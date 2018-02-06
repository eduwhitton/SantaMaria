using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SantaMaria.Entidades;
using System.Data.SqlClient;
using SantaMaria.Servicios;
using SantaMaria.Servicios.Excepciones;

namespace SantaMaria.DAL.DAO
{
    public class DAOEspecialidad
    {
        public void AgregarEspecialidad(Especialidad especialidad)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "[dbo].[EspecialidadesAgregar]";


            SqlCommand comando = new SqlCommand(query, conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@ID", Guid.NewGuid());
            comando.Parameters.AddWithValue("@Descripcion", especialidad.Descripcion);
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

                throw new DALException("Error al crear una especialidad.", ex);
            }
        }

        public Especialidad ObtenerPorCodEspecialidad(int CodEspecialidad)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "[dbo].[EspecialidadesObtenerPorCod_Especialidad]";

            SqlCommand comando = new SqlCommand(query, conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@Cod_Especialidad", CodEspecialidad);


            SqlDataReader dr;

            try
            {
                conexion.Open();

                dr = comando.ExecuteReader();

                dr.Read();

                EntidadBase entidad = new Especialidad();

                Mapeadores.MapeadorEntidad.RellenarEntidad(dr, ref entidad);

                Especialidad especialidad = entidad as Especialidad;

                Mapeador.DataReaderAEspecialidad(dr, ref especialidad);

                conexion.Close();

                return especialidad;

            }
            catch (Exception ex)
            {
                conexion.Close();

                throw new DALException("Error al crear obtener una especialidad por Código de especialidad.", ex);
            }


        }

        public Especialidad ObtenerPorID(Guid id)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "[dbo].[EspecialidadesObtenerPorId]";

            SqlCommand comando = new SqlCommand(query, conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@ID", id);


            SqlDataReader dr;

            try
            {
                conexion.Open();

                dr = comando.ExecuteReader();

                dr.Read();

                EntidadBase entidad = new Especialidad();

                Mapeadores.MapeadorEntidad.RellenarEntidad(dr, ref entidad);

                Especialidad especialidad = entidad as Especialidad;

                Mapeador.DataReaderAEspecialidad(dr, ref especialidad);

                conexion.Close();

                return especialidad;

            }
            catch (Exception ex)
            {
                conexion.Close();

                throw new DALException("Error al obtener una especialidad por id.", ex);
            }


        }

        public List<Especialidad> ObtenerTodo()
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "dbo.EspecialidadsObtener200";

            SqlCommand comando = new SqlCommand(query, conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;


            SqlDataReader dr;

            try
            {
                conexion.Open();

                dr = comando.ExecuteReader();

                List<Especialidad> lista = new List<Especialidad>();

                Especialidad especialidad;
                EntidadBase entidad;

                while (dr.Read())
                {

                    entidad = new Especialidad();

                    Mapeadores.MapeadorEntidad.RellenarEntidad(dr, ref entidad);

                    especialidad = entidad as Especialidad;

                    Mapeador.DataReaderAEspecialidad(dr, ref especialidad);

                    lista.Add(especialidad);
                }

                conexion.Close();

                return lista;

            }
            catch (Exception ex)
            {
                conexion.Close();

                throw new DALException("Error al obtener todas las especialidades.", ex);
            }

        }

        public void ModificarEspecialidad(Especialidad especialidad)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "[dbo].[EspecialidadesModificar]";

            SqlCommand comando = new SqlCommand(query, conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@ID", especialidad.Id);
            comando.Parameters.AddWithValue("@Cod_Especialidad", especialidad.CodEspecialidad);
            comando.Parameters.AddWithValue("@Descripcion", especialidad.Descripcion);
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

                throw new DALException("Error al modificar una especialidad.", ex);
            }
        }

        public void EliminarEspecialidad(Especialidad especialidad)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "[dbo].[EspecialidadesEliminar]";

            SqlCommand comando = new SqlCommand(query, conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@ID", especialidad.Id);
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

                throw new DALException("Error al eliminar una especialidad.", ex);
            }
        }
    }
}
