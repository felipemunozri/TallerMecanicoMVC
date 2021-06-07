using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTIL.Models
{
    public class EncabezadoPresupuestoModel
    {

        int folioEncabezado { set; get; }
        string fk_rutCliente { set; get; }

        string fk_patente { set; get; }
        DateTime fecha { set; get; }
        string observaciones { set; get; }

        string estado { set; get; }

        int neto { set; get; }

        int iva { set; get; }
        int total { set; get; }


    }
}
