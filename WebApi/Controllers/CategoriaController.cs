using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using WebApi.Models;
using WebApi.Models.Request;

namespace WebApi.Controllers
{
    [EnableCors(origins: "http://127.0.0.1:5501", headers: "*", methods: "*")]
    public class CategoriaController : ApiController
    {
        private readonly BolsaEmpleosEntities1 db = new BolsaEmpleosEntities1();

        // Método asíncrono que devuelve la lista de Categorías

        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            List<CategoriaRequest> lis = new List<CategoriaRequest>();

            try
            {

                lis = await (from d in db.categoria
                             select new CategoriaRequest
                             {
                                 categoria_id = d.categoria_id,
                                 nombre = d.nombre
                             }).ToListAsync();

                // Si no hay categorías, devolverá un 204
                if (lis == null)
                        return StatusCode(HttpStatusCode.NoContent);
                
            } catch (Exception e)
            {
                // Devuelve un código de respuesta 500, al generar la lista de categorías
                return StatusCode(HttpStatusCode.InternalServerError);
            }

            // retorna una 200 con la lista de categorias
            return Ok(lis);
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get([FromUri]int id)
        {
            categoria c = await db.categoria.Where(e => e.categoria_id == id).FirstOrDefaultAsync();

            if (c == null)
                return NotFound();

            return Ok(c);
        }

        // Método asíncrono que agrega una categoría
        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] CategoriaRequest model)
        {
            var catego = new categoria();

            using (BolsaEmpleosEntities1 db = new BolsaEmpleosEntities1())
            {
                try
                {
                    catego.nombre = model.nombre;
                    db.categoria.Add(catego);
                    await db.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    // Devuelve un código de respuesta 500, si ocurre algún error al guardar la categoría
                    return StatusCode(HttpStatusCode.InternalServerError);
                }
            }
            return Ok(catego);
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteCategoria(int id)
        {
            categoria categ = new categoria();

            using (BolsaEmpleosEntities1 db = new BolsaEmpleosEntities1())
            {
                try
                {
                    categ = await db.categoria.FindAsync(id);

                    if (categ == null)
                    {
                        return NotFound();
                    }

                    db.categoria.Remove(categ);
                    await db.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    // Devuelve un código de respuesta 500, si ocurre algún error al guardar la categoría
                    return StatusCode(HttpStatusCode.InternalServerError);
                }
            }

            return Ok(categ);
        }

        // PUT: api/Categoria/4
        [HttpPut]
        public async Task<IHttpActionResult> UpdateCategoria(int id, categoria model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.categoria_id)
            {
                return BadRequest();
            }

            db.Entry(model).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaExists(id))
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

        private bool CategoriaExists(int id)
        {
            return db.categoria.Count(e => e.categoria_id == id) > 0;
        }
    }
}
