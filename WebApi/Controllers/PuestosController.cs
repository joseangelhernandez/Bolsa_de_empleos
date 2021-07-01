using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using WebApi.Models;

namespace WebApi.Controllers
{
    [EnableCors(origins: "http://127.0.0.1:5501", headers: "*", methods: "*")]
    public class PuestosController : ApiController
    {
        private BolsaEmpleosEntities3 db = new BolsaEmpleosEntities3();

        // GET: api/Puestos
        public async Task<IEnumerable<Models.Request.PuestoRequest>> Getpuestoes()
        {
            List<Models.Request.PuestoRequest> lis = new List<Models.Request.PuestoRequest>();

            lis = await (from d in db.puestoes
                   where d.estado == true
                  select new Models.Request.PuestoRequest
                  {
                    Id = d.puesto_id, 
                    Descripcion = d.descripcion,
                    Nombre = d.nombre,
                    Email = d.email,
                    como_aplicar = d.como_aplicar,
                    Ubicacion = d.ubicacion,
                    Compania = d.compania,
                    Logo = d.logo,
                    Tipo = d.tipo,
                    Url = d.C_url
                  }).ToListAsync();
            return lis;
        }

        // GET: api/Puestos/5
        [ResponseType(typeof(puesto))]
        public async Task<IHttpActionResult> Getpuesto(int id)
        {
            puesto puesto = await db.puestoes.FindAsync(id);
            if (puesto == null)
            {
                return NotFound();
            }

            return Ok(puesto);
        }

        // PUT: api/Puestos/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putpuesto(int id, puesto puesto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != puesto.puesto_id)
            {
                return BadRequest();
            }

            db.Entry(puesto).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!puestoExists(id))
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

        // POST: api/Puestos
        [ResponseType(typeof(puesto))]
        public async Task<IHttpActionResult> Postpuesto(puesto puesto)
        {
            //HttpPostedFileBase http = Request.Files[0];

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.puestoes.Add(puesto);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = puesto.puesto_id }, puesto);
        }

        // DELETE: api/Puestos/5
        [ResponseType(typeof(puesto))]
        public async Task<IHttpActionResult> Deletepuesto(int id)
        {
            puesto puesto = await db.puestoes.FindAsync(id);

            if (puesto == null)
            {
                return NotFound();
            }

            db.puestoes.Remove(puesto);
            await db.SaveChangesAsync();

            return Ok(puesto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool puestoExists(int id)
        {
            return db.puestoes.Count(e => e.puesto_id == id) > 0;
        }
    }
}