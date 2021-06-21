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

        public RespuestaModel AgregarDetalle(DetallePresupuestoModel detalle,int id)
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



        public List<EncabezadoDetalle> obtenerEncabezadoDetalle( int _IdPresu)
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
    }
}
