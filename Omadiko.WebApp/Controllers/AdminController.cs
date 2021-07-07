using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Omadiko.WebApp.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult UserList()
        {
            return View();
        }
        public ActionResult UserAdd()
        {
            return View();
        }

        public ActionResult Category()
        {
            return View();
        }

        public ActionResult Album()
        {
            return View();
        }

        public ActionResult Artist()
        {
            return View();
        }

        public ActionResult Song()
        {
            return View();
        }
    }
}