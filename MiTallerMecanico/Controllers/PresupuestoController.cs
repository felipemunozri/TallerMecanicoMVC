using MiTallerMecanico.UTIL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTIL.Models;

namespace MiTallerMecanico.Controllers
{
    public class PresupuestoController : BaseController
    {
        #region vistas
        // GET: Presupuesto
        public ActionResult CrearPresupuesto()
        {
            #region dropdownlist
            List<TipoVehiculoModel> tipoVehiculos = controlTaller().ObtenerTiposVehiculos();
            ViewBag.TipoVehiculos = tipoVehiculos;

            List<RepuestoModel> repuestos = controlTaller().ObtenerRepuestos();
            ViewBag.Respuestos = repuestos;

            List<ServicioModel> servicios = controlTaller().ObtenerServicios();
            ViewBag.Servicios = servicios;
            #endregion

            return View();
        }

        public ActionResult ConsultarPresupuesto()
        {
            return View();
        }

        public ActionResult ModificarPresupuesto()
        {
            #region dropdownlist
            List<TipoVehiculoModel> tipoVehiculos = controlTaller().ObtenerTiposVehiculos();
            ViewBag.TipoVehiculos = tipoVehiculos;

            List<RepuestoModel> repuestos = controlTaller().ObtenerRepuestos();
            ViewBag.Respuestos = repuestos;

            List<ServicioModel> servicios = controlTaller().ObtenerServicios();
            ViewBag.Servicios = servicios;
            #endregion

            return View();
        }
        #endregion

        [HttpPost]
        public ActionResult BuscarCliente(string rutcliente) {

            ClienteModel clientes = controlTaller().BuscarCliente(rutcliente);

            if (clientes == null)
            {
                return Json(new { cliente = clientes, Validador = false }, JsonRequestBehavior.AllowGet);
            }
            else {
                return Json(new { cliente = clientes, Validador = true }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]

        public ActionResult BuscarVehiculo(string patente) {

            VehiculoModel vehiculo = controlTaller().BuscarVehiculo(patente);

            if (vehiculo == null)
            {
                return Json(new { vehiculo = vehiculo, Validador = false }, JsonRequestBehavior.AllowGet);
            }
            else {

                return Json(new { vehiculo = vehiculo, Validador = true }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult obtenerServiciosRespuestos()
        {

            List<ServicioModel> servicios = controlTaller().ObtenerServicios();
            List<RepuestoModel> repuestos = controlTaller().ObtenerRepuestos();
         
           
                return Json(new { servicios = servicios , repuestos=repuestos}, JsonRequestBehavior.AllowGet);
            }
        }

    }
