using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Omadiko.Database;
using Omadiko.Entities;
using Omadiko.RepositoryServices;

namespace Omadiko.WebApi.Controllers
{
    public class AlbumsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private AlbumRepository albumRepository;

        public AlbumsController()
        {
            this.albumRepository = new AlbumRepository(db);
        }

        [ResponseType(typeof(Album))]
        public IHttpActionResult GetAlbumSongs(int id)
        {
            Album album = albumRepository.GetById(id);
            if (album == null)
            {
                return NotFound();
            }

            return Ok(album.Songs.Select(song => new { id = song.SongId, name = song.Title, artist = string.Format($"{song.Albums.First().Artist.Name} {song.Albums.First().Artist.LastName}"), image = song.Albums.First().PhotoUrl.TrimStart('~'), path = song.AudioUrl }));
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AlbumExists(int id)
        {
            return db.Albums.Count(e => e.AlbumId == id) > 0;
        }
    }
}