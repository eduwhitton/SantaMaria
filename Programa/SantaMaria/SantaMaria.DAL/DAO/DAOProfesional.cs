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
    public class DAOProfesional
    {

        public void AgregarProfesional(Profesional profesional)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "dbo.ProfesionalesAgregar";

            SqlCommand comando = new SqlCommand(query, conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@ID", Guid.NewGuid());
            comando.Parameters.AddWithValue("@Nombre", profesional.Nombre);
            comando.Parameters.AddWithValue("@DNI", profesional.DNI);
            comando.Parameters.AddWithValue("@Nro_Matricula", profesional.NroMatricula);
            comando.Parameters.AddWithValue("@Direccion", profesional.Direccion);
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

                throw new DALException("Error al crear una profesional.", ex);
            }
        }

        public Profesional ObtenerPorDNI(int dni)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "dbo.ProfesionalesObtenerPorDni";

            SqlCommand comando = new SqlCommand(query, conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@DNI", dni);

            SqlDataReader dr;

            try
            {
                conexion.Open();

                dr = comando.ExecuteReader();

                dr.Read();

                EntidadBase entidad = new Profesional();

                Mapeadores.MapeadorEntidad.RellenarEntidad(dr, ref entidad);

                Profesional profesional = entidad as Profesional;

                Mapeador.DataReaderAProfesional(dr, ref profesional);

                conexion.Close();

                return profesional;
            }
            catch (Exception ex)
            {
                conexion.Close();

                throw new DALException("Error al crear obtener una profesional por dni.", ex);
            }
        }

        public Profesional ObtenerPorID(Guid id)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "dbo.ProfesionalesObtenerPorId";

            SqlCommand comando = new SqlCommand(query, conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@ID", id);

            SqlDataReader dr;

            try
            {
                conexion.Open();

                dr = comando.ExecuteReader();

                dr.Read();

                EntidadBase entidad = new Profesional();

                Mapeadores.MapeadorEntidad.RellenarEntidad(dr, ref entidad);

                Profesional profesional = entidad as Profesional;

                Mapeador.DataReaderAProfesional(dr, ref profesional);

                conexion.Close();

                return profesional;

            }
            catch (Exception ex)
            {
                conexion.Close();

                throw new DALException("Error al crear obtener una profesional por Id.", ex);
            }
        }

        public List<Profesional> ObtenerTodo()
        {

            SqlConnection conexion = Conexion.Instancia;

            string query = "dbo.ProfesionalesObtener200";

            SqlCommand comando = new SqlCommand(query, conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;


            SqlDataReader dr;

            try
            {
                conexion.Open();

                dr = comando.ExecuteReader();

                List<Profesional> lista = new List<Profesional>();

                Profesional profesional;
                EntidadBase entidad;

                while (dr.Read())
                {
                    entidad = new Profesional();

                    Mapeadores.MapeadorEntidad.RellenarEntidad(dr, ref entidad);

                    profesional = entidad as Profesional;

                    Mapeador.DataReaderAProfesional(dr, ref profesional);

                    lista.Add(profesional);
                }

                conexion.Close();

                return lista;

            }
            catch (Exception ex)
            {
                conexion.Close();

                throw new DALException("Error al obtener todos los profesionals.", ex);
            }

        }

        public void ModificarProfesional(Profesional profesional)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "dbo.ProfesionalesModificar";

            SqlCommand comando = new SqlCommand(query, conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;


            comando.Parameters.AddWithValue("@ID", profesional.Id);
            comando.Parameters.AddWithValue("@Nombre", profesional.Nombre);
            comando.Parameters.AddWithValue("@DNI", profesional.DNI);
            comando.Parameters.AddWithValue("@Nro_Matricula", profesional.NroMatricula);
            comando.Parameters.AddWithValue("@Direccion", profesional.Direccion);
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

                throw new DALException("Error al modificar una profesional.", ex);
            }
        }

        public void EliminarProfesional(Profesional profesional)
        {

            SqlConnection conexion = Conexion.Instancia;

            string query = "dbo.ProfesionalesEliminar";

            SqlCommand comando = new SqlCommand(query, conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@ID", profesional.Id);
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

                throw new DALException("Error al eliminar una profesional.", ex);
            }
        }

    }
}
