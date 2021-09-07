using Omadiko.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Web.Http.Results;
using Omadiko.Entities;

namespace Omadiko.WebApp.Controllers
{
    public class SubscriberController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();


        // GET: Subscriber
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult addFavoriteAlbum(int albumId)
        {
            var user = db.Users.Find(User.Identity.GetUserId());
            var album = db.Albums.Find(albumId);
            bool result;
            if (!(user.FavouriteAlbums.Any(x => x.AlbumId == albumId)))
            {
                user.FavouriteAlbums.Add(album);
                db.SaveChanges();
                result = true;
            }
            else
            {
                user.FavouriteAlbums.Remove(album);
                db.SaveChanges();
                result = false;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult addFavoriteArtist(int artistId)
        {
            var user = db.Users.Find(User.Identity.GetUserId());
            var artist = db.Artists.Find(artistId);
            bool result;
            if (!(user.FavouriteArtists.Any(x => x.ArtistId == artistId)))
            {
                user.FavouriteArtists.Add(artist);
                db.SaveChanges();
                result = true;
            }
            else
            {
                user.FavouriteArtists.Remove(artist);
                db.SaveChanges();
                result = false;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult addFavoriteSong(int songId)
        {
            var user = db.Users.Find(User.Identity.GetUserId());
            var song = db.Songs.Find(songId);
            bool result;
            if (!(user.FavouriteSongs.Any(x => x.SongId == songId)))
            {
                user.FavouriteSongs.Add(song);
                db.SaveChanges();
                result = true;
            }
            else
            {
                user.FavouriteSongs.Remove(song);
                db.SaveChanges();
                result = false;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}