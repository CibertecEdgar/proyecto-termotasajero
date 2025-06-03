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
            _logger.LogInformation("Entrando a Index de HorometrosMaquinariaPesadaController");
            var lista = new List<proyecto_termotasajero.Models.HorometrosMaquinariaPesada>();
            try
            {
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
                            item.HorometroCoaldozer2 = reader.GetDecimal(reader.GetOrdinal("HorometroCoaldozer2"));
                            item.HorometroCoaldozer3 = reader.GetDecimal(reader.GetOrdinal("HorometroCoaldozer3"));
                            item.HorometroCoaldozer4 = reader.GetDecimal(reader.GetOrdinal("HorometroCoaldozer4"));
                            item.HorometroCargador1 = reader.GetDecimal(reader.GetOrdinal("HorometroCargador1"));
                            item.HorometroCargador2 = reader.GetDecimal(reader.GetOrdinal("HorometroCargador2"));
                            item.HorometroClasificadoraCarbon = reader.GetDecimal(reader.GetOrdinal("HorometroClasificadoraCarbon"));
                            item.HorometroRetrocargadorKOMATSU = reader.GetDecimal(reader.GetOrdinal("HorometroRetrocargadorKOMATSU"));
                            item.HorometroMiniCargadorBOBCAT = reader.GetDecimal(reader.GetOrdinal("HorometroMiniCargadorBOBCAT"));
                            lista.Add(item);
                        }
                    }
                }
                _logger.LogInformation($"Se listaron {lista.Count} registros de HorometrosMaquinariaPesada");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al listar registros en Index de HorometrosMaquinariaPesadaController");
                return View("Error!");
            }
            return View(lista);
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            _logger.LogInformation("Entrando a Registrar (GET) de HorometrosMaquinariaPesadaController");
            return View("Registrar");
        }

        // Registrar usando procedimiento almacenado
        [HttpPost]
        public IActionResult Registrar(proyecto_termotasajero.Models.HorometrosMaquinariaPesada modelo)
        {
            _logger.LogInformation("Entrando a Registrar (POST) de HorometrosMaquinariaPesadaController");
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("ModelState inválido en Registrar (POST) de HorometrosMaquinariaPesadaController");
                return View("Index", modelo);
            }
            try
            {
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
                _logger.LogInformation($"Registro insertado correctamente para el operador: {modelo.Nombre}, inicio: {modelo.HoraInicio}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al insertar registro en Registrar (POST) de HorometrosMaquinariaPesadaController");
                return View("Error!");
            }
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            _logger.LogError("Se ha accedido a la acción Error en HorometrosMaquinariaPesadaController");
            return View("Error!");
        }
    }
}
