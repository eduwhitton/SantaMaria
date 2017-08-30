using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SantaMaria.Entidades;
using System.Data.SqlClient;
using SantaMaria.Servicios.Seguridad.Entidades;

namespace SantaMaria.Servicios.Seguridad.Dal
{
    class DAOPatente
    {
        /// <summary>
        /// Clase encargada del acceso de los datos en la Base de datos
        /// </summary>
        public void AgregarPatente(Patente patente)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = @"INSERT INTO [Servicios].[Patentes]
           ([ID]
           ,[Nombre]
           ,[Descripcion]
           ,[CreatedOn]
           ,[CreatedBy]
           ,[Deleted])
     VALUES
           (@ID
           ,@Nombre
           ,@Descripcion
           ,@CreatedOn
           ,@CreatedBy
           ,@Deleted)";

            SqlCommand comando = new SqlCommand(query, conexion);

            comando.Parameters.AddWithValue("@ID", Guid.NewGuid());
            comando.Parameters.AddWithValue("@Nombre", patente.NombreComponente);
            comando.Parameters.AddWithValue("@Descripcion", patente.DescripcionComponente);
            comando.Parameters.AddWithValue("@CreatedOn", DateTime.Now);
            comando.Parameters.AddWithValue("@CreatedBy", Contexto.UsuarioActual.Id);
            comando.Parameters.AddWithValue("@Deleted",false);

            try
            {
                conexion.Open();

                comando.ExecuteNonQuery();

                conexion.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Patente ObtenerPorNombre(string nombre)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "SELECT * FROM [Servicios].[Patentes]" +
            "WHERE Nombre = @Nombre AND DELETED = 0";

            SqlCommand comando = new SqlCommand(query, conexion);

            comando.Parameters.AddWithValue("@Nombre", nombre);


            SqlDataReader dr;

            try
            {
                conexion.Open();

                dr = comando.ExecuteReader();

                dr.Read();

                ComponenteBase componente = new Patente();

                MapeadorComponenteBase.CrearComponenteBase(dr, ref componente);

                Patente patente = componente as Patente;

                conexion.Close();

                return patente;

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public List<Patente> ObtenerTodo()
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "SELECT * FROM [Servicios].[Patentes] WHERE DELETED = 0";

            SqlCommand comando = new SqlCommand(query, conexion);


            SqlDataReader dr;

            try
            {
                conexion.Open();

                dr = comando.ExecuteReader();

                List<Patente> lista = new List<Patente>();

                Patente patente;
                ComponenteBase componente;

                while (dr.Read())
                {

                    componente = new Patente();

                    MapeadorComponenteBase.CrearComponenteBase(dr, ref componente);

                    patente = componente as Patente;

                    lista.Add(patente);
                }

                conexion.Close();

                return lista;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void ModificarPatente(Patente patente)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = @"UPDATE [Servicios].[Patentes]
   SET [Nombre] = @Nombre
      ,[Descripcion] = @Descripcion
      ,[ChangedOn] = @ChangedOn
      ,[ChangedBy] = @ChangedBy
        WHERE ID = @ID";

            SqlCommand comando = new SqlCommand(query, conexion);

            comando.Parameters.AddWithValue("@ID", Guid.NewGuid());
            comando.Parameters.AddWithValue("@Nombre", patente.NombreComponente);
            comando.Parameters.AddWithValue("@Nombre", patente.DescripcionComponente);
            comando.Parameters.AddWithValue("@ChangedOn", DateTime.Now);
            comando.Parameters.AddWithValue("@ChangedBy", Contexto.UsuarioActual.Id);


            try
            {
                conexion.Open();

                comando.ExecuteNonQuery();

                conexion.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void EliminarPatente(Patente patente)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "UPDATE [Servicios].[Patentes] SET Deleted = 1, " +
                "[DeletedOn] = @DeletedOn, " +
            "[DeletedBy] = @DeletedBy WHERE ID = @ID";

            SqlCommand comando = new SqlCommand(query, conexion);

            comando.Parameters.AddWithValue("@ID", patente.Id);
            comando.Parameters.AddWithValue("@DeletedOn", DateTime.Now);
            comando.Parameters.AddWithValue("@DeletedBy", Contexto.UsuarioActual.Id);

            try
            {
                conexion.Open();

                comando.ExecuteNonQuery();

                conexion.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
