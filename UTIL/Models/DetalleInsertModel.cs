using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTIL.Models
{
   public  class DetalleInsertModel
    {
        public int folioDetalle { get; set; }
        public int fk_folioEncabezado { get; set; }
        public int id { get; set; }
        public int cantidad { get; set; }
        public char Tipo { get; set; }
        public int contador { get; set; }
        public int subTotal { get; set; }
    }
}
