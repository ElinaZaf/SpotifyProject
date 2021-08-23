using Omadiko.Database;
using Omadiko.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Omadiko.RepositoryServices.RepositoryServices
{
    public class ShoppingCart
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        //string ShoppingCartId { get; set; }
        //public const string CartSessionKey = "CartId";

        //public static ShoppingCart GetCart(HttpContextBase context)
        //{
        //    var cart = new ShoppingCart();
        //    cart.ShoppingCartId = cart.GetCartId(context);
        //    return cart;
        //}

        //public static ShoppingCart GetCart(Controller controller)
        //{
        //    return GetCart(controller.HttpContext);
        //}


        //public void EmptyCart()
        //{
        //    var cartItems = db.Carts.Where(
        //        cart => cart.CartId == ShoppingCartId);

        //    foreach (var cartItem in cartItems)
        //    {
        //        db.Carts.Remove(cartItem);
        //    }
        //    db.SaveChanges();
        //}

        //public List<Cart> GetCartItems()
        //{
        //    return db.Carts.Where(
        //        cart => cart.CartId == ShoppingCartId).ToList();
        //}

        //public decimal GetTotal()
        //{
        //    decimal? total = (from cartItems in db.Carts
        //                      where cartItems.CartId == ShoppingCartId
        //                      select (int?)cartItems.Quantity * cartItems.Membership.SignUpFee).Sum();
        //    return total ?? decimal.Zero;
        //}


        //public int Subscribe(Subscription subscription)
        //{
        //    var cartItems = GetCartItems();

        //    foreach (var item in cartItems)
        //    {
        //        var subscriptionDetails = new SubscriptionDetails
        //        {
        //            MembershipId = item.MembershipId,
        //            SubscriptionId = subscription.SubscriptionId,
        //            Price = item.Membership.SignUpFee,
        //            Quantity = item.Quantity
        //        };

        //        db.SubscriptionsDetails.Add(subscriptionDetails);

        //    }
        //    db.SaveChanges();
        //    EmptyCart();
        //    return subscription.SubscriptionId;
        //}

        //public string GetCartId(HttpContextBase context)
        //{
        //    if (context.Session[CartSessionKey] == null)
        //    {
        //        if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
        //        {
        //            context.Session[CartSessionKey] =
        //                context.User.Identity.Name;
        //        }
        //        else
        //        {
        //            Guid tempCartId = Guid.NewGuid();
        //            context.Session[CartSessionKey] = tempCartId.ToString();
        //        }
        //    }
        //    return context.Session[CartSessionKey].ToString();
        //}

        //public void MigrateCart(string userName)
        //{
        //    var shoppingCart = db.Carts.Where(
        //        c => c.CartId == ShoppingCartId);

        //    foreach (Cart item in shoppingCart)
        //    {
        //        item.CartId = userName;
        //    }
        //    db.SaveChanges();
        //}
    }
}
