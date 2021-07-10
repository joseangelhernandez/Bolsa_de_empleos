using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Capa_Presentacion.Models;

namespace Capa_Presentacion.Controllers
{
    public class LoginController : Controller
    {
        BolsaEmpleosEntities bd = new BolsaEmpleosEntities();

        public static IEnumerable<SelectListItem> Rol_Categoria()
        {
            IList<SelectListItem> items = new List<SelectListItem>
            {
                new SelectListItem(){Text="Empresa", Value="2"},
                new SelectListItem(){Text="Usuario Solicitante", Value="3"},
            };
            return items;
        }
        public ActionResult AccesoDenegado()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(usuario users)
        {

            if (ModelState.IsValid)
            {
               var user = bd.usuario.Where(a => a.email == users.email && a.password == users.password).FirstOrDefault();

                if (user != null)
                {
                    var Ticket = new FormsAuthenticationTicket(users.email, false, 3000);
                    string Encrypt = FormsAuthentication.Encrypt(Ticket);
                    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, Encrypt);

                    cookie.Expires = DateTime.Now.AddHours(3000);
                    cookie.HttpOnly = true;
                    Response.Cookies.Add(cookie);


                    if (user.id_rol == 1)
                    {
                        return RedirectToAction("Index", "ModulosAdmin");
                    }
                    else if (user.id_rol == 2)
                    {
                        return RedirectToAction("Index", "ModulosPoster");
                    }
                    else if(user.id_rol == 3)
                    {
                        return RedirectToAction("Index", "ModulosSolicitante");
                    }

                }
                else
                {
                    TempData["msg"] = "Login Incorrecto";
                    return RedirectToAction("Index", "Login");
                }
            }


            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(usuario _user)
        {
            bd.usuario.Add(_user);
            bd.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");

        }
    }
}



