using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Omadiko.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Latest()
        {
            return View();
        }
        public ActionResult FeaturedArtists()
        {
            return View();
        }
        public ActionResult FeaturedAlbums()
        {
            return View();
        }
        public ActionResult FeaturedSongs()
        {
            return View();
        }
        public ActionResult CreatePlaylis()
        {
            return View();
        }

        public ActionResult FavouriteArtists()
        {
            return View();
        }
        public ActionResult FavouriteAlbums()
        {
            return View();
        }
        public ActionResult FavouriteSongs()
        {
            return View();
        }

    }
}