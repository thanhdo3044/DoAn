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
    public class HDBanHangsController : ApiController
    {
        private QLBANHANGEntities db = new QLBANHANGEntities();

        // GET: api/HDBanHangs
        public IQueryable<HDBanHang> GetHDBanHangs()
        {
            return db.HDBanHangs;
        }

        // GET: api/HDBanHangs/5
        [ResponseType(typeof(HDBanHang))]
        public async Task<IHttpActionResult> GetHDBanHang(string id)
        {
            HDBanHang hDBanHang = await db.HDBanHangs.FindAsync(id);
            if (hDBanHang == null)
            {
                return NotFound();
            }

            return Ok(hDBanHang);
        }

        // PUT: api/HDBanHangs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutHDBanHang(string id, HDBanHang hDBanHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hDBanHang.MaHDBan)
            {
                return BadRequest();
            }

            db.Entry(hDBanHang).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HDBanHangExists(id))
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

        // POST: api/HDBanHangs
        [ResponseType(typeof(HDBanHang))]
        public async Task<IHttpActionResult> PostHDBanHang(HDBanHang hDBanHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HDBanHangs.Add(hDBanHang);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HDBanHangExists(hDBanHang.MaHDBan))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = hDBanHang.MaHDBan }, hDBanHang);
        }

        // DELETE: api/HDBanHangs/5
        [ResponseType(typeof(HDBanHang))]
        public async Task<IHttpActionResult> DeleteHDBanHang(string id)
        {
            HDBanHang hDBanHang = await db.HDBanHangs.FindAsync(id);
            if (hDBanHang == null)
            {
                return NotFound();
            }

            db.HDBanHangs.Remove(hDBanHang);
            await db.SaveChangesAsync();

            return Ok(hDBanHang);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HDBanHangExists(string id)
        {
            return db.HDBanHangs.Count(e => e.MaHDBan == id) > 0;
        }
    }
}