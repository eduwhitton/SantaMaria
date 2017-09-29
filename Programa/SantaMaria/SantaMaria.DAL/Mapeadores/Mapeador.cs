using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SantaMaria.Entidades;
using System.Data;
using System.Data.SqlClient;

namespace SantaMaria.DAL
{
    public static class Mapeador
    {
        public static void DataReaderAPersona(SqlDataReader dr, ref Persona persona)
        {
            persona.Nombre = dr.GetString(dr.GetOrdinal("Nombre"));
            persona.DNI = dr.GetInt32(dr.GetOrdinal("DNI"));
            persona.Direccion = dr.GetString(dr.GetOrdinal("Direccion"));
            persona.Telefono = dr.GetInt32(dr.GetOrdinal("Telefono"));
        }

        public static void DataReaderAPaciente(SqlDataReader dr, ref Persona persona)
        {
            persona.Nombre = dr.GetString(dr.GetOrdinal("Nombre"));
            persona.DNI = dr.GetInt32(dr.GetOrdinal("DNI"));
            persona.Direccion = dr.GetString(dr.GetOrdinal("Direccion"));
        }

        public static void DataReaderAPaciente(SqlDataReader dr, ref Paciente paciente)
        {
            Persona persona = paciente as Persona;
            DataReaderAPersona(dr, ref persona);
            paciente = persona as Paciente;

            paciente.CodCobertura = dr.GetInt32(dr.GetOrdinal("Cod_Cobertura"));
        }

        internal static void DataReaderAProfesional(SqlDataReader dr, ref Profesional profesional)
        {
            Persona persona = profesional as Persona;
            DataReaderAPersona(dr, ref persona);
            profesional = persona as Profesional;

            profesional.NroMatricula = dr.GetInt32(dr.GetOrdinal("Nro_Matricula"));
        }

        internal static void DataReaderAHistoriaClinica(SqlDataReader dr, ref HistoriaClinica historiaClinica)
        {
            historiaClinica.diagnostico = dr.GetString(dr.GetOrdinal("Diagnostico"));
            historiaClinica.dni = dr.GetInt32(dr.GetOrdinal("DNI"));
            historiaClinica.especialidad = dr.GetInt32(dr.GetOrdinal("Cod_Especialidad"));
            historiaClinica.fecha = dr.GetDateTime(dr.GetOrdinal("Fecha"));
            historiaClinica.medicamentos = dr.GetString(dr.GetOrdinal("Medicamentos"));
            historiaClinica.nroMatricula = dr.GetInt32(dr.GetOrdinal("Nro_Matricula"));
        }

        internal static void DataReaderACobertura(SqlDataReader dr, ref Cobertura cobertura)
        {
            cobertura.CodCobertura = dr.GetInt32(dr.GetOrdinal("Cod_Cobertura"));
            cobertura.Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"));
        }

        internal static void DataReaderAEspecialidad(SqlDataReader dr, ref Especialidad especialidad)
        {
            especialidad.CodEspecialidad = dr.GetInt32(dr.GetOrdinal("Cod_Especialidad"));
            especialidad.Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"));
        }

        internal static void DataReaderAEspecialidadProfesional(SqlDataReader dr, ref EspecialidadProfesional especialidadProfesional)
        {
            especialidadProfesional.CodEspecialidad = dr.GetInt32(dr.GetOrdinal("Cod_Especialidad"));
            especialidadProfesional.NroMatricula = dr.GetInt32(dr.GetOrdinal("Nro_Matricula"));
        }

        internal static void DataReaderATurno(SqlDataReader dr, ref Turno turno)
        {
            turno.codEspecialidad = dr.GetInt32(dr.GetOrdinal("Cod_Especialidad"));
            turno.nroMatricula = dr.GetInt32(dr.GetOrdinal("Nro_Matricula"));
            turno.dni = dr.GetInt32(dr.GetOrdinal("DNI"));
            turno.fecha = dr.GetDateTime(dr.GetOrdinal("Fecha"));
            turno.sobreturno = dr.GetBoolean(dr.GetOrdinal("Sobreturno"));
        }

        internal static void DataReaderADisponibilidad(SqlDataReader dr, ref Disponibilidad disponibilidad)
        {
            disponibilidad.nroMatricula = dr.GetInt32(dr.GetOrdinal("Nro_Matricula"));
            disponibilidad.codEspecialidad = dr.GetInt32(dr.GetOrdinal("Cod_Especialidad"));
            disponibilidad.dia = dr.GetString(dr.GetOrdinal("Dia"));
            disponibilidad.horaInicio = dr.GetDateTime(dr.GetOrdinal("HoraInicio"));
            disponibilidad.horaFinal = dr.GetDateTime(dr.GetOrdinal("HoraFinal"));
        }
    }
}
