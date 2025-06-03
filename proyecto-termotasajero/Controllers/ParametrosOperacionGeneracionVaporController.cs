using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;

namespace proyecto_termotasajero.Controllers
{
    [Authorize]
    public class ParametrosOperacionGeneracionVaporController : Controller
    {
        private readonly ILogger<ParametrosOperacionGeneracionVaporController> _logger;
        private readonly string? _connectionString;

        public ParametrosOperacionGeneracionVaporController(ILogger<ParametrosOperacionGeneracionVaporController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _connectionString = configuration.GetConnectionString("sql");
        }

        // Listar registros usando procedimiento almacenado
        [HttpGet]
        public IActionResult Index()
        {
            var lista = new List<proyecto_termotasajero.Models.ParametrosOperacionGeneracionVapor>();
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("ListarParametrosOperacionGeneracionVapor", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var item = new proyecto_termotasajero.Models.ParametrosOperacionGeneracionVapor();
                        item.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                        item.FechaHoraInicio = reader.GetDateTime(reader.GetOrdinal("FechaHoraInicio"));
                        item.FechaHoraFinalizacion = reader.GetDateTime(reader.GetOrdinal("FechaHoraFinalizacion"));
                        item.CorreoElectronico = reader.IsDBNull(reader.GetOrdinal("CorreoElectronico")) ? null : reader.GetString(reader.GetOrdinal("CorreoElectronico"));
                        item.NombreOperador = reader.IsDBNull(reader.GetOrdinal("NombreOperador")) ? null : reader.GetString(reader.GetOrdinal("NombreOperador"));
                        item.OperadorTurno = reader.IsDBNull(reader.GetOrdinal("OperadorTurno")) ? null : reader.GetString(reader.GetOrdinal("OperadorTurno"));
                        item.AirePurgaA = reader.IsDBNull(reader.GetOrdinal("AirePurgaA")) ? null : reader.GetString(reader.GetOrdinal("AirePurgaA"));
                        item.AirePurgaB = reader.IsDBNull(reader.GetOrdinal("AirePurgaB")) ? null : reader.GetString(reader.GetOrdinal("AirePurgaB"));
                        item.CorrienteAirePurgaA = reader.GetDecimal(reader.GetOrdinal("CorrienteAirePurgaA"));
                        item.CorrienteAirePurgaB = reader.GetDecimal(reader.GetOrdinal("CorrienteAirePurgaB"));
                        item.VTIA_PresionAceiteEntrada = reader.GetDecimal(reader.GetOrdinal("VTIA_PresionAceiteEntrada"));
                        item.VTIA_PresionAceiteSalida = reader.GetDecimal(reader.GetOrdinal("VTIA_PresionAceiteSalida"));
                        item.VTIA_TempAceiteEntrada = reader.GetDecimal(reader.GetOrdinal("VTIA_TempAceiteEntrada"));
                        item.VTIA_TempAceiteSalida = reader.GetDecimal(reader.GetOrdinal("VTIA_TempAceiteSalida"));
                        item.VTIB_PresionAceiteEntrada = reader.GetDecimal(reader.GetOrdinal("VTIB_PresionAceiteEntrada"));
                        item.VTIB_PresionAceiteSalida = reader.GetDecimal(reader.GetOrdinal("VTIB_PresionAceiteSalida"));
                        item.VTIB_TempAceiteEntrada = reader.GetDecimal(reader.GetOrdinal("VTIB_TempAceiteEntrada"));
                        item.VTIB_TempAceiteSalida = reader.GetDecimal(reader.GetOrdinal("VTIB_TempAceiteSalida"));
                        item.PresionFluidizadorA = reader.GetDecimal(reader.GetOrdinal("PresionFluidizadorA"));
                        item.PresionFluidizadorB = reader.GetDecimal(reader.GetOrdinal("PresionFluidizadorB"));
                        item.SopladorFluidizadorA = reader.IsDBNull(reader.GetOrdinal("SopladorFluidizadorA")) ? null : reader.GetString(reader.GetOrdinal("SopladorFluidizadorA"));
                        item.SopladorFluidizadorB = reader.IsDBNull(reader.GetOrdinal("SopladorFluidizadorB")) ? null : reader.GetString(reader.GetOrdinal("SopladorFluidizadorB"));
                        item.SopladorTransporteA = reader.IsDBNull(reader.GetOrdinal("SopladorTransporteA")) ? null : reader.GetString(reader.GetOrdinal("SopladorTransporteA"));
                        item.SopladorTransporteB = reader.IsDBNull(reader.GetOrdinal("SopladorTransporteB")) ? null : reader.GetString(reader.GetOrdinal("SopladorTransporteB"));
                        item.VTFB_PresionEntrada = reader.GetDecimal(reader.GetOrdinal("VTFB_PresionEntrada"));
                        item.VTFB_PresionSalida = reader.GetDecimal(reader.GetOrdinal("VTFB_PresionSalida"));
                        item.VTFB_TempEntrada = reader.GetDecimal(reader.GetOrdinal("VTFB_TempEntrada"));
                        item.VTFB_TempSalida = reader.GetDecimal(reader.GetOrdinal("VTFB_TempSalida"));
                        item.VTFA_PresionEntrada = reader.GetDecimal(reader.GetOrdinal("VTFA_PresionEntrada"));
                        item.VTFA_PresionSalida = reader.GetDecimal(reader.GetOrdinal("VTFA_PresionSalida"));
                        item.VTFA_TempEntrada = reader.GetDecimal(reader.GetOrdinal("VTFA_TempEntrada"));
                        item.VTFA_TempSalida = reader.GetDecimal(reader.GetOrdinal("VTFA_TempSalida"));
                        item.BandaAC1 = reader.IsDBNull(reader.GetOrdinal("BandaAC1")) ? null : reader.GetString(reader.GetOrdinal("BandaAC1"));
                        item.Scrapper = reader.IsDBNull(reader.GetOrdinal("Scrapper")) ? null : reader.GetString(reader.GetOrdinal("Scrapper"));
                        item.PresionAguaLadoA = reader.GetDecimal(reader.GetOrdinal("PresionAguaLadoA"));
                        item.PresionAguaLadoB = reader.GetDecimal(reader.GetOrdinal("PresionAguaLadoB"));
                        item.TempAceiteMolinoD = reader.GetDecimal(reader.GetOrdinal("TempAceiteMolinoD"));
                        item.TempAceiteMolinoC = reader.GetDecimal(reader.GetOrdinal("TempAceiteMolinoC"));
                        item.TempAceiteMolinoB = reader.GetDecimal(reader.GetOrdinal("TempAceiteMolinoB"));
                        item.TempAceiteMolinoA = reader.GetDecimal(reader.GetOrdinal("TempAceiteMolinoA"));
                        item.PresionCojineteSoporteA = reader.GetDecimal(reader.GetOrdinal("PresionCojineteSoporteA"));
                        item.PresionCojineteSoporteB = reader.GetDecimal(reader.GetOrdinal("PresionCojineteSoporteB"));
                        item.PresionCojineteSoporteC = reader.GetDecimal(reader.GetOrdinal("PresionCojineteSoporteC"));
                        item.PresionCojineteSoporteD = reader.GetDecimal(reader.GetOrdinal("PresionCojineteSoporteD"));
                        item.LjungstromB = reader.IsDBNull(reader.GetOrdinal("LjungstromB")) ? null : reader.GetString(reader.GetOrdinal("LjungstromB"));
                        item.LjungstromA = reader.IsDBNull(reader.GetOrdinal("LjungstromA")) ? null : reader.GetString(reader.GetOrdinal("LjungstromA"));
                        item.PresionTk = reader.GetDecimal(reader.GetOrdinal("PresionTk"));
                        item.Apertura = reader.IsDBNull(reader.GetOrdinal("Apertura")) ? null : reader.GetString(reader.GetOrdinal("Apertura"));
                        item.VibradorA = reader.IsDBNull(reader.GetOrdinal("VibradorA")) ? null : reader.GetString(reader.GetOrdinal("VibradorA"));
                        item.VibradorB = reader.IsDBNull(reader.GetOrdinal("VibradorB")) ? null : reader.GetString(reader.GetOrdinal("VibradorB"));
                        item.VibradorC = reader.IsDBNull(reader.GetOrdinal("VibradorC")) ? null : reader.GetString(reader.GetOrdinal("VibradorC"));
                        item.ZarandaA = reader.IsDBNull(reader.GetOrdinal("ZarandaA")) ? null : reader.GetString(reader.GetOrdinal("ZarandaA"));
                        item.TrituradorA = reader.IsDBNull(reader.GetOrdinal("TrituradorA")) ? null : reader.GetString(reader.GetOrdinal("TrituradorA"));
                        item.ZarandaB = reader.IsDBNull(reader.GetOrdinal("ZarandaB")) ? null : reader.GetString(reader.GetOrdinal("ZarandaB"));
                        item.TrituradorB = reader.IsDBNull(reader.GetOrdinal("TrituradorB")) ? null : reader.GetString(reader.GetOrdinal("TrituradorB"));
                        item.FluidizadorB = reader.IsDBNull(reader.GetOrdinal("FluidizadorB")) ? null : reader.GetString(reader.GetOrdinal("FluidizadorB"));
                        item.FluidizadorA = reader.IsDBNull(reader.GetOrdinal("FluidizadorA")) ? null : reader.GetString(reader.GetOrdinal("FluidizadorA"));
                        item.Observaciones = reader.IsDBNull(reader.GetOrdinal("Observaciones")) ? null : reader.GetString(reader.GetOrdinal("Observaciones"));
                        item.TrenSeleccionadoSubirCarbon = reader.IsDBNull(reader.GetOrdinal("TrenSeleccionadoSubirCarbon")) ? null : reader.GetString(reader.GetOrdinal("TrenSeleccionadoSubirCarbon"));
                        item.MolinoD_Seleccion = reader.IsDBNull(reader.GetOrdinal("MolinoD_Seleccion")) ? null : reader.GetString(reader.GetOrdinal("MolinoD_Seleccion"));
                        item.MolinoC_Seleccion = reader.IsDBNull(reader.GetOrdinal("MolinoC_Seleccion")) ? null : reader.GetString(reader.GetOrdinal("MolinoC_Seleccion"));
                        item.MolinoB_Seleccion = reader.IsDBNull(reader.GetOrdinal("MolinoB_Seleccion")) ? null : reader.GetString(reader.GetOrdinal("MolinoB_Seleccion"));
                        item.MolinoA_Seleccion = reader.IsDBNull(reader.GetOrdinal("MolinoA_Seleccion")) ? null : reader.GetString(reader.GetOrdinal("MolinoA_Seleccion"));
                        item.LjungstromA_Seleccion = reader.IsDBNull(reader.GetOrdinal("LjungstromA_Seleccion")) ? null : reader.GetString(reader.GetOrdinal("LjungstromA_Seleccion"));
                        item.LjungstromB_Seleccion = reader.IsDBNull(reader.GetOrdinal("LjungstromB_Seleccion")) ? null : reader.GetString(reader.GetOrdinal("LjungstromB_Seleccion"));
                        lista.Add(item);
                    }
                }
            }
            return View(lista);
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            return View("Registrar");
        }

        // Registrar nuevo registro usando procedimiento almacenado
        [HttpPost]
        public IActionResult Registrar(proyecto_termotasajero.Models.ParametrosOperacionGeneracionVapor modelo)
        {
            if (!ModelState.IsValid)
                return View("Index", modelo);

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("Sp_InsertParametrosOperacionGeneracionVapor", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FechaHoraInicio", modelo.FechaHoraInicio);
                cmd.Parameters.AddWithValue("@FechaHoraFinalizacion", modelo.FechaHoraFinalizacion);
                cmd.Parameters.AddWithValue("@CorreoElectronico", (object?)modelo.CorreoElectronico ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@NombreOperador", (object?)modelo.NombreOperador ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@OperadorTurno", (object?)modelo.OperadorTurno ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@AirePurgaA", (object?)modelo.AirePurgaA ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@AirePurgaB", (object?)modelo.AirePurgaB ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@CorrienteAirePurgaA", modelo.CorrienteAirePurgaA);
                cmd.Parameters.AddWithValue("@CorrienteAirePurgaB", modelo.CorrienteAirePurgaB);
                cmd.Parameters.AddWithValue("@VTIA_PresionAceiteEntrada", modelo.VTIA_PresionAceiteEntrada);
                cmd.Parameters.AddWithValue("@VTIA_PresionAceiteSalida", modelo.VTIA_PresionAceiteSalida);
                cmd.Parameters.AddWithValue("@VTIA_TempAceiteEntrada", modelo.VTIA_TempAceiteEntrada);
                cmd.Parameters.AddWithValue("@VTIA_TempAceiteSalida", modelo.VTIA_TempAceiteSalida);
                cmd.Parameters.AddWithValue("@VTIB_PresionAceiteEntrada", modelo.VTIB_PresionAceiteEntrada);
                cmd.Parameters.AddWithValue("@VTIB_PresionAceiteSalida", modelo.VTIB_PresionAceiteSalida);
                cmd.Parameters.AddWithValue("@VTIB_TempAceiteEntrada", modelo.VTIB_TempAceiteEntrada);
                cmd.Parameters.AddWithValue("@VTIB_TempAceiteSalida", modelo.VTIB_TempAceiteSalida);
                cmd.Parameters.AddWithValue("@PresionFluidizadorA", modelo.PresionFluidizadorA);
                cmd.Parameters.AddWithValue("@PresionFluidizadorB", modelo.PresionFluidizadorB);
                cmd.Parameters.AddWithValue("@SopladorFluidizadorA", (object?)modelo.SopladorFluidizadorA ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@SopladorFluidizadorB", (object?)modelo.SopladorFluidizadorB ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@SopladorTransporteA", (object?)modelo.SopladorTransporteA ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@SopladorTransporteB", (object?)modelo.SopladorTransporteB ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@VTFB_PresionEntrada", modelo.VTFB_PresionEntrada);
                cmd.Parameters.AddWithValue("@VTFB_PresionSalida", modelo.VTFB_PresionSalida);
                cmd.Parameters.AddWithValue("@VTFB_TempEntrada", modelo.VTFB_TempEntrada);
                cmd.Parameters.AddWithValue("@VTFB_TempSalida", modelo.VTFB_TempSalida);
                cmd.Parameters.AddWithValue("@VTFA_PresionEntrada", modelo.VTFA_PresionEntrada);
                cmd.Parameters.AddWithValue("@VTFA_PresionSalida", modelo.VTFA_PresionSalida);
                cmd.Parameters.AddWithValue("@VTFA_TempEntrada", modelo.VTFA_TempEntrada);
                cmd.Parameters.AddWithValue("@VTFA_TempSalida", modelo.VTFA_TempSalida);
                cmd.Parameters.AddWithValue("@BandaAC1", (object?)modelo.BandaAC1 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Scrapper", (object?)modelo.Scrapper ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@PresionAguaLadoA", modelo.PresionAguaLadoA);
                cmd.Parameters.AddWithValue("@PresionAguaLadoB", modelo.PresionAguaLadoB);
                cmd.Parameters.AddWithValue("@TempAceiteMolinoD", modelo.TempAceiteMolinoD);
                cmd.Parameters.AddWithValue("@TempAceiteMolinoC", modelo.TempAceiteMolinoC);
                cmd.Parameters.AddWithValue("@TempAceiteMolinoB", modelo.TempAceiteMolinoB);
                cmd.Parameters.AddWithValue("@TempAceiteMolinoA", modelo.TempAceiteMolinoA);
                cmd.Parameters.AddWithValue("@PresionCojineteSoporteA", modelo.PresionCojineteSoporteA);
                cmd.Parameters.AddWithValue("@PresionCojineteSoporteB", modelo.PresionCojineteSoporteB);
                cmd.Parameters.AddWithValue("@PresionCojineteSoporteC", modelo.PresionCojineteSoporteC);
                cmd.Parameters.AddWithValue("@PresionCojineteSoporteD", modelo.PresionCojineteSoporteD);
                cmd.Parameters.AddWithValue("@LjungstromB", (object?)modelo.LjungstromB ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LjungstromA", (object?)modelo.LjungstromA ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@PresionTk", modelo.PresionTk);
                cmd.Parameters.AddWithValue("@Apertura", (object?)modelo.Apertura ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@VibradorA", (object?)modelo.VibradorA ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@VibradorB", (object?)modelo.VibradorB ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@VibradorC", (object?)modelo.VibradorC ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ZarandaA", (object?)modelo.ZarandaA ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@TrituradorA", (object?)modelo.TrituradorA ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ZarandaB", (object?)modelo.ZarandaB ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@TrituradorB", (object?)modelo.TrituradorB ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@FluidizadorB", (object?)modelo.FluidizadorB ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@FluidizadorA", (object?)modelo.FluidizadorA ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Observaciones", (object?)modelo.Observaciones ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@TrenSeleccionadoSubirCarbon", (object?)modelo.TrenSeleccionadoSubirCarbon ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@MolinoD_Seleccion", (object?)modelo.MolinoD_Seleccion ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@MolinoC_Seleccion", (object?)modelo.MolinoC_Seleccion ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@MolinoB_Seleccion", (object?)modelo.MolinoB_Seleccion ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@MolinoA_Seleccion", (object?)modelo.MolinoA_Seleccion ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LjungstromA_Seleccion", (object?)modelo.LjungstromA_Seleccion ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LjungstromB_Seleccion", (object?)modelo.LjungstromB_Seleccion ?? DBNull.Value);
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
