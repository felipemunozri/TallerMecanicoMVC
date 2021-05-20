using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Taller_Mecanico_MVC.Controllers
{
    public class VehiculoController : Controller
    {
        // GET: Vehiculo
        public ActionResult CrearVehiculo()
        {
            return View();
        }
        public ActionResult ConsultarVehiculo()
        {
            return View();
        }
        public ActionResult ModificarVehiculo()
        {
            return View();
        }
    }
}