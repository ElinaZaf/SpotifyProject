using Omadiko.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Web.Http.Results;
using Omadiko.Entities;
using Omadiko.RepositoryServices;

namespace Omadiko.WebApp.Controllers
{
    public class SubscriberController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationUserRepository userRepository;
        private ArtistRepository artistRepository;
        private AlbumRepository albumRepository;
        private SongRepository songRepository;

        public SubscriberController()
        {
            this.userRepository = new ApplicationUserRepository(db);
            this.artistRepository = new ArtistRepository(db);
            this.albumRepository = new AlbumRepository(db);
            this.songRepository = new SongRepository(db);
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult addFavoriteAlbum(int albumId)
        {
            var user = userRepository.GetById(User.Identity.GetUserId());
            var album = albumRepository.GetById(albumId);
            bool result;
            if (!(user.FavouriteAlbums.Any(x => x.AlbumId == albumId)))
            {
                user.FavouriteAlbums.Add(album);
                userRepository.Save();
                result = true;
            }
            else
            {
                user.FavouriteAlbums.Remove(album);
                userRepository.Save();
                result = false;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult addFavoriteArtist(int artistId)
        {
            var user = userRepository.GetById(User.Identity.GetUserId());
            var artist = artistRepository.GetById(artistId);
            bool result;
            if (!(user.FavouriteArtists.Any(x => x.ArtistId == artistId)))
            {
                user.FavouriteArtists.Add(artist);
                userRepository.Save();
                result = true;
            }
            else
            {
                user.FavouriteArtists.Remove(artist);
                userRepository.Save();
                result = false;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult addFavoriteSong(int songId)
        {
            var user = userRepository.GetById(User.Identity.GetUserId());
            var song = songRepository.GetById(songId);
            bool result;
            if (!(user.FavouriteSongs.Any(x => x.SongId == songId)))
            {
                user.FavouriteSongs.Add(song);
                userRepository.Save();
                result = true;
            }
            else
            {
                user.FavouriteSongs.Remove(song);
                userRepository.Save();
                result = false;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}