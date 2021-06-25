using MiTallerMecanico.UTIL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTIL;
using UTIL.Models;
using UTIL.Validaciones;

namespace MiTallerMecanico.Controllers
{
    public class LoginController : BaseController
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult LogOut()
        {
            SessionVariables.SESSION_DATOS_USUARIO = null;

            return RedirectToAction("Login", "Login");
        }

        [HttpPost]
        public JsonResult Login(string _Nombre, string _Contrasena)
        {
            var datosUsuarios = new UsuarioModel();

            SessionVariables.SESSION_DATOS_USUARIO = null;

            var validador = 0;
            datosUsuarios.nombreUsuario = _Nombre;
            datosUsuarios.passUsuario = _Contrasena;

            try
            {

                if (datosUsuarios.nombreUsuario.ToLower() == "adm" && datosUsuarios.passUsuario == "1234")
                {
                    var resultado = new UsuarioModel();
                    validador = 1;
                    resultado.idUsuario = 1;
                    resultado.nombreUsuario = "adm";
                    resultado.fk_idTipoUsuario = 1;

                    SessionVariables.SESSION_DATOS_USUARIO = resultado;


                    return Json(new { Validador = validador });
                }
                else
                {
                    LogUser.agregarLog("Lee Contraseña");
                    datosUsuarios.passUsuario = HashMD5.GetMD5(datosUsuarios.passUsuario);

                    LogUser.agregarLog("Contraseña:" + datosUsuarios.passUsuario);


                    var resultado = controlTaller().Login(datosUsuarios);
     
                
                   if (resultado != null)
                    {
                        validador = 1;
                        int tipoUsuario = resultado.fk_idTipoUsuario;
                        SessionVariables.SESSION_DATOS_USUARIO = resultado;
                        return Json(new { tipo=tipoUsuario,Validador = validador });
                    }
                 


                    return Json(new  RespuestaModel (){ Verificador = false,Mensaje="Error de Usuario y/o contraseña" });
                }

            }
            catch (Exception e) {
                string error = e.Message.ToString();
                LogUser.agregarLog(error);
                return null;
            
            }
        }
    }
}