using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace SantaMaria.Servicios
{
    /// <summary>
    /// Clase que contiene la instancia de la conexión de la base de datos
    /// </summary>
    public class Conexion
    {

        static SqlConnection _instancia;

        static string getConnectionString()
        {
            //return String.Format("AGUSNOTE\SQLEXPRESS;Initial Catalog=SantaMaria;Integrated Security=True");
            return ConfigurationManager.ConnectionStrings[0].ConnectionString;
        }

        public static SqlConnection Instancia
        {
            get
            {
                if (_instancia == null) _instancia = new SqlConnection(getConnectionString());
                return _instancia;
            }
        }
    }
}
