using MiTallerMecanico.UTIL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTIL.Models;

namespace MiTallerMecanico.Controllers
{
    public class ServicioController : BaseController
    {
        // GET: Servicio
        public ActionResult CrearServicio()
        {
            return View();
        }
        public ActionResult ConsultarServicio()
        {
            List<ServicioModel> servicios = controlTaller().ObtenerServicios();
            ViewBag.Servicios = servicios;

            return View();
        }
        public ActionResult ModificarServicio()
        {
            return View();
        }
    }
}