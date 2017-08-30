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
    /// <summary>
    /// Clase que loguea en la Base de datos. Implementa el patrón observador al observar cada vez que se
    /// levanta el evento de error o el evento de actividad
    /// </summary>
    public class DBLogger : ILogger
    {
        #region singleton
        private static readonly DBLogger instance = new DBLogger();

        private DBLogger() { }

        public static DBLogger Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion
        void IObservador<ErrorParameters>.Update(ErrorParameters nuevo)
        {
            InsertarError(nuevo);
        }

        void IObservador<ActivityParameters>.Update(ActivityParameters nuevo)
        {
            InsertarActividad(nuevo);
        }

        void InsertarError(ErrorParameters parametros)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query =
            @"
INSERT INTO [Audit].[ErrorLogs]
           ([ErrorDate]
           ,[Message]
           ,[Exception]
           ,[IpAddress]
           ,[CreatedOn]
           ,[CreatedBy]
           ,[ChangedOn]
           ,[ChangedBy])
     VALUES
           (@ErrorDate
           ,@Message
           ,@Exception 
           ,@IpAddress 
           ,@CreatedOn 
           ,@CreatedBy 
           ,@ChangedOn 
           ,@ChangedBy)
";
                
            SqlCommand comando = new SqlCommand(query, conexion);

            comando.Parameters.AddWithValue("@ErrorDate", parametros.ErrorDate);
            comando.Parameters.AddWithValue("@Message", parametros.Message);
            comando.Parameters.AddWithValue("@Exception", parametros.Exception.ToString().Length > 255 ? 
                parametros.Exception.ToString().Remove(255) : parametros.Exception.ToString());
            comando.Parameters.AddWithValue("@IpAddress", parametros.IpAddress);
            comando.Parameters.AddWithValue("@CreatedOn", parametros.CreatedOn ?? DateTime.Now);
            comando.Parameters.AddWithValue("@CreatedBy", (object)parametros.CreatedBy ?? DBNull.Value);
            comando.Parameters.AddWithValue("@ChangedOn", (object)parametros.ChangedOn ?? DBNull.Value);
            comando.Parameters.AddWithValue("@ChangedBy", (object)parametros.ChangedBy ?? DBNull.Value);


            try
            {
                conexion.Open();

                comando.ExecuteNonQuery();

                conexion.Close();
            }
            catch (Exception ex)
            {
                conexion.Close();
                Bitacora.Instance.EliminarLoggerDeLosEventos(Instance);
                throw new BLLException("Error al loggear en la base de datos", ex);
            }
        }   

        void InsertarActividad(ActivityParameters parametros)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query =
            @"INSERT INTO [Audit].[ActivityLogs]
           ([LogDate]
           ,[Activity]
           ,[Result]
           ,[IpAddress]
           ,[CreatedOn]
           ,[CreatedBy]
           ,[ChangedOn]
           ,[ChangedBy])
         VALUES
           (@LogDate
           ,@Activity
           ,@Result
           ,@IpAddress
           ,@CreatedOn
           ,@CreatedBy
           ,@ChangedOn
           ,@ChangedBy)
            ";

            SqlCommand comando = new SqlCommand(query, conexion);

            comando.Parameters.AddWithValue("@LogDate", parametros.LogDate);
            comando.Parameters.AddWithValue("@Activity", parametros.Activity);
            comando.Parameters.AddWithValue("@Result", parametros.Result);
            comando.Parameters.AddWithValue("@IpAddress", parametros.IpAddress);
            comando.Parameters.AddWithValue("@CreatedOn", parametros.CreatedOn ?? (object)DBNull.Value);
            comando.Parameters.AddWithValue("@CreatedBy", parametros.CreatedBy ?? (object)DBNull.Value);
            comando.Parameters.AddWithValue("@ChangedOn", parametros.ChangedOn ?? (object)DBNull.Value);
            comando.Parameters.AddWithValue("@ChangedBy", parametros.ChangedBy ?? (object)DBNull.Value);


            try
            {
                conexion.Open();

                comando.ExecuteNonQuery();

                conexion.Close();
            }
            catch (Exception ex)
            {
                conexion.Close();
                Bitacora.Instance.EliminarLoggerDeLosEventos(Instance);
                throw new BLLException("Error al loggear en la base de datos", ex);
            }
        }
    }
}
