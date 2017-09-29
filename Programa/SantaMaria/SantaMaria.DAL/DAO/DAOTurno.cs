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
    public class DAOTurno
    {
        public void AgregarTurno(Turno turno)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "[dbo].[TurnosAgregar]";

            SqlCommand comando = new SqlCommand(query, conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@ID", Guid.NewGuid());
            comando.Parameters.AddWithValue("@Nro_Matricula", turno.nroMatricula);
            comando.Parameters.AddWithValue("@dni", turno.dni);
            comando.Parameters.AddWithValue("@Fecha", turno.fecha);
            comando.Parameters.AddWithValue("@Cod_Especialidad", turno.codEspecialidad); 
            comando.Parameters.AddWithValue("@Sobreturno", turno.sobreturno);
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

                throw new DALException("Error al crear una turno.", ex);
            }
        }


        public Turno ObtenerPorID(Guid id)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "[dbo].[TurnosObtenerPorId]";

            SqlCommand comando = new SqlCommand(query, conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@ID", id);


            SqlDataReader dr;

            try
            {
                conexion.Open();

                dr = comando.ExecuteReader();

                dr.Read();

                EntidadBase entidad = new Turno();

                Mapeadores.MapeadorEntidad.RellenarEntidad(dr, ref entidad);

                Turno turno = entidad as Turno;

                Mapeador.DataReaderATurno(dr, ref turno);

                conexion.Close();

                return turno;

            }
            catch (Exception ex)
            {
                conexion.Close();

                throw new DALException("Error al obtener una turno por id.", ex);
            }


        }

        public List<Turno> ObtenerTodo()
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "dbo.TurnosObtener200";

            SqlCommand comando = new SqlCommand(query, conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;


            SqlDataReader dr;

            try
            {
                conexion.Open();

                dr = comando.ExecuteReader();

                List<Turno> lista = new List<Turno>();

                Turno turno;
                EntidadBase entidad;

                while (dr.Read())
                {

                    entidad = new Turno();

                    Mapeadores.MapeadorEntidad.RellenarEntidad(dr, ref entidad);

                    turno = entidad as Turno;

                    Mapeador.DataReaderATurno(dr, ref turno);

                    lista.Add(turno);
                }

                conexion.Close();

                return lista;

            }
            catch (Exception ex)
            {
                conexion.Close();

                throw new DALException("Error al obtener todas las turnos.", ex);
            }

        }

        public void ModificarTurno(Turno turno)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "[dbo].[TurnosModificar]";

            SqlCommand comando = new SqlCommand(query, conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@ID", turno.Id); 
            comando.Parameters.AddWithValue("@Nro_Matricula", turno.nroMatricula);
            comando.Parameters.AddWithValue("@dni", turno.dni);
            comando.Parameters.AddWithValue("@Fecha", turno.fecha);
            comando.Parameters.AddWithValue("@Cod_Especialidad", turno.codEspecialidad);
            comando.Parameters.AddWithValue("@Sobreturno", turno.sobreturno);
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

                throw new DALException("Error al modificar una turno.", ex);
            }
        }

        public void EliminarTurno(Turno turno)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "[dbo].[TurnosEliminar]";

            SqlCommand comando = new SqlCommand(query, conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@ID", turno.Id);
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

                throw new DALException("Error al eliminar una turno.", ex);
            }
        }
    }
}
