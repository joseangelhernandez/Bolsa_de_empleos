using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class RegisterController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Post([FromBody] Models.Request.RegisterRequest model)
        {
            Models.usuario User = null;

            using (Models.BolsaEmpleosEntities3 db = new Models.BolsaEmpleosEntities3())
            {
                User = db.usuarios.Where(u => u.email == model.Email && u.password == model.password).FirstOrDefault();
            }

            if (User == null)
                return StatusCode(HttpStatusCode.NotFound);

            return Ok(User);
        }
    }
}
