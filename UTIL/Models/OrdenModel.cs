using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTIL.Models
{
    public class OrdenModel
    {
        public int folioOrden { get; set; }
        public int fk_idUsuario { get; set; }
        public string fk_rutCliente { get; set; }
        public string fk_patente { get; set; }
        public DateTime fecha { get; set; }
        public DateTime fechaEntrega { get; set; }
         public string prioridad { get; set; }
         public string observaciones { get; set; }
         public bool anulacion { get; set; }
        public int neto { get; set; }
        public int iva { get; set; }
        public int total { get; set; }
    }
}
