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

namespace backend.Controllers.NguoiBan
{
    public class NguoiBansController : ApiController
    {
        private QLBANHANGEntities db = new QLBANHANGEntities();

        // GET: api/NguoiBans
        public IQueryable<NguoiBan> GetNguoiBans()
        {
            return db.NguoiBans;
        }

        // GET: api/NguoiBans/5
        [ResponseType(typeof(NguoiBan))]
        public async Task<IHttpActionResult> GetNguoiBan(long id)
        {
            NguoiBan nguoiBan = await db.NguoiBans.FindAsync(id);
            if (nguoiBan == null)
            {
                return NotFound();
            }

            return Ok(nguoiBan);
        }

        // PUT: api/NguoiBans/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutNguoiBan(long id, NguoiBan nguoiBan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nguoiBan.MaNguoiBan)
            {
                return BadRequest();
            }

            db.Entry(nguoiBan).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NguoiBanExists(id))
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

        // POST: api/NguoiBans
        [ResponseType(typeof(NguoiBan))]
        public async Task<IHttpActionResult> PostNguoiBan(NguoiBan nguoiBan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NguoiBans.Add(nguoiBan);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NguoiBanExists(nguoiBan.MaNguoiBan))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = nguoiBan.MaNguoiBan }, nguoiBan);
        }

        // DELETE: api/NguoiBans/5
        [ResponseType(typeof(NguoiBan))]
        public async Task<IHttpActionResult> DeleteNguoiBan(long id)
        {
            NguoiBan nguoiBan = await db.NguoiBans.FindAsync(id);
            if (nguoiBan == null)
            {
                return NotFound();
            }

            db.NguoiBans.Remove(nguoiBan);
            await db.SaveChangesAsync();

            return Ok(nguoiBan);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NguoiBanExists(long id)
        {
            return db.NguoiBans.Count(e => e.MaNguoiBan == id) > 0;
        }
    }
}