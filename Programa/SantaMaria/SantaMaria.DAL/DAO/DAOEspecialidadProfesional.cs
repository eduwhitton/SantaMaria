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
    public class DAOEspecialidadProfesional
    {

        public void AgregarEspecialidadProfesional(EspecialidadProfesional especialidadProfesional)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "dbo.Especialidades_ProfesionalesAgregar";

            SqlCommand comando = new SqlCommand(query, conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@ID", Guid.NewGuid());
            comando.Parameters.AddWithValue("@Cod_Especialidad", especialidadProfesional.CodEspecialidad);
            comando.Parameters.AddWithValue("@Nro_Matricula", especialidadProfesional.NroMatricula);
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

                throw new DALException("Error al crear una especialidadProfesional.", ex);
            }
        }

        
        public EspecialidadProfesional ObtenerPorID(Guid id)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "dbo.Especialidades_ProfesionalesObtenerPorId";

            SqlCommand comando = new SqlCommand(query, conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@ID", id);

            SqlDataReader dr;

            try
            {
                conexion.Open();

                dr = comando.ExecuteReader();

                dr.Read();

                EntidadBase entidad = new EspecialidadProfesional();

                Mapeadores.MapeadorEntidad.RellenarEntidad(dr, ref entidad);

                EspecialidadProfesional especialidadProfesional = entidad as EspecialidadProfesional;

                Mapeador.DataReaderAEspecialidadProfesional(dr, ref especialidadProfesional);

                conexion.Close();

                return especialidadProfesional;

            }
            catch (Exception ex)
            {
                conexion.Close();

                throw new DALException("Error al crear obtener una especialidadProfesional por Id.", ex);
            }
        }

        public List<EspecialidadProfesional> ObtenerPorNroMatricula(int nroMatricula)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "dbo.Especialidades_ProfesionalesObtenerPorNro_Matricula";

            SqlCommand comando = new SqlCommand(query, conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@Nro_Matricula", nroMatricula);

            SqlDataReader dr;

            List<EspecialidadProfesional> lista = new List<EspecialidadProfesional>();

            try
            {
                conexion.Open();

                dr = comando.ExecuteReader();


                EspecialidadProfesional especialidadProfesional;
                EntidadBase entidad;

                while (dr.Read())
                {
                    entidad = new EspecialidadProfesional();

                    Mapeadores.MapeadorEntidad.RellenarEntidad(dr, ref entidad);

                    especialidadProfesional = entidad as EspecialidadProfesional;

                    Mapeador.DataReaderAEspecialidadProfesional(dr, ref especialidadProfesional);

                    lista.Add(especialidadProfesional);
                }

                conexion.Close();

                return lista;

            }
            catch (Exception ex)
            {
                conexion.Close();

                throw new DALException("Error al obtener todos los especialidadProfesionals.", ex);
            }

        }

        public void ModificarEspecialidadProfesional(EspecialidadProfesional especialidadProfesional)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "dbo.Especialidades_ProfesionalesModificar";

            SqlCommand comando = new SqlCommand(query, conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;


            comando.Parameters.AddWithValue("@ID", especialidadProfesional.Id); 
            comando.Parameters.AddWithValue("@Cod_Especialidad", especialidadProfesional.CodEspecialidad);
            comando.Parameters.AddWithValue("@Nro_Matricula", especialidadProfesional.NroMatricula);
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

                throw new DALException("Error al modificar una especialidadProfesional.", ex);
            }
        }

        public void EliminarEspecialidadProfesional(EspecialidadProfesional especialidadProfesional)
        {

            SqlConnection conexion = Conexion.Instancia;

            string query = "dbo.Especialidades_ProfesionalesEliminar";

            SqlCommand comando = new SqlCommand(query, conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@ID", especialidadProfesional.Id);
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

                throw new DALException("Error al eliminar una especialidadProfesional.", ex);
            }
        }

    }
}
