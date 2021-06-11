using MiTallerMecanico.UTIL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTIL.Models;

namespace MiTallerMecanico.Controllers
{
    public class RepuestoController : BaseController
    {
        // GET: Repuesto
        public ActionResult CrearRepuesto()
        {
            return View();
        }
        public ActionResult ConsultarRepuesto()
        {
            List<RepuestoModel> repuestos = controlTaller().ObtenerRepuestos();
            ViewBag.Repuestos = repuestos;

            return View();
        }
        public ActionResult ModificarRepuesto()
        {
            return View();
        }
    }
}