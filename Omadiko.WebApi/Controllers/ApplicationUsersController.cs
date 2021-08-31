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
using Omadiko.Entities;
using Omadiko.WebApi.Dtos;
using AutoMapper;
using Omadiko.Entities.Models;

namespace Omadiko.WebApi.Controllers
{
    public class ApplicationUsersController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationUserRepository applicationUserRepository = new ApplicationUserRepository();
        private ArtistRepository artistRepository = new ArtistRepository();


        //GET /api/ApplicationUsers
        //public IEnumerable<ApplicationUserDto> GetApplicationUsers()
        //{
        //    return db.Users.ToList().Select(Mapper.Map<ApplicationUser, ApplicationUserDto>);
        //}

        ////GET /api/ApplicationUsers/1
        //public IHttpActionResult GetCurrentApplicationUser(string id)
        //{
        //    var applicationUser = db.Users.SingleOrDefault(x => User.Identity.GetUserId() == id);
        //    if (applicationUser == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(Mapper.Map<ApplicationUser, ApplicationUserDto>(applicationUser));
        //}

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







    }
}
