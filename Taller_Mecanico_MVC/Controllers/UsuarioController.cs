using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Taller_Mecanico_MVC.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult CrearUsuario()
        {
            return View();
        }
        public ActionResult ConsultarUsuario()
        {
            return View();
        }
        public ActionResult ModificarUsuario()
        {
            return View();
        }
    }
}