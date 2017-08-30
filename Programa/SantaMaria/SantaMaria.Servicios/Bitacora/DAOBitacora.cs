using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using SantaMaria.Servicios.Excepciones;

namespace SantaMaria.Servicios.Bitacora
{
    public class DAOBitacora
    {

        public List<BitacoraRow> ObtenerBitacora()
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "Servicios.SP_ObtenerBitacora";

            SqlCommand comando = new SqlCommand(query, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr;

            try
            {
                conexion.Open();

                dr = comando.ExecuteReader();

                List<BitacoraRow> lista = new List<BitacoraRow>();
                BitacoraRow row;

                while (dr.Read())
                {
                    row = new BitacoraRow();

                    if (!dr.HasRows) break;
                    row.actividad = dr.GetString(dr.GetOrdinal("Activity"));
                    row.fecha = dr.GetDateTime(dr.GetOrdinal("LogDate"));
                    row.resultado = dr.GetString(dr.GetOrdinal("Result"));
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
                throw new Excepciones.BLLException("Error al obtener la bitacora de la base de datos", ex);
            }
        }


        /// <summary>
        /// Filtra 200 entradas de la bitacora por Fecha, Usuario o actividad.
        /// </summary>
        public List<BitacoraRow> ObtenerBitacoraFiltrada(DateTime fechaDesde, DateTime fechaHasta, string usuario, string actividad)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "Servicios.SP_ObtenerBitacoraFiltrada";

            SqlCommand comando = new SqlCommand(query, conexion);            
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@FechaDesde", fechaDesde);
            comando.Parameters.AddWithValue("@FechaHasta", fechaHasta.Date.AddDays(1)); ///Corrección para que tome hasta el final del día (o el comienzo del siguiente)
            comando.Parameters.AddWithValue("@Usuario", usuario);
            comando.Parameters.AddWithValue("@Actividad", actividad);
            SqlDataReader dr;

            try
            {
                conexion.Open();

                dr = comando.ExecuteReader();

                List<BitacoraRow> lista = new List<BitacoraRow>();
                BitacoraRow row;

                while (dr.Read())
                {
                    row = new BitacoraRow();

                    if (!dr.HasRows) break;
                    row.actividad = dr.GetString(dr.GetOrdinal("Activity"));
                    row.fecha = dr.GetDateTime(dr.GetOrdinal("LogDate"));
                    row.resultado = dr.GetString(dr.GetOrdinal("Result"));
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
                throw new Excepciones.BLLException("Error al obtener la bitacora de la base de datos", ex);
            }
        }


    }
    public class BitacoraRow
    {
        public DateTime fecha;
        public string actividad;
        public string resultado;
        public string usuario;
        public string ip;
    }
}
