using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;

namespace proyecto_termotasajero.Controllers
{
    public class ParametrosOperacionTurboGeneracionController : Controller
    {
        private readonly ILogger<ParametrosOperacionTurboGeneracionController> _logger;
        private readonly string? _connectionString;

        public ParametrosOperacionTurboGeneracionController(ILogger<ParametrosOperacionTurboGeneracionController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _connectionString = configuration.GetConnectionString("sqlConUser");
        }

        // Listar registros
        [HttpGet]
        public IActionResult Index()
        {
            _logger.LogInformation("Entrando a Index de ParametrosOperacionTurboGeneracionController");
            var lista = new List<proyecto_termotasajero.Models.ParametrosOperacionTurboGeneracion>();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    // Usar el stored procedure para listar
                    var cmd = new SqlCommand("Sp_ListarParametrosOperacionTurbogeneracion", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var item = new proyecto_termotasajero.Models.ParametrosOperacionTurboGeneracion();
                            item.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                            item.FechaHoraInicio = reader.GetDateTime(reader.GetOrdinal("FechaHoraInicio"));
                            item.FechaHoraFinalizacion = reader.GetDateTime(reader.GetOrdinal("FechaHoraFinalizacion"));
                            item.CorreoElectronico = reader.IsDBNull(reader.GetOrdinal("CorreoElectronico")) ? null : reader.GetString(reader.GetOrdinal("CorreoElectronico"));
                            item.NombreOperador = reader.IsDBNull(reader.GetOrdinal("NombreOperador")) ? null : reader.GetString(reader.GetOrdinal("NombreOperador"));
                            item.OperadorTurno = reader.IsDBNull(reader.GetOrdinal("OperadorTurno")) ? null : reader.GetString(reader.GetOrdinal("OperadorTurno"));
                            item.EnfriadorAguaAguaA = reader.IsDBNull(reader.GetOrdinal("EnfriadorAguaAguaA")) ? null : reader.GetString(reader.GetOrdinal("EnfriadorAguaAguaA"));
                            item.EnfriadorAguaAguaB = reader.IsDBNull(reader.GetOrdinal("EnfriadorAguaAguaB")) ? null : reader.GetString(reader.GetOrdinal("EnfriadorAguaAguaB"));
                            item.BombaReforzadoraA = reader.IsDBNull(reader.GetOrdinal("BombaReforzadoraA")) ? null : reader.GetString(reader.GetOrdinal("BombaReforzadoraA"));
                            item.BombaReforzadoraB = reader.IsDBNull(reader.GetOrdinal("BombaReforzadoraB")) ? null : reader.GetString(reader.GetOrdinal("BombaReforzadoraB"));
                            item.TempEntradaCircuitoCerrado = reader.GetDecimal(reader.GetOrdinal("TempEntradaCircuitoCerrado"));
                            item.TempSalidaCircuitoAbierto = reader.GetDecimal(reader.GetOrdinal("TempSalidaCircuitoAbierto"));
                            item.PresionDescargaReforzadoraA = reader.GetDecimal(reader.GetOrdinal("PresionDescargaReforzadoraA"));
                            item.PresionDescargaReforzadoraB = reader.GetDecimal(reader.GetOrdinal("PresionDescargaReforzadoraB"));
                            item.DeltaPFiltroBombasReforzadoras = reader.GetDecimal(reader.GetOrdinal("DeltaPFiltroBombasReforzadoras"));
                            item.BbaSelloLadoH2 = reader.IsDBNull(reader.GetOrdinal("BbaSelloLadoH2")) ? null : reader.GetString(reader.GetOrdinal("BbaSelloLadoH2"));
                            item.BbaSelloLadoAire = reader.IsDBNull(reader.GetOrdinal("BbaSelloLadoAire")) ? null : reader.GetString(reader.GetOrdinal("BbaSelloLadoAire"));
                            item.BbaSelloEmergencia = reader.IsDBNull(reader.GetOrdinal("BbaSelloEmergencia")) ? null : reader.GetString(reader.GetOrdinal("BbaSelloEmergencia"));
                            item.BbaSelloFlotante = reader.IsDBNull(reader.GetOrdinal("BbaSelloFlotante")) ? null : reader.GetString(reader.GetOrdinal("BbaSelloFlotante"));
                            item.ExtractorTanqueBucle = reader.IsDBNull(reader.GetOrdinal("ExtractorTanqueBucle")) ? null : reader.GetString(reader.GetOrdinal("ExtractorTanqueBucle"));
                            item.PresionRefuerzo = reader.GetDecimal(reader.GetOrdinal("PresionRefuerzo"));
                            item.PresionAceiteLadoH2 = reader.GetDecimal(reader.GetOrdinal("PresionAceiteLadoH2"));
                            item.PresionAceiteLadoAire = reader.GetDecimal(reader.GetOrdinal("PresionAceiteLadoAire"));
                            item.TemperaturaAceiteLadoH2 = reader.GetDecimal(reader.GetOrdinal("TemperaturaAceiteLadoH2"));
                            item.TemperaturaAceiteLadoAire = reader.GetDecimal(reader.GetOrdinal("TemperaturaAceiteLadoAire"));
                            item.EstadoSecadorH2 = reader.IsDBNull(reader.GetOrdinal("EstadoSecadorH2")) ? null : reader.GetString(reader.GetOrdinal("EstadoSecadorH2"));
                            item.DewPointEntrada = reader.GetDecimal(reader.GetOrdinal("DewPointEntrada"));
                            item.DewPointSalida = reader.GetDecimal(reader.GetOrdinal("DewPointSalida"));
                            item.VlaControlNivelCalentadorBP1CV221 = reader.GetDecimal(reader.GetOrdinal("VlaControlNivelCalentadorBP1CV221"));
                            item.BbaVacioA = reader.IsDBNull(reader.GetOrdinal("BbaVacioA")) ? null : reader.GetString(reader.GetOrdinal("BbaVacioA"));
                            item.BbaVacioB = reader.IsDBNull(reader.GetOrdinal("BbaVacioB")) ? null : reader.GetString(reader.GetOrdinal("BbaVacioB"));
                            item.PresionSuccionBbaVacioA = reader.GetDecimal(reader.GetOrdinal("PresionSuccionBbaVacioA"));
                            item.PresionAguaSelloBbaVacioB = reader.GetDecimal(reader.GetOrdinal("PresionAguaSelloBbaVacioB"));
                            item.EnfriadorA = reader.IsDBNull(reader.GetOrdinal("EnfriadorA")) ? null : reader.GetString(reader.GetOrdinal("EnfriadorA"));
                            item.EnfriadorB = reader.IsDBNull(reader.GetOrdinal("EnfriadorB")) ? null : reader.GetString(reader.GetOrdinal("EnfriadorB"));
                            item.TemperaturaSalidaAgua = reader.GetDecimal(reader.GetOrdinal("TemperaturaSalidaAgua"));
                            item.AperturaValvulaControl = reader.GetDecimal(reader.GetOrdinal("AperturaValvulaControl"));
                            item.ExtraccionA = reader.IsDBNull(reader.GetOrdinal("ExtraccionA")) ? null : reader.GetString(reader.GetOrdinal("ExtraccionA"));
                            item.ExtraccionB = reader.IsDBNull(reader.GetOrdinal("ExtraccionB")) ? null : reader.GetString(reader.GetOrdinal("ExtraccionB"));
                            item.PresionSuccionExtraccionAireA = reader.GetDecimal(reader.GetOrdinal("PresionSuccionExtraccionAireA"));
                            item.PresionSuccionExtraccionAireB = reader.GetDecimal(reader.GetOrdinal("PresionSuccionExtraccionAireB"));
                            item.PurificadorAceite = reader.IsDBNull(reader.GetOrdinal("PurificadorAceite")) ? null : reader.GetString(reader.GetOrdinal("PurificadorAceite"));
                            item.PresionTkAceiteTurbina = reader.GetDecimal(reader.GetOrdinal("PresionTkAceiteTurbina"));
                            item.NivelTkAceiteTurbina = reader.GetDecimal(reader.GetOrdinal("NivelTkAceiteTurbina"));
                            item.CargadorA220Vdc = reader.IsDBNull(reader.GetOrdinal("CargadorA220Vdc")) ? null : reader.GetString(reader.GetOrdinal("CargadorA220Vdc"));
                            item.CargadorB220Vdc = reader.IsDBNull(reader.GetOrdinal("CargadorB220Vdc")) ? null : reader.GetString(reader.GetOrdinal("CargadorB220Vdc"));
                            item.CargadorA125Vdc = reader.IsDBNull(reader.GetOrdinal("CargadorA125Vdc")) ? null : reader.GetString(reader.GetOrdinal("CargadorA125Vdc"));
                            item.CargadorB125Vdc = reader.IsDBNull(reader.GetOrdinal("CargadorB125Vdc")) ? null : reader.GetString(reader.GetOrdinal("CargadorB125Vdc"));
                            item.CargadorA24Vdc = reader.IsDBNull(reader.GetOrdinal("CargadorA24Vdc")) ? null : reader.GetString(reader.GetOrdinal("CargadorA24Vdc"));
                            item.CargadorB24Vdc = reader.IsDBNull(reader.GetOrdinal("CargadorB24Vdc")) ? null : reader.GetString(reader.GetOrdinal("CargadorB24Vdc"));
                            item.CorrienteCargador220ES = reader.GetDecimal(reader.GetOrdinal("CorrienteCargador220ES"));
                            item.CorrienteCargador124ES = reader.GetDecimal(reader.GetOrdinal("CorrienteCargador124ES"));
                            item.CorrienteCargador24ES = reader.GetDecimal(reader.GetOrdinal("CorrienteCargador24ES"));
                            item.BAAC_Estado = reader.IsDBNull(reader.GetOrdinal("BAAC_Estado")) ? null : reader.GetString(reader.GetOrdinal("BAAC_Estado"));
                            item.BAAC_TempRetornoAceiteRodamientoLadoInterior = reader.GetDecimal(reader.GetOrdinal("BAAC_TempRetornoAceiteRodamientoLadoInterior"));
                            item.BAAC_TempRetornoAceiteRodamientoLadoExterior = reader.GetDecimal(reader.GetOrdinal("BAAC_TempRetornoAceiteRodamientoLadoExterior"));
                            item.BAAC_TempAguaSelloLadoInterior = reader.GetDecimal(reader.GetOrdinal("BAAC_TempAguaSelloLadoInterior"));
                            item.BAAC_TempAguaSelloLadoExterior = reader.GetDecimal(reader.GetOrdinal("BAAC_TempAguaSelloLadoExterior"));
                            item.BAAC_PresionAceiteRodamientoLadoInterior = reader.GetDecimal(reader.GetOrdinal("BAAC_PresionAceiteRodamientoLadoInterior"));
                            item.BAAC_PresionAceiteRodamientoLadoExterior = reader.GetDecimal(reader.GetOrdinal("BAAC_PresionAceiteRodamientoLadoExterior"));
                            item.BAAC_PresionEntradaAguaSello = reader.GetDecimal(reader.GetOrdinal("BAAC_PresionEntradaAguaSello"));
                            item.BAAC_PresionDiferencialFiltroAguaSello = reader.GetDecimal(reader.GetOrdinal("BAAC_PresionDiferencialFiltroAguaSello"));
                            item.BAAC_PresionDiferencialFiltroSuccion = reader.GetDecimal(reader.GetOrdinal("BAAC_PresionDiferencialFiltroSuccion"));
                            item.BAAC_AperturaAguaSelloLadoInterior = reader.GetDecimal(reader.GetOrdinal("BAAC_AperturaAguaSelloLadoInterior"));
                            item.BAAC_AperturaAguaSelloLadoExterior = reader.GetDecimal(reader.GetOrdinal("BAAC_AperturaAguaSelloLadoExterior"));
                            item.AcopleBAAC_TempMetalRadial1 = reader.GetDecimal(reader.GetOrdinal("AcopleBAAC_TempMetalRadial1"));
                            item.AcopleBAAC_TempMetalRadial2 = reader.GetDecimal(reader.GetOrdinal("AcopleBAAC_TempMetalRadial2"));
                            item.AcopleBAAC_TempMetalRadial3 = reader.GetDecimal(reader.GetOrdinal("AcopleBAAC_TempMetalRadial3"));
                            item.AcopleBAAC_TempMetalRadial4 = reader.GetDecimal(reader.GetOrdinal("AcopleBAAC_TempMetalRadial4"));
                            item.AcopleBAAC_TempMetalRadial5 = reader.GetDecimal(reader.GetOrdinal("AcopleBAAC_TempMetalRadial5"));
                            item.AcopleBAAC_TempMetalRadial6 = reader.GetDecimal(reader.GetOrdinal("AcopleBAAC_TempMetalRadial6"));
                            item.AcopleBAAC_TempAceiteTrabajoEntradaEnfriador = reader.GetDecimal(reader.GetOrdinal("AcopleBAAC_TempAceiteTrabajoEntradaEnfriador"));
                            item.AcopleBAAC_PresionAceiteLubricacion = reader.GetDecimal(reader.GetOrdinal("AcopleBAAC_PresionAceiteLubricacion"));
                            item.AcopleBAAC_PresionDiferencialFiltroAceite = reader.GetDecimal(reader.GetOrdinal("AcopleBAAC_PresionDiferencialFiltroAceite"));
                            item.AcopleBAAC_TempAceiteLubricacionEntradaEnfriador = reader.GetDecimal(reader.GetOrdinal("AcopleBAAC_TempAceiteLubricacionEntradaEnfriador"));
                            item.AcopleBAAC_TempAceiteLubricacionSalidaEnfriador = reader.GetDecimal(reader.GetOrdinal("AcopleBAAC_TempAceiteLubricacionSalidaEnfriador"));
                            item.AcopleBAAC_TempAceiteTrabajoSalidaEnfriador = reader.GetDecimal(reader.GetOrdinal("AcopleBAAC_TempAceiteTrabajoSalidaEnfriador"));
                            item.BAAB_Estado = reader.IsDBNull(reader.GetOrdinal("BAAB_Estado")) ? null : reader.GetString(reader.GetOrdinal("BAAB_Estado"));
                            item.BAAB_TempRetornoAceiteRodamientoLadoInterior = reader.GetDecimal(reader.GetOrdinal("BAAB_TempRetornoAceiteRodamientoLadoInterior"));
                            item.BAAB_TempRetornoAceiteRodamientoLadoExterior = reader.GetDecimal(reader.GetOrdinal("BAAB_TempRetornoAceiteRodamientoLadoExterior"));
                            item.BAAB_TempAguaSelloLadoInterior = reader.GetDecimal(reader.GetOrdinal("BAAB_TempAguaSelloLadoInterior"));
                            item.BAAB_TempAguaSelloLadoExterior = reader.GetDecimal(reader.GetOrdinal("BAAB_TempAguaSelloLadoExterior"));
                            item.BAAB_PresionAceiteRodamientoLadoInterior = reader.GetDecimal(reader.GetOrdinal("BAAB_PresionAceiteRodamientoLadoInterior"));
                            item.BAAB_PresionAceiteRodamientoLadoExterior = reader.GetDecimal(reader.GetOrdinal("BAAB_PresionAceiteRodamientoLadoExterior"));
                            item.BAAB_PresionEntradaAguaSello = reader.GetDecimal(reader.GetOrdinal("BAAB_PresionEntradaAguaSello"));
                            item.BAAB_PresionDiferencialFiltroAguaSello = reader.GetDecimal(reader.GetOrdinal("BAAB_PresionDiferencialFiltroAguaSello"));
                            item.BAAB_PresionDiferencialFiltroSuccion = reader.GetDecimal(reader.GetOrdinal("BAAB_PresionDiferencialFiltroSuccion"));
                            item.BAAB_AperturaAguaSelloLadoInterior = reader.GetDecimal(reader.GetOrdinal("BAAB_AperturaAguaSelloLadoInterior"));
                            item.BAAB_AperturaAguaSelloLadoExterior = reader.GetDecimal(reader.GetOrdinal("BAAB_AperturaAguaSelloLadoExterior"));
                            item.AcopleBAAB_TempMetalRadial1 = reader.GetDecimal(reader.GetOrdinal("AcopleBAAB_TempMetalRadial1"));
                            item.AcopleBAAB_TempMetalRadial2 = reader.GetDecimal(reader.GetOrdinal("AcopleBAAB_TempMetalRadial2"));
                            item.AcopleBAAB_TempMetalRadial3 = reader.GetDecimal(reader.GetOrdinal("AcopleBAAB_TempMetalRadial3"));
                            item.AcopleBAAB_TempMetalRadial4 = reader.GetDecimal(reader.GetOrdinal("AcopleBAAB_TempMetalRadial4"));
                            item.AcopleBAAB_TempMetalRadial5 = reader.GetDecimal(reader.GetOrdinal("AcopleBAAB_TempMetalRadial5"));
                            item.AcopleBAAB_TempMetalRadial6 = reader.GetDecimal(reader.GetOrdinal("AcopleBAAB_TempMetalRadial6"));
                            item.AcopleBAAB_TempAceiteTrabajoEntradaEnfriador = reader.GetDecimal(reader.GetOrdinal("AcopleBAAB_TempAceiteTrabajoEntradaEnfriador"));
                            item.AcopleBAAB_PresionAceiteLubricacion = reader.GetDecimal(reader.GetOrdinal("AcopleBAAB_PresionAceiteLubricacion"));
                            item.AcopleBAAB_PresionDiferencialFiltroAceite = reader.GetDecimal(reader.GetOrdinal("AcopleBAAB_PresionDiferencialFiltroAceite"));
                            item.AcopleBAAB_TempAceiteLubricacionEntradaEnfriador = reader.GetDecimal(reader.GetOrdinal("AcopleBAAB_TempAceiteLubricacionEntradaEnfriador"));
                            item.AcopleBAAB_TempAceiteLubricacionSalidaEnfriador = reader.GetDecimal(reader.GetOrdinal("AcopleBAAB_TempAceiteLubricacionSalidaEnfriador"));
                            item.AcopleBAAB_TempAceiteTrabajoSalidaEnfriador = reader.GetDecimal(reader.GetOrdinal("AcopleBAAB_TempAceiteTrabajoSalidaEnfriador"));
                            item.BAAA_Estado = reader.IsDBNull(reader.GetOrdinal("BAAA_Estado")) ? null : reader.GetString(reader.GetOrdinal("BAAA_Estado"));
                            item.BAAA_TempRetornoAceiteRodamientoLadoInterior = reader.GetDecimal(reader.GetOrdinal("BAAA_TempRetornoAceiteRodamientoLadoInterior"));
                            item.BAAA_TempRetornoAceiteRodamientoLadoExterior = reader.GetDecimal(reader.GetOrdinal("BAAA_TempRetornoAceiteRodamientoLadoExterior"));
                            item.BAAA_TempAguaSelloLadoInterior = reader.GetDecimal(reader.GetOrdinal("BAAA_TempAguaSelloLadoInterior"));
                            item.BAAA_TempAguaSelloLadoExterior = reader.GetDecimal(reader.GetOrdinal("BAAA_TempAguaSelloLadoExterior"));
                            item.BAAA_PresionAceiteRodamientoLadoInterior = reader.GetDecimal(reader.GetOrdinal("BAAA_PresionAceiteRodamientoLadoInterior"));
                            item.BAAA_PresionAceiteRodamientoLadoExterior = reader.GetDecimal(reader.GetOrdinal("BAAA_PresionAceiteRodamientoLadoExterior"));
                            item.BAAA_PresionEntradaAguaSello = reader.GetDecimal(reader.GetOrdinal("BAAA_PresionEntradaAguaSello"));
                            item.BAAA_PresionDiferencialFiltroAguaSello = reader.GetDecimal(reader.GetOrdinal("BAAA_PresionDiferencialFiltroAguaSello"));
                            item.BAAA_PresionDiferencialFiltroSuccion = reader.GetDecimal(reader.GetOrdinal("BAAA_PresionDiferencialFiltroSuccion"));
                            item.BAAA_AperturaAguaSelloLadoInterior = reader.GetDecimal(reader.GetOrdinal("BAAA_AperturaAguaSelloLadoInterior"));
                            item.BAAA_AperturaAguaSelloLadoExterior = reader.GetDecimal(reader.GetOrdinal("BAAA_AperturaAguaSelloLadoExterior"));
                            item.AcopleBAAA_TempMetalRadial1 = reader.GetDecimal(reader.GetOrdinal("AcopleBAAA_TempMetalRadial1"));
                            item.AcopleBAAA_TempMetalRadial2 = reader.GetDecimal(reader.GetOrdinal("AcopleBAAA_TempMetalRadial2"));
                            item.AcopleBAAA_TempMetalRadial3 = reader.GetDecimal(reader.GetOrdinal("AcopleBAAA_TempMetalRadial3"));
                            item.AcopleBAAA_TempMetalRadial4 = reader.GetDecimal(reader.GetOrdinal("AcopleBAAA_TempMetalRadial4"));
                            item.AcopleBAAA_TempMetalRadial5 = reader.GetDecimal(reader.GetOrdinal("AcopleBAAA_TempMetalRadial5"));
                            item.AcopleBAAA_TempMetalRadial6 = reader.GetDecimal(reader.GetOrdinal("AcopleBAAA_TempMetalRadial6"));
                            item.AcopleBAAA_TempAceiteTrabajoEntradaEnfriador = reader.GetDecimal(reader.GetOrdinal("AcopleBAAA_TempAceiteTrabajoEntradaEnfriador"));
                            item.AcopleBAAA_PresionAceiteLubricacion = reader.GetDecimal(reader.GetOrdinal("AcopleBAAA_PresionAceiteLubricacion"));
                            item.AcopleBAAA_PresionDiferencialFiltroAceite = reader.GetDecimal(reader.GetOrdinal("AcopleBAAA_PresionDiferencialFiltroAceite"));
                            item.AcopleBAAA_TempAceiteLubricacionEntradaEnfriador = reader.GetDecimal(reader.GetOrdinal("AcopleBAAA_TempAceiteLubricacionEntradaEnfriador"));
                            item.AcopleBAAA_TempAceiteLubricacionSalidaEnfriador = reader.GetDecimal(reader.GetOrdinal("AcopleBAAA_TempAceiteLubricacionSalidaEnfriador"));
                            item.AcopleBAAA_TempAceiteTrabajoSalidaEnfriador = reader.GetDecimal(reader.GetOrdinal("AcopleBAAA_TempAceiteTrabajoSalidaEnfriador"));
                            item.SecadorAireA = reader.IsDBNull(reader.GetOrdinal("SecadorAireA")) ? null : reader.GetString(reader.GetOrdinal("SecadorAireA"));
                            item.SecadorAireB = reader.IsDBNull(reader.GetOrdinal("SecadorAireB")) ? null : reader.GetString(reader.GetOrdinal("SecadorAireB"));
                            item.TempDewPointSecadorA = reader.GetDecimal(reader.GetOrdinal("TempDewPointSecadorA"));
                            item.TempDewPointSecadorB = reader.GetDecimal(reader.GetOrdinal("TempDewPointSecadorB"));
                            item.CompresorC_Estado = reader.IsDBNull(reader.GetOrdinal("CompresorC_Estado")) ? null : reader.GetString(reader.GetOrdinal("CompresorC_Estado"));
                            item.CompresorC_TempT1Descarga = reader.GetDecimal(reader.GetOrdinal("CompresorC_TempT1Descarga"));
                            item.CompresorC_TempT2LadoSeco = reader.GetDecimal(reader.GetOrdinal("CompresorC_TempT2LadoSeco"));
                            item.CompresorC_PresionP1Carter = reader.GetDecimal(reader.GetOrdinal("CompresorC_PresionP1Carter"));
                            item.CompresorC_PresionP2Linea = reader.GetDecimal(reader.GetOrdinal("CompresorC_PresionP2Linea"));
                            item.CompresorC_PresionP4Aceite = reader.GetDecimal(reader.GetOrdinal("CompresorC_PresionP4Aceite"));
                            item.CompresorC_PresionDP1Separador = reader.GetDecimal(reader.GetOrdinal("CompresorC_PresionDP1Separador"));
                            item.CompresorC_PresionDP2FiltroAceite = reader.GetDecimal(reader.GetOrdinal("CompresorC_PresionDP2FiltroAceite"));
                            item.CompresorC_PresionDP3Aceite = reader.GetDecimal(reader.GetOrdinal("CompresorC_PresionDP3Aceite"));
                            item.CompresorA_Estado = reader.IsDBNull(reader.GetOrdinal("CompresorA_Estado")) ? null : reader.GetString(reader.GetOrdinal("CompresorA_Estado"));
                            item.CompresorA_PresionDescargaConjunto = reader.GetDecimal(reader.GetOrdinal("CompresorA_PresionDescargaConjunto"));
                            item.CompresorA_TempDescargaConjunto = reader.GetDecimal(reader.GetOrdinal("CompresorA_TempDescargaConjunto"));
                            item.CompresorA_TempDescargaFase1 = reader.GetDecimal(reader.GetOrdinal("CompresorA_TempDescargaFase1"));
                            item.CompresorA_PresionEntradaFase2 = reader.GetDecimal(reader.GetOrdinal("CompresorA_PresionEntradaFase2"));
                            item.CompresorA_TempEntradaFase2 = reader.GetDecimal(reader.GetOrdinal("CompresorA_TempEntradaFase2"));
                            item.CompresorA_PresionDescargaFase2 = reader.GetDecimal(reader.GetOrdinal("CompresorA_PresionDescargaFase2"));
                            item.CompresorA_TempDescargaFase2 = reader.GetDecimal(reader.GetOrdinal("CompresorA_TempDescargaFase2"));
                            item.CompresorA_TempAceiteRodamientos = reader.GetDecimal(reader.GetOrdinal("CompresorA_TempAceiteRodamientos"));
                            item.CompresorA_PresionAceiteRodamientos = reader.GetDecimal(reader.GetOrdinal("CompresorA_PresionAceiteRodamientos"));
                            item.CompresorA_VacioEntrada = reader.GetDecimal(reader.GetOrdinal("CompresorA_VacioEntrada"));
                            item.CompresorA_CaidaPresionFiltroAceite = reader.GetDecimal(reader.GetOrdinal("CompresorA_CaidaPresionFiltroAceite"));
                            item.CompresorB_Estado = reader.IsDBNull(reader.GetOrdinal("CompresorB_Estado")) ? null : reader.GetString(reader.GetOrdinal("CompresorB_Estado"));
                            item.CompresorB_TempDescargaUnidad = reader.GetDecimal(reader.GetOrdinal("CompresorB_TempDescargaUnidad"));
                            item.CompresorB_Temp1aFase = reader.GetDecimal(reader.GetOrdinal("CompresorB_Temp1aFase"));
                            item.CompresorB_PresionAdmision2aFase = reader.GetDecimal(reader.GetOrdinal("CompresorB_PresionAdmision2aFase"));
                            item.CompresorB_TempAdmision2aFase = reader.GetDecimal(reader.GetOrdinal("CompresorB_TempAdmision2aFase"));
                            item.CompresorB_PresionDescarga2aFase = reader.GetDecimal(reader.GetOrdinal("CompresorB_PresionDescarga2aFase"));
                            item.CompresorB_TempDescarga2aFase = reader.GetDecimal(reader.GetOrdinal("CompresorB_TempDescarga2aFase"));
                            item.CompresorB_PresionAceiteCojinetes = reader.GetDecimal(reader.GetOrdinal("CompresorB_PresionAceiteCojinetes"));
                            item.CompresorB_TempAceiteCojinetes = reader.GetDecimal(reader.GetOrdinal("CompresorB_TempAceiteCojinetes"));
                            item.CompresorB_VacioEntrada = reader.GetDecimal(reader.GetOrdinal("CompresorB_VacioEntrada"));
                            item.CompresorB_EstadoFiltroEntrada = reader.IsDBNull(reader.GetOrdinal("CompresorB_EstadoFiltroEntrada")) ? null : reader.GetString(reader.GetOrdinal("CompresorB_EstadoFiltroEntrada"));
                            item.CompresorB_CaidaPresionFiltroAceite = reader.GetDecimal(reader.GetOrdinal("CompresorB_CaidaPresionFiltroAceite"));
                            item.VlaControlNivelCalentadorBP2CV223 = reader.GetDecimal(reader.GetOrdinal("VlaControlNivelCalentadorBP2CV223"));
                            item.CorrienteCompresorB = reader.GetDecimal(reader.GetOrdinal("CorrienteCompresorB"));
                            item.CorrienteCompresorC = reader.GetDecimal(reader.GetOrdinal("CorrienteCompresorC"));
                            item.CorrienteCompresorA = reader.GetDecimal(reader.GetOrdinal("CorrienteCompresorA"));
                            item.VlaControlNivelCalentadorBP3CV224 = reader.GetDecimal(reader.GetOrdinal("VlaControlNivelCalentadorBP3CV224"));
                            item.PI255_PresionAceiteAltaPresion = reader.GetDecimal(reader.GetOrdinal("PI255_PresionAceiteAltaPresion"));
                            item.PI257_PresionAceiteDescargaBombaPrincipal = reader.GetDecimal(reader.GetOrdinal("PI257_PresionAceiteDescargaBombaPrincipal"));
                            item.PI329_PresionSelloExtremoTurbina = reader.GetDecimal(reader.GetOrdinal("PI329_PresionSelloExtremoTurbina"));
                            item.PI328_PresionSelloExtremoGenerador = reader.GetDecimal(reader.GetOrdinal("PI328_PresionSelloExtremoGenerador"));
                            item.ExtractorTkBucle = reader.IsDBNull(reader.GetOrdinal("ExtractorTkBucle")) ? null : reader.GetString(reader.GetOrdinal("ExtractorTkBucle"));
                            item.PresionSuccionExtractorTkBucle = reader.GetDecimal(reader.GetOrdinal("PresionSuccionExtractorTkBucle"));
                            item.PI230_PresionVaporSelloBP = reader.GetDecimal(reader.GetOrdinal("PI230_PresionVaporSelloBP"));
                            item.PI238_PresionVaporSalidaCamaraIntermedia = reader.GetDecimal(reader.GetOrdinal("PI238_PresionVaporSalidaCamaraIntermedia"));
                            item.VlaControlNivelCalentadorAP5CV226 = reader.GetDecimal(reader.GetOrdinal("VlaControlNivelCalentadorAP5CV226"));
                            item.VlaControlNivelCalentadorAP6CV227 = reader.GetDecimal(reader.GetOrdinal("VlaControlNivelCalentadorAP6CV227"));
                            item.Observaciones = reader.IsDBNull(reader.GetOrdinal("Observaciones")) ? null : reader.GetString(reader.GetOrdinal("Observaciones"));
                            item.BombaFosfatoDomoA = reader.IsDBNull(reader.GetOrdinal("BombaFosfatoDomoA")) ? null : reader.GetString(reader.GetOrdinal("BombaFosfatoDomoA"));
                            item.BombaFosfatoDomoB = reader.IsDBNull(reader.GetOrdinal("BombaFosfatoDomoB")) ? null : reader.GetString(reader.GetOrdinal("BombaFosfatoDomoB"));
                            item.BombaHidracinaCicloA = reader.IsDBNull(reader.GetOrdinal("BombaHidracinaCicloA")) ? null : reader.GetString(reader.GetOrdinal("BombaHidracinaCicloA"));
                            item.BombaHidracinaCicloB = reader.IsDBNull(reader.GetOrdinal("BombaHidracinaCicloB")) ? null : reader.GetString(reader.GetOrdinal("BombaHidracinaCicloB"));
                            item.BombaHidracinaCtoCerradoA = reader.IsDBNull(reader.GetOrdinal("BombaHidracinaCtoCerradoA")) ? null : reader.GetString(reader.GetOrdinal("BombaHidracinaCtoCerradoA"));
                            item.BombaHidracinaCtoCerradoB = reader.IsDBNull(reader.GetOrdinal("BombaHidracinaCtoCerradoB")) ? null : reader.GetString(reader.GetOrdinal("BombaHidracinaCtoCerradoB"));
                            lista.Add(item);
                        }
                    }
                }
                _logger.LogInformation($"Se listaron {lista.Count} registros de ParametrosOperacionTurboGeneracion");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al listar registros en Index de ParametrosOperacionTurboGeneracionController");
                return View("Error!");
            }
            return View(lista);
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            _logger.LogInformation("Entrando a Registrar (GET) de ParametrosOperacionTurboGeneracionController");
            return View("Registrar");
        }

        [HttpPost]
        public IActionResult Registrar(proyecto_termotasajero.Models.ParametrosOperacionTurboGeneracion modelo)
        {
            _logger.LogInformation("Entrando a Registrar (POST) de ParametrosOperacionTurboGeneracionController");
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("ModelState inválido en Registrar (POST) de ParametrosOperacionTurboGeneracionController");
                return View("Index", modelo);
            }
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    var cmd = new SqlCommand("Sp_InsertParametrosOperacionTurbogeneracion", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FechaHoraInicio", modelo.FechaHoraInicio);
                    cmd.Parameters.AddWithValue("@FechaHoraFinalizacion", modelo.FechaHoraFinalizacion);
                    cmd.Parameters.AddWithValue("@CorreoElectronico", (object?)modelo.CorreoElectronico ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@NombreOperador", (object?)modelo.NombreOperador ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@OperadorTurno", (object?)modelo.OperadorTurno ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@EnfriadorAguaAguaA", (object?)modelo.EnfriadorAguaAguaA ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@EnfriadorAguaAguaB", (object?)modelo.EnfriadorAguaAguaB ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BombaReforzadoraA", (object?)modelo.BombaReforzadoraA ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BombaReforzadoraB", (object?)modelo.BombaReforzadoraB ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TempEntradaCircuitoCerrado", modelo.TempEntradaCircuitoCerrado);
                    cmd.Parameters.AddWithValue("@TempSalidaCircuitoAbierto", modelo.TempSalidaCircuitoAbierto);
                    cmd.Parameters.AddWithValue("@PresionDescargaReforzadoraA", modelo.PresionDescargaReforzadoraA);
                    cmd.Parameters.AddWithValue("@PresionDescargaReforzadoraB", modelo.PresionDescargaReforzadoraB);
                    cmd.Parameters.AddWithValue("@DeltaPFiltroBombasReforzadoras", modelo.DeltaPFiltroBombasReforzadoras);
                    cmd.Parameters.AddWithValue("@BbaSelloLadoH2", (object?)modelo.BbaSelloLadoH2 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BbaSelloLadoAire", (object?)modelo.BbaSelloLadoAire ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BbaSelloEmergencia", (object?)modelo.BbaSelloEmergencia ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BbaSelloFlotante", (object?)modelo.BbaSelloFlotante ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ExtractorTanqueBucle", (object?)modelo.ExtractorTanqueBucle ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PresionRefuerzo", modelo.PresionRefuerzo);
                    cmd.Parameters.AddWithValue("@PresionAceiteLadoH2", modelo.PresionAceiteLadoH2);
                    cmd.Parameters.AddWithValue("@PresionAceiteLadoAire", modelo.PresionAceiteLadoAire);
                    cmd.Parameters.AddWithValue("@TemperaturaAceiteLadoH2", modelo.TemperaturaAceiteLadoH2);
                    cmd.Parameters.AddWithValue("@TemperaturaAceiteLadoAire", modelo.TemperaturaAceiteLadoAire);
                    cmd.Parameters.AddWithValue("@EstadoSecadorH2", (object?)modelo.EstadoSecadorH2 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DewPointEntrada", modelo.DewPointEntrada);
                    cmd.Parameters.AddWithValue("@DewPointSalida", modelo.DewPointSalida);
                    cmd.Parameters.AddWithValue("@VlaControlNivelCalentadorBP1CV221", modelo.VlaControlNivelCalentadorBP1CV221);
                    cmd.Parameters.AddWithValue("@BbaVacioA", (object?)modelo.BbaVacioA ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BbaVacioB", (object?)modelo.BbaVacioB ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PresionSuccionBbaVacioA", modelo.PresionSuccionBbaVacioA);
                    cmd.Parameters.AddWithValue("@PresionAguaSelloBbaVacioB", modelo.PresionAguaSelloBbaVacioB);
                    cmd.Parameters.AddWithValue("@EnfriadorA", (object?)modelo.EnfriadorA ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@EnfriadorB", (object?)modelo.EnfriadorB ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TemperaturaSalidaAgua", modelo.TemperaturaSalidaAgua);
                    cmd.Parameters.AddWithValue("@AperturaValvulaControl", modelo.AperturaValvulaControl);
                    cmd.Parameters.AddWithValue("@ExtraccionA", (object?)modelo.ExtraccionA ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ExtraccionB", (object?)modelo.ExtraccionB ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PresionSuccionExtraccionAireA", modelo.PresionSuccionExtraccionAireA);
                    cmd.Parameters.AddWithValue("@PresionSuccionExtraccionAireB", modelo.PresionSuccionExtraccionAireB);
                    cmd.Parameters.AddWithValue("@PurificadorAceite", (object?)modelo.PurificadorAceite ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PresionTkAceiteTurbina", modelo.PresionTkAceiteTurbina);
                    cmd.Parameters.AddWithValue("@NivelTkAceiteTurbina", modelo.NivelTkAceiteTurbina);
                    cmd.Parameters.AddWithValue("@CargadorA220Vdc", (object?)modelo.CargadorA220Vdc ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CargadorB220Vdc", (object?)modelo.CargadorB220Vdc ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CargadorA125Vdc", (object?)modelo.CargadorA125Vdc ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CargadorB125Vdc", (object?)modelo.CargadorB125Vdc ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CargadorA24Vdc", (object?)modelo.CargadorA24Vdc ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CargadorB24Vdc", (object?)modelo.CargadorB24Vdc ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CorrienteCargador220ES", modelo.CorrienteCargador220ES);
                    cmd.Parameters.AddWithValue("@CorrienteCargador124ES", modelo.CorrienteCargador124ES);
                    cmd.Parameters.AddWithValue("@CorrienteCargador24ES", modelo.CorrienteCargador24ES);
                    cmd.Parameters.AddWithValue("@BAAC_Estado", (object?)modelo.BAAC_Estado ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BAAC_TempRetornoAceiteRodamientoLadoInterior", modelo.BAAC_TempRetornoAceiteRodamientoLadoInterior);
                    cmd.Parameters.AddWithValue("@BAAC_TempRetornoAceiteRodamientoLadoExterior", modelo.BAAC_TempRetornoAceiteRodamientoLadoExterior);
                    cmd.Parameters.AddWithValue("@BAAC_TempAguaSelloLadoInterior", modelo.BAAC_TempAguaSelloLadoInterior);
                    cmd.Parameters.AddWithValue("@BAAC_TempAguaSelloLadoExterior", modelo.BAAC_TempAguaSelloLadoExterior);
                    cmd.Parameters.AddWithValue("@BAAC_PresionAceiteRodamientoLadoInterior", modelo.BAAC_PresionAceiteRodamientoLadoInterior);
                    cmd.Parameters.AddWithValue("@BAAC_PresionAceiteRodamientoLadoExterior", modelo.BAAC_PresionAceiteRodamientoLadoExterior);
                    cmd.Parameters.AddWithValue("@BAAC_PresionEntradaAguaSello", modelo.BAAC_PresionEntradaAguaSello);
                    cmd.Parameters.AddWithValue("@BAAC_PresionDiferencialFiltroAguaSello", modelo.BAAC_PresionDiferencialFiltroAguaSello);
                    cmd.Parameters.AddWithValue("@BAAC_PresionDiferencialFiltroSuccion", modelo.BAAC_PresionDiferencialFiltroSuccion);
                    cmd.Parameters.AddWithValue("@BAAC_AperturaAguaSelloLadoInterior", modelo.BAAC_AperturaAguaSelloLadoInterior);
                    cmd.Parameters.AddWithValue("@BAAC_AperturaAguaSelloLadoExterior", modelo.BAAC_AperturaAguaSelloLadoExterior);
                    cmd.Parameters.AddWithValue("@AcopleBAAC_TempMetalRadial1", modelo.AcopleBAAC_TempMetalRadial1);
                    cmd.Parameters.AddWithValue("@AcopleBAAC_TempMetalRadial2", modelo.AcopleBAAC_TempMetalRadial2);
                    cmd.Parameters.AddWithValue("@AcopleBAAC_TempMetalRadial3", modelo.AcopleBAAC_TempMetalRadial3);
                    cmd.Parameters.AddWithValue("@AcopleBAAC_TempMetalRadial4", modelo.AcopleBAAC_TempMetalRadial4);
                    cmd.Parameters.AddWithValue("@AcopleBAAC_TempMetalRadial5", modelo.AcopleBAAC_TempMetalRadial5);
                    cmd.Parameters.AddWithValue("@AcopleBAAC_TempMetalRadial6", modelo.AcopleBAAC_TempMetalRadial6);
                    cmd.Parameters.AddWithValue("@AcopleBAAC_TempAceiteTrabajoEntradaEnfriador", modelo.AcopleBAAC_TempAceiteTrabajoEntradaEnfriador);
                    cmd.Parameters.AddWithValue("@AcopleBAAC_PresionAceiteLubricacion", modelo.AcopleBAAC_PresionAceiteLubricacion);
                    cmd.Parameters.AddWithValue("@AcopleBAAC_PresionDiferencialFiltroAceite", modelo.AcopleBAAC_PresionDiferencialFiltroAceite);
                    cmd.Parameters.AddWithValue("@AcopleBAAC_TempAceiteLubricacionEntradaEnfriador", modelo.AcopleBAAC_TempAceiteLubricacionEntradaEnfriador);
                    cmd.Parameters.AddWithValue("@AcopleBAAC_TempAceiteLubricacionSalidaEnfriador", modelo.AcopleBAAC_TempAceiteLubricacionSalidaEnfriador);
                    cmd.Parameters.AddWithValue("@AcopleBAAC_TempAceiteTrabajoSalidaEnfriador", modelo.AcopleBAAC_TempAceiteTrabajoSalidaEnfriador);
                    cmd.Parameters.AddWithValue("@BAAB_Estado", (object?)modelo.BAAB_Estado ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BAAB_TempRetornoAceiteRodamientoLadoInterior", modelo.BAAB_TempRetornoAceiteRodamientoLadoInterior);
                    cmd.Parameters.AddWithValue("@BAAB_TempRetornoAceiteRodamientoLadoExterior", modelo.BAAB_TempRetornoAceiteRodamientoLadoExterior);
                    cmd.Parameters.AddWithValue("@BAAB_TempAguaSelloLadoInterior", modelo.BAAB_TempAguaSelloLadoInterior);
                    cmd.Parameters.AddWithValue("@BAAB_TempAguaSelloLadoExterior", modelo.BAAB_TempAguaSelloLadoExterior);
                    cmd.Parameters.AddWithValue("@BAAB_PresionAceiteRodamientoLadoInterior", modelo.BAAB_PresionAceiteRodamientoLadoInterior);
                    cmd.Parameters.AddWithValue("@BAAB_PresionAceiteRodamientoLadoExterior", modelo.BAAB_PresionAceiteRodamientoLadoExterior);
                    cmd.Parameters.AddWithValue("@BAAB_PresionEntradaAguaSello", modelo.BAAB_PresionEntradaAguaSello);
                    cmd.Parameters.AddWithValue("@BAAB_PresionDiferencialFiltroAguaSello", modelo.BAAB_PresionDiferencialFiltroAguaSello);
                    cmd.Parameters.AddWithValue("@BAAB_PresionDiferencialFiltroSuccion", modelo.BAAB_PresionDiferencialFiltroSuccion);
                    cmd.Parameters.AddWithValue("@BAAB_AperturaAguaSelloLadoInterior", modelo.BAAB_AperturaAguaSelloLadoInterior);
                    cmd.Parameters.AddWithValue("@BAAB_AperturaAguaSelloLadoExterior", modelo.BAAB_AperturaAguaSelloLadoExterior);
                    cmd.Parameters.AddWithValue("@AcopleBAAB_TempMetalRadial1", modelo.AcopleBAAB_TempMetalRadial1);
                    cmd.Parameters.AddWithValue("@AcopleBAAB_TempMetalRadial2", modelo.AcopleBAAB_TempMetalRadial2);
                    cmd.Parameters.AddWithValue("@AcopleBAAB_TempMetalRadial3", modelo.AcopleBAAB_TempMetalRadial3);
                    cmd.Parameters.AddWithValue("@AcopleBAAB_TempMetalRadial4", modelo.AcopleBAAB_TempMetalRadial4);
                    cmd.Parameters.AddWithValue("@AcopleBAAB_TempMetalRadial5", modelo.AcopleBAAB_TempMetalRadial5);
                    cmd.Parameters.AddWithValue("@AcopleBAAB_TempMetalRadial6", modelo.AcopleBAAB_TempMetalRadial6);
                    cmd.Parameters.AddWithValue("@AcopleBAAB_TempAceiteTrabajoEntradaEnfriador", modelo.AcopleBAAB_TempAceiteTrabajoEntradaEnfriador);
                    cmd.Parameters.AddWithValue("@AcopleBAAB_PresionAceiteLubricacion", modelo.AcopleBAAB_PresionAceiteLubricacion);
                    cmd.Parameters.AddWithValue("@AcopleBAAB_PresionDiferencialFiltroAceite", modelo.AcopleBAAB_PresionDiferencialFiltroAceite);
                    cmd.Parameters.AddWithValue("@AcopleBAAB_TempAceiteLubricacionEntradaEnfriador", modelo.AcopleBAAB_TempAceiteLubricacionEntradaEnfriador);
                    cmd.Parameters.AddWithValue("@AcopleBAAB_TempAceiteLubricacionSalidaEnfriador", modelo.AcopleBAAB_TempAceiteLubricacionSalidaEnfriador);
                    cmd.Parameters.AddWithValue("@AcopleBAAB_TempAceiteTrabajoSalidaEnfriador", modelo.AcopleBAAB_TempAceiteTrabajoSalidaEnfriador);
                    cmd.Parameters.AddWithValue("@BAAA_Estado", (object?)modelo.BAAA_Estado ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BAAA_TempRetornoAceiteRodamientoLadoInterior", modelo.BAAA_TempRetornoAceiteRodamientoLadoInterior);
                    cmd.Parameters.AddWithValue("@BAAA_TempRetornoAceiteRodamientoLadoExterior", modelo.BAAA_TempRetornoAceiteRodamientoLadoExterior);
                    cmd.Parameters.AddWithValue("@BAAA_TempAguaSelloLadoInterior", modelo.BAAA_TempAguaSelloLadoInterior);
                    cmd.Parameters.AddWithValue("@BAAA_TempAguaSelloLadoExterior", modelo.BAAA_TempAguaSelloLadoExterior);
                    cmd.Parameters.AddWithValue("@BAAA_PresionAceiteRodamientoLadoInterior", modelo.BAAA_PresionAceiteRodamientoLadoInterior);
                    cmd.Parameters.AddWithValue("@BAAA_PresionAceiteRodamientoLadoExterior", modelo.BAAA_PresionAceiteRodamientoLadoExterior);
                    cmd.Parameters.AddWithValue("@BAAA_PresionEntradaAguaSello", modelo.BAAA_PresionEntradaAguaSello);
                    cmd.Parameters.AddWithValue("@BAAA_PresionDiferencialFiltroAguaSello", modelo.BAAA_PresionDiferencialFiltroAguaSello);
                    cmd.Parameters.AddWithValue("@BAAA_PresionDiferencialFiltroSuccion", modelo.BAAA_PresionDiferencialFiltroSuccion);
                    cmd.Parameters.AddWithValue("@BAAA_AperturaAguaSelloLadoInterior", modelo.BAAA_AperturaAguaSelloLadoInterior);
                    cmd.Parameters.AddWithValue("@BAAA_AperturaAguaSelloLadoExterior", modelo.BAAA_AperturaAguaSelloLadoExterior);
                    cmd.Parameters.AddWithValue("@AcopleBAAA_TempMetalRadial1", modelo.AcopleBAAA_TempMetalRadial1);
                    cmd.Parameters.AddWithValue("@AcopleBAAA_TempMetalRadial2", modelo.AcopleBAAA_TempMetalRadial2);
                    cmd.Parameters.AddWithValue("@AcopleBAAA_TempMetalRadial3", modelo.AcopleBAAA_TempMetalRadial3);
                    cmd.Parameters.AddWithValue("@AcopleBAAA_TempMetalRadial4", modelo.AcopleBAAA_TempMetalRadial4);
                    cmd.Parameters.AddWithValue("@AcopleBAAA_TempMetalRadial5", modelo.AcopleBAAA_TempMetalRadial5);
                    cmd.Parameters.AddWithValue("@AcopleBAAA_TempMetalRadial6", modelo.AcopleBAAA_TempMetalRadial6);
                    cmd.Parameters.AddWithValue("@AcopleBAAA_TempAceiteTrabajoEntradaEnfriador", modelo.AcopleBAAA_TempAceiteTrabajoEntradaEnfriador);
                    cmd.Parameters.AddWithValue("@AcopleBAAA_PresionAceiteLubricacion", modelo.AcopleBAAA_PresionAceiteLubricacion);
                    cmd.Parameters.AddWithValue("@AcopleBAAA_PresionDiferencialFiltroAceite", modelo.AcopleBAAA_PresionDiferencialFiltroAceite);
                    cmd.Parameters.AddWithValue("@AcopleBAAA_TempAceiteLubricacionEntradaEnfriador", modelo.AcopleBAAA_TempAceiteLubricacionEntradaEnfriador);
                    cmd.Parameters.AddWithValue("@AcopleBAAA_TempAceiteLubricacionSalidaEnfriador", modelo.AcopleBAAA_TempAceiteLubricacionSalidaEnfriador);
                    cmd.Parameters.AddWithValue("@AcopleBAAA_TempAceiteTrabajoSalidaEnfriador", modelo.AcopleBAAA_TempAceiteTrabajoSalidaEnfriador);
                    cmd.Parameters.AddWithValue("@SecadorAireA", (object?)modelo.SecadorAireA ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SecadorAireB", (object?)modelo.SecadorAireB ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TempDewPointSecadorA", modelo.TempDewPointSecadorA);
                    cmd.Parameters.AddWithValue("@TempDewPointSecadorB", modelo.TempDewPointSecadorB);
                    cmd.Parameters.AddWithValue("@CompresorC_Estado", (object?)modelo.CompresorC_Estado ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CompresorC_TempT1Descarga", modelo.CompresorC_TempT1Descarga);
                    cmd.Parameters.AddWithValue("@CompresorC_TempT2LadoSeco", modelo.CompresorC_TempT2LadoSeco);
                    cmd.Parameters.AddWithValue("@CompresorC_PresionP1Carter", modelo.CompresorC_PresionP1Carter);
                    cmd.Parameters.AddWithValue("@CompresorC_PresionP2Linea", modelo.CompresorC_PresionP2Linea);
                    cmd.Parameters.AddWithValue("@CompresorC_PresionP4Aceite", modelo.CompresorC_PresionP4Aceite);
                    cmd.Parameters.AddWithValue("@CompresorC_PresionDP1Separador", modelo.CompresorC_PresionDP1Separador);
                    cmd.Parameters.AddWithValue("@CompresorC_PresionDP2FiltroAceite", modelo.CompresorC_PresionDP2FiltroAceite);
                    cmd.Parameters.AddWithValue("@CompresorC_PresionDP3Aceite", modelo.CompresorC_PresionDP3Aceite);
                    cmd.Parameters.AddWithValue("@CompresorA_Estado", (object?)modelo.CompresorA_Estado ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CompresorA_PresionDescargaConjunto", modelo.CompresorA_PresionDescargaConjunto);
                    cmd.Parameters.AddWithValue("@CompresorA_TempDescargaConjunto", modelo.CompresorA_TempDescargaConjunto);
                    cmd.Parameters.AddWithValue("@CompresorA_TempDescargaFase1", modelo.CompresorA_TempDescargaFase1);
                    cmd.Parameters.AddWithValue("@CompresorA_PresionEntradaFase2", modelo.CompresorA_PresionEntradaFase2);
                    cmd.Parameters.AddWithValue("@CompresorA_TempEntradaFase2", modelo.CompresorA_TempEntradaFase2);
                    cmd.Parameters.AddWithValue("@CompresorA_PresionDescargaFase2", modelo.CompresorA_PresionDescargaFase2);
                    cmd.Parameters.AddWithValue("@CompresorA_TempDescargaFase2", modelo.CompresorA_TempDescargaFase2);
                    cmd.Parameters.AddWithValue("@CompresorA_TempAceiteRodamientos", modelo.CompresorA_TempAceiteRodamientos);
                    cmd.Parameters.AddWithValue("@CompresorA_PresionAceiteRodamientos", modelo.CompresorA_PresionAceiteRodamientos);
                    cmd.Parameters.AddWithValue("@CompresorA_VacioEntrada", modelo.CompresorA_VacioEntrada);
                    cmd.Parameters.AddWithValue("@CompresorA_CaidaPresionFiltroAceite", modelo.CompresorA_CaidaPresionFiltroAceite);
                    cmd.Parameters.AddWithValue("@CompresorB_Estado", (object?)modelo.CompresorB_Estado ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CompresorB_TempDescargaUnidad", modelo.CompresorB_TempDescargaUnidad);
                    cmd.Parameters.AddWithValue("@CompresorB_Temp1aFase", modelo.CompresorB_Temp1aFase);
                    cmd.Parameters.AddWithValue("@CompresorB_PresionAdmision2aFase", modelo.CompresorB_PresionAdmision2aFase);
                    cmd.Parameters.AddWithValue("@CompresorB_TempAdmision2aFase", modelo.CompresorB_TempAdmision2aFase);
                    cmd.Parameters.AddWithValue("@CompresorB_PresionDescarga2aFase", modelo.CompresorB_PresionDescarga2aFase);
                    cmd.Parameters.AddWithValue("@CompresorB_TempDescarga2aFase", modelo.CompresorB_TempDescarga2aFase);
                    cmd.Parameters.AddWithValue("@CompresorB_PresionAceiteCojinetes", modelo.CompresorB_PresionAceiteCojinetes);
                    cmd.Parameters.AddWithValue("@CompresorB_TempAceiteCojinetes", modelo.CompresorB_TempAceiteCojinetes);
                    cmd.Parameters.AddWithValue("@CompresorB_VacioEntrada", modelo.CompresorB_VacioEntrada);
                    cmd.Parameters.AddWithValue("@CompresorB_EstadoFiltroEntrada", (object?)modelo.CompresorB_EstadoFiltroEntrada ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CompresorB_CaidaPresionFiltroAceite", modelo.CompresorB_CaidaPresionFiltroAceite);
                    cmd.Parameters.AddWithValue("@VlaControlNivelCalentadorBP2CV223", modelo.VlaControlNivelCalentadorBP2CV223);
                    cmd.Parameters.AddWithValue("@CorrienteCompresorB", modelo.CorrienteCompresorB);
                    cmd.Parameters.AddWithValue("@CorrienteCompresorC", modelo.CorrienteCompresorC);
                    cmd.Parameters.AddWithValue("@CorrienteCompresorA", modelo.CorrienteCompresorA);
                    cmd.Parameters.AddWithValue("@VlaControlNivelCalentadorBP3CV224", modelo.VlaControlNivelCalentadorBP3CV224);
                    cmd.Parameters.AddWithValue("@PI255_PresionAceiteAltaPresion", modelo.PI255_PresionAceiteAltaPresion);
                    cmd.Parameters.AddWithValue("@PI257_PresionAceiteDescargaBombaPrincipal", modelo.PI257_PresionAceiteDescargaBombaPrincipal);
                    cmd.Parameters.AddWithValue("@PI329_PresionSelloExtremoTurbina", modelo.PI329_PresionSelloExtremoTurbina);
                    cmd.Parameters.AddWithValue("@PI328_PresionSelloExtremoGenerador", modelo.PI328_PresionSelloExtremoGenerador);
                    cmd.Parameters.AddWithValue("@ExtractorTkBucle", (object?)modelo.ExtractorTkBucle ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PresionSuccionExtractorTkBucle", modelo.PresionSuccionExtractorTkBucle);
                    cmd.Parameters.AddWithValue("@PI230_PresionVaporSelloBP", modelo.PI230_PresionVaporSelloBP);
                    cmd.Parameters.AddWithValue("@PI238_PresionVaporSalidaCamaraIntermedia", modelo.PI238_PresionVaporSalidaCamaraIntermedia);
                    cmd.Parameters.AddWithValue("@VlaControlNivelCalentadorAP5CV226", modelo.VlaControlNivelCalentadorAP5CV226);
                    cmd.Parameters.AddWithValue("@VlaControlNivelCalentadorAP6CV227", modelo.VlaControlNivelCalentadorAP6CV227);
                    cmd.Parameters.AddWithValue("@Observaciones", (object?)modelo.Observaciones ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BombaFosfatoDomoA", (object?)modelo.BombaFosfatoDomoA ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BombaFosfatoDomoB", (object?)modelo.BombaFosfatoDomoB ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BombaHidracinaCicloA", (object?)modelo.BombaHidracinaCicloA ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BombaHidracinaCicloB", (object?)modelo.BombaHidracinaCicloB ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BombaHidracinaCtoCerradoA", (object?)modelo.BombaHidracinaCtoCerradoA ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BombaHidracinaCtoCerradoB", (object?)modelo.BombaHidracinaCtoCerradoB ?? DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
                _logger.LogInformation($"Registro insertado correctamente para el operador: {modelo.NombreOperador}, inicio: {modelo.FechaHoraInicio}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al insertar registro en Registrar (POST) de ParametrosOperacionTurboGeneracionController");
                return View("Error!");
            }
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            _logger.LogError("Se ha accedido a la acción Error en ParametrosOperacionTurboGeneracionController");
            return View("Error!");
        }
    }
}