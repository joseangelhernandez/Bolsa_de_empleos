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
using WebApi.Models;

namespace WebApi.Controllers
{
    public class SolicitudController : ApiController
    {
        private BolsaEmpleosEntities1 db = new BolsaEmpleosEntities1();

        // GET: api/Solicitud
        public IQueryable<Solicitudes> GetSolicitudes()
        {
            return db.Solicitudes;
        }

        // GET: api/Solicitud/5
        [ResponseType(typeof(Solicitudes))]
        public async Task<IHttpActionResult> GetSolicitudes(int id)
        {
            Solicitudes solicitudes = await db.Solicitudes.FindAsync(id);
            if (solicitudes == null)
            {
                return NotFound();
            }

            return Ok(solicitudes);
        }

        // PUT: api/Solicitud/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSolicitudes(int id, Solicitudes solicitudes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != solicitudes.id_solicitud)
            {
                return BadRequest();
            }

            db.Entry(solicitudes).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SolicitudesExists(id))
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

        // POST: api/Solicitud
        [ResponseType(typeof(Solicitudes))]
        public async Task<IHttpActionResult> PostSolicitudes(Solicitudes solicitudes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Solicitudes.Add(solicitudes);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = solicitudes.id_solicitud }, solicitudes);
        }

        // DELETE: api/Solicitud/5
        [ResponseType(typeof(Solicitudes))]
        public async Task<IHttpActionResult> DeleteSolicitudes(int id)
        {
            Solicitudes solicitudes = await db.Solicitudes.FindAsync(id);
            if (solicitudes == null)
            {
                return NotFound();
            }

            db.Solicitudes.Remove(solicitudes);
            await db.SaveChangesAsync();

            return Ok(solicitudes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SolicitudesExists(int id)
        {
            return db.Solicitudes.Count(e => e.id_solicitud == id) > 0;
        }
    }
}