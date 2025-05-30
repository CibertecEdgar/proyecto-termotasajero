using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto_termotasajero.Models
{
    public class ParametrosOperacionCirculacionAgua
    {
        public int ID { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Finalizacion { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? Nombre { get; set; }
        public string? OperadorTurno { get; set; }
        public string? BAC_B_Estado { get; set; }
        public string? BAC_A_Estado { get; set; }
        public string? BAC_C_Estado { get; set; }
        public decimal PI308_A_Presion { get; set; }
        public decimal PI308_B_Presion { get; set; }
        public decimal PI308_C_Presion { get; set; }
        public decimal FiltroLubricacion_Antes { get; set; }
        public decimal FiltroLubricacion_Despues { get; set; }
        public decimal FS212A_Flujo { get; set; }
        public decimal FS212B_Flujo { get; set; }
        public decimal FS212C_Flujo { get; set; }
        public string? BbaRiegoPatio_A_Estado { get; set; }
        public string? BbaRiegoPatio_B_Estado { get; set; }
        public decimal PresionRiegoPatio_A { get; set; }
        public decimal PresionRiegoPatio_B { get; set; }
        public string? LavadoTamiz_A_Estado { get; set; }
        public string? LavadoTamiz_B_Estado { get; set; }
        public string? LavadoTamiz_C_Estado { get; set; }
        public decimal PresionBbaTamiz_A { get; set; }
        public decimal PresionBbaTamiz_B { get; set; }
        public decimal PresionBbaTamiz_C { get; set; }
        public string? BbaAguaCruda_A_Estado { get; set; }
        public string? BbaAguaCruda_B_Estado { get; set; }
        public decimal PresionCruda_A { get; set; }
        public decimal PresionCruda_B { get; set; }
        public string? BbaLavadoCeniza_B_Estado { get; set; }
        public string? BbaLavadoCeniza_A_Estado { get; set; }
        public decimal PresionCeniza_A { get; set; }
        public decimal PresionCeniza_B { get; set; }
        public string? BbaLubric_A_Estado { get; set; }
        public string? BbaLubric_B_Estado { get; set; }
        public decimal PresionLubric_A { get; set; }
        public decimal PresionLubric_B { get; set; }
        public string? BombaEnfriamientoAlterno_Estado { get; set; }
        public decimal PresionEnfriamientoAlterno { get; set; }
        public decimal VoltajeBAT1 { get; set; }
        public decimal CorrienteBAT1 { get; set; }
        public decimal VoltajeBAT2 { get; set; }
        public decimal CorrienteBAT2 { get; set; }
        public decimal PresionTkPulmon { get; set; }
        public decimal PresionCompresor_A { get; set; }
        public decimal PresionCompresor_B { get; set; }
    }
}
