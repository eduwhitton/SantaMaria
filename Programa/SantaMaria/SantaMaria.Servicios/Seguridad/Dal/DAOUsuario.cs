using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SantaMaria.Entidades;
using System.Data.SqlClient;
using SantaMaria.Servicios.Seguridad.Entidades;
using SantaMaria.Servicios.Seguridad;

namespace SantaMaria.Servicios.Seguridad.Dal
{
    /// <summary>
    /// Clase encargada del acceso de los datos en la Base de datos
    /// </summary>  
    class DAOUsuario
    {
        public void ActualizarCheckSum(Usuario usuario)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = @"UPDATE [Servicios].[Usuarios]
   SET [CheckSum] = @CheckSum 
        WHERE ID = @ID";

            SqlCommand comando = new SqlCommand(query, conexion);

            comando.Parameters.AddWithValue("@ID", usuario.Id);
            comando.Parameters.AddWithValue("@CheckSum", CheckSum.CalcularCheckSum(usuario));

            try
            {
                conexion.Open();

                comando.ExecuteNonQuery();

                conexion.Close();
            }
            catch (Exception ex)
            {
                conexion.Close();
                throw new Excepciones.DALException("Error al actualizar el checksum en la base de datos",ex);
            }
            
        }
        public void AgregarUsuario(Usuario usuario)
        {
            SqlConnection conexion = Conexion.Instancia;

            usuario.Id = Guid.NewGuid();

            string query = @"INSERT INTO [Servicios].[Usuarios]
           ([ID]
           ,[Nombre]
           ,[Descripcion]
           ,[Usuario]
           ,[Contraseña]
           ,[Dni]
           ,[Habilitado]
           ,[CreatedOn]
           ,[CreatedBy]
           ,[Deleted]
           ,[CheckSum])
     VALUES
           (@ID
           ,@Nombre
           ,@Descripcion
           ,@Usuario
           ,@Contraseña
           ,@Dni
           ,@Habilitado
           ,@CreatedOn
           ,@CreatedBy
           ,@Deleted
           ,@CheckSum)";

            SqlCommand comando = new SqlCommand(query, conexion);

            comando.Parameters.AddWithValue("@ID", usuario.Id);
            comando.Parameters.AddWithValue("@Nombre", usuario.NombreComponente);
            comando.Parameters.AddWithValue("@Descripcion", usuario.DescripcionComponente);
            comando.Parameters.AddWithValue("@Usuario", usuario.usuario);
            comando.Parameters.AddWithValue("@Contraseña", usuario.contraseña);
            comando.Parameters.AddWithValue("@Dni", usuario.dni);
            comando.Parameters.AddWithValue("@Habilitado", usuario.habilitado);
            comando.Parameters.AddWithValue("@CreatedOn", DateTime.Now);
            comando.Parameters.AddWithValue("@CreatedBy", Contexto.UsuarioActual.Id);
            comando.Parameters.AddWithValue("@Deleted", false);
            comando.Parameters.AddWithValue("@CheckSum", CheckSum.CalcularCheckSum(usuario));

            try
            {
                conexion.Open();

                comando.ExecuteNonQuery();

                conexion.Close();
            }
            catch (Exception ex)
            {
                conexion.Close();
                throw new Excepciones.DALException("Error al agregar un usuario en la base de datos", ex);
            }
        }
        public void AgregarRelacion(Usuario usuario, ComponenteBase componente)
        {
            SqlConnection conexion = Conexion.Instancia;
            string query = "THROW 51000, 'Formato de relación erroneo', 15; ";

            if (componente.GetType() == typeof(Patente))
            {
                query = @"INSERT INTO [Servicios].[Usuarios_Patentes]
           ([Id_Usuario]
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
                query = @"INSERT INTO [Servicios].[Usuarios_Familias]
           ([Id_Usuario]
           ,[Id_Familia]
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

            comando.Parameters.AddWithValue("@IDContenedor", usuario.Id);
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
                conexion.Close();
                throw new Excepciones.DALException("Error al agregar un usuario en la base de datos", ex);
            }
        }
        public void DeshabilitarUsuario(Usuario usuario)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "UPDATE [Servicios].[Usuarios] SET Habilitado = 0 " +
                "WHERE ID = @ID";

            SqlCommand comando = new SqlCommand(query, conexion);

            comando.Parameters.AddWithValue("@ID", usuario.Id);
            try
            {
                conexion.Open();

                comando.ExecuteNonQuery();

                conexion.Close();
            }
            catch (Exception ex)
            {
                conexion.Close();
                throw new Excepciones.DALException("Error al agregar una relacion de un Usuario en la base de datos", ex);
            }
        }
        public void HabilitarUsuario(Usuario usuario)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "UPDATE [Servicios].[Usuarios] SET Habilitado = 1 " +
                "WHERE ID = @ID";

            SqlCommand comando = new SqlCommand(query, conexion);

            comando.Parameters.AddWithValue("@ID", usuario.Id);
            try
            {
                conexion.Open();

                comando.ExecuteNonQuery();

                conexion.Close();
            }
            catch (Exception ex)
            {
                conexion.Close();
                throw new Excepciones.DALException("Error al habilitar un usuario en la base de datos", ex);
            }
        }
        public void EliminarRelacion(Usuario usuario, ComponenteBase componente)
        {
            SqlConnection conexion = Conexion.Instancia;
            string query = "THROW 51000, 'Formato de relación erroneo', 15; ";


            if (componente.GetType() == typeof(Patente))
            {
                query = @"DELETE FROM [Servicios].[Usuarios_Patentes]
                        WHERE [Id_Usuario] = @IDContenedor 
                        AND [Id_Patente] = @IDContenido";
            }

            if (componente.GetType() == typeof(Familia))
            {
                query = @"DELETE FROM [Servicios].[Usuarios_Familias]
                        WHERE [Id_Usuario] = @IDContenedor
                        AND [Id_Familia] = @IDContenido";
            }

            SqlCommand comando = new SqlCommand(query, conexion);

            comando.Parameters.AddWithValue("@IDContenedor", usuario.Id);
            comando.Parameters.AddWithValue("@IDContenido", componente.Id);


            try
            {
                conexion.Open();

                comando.ExecuteNonQuery();

                conexion.Close();
            }
            catch (Exception ex)
            {
                conexion.Close();
                throw new Excepciones.DALException("Error al elminar una relacion de un usuario en la base de datos", ex);
            }
        }
        public Usuario ObtenerPorUsuario(string usu)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "SELECT * FROM [Servicios].[Usuarios]" +
            "WHERE Usuario = @Usuario AND DELETED = 0 AND Habilitado = 1";

