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
    public class NguoiDungsController : ApiController
    {
        private QLBANHANGEntities db = new QLBANHANGEntities();

        // GET: api/NguoiDungs
        public IQueryable<NguoiDung> GetNguoiDungs()
        {
            return db.NguoiDungs;
        }

        // GET: api/NguoiDungs/5
        [ResponseType(typeof(NguoiDung))]
        public async Task<IHttpActionResult> GetNguoiDung(string id)
        {
            NguoiDung nguoiDung = await db.NguoiDungs.FindAsync(id);
            if (nguoiDung == null)
            {
                return NotFound();
            }

            return Ok(nguoiDung);
        }

        // PUT: api/NguoiDungs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutNguoiDung(string id, NguoiDung nguoiDung)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nguoiDung.MaNguoiDung)
            {
                return BadRequest();
            }

            db.Entry(nguoiDung).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NguoiDungExists(id))
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

        // POST: api/NguoiDungs
        [ResponseType(typeof(NguoiDung))]
        public async Task<IHttpActionResult> PostNguoiDung(NguoiDung nguoiDung)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NguoiDungs.Add(nguoiDung);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NguoiDungExists(nguoiDung.MaNguoiDung))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = nguoiDung.MaNguoiDung }, nguoiDung);
        }

        // DELETE: api/NguoiDungs/5
        [ResponseType(typeof(NguoiDung))]
        public async Task<IHttpActionResult> DeleteNguoiDung(string id)
        {
            NguoiDung nguoiDung = await db.NguoiDungs.FindAsync(id);
            if (nguoiDung == null)
            {
                return NotFound();
            }

            db.NguoiDungs.Remove(nguoiDung);
            await db.SaveChangesAsync();

            return Ok(nguoiDung);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NguoiDungExists(string id)
        {
            return db.NguoiDungs.Count(e => e.MaNguoiDung == id) > 0;
        }
    }
}