using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace SantaMaria.Servicios.MultiIdiioma
{
    /// <summary>
    /// Clase que accede a los idiomas en la base de datos
    /// </summary>
    public class DAOMultiidioma
    {
        public Dictionary<string,string> ObtenerDiccionarioIdioma(string idioma)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "Servicios.SP_ObtenerDiccionarioIdioma";

            SqlCommand comando = new SqlCommand(query, conexion);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@Idioma", idioma);
            
            SqlDataReader dr;

            Dictionary<string, string> dic = new Dictionary<string, string>();

            try
            {
                conexion.Open();

                dr = comando.ExecuteReader();

                while (dr.Read())
                {
                    dic.Add(dr.GetString(0), dr.GetString(1));
                }

                conexion.Close();

                return dic;

            }
            catch (Exception ex)
            {
                conexion.Close();
                throw new Excepciones.BLLException("Error al obtener un usuario en la base de datos", ex);
            }
            finally
            {
                conexion.Close();
            }
        }
        public List<string> ObtenerIdiomas()
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "Servicios.SP_ObtenerIdiomas";

            SqlCommand comando = new SqlCommand(query, conexion);
            comando.CommandType = CommandType.StoredProcedure;

            SqlDataReader dr;

            List<string> lista = new List<string>();

            try
            {
                conexion.Open();

                dr = comando.ExecuteReader();


                while (dr.Read())
                {
                    lista.Add(dr.GetString(0));
                }

                conexion.Close();


            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conexion.Close();
            }


            return lista;
        }
    }
}
