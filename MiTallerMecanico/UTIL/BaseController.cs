using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTIL.Models;


namespace MiTallerMecanico.UTIL
{
    public class BaseController: Controller
    {
        private ControlTaller _control = new ControlTaller();

        public UsuarioModel obtenerUsuario()
        {
            return SessionVariables.SESSION_DATOS_USUARIO;
        }
        public ControlTaller controlTaller()
        {
            return _control;
        }

      
    }
}