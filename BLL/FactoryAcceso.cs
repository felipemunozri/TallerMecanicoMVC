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

        public List<ServiciosModel> ObtenerServicios()
        {
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("MT_GET_Servicios", new System.Collections.Hashtable()
                {

                }).Tables[0];
                return UTIL.Mapper.BindDataList<ServiciosModel>(data);
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
    }
}
