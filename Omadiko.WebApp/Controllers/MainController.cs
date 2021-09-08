using Omadiko.Database;
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
        private ApplicationDbContext db = new ApplicationDbContext();
        private MembershipRepository membershipRepository;

        public MainController()
        {
            this.membershipRepository = new MembershipRepository(db);
        }

        public ActionResult Index()
        {
            return View();
        }
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