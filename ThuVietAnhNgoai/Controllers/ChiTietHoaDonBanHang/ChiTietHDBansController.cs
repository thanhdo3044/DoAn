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

namespace backend.Controllers.ChiTietHoaDonBanHang
{
    public class ChiTietHDBansController : ApiController
    {
        private QLBANHANGEntities db = new QLBANHANGEntities();

        // GET: api/ChiTietHDBans
        public IQueryable<ChiTietHDBan> GetChiTietHDBans()
        {
            return db.ChiTietHDBans;
        }

        // GET: api/ChiTietHDBans/5
        [ResponseType(typeof(ChiTietHDBan))]
        public async Task<IHttpActionResult> GetChiTietHDBan(string id)
        {
            ChiTietHDBan chiTietHDBan = await db.ChiTietHDBans.FindAsync(id);
            if (chiTietHDBan == null)
            {
                return NotFound();
            }

            return Ok(chiTietHDBan);
        }

        // PUT: api/ChiTietHDBans/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutChiTietHDBan(string id, ChiTietHDBan chiTietHDBan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != chiTietHDBan.MaHDban)
            {
                return BadRequest();
            }

            db.Entry(chiTietHDBan).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChiTietHDBanExists(id))
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

        // POST: api/ChiTietHDBans
        [ResponseType(typeof(ChiTietHDBan))]
        public async Task<IHttpActionResult> PostChiTietHDBan(ChiTietHDBan chiTietHDBan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ChiTietHDBans.Add(chiTietHDBan);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ChiTietHDBanExists(chiTietHDBan.MaHDban))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = chiTietHDBan.MaHDban }, chiTietHDBan);
        }

        // DELETE: api/ChiTietHDBans/5
        [ResponseType(typeof(ChiTietHDBan))]
        public async Task<IHttpActionResult> DeleteChiTietHDBan(string id)
        {
            ChiTietHDBan chiTietHDBan = await db.ChiTietHDBans.FindAsync(id);
            if (chiTietHDBan == null)
            {
                return NotFound();
            }

            db.ChiTietHDBans.Remove(chiTietHDBan);
            await db.SaveChangesAsync();

            return Ok(chiTietHDBan);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ChiTietHDBanExists(string id)
        {
            return db.ChiTietHDBans.Count(e => e.MaHDban == id) > 0;
        }
    }
}