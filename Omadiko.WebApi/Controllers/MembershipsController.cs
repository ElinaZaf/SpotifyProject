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
using AutoMapper;
using Omadiko.Database;
using Omadiko.Entities.Models;

namespace Omadiko.WebApi.Controllers
{
    public class MembershipsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Memberships
        public IQueryable<Membership> GetMemberships()
        {
            return db.Memberships;
        }

        // GET: api/Memberships/5
        [ResponseType(typeof(Membership))]
        public IHttpActionResult GetMembership(int id)
        {
            Membership membership = db.Memberships.Find(id);
            if (membership == null)
            {
                return NotFound();
            }

            return Ok(membership);
        }



        //// PUT: api/Memberships/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutMembership(int id, MembershipDto membershipDto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var membershipInDb = db.Memberships.Find(id);

        //    //if (id != membershipDto.MembershipId)
        //    //{
        //    //    return BadRequest();
        //    //}

        //    if (membershipInDb == null)
        //    {
        //        throw new HttpResponseException(HttpStatusCode.NotFound);
        //    }

        //    Mapper.Map(membershipDto, membershipInDb);
        //    db.Entry(membershipInDb).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!MembershipExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}







































        //// PUT: api/Memberships/PutMembership/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutMembership(int id, Membership membership)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != membership.MembershipId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(membership).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!MembershipExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST: api/Memberships
        [ResponseType(typeof(Membership))]
        public IHttpActionResult PostMembership(Membership membership)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Memberships.Add(membership);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = membership.MembershipId }, membership);
        }

        // DELETE: api/Memberships/5
        [ResponseType(typeof(Membership))]
        public IHttpActionResult DeleteMembership(int id)
        {
            Membership membership = db.Memberships.Find(id);
            if (membership == null)
            {
                return NotFound();
            }

            db.Memberships.Remove(membership);
            db.SaveChanges();

            return Ok(membership);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MembershipExists(int id)
        {
            return db.Memberships.Count(e => e.MembershipId == id) > 0;
        }
    }
}