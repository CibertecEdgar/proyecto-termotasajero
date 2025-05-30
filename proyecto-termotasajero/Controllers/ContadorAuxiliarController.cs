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
    public class ContadorAuxiliarController : Controller
    {
        private readonly ILogger<ContadorAuxiliarController> _logger;
        private readonly string? _connectionString;

        public ContadorAuxiliarController(ILogger<ContadorAuxiliarController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _connectionString = configuration.GetConnectionString("sqlConUser");
        }

        // Listar registros usando procedimiento almacenado
        [HttpGet]
        public IActionResult Index()
        {
            var lista = new List<proyecto_termotasajero.Models.ContadorAuxiliar>();
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("ListarContadoresAuxiliares", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new proyecto_termotasajero.Models.ContadorAuxiliar
                        {
                            ID = reader.GetInt32(reader.GetOrdinal("ID")),
                            HoraInicio = reader.GetDateTime(reader.GetOrdinal("HoraInicio")),
                            HoraFinalizacion = reader.GetDateTime(reader.GetOrdinal("HoraFinalizacion")),
                            CorreoElectronico = reader.IsDBNull(reader.GetOrdinal("CorreoElectronico")) ? null : reader.GetString(reader.GetOrdinal("CorreoElectronico")),
                            Nombre = reader.IsDBNull(reader.GetOrdinal("Nombre")) ? null : reader.GetString(reader.GetOrdinal("Nombre")),
                            FechaDeCorte = reader.GetDateTime(reader.GetOrdinal("FechaDeCorte")),
                            Operador = reader.IsDBNull(reader.GetOrdinal("Operador")) ? null : reader.GetString(reader.GetOrdinal("Operador")),
                            ContadorAguaServicios = reader.GetDouble(reader.GetOrdinal("ContadorAguaServicios")),
                            ContadorACPM = reader.GetDouble(reader.GetOrdinal("ContadorACPM")),
                            ContadorAguaPotable = reader.GetDouble(reader.GetOrdinal("ContadorAguaPotable")),
                            ContadorAguaDEMI = reader.GetDouble(reader.GetOrdinal("ContadorAguaDEMI")),
                            ContadorAguaDescargadorRotatorio = reader.GetDouble(reader.GetOrdinal("ContadorAguaDescargadorRotatorio"))
                        });
                    }
                }
            }
            return View(lista);
        }

        // Registrar nuevo registro usando procedimiento almacenado
        [HttpPost]
        public IActionResult Registrar(proyecto_termotasajero.Models.ContadorAuxiliar modelo)
        {
            if (!ModelState.IsValid)
                return View("Index", modelo);

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("Sp_InsertContadorAuxiliar", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@HoraInicio", modelo.HoraInicio);
                cmd.Parameters.AddWithValue("@HoraFinalizacion", modelo.HoraFinalizacion);
                cmd.Parameters.AddWithValue("@CorreoElectronico", (object?)modelo.CorreoElectronico ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Nombre", (object?)modelo.Nombre ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@FechaDeCorte", modelo.FechaDeCorte);
                cmd.Parameters.AddWithValue("@Operador", (object?)modelo.Operador ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ContadorAguaServicios", modelo.ContadorAguaServicios);
                cmd.Parameters.AddWithValue("@ContadorACPM", modelo.ContadorACPM);
                cmd.Parameters.AddWithValue("@ContadorAguaPotable", modelo.ContadorAguaPotable);
                cmd.Parameters.AddWithValue("@ContadorAguaDEMI", modelo.ContadorAguaDEMI);
                cmd.Parameters.AddWithValue("@ContadorAguaDescargadorRotatorio", modelo.ContadorAguaDescargadorRotatorio);
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
