﻿using System;
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
    /// <summary>
    /// Clase encargada del acceso de los datos en la Base de datos
    /// </summary>
    public class DAOPersona
    {
        public void AgregarPersona(Persona persona)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "INSERT INTO [dbo].[Personas]([ID],[Nombre],[DNI],[Direccion],[CreatedOn]," +
            "[CreatedBy],[Deleted]) VALUES (@ID,@Nombre,@DNI,@Direccion,@CreatedOn," +
            "@CreatedBy,@Deleted)";

            SqlCommand comando = new SqlCommand(query, conexion);

            comando.Parameters.AddWithValue("@ID", Guid.NewGuid());
            comando.Parameters.AddWithValue("@Nombre", persona.Nombre);
            comando.Parameters.AddWithValue("@DNI", persona.DNI);
            comando.Parameters.AddWithValue("@Direccion", persona.Direccion);
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

                throw new DALException("Error al crear una persona.", ex);
            }
        }
        
        public Persona ObtenerPorDNI(int dni)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "SELECT * FROM [dbo].[Personas]" +
            "WHERE DNI = @DNI AND DELETED = 0";

            SqlCommand comando = new SqlCommand(query, conexion);

            comando.Parameters.AddWithValue("@DNI", dni);


            SqlDataReader dr;

            try
            {
                conexion.Open();

                dr = comando.ExecuteReader();

                dr.Read();

                EntidadBase entidad = new Persona();

                Mapeadores.MapeadorEntidad.RellenarEntidad(dr, ref entidad);

                Persona persona = entidad as Persona;

                Mapeador.DataReaderAPersona(dr, ref persona);

                conexion.Close();

                return persona;

            }
            catch (Exception ex)
            {
                conexion.Close();

                throw new DALException("Error al crear obtener una persona por dni.", ex);
            }


        }

        public Persona ObtenerPorID(Guid id)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "SELECT * FROM [dbo].[Personas]" +
            "WHERE ID = @ID AND DELETED = 0";

            SqlCommand comando = new SqlCommand(query, conexion);

            comando.Parameters.AddWithValue("@ID", id);


            SqlDataReader dr;

            try
            {
                conexion.Open();

                dr = comando.ExecuteReader();

                dr.Read();

                EntidadBase entidad = new Persona();

                Mapeadores.MapeadorEntidad.RellenarEntidad(dr, ref entidad);

                Persona persona = entidad as Persona;

                Mapeador.DataReaderAPersona(dr, ref persona);

                conexion.Close();

                return persona;

            }
            catch (Exception ex)
            {
                conexion.Close();

                throw new DALException("Error al obtener una persona por id.", ex);
            }


        }

        public List<Persona> ObtenerTodo()
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "SELECT TOP 200 * FROM [dbo].[Personas] WHERE DELETED = 0";

            SqlCommand comando = new SqlCommand(query, conexion);


            SqlDataReader dr;

            try
            {
                conexion.Open();

                dr = comando.ExecuteReader();

                List<Persona> lista = new List<Persona>();

                Persona persona;
                EntidadBase entidad;

                while (dr.Read())
                {

                    entidad = new Persona();

                    Mapeadores.MapeadorEntidad.RellenarEntidad(dr, ref entidad);

                    persona = entidad as Persona;

                    Mapeador.DataReaderAPersona(dr, ref persona);

                    lista.Add(persona);
                }

                conexion.Close();

                return lista;

            }
            catch (Exception ex)
            {
                conexion.Close();

                throw new DALException("Error al obtener todas las personas.", ex);
            }

        }

        public void ModificarPersona(Persona persona)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "UPDATE [dbo].[Personas] SET [Nombre] = @Nombre, [DNI] = @DNI, [Direccion] = @Direccion, " +
                "[ChangedOn] = @ChangedOn, " +
            "[ChangedBy] = @ChangedBy WHERE ID = @ID";

            SqlCommand comando = new SqlCommand(query, conexion);

            comando.Parameters.AddWithValue("@ID", persona.Id);
            comando.Parameters.AddWithValue("@Nombre", persona.Nombre);
            comando.Parameters.AddWithValue("@DNI", persona.DNI);
            comando.Parameters.AddWithValue("@Direccion", persona.Direccion);
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

                throw new DALException("Error al modificar una persona.", ex);
            }
        }

        public void EliminarPersona(Persona persona)
        {
            SqlConnection conexion = Conexion.Instancia;

            string query = "UPDATE [dbo].[Personas] SET Deleted = 1, " +
                "[DeletedOn] = @DeletedOn, " +
            "[DeletedBy] = @DeletedBy WHERE ID = @ID";

            SqlCommand comando = new SqlCommand(query, conexion);

            comando.Parameters.AddWithValue("@ID", persona.Id);
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

                throw new DALException("Error al eliminar una persona.", ex);
            }
        }

    }

}
