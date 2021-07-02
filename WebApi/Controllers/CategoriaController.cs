using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApi.Controllers
{
    [EnableCors(origins: "http://127.0.0.1:5501", headers: "*", methods: "*")]
    public class CategoriaController : ApiController
    {

        [HttpGet]
        public IHttpActionResult Get()
        {
            List<Models.Request.CategoriaRequest> lis = new List<Models.Request.CategoriaRequest>();

            using (Models.BolsaEmpleosEntities3 db = new Models.BolsaEmpleosEntities3())
            {
                lis = (from d in db.categorias select new Models.Request.CategoriaRequest
                {
                    nombre = d.nombre
                }).ToList();
            }

            return Ok(lis);
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody]Models.Request.CategoriaRequest model)
        {
            var catego = new Models.categoria();
            using (Models.BolsaEmpleosEntities3 db = new Models.BolsaEmpleosEntities3())
            {
                catego.nombre = model.nombre;
                db.categorias.Add(catego);
                db.SaveChanges();
            }
            return Ok(catego);
        }
    }
}
