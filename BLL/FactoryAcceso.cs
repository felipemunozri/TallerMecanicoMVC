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
    }
}
