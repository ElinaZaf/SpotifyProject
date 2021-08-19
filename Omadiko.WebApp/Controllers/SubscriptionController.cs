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

namespace Omadiko.WebApp.Controllers
{
    public class SubscriptionController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        MembershipRepository membershipRepository = new MembershipRepository();
        private string strSubscription = "Subscription";

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Success()
        {
            return View();
        }


        public ActionResult Failure()
        {
            return View();
        }

        public ActionResult OrderNow(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (Session[strSubscription] == null)
            {
                Subscription selectedSubscription = new Subscription(membershipRepository.GetById(id), 1);
                Session[strSubscription] = selectedSubscription;

                List<Subscription> lsSubscription = new List<Subscription>
                {
                    new Subscription(membershipRepository.GetById(id),1)
                };
                Session[strSubscription] = lsSubscription;
            }
            else
            {
                List<Subscription> lsSubscription = (List<Subscription>)Session[strSubscription];
                int check = isExistingCheck(id);
                if (check == -1)
                {
                    lsSubscription.Add(new Subscription(membershipRepository.GetById(id), 1));
                }
                else
                {
                    lsSubscription[check].Quantity++;
                }
            }
            return View("Index");
        }

        private int isExistingCheck(int? id)
        {
            List<Subscription> lsSubscription = (List<Subscription>)Session[strSubscription];
            for (int i = 0; i < lsSubscription.Count; i++)
            {
                if (lsSubscription[i].Membership.MembershipId == id)
                {
                    return i;
                }
            }
            return -1;
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<Subscription> lsSubscription = (List<Subscription>)Session[strSubscription];
            int check = isExistingCheck(id);
            lsSubscription.RemoveAt(check);
            Session[strSubscription] = lsSubscription;
            return View("Index");
        }


        private Payment payment;

        private Payment CreatePayment(APIContext apiContext, string redirectUrl)
        {
            var listItems = new ItemList()
            {
                items = new List<Item>()
            };

            List<Subscription> listSubscription = (List<Subscription>)Session[strSubscription];
            foreach (var subscription in listSubscription)
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
                subtotal = listSubscription.Sum(x => x.Quantity * x.Membership.SignUpFee).ToString()
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
                    string baseURI = Request.Url.Scheme + "://" + Request.Url.Authority + "/Subscription/PaymentWithPaypal?";
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
            catch (Exception)
            {
                //PaypalLogger.Log("Error: " + ex.Message);
                return View("Failure");
            }
            return View("Success");
        }

    }
}