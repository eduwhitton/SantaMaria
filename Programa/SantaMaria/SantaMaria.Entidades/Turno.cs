using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantaMaria.Entidades
{
    public class Turno : EntidadBase
    {
        public int nroMatricula;
        public int dni;
        public DateTime fecha;
        public int codEspecialidad;
        public bool sobreturno;
        public bool confirmado;
        public bool asistido;
    }
}
