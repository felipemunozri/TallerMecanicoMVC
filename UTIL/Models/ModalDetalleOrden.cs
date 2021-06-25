using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTIL.Models
{
    public class ModalDetalleOrden
    {

        public int folioOrden { get; set; }
        public string  Nombre { get; set; }
        public string rutCliente { get; set; }
        public int telefonoCliente { get; set; }
        public string patente { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public int ano { get; set; }

        public int kilometraje { get; set; }

        public string  fecha { get; set; }
        public string  Plazo { get; set; }
        public string Responsable { get; set; }
        public string prioridad { get; set; }
        public string observaciones { get; set; }
        public int neto { get; set; }
        public int iva { get; set; }
        public int total { get; set; }
        public string estado { get; set; }

        public string Anulada { get; set; }

    }
}
