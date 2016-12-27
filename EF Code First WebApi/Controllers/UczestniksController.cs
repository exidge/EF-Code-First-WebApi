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
using EF_Code_First_WebApi.DAL;
using EF_Code_First_WebApi.Models;

namespace EF_Code_First_WebApi.Controllers
{
    public class UczestniksController : ApiController
    {
        private static string ConnString = @"Data Source = localhost\SQLEXPRESS; Integrated Security = true;";
        private UczestnicyKonferencji db = new UczestnicyKonferencji(ConnString);

        // GET: api/Uczestniks
        public IQueryable<Uczestnik> GetUczestnicy()
        {
            return db.Uczestnicy;
        }

        // GET: api/Uczestniks/5
        [ResponseType(typeof(Uczestnik))]
        public IHttpActionResult GetUczestnik(int id)
        {
            Uczestnik uczestnik = db.Uczestnicy.Find(id);
            if (uczestnik == null)
            {
                return NotFound();
            }

            return Ok(uczestnik);
        }

        // PUT: api/Uczestniks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUczestnik(int id, Uczestnik uczestnik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != uczestnik.ID)
            {
                return BadRequest();
            }

            db.Entry(uczestnik).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UczestnikExists(id))
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

        // POST: api/Uczestniks
        [ResponseType(typeof(Uczestnik))]
        public IHttpActionResult PostUczestnik(Uczestnik uczestnik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Uczestnicy.Add(uczestnik);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = uczestnik.ID }, uczestnik);
        }

        // DELETE: api/Uczestniks/5
        [ResponseType(typeof(Uczestnik))]
        public IHttpActionResult DeleteUczestnik(int id)
        {
            Uczestnik uczestnik = db.Uczestnicy.Find(id);
            if (uczestnik == null)
            {
                return NotFound();
            }

            db.Uczestnicy.Remove(uczestnik);
            db.SaveChanges();

            return Ok(uczestnik);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UczestnikExists(int id)
        {
            return db.Uczestnicy.Count(e => e.ID == id) > 0;
        }
    }
}