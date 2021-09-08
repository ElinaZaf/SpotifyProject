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

namespace Omadiko.WebApp.Controllers
{
    public class ArtistController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ArtistRepository artistRepository;

        public ArtistController()
        {
            this.artistRepository = new ArtistRepository(db);
        }

        public ActionResult ShowArtists(string searchBy, string search, int? page)
        {
            List<Artist> artists = artistRepository.GetAllOrderedByName();

            if (searchBy == "Name")
            {
                artists = artistRepository.GetArtistsFilteredByName(search, artists);
            }
            if (searchBy == "Country")
            {
                artists = artistRepository.GetArtistsFilteredByCountry(search, artists);
            }

            int pageSize = 18;
            int pageNumber = page ?? 1;
            return View(artists.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult ShowArtistDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = artistRepository.GetById(id);
            if (artist == null)
            {
                return HttpNotFound();
            }

            return View(artist);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // ViewBags
        public void CreateAlbumViewBag()
        {
            ViewBag.SelectedAlbumIds = db.Albums.OrderBy(x => x.Title).ToList().Select(x =>
            new SelectListItem()
            {
                Value = x.AlbumId.ToString(),
                Text = String.Format($"{x.Title}")
            });
        }

        public void EditAlbumViewBag(Artist artist)
        {
            ViewBag.SelectedAlbumIds = db.Albums.OrderBy(x => x.Title).ToList().Select(x =>
            new SelectListItem()
            {
                Value = x.AlbumId.ToString(),
                Text = String.Format($"{x.Title}"),
                Selected = artist.Albums.Any(g => g.AlbumId == x.AlbumId)
            });
        }
        // GET: Artist
        [Authorize(Roles = Role.Admin)]
        public ActionResult Index(string searchBy, string search, int? page, string sortBy)
        {
            ViewBag.SortFNameParameter = string.IsNullOrEmpty(sortBy) ? "FNameDesc" : "";
            ViewBag.SortLNameParameter = sortBy == "LNameDesc" ? "LNameAsc" : "LNameDesc";
            ViewBag.SortCountryParameter = sortBy == "CountryDesc" ? "CountryAsc" : "CountryDesc";
            var artist = db.Artists.AsQueryable();
            if (searchBy == "FirstName")
            {
                artist = artist.Where(x => x.Name.Contains(search) || search == null);

            }
            else if (searchBy == "LastName")
            {
                artist = artist.Where(x => x.LastName.Contains(search) || search == null);
            }
            else if (searchBy == "Country")
            {
                artist = artist.Where(x => x.Country.Contains(search) || search == null);
            }

            switch (sortBy)
            {
                case "FNameDesc":
                    artist = artist.OrderByDescending(x => x.Name);
                    break;
                case "LNameDesc":
                    artist = artist.OrderByDescending(x => x.LastName);
                    break;
                case "LNameAsc":
                    artist = artist.OrderBy(x => x.LastName);
                    break;
                case "CountryDesc":
                    artist = artist.OrderByDescending(x => x.Country);
                    break;
                case "CountryAsc":
                    artist = artist.OrderBy(x => x.Country);
                    break;
                default:
                    artist = artist.OrderBy(x => x.Name);
                    break;

            }
            return View(artist.ToPagedList(page ?? 1, 10));
        }

        // GET: Artist/Details/5
        [Authorize(Roles = Role.Admin)]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        // GET: Artist/Create
        [Authorize(Roles = Role.Admin)]
        public ActionResult Create()
        {
            CreateAlbumViewBag();
            return View();
        }

        // POST: Artist/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = Role.Admin)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArtistId,Name,LastName,Country,DateOfBirth,DateOfDeath,PhotoUrl")] Artist artist, IEnumerable<int> SelectedAlbumIds)
        {
            if (ModelState.IsValid)
            {
                db.Artists.Add(artist);
                db.Entry(artist).Collection("Albums").Load();
                artist.Albums.Clear();
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            CreateAlbumViewBag();
            return View(artist);
        }

        // GET: Artist/Edit/5
        [Authorize(Roles = Role.Admin)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            EditAlbumViewBag(artist);
            return View(artist);
        }

        // POST: Artist/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = Role.Admin)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArtistId,Name,LastName,Country,DateOfBirth,DateOfDeath,PhotoUrl")] Artist artist, IEnumerable<int> SelectedAlbumIds)
        {
            if (ModelState.IsValid)
            {
                db.Artists.Attach(artist);
                db.Entry(artist).Collection("Albums").Load();
                artist.Albums.Clear();
                db.SaveChanges();

                if (!(SelectedAlbumIds is null))
                {
                    foreach (var id in SelectedAlbumIds)
                    {
                        Album album = db.Albums.Find(id);
                        if (album != null)
                        {
                            artist.Albums.Add(album);
                        }
                    }
                    db.SaveChanges();
                }

                db.Entry(artist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(artist);
        }

        // GET: Artist/Delete/5
        [Authorize(Roles = Role.Admin)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        // POST: Artist/Delete/5
        [Authorize(Roles = Role.Admin)]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Artist artist = db.Artists.Find(id);
            db.Artists.Remove(artist);
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
