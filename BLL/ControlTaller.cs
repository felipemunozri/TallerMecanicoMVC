using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTIL.Models;


namespace BLL
{
    public class ControlTaller
    {
        private FactoryAcceso _Control = new FactoryAcceso();



        public UsuarioModel Login(UsuarioModel usuario)
        {
            return _Control.Login(usuario);
        }


        public List<TipoVehiculoModel> ObtenerTiposVehiculos()
        {
            return _Control.ObtenerTiposVehiculos();
        }

        public List<RepuestoModel> ObtenerRepuestos() 
        {
            return _Control.ObtenerRepuestos();
        }
        public List<ServiciosModel> ObtenerServicios()
        {
            return _Control.ObtenerServicios();
        }

        public ClienteModel BuscarCliente(string rutCliente) {


            return _Control.BuscarCliente(rutCliente);
        }
    }
}
