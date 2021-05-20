using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTIL.Objetos;

namespace BLL
{
    public class Control
    {
        private FactoryAcceso _Control = new FactoryAcceso();

        public ObjetoUsuario Login(ObjetoUsuario usuario)
        {
            return _Control.Login(usuario);
        }
    }
}
