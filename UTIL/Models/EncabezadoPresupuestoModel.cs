using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTIL.Models
{
    public class EncabezadoPresupuestoModel
    {
        int folioEncabezado { get; set; }
        string fk_rutCliente { get; set; }
        string fk_patente { get; set; }
        DateTime fecha { get; set; }
        string observaciones { get; set; }
        string estado { get; set; }
        int neto { get; set; }
        int iva { get; set; }
        int total { get; set; }
    }
}
