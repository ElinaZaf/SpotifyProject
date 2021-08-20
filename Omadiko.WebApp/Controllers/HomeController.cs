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
                LatestReleases = db.Albums.OrderByDescending(x => x.ReleaseDate).Take(5).ToList(),
                FeaturedArtists = db.Artists.OrderBy(x => Guid.NewGuid()).Take(12).ToList(),
                FeaturedAlbums = db.Albums.OrderBy(x => Guid.NewGuid()).Take(12).ToList(),
                FeaturedSongs = db.Songs.OrderBy(x => Guid.NewGuid()).Take(12).ToList(),
            };
            return View(vm);
        }

       
    }
}