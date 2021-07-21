using Omadiko.Database;
using Omadiko.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Omadiko.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            IndexHomeViewModel vm = new IndexHomeViewModel()
            {
                NewReleases = db.Albums.Where(x => x.ReleaseDate.Year >= 2018).Take(12).ToList(),
                FeaturedArtists = db.Artists.Take(12).ToList(),
                FeaturedAlbums = db.Albums.Take(12).ToList(),
                FeaturedSongs = db.Songs.Take(2).ToList(),
            };
            return View(vm);
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