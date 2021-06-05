using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTIL.Formato
{
    public class FormatoInt
    {
        public static string agregarSeparadorMiles(int? numero, string simboloAntes = "", string simboloDespues = "", string valorDefecto = "")
        {
            if (numero == null)
            {
                return valorDefecto;
            }
            else
            {
                return simboloAntes + ((int)numero).ToString("N0") + simboloDespues;
            }
        }

    }
}
