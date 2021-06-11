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
        public List<ServicioModel> ObtenerServicios()
        {
            return _Control.ObtenerServicios();
        }
        public List<ClienteModel> ObtenerClientes()
        {
            return _Control.ObtenerClientes();
        }
        public List<UsuarioModel> ObtenerUsuarios()
        {
            return _Control.ObtenerUsuarios();
        }
        public List<VehiculoModel> ObtenerVehiculos()
        {
            return _Control.ObtenerVehiculos();
        }
        public List<ProveedorModel> ObtenerProveedores()
        {
            return _Control.ObtenerProveedores();
        }
        public List<TipoUsuarioModel> ObtenerTiposUsuarios()
        {
            return _Control.ObtenerTiposUsuarios();
        }

        public ClienteModel BuscarCliente(string rutCliente) 
        {
            return _Control.BuscarCliente(rutCliente);
        }
    }
}
