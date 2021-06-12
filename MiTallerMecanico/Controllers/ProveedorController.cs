using MiTallerMecanico.UTIL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTIL.Models;


namespace MiTallerMecanico.Controllers
{
    public class ProveedorController : BaseController
    {
        // GET: Proveedor
        public ActionResult CrearProveedor()
        {
            return View();
        }
        public ActionResult ConsultarProveedor()
        {
            List<ProveedorModel> proveedores = controlTaller().ObtenerProveedores();
            ViewBag.Proveedores = proveedores;

            return View();
        }
        public ActionResult ModificarProveedor()
        {
            return View();
        }
    }
}