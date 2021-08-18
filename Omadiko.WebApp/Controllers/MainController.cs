using Omadiko.RepositoryServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Omadiko.WebApp.Controllers
{
    [AllowAnonymous]
    public class MainController : Controller
    {
        private MembershipRepository membershipRepository = new MembershipRepository();

        // GET: Main
        public ActionResult Index()
        {
            return View();
        }


        // GET: Subscription
        public ActionResult Premium()
        {
            return View(membershipRepository.GetAll());
        }

        public ActionResult Support()
        {
            return View();
        }
        public ActionResult Faq()
        {
            return View();
        }

       
    }
}