using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Taller_Mecanico_MVC.Controllers
{
    public class OrdenTrabajoController : Controller
    {
        // GET: OrdenTrabajo
        public ActionResult CrearOrden()
        {
            return View();
        }
        public ActionResult ConsultarOrden()
        {
            return View();
        }
        public ActionResult ModificarOrden()
        {
            return View();
        }
        public ActionResult AnularOrden()
        {
            return View();
        }
    }
}