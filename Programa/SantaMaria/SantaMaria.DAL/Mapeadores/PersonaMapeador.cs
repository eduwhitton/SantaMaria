using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SantaMaria.Entidades;
using System.Data;
using System.Data.SqlClient;

namespace SantaMaria.DAL
{
    public class PersonaMapeador
    {
        public static void DataReaderAPersona(SqlDataReader dr, ref Persona persona)
        {
            persona.Nombre = dr.GetString(dr.GetOrdinal("Nombre"));
            persona.DNI = dr.GetInt32(dr.GetOrdinal("DNI"));
            persona.Direccion = dr.GetString(dr.GetOrdinal("Direccion"));
        }


    }
}
