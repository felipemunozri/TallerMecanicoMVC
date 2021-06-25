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

        [HttpPost]
        public JsonResult obtieneServicios()
        {

            List<ServicioModel> ser = controlTaller().ObtenerServicios();

            return MiTallerMecanico.UTIL.JsonResultResponse.ObtenerResponse<List<ServicioModel>>(ser);
        }




        public JsonResult GenerePdfCotizacion(int Id)
        {
            try
            {
                string mapPath = System.Web.Hosting.HostingEnvironment.MapPath("~/Presupuestos/");
                string rutas = "";

                EncabezadoDetalle Enca = controlTaller().EncabezadoPDF(Id);
                List<DetallePresuModel> deta = controlTaller().obtenerDetalle(Id);


                RespuestaModel response = new MiTallerMecanico.UTIL.PDF.PDF().GeneraPdfCotizacionII(mapPath, Enca, deta);
                rutas = response.RutaArchivo;
                SessionVariables.SESSION_RUTA_PDF_COTIZACION = rutas;
                return Json(response.Mensaje);
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return Json(new { Verificador = false, Mensaje = "Se produjo un error al generar el reporte, favor reintentelo, si el problema persiste, comuniquese con su administrador" });
            }
        }
    }

}