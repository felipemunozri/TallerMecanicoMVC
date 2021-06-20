using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTIL.Models
{
    public class PresupuestoModel
    {
        public int folioEncabezado { get; set; }
        public string Nombre { get; set; }
        public string rutCliente { get; set; }
        public string patente { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public string fecha { get; set; }
        public int neto { get; set; }
        public int iva { get; set; }
        public int total { get; set; }
        public string Estado { get; set; }


    }
}
