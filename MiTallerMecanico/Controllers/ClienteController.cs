using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiTallerMecanico.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult CrearCliente()
        {
            return View();
        }
        public ActionResult ConsultarCliente()
        {
            return View();
        }
        public ActionResult ModificarCliente()
        {
            return View();
        }
    }
}