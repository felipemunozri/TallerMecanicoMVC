using MiTallerMecanico.UTIL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTIL.Models;


namespace MiTallerMecanico.Controllers
{
    public class UsuarioController : BaseController
    {
        // GET: Usuario
        public ActionResult CrearUsuario()
        {
            #region dropdownlist
            List<TipoUsuarioModel> tipoUsuarios = controlTaller().ObtenerTiposUsuarios();
            ViewBag.TipoUsuarios = tipoUsuarios;
            #endregion

            return View();
        }

        public ActionResult ConsultarUsuario()
        {
            List<UsuarioModel> usuarios = controlTaller().ObtenerUsuarios();
            ViewBag.Usuarios = usuarios;

            return View();
        }
        public ActionResult ModificarUsuario()
        {
            #region dropdownlist
            List<TipoUsuarioModel> tipoUsuarios = controlTaller().ObtenerTiposUsuarios();
            ViewBag.TipoUsuarios = tipoUsuarios;
            #endregion

            return View();
        }
    }
}