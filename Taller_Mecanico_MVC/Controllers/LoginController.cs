using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UTIL.Objetos;
using UTIL.Validaciones;
using System.Web.Mvc;

namespace Taller_Mecanico_MVC.Controllers
{
    public class LoginController : BaseController
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login() {
            
            
            return View();
        }
        public ActionResult LogOut()
        {
            

            return RedirectToAction("Login", "Login");
        }

        [HttpPost]

        public JsonResult Login(string nombre, string password) {

            var validador = 0;
            var datosUsuarios = new ObjetoUsuario();
            datosUsuarios.nombreUsuario = nombre;
            datosUsuarios.passUsuario = password;

            datosUsuarios.passUsuario = HashMd5.GetMD5(datosUsuarios.passUsuario);

            var resultado = control().Login(datosUsuarios);

            var result = contro
            if () { 
            
            
            
            }

            return Json(new { Validador = validador });
        }
    }
}