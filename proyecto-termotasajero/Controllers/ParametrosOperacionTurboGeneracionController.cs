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
    [Route("[controller]")]
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
            var lista = new List<proyecto_termotasajero.Models.ParametrosOperacionTurboGeneracion>();
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM ParametrosOperacionTurbogeneracion", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var item = new proyecto_termotasajero.Models.ParametrosOperacionTurboGeneracion();
                        // Asignar todas las propiedades del modelo aquí (ejemplo de algunos campos):
                        item.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                        item.FechaHoraInicio = reader.GetDateTime(reader.GetOrdinal("FechaHoraInicio"));
                        item.FechaHoraFinalizacion = reader.GetDateTime(reader.GetOrdinal("FechaHoraFinalizacion"));
                        item.CorreoElectronico = reader.IsDBNull(reader.GetOrdinal("CorreoElectronico")) ? null : reader.GetString(reader.GetOrdinal("CorreoElectronico"));
                        item.NombreOperador = reader.IsDBNull(reader.GetOrdinal("NombreOperador")) ? null : reader.GetString(reader.GetOrdinal("NombreOperador"));
                        // ...continúa con el resto de campos del modelo...
                        lista.Add(item);
                    }
                }
            }
            return View(lista);
        }

        // Registrar nuevo registro usando Store Procedure
        [HttpPost]
        public IActionResult Registrar(proyecto_termotasajero.Models.ParametrosOperacionTurboGeneracion modelo)
        {
            if (!ModelState.IsValid)
                return View("Index", modelo);

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
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}