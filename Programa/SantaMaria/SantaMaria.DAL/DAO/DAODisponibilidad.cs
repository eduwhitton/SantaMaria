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
    public class DAODisponibilidad
    {

        public void AgregarDisponibilidad(Disponibilidad disponibilidad)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "dbo.DisponibilidadesAgregar";

            SqlCommand comando = new SqlCommand(query, conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@ID", Guid.NewGuid());
            comando.Parameters.AddWithValue("@Nro_Matricula", disponibilidad.nroMatricula);
            comando.Parameters.AddWithValue("@Cod_Especialidad", disponibilidad.codEspecialidad);
            comando.Parameters.AddWithValue("@Día_Atencion", disponibilidad.dia);
            comando.Parameters.AddWithValue("@HoraInicio", disponibilidad.horaInicio);
            comando.Parameters.AddWithValue("@HoraFinal", disponibilidad.horaFinal);
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

                throw new DALException("Error al crear una disponibilidad.", ex);
            }
        }

        public List<Disponibilidad> ObtenerPorNroMatricula(int NroMatricula)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "dbo.DisponibilidadesObtenerPorNro_Matricula";

            SqlCommand comando = new SqlCommand(query, conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@Nro_Matricula", NroMatricula);

            SqlDataReader dr;

            try
            {
                conexion.Open();

                dr = comando.ExecuteReader();

                List<Disponibilidad> lista = new List<Disponibilidad>();

                Disponibilidad disponibilidad;
                EntidadBase entidad;

                while (dr.Read())
                {
                    entidad = new Disponibilidad();

                    Mapeadores.MapeadorEntidad.RellenarEntidad(dr, ref entidad);

                    disponibilidad = entidad as Disponibilidad;

                    Mapeador.DataReaderADisponibilidad(dr, ref disponibilidad);

                    lista.Add(disponibilidad);
                }

                conexion.Close();

                return lista;

            }
            catch (Exception ex)
            {
                conexion.Close();

                throw new DALException("Error al crear obtener una disponibilidad por Número de Matricula.", ex);
            }
        }
        public List<Disponibilidad> ObtenerPorCodEspecialidad(int CodEspecialidad)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "dbo.DisponibilidadesObtenerPorCod_Especialidad";

            SqlCommand comando = new SqlCommand(query, conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@Cod_Especialidad", CodEspecialidad);

            SqlDataReader dr;

            try
            {
                conexion.Open();

                dr = comando.ExecuteReader();

                List<Disponibilidad> lista = new List<Disponibilidad>();

                Disponibilidad disponibilidad;
                EntidadBase entidad;

                while (dr.Read())
                {
                    entidad = new Disponibilidad();

                    Mapeadores.MapeadorEntidad.RellenarEntidad(dr, ref entidad);

                    disponibilidad = entidad as Disponibilidad;

                    Mapeador.DataReaderADisponibilidad(dr, ref disponibilidad);

                    lista.Add(disponibilidad);
                }

                conexion.Close();

                return lista;

            }
            catch (Exception ex)
            {
                conexion.Close();

                throw new DALException("Error al crear obtener una disponibilidad por Codigo de Especialidad.", ex);
            }
        }

        public Disponibilidad ObtenerPorID(Guid id)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "dbo.DisponibilidadesObtenerPorId";

            SqlCommand comando = new SqlCommand(query, conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@ID", id);

            SqlDataReader dr;

            try
            {
                conexion.Open();

                dr = comando.ExecuteReader();

                dr.Read();

                EntidadBase entidad = new Disponibilidad();

                Mapeadores.MapeadorEntidad.RellenarEntidad(dr, ref entidad);

                Disponibilidad disponibilidad = entidad as Disponibilidad;

                Mapeador.DataReaderADisponibilidad(dr, ref disponibilidad);

                conexion.Close();

                return disponibilidad;

            }
            catch (Exception ex)
            {
                conexion.Close();

                throw new DALException("Error al crear obtener una disponibilidad por Id.", ex);
            }
        }

        public void ModificarDisponibilidad(Disponibilidad disponibilidad)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "dbo.DisponibilidadesModificar";

            SqlCommand comando = new SqlCommand(query, conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;


            comando.Parameters.AddWithValue("@ID", Guid.NewGuid());
            comando.Parameters.AddWithValue("@Nro_Matricula", disponibilidad.nroMatricula);
            comando.Parameters.AddWithValue("@Cod_Especialidad", disponibilidad.codEspecialidad);
            comando.Parameters.AddWithValue("@Día_Atencion", disponibilidad.dia);
            comando.Parameters.AddWithValue("@HoraInicio", disponibilidad.horaInicio);
            comando.Parameters.AddWithValue("@HoraFinal", disponibilidad.horaFinal);
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

                throw new DALException("Error al modificar una disponibilidad.", ex);
            }
        }

        public void EliminarDisponibilidad(Disponibilidad disponibilidad)
        {

            SqlConnection conexion = Conexion.Instancia;

            string query = "dbo.DisponibilidadesEliminar";

            SqlCommand comando = new SqlCommand(query, conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@ID", disponibilidad.Id);
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

                throw new DALException("Error al eliminar una disponibilidad.", ex);
            }
        }

    }
}
