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
