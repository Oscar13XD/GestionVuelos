using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVuelos.Model
{
    public class VuelosModel
    {
        public int id { get; set; }
        public string ciudadOrigen { get; set; }
        public string ciudadDestino { get; set; }
        public string fecha { get; set; }
        public string horaSalida { get; set; }
        public string horaLlegada { get; set; }
        public int numeroVuelo { get; set; }
        public string aerolinea { get; set; }
        public string estadoVuelo { get; set; }
    }
}
