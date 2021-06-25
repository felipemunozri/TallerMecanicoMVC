using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTIL.Models
{
    public class ListarOrdenesTrabajo
    {
        public int folioOrden { set; get; }

        public string Nombre { set; get; }

        public string rutCliente { set; get; }
        public string patente { set; get; }
        public string marca { set; get; }
        public string modelo { set; get; }
        public string fecha { set; get; }
        public string Plazo { set; get; }
        public string Responsable { set; get; }
        public string prioridad { set; get; }
        public int neto { set; get; }
        public int iva { set; get; }
        public int  total { set; get; }
        public string estado { set; get; }

    }
}
