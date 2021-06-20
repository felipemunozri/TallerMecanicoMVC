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

        public List<PresupuestoModel> obtenerPresupuestos() {
            return _Control.obtenerPresupuestos();
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

        public VehiculoModel BuscarVehiculo(string patente) {
            
            return _Control.BuscarVehiculo(patente);
        }


        public RespuestaModel AgregarEncabezado(EncabezadoPresupuestoModel presupuesto) {

            return _Control.AgregarEncabezado(presupuesto);
        }

        public RespuestaModel AgregarDetalle(DetallePresupuestoModel detalle, int id) {

            return _Control.AgregarDetalle(detalle,id);
        }


        public List<EncabezadoDetalle> obtenerEncabezadoDetalle(int _IdPresu) {

            return _Control.obtenerEncabezadoDetalle(_IdPresu);
        }

        public List<DetallePresuModel> obtenerDetalle(int _IdPresu) {

            return _Control.obtenerDetalle(_IdPresu);
        }
    }
}
