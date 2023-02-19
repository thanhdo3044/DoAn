using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using backend.Models;

namespace backend.Controllers.Hang
{
    public class HangsController : ApiController
    {
        private QLBANHANGEntities db = new QLBANHANGEntities();

        // GET: api/Hangs
        public IQueryable<Hang> GetHangs()
        {
            return db.Hangs;
        }

        // GET: api/Hangs/5
        [ResponseType(typeof(Hang))]
        public async Task<IHttpActionResult> GetHang(string id)
        {
            Hang hang = await db.Hangs.FindAsync(id);
            if (hang == null)
            {
                return NotFound();
            }

            return Ok(hang);
        }

        // PUT: api/Hangs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutHang(string id, Hang hang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hang.MaHang)
            {
                return BadRequest();
            }

            db.Entry(hang).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HangExists(id))
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

        // POST: api/Hangs
        [ResponseType(typeof(Hang))]
        public async Task<IHttpActionResult> PostHang(Hang hang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Hangs.Add(hang);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HangExists(hang.MaHang))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = hang.MaHang }, hang);
        }

        // DELETE: api/Hangs/5
        [ResponseType(typeof(Hang))]
        public async Task<IHttpActionResult> DeleteHang(string id)
        {
            Hang hang = await db.Hangs.FindAsync(id);
            if (hang == null)
            {
                return NotFound();
            }

            db.Hangs.Remove(hang);
            await db.SaveChangesAsync();

            return Ok(hang);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HangExists(string id)
        {
            return db.Hangs.Count(e => e.MaHang == id) > 0;
        }
    }
}