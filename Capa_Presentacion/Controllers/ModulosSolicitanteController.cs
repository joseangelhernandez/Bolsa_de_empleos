using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Capa_Presentacion.Models;

namespace Capa_Presentacion.Controllers
{
    [AccessDeniedAuthorizeAttribute(Roles = "solicitante")]
    public class ModulosSolicitanteController : Controller
    {
        BolsaEmpleosEntities bd = new BolsaEmpleosEntities();
        public string Email { get; set; }
        public int Puesto_id;
        public string Descripcion;
        public string Empresa;
        public double? Salario;
        public string Posicion;
        public string email;
        // GET: ModulosSolicitante
        public ActionResult Index()
        {
            Email = User.Identity.Name;

            var Nombre = bd.usuario.Where(a => a.email == Email).FirstOrDefault().nombre;

            ViewData["nombre"] = Nombre;

            return View(bd.puesto.ToList());
        }

        public ActionResult MostrarInfo(int puesto_id)
        {
            Email = User.Identity.Name;

            var Nombre = bd.usuario.Where(a => a.email == Email).FirstOrDefault().nombre;

            ViewData["nombre"] = Nombre;

            Puesto_id = puesto_id;

            TempData["puestoID"] = Puesto_id;

            Descripcion = bd.puesto.Where(a => a.puesto_id == Puesto_id).FirstOrDefault().descripcion;

            Empresa = bd.puesto.Where(a => a.puesto_id == Puesto_id).FirstOrDefault().compania;

            Salario = bd.puesto.Where(a => a.puesto_id == Puesto_id).FirstOrDefault().Salario;

            Posicion = bd.puesto.Where(a => a.puesto_id == Puesto_id).FirstOrDefault().nombre;

            email = bd.puesto.Where(a => a.puesto_id == Puesto_id).FirstOrDefault().email;

            TempData["Descripcion"] = Descripcion;
            TempData["Empresa"] = Empresa;
            TempData["Salario"] = "RD" + $"{Salario:C}";
            TempData["Posicion"] = Posicion;
            TempData["Email"] = email;


            return View();
        }

        public ActionResult Solicitar()
        {
            Email = User.Identity.Name;

            var Nombre = bd.usuario.Where(a => a.email == Email).FirstOrDefault().nombre;

            ViewData["nombre"] = Nombre;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Solicitar(Solicitudes solicitudes)
        {
            Email = User.Identity.Name;

            var Solicitante_id = bd.usuario.Where(a => a.email == Email).FirstOrDefault().id;

            var Nombre = bd.usuario.Where(a => a.email == Email).FirstOrDefault().nombre;

            ViewData["nombre"] = Nombre;

            solicitudes.solicitante = Solicitante_id;
            solicitudes.posicion = TempData["Posicion"].ToString();
            solicitudes.empresa = TempData["Empresa"].ToString();
            solicitudes.id_puesto = Convert.ToInt32(TempData["puestoID"]);
            solicitudes.nombre = Nombre;

            //Cargar imagen
            string fileName = User.Identity.Name;
            string Extension = ".pdf";
            fileName = fileName + Extension;
            solicitudes.CV = "~/CVs/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/CVs/"), fileName);
            System.Diagnostics.Debug.WriteLine(fileName);

            //Confirmar si existe
            if (System.IO.File.Exists(fileName))
            {
                System.IO.File.Delete(fileName);
            }

            //Guardar Imagen
            solicitudes.PDF.SaveAs(fileName);

            bd.Solicitudes.Add(solicitudes);
            bd.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Solicitudes()
        {
            Email = User.Identity.Name;

            var Nombre = bd.usuario.Where(a => a.email == Email).FirstOrDefault().nombre;

            var ID = bd.usuario.Where(a => a.email == Email).FirstOrDefault().id;

            ViewData["nombre"] = Nombre;

            return View(bd.Solicitudes.Where(x => x.solicitante == ID).ToList());
        }

        [HttpPost]
        public ActionResult delete_solicitud(int solicitud_id)
        {

            var busqueda = bd.Solicitudes.Find(solicitud_id);
            bd.Solicitudes.Remove(busqueda);
            bd.SaveChanges();

            return RedirectToAction("Index");

        }

        public FileResult Download(string PDF)
        {
            var FilePath = PDF;
            return File(FilePath, "application/force- download", Path.GetFileName(FilePath));
        }


    }
}