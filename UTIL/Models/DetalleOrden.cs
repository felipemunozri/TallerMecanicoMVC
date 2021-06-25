using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTIL.Models
{
    public class DetalleOrden
    {
        public int folioDetalleOrden { set; get; }
        public int fk_folioOrden { set; get; }
        public int id { set; get; }
        public int cantidad { set; get; }
        public char Tipo { set; get; }
        public int  subTotal { set; get;}


    }
}
