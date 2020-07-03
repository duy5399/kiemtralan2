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
using KTGiuaKi2.Models;

namespace KTGiuaKi2.Controllers
{
    public class PHONEsController : ApiController
    {
        private QLDLPhoneEntities db = new QLDLPhoneEntities();

        // GET: api/PHONEs
        public IQueryable<PHONE> GetPHONEs()
        {
            return db.PHONEs;
        }

        // GET: api/PHONEs/5
        [ResponseType(typeof(PHONE))]
        public IHttpActionResult GetPHONE(int id)
        {
            PHONE pHONE = db.PHONEs.Find(id);
            if (pHONE == null)
            {
                return NotFound();
            }

            return Ok(pHONE);
        }

        // PUT: api/PHONEs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPHONE(int id, PHONE pHONE)
        {


            if (id != pHONE.ID)
            {
                return BadRequest();
            }

            db.Entry(pHONE).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PHONEExists(id))
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

        // POST: api/PHONEs
        [ResponseType(typeof(PHONE))]
        public IHttpActionResult PostPHONE(PHONE pHONE)
        {

            db.PHONEs.Add(pHONE);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pHONE.ID }, pHONE);
        }

        // DELETE: api/PHONEs/5
        [ResponseType(typeof(PHONE))]
        public IHttpActionResult DeletePHONE(int id)
        {
            PHONE pHONE = db.PHONEs.Find(id);
            if (pHONE == null)
            {
                return NotFound();
            }

            db.PHONEs.Remove(pHONE);
            db.SaveChanges();

            return Ok(pHONE);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PHONEExists(int id)
        {
            return db.PHONEs.Count(e => e.ID == id) > 0;
        }
    }
}