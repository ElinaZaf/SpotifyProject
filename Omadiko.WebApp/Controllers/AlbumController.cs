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
    public class AlbumController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private AlbumRepository albumRepository = new AlbumRepository();


        public ActionResult ShowAlbums(string searchBy, string search, int? page)
        {
            List<Album> albums = albumRepository.GetAllOrderedByTitle();

            if (searchBy == "Title")
            {
                albums = albumRepository.GetAlbumsFilteredByTitle(search, albums);
            }
            if (searchBy == "Artist")
            {
                albums = albumRepository.GetAlbumsFilteredByArtistName(search, albums);
            }
            if (searchBy == "Release Year")
            {
                albums = albumRepository.GetAlbumsFilteredByReleaseYear(search, albums);
            }
            if (searchBy == "Genre")
            {
                albums = albumRepository.GetAlbumsFilteredByGenre(search, albums);
            }

            int pageSize = 18;
            int pageNumber = page ?? 1;
            return View(albums.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult ShowAlbumDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = albumRepository.GetById(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //ViewBags
        public void CreateArtistViewBag()
        {
            var artist = db.Artists.ToList().Select
                (x => new { ArtistId = x.ArtistId, FullName = String.Format($"{x.Name} {x.LastName}") });
            ViewBag.ArtistId = new SelectList(artist, "ArtistId", "FullName");
        }

        public void CreateGenreViewBag()
        {
            ViewBag.SelectedGenreIds = db.Genres.ToList().Select(x =>
            new SelectListItem()
            {
                Value = x.GenreId.ToString(),
                Text = String.Format($"{x.Kind}")
            });
        }



        // GET: Album
        public ActionResult Index()
        {
            var albums = db.Albums.Include(a => a.Artist);
            return View(albums.ToList());
        }

        // GET: Album/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // GET: Album/Create
        public ActionResult Create()
        {
            CreateArtistViewBag();
            CreateGenreViewBag();

            return View();
        }

        // POST: Album/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlbumId,Title,ReleaseDate,PhotoUrl,ArtistId")] Album album, IEnumerable<int> SelectedGenreIds)
        {
            if (ModelState.IsValid)
            {
                db.Albums.Attach(album);
                db.Entry(album).Collection("Genres").Load();
                album.Genres.Clear();
                db.SaveChanges();
                if (!(SelectedGenreIds is null))
                {
                    foreach (var id in SelectedGenreIds)
                    {
                        Genre genre = db.Genres.Find(id);
                        if (genre != null)
                        {
                            album.Genres.Add(genre);
                        }
                    }
                    //db.SaveChanges();
                }


                db.Entry(album).State = EntityState.Added;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            CreateArtistViewBag();
            CreateGenreViewBag();
            return View(album);
        }
       
        // GET: Album/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }

            CreateArtistViewBag();
            
            var genreIds = album.Genres.Select(x => x.GenreId);
            CreateGenreViewBag();
            return View(album);
        }

        // POST: Album/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlbumId,Title,ReleaseDate,PhotoUrl,ArtistId")] Album album, IEnumerable<int> SelectedGenreIds)
        {
            if (ModelState.IsValid)
            {
                db.Albums.Attach(album);
                db.Entry(album).Collection("Genres").Load();
                album.Genres.Clear();
                db.SaveChanges();
                if (!(SelectedGenreIds is null))
                {
                    foreach (var id in SelectedGenreIds)
                    {
                        Genre genre = db.Genres.Find(id);
                        if (genre != null)
                        {
                            album.Genres.Add(genre);
                        }
                    }
                    db.SaveChanges();
                }
                db.Entry(album).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            db.Albums.Attach(album);
            db.Entry(album).Collection("Genres").Load();
            var genreIds = album.Genres.Select(x => x.GenreId);
            CreateGenreViewBag();

            CreateArtistViewBag();

            return View(album);
        }

        // GET: Album/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // POST: Album/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Album album = db.Albums.Find(id);
            db.Albums.Remove(album);
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
