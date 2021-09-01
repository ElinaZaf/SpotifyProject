﻿using Microsoft.AspNet.Identity;
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
        private ApplicationUserRepository applicationUserRepository = new ApplicationUserRepository();
        public UserManager<ApplicationUser> UserManager { get; set; }
        public ApplicationUserController()
        {
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
        }

        public ActionResult UserProfile(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = applicationUserRepository.GetById(id);
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
            ApplicationUser applicationUser = applicationUserRepository.GetById(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }




        [Authorize(Roles = Role.Subscriber)]
        public ActionResult FavouriteAlbums(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = applicationUserRepository.GetById(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        [Authorize(Roles = Role.Subscriber)]
        public ActionResult FavouriteArtists(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = applicationUserRepository.GetById(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        [Authorize(Roles = Role.Subscriber)]
        public ActionResult FavouriteSongs(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = applicationUserRepository.GetById(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

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
    }
}