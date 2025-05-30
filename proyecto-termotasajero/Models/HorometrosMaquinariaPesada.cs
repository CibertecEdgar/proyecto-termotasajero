using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto_termotasajero.Models
{
    public class HorometrosMaquinariaPesada
    {
        public int ID { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFinalizacion { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? Nombre { get; set; }
        public double HorometroCoaldozer2 { get; set; }
        public double HorometroCoaldozer3 { get; set; }
        public double HorometroCoaldozer4 { get; set; }
        public double HorometroCargador1 { get; set; }
        public double HorometroCargador2 { get; set; }
        public double HorometroClasificadoraCarbon { get; set; }
        public double HorometroRetrocargadorKOMATSU { get; set; }
        public double HorometroMiniCargadorBOBCAT { get; set; }
    }
}
