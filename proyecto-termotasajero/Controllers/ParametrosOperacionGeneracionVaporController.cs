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
    [Route("[controller]")]
    public class ParametrosOperacionGeneracionVaporController : Controller
    {
        private readonly ILogger<ParametrosOperacionGeneracionVaporController> _logger;
        private readonly string? _connectionString;

        public ParametrosOperacionGeneracionVaporController(ILogger<ParametrosOperacionGeneracionVaporController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _connectionString = configuration.GetConnectionString("sql");
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}
