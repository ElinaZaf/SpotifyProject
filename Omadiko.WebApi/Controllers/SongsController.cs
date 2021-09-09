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
    public class SongsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private SongRepository songRepository;

        public SongsController()
        {
            this.songRepository = new SongRepository(db);
        }

        [ResponseType(typeof(Song))]
        public IHttpActionResult GetSong(int id)
        {
            Song song = songRepository.GetById(id);
            if (song == null)
            {
                return NotFound();
            }

            return Ok(new { id = song.SongId, name = song.Title, artist = string.Format($"{song.Albums.First().Artist.Name} {song.Albums.First().Artist.LastName}"), image=song.Albums.First().PhotoUrl.TrimStart('~'), path = song.AudioUrl });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SongExists(int id)
        {
            return db.Songs.Count(e => e.SongId == id) > 0;
        }
    }
}