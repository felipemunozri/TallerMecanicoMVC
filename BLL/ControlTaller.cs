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

        public List<PresupuestoModel> obtenerPresupuestosAprobados()
        {
            return _Control.obtenerPresupuestosAprobados();
        }
        public List<UsuarioModel> obtenerMecanicos() {
            return _Control.obtenerMecanicos();
        }

        public EstadoModel obtenerEstado(string patente) {

            return _Control.obtenerEstado(patente);
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

        public RespuestaModel AgregarDetalle(DetalleInsertModel detalle, int id) {

            return _Control.AgregarDetalle(detalle,id);
        }


        public List<EncabezadoDetalle> obtenerEncabezadoDetalle(int _IdPresu) {

            return _Control.obtenerEncabezadoDetalle(_IdPresu);
        }


        public EncabezadoDetalle EncabezadoPDF(int id) {

            return _Control.EncabezadoPDF(id);
        }

        public List<DetallePresuModel> obtenerDetalle(int _IdPresu) {

            return _Control.obtenerDetalle(_IdPresu);
        }
        public List<ModalDetalleOrden> ObtenerDetalleOrdenes(int idOrden)
        {

            return _Control.ObtenerDetalleOrdenes(idOrden);
        }

        public List<ModalDetalleOrden> OrdenesMecanico(int idUsuario)
        {

            return _Control.OrdenesMecanico(idUsuario);
        }
        public List<ModalDetalleOrdenDetalle> obtenerDetalleOrdenDetalle(int idOrden)
        {

            return _Control.obtenerDetalleOrdenDetalle(idOrden);
        }
        public RespuestaModel ActualizarEstadoOrden(string patente,string Estado) {

            
            return _Control.ActualizarEstadoOrden(patente, Estado);
        }

        public RespuestaModel ActulizarComentario(int id, string comentario)
        {

            return _Control.ActulizarComentario(id, comentario);
        }



        public List<DetallePresupuestoModel> obtenerDetalleExacto(int _IdPresu)
        {

            return _Control.obtenerDetalleExacto(_IdPresu);
        }
        
        public RespuestaModel EliminarDetalle(int Linea, int idEncabezado) {
            
            return _Control.EliminarDetalle(Linea, idEncabezado);
        }

        public RespuestaModel ActualizarEncabezado(int idEncabezado,int  neto,int  iva,int  total)
        {

            return _Control.ActualizarEncabezado(idEncabezado, neto, iva, total);
        }


        public DetallePresuModel buscarDetalle(int Linea,int idEncabezado)
        {
            return _Control.buscarDetalle(Linea, idEncabezado);
        }


        public RespuestaModel ActualizaDetalle(int folioDetalle, int cantidad, int subtotal) {

            return _Control.ActualizaDetalle(folioDetalle, cantidad, subtotal);
        }

        public RespuestaModel ActualizaObservacion(int idEncabezado, string observacion) {

            return _Control.ActualizaObservacion(idEncabezado,observacion);
        }

        public RespuestaModel ActualizarEstadoPresupuesto(int idEncabezado)
        {

            return _Control.ActualizarEstadoPresupuesto(idEncabezado);
        }

        public RespuestaModel AgregarEncabezadoOrden(OrdenModel orden) {

            return _Control.AgregarEncabezadoOrden(orden);
        }
        public RespuestaModel AgregarDetalleOrden(DetalleOrden detalle)
        {
            return _Control.AgregarDetalleOrden(detalle);
        }


        #region Ordenes

        public List<ListarOrdenesTrabajo> listarOrdenes() {

            return _Control.listarOrdenes();
        }

        public List<ListarOrdenesTrabajo> listarOrdenesAnuladas()
        {

            return _Control.listarOrdenesAnuladas();
        }

        public RespuestaModel AnularOrden(int id) {

            return _Control.AnularOrden(id);
        }

        #endregion
    }
}
