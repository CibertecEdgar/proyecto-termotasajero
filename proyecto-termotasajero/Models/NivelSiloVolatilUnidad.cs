using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto_termotasajero.Models
{
    public class NivelSiloVolatilUnidad
    {
        public int ID { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFinalizacion { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? Nombre { get; set; }
        public string? OperadorTurno { get; set; }
        public decimal NivelSiloVolatilMetros { get; set; }
    }
}