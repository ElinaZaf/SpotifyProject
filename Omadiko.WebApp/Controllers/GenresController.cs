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
using PagedList;
using PagedList.Mvc;

namespace Omadiko.WebApp.Controllers
{
    [Authorize(Roles = Role.Admin)]
    public class GenresController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Genres
        public ActionResult Index(string searchBy, string search, int? page, string sortBy)
        {
            ViewBag.SortNameParameter = string.IsNullOrEmpty(sortBy) ? "NameDesc" : "";
            var genres = db.Genres.AsQueryable();

            if (searchBy == "Kind")
            {
                genres = genres.Where(x => x.Kind.Contains(search) || search == null);

            }

            switch (sortBy)
            {
                case "NameDesc":
                    genres = genres.OrderByDescending(x => x.Kind);
                    break;
                default:
                    genres = genres.OrderBy(x => x.Kind);
                    break;

            }
            return View(genres.ToPagedList(page ?? 1, 5));
        }

        // GET: Genres/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genre genre = db.Genres.Find(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        // GET: Genres/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Genres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GenreId,Kind")] Genre genre)
        {
            if (ModelState.IsValid)
            {
                db.Genres.Add(genre);
                db.SaveChanges();
                TempData["Successfull Create"] = true;
                TempData["Status"] = "You have Successfully Created this Genre: " + genre.Kind;
                return RedirectToAction("Index");
            }
            return View(genre);
        }

        // GET: Genres/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genre genre = db.Genres.Find(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        // POST: Genres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GenreId,Kind")] Genre genre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(genre).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Successfull Edit"] = true;
                TempData["Status"] = "You have Successfully Edited this Genre: " + genre.Kind;
                return RedirectToAction("Index");
            }
            return View(genre);
        }

        // GET: Genres/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genre genre = db.Genres.Find(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        // POST: Genres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Genre genre = db.Genres.Find(id);
            db.Genres.Remove(genre);
            db.SaveChanges();
            TempData["Successfull Delete"] = true;
            TempData["Status"] = "You have Successfully Deleted this Genre: " + genre.Kind;
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
