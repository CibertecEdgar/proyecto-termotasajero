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
    public class ParametrosOperacionCirculacionAguaController : Controller
    {
        private readonly ILogger<ParametrosOperacionCirculacionAguaController> _logger;
        private readonly string? _connectionString;

        public ParametrosOperacionCirculacionAguaController(ILogger<ParametrosOperacionCirculacionAguaController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _connectionString = configuration.GetConnectionString("sql");
        }

        // Listar registros usando procedimiento almacenado
        [HttpGet]
        public IActionResult Index()
        {
            var lista = new List<proyecto_termotasajero.Models.ParametrosOperacionCirculacionAgua>();
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("ListarParametrosOperacionCirculacionAgua", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var item = new proyecto_termotasajero.Models.ParametrosOperacionCirculacionAgua();

                        item.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                        item.Inicio = reader.GetDateTime(reader.GetOrdinal("Inicio"));
                        item.Finalizacion = reader.GetDateTime(reader.GetOrdinal("Finalizacion"));
                        item.CorreoElectronico = reader.IsDBNull(reader.GetOrdinal("CorreoElectronico")) ? null : reader.GetString(reader.GetOrdinal("CorreoElectronico"));
                        item.Nombre = reader.IsDBNull(reader.GetOrdinal("Nombre")) ? null : reader.GetString(reader.GetOrdinal("Nombre"));
                        item.OperadorTurno = reader.IsDBNull(reader.GetOrdinal("OperadorTurno")) ? null : reader.GetString(reader.GetOrdinal("OperadorTurno"));
                        item.BAC_B_Estado = reader.IsDBNull(reader.GetOrdinal("BAC_B_Estado")) ? null : reader.GetString(reader.GetOrdinal("BAC_B_Estado"));
                        item.BAC_A_Estado = reader.IsDBNull(reader.GetOrdinal("BAC_A_Estado")) ? null : reader.GetString(reader.GetOrdinal("BAC_A_Estado"));
                        item.BAC_C_Estado = reader.IsDBNull(reader.GetOrdinal("BAC_C_Estado")) ? null : reader.GetString(reader.GetOrdinal("BAC_C_Estado"));
                        item.PI308_A_Presion = reader.GetDecimal(reader.GetOrdinal("PI308_A_Presion"));
                        item.PI308_B_Presion = reader.GetDecimal(reader.GetOrdinal("PI308_B_Presion"));
                        item.PI308_C_Presion = reader.GetDecimal(reader.GetOrdinal("PI308_C_Presion"));
                        item.FiltroLubricacion_Antes = reader.GetDecimal(reader.GetOrdinal("FiltroLubricacion_Antes"));
                        item.FiltroLubricacion_Despues = reader.GetDecimal(reader.GetOrdinal("FiltroLubricacion_Despues"));
                        item.FS212A_Flujo = reader.GetDecimal(reader.GetOrdinal("FS212A_Flujo"));
                        item.FS212B_Flujo = reader.GetDecimal(reader.GetOrdinal("FS212B_Flujo"));
                        item.FS212C_Flujo = reader.GetDecimal(reader.GetOrdinal("FS212C_Flujo"));
                        item.BbaRiegoPatio_A_Estado = reader.IsDBNull(reader.GetOrdinal("BbaRiegoPatio_A_Estado")) ? null : reader.GetString(reader.GetOrdinal("BbaRiegoPatio_A_Estado"));
                        item.BbaRiegoPatio_B_Estado = reader.IsDBNull(reader.GetOrdinal("BbaRiegoPatio_B_Estado")) ? null : reader.GetString(reader.GetOrdinal("BbaRiegoPatio_B_Estado"));
                        item.PresionRiegoPatio_A = reader.GetDecimal(reader.GetOrdinal("PresionRiegoPatio_A"));
                        item.PresionRiegoPatio_B = reader.GetDecimal(reader.GetOrdinal("PresionRiegoPatio_B"));
                        item.LavadoTamiz_A_Estado = reader.IsDBNull(reader.GetOrdinal("LavadoTamiz_A_Estado")) ? null : reader.GetString(reader.GetOrdinal("LavadoTamiz_A_Estado"));
                        item.LavadoTamiz_B_Estado = reader.IsDBNull(reader.GetOrdinal("LavadoTamiz_B_Estado")) ? null : reader.GetString(reader.GetOrdinal("LavadoTamiz_B_Estado"));
                        item.LavadoTamiz_C_Estado = reader.IsDBNull(reader.GetOrdinal("LavadoTamiz_C_Estado")) ? null : reader.GetString(reader.GetOrdinal("LavadoTamiz_C_Estado"));
                        item.PresionBbaTamiz_A = reader.GetDecimal(reader.GetOrdinal("PresionBbaTamiz_A"));
                        item.PresionBbaTamiz_B = reader.GetDecimal(reader.GetOrdinal("PresionBbaTamiz_B"));
                        item.PresionBbaTamiz_C = reader.GetDecimal(reader.GetOrdinal("PresionBbaTamiz_C"));
                        item.BbaAguaCruda_A_Estado = reader.IsDBNull(reader.GetOrdinal("BbaAguaCruda_A_Estado")) ? null : reader.GetString(reader.GetOrdinal("BbaAguaCruda_A_Estado"));
                        item.BbaAguaCruda_B_Estado = reader.IsDBNull(reader.GetOrdinal("BbaAguaCruda_B_Estado")) ? null : reader.GetString(reader.GetOrdinal("BbaAguaCruda_B_Estado"));
                        item.PresionCruda_A = reader.GetDecimal(reader.GetOrdinal("PresionCruda_A"));
                        item.PresionCruda_B = reader.GetDecimal(reader.GetOrdinal("PresionCruda_B"));
                        item.BbaLavadoCeniza_B_Estado = reader.IsDBNull(reader.GetOrdinal("BbaLavadoCeniza_B_Estado")) ? null : reader.GetString(reader.GetOrdinal("BbaLavadoCeniza_B_Estado"));
                        item.BbaLavadoCeniza_A_Estado = reader.IsDBNull(reader.GetOrdinal("BbaLavadoCeniza_A_Estado")) ? null : reader.GetString(reader.GetOrdinal("BbaLavadoCeniza_A_Estado"));
                        item.PresionCeniza_A = reader.GetDecimal(reader.GetOrdinal("PresionCeniza_A"));
                        item.PresionCeniza_B = reader.GetDecimal(reader.GetOrdinal("PresionCeniza_B"));
                        item.BbaLubric_A_Estado = reader.IsDBNull(reader.GetOrdinal("BbaLubric_A_Estado")) ? null : reader.GetString(reader.GetOrdinal("BbaLubric_A_Estado"));
                        item.BbaLubric_B_Estado = reader.IsDBNull(reader.GetOrdinal("BbaLubric_B_Estado")) ? null : reader.GetString(reader.GetOrdinal("BbaLubric_B_Estado"));
                        item.PresionLubric_A = reader.GetDecimal(reader.GetOrdinal("PresionLubric_A"));
                        item.PresionLubric_B = reader.GetDecimal(reader.GetOrdinal("PresionLubric_B"));
                        item.BombaEnfriamientoAlterno_Estado = reader.IsDBNull(reader.GetOrdinal("BombaEnfriamientoAlterno_Estado")) ? null : reader.GetString(reader.GetOrdinal("BombaEnfriamientoAlterno_Estado"));
                        item.PresionEnfriamientoAlterno = reader.GetDecimal(reader.GetOrdinal("PresionEnfriamientoAlterno"));
                        item.VoltajeBAT1 = reader.GetDecimal(reader.GetOrdinal("VoltajeBAT1"));
                        item.CorrienteBAT1 = reader.GetDecimal(reader.GetOrdinal("CorrienteBAT1"));
                        item.VoltajeBAT2 = reader.GetDecimal(reader.GetOrdinal("VoltajeBAT2"));
                        item.CorrienteBAT2 = reader.GetDecimal(reader.GetOrdinal("CorrienteBAT2"));
                        item.PresionTkPulmon = reader.GetDecimal(reader.GetOrdinal("PresionTkPulmon"));
                        item.PresionCompresor_A = reader.GetDecimal(reader.GetOrdinal("PresionCompresor_A"));
                        item.PresionCompresor_B = reader.GetDecimal(reader.GetOrdinal("PresionCompresor_B"));
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
        public IActionResult Registrar(proyecto_termotasajero.Models.ParametrosOperacionCirculacionAgua modelo)
        {
            if (!ModelState.IsValid)
                return View("Index", modelo);

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("Sp_InsertParametrosOperacionCirculacionAgua", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Inicio", modelo.Inicio);
                cmd.Parameters.AddWithValue("@Finalizacion", modelo.Finalizacion);
                cmd.Parameters.AddWithValue("@CorreoElectronico", (object?)modelo.CorreoElectronico ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Nombre", (object?)modelo.Nombre ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@OperadorTurno", (object?)modelo.OperadorTurno ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@BAC_B_Estado", (object?)modelo.BAC_B_Estado ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@BAC_A_Estado", (object?)modelo.BAC_A_Estado ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@BAC_C_Estado", (object?)modelo.BAC_C_Estado ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@PI308_A_Presion", modelo.PI308_A_Presion);
                cmd.Parameters.AddWithValue("@PI308_B_Presion", modelo.PI308_B_Presion);
                cmd.Parameters.AddWithValue("@PI308_C_Presion", modelo.PI308_C_Presion);
                cmd.Parameters.AddWithValue("@FiltroLubricacion_Antes", modelo.FiltroLubricacion_Antes);
                cmd.Parameters.AddWithValue("@FiltroLubricacion_Despues", modelo.FiltroLubricacion_Despues);
                cmd.Parameters.AddWithValue("@FS212A_Flujo", modelo.FS212A_Flujo);
                cmd.Parameters.AddWithValue("@FS212B_Flujo", modelo.FS212B_Flujo);
                cmd.Parameters.AddWithValue("@FS212C_Flujo", modelo.FS212C_Flujo);
                cmd.Parameters.AddWithValue("@BbaRiegoPatio_A_Estado", (object?)modelo.BbaRiegoPatio_A_Estado ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@BbaRiegoPatio_B_Estado", (object?)modelo.BbaRiegoPatio_B_Estado ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@PresionRiegoPatio_A", modelo.PresionRiegoPatio_A);
                cmd.Parameters.AddWithValue("@PresionRiegoPatio_B", modelo.PresionRiegoPatio_B);
                cmd.Parameters.AddWithValue("@LavadoTamiz_A_Estado", (object?)modelo.LavadoTamiz_A_Estado ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LavadoTamiz_B_Estado", (object?)modelo.LavadoTamiz_B_Estado ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LavadoTamiz_C_Estado", (object?)modelo.LavadoTamiz_C_Estado ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@PresionBbaTamiz_A", modelo.PresionBbaTamiz_A);
                cmd.Parameters.AddWithValue("@PresionBbaTamiz_B", modelo.PresionBbaTamiz_B);
                cmd.Parameters.AddWithValue("@PresionBbaTamiz_C", modelo.PresionBbaTamiz_C);
                cmd.Parameters.AddWithValue("@BbaAguaCruda_A_Estado", (object?)modelo.BbaAguaCruda_A_Estado ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@BbaAguaCruda_B_Estado", (object?)modelo.BbaAguaCruda_B_Estado ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@PresionCruda_A", modelo.PresionCruda_A);
                cmd.Parameters.AddWithValue("@PresionCruda_B", modelo.PresionCruda_B);
                cmd.Parameters.AddWithValue("@BbaLavadoCeniza_B_Estado", (object?)modelo.BbaLavadoCeniza_B_Estado ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@BbaLavadoCeniza_A_Estado", (object?)modelo.BbaLavadoCeniza_A_Estado ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@PresionCeniza_A", modelo.PresionCeniza_A);
                cmd.Parameters.AddWithValue("@PresionCeniza_B", modelo.PresionCeniza_B);
                cmd.Parameters.AddWithValue("@BbaLubric_A_Estado", (object?)modelo.BbaLubric_A_Estado ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@BbaLubric_B_Estado", (object?)modelo.BbaLubric_B_Estado ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@PresionLubric_A", modelo.PresionLubric_A);
                cmd.Parameters.AddWithValue("@PresionLubric_B", modelo.PresionLubric_B);
                cmd.Parameters.AddWithValue("@BombaEnfriamientoAlterno_Estado", (object?)modelo.BombaEnfriamientoAlterno_Estado ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@PresionEnfriamientoAlterno", modelo.PresionEnfriamientoAlterno);
                cmd.Parameters.AddWithValue("@VoltajeBAT1", modelo.VoltajeBAT1);
                cmd.Parameters.AddWithValue("@CorrienteBAT1", modelo.CorrienteBAT1);
                cmd.Parameters.AddWithValue("@VoltajeBAT2", modelo.VoltajeBAT2);
                cmd.Parameters.AddWithValue("@CorrienteBAT2", modelo.CorrienteBAT2);
                cmd.Parameters.AddWithValue("@PresionTkPulmon", modelo.PresionTkPulmon);
                cmd.Parameters.AddWithValue("@PresionCompresor_A", modelo.PresionCompresor_A);
                cmd.Parameters.AddWithValue("@PresionCompresor_B", modelo.PresionCompresor_B);
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
