using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capa_Presentacion.Controllers
{
    [AccessDeniedAuthorizeAttribute(Roles = "poster")]
    public class ModulosPosterController : Controller
    {
        // GET: ModulosPoster
        public ActionResult Index()
        {
            return View();
        }
    }
}