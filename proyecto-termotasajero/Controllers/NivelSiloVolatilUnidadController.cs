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
    public class NivelSiloVolatilUnidadController : Controller
    {
        private readonly ILogger<NivelSiloVolatilUnidadController> _logger;
        private readonly string? _connectionString;

        public NivelSiloVolatilUnidadController(ILogger<NivelSiloVolatilUnidadController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _connectionString = configuration.GetConnectionString("sql");
        }

        // Listar registros
        [HttpGet]
        public IActionResult Index()
        {
            _logger.LogInformation("Entrando a Index de NivelSiloVolatilUnidadController");
            var lista = new List<proyecto_termotasajero.Models.NivelSiloVolatilUnidad>();
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("Sp_ListarNivelSiloVolatilUnidad", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new proyecto_termotasajero.Models.NivelSiloVolatilUnidad
                        {
                            ID = reader.GetInt32(0),
                            HoraInicio = reader.GetDateTime(1),
                            HoraFinalizacion = reader.GetDateTime(2),
                            CorreoElectronico = reader.IsDBNull(3) ? null : reader.GetString(3),
                            Nombre = reader.IsDBNull(4) ? null : reader.GetString(4),
                            OperadorTurno = reader.IsDBNull(5) ? null : reader.GetString(5),
                            NivelSiloVolatilMetros = reader.GetDecimal(6)
                        });
                    }
                }
            }
            _logger.LogInformation($"Se listaron {lista.Count} registros de NivelSiloVolatilUnidad");
            return View(lista);
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            _logger.LogInformation("Entrando a Registrar (GET) de NivelSiloVolatilUnidadController");
            return View("Registrar");
        }

        // Registrar nuevo registro usando Store Procedure
        [HttpPost]
        public IActionResult Registrar(proyecto_termotasajero.Models.NivelSiloVolatilUnidad modelo)
        {
            _logger.LogInformation("Entrando a Registrar (POST) de NivelSiloVolatilUnidadController");
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("ModelState inválido en Registrar (POST) de NivelSiloVolatilUnidadController");
                return View("Index", modelo);
            }

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("Sp_InsertNivelSiloVolatilUnidad", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@HoraInicio", modelo.HoraInicio);
                cmd.Parameters.AddWithValue("@HoraFinalizacion", modelo.HoraFinalizacion);
                cmd.Parameters.AddWithValue("@CorreoElectronico", (object?)modelo.CorreoElectronico ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Nombre", (object?)modelo.Nombre ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@OperadorTurno", (object?)modelo.OperadorTurno ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@NivelSiloVolatilMetros", modelo.NivelSiloVolatilMetros);
                cmd.ExecuteNonQuery();
            }
            _logger.LogInformation($"Registro insertado correctamente para el operador: {modelo.OperadorTurno}, fecha inicio: {modelo.HoraInicio}");
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            _logger.LogError("Se ha accedido a la acción Error en NivelSiloVolatilUnidadController");
            return View("Error!");
        }
    }
}