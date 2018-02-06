using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantaMaria.Entidades
{
    public class Disponibilidad : EntidadBase
    {
        public int nroMatricula;
        public int codEspecialidad;
        public int diaDeLaSemana;
        public TimeSpan horaInicio;
        public TimeSpan horaFinal;
    }
}
