using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTIL.Objetos
{
   public  class ObjetoUsuario
    {
        private int _idUsuario;
        private int _idTipoUsuario;
        private string _nombreUsuario;
        private string _passUsuario;


        public int idUsuario { get => _idUsuario; set => _idUsuario = value; }
        public int idTipoUsuario { get => _idTipoUsuario; set => _idTipoUsuario = value;}
        public string nombreUsuario { get => _nombreUsuario; set => _nombreUsuario = value; }
        public string passUsuario { get => _passUsuario; set => _passUsuario = value; }


    }
}
