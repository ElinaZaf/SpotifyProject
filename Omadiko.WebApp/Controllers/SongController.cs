using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Omadiko.Database;
using Omadiko.Entities;
using Omadiko.RepositoryServices;
using PagedList;

namespace Omadiko.WebApp.Controllers
{
    public class SongController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private SongRepository songRepository = new SongRepository();

        public ActionResult ShowSongs(string searchBy, string search, int? page)
        {
            List<Song> songs = songRepository.GetAllOrderedByTitle();

            if (searchBy == "Title")
            {
                songs = songRepository.GetSongsFilteredByTitle(search, songs);
            }
            if (searchBy == "Artist")
            {
                songs = songRepository.GetSongsFilteredByArtistName(search, songs);
            }
            int pageSize = 18;
            int pageNumber = page ?? 1;
            return View(songs.ToPagedList(pageNumber, pageSize));
        }


        public ActionResult ShowSongDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Song song = songRepository.GetById(id);
            if (song == null)
            {
                return HttpNotFound();
            }

            return View(song);
        }












        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // GET: Song
        public ActionResult Index(string searchBy, string search, int? page, string sortBy)
        {
            ViewBag.SortNameParameter = string.IsNullOrEmpty(sortBy) ? "NameDesc" : "";
            var songs = db.Songs.AsQueryable();

            if (searchBy == "Title")
            {
                songs = songs.Where(x => x.Title.Contains(search));
                       
            }

            switch (sortBy)
            {
                case "NameDesc":
                    songs = songs.OrderByDescending(x => x.Title);
                    break;
                default:
                    songs = songs.OrderBy(x => x.Title);
                    break;

            }
            return View(songs.ToPagedList(page ?? 1, 10));
        }

        // GET: Song/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Song song = db.Songs.Find(id);
            if (song == null)
            {
                return HttpNotFound();
            }
            return View(song);
        }

        // GET: Song/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Song/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SongId,Title,Duration,AudioUrl,VideoUrl")] Song song)
        {
            if (ModelState.IsValid)
            {
                db.Songs.Add(song);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(song);
        }

        // GET: Song/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Song song = db.Songs.Find(id);
            if (song == null)
            {
                return HttpNotFound();
            }
            return View(song);
        }

        // POST: Song/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SongId,Title,Duration,AudioUrl,VideoUrl")] Song song)
        {
            if (ModelState.IsValid)
            {
                db.Entry(song).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(song);
        }

        // GET: Song/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Song song = db.Songs.Find(id);
            if (song == null)
            {
                return HttpNotFound();
            }
            return View(song);
        }

        // POST: Song/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Song song = db.Songs.Find(id);
            db.Songs.Remove(song);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
