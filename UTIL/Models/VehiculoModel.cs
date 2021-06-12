using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTIL.Models
{
    public class VehiculoModel
    {
        public string patente { get; set; }
        public string fk_rutCliente { get; set; }
        public int fk_idTipoVehiculo { get; set; }
        // Añadido nombre del tipo de vehiculo
        public string tipoVehiculo { get; set; }
        public string marca { get; set; }
        public string color { get; set; }
        public string modelo { get; set; }
        public int ano { get; set; }
        public int kilometraje { get; set; }
        public string estado { get; set; }
    }
}
