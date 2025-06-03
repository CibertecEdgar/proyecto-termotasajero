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
        public decimal HorometroCoaldozer2 { get; set; }
        public decimal HorometroCoaldozer3 { get; set; }
        public decimal HorometroCoaldozer4 { get; set; }
        public decimal HorometroCargador1 { get; set; }
        public decimal HorometroCargador2 { get; set; }
        public decimal HorometroClasificadoraCarbon { get; set; }
        public decimal HorometroRetrocargadorKOMATSU { get; set; }
        public decimal HorometroMiniCargadorBOBCAT { get; set; }
    }
}
