using Omadiko.RepositoryServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using Omadiko.Database;
using AutoMapper;
using Omadiko.Entities.Models;
using System.Web.Http.Description;
using System.Data.Entity.Infrastructure;

namespace Omadiko.WebApi.Controllers
{
    public class ApplicationUsersController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationUserRepository applicationUserRepository = new ApplicationUserRepository();
       
        [HttpPost]
        public IHttpActionResult GetCurrentApplicationUserPhotoUrl(string id)
        {
            var applicationUser = applicationUserRepository.GetById(id);
            if (applicationUser == null)
            {
                return NotFound();
            }

            var photoUrl = applicationUser.PhotoUrl;

            if (!(photoUrl is null))
            {
                return Ok(photoUrl);
            }
            else
            {
                if (applicationUser.Gender == Gender.Male)
                {
                    return Ok("/Content/images/UserImages/male.png");
                }
                else if (applicationUser.Gender == Gender.Female)
                {
                    return Ok("/Content/images/UserImages/female.png");
                }
                else
                {
                    return Ok("/Content/images/UserImages/nonbinary.png");
                }
            }
        }


        // PUT: api/ApplicationUsers/PutApplicationUser/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutApplicationUser(string id, ApplicationUserDto applicationUserDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var applicationUser = db.Users.Find(id);

            if (applicationUser == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(applicationUserDto, applicationUser);
            db.Entry(applicationUser).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationUserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }


        private bool ApplicationUserExists(string id)
        {
            return db.Users.Count(e => e.Id == id) > 0;
        }

        //[HttpPost]
        //public void addArtistToFavorites(int id)
        //{
        //    var user = applicationUserRepository.GetById(User.Identity.GetUserId());
        //    var countFavorite = user.FavouriteArtists.Where(x => x.ArtistId == id).Count();
        //    if (countFavorite == 0)
        //    {
        //        List<string> errors = new List<string>();
        //        user.FavouriteArtists.Add(artistRepository.GetById(id));
        //        db.Entry(user).State = EntityState.Modified;
        //        db.SaveChanges();
        //    }
        //}


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
