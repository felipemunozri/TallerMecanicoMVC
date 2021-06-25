using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UTIL.Models;


namespace MiTallerMecanico.UTIL
{
    public class SessionVariables
    {
        public static UsuarioModel SESSION_DATOS_USUARIO
        {
            get { return (UsuarioModel)HttpContext.Current.Session["EWRWEFVREFGVR"]; }
            set { HttpContext.Current.Session["EWRWEFVREFGVR"] = value; }
        }
        public static string SESSION_RUTA_PDF_COTIZACION
        {
            get { return (string)HttpContext.Current.Session["TGRKJTGHRDUIOGHRFNVORFGN"]; }
            set { HttpContext.Current.Session["TGRKJTGHRDUIOGHRFNVORFGN"] = value; }
        }


    }
}