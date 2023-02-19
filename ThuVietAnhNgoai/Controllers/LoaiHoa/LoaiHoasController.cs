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

namespace backend.Controllers.LoaiHoa
{
    public class LoaiHoasController : ApiController
    {
        private QLBANHANGEntities db = new QLBANHANGEntities();

        // GET: api/LoaiHoas
        public IQueryable<LoaiHoa> GetLoaiHoas()
        {
            return db.LoaiHoas;
        }

        // GET: api/LoaiHoas/5
        [ResponseType(typeof(LoaiHoa))]
        public async Task<IHttpActionResult> GetLoaiHoa(string id)
        {
            LoaiHoa loaiHoa = await db.LoaiHoas.FindAsync(id);
            if (loaiHoa == null)
            {
                return NotFound();
            }

            return Ok(loaiHoa);
        }

        // PUT: api/LoaiHoas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLoaiHoa(string id, LoaiHoa loaiHoa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != loaiHoa.MaHoa)
            {
                return BadRequest();
            }

            db.Entry(loaiHoa).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoaiHoaExists(id))
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

        // POST: api/LoaiHoas
        [ResponseType(typeof(LoaiHoa))]
        public async Task<IHttpActionResult> PostLoaiHoa(LoaiHoa loaiHoa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LoaiHoas.Add(loaiHoa);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LoaiHoaExists(loaiHoa.MaHoa))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = loaiHoa.MaHoa }, loaiHoa);
        }

        // DELETE: api/LoaiHoas/5
        [ResponseType(typeof(LoaiHoa))]
        public async Task<IHttpActionResult> DeleteLoaiHoa(string id)
        {
            LoaiHoa loaiHoa = await db.LoaiHoas.FindAsync(id);
            if (loaiHoa == null)
            {
                return NotFound();
            }

            db.LoaiHoas.Remove(loaiHoa);
            await db.SaveChangesAsync();

            return Ok(loaiHoa);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LoaiHoaExists(string id)
        {
            return db.LoaiHoas.Count(e => e.MaHoa == id) > 0;
        }
    }
}