using MiTallerMecanico.UTIL;
using System;
using System.Collections.Generic;
using System.Globalization;
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

            List<ServicioModel> servicios = controlTaller().ObtenerServicios();
            ViewBag.Servicios = servicios;
            #endregion

            return View();
        }

        public ActionResult ConsultarPresupuesto()
        {
            List<PresupuestoModel> presu = controlTaller().obtenerPresupuestos();
            ViewBag.presu = presu;

            List<UsuarioModel> mecanicos = controlTaller().obtenerMecanicos();
           
            ViewBag.mecanico = mecanicos;

            return View();
        }

        public ActionResult ModificarPresupuesto()
        {
            #region dropdownlist
            List<TipoVehiculoModel> tipoVehiculos = controlTaller().ObtenerTiposVehiculos();
            ViewBag.TipoVehiculos = tipoVehiculos;

            List<RepuestoModel> repuestos = controlTaller().ObtenerRepuestos();
            ViewBag.Respuestos = repuestos;

            List<ServicioModel> servicios = controlTaller().ObtenerServicios();
            ViewBag.Servicios = servicios;
            #endregion

            return View();
        }

        public ActionResult PresupuestosAprobados()
        {
            List<PresupuestoModel> presuAprobados = controlTaller().obtenerPresupuestosAprobados();
            ViewBag.presuAprobador = presuAprobados;

            return View();
        }
        #endregion

        [HttpPost]
        public ActionResult BuscarCliente(string rutcliente) {

            ClienteModel clientes = controlTaller().BuscarCliente(rutcliente);

            if (clientes == null)
            {
                return Json(new { cliente = clientes, Validador = false }, JsonRequestBehavior.AllowGet);
            }
            else {
                return Json(new { cliente = clientes, Validador = true }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]

        public ActionResult BuscarVehiculo(string patente) {

            VehiculoModel vehiculo = controlTaller().BuscarVehiculo(patente);

            if (vehiculo == null)
            {
                return Json(new { vehiculo = vehiculo, Validador = false }, JsonRequestBehavior.AllowGet);
            }
            else {

                return Json(new { vehiculo = vehiculo, Validador = true }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult obtenerServiciosRespuestos()
        {

            List<ServicioModel> servicios = controlTaller().ObtenerServicios();
            List<RepuestoModel> repuestos = controlTaller().ObtenerRepuestos();
         
           
                return Json(new { servicios = servicios , repuestos=repuestos}, JsonRequestBehavior.AllowGet);
            }

        
        public JsonResult AgregarPresupuesto(EncabezadoPresupuestoModel presupuesto, List<DetalleInsertModel> detalle) {

            RespuestaModel id_encabezado = controlTaller().AgregarEncabezado(presupuesto);

            for (int i = 0; i < detalle.Count; i++)
            {

                RespuestaModel Detalle = controlTaller().AgregarDetalle(detalle[i], Convert.ToInt32(id_encabezado.id_encabezado));

            }
            if (id_encabezado == null && detalle == null)
            {

                return Json(new { Validador = false }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { Validador = true }, JsonRequestBehavior.AllowGet);
            }
          

        }


        [HttpPost]
        public JsonResult DetallePresupuesto(int _IdPresu) {

            List<EncabezadoDetalle> enca = controlTaller().obtenerEncabezadoDetalle(_IdPresu);

            List<DetallePresuModel> deta = controlTaller().obtenerDetalle(_IdPresu);




            return Json(new { Cabecera =enca, Detalle =deta }, JsonRequestBehavior.AllowGet);
        }




        [HttpPost]
        public JsonResult EditarPresupuesto(int _IdPresu)
        {

            List<EncabezadoDetalle> enca = controlTaller().obtenerEncabezadoDetalle(_IdPresu);

            List<DetallePresuModel> deta = controlTaller().obtenerDetalle(_IdPresu);




            return Json(new { Cabecera = enca, Detalle = deta }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult EliminarDetalle(int Linea, int idEncabezado)
        {
            int neto=0;
            int  netoAux = 0;
            int  iva=0;
            int total;
            RespuestaModel respuesta = controlTaller().EliminarDetalle(Linea, idEncabezado);

            List<EncabezadoDetalle> enca = controlTaller().obtenerEncabezadoDetalle(idEncabezado);
            List<DetallePresuModel> deta = controlTaller().obtenerDetalle(idEncabezado);

            for (int i = 0; i < deta.Count; i++)
            {
                netoAux = neto + netoAux;
                neto =netoAux+deta[i].subTotal;
            }

            iva = (neto * 19)/100;
            total = neto + iva;

            RespuestaModel upd = controlTaller().ActualizarEncabezado(idEncabezado,neto,iva,total);



            return Json(new { Cabecera = enca, Detalle = deta, Verificador = true }, JsonRequestBehavior.AllowGet);
        }


        public JsonResult BuscarDetalle(int Linea, int idEncabezado)
        {
           
            DetallePresuModel deta = controlTaller().buscarDetalle(Linea, idEncabezado);

            if (deta ==null) {

                return Json(new { Detalle = deta, Verificador = false }, JsonRequestBehavior.AllowGet);
            }
            else {

                return Json(new { Detalle = deta, Verificador = true }, JsonRequestBehavior.AllowGet);
            }
           
        }

        public JsonResult detallexmodificar(int folioDetalle, int idEncabezado, int cantidad,int subtotal)
        {
            int neto = 0;
            int netoAux = 0;
            int iva = 0;
            int total;
            RespuestaModel upd = controlTaller().ActualizaDetalle(folioDetalle,cantidad,subtotal);

          List<EncabezadoDetalle> enca = controlTaller().obtenerEncabezadoDetalle(idEncabezado);
            List<DetallePresuModel> deta = controlTaller().obtenerDetalle(idEncabezado);

            for (int i = 0; i < deta.Count; i++)
            {
                netoAux = neto + netoAux;
                neto = netoAux + deta[i].subTotal;
            }

            iva = (neto * 19) / 100;
            total = neto + iva;

            RespuestaModel up = controlTaller().ActualizarEncabezado(idEncabezado, neto, iva, total);


            return Json(new { Cabecera = enca, Detalle = deta, Verificador = true }, JsonRequestBehavior.AllowGet);
        }


        public JsonResult ActualizarObservacion(int Id, string observacion)
        {
           
            RespuestaModel upd = controlTaller().ActualizaObservacion(Id, observacion);


            return Json(new {Verificador = true }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AprobarPresupuesto( int id) {

            List<UsuarioModel> mecanicos = controlTaller().obtenerMecanicos();
            
            return Json(new {mecanicos= mecanicos, Verificador = true }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GenerarOrden(int idPresupuesto,int Idmecanico,string prioridad, DateTime fecha)
        {
          var fh = DateTime.Now.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture);
           
            List<EncabezadoDetalle> enca = controlTaller().obtenerEncabezadoDetalle(idPresupuesto);
            List<DetallePresupuestoModel> deta = controlTaller().obtenerDetalleExacto(idPresupuesto);

            DetalleOrden detalle = new DetalleOrden();
            OrdenModel orden = new OrdenModel();
 
            orden.fk_idUsuario = Idmecanico;
            orden.fk_rutCliente = enca[0].rutCliente;
            orden.fk_patente = enca[0].patente;
            orden.fecha = Convert.ToDateTime(fh);
            orden.fechaEntrega = fecha;
            orden.prioridad = prioridad;
            orden.observaciones = enca[0].observaciones;
            orden.anulacion = false;
            orden.neto = enca[0].neto;
            orden.iva = enca[0].iva;
            orden.total = enca[0].total;

            RespuestaModel idDetalleEncabezado = controlTaller().AgregarEncabezadoOrden(orden);


            for (int i = 0; i < deta.Count; i++) {

                detalle.fk_folioOrden = Convert.ToInt32(idDetalleEncabezado.id_encabezado);
                detalle.id = deta[i].id;
                detalle.cantidad = deta[i].cantidad;
                detalle.Tipo = char.Parse(deta[i].tipo);
                detalle.subTotal = deta[i].subTotal;

                RespuestaModel ins = controlTaller().AgregarDetalleOrden(detalle);
            }

            RespuestaModel act = controlTaller().ActualizarEstadoPresupuesto(idPresupuesto);

            return Json(new {  Verificador = true }, JsonRequestBehavior.AllowGet);
        }


        




    }



}
