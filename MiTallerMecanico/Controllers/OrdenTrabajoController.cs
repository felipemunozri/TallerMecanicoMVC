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
            return View();
        }
    }
}