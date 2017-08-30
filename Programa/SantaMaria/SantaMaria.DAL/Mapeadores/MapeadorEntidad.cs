using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SantaMaria.Entidades;
using System.Data.SqlClient;

namespace SantaMaria.DAL.Mapeadores
{
    /// <summary>
    /// Clase que rellena los datos del la entidad base que tienen todas las entidades
    /// </summary>
    public class MapeadorEntidad
    {
        public static void CrearEntidad(SqlDataReader dr, ref EntidadBase entidad)
        {
            entidad.Id = dr.GetGuid(dr.GetOrdinal("ID"));
            entidad.CreatedOn = dr.GetDateTime(dr.GetOrdinal("CreatedOn"));
            entidad.CreatedBy = dr.GetGuid(dr.GetOrdinal("CreatedBy"));
            if (!dr.IsDBNull(dr.GetOrdinal("ChangedOn")))
            {
                entidad.ChangedOn = dr.GetDateTime(dr.GetOrdinal("ChangedOn"));
                entidad.ChangedBy = dr.GetGuid(dr.GetOrdinal("ChangedBy"));
            }
            if (!dr.IsDBNull(dr.GetOrdinal("DeletedOn")))
            {
                entidad.DeletedOn = dr.GetDateTime(dr.GetOrdinal("DeletedOn"));
                entidad.DeletedBy = dr.GetGuid(dr.GetOrdinal("DeletedBy"));
            }
            entidad.Deleted = dr.GetBoolean(dr.GetOrdinal("Deleted"));

        }
    }
}
