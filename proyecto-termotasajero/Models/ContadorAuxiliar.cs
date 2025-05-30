using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto_termotasajero.Models
{
    public class ContadorAuxiliar
    {
        public int ID { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFinalizacion { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? Nombre { get; set; }
        public DateTime FechaDeCorte { get; set; }
        public string? Operador { get; set; }
        public double ContadorAguaServicios { get; set; }
        public double ContadorACPM { get; set; }
        public double ContadorAguaPotable { get; set; }
        public double ContadorAguaDEMI { get; set; }
        public double ContadorAguaDescargadorRotatorio { get; set; }
    }
}
