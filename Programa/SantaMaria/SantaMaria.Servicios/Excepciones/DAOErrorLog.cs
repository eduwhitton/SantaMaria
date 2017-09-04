using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using SantaMaria.Servicios.Excepciones;

namespace SantaMaria.Servicios.Excepciones
{
    public class DAOErrorLog
    {

        public List<ErrorLogRow> ObtenerErrorLog()
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "Servicios.SP_ObtenerErrorLog";

            SqlCommand comando = new SqlCommand(query, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr;

            try
            {
                conexion.Open();

                dr = comando.ExecuteReader();

                List<ErrorLogRow> lista = new List<ErrorLogRow>();
                ErrorLogRow row;

                while (dr.Read())
                {
                    row = new ErrorLogRow();

                    if (!dr.HasRows) break;
                    row.mensaje = dr.GetString(dr.GetOrdinal("Message"));
                    row.fecha = dr.GetDateTime(dr.GetOrdinal("ErrorDate"));
                    row.excepcion = dr.GetString(dr.GetOrdinal("Exception"));
                    if (!dr.IsDBNull(dr.GetOrdinal("Usuario")))
                        row.usuario = dr.GetString(dr.GetOrdinal("Usuario"));
                    if (!dr.IsDBNull(dr.GetOrdinal("IpAddress")))
                        row.ip = dr.GetString(dr.GetOrdinal("IpAddress"));

                    lista.Add(row);
                }

                conexion.Close();

                return lista;
            }
            catch (Exception ex)
            {
                conexion.Close();
                throw new Excepciones.BLLException("Error al obtener los log de error de la base de datos", ex);
            }
        }


        /// <summary>
        /// Filtra 200 entradas del ErrorLog por Fecha, Usuario o actividad.
        /// </summary>
        public List<ErrorLogRow> ObtenerErrorLogFiltrado(DateTime fechaDesde, DateTime fechaHasta, string usuario, string actividad)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "Servicios.SP_ObtenerErrorLogFiltrado";

            SqlCommand comando = new SqlCommand(query, conexion);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@FechaDesde", fechaDesde.Date);
            comando.Parameters.AddWithValue("@FechaHasta", fechaHasta.Date.AddDays(1)); ///Corrección para que tome hasta el final del día (o el comienzo del siguiente)
            comando.Parameters.AddWithValue("@Usuario", usuario);
            comando.Parameters.AddWithValue("@Mensaje", actividad);
            SqlDataReader dr;

            try
            {
                conexion.Open();

                dr = comando.ExecuteReader();

                List<ErrorLogRow> lista = new List<ErrorLogRow>();
                ErrorLogRow row;

                while (dr.Read())
                {
                    row = new ErrorLogRow();

                    if (!dr.HasRows) break;
                    row.mensaje = dr.GetString(dr.GetOrdinal("Message"));
                    row.fecha = dr.GetDateTime(dr.GetOrdinal("ErrorDate"));
                    row.excepcion = dr.GetString(dr.GetOrdinal("Exception"));
                    if (!dr.IsDBNull(dr.GetOrdinal("Usuario")))
                        row.usuario = dr.GetString(dr.GetOrdinal("Usuario"));
                    if (!dr.IsDBNull(dr.GetOrdinal("IpAddress")))
                        row.ip = dr.GetString(dr.GetOrdinal("IpAddress"));

                    lista.Add(row);
                }

                conexion.Close();

                return lista;
            }
            catch (Exception ex)
            {
                conexion.Close();
                throw new Excepciones.BLLException("Error al obtener el ErrorLog de la base de datos", ex);
            }
        }


    }
    public class ErrorLogRow
    {
        public DateTime fecha;
        public string mensaje;
        public string excepcion;
        public string usuario;
        public string ip;
    }
}
