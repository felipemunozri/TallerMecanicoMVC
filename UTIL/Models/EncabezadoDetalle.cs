using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTIL.Models
{
   public class EncabezadoDetalle
    {
        public int folioEncabezado { set; get; }
        
        public string Nombre { set; get;}

        public string rutCliente { set; get; }

        public int telefonoCliente { set; get; }
        public string patente { set; get; }
        public string marca { set; get; }
        public string modelo { set; get; }
        public  int ano { set; get; }

        public int kilometraje { set; get; }
        public string observaciones { set; get; }
        public string fecha { set; get; }
        public int neto { set; get; }
        public int iva { set; get; }
        public int total { set; get; }

    }
}
