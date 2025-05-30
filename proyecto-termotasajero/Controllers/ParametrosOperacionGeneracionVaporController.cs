using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace proyecto_termotasajero.Controllers
{
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
                        lista.Add(new proyecto_termotasajero.Models.ParametrosOperacionGeneracionVapor
                        {
                            ID = reader.GetInt32(reader.GetOrdinal("ID")),
                            FechaHoraInicio = reader.GetDateTime(reader.GetOrdinal("FechaHoraInicio")),
                            FechaHoraFinalizacion = reader.GetDateTime(reader.GetOrdinal("FechaHoraFinalizacion")),
                            CorreoElectronico = reader.IsDBNull(reader.GetOrdinal("CorreoElectronico")) ? null : reader.GetString(reader.GetOrdinal("CorreoElectronico")),
                            NombreOperador = reader.IsDBNull(reader.GetOrdinal("NombreOperador")) ? null : reader.GetString(reader.GetOrdinal("NombreOperador")),
                            OperadorTurno = reader.IsDBNull(reader.GetOrdinal("OperadorTurno")) ? null : reader.GetString(reader.GetOrdinal("OperadorTurno")),
                            AirePurgaA = reader.IsDBNull(reader.GetOrdinal("AirePurgaA")) ? null : reader.GetString(reader.GetOrdinal("AirePurgaA")),
                            AirePurgaB = reader.IsDBNull(reader.GetOrdinal("AirePurgaB")) ? null : reader.GetString(reader.GetOrdinal("AirePurgaB")),
                            CorrienteAirePurgaA = reader.GetDecimal(reader.GetOrdinal("CorrienteAirePurgaA")),
                            CorrienteAirePurgaB = reader.GetDecimal(reader.GetOrdinal("CorrienteAirePurgaB")),
                            VTIA_PresionAceiteEntrada = reader.GetDecimal(reader.GetOrdinal("VTIA_PresionAceiteEntrada")),
                            VTIA_PresionAceiteSalida = reader.GetDecimal(reader.GetOrdinal("VTIA_PresionAceiteSalida")),
                            VTIA_TempAceiteEntrada = reader.GetDecimal(reader.GetOrdinal("VTIA_TempAceiteEntrada")),
                            VTIA_TempAceiteSalida = reader.GetDecimal(reader.GetOrdinal("VTIA_TempAceiteSalida")),
                            VTIB_PresionAceiteEntrada = reader.GetDecimal(reader.GetOrdinal("VTIB_PresionAceiteEntrada")),
                            VTIB_PresionAceiteSalida = reader.GetDecimal(reader.GetOrdinal("VTIB_PresionAceiteSalida")),
                            VTIB_TempAceiteEntrada = reader.GetDecimal(reader.GetOrdinal("VTIB_TempAceiteEntrada")),
                            VTIB_TempAceiteSalida = reader.GetDecimal(reader.GetOrdinal("VTIB_TempAceiteSalida")),
                            PresionFluidizadorA = reader.GetDecimal(reader.GetOrdinal("PresionFluidizadorA")),
                            PresionFluidizadorB = reader.GetDecimal(reader.GetOrdinal("PresionFluidizadorB")),
                            SopladorFluidizadorA = reader.IsDBNull(reader.GetOrdinal("SopladorFluidizadorA")) ? null : reader.GetString(reader.GetOrdinal("SopladorFluidizadorA")),
                            SopladorFluidizadorB = reader.IsDBNull(reader.GetOrdinal("SopladorFluidizadorB")) ? null : reader.GetString(reader.GetOrdinal("SopladorFluidizadorB")),
                            SopladorTransporteA = reader.IsDBNull(reader.GetOrdinal("SopladorTransporteA")) ? null : reader.GetString(reader.GetOrdinal("SopladorTransporteA")),
                            SopladorTransporteB = reader.IsDBNull(reader.GetOrdinal("SopladorTransporteB")) ? null : reader.GetString(reader.GetOrdinal("SopladorTransporteB")),
                            VTFB_PresionEntrada = reader.GetDecimal(reader.GetOrdinal("VTFB_PresionEntrada")),
                            VTFB_PresionSalida = reader.GetDecimal(reader.GetOrdinal("VTFB_PresionSalida")),
                            VTFB_TempEntrada = reader.GetDecimal(reader.GetOrdinal("VTFB_TempEntrada")),
                            VTFB_TempSalida = reader.GetDecimal(reader.GetOrdinal("VTFB_TempSalida")),
                            VTFA_PresionEntrada = reader.GetDecimal(reader.GetOrdinal("VTFA_PresionEntrada")),
                            VTFA_PresionSalida = reader.GetDecimal(reader.GetOrdinal("VTFA_PresionSalida")),
                            VTFA_TempEntrada = reader.GetDecimal(reader.GetOrdinal("VTFA_TempEntrada")),
                            VTFA_TempSalida = reader.GetDecimal(reader.GetOrdinal("VTFA_TempSalida")),
                            BandaAC1 = reader.IsDBNull(reader.GetOrdinal("BandaAC1")) ? null : reader.GetString(reader.GetOrdinal("BandaAC1")),
                            Scrapper = reader.IsDBNull(reader.GetOrdinal("Scrapper")) ? null : reader.GetString(reader.GetOrdinal("Scrapper")),
                            PresionAguaLadoA = reader.GetDecimal(reader.GetOrdinal("PresionAguaLadoA")),
                            PresionAguaLadoB = reader.GetDecimal(reader.GetOrdinal("PresionAguaLadoB")),
                            TempAceiteMolinoD = reader.GetDecimal(reader.GetOrdinal("TempAceiteMolinoD")),
                            TempAceiteMolinoC = reader.GetDecimal(reader.GetOrdinal("TempAceiteMolinoC")),
                            TempAceiteMolinoB = reader.GetDecimal(reader.GetOrdinal("TempAceiteMolinoB")),
                            TempAceiteMolinoA = reader.GetDecimal(reader.GetOrdinal("TempAceiteMolinoA")),
                            PresionCojineteSoporteA = reader.GetDecimal(reader.GetOrdinal("PresionCojineteSoporteA")),
                            PresionCojineteSoporteB = reader.GetDecimal(reader.GetOrdinal("PresionCojineteSoporteB")),
                            PresionCojineteSoporteC = reader.GetDecimal(reader.GetOrdinal("PresionCojineteSoporteC")),
                            PresionCojineteSoporteD = reader.GetDecimal(reader.GetOrdinal("PresionCojineteSoporteD")),
                            LjungstromB = reader.IsDBNull(reader.GetOrdinal("LjungstromB")) ? null : reader.GetString(reader.GetOrdinal("LjungstromB")),
                            LjungstromA = reader.IsDBNull(reader.GetOrdinal("LjungstromA")) ? null : reader.GetString(reader.GetOrdinal("LjungstromA")),
                            PresionTk = reader.GetDecimal(reader.GetOrdinal("PresionTk")),
                            Apertura = reader.IsDBNull(reader.GetOrdinal("Apertura")) ? null : reader.GetString(reader.GetOrdinal("Apertura")),
                            VibradorA = reader.IsDBNull(reader.GetOrdinal("VibradorA")) ? null : reader.GetString(reader.GetOrdinal("VibradorA")),
                            VibradorB = reader.IsDBNull(reader.GetOrdinal("VibradorB")) ? null : reader.GetString(reader.GetOrdinal("VibradorB")),
                            VibradorC = reader.IsDBNull(reader.GetOrdinal("VibradorC")) ? null : reader.GetString(reader.GetOrdinal("VibradorC")),
                            ZarandaA = reader.IsDBNull(reader.GetOrdinal("ZarandaA")) ? null : reader.GetString(reader.GetOrdinal("ZarandaA")),
                            TrituradorA = reader.IsDBNull(reader.GetOrdinal("TrituradorA")) ? null : reader.GetString(reader.GetOrdinal("TrituradorA")),
                            ZarandaB = reader.IsDBNull(reader.GetOrdinal("ZarandaB")) ? null : reader.GetString(reader.GetOrdinal("ZarandaB")),
                            TrituradorB = reader.IsDBNull(reader.GetOrdinal("TrituradorB")) ? null : reader.GetString(reader.GetOrdinal("TrituradorB")),
                            FluidizadorB = reader.IsDBNull(reader.GetOrdinal("FluidizadorB")) ? null : reader.GetString(reader.GetOrdinal("FluidizadorB")),
                            FluidizadorA = reader.IsDBNull(reader.GetOrdinal("FluidizadorA")) ? null : reader.GetString(reader.GetOrdinal("FluidizadorA")),
                            Observaciones = reader.IsDBNull(reader.GetOrdinal("Observaciones")) ? null : reader.GetString(reader.GetOrdinal("Observaciones")),
                            TrenSeleccionadoSubirCarbon = reader.IsDBNull(reader.GetOrdinal("TrenSeleccionadoSubirCarbon")) ? null : reader.GetString(reader.GetOrdinal("TrenSeleccionadoSubirCarbon")),
                            MolinoD_Seleccion = reader.IsDBNull(reader.GetOrdinal("MolinoD_Seleccion")) ? null : reader.GetString(reader.GetOrdinal("MolinoD_Seleccion")),
                            MolinoC_Seleccion = reader.IsDBNull(reader.GetOrdinal("MolinoC_Seleccion")) ? null : reader.GetString(reader.GetOrdinal("MolinoC_Seleccion")),
                            MolinoB_Seleccion = reader.IsDBNull(reader.GetOrdinal("MolinoB_Seleccion")) ? null : reader.GetString(reader.GetOrdinal("MolinoB_Seleccion")),
                            MolinoA_Seleccion = reader.IsDBNull(reader.GetOrdinal("MolinoA_Seleccion")) ? null : reader.GetString(reader.GetOrdinal("MolinoA_Seleccion")),
                            LjungstromA_Seleccion = reader.IsDBNull(reader.GetOrdinal("LjungstromA_Seleccion")) ? null : reader.GetString(reader.GetOrdinal("LjungstromA_Seleccion")),
                            LjungstromB_Seleccion = reader.IsDBNull(reader.GetOrdinal("LjungstromB_Seleccion")) ? null : reader.GetString(reader.GetOrdinal("LjungstromB_Seleccion")),
                            FechaCreacion = reader.GetDateTime(reader.GetOrdinal("FechaCreacion")),
                            UsuarioCreacion = reader.IsDBNull(reader.GetOrdinal("UsuarioCreacion")) ? null : reader.GetString(reader.GetOrdinal("UsuarioCreacion"))
                        });
                    }
                }
            }
            return View(lista);
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
                cmd.Parameters.AddWithValue("@FechaCreacion", modelo.FechaCreacion);
                cmd.Parameters.AddWithValue("@UsuarioCreacion", (object?)modelo.UsuarioCreacion ?? DBNull.Value);
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            return View("Registrar");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}
