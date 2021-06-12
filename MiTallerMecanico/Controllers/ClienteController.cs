using MiTallerMecanico.UTIL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTIL.Models;

namespace MiTallerMecanico.Controllers
{
    public class ClienteController : BaseController
    {
        // GET: Cliente
        public ActionResult CrearCliente()
        {
            return View();
        }
        public ActionResult ConsultarCliente()
        {
            List<ClienteModel> clientes = controlTaller().ObtenerClientes();
            ViewBag.Clientes = clientes;

            return View();
        }

        public ActionResult ModificarCliente()
        {
            return View();
        }
    }
}