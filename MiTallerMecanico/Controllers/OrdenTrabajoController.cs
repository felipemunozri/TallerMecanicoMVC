using MiTallerMecanico.UTIL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTIL.Models;

namespace MiTallerMecanico.Controllers
{
    public class OrdenTrabajoController : BaseController
    {
        // GET: OrdenTrabajo
        public ActionResult CrearOrden()
        {
            #region dropdownlist
            List<UsuarioModel> usuarios = controlTaller().ObtenerUsuarios();
            ViewBag.Usuarios = usuarios;

            List<TipoVehiculoModel> tipoVehiculos = controlTaller().ObtenerTiposVehiculos();
            ViewBag.TipoVehiculos = tipoVehiculos;

            List<RepuestoModel> repuestos = controlTaller().ObtenerRepuestos();
            ViewBag.Respuestos = repuestos;

            List<ServicioModel> servicios = controlTaller().ObtenerServicios();
            ViewBag.Servicios = servicios;
            #endregion

            return View();
        }
        public ActionResult ConsultarOrden()
        {

            List<ListarOrdenesTrabajo> ordenes = controlTaller().listarOrdenes();
           
            ViewBag.orden = ordenes;
            return View();
        }
        public ActionResult ModificarOrden()
        {
            #region dropdownlist
            List<UsuarioModel> usuarios = controlTaller().ObtenerUsuarios();
            ViewBag.Usuarios = usuarios;

            List<TipoVehiculoModel> tipoVehiculos = controlTaller().ObtenerTiposVehiculos();
            ViewBag.TipoVehiculos = tipoVehiculos;

            List<RepuestoModel> repuestos = controlTaller().ObtenerRepuestos();
            ViewBag.Respuestos = repuestos;

            List<ServicioModel> servicios = controlTaller().ObtenerServicios();
            ViewBag.Servicios = servicios;
            #endregion

            return View();
        }
        public ActionResult AnularOrden()
        {
            List<ListarOrdenesTrabajo> ordenes = controlTaller().listarOrdenesAnuladas();
            ViewBag.ordenesAnuladas = ordenes;
            return View();
        }

        [HttpPost]
        public JsonResult AnularOrden(int id) {

            RespuestaModel anular = controlTaller().AnularOrden(id);


            return Json(new {  Verificador = true }, JsonRequestBehavior.AllowGet);
        }



        public JsonResult DetalleOrdenes(int idOrden)
        {

            List<ModalDetalleOrden> enca = controlTaller().ObtenerDetalleOrdenes(idOrden);

            List<ModalDetalleOrdenDetalle> deta = controlTaller().obtenerDetalleOrdenDetalle(idOrden);

            return Json(new { Cabecera = enca, Detalle = deta }, JsonRequestBehavior.AllowGet);
        }



    }
}