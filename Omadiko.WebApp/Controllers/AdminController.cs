using Omadiko.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Omadiko.WebApp.Controllers
{
    [Authorize(Roles = Role.Admin)]
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
    }
}