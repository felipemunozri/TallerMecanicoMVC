using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTIL;
using UTIL.Models;

namespace BLL
{
    public class FactoryAcceso
    {

        #region Login

        public UsuarioModel Login(UsuarioModel datosUsuarios)
        {
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("SP_GET_LOGIN", new System.Collections.Hashtable()
                {
                    {"Nombre", datosUsuarios.nombreUsuario},
                    {"Contrasena", datosUsuarios.passUsuario }
                }).Tables[0];
                return UTIL.Mapper.BindData<UsuarioModel>(data);
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                LogUser.agregarLog(error);
                return null;
            }
        }

        #endregion}

        #region Presupuesto

        public  List<TipoVehiculoModel> ObtenerTiposVehiculos()
        {
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("MT_GET_TipoVehiculo", new System.Collections.Hashtable()
                {
  
                }).Tables[0];
                return UTIL.Mapper.BindDataList<TipoVehiculoModel>(data);
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                LogUser.agregarLog(error);
                return null;
            }
        }
        public List<RepuestoModel> ObtenerRepuestos()
        {
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("MT_GET_Repuestos", new System.Collections.Hashtable()
                {

                }).Tables[0];
                return UTIL.Mapper.BindDataList<RepuestoModel>(data);
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                LogUser.agregarLog(error);
                return null;
            }
        }

        public List<ServicioModel> ObtenerServicios()
        {
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("MT_GET_Servicios", new System.Collections.Hashtable()
                {

                }).Tables[0];
                return UTIL.Mapper.BindDataList<ServicioModel>(data);
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                LogUser.agregarLog(error);
                return null;
            }
        }


        public ClienteModel BuscarCliente(string rutCliente)
        {
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("MT_GET_BuscarCliente", new System.Collections.Hashtable()
                {
                     {"rut", rutCliente}
                }).Tables[0];
                return UTIL.Mapper.BindData<ClienteModel>(data);
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                LogUser.agregarLog(error);
                return null;
            }
        }

        public List<PresupuestoModel> obtenerPresupuestos()
        {
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("MT_SP_GET_Presupuestos", new System.Collections.Hashtable()
                {
                     
                }).Tables[0];
                return UTIL.Mapper.BindDataList<PresupuestoModel>(data);
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                LogUser.agregarLog(error);
                return null;
            }
        }

        public List<PresupuestoModel> obtenerPresupuestosAprobados()
        {
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("MT_SP_GET_PresupuestosAprobador", new System.Collections.Hashtable()
                {

                }).Tables[0];
                return UTIL.Mapper.BindDataList<PresupuestoModel>(data);
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                LogUser.agregarLog(error);
                return null;
            }
        }

        public List<UsuarioModel> obtenerMecanicos()
        {
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("MT_SP_GET_obtenerMecanicos", new System.Collections.Hashtable()
                {

                }).Tables[0];
                return UTIL.Mapper.BindDataList<UsuarioModel>(data);
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                LogUser.agregarLog(error);
                return null;
            }
        }


        public RespuestaModel AgregarEncabezado(EncabezadoPresupuestoModel presupuesto)
        {
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("SP_INS_EncabezadoPresupuesto", new System.Collections.Hashtable()
                {
                    {"rutcliente",presupuesto.fk_rutCliente},
                    {"patente",presupuesto.fk_patente},
                    { "fecha",presupuesto.fecha},
                    { "observaciones",presupuesto.observaciones},
                    { "estado",presupuesto.estado},
                    { "neto", presupuesto.neto},
                    { "iva", presupuesto.iva},
                    { "total",presupuesto.total}
                }).Tables[0];
                return UTIL.Mapper.BindData<RespuestaModel>(data);
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return null;
            }
        }

        public RespuestaModel AgregarDetalle(DetalleInsertModel detalle,int id)
        {
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("SP_INS_DetallePresupuesto", new System.Collections.Hashtable()
                {
                    {"FolioEncabezado",id},
                    {"id",detalle.id},
                    { "cantidad",detalle.cantidad},
                    { "Tipo",detalle.Tipo},
                    { "subTotal",detalle.subTotal}
                    
                }).Tables[0];
                return UTIL.Mapper.BindData<RespuestaModel>(data);
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return null;
            }
        }


        public EstadoModel obtenerEstado(string patente)
        {
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("MT_SP_GET_Estado", new System.Collections.Hashtable()
                {
                    {"patente",patente},
                 

                }).Tables[0];
                return UTIL.Mapper.BindData<EstadoModel>(data);
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return null;
            }
        }

        public RespuestaModel ActulizarComentario(int id,string comentario)
        {
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("MT_SP_UP_ActualizarObservacionOrden", new System.Collections.Hashtable()
                {
                    {"id",id},
                    {"comentario",comentario}
                   

                }).Tables[0];
                return UTIL.Mapper.BindData<RespuestaModel>(data);
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return null;
            }
        }

        public RespuestaModel ActualizarEstadoOrden(string patente, string Estado)
        {
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("MT_SP_UP_ActualizarEstadoOR", new System.Collections.Hashtable()
                {
                    {"patente",patente},
                    {"estado",Estado}


                }).Tables[0];
                return UTIL.Mapper.BindData<RespuestaModel>(data);
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return null;
            }
        }

        public List <EncabezadoDetalle> obtenerEncabezadoDetalle( int _IdPresu)
        {
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("MT_SP_GET_EncabezadoDetalle", new System.Collections.Hashtable()
                {
                    {"id_Encabezado",_IdPresu}
                    

                }).Tables[0];
                return UTIL.Mapper.BindDataList<EncabezadoDetalle>(data);
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return null;
            }
        }

        public EncabezadoDetalle EncabezadoPDF(int id)
        {
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("MT_SP_GET_EncabezadoDetalle", new System.Collections.Hashtable()
                {
                    {"id_Encabezado",id}


                }).Tables[0];
                return UTIL.Mapper.BindData<EncabezadoDetalle>(data);
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return null;
            }
        }

        public List<DetallePresuModel> obtenerDetalle(int _IdPresu)
        {
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("MT_SP_GET_DetallePrespuesto", new System.Collections.Hashtable()
                {
                    {"id_Encabezado",_IdPresu}


                }).Tables[0];
                return UTIL.Mapper.BindDataList<DetallePresuModel>(data);
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return null;
            }
        }

        public List<ModalDetalleOrden> ObtenerDetalleOrdenes(int idOrden)
        {
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("MT_SP_GET_DEtalleOrden", new System.Collections.Hashtable()
                {
                    {"id_orden",idOrden}


                }).Tables[0];
                return UTIL.Mapper.BindDataList<ModalDetalleOrden>(data);
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return null;
            }
        }


        public List<ModalDetalleOrden> OrdenesMecanico(int idUsuario)
        {
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("MT_SP_GET_Mecanico", new System.Collections.Hashtable()
                {
                    {"idUsuario",idUsuario}


                }).Tables[0];
                return UTIL.Mapper.BindDataList<ModalDetalleOrden>(data);
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return null;
            }
        }

        public List<ModalDetalleOrdenDetalle> obtenerDetalleOrdenDetalle(int idOrden)
        {
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("MT_SP_GET_DetalleOrdenModal", new System.Collections.Hashtable()
                {
                    {"id_Orden",idOrden}


                }).Tables[0];
                return UTIL.Mapper.BindDataList<ModalDetalleOrdenDetalle>(data);
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return null;
            }
        }
        
        public List<DetallePresupuestoModel> obtenerDetalleExacto(int _IdPresu)
        {
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("MT_SP_GET_DetallePrespuestoExacto", new System.Collections.Hashtable()
                {
                    {"id_Encabezado",_IdPresu}


                }).Tables[0];
                return UTIL.Mapper.BindDataList<DetallePresupuestoModel>(data);
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return null;
            }
        }


        public RespuestaModel EliminarDetalle(int linea,int idEncabezado)
        {
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("MT_SP_DEL_DetallePresupuesto", new System.Collections.Hashtable()
                {
                    {"idEncabezado",idEncabezado},
                    {"linea",linea}


                }).Tables[0];
                return UTIL.Mapper.BindData<RespuestaModel>(data);
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return null;
            }
        }

        public DetallePresuModel buscarDetalle(int linea, int idEncabezado)
        {
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("MT_SP_GET_BuscarDetalle", new System.Collections.Hashtable()
                {
                    {"idEncabezado",idEncabezado},
                    {"linea",linea}


                }).Tables[0];
                return UTIL.Mapper.BindData<DetallePresuModel>(data);
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return null;
            }
        }



        public RespuestaModel ActualizarEncabezado(int idEncabezado, int neto, int iva, int total)
        {
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("MT_SP_UP_ActualizarPresupuesto", new System.Collections.Hashtable()
                {
                    {"idEncabezado",idEncabezado},
                    {"neto",neto},
                    {"iva",iva},
                    {"total",total}   



            }).Tables[0];
                return UTIL.Mapper.BindData<RespuestaModel>(data);
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return null;
            }
        }

        public RespuestaModel ActualizaDetalle(int folioDetalle, int cantidad, int subtotal)
        {
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("MT_SP_UP_ActualizarDetalle", new System.Collections.Hashtable()
                {
                    {"folioDetalle",folioDetalle},
                    {"cantidad",cantidad},
                    {"subtotal",subtotal}
                    



            }).Tables[0];
                return UTIL.Mapper.BindData<RespuestaModel>(data);
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return null;
            }
        }


        public RespuestaModel ActualizaObservacion(int idEncabezado, string observacion)
        {
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("MT_SP_UP_ActualizarObservacionPresu", new System.Collections.Hashtable()
                {
                    {"idEncabezado",idEncabezado},
                    {"observacion",observacion}
                   




            }).Tables[0];
                return UTIL.Mapper.BindData<RespuestaModel>(data);
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return null;
            }
        }



        #endregion


        public VehiculoModel BuscarVehiculo(string patente)
        {
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("MT_GET_BuscarVehiculo", new System.Collections.Hashtable()
                {
                     {"patente", patente}
                }).Tables[0];
                return UTIL.Mapper.BindData<VehiculoModel>(data);
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                LogUser.agregarLog(error);
                return null;
            }
        }



        #region Cliente

        public List<ClienteModel> ObtenerClientes()
        {
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("MT_GET_Clientes", new System.Collections.Hashtable()
                {

                }).Tables[0];
                return UTIL.Mapper.BindDataList<ClienteModel>(data);
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                LogUser.agregarLog(error);
                return null;
            }
        }

        #endregion

        #region Usuario

        public List<UsuarioModel> ObtenerUsuarios()
        {
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("MT_GET_Usuarios", new System.Collections.Hashtable()
                {

                }).Tables[0];
                return UTIL.Mapper.BindDataList<UsuarioModel>(data);
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                LogUser.agregarLog(error);
                return null;
            }
        }

        #endregion

        #region Vehiculo

        public List<VehiculoModel> ObtenerVehiculos()
        {
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("MT_GET_Vehiculos", new System.Collections.Hashtable()
                {

                }).Tables[0];
                return UTIL.Mapper.BindDataList<VehiculoModel>(data);
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                LogUser.agregarLog(error);
                return null;
            }
        }

        #endregion

        #region Proveedor

        public List<ProveedorModel> ObtenerProveedores()
        {
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("MT_GET_Proveedores", new System.Collections.Hashtable()
                {

                }).Tables[0];
                return UTIL.Mapper.BindDataList<ProveedorModel>(data);
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                LogUser.agregarLog(error);
                return null;
            }
        }

        #endregion

        #region TipoUsuario

        public List<TipoUsuarioModel> ObtenerTiposUsuarios()
        {
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("MT_GET_TipoUsuario", new System.Collections.Hashtable()
                {

                }).Tables[0];
                return UTIL.Mapper.BindDataList<TipoUsuarioModel>(data);
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                LogUser.agregarLog(error);
                return null;
            }
        }

        #endregion


        #region OrdenTrabajo


        public RespuestaModel AgregarEncabezadoOrden(OrdenModel orden)
        {
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("SP_INS_EncabezadoOrden", new System.Collections.Hashtable()
                {
                    {"IdUsuario",orden.fk_idUsuario},
                    {"rutCliente",orden.fk_rutCliente },
                    { "patente",orden.fk_patente},
                    { "fecha",orden.fecha},
                    { "fechaEntrega",orden.fechaEntrega},
                    { "prioridad",orden.prioridad },
                    { "observacion",orden.observaciones},
                    { "anulacion",orden.anulacion},
                    { "neto",orden.neto},
                    { "iva",orden.iva},
                    { "total",orden.total}
                    
                }).Tables[0];
                return UTIL.Mapper.BindData<RespuestaModel>(data);
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return null;
            }
        }

        public RespuestaModel AgregarDetalleOrden(DetalleOrden detalle)
        {
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("SP_INS_DetalleOrden", new System.Collections.Hashtable()
                {
                    {"folioOrden",detalle.fk_folioOrden},
                    {"id",detalle.id },
                    { "cantidad",detalle.cantidad},
                    { "Tipo",detalle.Tipo},
                    { "subTotal",detalle.subTotal}
                

                }).Tables[0];
                return UTIL.Mapper.BindData<RespuestaModel>(data);
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return null;
            }
        }
        public RespuestaModel ActualizarEstadoPresupuesto(int idEncabezado)
        {
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("MT_SP_UP_ActualizarEstadoPresupuesto", new System.Collections.Hashtable()
                {
                    {"idEncabezado",idEncabezado}
                 

                }).Tables[0];
                return UTIL.Mapper.BindData<RespuestaModel>(data);
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return null;
            }
        }



        public List<ListarOrdenesTrabajo> listarOrdenes() {

            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("MT_SP_GET_OrdenTrabajo", new System.Collections.Hashtable()
                {
                  


                }).Tables[0];
                return UTIL.Mapper.BindDataList<ListarOrdenesTrabajo>(data);
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return null;
            }

        }

        public List<ListarOrdenesTrabajo> listarOrdenesAnuladas()
        {

            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("MT_SP_GET_OrdenAnuladas", new System.Collections.Hashtable()
                {



                }).Tables[0];
                return UTIL.Mapper.BindDataList<ListarOrdenesTrabajo>(data);
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return null;
            }

        }

        public RespuestaModel AnularOrden(int id)
        {

            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("SP_INS_AnularOrden", new System.Collections.Hashtable()
                {
                    {"id",id }


                }).Tables[0];
                return UTIL.Mapper.BindData<RespuestaModel>(data);
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return null;
            }

        }

        #endregion
    }
}
