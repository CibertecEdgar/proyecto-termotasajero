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
        public decimal ContadorAguaServicios { get; set; }
        public decimal ContadorACPM { get; set; }
        public decimal ContadorAguaPotable { get; set; }
        public decimal ContadorAguaDEMI { get; set; }
        public decimal ContadorAguaDescargadorRotatorio { get; set; }
    }
}
