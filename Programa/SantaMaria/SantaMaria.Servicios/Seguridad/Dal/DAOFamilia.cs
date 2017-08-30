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
    /// <summary>
    /// Clase encargada del acceso de los datos en la Base de datos
    /// </summary>
    class DAOFamilia
    {
        public void AgregarFamilia(Familia familia)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = @"INSERT INTO [Servicios].[Familias]
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
            comando.Parameters.AddWithValue("@Nombre", familia.NombreComponente);
            comando.Parameters.AddWithValue("@Descripcion", familia.DescripcionComponente);
            comando.Parameters.AddWithValue("@CreatedOn", DateTime.Now);
            comando.Parameters.AddWithValue("@CreatedBy", Contexto.UsuarioActual.Id);
            comando.Parameters.AddWithValue("@Deleted", false);


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
        public void AgregarRelacion(Familia familia, ComponenteBase componente)
        {
            SqlConnection conexion = Conexion.Instancia;
            string query = "THROW 51000, 'Formato de relación erroneo', 15; ";

            if (componente.GetType() == typeof(Patente))
            {
                query = @"INSERT INTO [Servicios].[Familias_Patentes]
           ([Id_Familia]
           ,[Id_Patente]
           ,[CreatedOn]
           ,[CreatedBy]
           ,[Deleted])
     VALUES
           (@IDContenedor
           ,@IDContenido
           ,@CreatedOn
           ,@CreatedBy
           ,@Deleted)";
            }

            if (componente.GetType() == typeof(Familia))
            {
                query = @"INSERT INTO [Servicios].[Familias_Familias]
           ([Id_FamiliaContenedora]
           ,[Id_FamiliaContenida]
           ,[CreatedOn]
           ,[CreatedBy]
           ,[Deleted])
     VALUES
           (@IDContenedor
           ,@IDContenido
           ,@CreatedOn
           ,@CreatedBy
           ,@Deleted)";
            }
            
            SqlCommand comando = new SqlCommand(query, conexion);

            comando.Parameters.AddWithValue("@IDContenedor", familia.Id);
            comando.Parameters.AddWithValue("@IDContenido", componente.Id);
            comando.Parameters.AddWithValue("@CreatedOn", DateTime.Now);
            comando.Parameters.AddWithValue("@CreatedBy", Contexto.UsuarioActual.Id);
            comando.Parameters.AddWithValue("@Deleted", false);


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

        public void EliminarRelacion(Familia familia, ComponenteBase componente)
        {
            SqlConnection conexion = Conexion.Instancia;
            string query = "THROW 51000, 'Formato de relación erroneo', 15; ";


            if (componente.GetType() == typeof(Patente))
            {
                query = @"DELETE FROM [Servicios].[Familias_Patentes]
                        WHERE [Id_Familia] = @IDContenedor 
                        AND [Id_Patente] = @IDContenido";
            }

            if (componente.GetType() == typeof(Familia))
            {
                query = @"DELETE FROM [Servicios].[Familias_Familias]
                        WHERE [Id_FamiliaContenida] = @IDContenido
                        AND [Id_FamiliaContenedora] = @IDContenedor";
            }

            SqlCommand comando = new SqlCommand(query, conexion);

            comando.Parameters.AddWithValue("@IDContenedor", familia.Id);
            comando.Parameters.AddWithValue("@IDContenido", componente.Id);
            comando.Parameters.AddWithValue("@DeletedOn", DateTime.Now);
            comando.Parameters.AddWithValue("@DeletedBy", Contexto.UsuarioActual.Id);
            comando.Parameters.AddWithValue("@Deleted", true);


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

        
        public Familia ObtenerPorNombre(string nombre)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "SELECT * FROM [Servicios].[Familias]" +
            "WHERE Nombre = @Nombre AND DELETED = 0";

            SqlCommand comando = new SqlCommand(query, conexion);

            comando.Parameters.AddWithValue("@Nombre", nombre);


            SqlDataReader dr;

            try
            {
                conexion.Open();

                dr = comando.ExecuteReader();

                dr.Read();

                ComponenteBase componente = new Familia();

                MapeadorComponenteBase.CrearComponenteBase(dr, ref componente);

                Familia familia = componente as Familia;

                conexion.Close();

                return familia;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public List<Familia> ObtenerTodo()
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "SELECT * FROM [Servicios].[Familias] WHERE DELETED = 0";

            SqlCommand comando = new SqlCommand(query, conexion);


            SqlDataReader dr;

            try
            {
                conexion.Open();

                dr = comando.ExecuteReader();

                List<Familia> lista = new List<Familia>();

                Familia familia;
                ComponenteBase componente;

                while (dr.Read())
                {

                    componente = new Familia();

                    MapeadorComponenteBase.CrearComponenteBase(dr, ref componente);

                    familia = componente as Familia;

                    lista.Add(familia);
                }

                conexion.Close();

                return lista;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<Familia> ObtenerFamilias(Familia fam)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "SELECT * FROM [Servicios].[Familias] WHERE DELETED = 0 "
                + "AND ID IN (SELECT Id_FamiliaContenida FROM [Servicios].[Familias_Familias] WHERE "
                + "DELETED = 0 AND Id_FamiliaContenedora = @ID)";

            SqlCommand comando = new SqlCommand(query, conexion);
            comando.Parameters.AddWithValue("@ID", fam.Id);

            SqlDataReader dr;

            try
            {
                conexion.Open();

                dr = comando.ExecuteReader();

                List<Familia> lista = new List<Familia>();

                Familia familia;
                ComponenteBase componente;

                while (dr.Read())
                {

                    componente = new Familia();

                    MapeadorComponenteBase.CrearComponenteBase(dr, ref componente);

                    familia = componente as Familia;

                    lista.Add(familia);
                }

                conexion.Close();

                return lista;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<Patente> ObtenerPatentes(Familia fam)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "SELECT * FROM [Servicios].[Patentes] WHERE DELETED = 0 "
                + "AND ID IN (SELECT Id_Patente FROM [Servicios].[Familias_Patentes] WHERE "
                + "DELETED = 0 AND Id_Familia = @ID)";

            SqlCommand comando = new SqlCommand(query, conexion);
            comando.Parameters.AddWithValue("@ID", fam.Id);


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

        public void ModificarFamilia(Familia familia)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = @"UPDATE [Servicios].[Familias]
   SET [Nombre] = @Nombre
      ,[Descripcion] = @Descripcion
      ,[ChangedOn] = @ChangedOn
      ,[ChangedBy] = @ChangedBy
        WHERE ID = @ID";

            SqlCommand comando = new SqlCommand(query, conexion);

            comando.Parameters.AddWithValue("@ID", Guid.NewGuid());
            comando.Parameters.AddWithValue("@Nombre", familia.NombreComponente);
            comando.Parameters.AddWithValue("@Nombre", familia.DescripcionComponente);
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

        public void EliminarFamilia(Familia familia)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "UPDATE [Servicios].[Familias] SET Deleted = 1, " +
                "[DeletedOn] = @DeletedOn, " +
            "[DeletedBy] = @DeletedBy WHERE ID = @ID";

            SqlCommand comando = new SqlCommand(query, conexion);

            comando.Parameters.AddWithValue("@ID", familia.Id);
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
