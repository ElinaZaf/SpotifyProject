using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Omadiko.Database;
using Omadiko.WebApp.Models;
using Omadiko.RepositoryServices;
using PayPal.Api;
using Omadiko.Entities.Models;
using System.Net;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using Omadiko.Entities;

namespace Omadiko.WebApp.Controllers
{
    public class ShoppingCartController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        MembershipRepository membershipRepository = new MembershipRepository();
        ApplicationUserRepository applicationUserRepository = new ApplicationUserRepository();
        private string strCart = "Cart";

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OrderNow(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (Session[strCart] == null)
            {
                var cart = new Cart() { Membership = membershipRepository.GetById(id), Quantity = 1, DateCreated = DateTime.Now };
                List<Cart> listCart = new List<Cart>() { cart };
                Session[strCart] = listCart;
            }
            else
            {
                Session[strCart] = null;
                OrderNow(id);
            }
            
            return View("Index");
        }


        public ActionResult CheckOut(FormCollection frc)
        {
            List<Cart> listCart = (List<Cart>)Session[strCart];
            var subscription = new Subscription()
            {
                OrderDate = DateTime.Now,
                PaymentType = "PayPal",
                CustomerFirstName = frc["firstName"],
                CustomerLastName = frc["lastName"],
                CustomerAddress = frc["address"],
                CustomerCity = frc["city"],
                CustomerCountry = frc["country"]
                
            };
            db.Subscriptions.Add(subscription);
            db.SaveChanges();

            foreach (var cart in listCart)
            {
                var subscriptionDetails = new SubscriptionDetails()
                {
                    SubscriptionId = subscription.SubscriptionId,
                    MembershipId = cart.Membership.MembershipId,
                    Quantity = 1,
                    Price = cart.Membership.SignUpFee
                };
                db.SubscriptionsDetails.Add(subscriptionDetails);
                db.SaveChanges();
            }
            var user = db.Users.Find(User.Identity.GetUserId());
            user.Subscriptions = new List<Subscription>() { subscription };
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("PaymentWithPaypal");
        }


        private Payment payment;

        private Payment CreatePayment(APIContext apiContext, string redirectUrl)
        {
            var listItems = new ItemList()
            {
                items = new List<Item>()
            };

            List<Cart> listCart = (List<Cart>)Session[strCart];
            foreach (var subscription in listCart)
            {
                listItems.items.Add(new Item()
                {
                    name = subscription.Membership.Type,
                    currency = "EUR",
                    price = subscription.Membership.SignUpFee.ToString(),
                    quantity = subscription.Quantity.ToString(),
                    sku = "sku"
                });

            }

            var payer = new Payer()
            {
                payment_method = "paypal"
            };

            var redirUrls = new RedirectUrls()
            {
                cancel_url = redirectUrl,
                return_url = redirectUrl
            };

            var details = new Details()
            {
                tax = "1",
                shipping = "1",
                subtotal = listCart.Sum(x => x.Quantity * x.Membership.SignUpFee).ToString()
            };

            var amount = new Amount()
            {
                currency = "EUR",
                total = (Convert.ToDouble(details.tax) + Convert.ToDouble(details.shipping) + Convert.ToDouble(details.subtotal)).ToString(),
                details = details
            };

            var transactionList = new List<Transaction>();
            transactionList.Add(new Transaction()
            {
                description = "Subscription to Muzik Premium",
                invoice_number = Convert.ToString((new Random()).Next(100000)),
                amount = amount,
                item_list = listItems
            });

            payment = new Payment()
            {
                intent = "sale",
                payer = payer,
                transactions = transactionList,
                redirect_urls = redirUrls
            };
            return payment.Create(apiContext);
        }

        private Payment ExecutePayment(APIContext apiContext, string payerId, string paymentId)
        {
            var paymentExecution = new PaymentExecution()
            {
                payer_id = payerId
            };
            payment = new Payment()
            {
                id = paymentId
            };
            return payment.Execute(apiContext, paymentExecution);
        }

        public ActionResult PaymentWithPaypal()
        {
            APIContext apiContext = PaypalConfiguration.GetAPIContext();
            try
            {
                string payerId = Request.Params["PayerID"];
                if (string.IsNullOrEmpty(payerId))
                {
                    string baseURI = Request.Url.Scheme + "://" + Request.Url.Authority + "/ShoppingCart/PaymentWithPaypal?";
                    var guid = Convert.ToString((new Random()).Next(100000));
                    var createdPayment = CreatePayment(apiContext, baseURI + "guid=" + guid);

                    var links = createdPayment.links.GetEnumerator();
                    string paypalRedirectUrl = string.Empty;
                    while (links.MoveNext())
                    {
                        Links link = links.Current;
                        if (link.rel.ToLower().Trim().Equals("approval_url"))
                        {
                            paypalRedirectUrl = link.href;
                        }
                    }
                    Session.Add(guid, createdPayment.id);
                    return Redirect(paypalRedirectUrl);
                }
                else
                {
                    var guid = Request.Params["guid"];
                    var executedPayment = ExecutePayment(apiContext, payerId, Session[guid] as string);
                    if (executedPayment.state.ToLower() != "approved")
                    {
                        return View("Failure");
                    }
                }
            }
            catch (Exception ex)
            {
                PaypalLogger.Log("Error: " + ex.Message);
                return View("Failure");
            }
            return View("Success");
        }

        public ActionResult Success()
        {
            return View();
        }

        public ActionResult Failure()
        {
            return View();
        }






















    }










    //List<Cart> listCart = (List<Cart>)Session[strCart];
    //Subscription subscription = new Subscription()
    //{
    //    FirstName = frc["firstName"],
    //    LastName = frc["lastName"],
    //    Address = frc["address"],
    //    City = frc["city"],
    //    PostalCode = frc["postalCode"],
    //    Country = frc["country"],
    //    Phone = frc["phone"],
    //    Email = frc["email"],
    //    OrderDate = DateTime.Now
    //};
    //db.Subscriptions.Add(subscription);
    //db.SaveChanges();

    //foreach (var cart in listCart)
    //{
    //    SubscriptionDetails subscriptionDetails = new SubscriptionDetails()
    //    {
    //        SubscriptionId = subscription.SubscriptionId,
    //        MembershipId = cart.Membership.MembershipId,
    //        Quantity = cart.Quantity,
    //        Price = cart.Membership.SignUpFee
    //    };
    //    db.SubscriptionsDetails.Add(subscriptionDetails);
    //    db.SaveChanges();
    //}
    //return View("CheckOut");
}



