using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.IO;
using Capa_Presentacion.Models;

namespace Capa_Presentacion.Controllers
{
    [AccessDeniedAuthorizeAttribute(Roles = "admin")]
    public class ModulosAdminController : Controller
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

            var Nombre= bd.usuario.Where(a => a.email == Email).FirstOrDefault().nombre;

            ViewData["nombre"] = Nombre;

            return View(bd.puesto.ToList());
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

            return View(bd.Solicitudes.ToList());
        }

        [HttpPost]
        public ActionResult delete_solicitud(int solicitud_id)
        {
            var busqueda = bd.Solicitudes.Find(solicitud_id);
            bd.Solicitudes.Remove(busqueda);
            bd.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult MostrarCategorias()
        {
            Email = User.Identity.Name;

            var Nombre_empresa = bd.usuario.Where(a => a.email == Email).FirstOrDefault().nombre;

            ViewData["nombre"] = Nombre_empresa;

            return View(bd.categoria.ToList());
        }

        public ActionResult Categorias()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Categorias(categoria _categoria)
        {
            Email = User.Identity.Name;

            var Nombre_empresa = bd.usuario.Where(a => a.email == Email).FirstOrDefault().nombre;

            ViewData["nombre"] = Nombre_empresa;

            bd.categoria.Add(_categoria);
            bd.SaveChanges();
            return RedirectToAction("MostrarCategorias");
        }

        [HttpPost]
        public ActionResult delete_categoria(int categoria_id)
        {
            var busqueda = bd.categoria.Find(categoria_id);
            bd.categoria.Remove(busqueda);
            bd.SaveChanges();

            return RedirectToAction("MostrarCategorias");
        }

        public ActionResult Usuarios()
        {
            Email = User.Identity.Name;

            var Nombre_empresa = bd.usuario.Where(a => a.email == Email).FirstOrDefault().nombre;

            ViewData["nombre"] = Nombre_empresa;

            return View(bd.usuario.ToList());
        }
        [HttpPost]
        public ActionResult delete_usuario(int usuario_id)
        {
            var busqueda = bd.usuario.Find(usuario_id);
            bd.usuario.Remove(busqueda);
            bd.SaveChanges();

            return RedirectToAction("Usuarios");
        }
    }
}