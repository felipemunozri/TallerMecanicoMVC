using MiTallerMecanico.UTIL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTIL.Models;


namespace MiTallerMecanico.Controllers
{
    public class VehiculoController : BaseController
    {
        // GET: Vehiculo
        public ActionResult CrearVehiculo()
        {
            #region dropdownlist
            List<TipoVehiculoModel> tipoVehiculos = controlTaller().ObtenerTiposVehiculos();
            ViewBag.TipoVehiculos = tipoVehiculos;
            #endregion

            return View();
        }
        public ActionResult ConsultarVehiculo()
        {
            List<VehiculoModel> vehiculos = controlTaller().ObtenerVehiculos();
            ViewBag.Vehiculos = vehiculos;

            return View();
        }
        public ActionResult ModificarVehiculo()
        {
            #region dropdownlist
            List<TipoVehiculoModel> tipoVehiculos = controlTaller().ObtenerTiposVehiculos();
            ViewBag.TipoVehiculos = tipoVehiculos;
            #endregion

            return View();
        }
    }
}