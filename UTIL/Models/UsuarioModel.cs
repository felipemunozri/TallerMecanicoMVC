using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTIL.Models
{
   public class UsuarioModel
    {
        public int IdUsuario{ get; set; }
        public int fk_idTipoUsuario { get; set; }

        public string nombreUsuario { get; set; }
        public string passUsuario { get; set; }
    }
}
