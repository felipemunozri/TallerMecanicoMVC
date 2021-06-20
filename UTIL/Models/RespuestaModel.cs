using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTIL.Models
{
    public class RespuestaModel
    {
        public bool Verificador { get; set; }
        public string Mensaje { get; set; }
        public string RutaArchivo { get; set; }

        public decimal id_encabezado { get; set; }
    }
}
