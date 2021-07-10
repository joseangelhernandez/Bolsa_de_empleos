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
    [AccessDeniedAuthorizeAttribute(Roles = "poster")]
    public class ModulosPosterController : Controller
    {
        BolsaEmpleosEntities bd = new BolsaEmpleosEntities();
        public string Email { get; set; }

        public static IEnumerable<SelectListItem> HORARIOS()
        {
            IList<SelectListItem> items = new List<SelectListItem>
            {
                new SelectListItem(){Text="Tiempo Completo", Value="Tiempo Completo"},
                new SelectListItem(){Text="Medio Tiempo", Value="Tiempo Completo"},
                new SelectListItem(){Text="Flexible", Value="Flexible"}
            };
            return items;
        }

        public ActionResult Index()
        {
            var getcategorias = bd.categoria.ToList();
            SelectList lista = new SelectList(getcategorias, "nombre", "nombre");
            ViewBag.categorias = lista;

            Email = User.Identity.Name;

            var Nombre_empresa = bd.usuario.Where(a => a.email == Email).FirstOrDefault().nombre;

            ViewData["nombre"] = Nombre_empresa;

            return View(bd.puesto.Where(x=>x.compania == Nombre_empresa).ToList());
        }

        public ActionResult CrearPuesto()
        {
            var getcategorias = bd.categoria.ToList();
            SelectList lista = new SelectList(getcategorias, "nombre", "nombre");
            ViewBag.categorias = lista;

            Email = User.Identity.Name;

            ViewData["nombre"] = bd.usuario.Where(a => a.email == Email).FirstOrDefault().nombre;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearPuesto(puesto puesto)
        {
            var getcategorias = bd.categoria.ToList();
            SelectList lista = new SelectList(getcategorias, "nombre", "nombre");
            ViewBag.categorias = lista;

            Email = User.Identity.Name;

            ViewData["nombre"] = bd.usuario.Where(a => a.email == Email).FirstOrDefault().nombre;


            puesto.compania = bd.usuario.Where(a => a.email == Email).FirstOrDefault().nombre;

            bd.puesto.Add(puesto);
            bd.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult EditPuesto(int id)
        {
            var getcategorias = bd.categoria.ToList();
            SelectList lista = new SelectList(getcategorias, "nombre", "nombre");
            ViewBag.categorias = lista;

            var puesto = bd.puesto.Where(a => a.puesto_id == id).FirstOrDefault();

            return PartialView("EditPuesto", puesto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPuesto(puesto puesto)
        {
            var getcategorias = bd.categoria.ToList();
            SelectList lista = new SelectList(getcategorias, "nombre", "nombre");
            ViewBag.categorias = lista;

            var busqueda = bd.puesto.Find(puesto.puesto_id);
            busqueda.nombre = puesto.nombre;
            busqueda.email = puesto.email;
            busqueda.Categoria = puesto.Categoria;
            busqueda.ubicacion = puesto.ubicacion;
            busqueda.Salario = puesto.Salario;
            busqueda.como_aplicar = puesto.como_aplicar;
            busqueda.descripcion = puesto.descripcion;

            bd.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult delete(int puesto_id)
        {
            
            var busqueda = bd.puesto.Find(puesto_id);
            bd.puesto.Remove(busqueda);
            bd.SaveChanges();

            return RedirectToAction("Index");

        }

        public ActionResult Solicitudes()
        {
            Email = User.Identity.Name;

            var Nombre_empresa = bd.usuario.Where(a => a.email == Email).FirstOrDefault().nombre;

            ViewData["nombre"] = Nombre_empresa;

            return View(bd.Solicitudes.Where(x => x.empresa == Nombre_empresa).ToList());
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