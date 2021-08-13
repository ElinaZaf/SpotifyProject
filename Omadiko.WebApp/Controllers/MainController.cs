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
        // GET: Main
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Premium()
        {
            return View();
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