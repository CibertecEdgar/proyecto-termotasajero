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
            _connectionString = configuration.GetConnectionString("sqlConUser");
        }

        // Listar registros
        [HttpGet]
        public IActionResult Index()
        {
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
                            OperadorTurno = reader.IsDBNull(3) ? null : reader.GetString(3),
                            NivelSiloVolatilMetros = reader.GetDouble(4)
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
        public IActionResult Registrar(proyecto_termotasajero.Models.NivelSiloVolatilUnidad modelo)
        {
            if (!ModelState.IsValid)
                return View("Index", modelo);

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("Sp_InsertNivelSiloVolatilUnidad", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@HoraInicio", modelo.HoraInicio);
                cmd.Parameters.AddWithValue("@HoraFinalizacion", modelo.HoraFinalizacion);
                cmd.Parameters.AddWithValue("@OperadorTurno", (object?)modelo.OperadorTurno ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@NivelSiloVolatilMetros", modelo.NivelSiloVolatilMetros);
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