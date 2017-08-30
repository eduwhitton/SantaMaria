using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using SantaMaria.Servicios.Seguridad.Entidades;
namespace SantaMaria.Servicios.Seguridad.Dal
{
    /// <summary>
    /// Clase que rellena los datos del componente base
    /// </summary>
    class MapeadorComponenteBase
    {

        public static void CrearComponenteBase(SqlDataReader dr, ref ComponenteBase componente)
        {
            if (!dr.HasRows) return;
            componente.Id = dr.GetGuid(dr.GetOrdinal("ID"));
            componente.NombreComponente = dr.GetString(dr.GetOrdinal("Nombre"));
            componente.DescripcionComponente = dr.GetString(dr.GetOrdinal("Descripcion"));
            componente.CreatedOn = dr.GetDateTime(dr.GetOrdinal("CreatedOn"));
            componente.CreatedBy = dr.GetGuid(dr.GetOrdinal("CreatedBy"));
            if (!dr.IsDBNull(dr.GetOrdinal("ChangedOn")))
            {
                componente.ChangedOn = dr.GetDateTime(dr.GetOrdinal("ChangedOn"));
                componente.ChangedBy = dr.GetGuid(dr.GetOrdinal("ChangedBy"));
            }
            if (!dr.IsDBNull(dr.GetOrdinal("DeletedOn")))
            {
                componente.DeletedOn = dr.GetDateTime(dr.GetOrdinal("DeletedOn"));
                componente.DeletedBy = dr.GetGuid(dr.GetOrdinal("DeletedBy"));
            }
            componente.Deleted = dr.GetBoolean(dr.GetOrdinal("Deleted"));

        }
    }
}
