using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTIL.Models
{
    public class DetallePresuModel
    {
        public int folioDetalle { set; get; }
        public int codigo { set; get; }

        public string nombre { set; get; }
        public int fk_folioEncabezado { set; get; }
        public int cantidad { set; get; }
        public int Unidad { set; get; }
        public int subTotal { set; get; }

    }
}
