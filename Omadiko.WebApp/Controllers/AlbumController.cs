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
using Omadiko.Entities.Models;
using Omadiko.RepositoryServices;
using PagedList;
using PagedList.Mvc;


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
            var artist = db.Artists.OrderBy(x=>x.Name).ToList().Select
                (x => new { ArtistId = x.ArtistId, FullName = String.Format($"{x.Name} {x.LastName}") });
            ViewBag.ArtistId = new SelectList(artist, "ArtistId", "FullName");
        }

        public void EditArtistViewBag(Album album)
        {
            var artist = db.Artists.OrderBy(x => x.Name).ToList().Select
                (x => new { ArtistId = x.ArtistId, FullName = String.Format($"{x.Name} {x.LastName}") });
            ViewBag.ArtistId = new SelectList(artist, "ArtistId", "FullName");
        }

        public void CreateSongViewBag()
        {
            ViewBag.SelectedSongIds = db.Songs.OrderBy(x => x.Title).ToList().Select(x =>
            new SelectListItem()
            {
                Value = x.SongId.ToString(),
                Text = String.Format($"{x.Title}")
            });
        }

        public void EditSongViewBag(Album album)
        {
            ViewBag.SelectedSongIds = db.Songs.OrderBy(x => x.Title).ToList().Select(x =>
            new SelectListItem()
            {
                Value = x.SongId.ToString(),
                Text = String.Format($"{x.Title}"),
                Selected = album.Songs.Any(g => g.SongId == x.SongId)
            });
        }

        public void CreateGenreViewBag()
        {
            ViewBag.SelectedGenreIds = db.Genres.OrderBy(x => x.Kind).ToList().Select(x =>
            new SelectListItem()
            {
                Value = x.GenreId.ToString(),
                Text = String.Format($"{x.Kind}")
            });
        }

        public void EditGenreViewBag(Album album)
        {
            ViewBag.SelectedGenreIds = db.Genres.OrderBy(x => x.Kind).ToList().Select(x =>
            new SelectListItem()
            {
                Value = x.GenreId.ToString(),
                Text = String.Format($"{x.Kind}"),
                Selected = album.Genres.Any(g=>g.GenreId == x.GenreId)
            });
        }



        // GET: Album
        [Authorize(Roles = Role.Admin)]
        public ActionResult Index(string searchBy, string search, int? page, string sortBy)
        {
            var albums = db.Albums.AsQueryable().Include(a => a.Artist);
            

            ViewBag.SortTitleParameter = string.IsNullOrEmpty(sortBy) ? "TitleDesc" : "";
            ViewBag.SortArtistParameter = sortBy == "ArtistDesc" ? "ArtistAsc" : "ArtistDesc";
            ViewBag.SortReleaseDateParameter = sortBy == "ReleaseDateDesc" ? "ReleaseDateAsc" : "ReleaseDateDesc";
            

            if (searchBy == "Title")
            {
                albums = albums.Where(x => x.Title.Contains(search) || search == null);

            }
            else if (searchBy == "Artist")
            {
                albums = albums.Where(x => x.Artist.Name.Contains(search) || x.Artist.LastName.Contains(search) || search == null);
            }
            else if (searchBy == "ReleaseDate")
            {
                int? searchByDate = Convert.ToInt32(search);
                albums = albums.Where(x => x.ReleaseDate.Year == searchByDate || searchByDate == null);
            }
            else if(searchBy == "Genre")
            {
                albums = albums.Where(x => x.Genres.Any(y => y.Kind.Contains(search)) || search == null);
            }

            switch (sortBy)
            {
                case "TitleDesc":
                    albums = albums.OrderByDescending(x => x.Title);
                    break;
                case "ArtistDesc":
                    albums = albums.OrderByDescending(x => x.Artist.Name);
                    break;
                case "ArtistAsc":
                    albums = albums.OrderBy(x => x.Artist.Name);
                    break;
                case "ReleaseDateDesc":
                    albums = albums.OrderByDescending(x => x.ReleaseDate);
                    break;
                case "ReleaseDateAsc":
                    albums = albums.OrderBy(x => x.ReleaseDate);
                    break;
                default:
                    albums = albums.OrderBy(x => x.Title);
                    break;
            }
            return View(albums.ToPagedList(page ?? 1, 10));
        }

        // GET: Album/Details/5
        [Authorize(Roles = Role.Admin)]
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
        [Authorize(Roles = Role.Admin)]
        public ActionResult Create()
        {
            CreateArtistViewBag();
            CreateGenreViewBag();
            CreateSongViewBag();

            return View();
        }

        // POST: Album/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = Role.Admin)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlbumId,Title,ReleaseDate,PhotoUrl,ArtistId")] Album album, IEnumerable<int> SelectedGenreIds, IEnumerable<int> SelectedSongIds)
        {
            if (ModelState.IsValid)
            {
                db.Albums.Attach(album);
                db.Entry(album).Collection("Genres").Load();
                album.Genres.Clear();
                db.Entry(album).Collection("Songs").Load();
                album.Songs.Clear();
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
                }

                if (!(SelectedSongIds is null))
                {
                    foreach (var id in SelectedSongIds)
                    {
                        Song song = db.Songs.Find(id);
                        if (song != null)
                        {
                            album.Songs.Add(song);
                        }
                    }
                }

                db.Entry(album).State = EntityState.Added;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            CreateArtistViewBag();
            CreateGenreViewBag();
            CreateSongViewBag();
            return View(album);
        }

        // GET: Album/Edit/5
        [Authorize(Roles = Role.Admin)]
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

            EditArtistViewBag(album);
            EditSongViewBag(album);
            EditGenreViewBag(album);
            return View(album);
        }

        // POST: Album/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = Role.Admin)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlbumId,Title,ReleaseDate,PhotoUrl,ArtistId")] Album album, IEnumerable<int> SelectedGenreIds, IEnumerable<int> SelectedSongIds)
        {
            if (ModelState.IsValid)
            {
                db.Albums.Attach(album);
                db.Entry(album).Collection("Genres").Load();
                album.Genres.Clear();
                db.Entry(album).Collection("Songs").Load();
                album.Songs.Clear();
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

                if (!(SelectedSongIds is null))
                {
                    foreach (var id in SelectedSongIds)
                    {
                        Song song = db.Songs.Find(id);
                        if (song != null)
                        {
                            album.Songs.Add(song);
                        }
                    }
                    db.SaveChanges();
                }

                db.Entry(album).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            db.Albums.Attach(album);
            CreateGenreViewBag();
            CreateSongViewBag();
            CreateArtistViewBag();

            return View(album);
        }

        // GET: Album/Delete/5
        [Authorize(Roles = Role.Admin)]
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
        [Authorize(Roles = Role.Admin)]
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
