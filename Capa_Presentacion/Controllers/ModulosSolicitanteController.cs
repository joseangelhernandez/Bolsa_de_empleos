using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capa_Presentacion.Controllers
{
    [AccessDeniedAuthorizeAttribute(Roles = "solicitante")]
    public class ModulosSolicitanteController : Controller
    {
        // GET: ModulosSolicitante
        public ActionResult Index()
        {
            return View();
        }
    }
}