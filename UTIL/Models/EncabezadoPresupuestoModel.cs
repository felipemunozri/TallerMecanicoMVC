using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTIL.Models
{
    public class EncabezadoPresupuestoModel
    {
        public int folioEncabezado { get; set; }
        
        public string fk_rutCliente { get; set; }
        
        public string fk_patente { get; set; }

        public DateTime fecha { get; set; }
        public string observaciones { get; set; }

        public string estado { get; set; }

        public int neto { get; set; }

        public int iva { get; set; }

        public int total { get; set; }
    }
}
