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
    public class DAOCobertura
    {
        public void AgregarCobertura(Cobertura cobertura)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "[dbo].[CoberturasAgregar]";


            SqlCommand comando = new SqlCommand(query, conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@ID", Guid.NewGuid());
            comando.Parameters.AddWithValue("@Cod_Cobertura", cobertura.CodCobertura);
            comando.Parameters.AddWithValue("@Descripcion", cobertura.Descripcion);
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

                throw new DALException("Error al crear una cobertura.", ex);
            }
        }
        
        public Cobertura ObtenerPorCodCobertura(int CodCobertura)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "[dbo].[CoberturasPorCod_Cobertura]";

            SqlCommand comando = new SqlCommand(query, conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@Cod_Cobertura", CodCobertura);


            SqlDataReader dr;

            try
            {
                conexion.Open();

                dr = comando.ExecuteReader();

                dr.Read();

                EntidadBase entidad = new Cobertura();

                Mapeadores.MapeadorEntidad.RellenarEntidad(dr, ref entidad);

                Cobertura cobertura = entidad as Cobertura;

                Mapeador.DataReaderACobertura(dr, ref cobertura);

                conexion.Close();

                return cobertura;

            }
            catch (Exception ex)
            {
                conexion.Close();

                throw new DALException("Error al crear obtener una cobertura por Código de cobertura.", ex);
            }


        }

        public Cobertura ObtenerPorID(Guid id)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "[dbo].[CoberturasObtenerPorId]";

            SqlCommand comando = new SqlCommand(query, conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@ID", id);


            SqlDataReader dr;

            try
            {
                conexion.Open();

                dr = comando.ExecuteReader();

                dr.Read();

                EntidadBase entidad = new Cobertura();

                Mapeadores.MapeadorEntidad.RellenarEntidad(dr, ref entidad);

                Cobertura cobertura = entidad as Cobertura;

                Mapeador.DataReaderACobertura(dr, ref cobertura);

                conexion.Close();

                return cobertura;

            }
            catch (Exception ex)
            {
                conexion.Close();

                throw new DALException("Error al obtener una cobertura por id.", ex);
            }


        }

        public List<Cobertura> ObtenerTodo()
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "dbo.CoberturasObtener200";

            SqlCommand comando = new SqlCommand(query, conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;


            SqlDataReader dr;

            try
            {
                conexion.Open();

                dr = comando.ExecuteReader();

                List<Cobertura> lista = new List<Cobertura>();

                Cobertura cobertura;
                EntidadBase entidad;

                while (dr.Read())
                {

                    entidad = new Cobertura();

                    Mapeadores.MapeadorEntidad.RellenarEntidad(dr, ref entidad);

                    cobertura = entidad as Cobertura;

                    Mapeador.DataReaderACobertura(dr, ref cobertura);

                    lista.Add(cobertura);
                }

                conexion.Close();

                return lista;

            }
            catch (Exception ex)
            {
                conexion.Close();

                throw new DALException("Error al obtener todas las coberturas.", ex);
            }

        }

        public void ModificarCobertura(Cobertura cobertura)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "[dbo].[CoberturasModificar]";

            SqlCommand comando = new SqlCommand(query, conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@ID", cobertura.Id);
            comando.Parameters.AddWithValue("@Cod_Cobertura", cobertura.CodCobertura);
            comando.Parameters.AddWithValue("@Descripcion", cobertura.Descripcion);
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

                throw new DALException("Error al modificar una cobertura.", ex);
            }
        }

        public void EliminarCobertura(Cobertura cobertura)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "[dbo].[CoberturasEliminar]";

            SqlCommand comando = new SqlCommand(query, conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@ID", cobertura.Id);
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

                throw new DALException("Error al eliminar una cobertura.", ex);
            }
        }
    }
}
