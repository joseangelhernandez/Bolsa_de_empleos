using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.IO;

namespace Capa_Presentacion.Controllers
{
    [AccessDeniedAuthorizeAttribute(Roles = "admin")]
    public class ModulosAdminController : Controller
    {
        // GET: ModulosAdmin
        public ActionResult Index()
        {
            return View();
        }
    }
}