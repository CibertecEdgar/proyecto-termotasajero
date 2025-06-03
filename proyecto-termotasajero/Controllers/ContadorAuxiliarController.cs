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
    public class ContadorAuxiliarController : Controller
    {
        private readonly ILogger<ContadorAuxiliarController> _logger;
        private readonly string? _connectionString;

        public ContadorAuxiliarController(ILogger<ContadorAuxiliarController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _connectionString = configuration.GetConnectionString("sql");
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
                        var item = new proyecto_termotasajero.Models.ContadorAuxiliar();

                        item.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                        item.HoraInicio = reader.GetDateTime(reader.GetOrdinal("HoraInicio"));
                        item.HoraFinalizacion = reader.GetDateTime(reader.GetOrdinal("HoraFinalizacion"));
                        item.CorreoElectronico = reader.IsDBNull(reader.GetOrdinal("CorreoElectronico")) ? null : reader.GetString(reader.GetOrdinal("CorreoElectronico"));
                        item.Nombre = reader.IsDBNull(reader.GetOrdinal("Nombre")) ? null : reader.GetString(reader.GetOrdinal("Nombre"));
                        item.FechaDeCorte = reader.GetDateTime(reader.GetOrdinal("FechaDeCorte"));
                        item.Operador = reader.IsDBNull(reader.GetOrdinal("Operador")) ? null : reader.GetString(reader.GetOrdinal("Operador"));
                        item.ContadorAguaServicios = reader.GetDouble(reader.GetOrdinal("ContadorAguaServicios"));
                        item.ContadorACPM = reader.GetDouble(reader.GetOrdinal("ContadorACPM"));
                        item.ContadorAguaPotable = reader.GetDouble(reader.GetOrdinal("ContadorAguaPotable"));
                        item.ContadorAguaDEMI = reader.GetDouble(reader.GetOrdinal("ContadorAguaDEMI"));
                        item.ContadorAguaDescargadorRotatorio = reader.GetDouble(reader.GetOrdinal("ContadorAguaDescargadorRotatorio"));
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
