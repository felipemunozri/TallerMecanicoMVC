using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiTallerMecanico.Controllers
{
    public class PresupuestoController : Controller
    {
        // GET: Presupuesto
        public ActionResult CrearPresupuesto()
        {
            return View();
        }
        public ActionResult ConsultarPresupuesto()
        {
            return View();
        }
        public ActionResult ModificarPresupuesto()
        {
            return View();
        }
    }
}