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
    public class ParametrosOperacionCapacitacionAguaController : Controller
    {
        private readonly ILogger<ParametrosOperacionCapacitacionAguaController> _logger;
        private readonly string? _connectionString;

        public ParametrosOperacionCapacitacionAguaController(ILogger<ParametrosOperacionCapacitacionAguaController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _connectionString = configuration.GetConnectionString("sqlConUser");
        }

        // Listar registros
        [HttpGet]
        public IActionResult Index()
        {
            var lista = new List<proyecto_termotasajero.Models.ParametrosOperacionCapacitacionAgua>();
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("Sp_ListarParametrosOperacionCapacitacionAgua", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new proyecto_termotasajero.Models.ParametrosOperacionCapacitacionAgua
                        {
                            ID = reader.GetInt32(reader.GetOrdinal("ID")),
                            Inicio = reader.GetDateTime(reader.GetOrdinal("Inicio")),
                            Finalizacion = reader.GetDateTime(reader.GetOrdinal("Finalizacion")),
                            CorreoElectronico = reader.IsDBNull(reader.GetOrdinal("CorreoElectronico")) ? null : reader.GetString(reader.GetOrdinal("CorreoElectronico")),
                            Nombre = reader.IsDBNull(reader.GetOrdinal("Nombre")) ? null : reader.GetString(reader.GetOrdinal("Nombre")),
                            OperadorTurno = reader.IsDBNull(reader.GetOrdinal("OperadorTurno")) ? null : reader.GetString(reader.GetOrdinal("OperadorTurno")),
                            VoltajeBarraBPW_kV = reader.GetDecimal(reader.GetOrdinal("VoltajeBarraBPW_kV")),
                            Corriente_A = reader.GetDecimal(reader.GetOrdinal("Corriente_A")),
                            BBT_A_Estado = reader.IsDBNull(reader.GetOrdinal("BBT_A_Estado")) ? null : reader.GetString(reader.GetOrdinal("BBT_A_Estado")),
                            TempAceiteReductor_A = reader.GetDecimal(reader.GetOrdinal("TempAceiteReductor_A")),
                            PresAceitePrincipal_A_kgcm2 = reader.GetDecimal(reader.GetOrdinal("PresAceitePrincipal_A_kgcm2")),
                            PresNormalLubricacion_A_kgcm2 = reader.GetDecimal(reader.GetOrdinal("PresNormalLubricacion_A_kgcm2")),
                            PresAguaEnfriamiento_A_kgcm2 = reader.GetDecimal(reader.GetOrdinal("PresAguaEnfriamiento_A_kgcm2")),
                            TempDevanadosFaseR_A = reader.GetDecimal(reader.GetOrdinal("TempDevanadosFaseR_A")),
                            TempDevanadosFaseS_A = reader.GetDecimal(reader.GetOrdinal("TempDevanadosFaseS_A")),
                            TempDevanadosFaseT_A = reader.GetDecimal(reader.GetOrdinal("TempDevanadosFaseT_A")),
                            BBT_B_Estado = reader.IsDBNull(reader.GetOrdinal("BBT_B_Estado")) ? null : reader.GetString(reader.GetOrdinal("BBT_B_Estado")),
                            TempAceiteReductor_B = reader.GetDecimal(reader.GetOrdinal("TempAceiteReductor_B")),
                            PresAceitePrincipal_B_kgcm2 = reader.GetDecimal(reader.GetOrdinal("PresAceitePrincipal_B_kgcm2")),
                            PresNormalLubricacion_B_kgcm2 = reader.GetDecimal(reader.GetOrdinal("PresNormalLubricacion_B_kgcm2")),
                            PresAguaEnfriamiento_B_kgcm2 = reader.GetDecimal(reader.GetOrdinal("PresAguaEnfriamiento_B_kgcm2")),
                            TempRodamientoLadoLibre_B = reader.GetDecimal(reader.GetOrdinal("TempRodamientoLadoLibre_B")),
                            TempDevanadosFaseR_B = reader.GetDecimal(reader.GetOrdinal("TempDevanadosFaseR_B")),
                            TempDevanadosFaseS_B = reader.GetDecimal(reader.GetOrdinal("TempDevanadosFaseS_B")),
                            TempDevanadosFaseT_B = reader.GetDecimal(reader.GetOrdinal("TempDevanadosFaseT_B")),
                            TempRodamientoLadoAcople_B = reader.GetDecimal(reader.GetOrdinal("TempRodamientoLadoAcople_B")),
                            BBT_C_Estado = reader.IsDBNull(reader.GetOrdinal("BBT_C_Estado")) ? null : reader.GetString(reader.GetOrdinal("BBT_C_Estado")),
                            TempAceiteReductor_C = reader.GetDecimal(reader.GetOrdinal("TempAceiteReductor_C")),
                            PresAceitePrincipal_C_kgcm2 = reader.GetDecimal(reader.GetOrdinal("PresAceitePrincipal_C_kgcm2")),
                            PresNormalLubricacion_C_kgcm2 = reader.GetDecimal(reader.GetOrdinal("PresNormalLubricacion_C_kgcm2")),
                            PresAguaEnfriamiento_C_kgcm2 = reader.GetDecimal(reader.GetOrdinal("PresAguaEnfriamiento_C_kgcm2")),
                            TempDevanadosFaseR_C = reader.GetDecimal(reader.GetOrdinal("TempDevanadosFaseR_C")),
                            TempDevanadosFaseS_C = reader.GetDecimal(reader.GetOrdinal("TempDevanadosFaseS_C")),
                            TempDevanadosFaseT_C = reader.GetDecimal(reader.GetOrdinal("TempDevanadosFaseT_C")),
                            BbaB_CircuitoCerrado = reader.IsDBNull(reader.GetOrdinal("BbaB_CircuitoCerrado")) ? null : reader.GetString(reader.GetOrdinal("BbaB_CircuitoCerrado")),
                            BbaA_CircuitoCerrado = reader.IsDBNull(reader.GetOrdinal("BbaA_CircuitoCerrado")) ? null : reader.GetString(reader.GetOrdinal("BbaA_CircuitoCerrado")),
                            PresDescargaCabezal_kgcm2 = reader.GetDecimal(reader.GetOrdinal("PresDescargaCabezal_kgcm2"))
                        });
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

        // Registrar nuevo registro usando Store Procedure
        [HttpPost]
        public IActionResult Registrar(proyecto_termotasajero.Models.ParametrosOperacionCapacitacionAgua modelo)
        {
            if (!ModelState.IsValid)
                return View("Index", modelo);

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("Sp_InsertParametrosOperacionCapacitacionAgua", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Inicio", modelo.Inicio);
                cmd.Parameters.AddWithValue("@Finalizacion", modelo.Finalizacion);
                cmd.Parameters.AddWithValue("@CorreoElectronico", (object?)modelo.CorreoElectronico ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Nombre", (object?)modelo.Nombre ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@OperadorTurno", (object?)modelo.OperadorTurno ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@VoltajeBarraBPW_kV", modelo.VoltajeBarraBPW_kV);
                cmd.Parameters.AddWithValue("@Corriente_A", modelo.Corriente_A);
                cmd.Parameters.AddWithValue("@BBT_A_Estado", (object?)modelo.BBT_A_Estado ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@TempAceiteReductor_A", modelo.TempAceiteReductor_A);
                cmd.Parameters.AddWithValue("@PresAceitePrincipal_A_kgcm2", modelo.PresAceitePrincipal_A_kgcm2);
                cmd.Parameters.AddWithValue("@PresNormalLubricacion_A_kgcm2", modelo.PresNormalLubricacion_A_kgcm2);
                cmd.Parameters.AddWithValue("@PresAguaEnfriamiento_A_kgcm2", modelo.PresAguaEnfriamiento_A_kgcm2);
                cmd.Parameters.AddWithValue("@TempDevanadosFaseR_A", modelo.TempDevanadosFaseR_A);
                cmd.Parameters.AddWithValue("@TempDevanadosFaseS_A", modelo.TempDevanadosFaseS_A);
                cmd.Parameters.AddWithValue("@TempDevanadosFaseT_A", modelo.TempDevanadosFaseT_A);
                cmd.Parameters.AddWithValue("@BBT_B_Estado", (object?)modelo.BBT_B_Estado ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@TempAceiteReductor_B", modelo.TempAceiteReductor_B);
                cmd.Parameters.AddWithValue("@PresAceitePrincipal_B_kgcm2", modelo.PresAceitePrincipal_B_kgcm2);
                cmd.Parameters.AddWithValue("@PresNormalLubricacion_B_kgcm2", modelo.PresNormalLubricacion_B_kgcm2);
                cmd.Parameters.AddWithValue("@PresAguaEnfriamiento_B_kgcm2", modelo.PresAguaEnfriamiento_B_kgcm2);
                cmd.Parameters.AddWithValue("@TempRodamientoLadoLibre_B", modelo.TempRodamientoLadoLibre_B);
                cmd.Parameters.AddWithValue("@TempDevanadosFaseR_B", modelo.TempDevanadosFaseR_B);
                cmd.Parameters.AddWithValue("@TempDevanadosFaseS_B", modelo.TempDevanadosFaseS_B);
                cmd.Parameters.AddWithValue("@TempDevanadosFaseT_B", modelo.TempDevanadosFaseT_B);
                cmd.Parameters.AddWithValue("@TempRodamientoLadoAcople_B", modelo.TempRodamientoLadoAcople_B);
                cmd.Parameters.AddWithValue("@BBT_C_Estado", (object?)modelo.BBT_C_Estado ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@TempAceiteReductor_C", modelo.TempAceiteReductor_C);
                cmd.Parameters.AddWithValue("@PresAceitePrincipal_C_kgcm2", modelo.PresAceitePrincipal_C_kgcm2);
                cmd.Parameters.AddWithValue("@PresNormalLubricacion_C_kgcm2", modelo.PresNormalLubricacion_C_kgcm2);
                cmd.Parameters.AddWithValue("@PresAguaEnfriamiento_C_kgcm2", modelo.PresAguaEnfriamiento_C_kgcm2);
                cmd.Parameters.AddWithValue("@TempDevanadosFaseR_C", modelo.TempDevanadosFaseR_C);
                cmd.Parameters.AddWithValue("@TempDevanadosFaseS_C", modelo.TempDevanadosFaseS_C);
                cmd.Parameters.AddWithValue("@TempDevanadosFaseT_C", modelo.TempDevanadosFaseT_C);
                cmd.Parameters.AddWithValue("@BbaB_CircuitoCerrado", (object?)modelo.BbaB_CircuitoCerrado ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@BbaA_CircuitoCerrado", (object?)modelo.BbaA_CircuitoCerrado ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@PresDescargaCabezal_kgcm2", modelo.PresDescargaCabezal_kgcm2);
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