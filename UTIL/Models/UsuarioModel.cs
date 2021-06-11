using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTIL.Models
{
   public class UsuarioModel
    {
        public int idUsuario { get; set; }
        public int fk_idTipoUsuario { get; set; }
        // Añadido nombre del cargo
        public string cargo { get; set; }
        public string nombreUsuario { get; set; }
        public string passUsuario { get; set; }
    }
}