            SqlCommand comando = new SqlCommand(query, conexion);

            comando.Parameters.AddWithValue("@Usuario", usu);

            SqlDataReader dr;

            Usuario usuario = null;

            try
            {
                conexion.Open();

                dr = comando.ExecuteReader();
                
                if (dr.Read())
                {

                ComponenteBase componente = new Usuario();

                MapeadorComponenteBase.CrearComponenteBase(dr, ref componente);

                usuario = componente as Usuario;

                MapeadorUsuario.DataReaderAUsuario(dr, ref usuario);
            }

                conexion.Close();


                return usuario;

            }
            catch (Exception ex)
            {
                conexion.Close();
                throw new Excepciones.DALException("Error al obtener un usuario en la base de datos", ex);
            }


        }
        public Usuario ObtenerPorId(Guid id)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "SELECT * FROM [Servicios].[Usuarios]" +
            "WHERE Id = @Id AND DELETED = 0";

            SqlCommand comando = new SqlCommand(query, conexion);

            comando.Parameters.AddWithValue("@Id", id);


            SqlDataReader dr;

            Usuario usuario = null;

            try
            {
                conexion.Open();

                dr = comando.ExecuteReader();

                if (dr.Read())
                {

                    ComponenteBase componente = new Usuario();

                    MapeadorComponenteBase.CrearComponenteBase(dr, ref componente);

                    usuario = componente as Usuario;

                    MapeadorUsuario.DataReaderAUsuario(dr, ref usuario);
                }

                conexion.Close();


                return usuario;

            }
            catch (Exception ex)
            {
                conexion.Close();
                throw new Excepciones.DALException("Error al obtener un usuario en la base de datos", ex);
            }
        }
        public Usuario ObtenerPorNombre(string nombre)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "SELECT * FROM [Servicios].[Usuarios]" +
            "WHERE Nombre = @Nombre AND DELETED = 0";

            SqlCommand comando = new SqlCommand(query, conexion);

            comando.Parameters.AddWithValue("@Nombre", nombre);


            SqlDataReader dr;
            Usuario usuario = null;

            try
            {
                conexion.Open();

                dr = comando.ExecuteReader();

                if (dr.Read())
                {

                    ComponenteBase componente = new Usuario();

                    MapeadorComponenteBase.CrearComponenteBase(dr, ref componente);

                    usuario = componente as Usuario;

                    MapeadorUsuario.DataReaderAUsuario(dr, ref usuario);
                }

                conexion.Close();


                return usuario;

            }
            catch (Exception ex)
            {
                conexion.Close();
                throw new Excepciones.DALException("Error al obtener un usuario en la base de datos", ex);
            }

        }
        public List<Usuario> ObtenerTodo()
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "SELECT * FROM [Servicios].[Usuarios] WHERE DELETED = 0";

            SqlCommand comando = new SqlCommand(query, conexion);


            SqlDataReader dr;

            try
            {
                conexion.Open();

                dr = comando.ExecuteReader();

                List<Usuario> lista = new List<Usuario>();

                Usuario usuario;
                ComponenteBase componente;

                while (dr.Read())
                {

                    componente = new Usuario();

                    MapeadorComponenteBase.CrearComponenteBase(dr, ref componente);

                    usuario = componente as Usuario;

                    MapeadorUsuario.DataReaderAUsuario(dr, ref usuario);

                    lista.Add(usuario);
                }

                conexion.Close();

                return lista;

            }
            catch (Exception ex)
            {
                conexion.Close();
                throw new Excepciones.DALException("Error al obtener un grupo de usuarios de la base de datos", ex);
            }

        }
        public List<Familia> ObtenerFamilias(Usuario usu)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "SELECT * FROM [Servicios].[Familias] WHERE DELETED = 0 "
                + "AND ID IN (SELECT Id_Familia FROM [Servicios].[Usuarios_Familias] WHERE "
                + "DELETED = 0 AND Id_Usuario = @ID)";

            SqlCommand comando = new SqlCommand(query, conexion);
            comando.Parameters.AddWithValue("@ID", usu.Id);

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
                conexion.Close();
                throw new Excepciones.DALException("Error al obtener las familias de un usuario en la base de datos", ex);
            }

        }
        public List<Patente> ObtenerPatentes(Usuario usu)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "SELECT * FROM [Servicios].[Patentes] WHERE DELETED = 0 "
                + "AND ID IN (SELECT Id_Patente FROM [Servicios].[Usuarios_Patentes] WHERE "
                + "DELETED = 0 AND Id_Usuario = @ID)";

            SqlCommand comando = new SqlCommand(query, conexion);
            comando.Parameters.AddWithValue("@ID", usu.Id);


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
                conexion.Close();
                throw new Excepciones.DALException("Error al obtener las patentes de un usuario en la base de datos", ex);
            }

        }
        public void ModificarUsuario(Usuario usuario)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = @"UPDATE [Servicios].[Usuarios]
   SET [Nombre] = @Nombre
      ,[Descripcion] = @Descripcion
      ,[ChangedOn] = @ChangedOn
      ,[ChangedBy] = @ChangedBy
        WHERE ID = @ID";

            SqlCommand comando = new SqlCommand(query, conexion);

            comando.Parameters.AddWithValue("@ID", Guid.NewGuid());
            comando.Parameters.AddWithValue("@Nombre", usuario.NombreComponente);
            comando.Parameters.AddWithValue("@Nombre", usuario.DescripcionComponente);
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
                conexion.Close();
                throw new Excepciones.DALException("Error al modificar un usuario en la base de datos", ex);
            }
        }
        public void EliminarUsuario(Usuario usuario)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "UPDATE [Servicios].[Usuarios] SET Deleted = 1, " +
                "[DeletedOn] = @DeletedOn, " +
            "[DeletedBy] = @DeletedBy WHERE ID = @ID";

            SqlCommand comando = new SqlCommand(query, conexion);

            comando.Parameters.AddWithValue("@ID", usuario.Id);
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
                conexion.Close();
                throw new Excepciones.DALException("Error al eliminar un usuario en la base de datos", ex);
            }
        }
    }
}