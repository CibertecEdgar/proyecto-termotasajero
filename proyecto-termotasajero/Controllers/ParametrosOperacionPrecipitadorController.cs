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
    public class ParametrosOperacionPrecipitadorController : Controller
    {
        private readonly ILogger<ParametrosOperacionPrecipitadorController> _logger;
        private readonly string? _connectionString;

        public ParametrosOperacionPrecipitadorController(ILogger<ParametrosOperacionPrecipitadorController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _connectionString = configuration.GetConnectionString("sqlConUser");
        }

        // Listar registros
        [HttpGet]
        public IActionResult Index()
        {
            var lista = new List<proyecto_termotasajero.Models.ParametrosOperacionPrecipitador>();
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("Sp_ListarParametrosOperacionPrecipitador", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var item = new proyecto_termotasajero.Models.ParametrosOperacionPrecipitador();
                        item.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                        item.FechaHoraInicio = reader.GetDateTime(reader.GetOrdinal("FechaHoraInicio"));
                        item.FechaHoraFinalizacion = reader.GetDateTime(reader.GetOrdinal("FechaHoraFinalizacion"));
                        item.Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader.GetString(reader.GetOrdinal("Email"));
                        item.NombreOperador = reader.IsDBNull(reader.GetOrdinal("NombreOperador")) ? null : reader.GetString(reader.GetOrdinal("NombreOperador"));
                        item.OperadorTurno = reader.IsDBNull(reader.GetOrdinal("OperadorTurno")) ? null : reader.GetString(reader.GetOrdinal("OperadorTurno"));
                        item.IPF14 = reader.IsDBNull(reader.GetOrdinal("IPF14")) ? null : reader.GetString(reader.GetOrdinal("IPF14"));
                        item.IPF13 = reader.IsDBNull(reader.GetOrdinal("IPF13")) ? null : reader.GetString(reader.GetOrdinal("IPF13"));
                        item.IPF15 = reader.IsDBNull(reader.GetOrdinal("IPF15")) ? null : reader.GetString(reader.GetOrdinal("IPF15"));
                        item.IPF16 = reader.IsDBNull(reader.GetOrdinal("IPF16")) ? null : reader.GetString(reader.GetOrdinal("IPF16"));
                        item.IPF12 = reader.IsDBNull(reader.GetOrdinal("IPF12")) ? null : reader.GetString(reader.GetOrdinal("IPF12"));
                        item.IPF11 = reader.IsDBNull(reader.GetOrdinal("IPF11")) ? null : reader.GetString(reader.GetOrdinal("IPF11"));
                        item.IPF10 = reader.IsDBNull(reader.GetOrdinal("IPF10")) ? null : reader.GetString(reader.GetOrdinal("IPF10"));
                        item.IPF9 = reader.IsDBNull(reader.GetOrdinal("IPF9")) ? null : reader.GetString(reader.GetOrdinal("IPF9"));
                        item.IPF5 = reader.IsDBNull(reader.GetOrdinal("IPF5")) ? null : reader.GetString(reader.GetOrdinal("IPF5"));
                        item.IPF6 = reader.IsDBNull(reader.GetOrdinal("IPF6")) ? null : reader.GetString(reader.GetOrdinal("IPF6"));
                        item.IPF7 = reader.IsDBNull(reader.GetOrdinal("IPF7")) ? null : reader.GetString(reader.GetOrdinal("IPF7"));
                        item.IPF8 = reader.IsDBNull(reader.GetOrdinal("IPF8")) ? null : reader.GetString(reader.GetOrdinal("IPF8"));
                        item.IPF4 = reader.IsDBNull(reader.GetOrdinal("IPF4")) ? null : reader.GetString(reader.GetOrdinal("IPF4"));
                        item.IPF3 = reader.IsDBNull(reader.GetOrdinal("IPF3")) ? null : reader.GetString(reader.GetOrdinal("IPF3"));
                        item.IPF2 = reader.IsDBNull(reader.GetOrdinal("IPF2")) ? null : reader.GetString(reader.GetOrdinal("IPF2"));
                        item.IPF1 = reader.IsDBNull(reader.GetOrdinal("IPF1")) ? null : reader.GetString(reader.GetOrdinal("IPF1"));
                        item.Temp1B2 = reader.GetDecimal(reader.GetOrdinal("Temp1B2"));
                        item.Nivel1B2 = reader.IsDBNull(reader.GetOrdinal("Nivel1B2")) ? null : reader.GetString(reader.GetOrdinal("Nivel1B2"));
                        item.Temp2B2 = reader.GetDecimal(reader.GetOrdinal("Temp2B2"));
                        item.Nivel2B2 = reader.IsDBNull(reader.GetOrdinal("Nivel2B2")) ? null : reader.GetString(reader.GetOrdinal("Nivel2B2"));
                        item.Temp3B2 = reader.GetDecimal(reader.GetOrdinal("Temp3B2"));
                        item.Nivel3B2 = reader.IsDBNull(reader.GetOrdinal("Nivel3B2")) ? null : reader.GetString(reader.GetOrdinal("Nivel3B2"));
                        item.Temp4B2 = reader.GetDecimal(reader.GetOrdinal("Temp4B2"));
                        item.Nivel4B2 = reader.IsDBNull(reader.GetOrdinal("Nivel4B2")) ? null : reader.GetString(reader.GetOrdinal("Nivel4B2"));
                        item.Temp4B1 = reader.GetDecimal(reader.GetOrdinal("Temp4B1"));
                        item.Nivel4B1 = reader.IsDBNull(reader.GetOrdinal("Nivel4B1")) ? null : reader.GetString(reader.GetOrdinal("Nivel4B1"));
                        item.Temp3B1 = reader.GetDecimal(reader.GetOrdinal("Temp3B1"));
                        item.Nivel3B1 = reader.IsDBNull(reader.GetOrdinal("Nivel3B1")) ? null : reader.GetString(reader.GetOrdinal("Nivel3B1"));
                        item.Temp2B1 = reader.GetDecimal(reader.GetOrdinal("Temp2B1"));
                        item.Nivel2B1 = reader.IsDBNull(reader.GetOrdinal("Nivel2B1")) ? null : reader.GetString(reader.GetOrdinal("Nivel2B1"));
                        item.Temp1B1 = reader.GetDecimal(reader.GetOrdinal("Temp1B1"));
                        item.Nivel1B1 = reader.IsDBNull(reader.GetOrdinal("Nivel1B1")) ? null : reader.GetString(reader.GetOrdinal("Nivel1B1"));
                        item.Temp1A2 = reader.GetDecimal(reader.GetOrdinal("Temp1A2"));
                        item.Nivel1A2 = reader.IsDBNull(reader.GetOrdinal("Nivel1A2")) ? null : reader.GetString(reader.GetOrdinal("Nivel1A2"));
                        item.Temp2A2 = reader.GetDecimal(reader.GetOrdinal("Temp2A2"));
                        item.Nivel2A2 = reader.IsDBNull(reader.GetOrdinal("Nivel2A2")) ? null : reader.GetString(reader.GetOrdinal("Nivel2A2"));
                        item.Temp3A2 = reader.GetDecimal(reader.GetOrdinal("Temp3A2"));
                        item.Nivel3A2 = reader.IsDBNull(reader.GetOrdinal("Nivel3A2")) ? null : reader.GetString(reader.GetOrdinal("Nivel3A2"));
                        item.Temp4A2 = reader.GetDecimal(reader.GetOrdinal("Temp4A2"));
                        item.Nivel4A2 = reader.IsDBNull(reader.GetOrdinal("Nivel4A2")) ? null : reader.GetString(reader.GetOrdinal("Nivel4A2"));
                        item.Temp4A1 = reader.GetDecimal(reader.GetOrdinal("Temp4A1"));
                        item.Nivel4A1 = reader.IsDBNull(reader.GetOrdinal("Nivel4A1")) ? null : reader.GetString(reader.GetOrdinal("Nivel4A1"));
                        item.Temp3A1 = reader.GetDecimal(reader.GetOrdinal("Temp3A1"));
                        item.Nivel3A1 = reader.IsDBNull(reader.GetOrdinal("Nivel3A1")) ? null : reader.GetString(reader.GetOrdinal("Nivel3A1"));
                        item.Temp2A1 = reader.GetDecimal(reader.GetOrdinal("Temp2A1"));
                        item.Nivel2A1 = reader.IsDBNull(reader.GetOrdinal("Nivel2A1")) ? null : reader.GetString(reader.GetOrdinal("Nivel2A1"));
                        item.Temp1A1 = reader.GetDecimal(reader.GetOrdinal("Temp1A1"));
                        item.Nivel1A1 = reader.IsDBNull(reader.GetOrdinal("Nivel1A1")) ? null : reader.GetString(reader.GetOrdinal("Nivel1A1"));
                        item.Campo1A1_Amps = reader.GetDecimal(reader.GetOrdinal("Campo1A1_Amps"));
                        item.Campo1A1_Volts = reader.GetDecimal(reader.GetOrdinal("Campo1A1_Volts"));
                        item.Campo1A1_mA = reader.GetDecimal(reader.GetOrdinal("Campo1A1_mA"));
                        item.Campo1A1_KV = reader.GetDecimal(reader.GetOrdinal("Campo1A1_KV"));
                        item.Campo1A1_SPM = reader.IsDBNull(reader.GetOrdinal("Campo1A1_SPM")) ? null : reader.GetString(reader.GetOrdinal("Campo1A1_SPM"));
                        item.Campo1A1_KW = reader.GetDecimal(reader.GetOrdinal("Campo1A1_KW"));
                        item.Campo1A1_Deg = reader.GetDecimal(reader.GetOrdinal("Campo1A1_Deg"));
                        item.Campo1A2_Amps = reader.GetDecimal(reader.GetOrdinal("Campo1A2_Amps"));
                        item.Campo1A2_Volts = reader.GetDecimal(reader.GetOrdinal("Campo1A2_Volts"));
                        item.Campo1A2_mA = reader.GetDecimal(reader.GetOrdinal("Campo1A2_mA"));
                        item.Campo1A2_KV = reader.GetDecimal(reader.GetOrdinal("Campo1A2_KV"));
                        item.Campo1A2_SPM = reader.IsDBNull(reader.GetOrdinal("Campo1A2_SPM")) ? null : reader.GetString(reader.GetOrdinal("Campo1A2_SPM"));
                        item.Campo1A2_KW = reader.GetDecimal(reader.GetOrdinal("Campo1A2_KW"));
                        item.Campo1A2_Deg = reader.GetDecimal(reader.GetOrdinal("Campo1A2_Deg"));
                        item.Campo1B1_Amps = reader.GetDecimal(reader.GetOrdinal("Campo1B1_Amps"));
                        item.Campo1B1_Volts = reader.GetDecimal(reader.GetOrdinal("Campo1B1_Volts"));
                        item.Campo1B1_mA = reader.GetDecimal(reader.GetOrdinal("Campo1B1_mA"));
                        item.Campo1B1_KV = reader.GetDecimal(reader.GetOrdinal("Campo1B1_KV"));
                        item.Campo1B1_SPM = reader.IsDBNull(reader.GetOrdinal("Campo1B1_SPM")) ? null : reader.GetString(reader.GetOrdinal("Campo1B1_SPM"));
                        item.Campo1B1_KW = reader.GetDecimal(reader.GetOrdinal("Campo1B1_KW"));
                        item.Campo1B1_Deg = reader.GetDecimal(reader.GetOrdinal("Campo1B1_Deg"));
                        item.Campo1B2_Amps = reader.GetDecimal(reader.GetOrdinal("Campo1B2_Amps"));
                        item.Campo1B2_Volts = reader.GetDecimal(reader.GetOrdinal("Campo1B2_Volts"));
                        item.Campo1B2_mA = reader.GetDecimal(reader.GetOrdinal("Campo1B2_mA"));
                        item.Campo1B2_KV = reader.GetDecimal(reader.GetOrdinal("Campo1B2_KV"));
                        item.Campo1B2_SPM = reader.IsDBNull(reader.GetOrdinal("Campo1B2_SPM")) ? null : reader.GetString(reader.GetOrdinal("Campo1B2_SPM"));
                        item.Campo1B2_KW = reader.GetDecimal(reader.GetOrdinal("Campo1B2_KW"));
                        item.Campo1B2_Deg = reader.GetDecimal(reader.GetOrdinal("Campo1B2_Deg"));
                        item.Campo2A1_Amps = reader.GetDecimal(reader.GetOrdinal("Campo2A1_Amps"));
                        item.Campo2A1_Volts = reader.GetDecimal(reader.GetOrdinal("Campo2A1_Volts"));
                        item.Campo2A1_mA = reader.GetDecimal(reader.GetOrdinal("Campo2A1_mA"));
                        item.Campo2A1_KV = reader.GetDecimal(reader.GetOrdinal("Campo2A1_KV"));
                        item.Campo2A1_SPM = reader.IsDBNull(reader.GetOrdinal("Campo2A1_SPM")) ? null : reader.GetString(reader.GetOrdinal("Campo2A1_SPM"));
                        item.Campo2A1_KW = reader.GetDecimal(reader.GetOrdinal("Campo2A1_KW"));
                        item.Campo2A1_Deg = reader.GetDecimal(reader.GetOrdinal("Campo2A1_Deg"));
                        item.Campo2B2_Amps = reader.GetDecimal(reader.GetOrdinal("Campo2B2_Amps"));
                        item.Campo2B2_Volts = reader.GetDecimal(reader.GetOrdinal("Campo2B2_Volts"));
                        item.Campo2B2_mA = reader.GetDecimal(reader.GetOrdinal("Campo2B2_mA"));
                        item.Campo2B2_KV = reader.GetDecimal(reader.GetOrdinal("Campo2B2_KV"));
                        item.Campo2B2_SPM = reader.IsDBNull(reader.GetOrdinal("Campo2B2_SPM")) ? null : reader.GetString(reader.GetOrdinal("Campo2B2_SPM"));
                        item.Campo2B2_KW = reader.GetDecimal(reader.GetOrdinal("Campo2B2_KW"));
                        item.Campo2B2_Deg = reader.GetDecimal(reader.GetOrdinal("Campo2B2_Deg"));
                        item.Campo2B1_Amps = reader.GetDecimal(reader.GetOrdinal("Campo2B1_Amps"));
                        item.Campo2B1_Volts = reader.GetDecimal(reader.GetOrdinal("Campo2B1_Volts"));
                        item.Campo2B1_mA = reader.GetDecimal(reader.GetOrdinal("Campo2B1_mA"));
                        item.Campo2B1_KV = reader.GetDecimal(reader.GetOrdinal("Campo2B1_KV"));
                        item.Campo2B1_SPM = reader.IsDBNull(reader.GetOrdinal("Campo2B1_SPM")) ? null : reader.GetString(reader.GetOrdinal("Campo2B1_SPM"));
                        item.Campo2B1_KW = reader.GetDecimal(reader.GetOrdinal("Campo2B1_KW"));
                        item.Campo2B1_Deg = reader.GetDecimal(reader.GetOrdinal("Campo2B1_Deg"));
                        item.Campo2A2_Amps = reader.GetDecimal(reader.GetOrdinal("Campo2A2_Amps"));
                        item.Campo2A2_Volts = reader.GetDecimal(reader.GetOrdinal("Campo2A2_Volts"));
                        item.Campo2A2_mA = reader.GetDecimal(reader.GetOrdinal("Campo2A2_mA"));
                        item.Campo2A2_KV = reader.GetDecimal(reader.GetOrdinal("Campo2A2_KV"));
                        item.Campo2A2_SPM = reader.IsDBNull(reader.GetOrdinal("Campo2A2_SPM")) ? null : reader.GetString(reader.GetOrdinal("Campo2A2_SPM"));
                        item.Campo2A2_KW = reader.GetDecimal(reader.GetOrdinal("Campo2A2_KW"));
                        item.Campo2A2_Deg = reader.GetDecimal(reader.GetOrdinal("Campo2A2_Deg"));
                        item.Campo3A1_Amps = reader.GetDecimal(reader.GetOrdinal("Campo3A1_Amps"));
                        item.Campo3A1_Volts = reader.GetDecimal(reader.GetOrdinal("Campo3A1_Volts"));
                        item.Campo3A1_mA = reader.GetDecimal(reader.GetOrdinal("Campo3A1_mA"));
                        item.Campo3A1_KV = reader.GetDecimal(reader.GetOrdinal("Campo3A1_KV"));
                        item.Campo3A1_SCR = reader.IsDBNull(reader.GetOrdinal("Campo3A1_SCR")) ? null : reader.GetString(reader.GetOrdinal("Campo3A1_SCR"));
                        item.Campo3A1_KW = reader.GetDecimal(reader.GetOrdinal("Campo3A1_KW"));
                        item.Campo3A1_SM = reader.IsDBNull(reader.GetOrdinal("Campo3A1_SM")) ? null : reader.GetString(reader.GetOrdinal("Campo3A1_SM"));
                        item.Campo3A2_Amps = reader.GetDecimal(reader.GetOrdinal("Campo3A2_Amps"));
                        item.Campo3A2_Volts = reader.GetDecimal(reader.GetOrdinal("Campo3A2_Volts"));
                        item.Campo3A2_mA = reader.GetDecimal(reader.GetOrdinal("Campo3A2_mA"));
                        item.Campo3A2_KV = reader.GetDecimal(reader.GetOrdinal("Campo3A2_KV"));
                        item.Campo3A2_SCR = reader.IsDBNull(reader.GetOrdinal("Campo3A2_SCR")) ? null : reader.GetString(reader.GetOrdinal("Campo3A2_SCR"));
                        item.Campo3A2_KW = reader.GetDecimal(reader.GetOrdinal("Campo3A2_KW"));
                        item.Campo3A2_SM = reader.IsDBNull(reader.GetOrdinal("Campo3A2_SM")) ? null : reader.GetString(reader.GetOrdinal("Campo3A2_SM"));
                        item.Campo4A1_Amps = reader.GetDecimal(reader.GetOrdinal("Campo4A1_Amps"));
                        item.Campo4A1_Volts = reader.GetDecimal(reader.GetOrdinal("Campo4A1_Volts"));
                        item.Campo4A1_mA = reader.GetDecimal(reader.GetOrdinal("Campo4A1_mA"));
                        item.Campo4A1_KV = reader.GetDecimal(reader.GetOrdinal("Campo4A1_KV"));
                        item.Campo4A1_SCR = reader.IsDBNull(reader.GetOrdinal("Campo4A1_SCR")) ? null : reader.GetString(reader.GetOrdinal("Campo4A1_SCR"));
                        item.Campo4A1_KW = reader.GetDecimal(reader.GetOrdinal("Campo4A1_KW"));
                        item.Campo4A1_SM = reader.IsDBNull(reader.GetOrdinal("Campo4A1_SM")) ? null : reader.GetString(reader.GetOrdinal("Campo4A1_SM"));
                        item.Campo4A2_Amps = reader.GetDecimal(reader.GetOrdinal("Campo4A2_Amps"));
                        item.Campo4A2_Volts = reader.GetDecimal(reader.GetOrdinal("Campo4A2_Volts"));
                        item.Campo4A2_mA = reader.GetDecimal(reader.GetOrdinal("Campo4A2_mA"));
                        item.Campo4A2_KV = reader.GetDecimal(reader.GetOrdinal("Campo4A2_KV"));
                        item.Campo4A2_SCR = reader.IsDBNull(reader.GetOrdinal("Campo4A2_SCR")) ? null : reader.GetString(reader.GetOrdinal("Campo4A2_SCR"));
                        item.Campo4A2_KW = reader.GetDecimal(reader.GetOrdinal("Campo4A2_KW"));
                        item.Campo4A2_SM = reader.IsDBNull(reader.GetOrdinal("Campo4A2_SM")) ? null : reader.GetString(reader.GetOrdinal("Campo4A2_SM"));
                        item.Campo3B1_Amps = reader.GetDecimal(reader.GetOrdinal("Campo3B1_Amps"));
                        item.Campo3B1_Volts = reader.GetDecimal(reader.GetOrdinal("Campo3B1_Volts"));
                        item.Campo3B1_mA = reader.GetDecimal(reader.GetOrdinal("Campo3B1_mA"));
                        item.Campo3B1_KV = reader.GetDecimal(reader.GetOrdinal("Campo3B1_KV"));
                        item.Campo3B1_SCR = reader.IsDBNull(reader.GetOrdinal("Campo3B1_SCR")) ? null : reader.GetString(reader.GetOrdinal("Campo3B1_SCR"));
                        item.Campo3B1_KW = reader.GetDecimal(reader.GetOrdinal("Campo3B1_KW"));
                        item.Campo3B1_SM = reader.IsDBNull(reader.GetOrdinal("Campo3B1_SM")) ? null : reader.GetString(reader.GetOrdinal("Campo3B1_SM"));
                        item.Campo3B2_Amps = reader.GetDecimal(reader.GetOrdinal("Campo3B2_Amps"));
                        item.Campo3B2_Volts = reader.GetDecimal(reader.GetOrdinal("Campo3B2_Volts"));
                        item.Campo3B2_mA = reader.GetDecimal(reader.GetOrdinal("Campo3B2_mA"));
                        item.Campo3B2_KV = reader.GetDecimal(reader.GetOrdinal("Campo3B2_KV"));
                        item.Campo3B2_SCR = reader.IsDBNull(reader.GetOrdinal("Campo3B2_SCR")) ? null : reader.GetString(reader.GetOrdinal("Campo3B2_SCR"));
                        item.Campo3B2_KW = reader.GetDecimal(reader.GetOrdinal("Campo3B2_KW"));
                        item.Campo3B2_SM = reader.IsDBNull(reader.GetOrdinal("Campo3B2_SM")) ? null : reader.GetString(reader.GetOrdinal("Campo3B2_SM"));
                        item.Campo4B1_Amps = reader.GetDecimal(reader.GetOrdinal("Campo4B1_Amps"));
                        item.Campo4B1_Volts = reader.GetDecimal(reader.GetOrdinal("Campo4B1_Volts"));
                        item.Campo4B1_mA = reader.GetDecimal(reader.GetOrdinal("Campo4B1_mA"));
                        item.Campo4B1_KV = reader.GetDecimal(reader.GetOrdinal("Campo4B1_KV"));
                        item.Campo4B1_SCR = reader.IsDBNull(reader.GetOrdinal("Campo4B1_SCR")) ? null : reader.GetString(reader.GetOrdinal("Campo4B1_SCR"));
                        item.Campo4B1_KW = reader.GetDecimal(reader.GetOrdinal("Campo4B1_KW"));
                        item.Campo4B1_SM = reader.IsDBNull(reader.GetOrdinal("Campo4B1_SM")) ? null : reader.GetString(reader.GetOrdinal("Campo4B1_SM"));
                        item.Campo4B2_Amps = reader.GetDecimal(reader.GetOrdinal("Campo4B2_Amps"));
                        item.Campo4B2_Volts = reader.GetDecimal(reader.GetOrdinal("Campo4B2_Volts"));
                        item.Campo4B2_mA = reader.GetDecimal(reader.GetOrdinal("Campo4B2_mA"));
                        item.Campo4B2_KV = reader.GetDecimal(reader.GetOrdinal("Campo4B2_KV"));
                        item.Campo4B2_SCR = reader.IsDBNull(reader.GetOrdinal("Campo4B2_SCR")) ? null : reader.GetString(reader.GetOrdinal("Campo4B2_SCR"));
                        item.Campo4B2_KW = reader.GetDecimal(reader.GetOrdinal("Campo4B2_KW"));
                        item.Campo4B2_SM = reader.IsDBNull(reader.GetOrdinal("Campo4B2_SM")) ? null : reader.GetString(reader.GetOrdinal("Campo4B2_SM"));
                        item.Observaciones = reader.IsDBNull(reader.GetOrdinal("Observaciones")) ? null : reader.GetString(reader.GetOrdinal("Observaciones"));
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

        // Registrar nuevo registro usando Store Procedure
        [HttpPost]
        public IActionResult Registrar(proyecto_termotasajero.Models.ParametrosOperacionPrecipitador modelo)
        {
            if (!ModelState.IsValid)
                return View("Registrar", modelo);

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("Sp_InsertParametrosOperacionPrecipitador", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FechaHoraInicio", modelo.FechaHoraInicio);
                cmd.Parameters.AddWithValue("@FechaHoraFinalizacion", modelo.FechaHoraFinalizacion);
                cmd.Parameters.AddWithValue("@Email", (object?)modelo.Email ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@NombreOperador", (object?)modelo.NombreOperador ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@OperadorTurno", (object?)modelo.OperadorTurno ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IPF14", (object?)modelo.IPF14 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IPF13", (object?)modelo.IPF13 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IPF15", (object?)modelo.IPF15 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IPF16", (object?)modelo.IPF16 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IPF12", (object?)modelo.IPF12 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IPF11", (object?)modelo.IPF11 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IPF10", (object?)modelo.IPF10 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IPF9", (object?)modelo.IPF9 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IPF5", (object?)modelo.IPF5 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IPF6", (object?)modelo.IPF6 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IPF7", (object?)modelo.IPF7 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IPF8", (object?)modelo.IPF8 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IPF4", (object?)modelo.IPF4 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IPF3", (object?)modelo.IPF3 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IPF2", (object?)modelo.IPF2 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IPF1", (object?)modelo.IPF1 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Temp1B2", modelo.Temp1B2);
                cmd.Parameters.AddWithValue("@Nivel1B2", (object?)modelo.Nivel1B2 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Temp2B2", modelo.Temp2B2);
                cmd.Parameters.AddWithValue("@Nivel2B2", (object?)modelo.Nivel2B2 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Temp3B2", modelo.Temp3B2);
                cmd.Parameters.AddWithValue("@Nivel3B2", (object?)modelo.Nivel3B2 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Temp4B2", modelo.Temp4B2);
                cmd.Parameters.AddWithValue("@Nivel4B2", (object?)modelo.Nivel4B2 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Temp4B1", modelo.Temp4B1);
                cmd.Parameters.AddWithValue("@Nivel4B1", (object?)modelo.Nivel4B1 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Temp3B1", modelo.Temp3B1);
                cmd.Parameters.AddWithValue("@Nivel3B1", (object?)modelo.Nivel3B1 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Temp2B1", modelo.Temp2B1);
                cmd.Parameters.AddWithValue("@Nivel2B1", (object?)modelo.Nivel2B1 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Temp1B1", modelo.Temp1B1);
                cmd.Parameters.AddWithValue("@Nivel1B1", (object?)modelo.Nivel1B1 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Temp1A2", modelo.Temp1A2);
                cmd.Parameters.AddWithValue("@Nivel1A2", (object?)modelo.Nivel1A2 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Temp2A2", modelo.Temp2A2);
                cmd.Parameters.AddWithValue("@Nivel2A2", (object?)modelo.Nivel2A2 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Temp3A2", modelo.Temp3A2);
                cmd.Parameters.AddWithValue("@Nivel3A2", (object?)modelo.Nivel3A2 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Temp4A2", modelo.Temp4A2);
                cmd.Parameters.AddWithValue("@Nivel4A2", (object?)modelo.Nivel4A2 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Temp4A1", modelo.Temp4A1);
                cmd.Parameters.AddWithValue("@Nivel4A1", (object?)modelo.Nivel4A1 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Temp3A1", modelo.Temp3A1);
                cmd.Parameters.AddWithValue("@Nivel3A1", (object?)modelo.Nivel3A1 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Temp2A1", modelo.Temp2A1);
                cmd.Parameters.AddWithValue("@Nivel2A1", (object?)modelo.Nivel2A1 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Temp1A1", modelo.Temp1A1);
                cmd.Parameters.AddWithValue("@Nivel1A1", (object?)modelo.Nivel1A1 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Campo1A1_Amps", modelo.Campo1A1_Amps);
                cmd.Parameters.AddWithValue("@Campo1A1_Volts", modelo.Campo1A1_Volts);
                cmd.Parameters.AddWithValue("@Campo1A1_mA", modelo.Campo1A1_mA);
                cmd.Parameters.AddWithValue("@Campo1A1_KV", modelo.Campo1A1_KV);
                cmd.Parameters.AddWithValue("@Campo1A1_SPM", (object?)modelo.Campo1A1_SPM ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Campo1A1_KW", modelo.Campo1A1_KW);
                cmd.Parameters.AddWithValue("@Campo1A1_Deg", modelo.Campo1A1_Deg);
                cmd.Parameters.AddWithValue("@Campo1A2_Amps", modelo.Campo1A2_Amps);
                cmd.Parameters.AddWithValue("@Campo1A2_Volts", modelo.Campo1A2_Volts);
                cmd.Parameters.AddWithValue("@Campo1A2_mA", modelo.Campo1A2_mA);
                cmd.Parameters.AddWithValue("@Campo1A2_KV", modelo.Campo1A2_KV);
                cmd.Parameters.AddWithValue("@Campo1A2_SPM", (object?)modelo.Campo1A2_SPM ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Campo1A2_KW", modelo.Campo1A2_KW);
                cmd.Parameters.AddWithValue("@Campo1A2_Deg", modelo.Campo1A2_Deg);
                cmd.Parameters.AddWithValue("@Campo1B1_Amps", modelo.Campo1B1_Amps);
                cmd.Parameters.AddWithValue("@Campo1B1_Volts", modelo.Campo1B1_Volts);
                cmd.Parameters.AddWithValue("@Campo1B1_mA", modelo.Campo1B1_mA);
                cmd.Parameters.AddWithValue("@Campo1B1_KV", modelo.Campo1B1_KV);
                cmd.Parameters.AddWithValue("@Campo1B1_SPM", (object?)modelo.Campo1B1_SPM ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Campo1B1_KW", modelo.Campo1B1_KW);
                cmd.Parameters.AddWithValue("@Campo1B1_Deg", modelo.Campo1B1_Deg);
                cmd.Parameters.AddWithValue("@Campo1B2_Amps", modelo.Campo1B2_Amps);
                cmd.Parameters.AddWithValue("@Campo1B2_Volts", modelo.Campo1B2_Volts);
                cmd.Parameters.AddWithValue("@Campo1B2_mA", modelo.Campo1B2_mA);
                cmd.Parameters.AddWithValue("@Campo1B2_KV", modelo.Campo1B2_KV);
                cmd.Parameters.AddWithValue("@Campo1B2_SPM", (object?)modelo.Campo1B2_SPM ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Campo1B2_KW", modelo.Campo1B2_KW);
                cmd.Parameters.AddWithValue("@Campo1B2_Deg", modelo.Campo1B2_Deg);
                cmd.Parameters.AddWithValue("@Campo2A1_Amps", modelo.Campo2A1_Amps);
                cmd.Parameters.AddWithValue("@Campo2A1_Volts", modelo.Campo2A1_Volts);
                cmd.Parameters.AddWithValue("@Campo2A1_mA", modelo.Campo2A1_mA);
                cmd.Parameters.AddWithValue("@Campo2A1_KV", modelo.Campo2A1_KV);
                cmd.Parameters.AddWithValue("@Campo2A1_SPM", (object?)modelo.Campo2A1_SPM ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Campo2A1_KW", modelo.Campo2A1_KW);
                cmd.Parameters.AddWithValue("@Campo2A1_Deg", modelo.Campo2A1_Deg);
                cmd.Parameters.AddWithValue("@Campo2B2_Amps", modelo.Campo2B2_Amps);
                cmd.Parameters.AddWithValue("@Campo2B2_Volts", modelo.Campo2B2_Volts);
                cmd.Parameters.AddWithValue("@Campo2B2_mA", modelo.Campo2B2_mA);
                cmd.Parameters.AddWithValue("@Campo2B2_KV", modelo.Campo2B2_KV);
                cmd.Parameters.AddWithValue("@Campo2B2_SPM", (object?)modelo.Campo2B2_SPM ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Campo2B2_KW", modelo.Campo2B2_KW);
                cmd.Parameters.AddWithValue("@Campo2B2_Deg", modelo.Campo2B2_Deg);
                cmd.Parameters.AddWithValue("@Campo2B1_Amps", modelo.Campo2B1_Amps);
                cmd.Parameters.AddWithValue("@Campo2B1_Volts", modelo.Campo2B1_Volts);
                cmd.Parameters.AddWithValue("@Campo2B1_mA", modelo.Campo2B1_mA);
                cmd.Parameters.AddWithValue("@Campo2B1_KV", modelo.Campo2B1_KV);
                cmd.Parameters.AddWithValue("@Campo2B1_SPM", (object?)modelo.Campo2B1_SPM ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Campo2B1_KW", modelo.Campo2B1_KW);
                cmd.Parameters.AddWithValue("@Campo2B1_Deg", modelo.Campo2B1_Deg);
                cmd.Parameters.AddWithValue("@Campo2A2_Amps", modelo.Campo2A2_Amps);
                cmd.Parameters.AddWithValue("@Campo2A2_Volts", modelo.Campo2A2_Volts);
                cmd.Parameters.AddWithValue("@Campo2A2_mA", modelo.Campo2A2_mA);
                cmd.Parameters.AddWithValue("@Campo2A2_KV", modelo.Campo2A2_KV);
                cmd.Parameters.AddWithValue("@Campo2A2_SPM", (object?)modelo.Campo2A2_SPM ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Campo2A2_KW", modelo.Campo2A2_KW);
                cmd.Parameters.AddWithValue("@Campo2A2_Deg", modelo.Campo2A2_Deg);
                cmd.Parameters.AddWithValue("@Campo3A1_Amps", modelo.Campo3A1_Amps);
                cmd.Parameters.AddWithValue("@Campo3A1_Volts", modelo.Campo3A1_Volts);
                cmd.Parameters.AddWithValue("@Campo3A1_mA", modelo.Campo3A1_mA);
                cmd.Parameters.AddWithValue("@Campo3A1_KV", modelo.Campo3A1_KV);
                cmd.Parameters.AddWithValue("@Campo3A1_SCR", (object?)modelo.Campo3A1_SCR ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Campo3A1_KW", modelo.Campo3A1_KW);
                cmd.Parameters.AddWithValue("@Campo3A1_SM", (object?)modelo.Campo3A1_SM ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Campo3A2_Amps", modelo.Campo3A2_Amps);
                cmd.Parameters.AddWithValue("@Campo3A2_Volts", modelo.Campo3A2_Volts);
                cmd.Parameters.AddWithValue("@Campo3A2_mA", modelo.Campo3A2_mA);
                cmd.Parameters.AddWithValue("@Campo3A2_KV", modelo.Campo3A2_KV);
                cmd.Parameters.AddWithValue("@Campo3A2_SCR", (object?)modelo.Campo3A2_SCR ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Campo3A2_KW", modelo.Campo3A2_KW);
                cmd.Parameters.AddWithValue("@Campo3A2_SM", (object?)modelo.Campo3A2_SM ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Campo4A1_Amps", modelo.Campo4A1_Amps);
                cmd.Parameters.AddWithValue("@Campo4A1_Volts", modelo.Campo4A1_Volts);
                cmd.Parameters.AddWithValue("@Campo4A1_mA", modelo.Campo4A1_mA);
                cmd.Parameters.AddWithValue("@Campo4A1_KV", modelo.Campo4A1_KV);
                cmd.Parameters.AddWithValue("@Campo4A1_SCR", (object?)modelo.Campo4A1_SCR ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Campo4A1_KW", modelo.Campo4A1_KW);
                cmd.Parameters.AddWithValue("@Campo4A1_SM", (object?)modelo.Campo4A1_SM ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Campo4A2_Amps", modelo.Campo4A2_Amps);
                cmd.Parameters.AddWithValue("@Campo4A2_Volts", modelo.Campo4A2_Volts);
                cmd.Parameters.AddWithValue("@Campo4A2_mA", modelo.Campo4A2_mA);
                cmd.Parameters.AddWithValue("@Campo4A2_KV", modelo.Campo4A2_KV);
                cmd.Parameters.AddWithValue("@Campo4A2_SCR", (object?)modelo.Campo4A2_SCR ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Campo4A2_KW", modelo.Campo4A2_KW);
                cmd.Parameters.AddWithValue("@Campo4A2_SM", (object?)modelo.Campo4A2_SM ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Campo3B1_Amps", modelo.Campo3B1_Amps);
                cmd.Parameters.AddWithValue("@Campo3B1_Volts", modelo.Campo3B1_Volts);
                cmd.Parameters.AddWithValue("@Campo3B1_mA", modelo.Campo3B1_mA);
                cmd.Parameters.AddWithValue("@Campo3B1_KV", modelo.Campo3B1_KV);
                cmd.Parameters.AddWithValue("@Campo3B1_SCR", (object?)modelo.Campo3B1_SCR ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Campo3B1_KW", modelo.Campo3B1_KW);
                cmd.Parameters.AddWithValue("@Campo3B1_SM", (object?)modelo.Campo3B1_SM ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Campo3B2_Amps", modelo.Campo3B2_Amps);
                cmd.Parameters.AddWithValue("@Campo3B2_Volts", modelo.Campo3B2_Volts);
                cmd.Parameters.AddWithValue("@Campo3B2_mA", modelo.Campo3B2_mA);
                cmd.Parameters.AddWithValue("@Campo3B2_KV", modelo.Campo3B2_KV);
                cmd.Parameters.AddWithValue("@Campo3B2_SCR", (object?)modelo.Campo3B2_SCR ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Campo3B2_KW", modelo.Campo3B2_KW);
                cmd.Parameters.AddWithValue("@Campo3B2_SM", (object?)modelo.Campo3B2_SM ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Campo4B1_Amps", modelo.Campo4B1_Amps);
                cmd.Parameters.AddWithValue("@Campo4B1_Volts", modelo.Campo4B1_Volts);
                cmd.Parameters.AddWithValue("@Campo4B1_mA", modelo.Campo4B1_mA);
                cmd.Parameters.AddWithValue("@Campo4B1_KV", modelo.Campo4B1_KV);
                cmd.Parameters.AddWithValue("@Campo4B1_SCR", (object?)modelo.Campo4B1_SCR ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Campo4B1_KW", modelo.Campo4B1_KW);
                cmd.Parameters.AddWithValue("@Campo4B1_SM", (object?)modelo.Campo4B1_SM ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Campo4B2_Amps", modelo.Campo4B2_Amps);
                cmd.Parameters.AddWithValue("@Campo4B2_Volts", modelo.Campo4B2_Volts);
                cmd.Parameters.AddWithValue("@Campo4B2_mA", modelo.Campo4B2_mA);
                cmd.Parameters.AddWithValue("@Campo4B2_KV", modelo.Campo4B2_KV);
                cmd.Parameters.AddWithValue("@Campo4B2_SCR", (object?)modelo.Campo4B2_SCR ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Campo4B2_KW", modelo.Campo4B2_KW);
                cmd.Parameters.AddWithValue("@Campo4B2_SM", (object?)modelo.Campo4B2_SM ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Observaciones", (object?)modelo.Observaciones ?? DBNull.Value);
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