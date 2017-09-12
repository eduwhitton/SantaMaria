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
    public class DAOPaciente
    {
        public void AgregarPaciente(Paciente paciente)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "dbo.PacientesAgregar";

            SqlCommand comando = new SqlCommand(query, conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@ID", Guid.NewGuid());
            comando.Parameters.AddWithValue("@Nombre", paciente.Nombre);
            comando.Parameters.AddWithValue("@DNI", paciente.DNI);
            comando.Parameters.AddWithValue("@Cod_Cobertura", paciente.CodCobertura);
            comando.Parameters.AddWithValue("@Direccion", paciente.Direccion);
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

                throw new DALException("Error al crear una paciente.", ex);
            }
        }

        public Paciente ObtenerPorDNI(int dni)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "dbo.PacientesObtenerPorDni";

            SqlCommand comando = new SqlCommand(query, conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@DNI", dni);

            SqlDataReader dr;

            try
            {
                conexion.Open();

                dr = comando.ExecuteReader();

                dr.Read();

                EntidadBase entidad = new Paciente();

                Mapeadores.MapeadorEntidad.RellenarEntidad(dr, ref entidad);

                Paciente paciente = entidad as Paciente;

                Mapeador.DataReaderAPaciente(dr, ref paciente);

                conexion.Close();
                
                return paciente;
            }
            catch (Exception ex)
            {
                conexion.Close();

                throw new DALException("Error al crear obtener una paciente por dni.", ex);
            }
        }

        public Paciente ObtenerPorID(Guid id)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "dbo.PacientesObtenerPorId";

            SqlCommand comando = new SqlCommand(query, conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@ID", id);

            SqlDataReader dr;

            try
            {
                conexion.Open();

                dr = comando.ExecuteReader();

                dr.Read();

                EntidadBase entidad = new Paciente();

                Mapeadores.MapeadorEntidad.RellenarEntidad(dr, ref entidad);

                Paciente paciente = entidad as Paciente;

                Mapeador.DataReaderAPaciente(dr, ref paciente);

                conexion.Close();

                return paciente;

            }
            catch (Exception ex)
            {
                conexion.Close();

                throw new DALException("Error al crear obtener una paciente por Id.", ex);
            }
        }

        public List<Paciente> ObtenerTodo()
        {

            SqlConnection conexion = Conexion.Instancia;

            string query = "dbo.PacientesObtener200";

            SqlCommand comando = new SqlCommand(query, conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;


            SqlDataReader dr;

            try
            {
                conexion.Open();

                dr = comando.ExecuteReader();

                List<Paciente> lista = new List<Paciente>();

                Paciente paciente;
                EntidadBase entidad;

                while (dr.Read())
                {
                    entidad = new Paciente();

                    Mapeadores.MapeadorEntidad.RellenarEntidad(dr, ref entidad);

                    paciente = entidad as Paciente;

                    Mapeador.DataReaderAPaciente(dr, ref paciente);

                    lista.Add(paciente);
                }

                conexion.Close();

                return lista;

            }
            catch (Exception ex)
            {
                conexion.Close();

                throw new DALException("Error al obtener todos los pacientes.", ex);
            }

        }

        public void ModificarPaciente(Paciente paciente)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "dbo.PacientesModificar";

            SqlCommand comando = new SqlCommand(query, conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;


            comando.Parameters.AddWithValue("@ID", paciente.Id);
            comando.Parameters.AddWithValue("@Nombre", paciente.Nombre);
            comando.Parameters.AddWithValue("@DNI", paciente.DNI);
            comando.Parameters.AddWithValue("@Cod_Cobertura", paciente.CodCobertura);
            comando.Parameters.AddWithValue("@Direccion", paciente.Direccion);
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

                throw new DALException("Error al modificar una paciente.", ex);
            }
        }

        public void EliminarPaciente(Paciente paciente)
        {

            SqlConnection conexion = Conexion.Instancia;

            string query = "dbo.PacientesEliminar";

            SqlCommand comando = new SqlCommand(query, conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@ID", paciente.Id);
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

                throw new DALException("Error al eliminar una paciente.", ex);
            }
        }

    }
}
