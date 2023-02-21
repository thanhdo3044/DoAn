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

namespace backend.Controllers
{
    public class BogsController : ApiController
    {
        private QLBANHANGEntities db = new QLBANHANGEntities();

        // GET: api/Bogs
        public IQueryable<Bog> GetBogs()
        {
            return db.Bogs;
        }

        // GET: api/Bogs/5
        [ResponseType(typeof(Bog))]
        public async Task<IHttpActionResult> GetBog(string id)
        {
            Bog bog = await db.Bogs.FindAsync(id);
            if (bog == null)
            {
                return NotFound();
            }

            return Ok(bog);
        }

        // PUT: api/Bogs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBog(string id, Bog bog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bog.MaNoiDung)
            {
                return BadRequest();
            }

            db.Entry(bog).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BogExists(id))
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

        // POST: api/Bogs
        [ResponseType(typeof(Bog))]
        public async Task<IHttpActionResult> PostBog(Bog bog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bogs.Add(bog);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BogExists(bog.MaNoiDung))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = bog.MaNoiDung }, bog);
        }

        // DELETE: api/Bogs/5
        [ResponseType(typeof(Bog))]
        public async Task<IHttpActionResult> DeleteBog(string id)
        {
            Bog bog = await db.Bogs.FindAsync(id);
            if (bog == null)
            {
                return NotFound();
            }

            db.Bogs.Remove(bog);
            await db.SaveChangesAsync();

            return Ok(bog);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BogExists(string id)
        {
            return db.Bogs.Count(e => e.MaNoiDung == id) > 0;
        }
    }
}