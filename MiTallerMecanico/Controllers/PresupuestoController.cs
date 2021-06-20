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
            List<PresupuestoModel> presu = controlTaller().obtenerPresupuestos();
            ViewBag.presu = presu;

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

        [HttpPost]
        public ActionResult AgregarPresupuesto(EncabezadoPresupuestoModel presupuesto, List<DetallePresupuestoModel> detalle) {

            RespuestaModel id_encabezado = controlTaller().AgregarEncabezado(presupuesto);

            for (int i=0;i<detalle.Count;i++) {

              RespuestaModel Detalle= controlTaller().AgregarDetalle(detalle[i],Convert.ToInt32(id_encabezado.id_encabezado));
            
            }
            if (id_encabezado == null && detalle==null)
            {

                return Json(new { Validador = false }, JsonRequestBehavior.AllowGet);
            }
            else {
                return Json(new { Validador = true }, JsonRequestBehavior.AllowGet);
            }

            
        }


        [HttpPost]
        public JsonResult DetallePresupuesto(int _IdPresu) {

            List<EncabezadoDetalle> enca = controlTaller().obtenerEncabezadoDetalle(_IdPresu);

            List<DetallePresuModel> deta = controlTaller().obtenerDetalle(_IdPresu);




            return Json(new { Cabecera =enca, Detalle =deta }, JsonRequestBehavior.AllowGet);
        }




        [HttpPost]
        public JsonResult EditarPresupuesto(int _IdPresu)
        {

            List<EncabezadoDetalle> enca = controlTaller().obtenerEncabezadoDetalle(_IdPresu);

            List<DetallePresuModel> deta = controlTaller().obtenerDetalle(_IdPresu);




            return Json(new { Cabecera = enca, Detalle = deta }, JsonRequestBehavior.AllowGet);
        }

    }



}
