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
        }

        public static void DataReaderAPaciente(SqlDataReader dr, ref Paciente paciente)
        {
            Persona persona = paciente as Persona;
            DataReaderAPersona(dr, ref persona);
            paciente = persona as Paciente;

            paciente.CodCobertura = dr.GetInt16(dr.GetOrdinal("Cod_Cobertura"));
        }

        internal static void DataReaderAProfesional(SqlDataReader dr, ref Profesional profesional)
        {
            Persona persona = profesional as Persona;
            DataReaderAPersona(dr, ref persona);
            profesional = persona as Profesional;

            profesional.NroMatricula = dr.GetInt16(dr.GetOrdinal("Nro_Matricula"));
        }

        internal static void DataReaderAHistoriaClinica(SqlDataReader dr, ref HistoriaClinica historiaClinica)
        {
            historiaClinica.diagnostico = dr.GetString(dr.GetOrdinal("Diagnostico"));
            historiaClinica.dni = dr.GetInt16(dr.GetOrdinal("DNI"));
            historiaClinica.especialidad = dr.GetInt16(dr.GetOrdinal("Cod_Especialidad"));
            historiaClinica.fecha = dr.GetDateTime(dr.GetOrdinal("Fecha"));
            historiaClinica.medicamentos = dr.GetString(dr.GetOrdinal("Medicamentos"));
            historiaClinica.nroMatricula = dr.GetInt16(dr.GetOrdinal("Nro_Matricula"));
        }
    }
}
