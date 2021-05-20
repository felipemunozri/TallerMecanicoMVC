using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTIL.Objetos;

namespace BLL
{
    public class FactoryAcceso
    {
        public ObjetoUsuario Login(ObjetoUsuario datosUsuario) {

            var DatosLogin = new ObjetoUsuario();

            var data = new DBConector().EjecutarProcedimientoAlmacenado("nombre_SP", new System.Collections.Hashtable()
            {
                {"nombreUsuario",datosUsuario.nombreUsuario },
                { "password",datosUsuario.passUsuario}
            }).Tables[0];


        return DatosLogin;
        }
    }
}
