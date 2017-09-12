using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantaMaria.Entidades
{
    public class HistoriaClinica : EntidadBase
    {
        public int nroMatricula;
        public int dni;
        public DateTime fecha;
        public int especialidad;
        public string diagnostico;
        public string medicamentos;
    }
}
