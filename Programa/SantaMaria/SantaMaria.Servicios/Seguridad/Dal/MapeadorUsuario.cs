using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SantaMaria.Servicios.Seguridad.Entidades;
using System.Data.SqlClient;

namespace SantaMaria.Servicios.Seguridad.Dal
{
    /// <summary>
    /// Clase que obtiene los datos del usuario del DataReader y los guarda en la clase usuario
    /// </summary>
    public class MapeadorUsuario
    {
        public static void DataReaderAUsuario(SqlDataReader dr, ref Usuario usuario)
        {
            usuario.Nombre = dr.GetString(dr.GetOrdinal("Nombre"));            
            usuario.DescripcionComponente = dr.GetString(dr.GetOrdinal("Descripcion"));
            usuario.usuario = dr.GetString(dr.GetOrdinal("Usuario"));            
            usuario.contraseña = dr.GetString(dr.GetOrdinal("Contraseña"));
            usuario.dni = dr.GetInt32(dr.GetOrdinal("Dni"));            
            usuario.habilitado = dr.GetBoolean(dr.GetOrdinal("Habilitado"));
            usuario.CheckSum = dr.GetString(dr.GetOrdinal("CheckSum"));
        }
    }
}
