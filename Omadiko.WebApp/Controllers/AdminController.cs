using Omadiko.Database;
using Omadiko.Entities;
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
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin
        public ActionResult Index()
        {
            ViewBag.TotalArtists = db.Artists.Count();
            ViewBag.TotalUsers = db.Users.Count();
            ViewBag.TotalAlbums = db.Albums.Count();
            ViewBag.TotalSongs = db.Songs.Count();

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