using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading.Tasks;
using SantaMaria.Entidades;
using System.Data.SqlClient;
using SantaMaria.Servicios;
using SantaMaria.Servicios.Excepciones;

namespace SantaMaria.DAL.DAO
{
    public class DAOHistoriaClinica
    {
        public void AgregarHistoriaClinica(HistoriaClinica historiaClinica)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "dbo.Historias_ClinicasAgregar";

            SqlCommand comando = new SqlCommand(query, conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@ID", Guid.NewGuid());
            comando.Parameters.AddWithValue("@Nro_Matricula", historiaClinica.nroMatricula);
            comando.Parameters.AddWithValue("@DNI", historiaClinica.dni);
            comando.Parameters.AddWithValue("@Fecha", historiaClinica.fecha);
            comando.Parameters.AddWithValue("@Cod_Especialidad", historiaClinica.especialidad);
            comando.Parameters.AddWithValue("@Diagnostico", historiaClinica.diagnostico);
            comando.Parameters.AddWithValue("@Medicamentos", historiaClinica.medicamentos);
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

                throw new DALException("Error al crear una historia clinica.", ex);
            }
        }

        public List<HistoriaClinica> ObtenerPorDNI(int dni)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "dbo.Historias_ClinicasObtenerPorDni";

            SqlCommand comando = new SqlCommand(query, conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@DNI", dni);

            SqlDataReader dr;

            try
            {
                conexion.Open();

                dr = comando.ExecuteReader();

                List<HistoriaClinica> lista = new List<HistoriaClinica>();

                HistoriaClinica historiaClinica;
                EntidadBase entidad;

                while (dr.Read())
                {
                    entidad = new HistoriaClinica();

                    Mapeadores.MapeadorEntidad.RellenarEntidad(dr, ref entidad);

                    historiaClinica = entidad as HistoriaClinica;

                    Mapeador.DataReaderAHistoriaClinica(dr, ref historiaClinica);

                    lista.Add(historiaClinica);
                }
                conexion.Close();

                return lista;

            }
            catch (Exception ex)
            {
                conexion.Close();

                throw new DALException("Error al crear obtener una historiaClinica por dni.", ex);
            }
        }

        public HistoriaClinica ObtenerPorID(Guid id)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "dbo.Historias_ClinicasObtenerPorId";

            SqlCommand comando = new SqlCommand(query, conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@ID", id);

            SqlDataReader dr;

            try
            {
                conexion.Open();

                dr = comando.ExecuteReader();

                dr.Read();

                EntidadBase entidad = new HistoriaClinica();

                Mapeadores.MapeadorEntidad.RellenarEntidad(dr, ref entidad);

                HistoriaClinica historiaClinica = entidad as HistoriaClinica;

                Mapeador.DataReaderAHistoriaClinica(dr, ref historiaClinica);

                conexion.Close();

                return historiaClinica;

            }
            catch (Exception ex)
            {
                conexion.Close();

                throw new DALException("Error al obtener una historia clinica por Id.", ex);
            }
        }


        public void ModificarHistoriaClinica(HistoriaClinica historiaClinica)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "dbo.Historias_ClinicasModificar";

            SqlCommand comando = new SqlCommand(query, conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;


            comando.Parameters.AddWithValue("@ID", Guid.NewGuid());
            comando.Parameters.AddWithValue("@Nro_Matricula", historiaClinica.nroMatricula);
            comando.Parameters.AddWithValue("@DNI", historiaClinica.dni);
            comando.Parameters.AddWithValue("@Fecha", historiaClinica.fecha);
            comando.Parameters.AddWithValue("@Cod_Especialidad", (int)historiaClinica.especialidad);
            comando.Parameters.AddWithValue("@Diagnostico", historiaClinica.diagnostico);
            comando.Parameters.AddWithValue("@Medicamentos", historiaClinica.medicamentos);
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

                throw new DALException("Error al modificar una historia clinica.", ex);
            }
        }

        public void EliminarHistoriaClinica(HistoriaClinica historiaClinica)
        {

            SqlConnection conexion = Conexion.Instancia;

            string query = "dbo.Historias_ClinicasEliminar";

            SqlCommand comando = new SqlCommand(query, conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@ID", historiaClinica.Id);
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

                throw new DALException("Error al eliminar una historia clinica.", ex);
            }
        }

    }
}
