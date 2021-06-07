﻿using MiTallerMecanico.UTIL;
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

            List<ServiciosModel> servicios = controlTaller().ObtenerServicios();
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
            return View();
        }
        #endregion

        [HttpPost]
        public ActionResult BuscarCliente(string rutcliente) {

            ClienteModel clientes = controlTaller().BuscarCliente(rutcliente);

            return Json(new { cliente=clientes, Validador=true}, JsonRequestBehavior.AllowGet);
        }

    }
}