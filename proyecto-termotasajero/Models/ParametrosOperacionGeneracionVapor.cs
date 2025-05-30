using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto_termotasajero.Models
{
    public class ParametrosOperacionGeneracionVapor
    {
        public int ID { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraFinalizacion { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? NombreOperador { get; set; }
        public string? OperadorTurno { get; set; }
        public string? AirePurgaA { get; set; }
        public string? AirePurgaB { get; set; }
        public decimal CorrienteAirePurgaA { get; set; }
        public decimal CorrienteAirePurgaB { get; set; }
        public decimal VTIA_PresionAceiteEntrada { get; set; }
        public decimal VTIA_PresionAceiteSalida { get; set; }
        public decimal VTIA_TempAceiteEntrada { get; set; }
        public decimal VTIA_TempAceiteSalida { get; set; }
        public decimal VTIB_PresionAceiteEntrada { get; set; }
        public decimal VTIB_PresionAceiteSalida { get; set; }
        public decimal VTIB_TempAceiteEntrada { get; set; }
        public decimal VTIB_TempAceiteSalida { get; set; }
        public decimal PresionFluidizadorA { get; set; }
        public decimal PresionFluidizadorB { get; set; }
        public string? SopladorFluidizadorA { get; set; }
        public string? SopladorFluidizadorB { get; set; }
        public string? SopladorTransporteA { get; set; }
        public string? SopladorTransporteB { get; set; }
        public decimal VTFB_PresionEntrada { get; set; }
        public decimal VTFB_PresionSalida { get; set; }
        public decimal VTFB_TempEntrada { get; set; }
        public decimal VTFB_TempSalida { get; set; }
        public decimal VTFA_PresionEntrada { get; set; }
        public decimal VTFA_PresionSalida { get; set; }
        public decimal VTFA_TempEntrada { get; set; }
        public decimal VTFA_TempSalida { get; set; }
        public string? BandaAC1 { get; set; }
        public string? Scrapper { get; set; }
        public decimal PresionAguaLadoA { get; set; }
        public decimal PresionAguaLadoB { get; set; }
        public decimal TempAceiteMolinoD { get; set; }
        public decimal TempAceiteMolinoC { get; set; }
        public decimal TempAceiteMolinoB { get; set; }
        public decimal TempAceiteMolinoA { get; set; }
        public decimal PresionCojineteSoporteA { get; set; }
        public decimal PresionCojineteSoporteB { get; set; }
        public decimal PresionCojineteSoporteC { get; set; }
        public decimal PresionCojineteSoporteD { get; set; }
        public string? LjungstromB { get; set; }
        public string? LjungstromA { get; set; }
        public decimal PresionTk { get; set; }
        public string? Apertura { get; set; }
        public string? VibradorA { get; set; }
        public string? VibradorB { get; set; }
        public string? VibradorC { get; set; }
        public string? ZarandaA { get; set; }
        public string? TrituradorA { get; set; }
        public string? ZarandaB { get; set; }
        public string? TrituradorB { get; set; }
        public string? FluidizadorB { get; set; }
        public string? FluidizadorA { get; set; }
        public string? Observaciones { get; set; }
        public string? TrenSeleccionadoSubirCarbon { get; set; }
        public string? MolinoD_Seleccion { get; set; }
        public string? MolinoC_Seleccion { get; set; }
        public string? MolinoB_Seleccion { get; set; }
        public string? MolinoA_Seleccion { get; set; }
        public string? LjungstromA_Seleccion { get; set; }
        public string? LjungstromB_Seleccion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string? UsuarioCreacion { get; set; }
    }
}
