using MiTallerMecanico.UTIL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTIL.Models;

namespace MiTallerMecanico.Controllers
{
    public class ConsultaClienteController : BaseController
    {
        // GET: ConsultaCliente
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult ConsultaCliente()
        {

            return View();
        }


        public JsonResult EstadoVehiculo(string patente)
        {
            
            EstadoModel est = controlTaller().obtenerEstado(patente);

            if (est == null)
            {
                
                return Json(new { Validador = false }, JsonRequestBehavior.AllowGet);
            }
            else {
                
                return Json(new { estado = est.estado, Validador = true }, JsonRequestBehavior.AllowGet);
            }


        }
    }
}