using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTIL.Models;


namespace BLL
{
    public class ControlTaller
    {
        private FactoryAcceso _Control = new FactoryAcceso();



        public UsuarioModel Login(UsuarioModel usuario)
        {
            return _Control.Login(usuario);
        }

    }
}
