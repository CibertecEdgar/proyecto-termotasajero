using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto_termotasajero.Models
{
    public class ParametrosOperacionCapacitacionAgua
    {
        public int? ID { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Finalizacion { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? Nombre { get; set; }
        public string? OperadorTurno { get; set; }
        public decimal VoltajeBarraBPW_kV { get; set; }
        public decimal Corriente_A { get; set; }
        public string? BBT_A_Estado { get; set; }
        public decimal TempAceiteReductor_A { get; set; }
        public decimal PresAceitePrincipal_A_kgcm2 { get; set; }
        public decimal PresNormalLubricacion_A_kgcm2 { get; set; }
        public decimal PresAguaEnfriamiento_A_kgcm2 { get; set; }
        public decimal TempDevanadosFaseR_A { get; set; }
        public decimal TempDevanadosFaseS_A { get; set; }
        public decimal TempDevanadosFaseT_A { get; set; }
        public string? BBT_B_Estado { get; set; }
        public decimal TempAceiteReductor_B { get; set; }
        public decimal PresAceitePrincipal_B_kgcm2 { get; set; }
        public decimal PresNormalLubricacion_B_kgcm2 { get; set; }
        public decimal PresAguaEnfriamiento_B_kgcm2 { get; set; }
        public decimal TempRodamientoLadoLibre_B { get; set; }
        public decimal TempDevanadosFaseR_B { get; set; }
        public decimal TempDevanadosFaseS_B { get; set; }
        public decimal TempDevanadosFaseT_B { get; set; }
        public decimal TempRodamientoLadoAcople_B { get; set; }
        public string? BBT_C_Estado { get; set; }
        public decimal TempAceiteReductor_C { get; set; }
        public decimal PresAceitePrincipal_C_kgcm2 { get; set; }
        public decimal PresNormalLubricacion_C_kgcm2 { get; set; }
        public decimal PresAguaEnfriamiento_C_kgcm2 { get; set; }
        public decimal TempDevanadosFaseR_C { get; set; }
        public decimal TempDevanadosFaseS_C { get; set; }
        public decimal TempDevanadosFaseT_C { get; set; }
        public string? BbaB_CircuitoCerrado { get; set; }
        public string? BbaA_CircuitoCerrado { get; set; }
        public decimal PresDescargaCabezal_kgcm2 { get; set; }
    }
}