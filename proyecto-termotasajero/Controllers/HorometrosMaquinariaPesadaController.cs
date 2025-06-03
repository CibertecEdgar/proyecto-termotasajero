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
    public class HorometrosMaquinariaPesadaController : Controller
    {
        private readonly ILogger<HorometrosMaquinariaPesadaController> _logger;
        private readonly string? _connectionString;

        public HorometrosMaquinariaPesadaController(ILogger<HorometrosMaquinariaPesadaController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _connectionString = configuration.GetConnectionString("sql");
        }

        // Listar registros usando procedimiento almacenado
        [HttpGet]
        public IActionResult Index()
        {
            var lista = new List<proyecto_termotasajero.Models.HorometrosMaquinariaPesada>();
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("ListarHorometrosMaquinariaPesada", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var item = new proyecto_termotasajero.Models.HorometrosMaquinariaPesada();
                        item.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                        item.HoraInicio = reader.GetDateTime(reader.GetOrdinal("HoraInicio"));
                        item.HoraFinalizacion = reader.GetDateTime(reader.GetOrdinal("HoraFinalizacion"));
                        item.CorreoElectronico = reader.IsDBNull(reader.GetOrdinal("CorreoElectronico")) ? null : reader.GetString(reader.GetOrdinal("CorreoElectronico"));
                        item.Nombre = reader.IsDBNull(reader.GetOrdinal("Nombre")) ? null : reader.GetString(reader.GetOrdinal("Nombre"));
                        item.HorometroCoaldozer2 = reader.GetDouble(reader.GetOrdinal("HorometroCoaldozer2"));
                        item.HorometroCoaldozer3 = reader.GetDouble(reader.GetOrdinal("HorometroCoaldozer3"));
                        item.HorometroCoaldozer4 = reader.GetDouble(reader.GetOrdinal("HorometroCoaldozer4"));
                        item.HorometroCargador1 = reader.GetDouble(reader.GetOrdinal("HorometroCargador1"));
                        item.HorometroCargador2 = reader.GetDouble(reader.GetOrdinal("HorometroCargador2"));
                        item.HorometroClasificadoraCarbon = reader.GetDouble(reader.GetOrdinal("HorometroClasificadoraCarbon"));
                        item.HorometroRetrocargadorKOMATSU = reader.GetDouble(reader.GetOrdinal("HorometroRetrocargadorKOMATSU"));
                        item.HorometroMiniCargadorBOBCAT = reader.GetDouble(reader.GetOrdinal("HorometroMiniCargadorBOBCAT"));
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

        // Registrar usando procedimiento almacenado
        [HttpPost]
        public IActionResult Registrar(proyecto_termotasajero.Models.HorometrosMaquinariaPesada modelo)
        {
            if (!ModelState.IsValid)
                return View("Index", modelo);

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("Sp_InsertHorometrosMaquinariaPesada", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@HoraInicio", modelo.HoraInicio);
                cmd.Parameters.AddWithValue("@HoraFinalizacion", modelo.HoraFinalizacion);
                cmd.Parameters.AddWithValue("@CorreoElectronico", (object?)modelo.CorreoElectronico ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Nombre", (object?)modelo.Nombre ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@HorometroCoaldozer2", modelo.HorometroCoaldozer2);
                cmd.Parameters.AddWithValue("@HorometroCoaldozer3", modelo.HorometroCoaldozer3);
                cmd.Parameters.AddWithValue("@HorometroCoaldozer4", modelo.HorometroCoaldozer4);
                cmd.Parameters.AddWithValue("@HorometroCargador1", modelo.HorometroCargador1);
                cmd.Parameters.AddWithValue("@HorometroCargador2", modelo.HorometroCargador2);
                cmd.Parameters.AddWithValue("@HorometroClasificadoraCarbon", modelo.HorometroClasificadoraCarbon);
                cmd.Parameters.AddWithValue("@HorometroRetrocargadorKOMATSU", modelo.HorometroRetrocargadorKOMATSU);
                cmd.Parameters.AddWithValue("@HorometroMiniCargadorBOBCAT", modelo.HorometroMiniCargadorBOBCAT);
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
