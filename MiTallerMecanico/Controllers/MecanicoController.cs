using MiTallerMecanico.UTIL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTIL.Models;

namespace MiTallerMecanico.Controllers
{
    public class MecanicoController : BaseController
    {
        // GET: Mecanico
        public ActionResult Mecanico()
        {
            var resultado = SessionVariables.SESSION_DATOS_USUARIO;

            List < ModalDetalleOrden>mecanicos=controlTaller().OrdenesMecanico(resultado.idUsuario);

            ViewBag.Mec = mecanicos;
            
            return View();
        }

        public JsonResult DetalleOrdenes(int idOrden)
        {

            List<ModalDetalleOrden> enca = controlTaller().ObtenerDetalleOrdenes(idOrden);

            List<ModalDetalleOrdenDetalle> deta = controlTaller().obtenerDetalleOrdenDetalle(idOrden);




            return Json(new { Cabecera = enca, Detalle = deta }, JsonRequestBehavior.AllowGet);
        }

        

        public JsonResult EditarOrdenMecanico(int id, string comentario, string Estado,string patente)
        {

            RespuestaModel est = controlTaller().ActualizarEstadoOrden(patente, Estado);

            RespuestaModel com = controlTaller().ActulizarComentario(id, comentario);

            //List<ModalDetalleOrdenDetalle> deta = controlTaller().obtenerDetalleOrdenDetalle(idOrden);




            return Json(new { Verificador=true }, JsonRequestBehavior.AllowGet);
        }
    }
}