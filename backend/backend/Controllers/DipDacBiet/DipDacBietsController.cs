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
    public class DipDacBietsController : ApiController
    {
        private QLBANHANGEntities db = new QLBANHANGEntities();

        // GET: api/DipDacBiets
        public IQueryable<DipDacBiet> GetDipDacBiets()
        {
            return db.DipDacBiets;
        }

        // GET: api/DipDacBiets/5
        [ResponseType(typeof(DipDacBiet))]
        public async Task<IHttpActionResult> GetDipDacBiet(string id)
        {
            DipDacBiet dipDacBiet = await db.DipDacBiets.FindAsync(id);
            if (dipDacBiet == null)
            {
                return NotFound();
            }

            return Ok(dipDacBiet);
        }

        // PUT: api/DipDacBiets/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDipDacBiet(string id, DipDacBiet dipDacBiet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dipDacBiet.MaNgay)
            {
                return BadRequest();
            }

            db.Entry(dipDacBiet).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DipDacBietExists(id))
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

        // POST: api/DipDacBiets
        [ResponseType(typeof(DipDacBiet))]
        public async Task<IHttpActionResult> PostDipDacBiet(DipDacBiet dipDacBiet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DipDacBiets.Add(dipDacBiet);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DipDacBietExists(dipDacBiet.MaNgay))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = dipDacBiet.MaNgay }, dipDacBiet);
        }

        // DELETE: api/DipDacBiets/5
        [ResponseType(typeof(DipDacBiet))]
        public async Task<IHttpActionResult> DeleteDipDacBiet(string id)
        {
            DipDacBiet dipDacBiet = await db.DipDacBiets.FindAsync(id);
            if (dipDacBiet == null)
            {
                return NotFound();
            }

            db.DipDacBiets.Remove(dipDacBiet);
            await db.SaveChangesAsync();

            return Ok(dipDacBiet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DipDacBietExists(string id)
        {
            return db.DipDacBiets.Count(e => e.MaNgay == id) > 0;
        }
    }
}