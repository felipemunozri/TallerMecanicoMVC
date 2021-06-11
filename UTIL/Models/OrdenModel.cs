using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTIL.Models
{
    public class OrdenModel
    {
        int folioOrden { get; set; }
        int fk_idUsuario { get; set; }
        string fk_rutCliente { get; set; }
        string fk_patente { get; set; }
        DateTime fecha { get; set; }
        DateTime fechaEntrega { get; set; }
        string prioridad { get; set; }
        string observaciones { get; set; }
        bool anulacion { get; set; }
        int neto { get; set; }
        int iva { get; set; }
        int total { get; set; }
    }
}
