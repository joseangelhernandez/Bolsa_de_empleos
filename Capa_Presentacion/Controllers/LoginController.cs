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
        public ActionResult Index(USUARIOS users)
        {

            if (ModelState.IsValid)
            {
               var user = bd.USUARIOS.Where(a => a.email == users.email && a.password == users.password).FirstOrDefault();

                if (user != null)
                {
                    var Ticket = new FormsAuthenticationTicket(users.email, false, 3000);
                    string Encrypt = FormsAuthentication.Encrypt(Ticket);
                    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, Encrypt);

                    cookie.Expires = DateTime.Now.AddHours(3000);
                    cookie.HttpOnly = true;
                    Response.Cookies.Add(cookie);


                    if (user.rol_id == 1)
                    {
                        return RedirectToAction("Index", "ModulosAdmin");
                    }
                    else if (user.rol_id == 2)
                    {
                        return RedirectToAction("Index", "ModulosPoster");
                    }
                    else if(user.rol_id == 3)
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
    }
}