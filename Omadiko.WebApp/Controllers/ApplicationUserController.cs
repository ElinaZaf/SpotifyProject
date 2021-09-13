using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Omadiko.Database;
using Omadiko.Entities;
using Omadiko.Entities.Models;
using Omadiko.RepositoryServices;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Omadiko.WebApp.Controllers
{
    public class ApplicationUserController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationUserRepository userRepository;
        public UserManager<ApplicationUser> UserManager { get; set; }

        public ApplicationUserController()
        {
            this.userRepository = new ApplicationUserRepository(db);
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
        }


        public ActionResult UserProfile(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = userRepository.GetById(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        public ActionResult UpdateRole(string id)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            ApplicationUser applicationUser = userRepository.GetById(id);
            if (!(applicationUser.Subscriptions.Count == 0))
            {
                var result = userManager.AddToRole(applicationUser.Id, Role.Subscriber);
                return Json(result.Succeeded, JsonRequestBehavior.AllowGet);
            }

            return new EmptyResult();
        }

        public ActionResult EditProfile(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = userRepository.GetById(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        public ActionResult SubscriptionDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = userRepository.GetById(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        [Authorize(Roles = Role.Admin + "," + Role.Subscriber)]
        public ActionResult FavouriteAlbums(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = userRepository.GetById(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }


        [Authorize(Roles = Role.Admin + "," + Role.Subscriber)]
        public ActionResult FavouriteArtists(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = userRepository.GetById(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }


        [Authorize(Roles = Role.Admin + "," + Role.Subscriber)]
        public ActionResult FavouriteSongs(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = userRepository.GetById(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }



        //============================================= Admin crud and views ============================================================//

        //=== Show all users Admin index view ===//
        public ActionResult Index(string searchBy, string search, int? page, string sortBy)
        {
            ViewBag.SortFNameParameter = string.IsNullOrEmpty(sortBy) ? "FNameDesc" : "";
            ViewBag.SortLNameParameter = sortBy == "LNameDesc" ? "LNameAsc" : "LNameDesc";
            ViewBag.SortCityParameter = sortBy == "CityDesc" ? "CityAsc" : "CityDesc";
            ViewBag.SortCountryParameter = sortBy == "CountryDesc" ? "CountryAsc" : "CountryDesc";
            ViewBag.SortDoBParameter = sortBy == "DoBDesc" ? "DoBAsc" : "DoBDesc";
            var members = db.Users.AsQueryable();

            if (searchBy == "First Name")
            {
                members = members.Where(x => x.FirstName.Contains(search) || search == null);

            }
            else if (searchBy == "Last Name")
            {
                members = members.Where(x => x.LastName.Contains(search) || x.LastName.Contains(search) || search == null);
            }
            else if (searchBy == "City")
            {
                members = members.Where(x => x.City.Contains(search) || search == null);
            }
            else if (searchBy == "Country")
            {
                members = members.Where(x => x.Country.Contains(search) || search == null);
            }

            switch (sortBy)
            {
                case "FNameDesc":
                    members = members.OrderByDescending(x => x.FirstName);
                    break;
                case "LNameDesc":
                    members = members.OrderByDescending(x => x.LastName);
                    break;
                case "LNameAsc":
                    members = members.OrderBy(x => x.LastName);
                    break;
                case "CityDesc":
                    members = members.OrderByDescending(x => x.City);
                    break;
                case "CityAsc":
                    members = members.OrderBy(x => x.City);
                    break;
                case "CountryDesc":
                    members = members.OrderByDescending(x => x.Country);
                    break;
                case "CountryAsc":
                    members = members.OrderBy(x => x.Country);
                    break;
                case "DoBDesc":
                    members = members.OrderByDescending(x => x.DateOfBirth);
                    break;
                case "DoBAsc":
                    members = members.OrderBy(x => x.DateOfBirth);
                    break;
                default:
                    members = members.OrderBy(x => x.FirstName);
                    break;
            }

            return View(members.ToPagedList(page ?? 1, 2));
        }

        // GET: User/Delete/5
        [Authorize(Roles = Role.Admin)]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var member = db.Users.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: User/Delete/5
        [Authorize(Roles = Role.Admin)]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            var member = db.Users.Find(id);
            member.Subscriptions.Clear();
            db.Users.Remove(member);
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