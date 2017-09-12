using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantaMaria.Entidades
{
    public class Profesional : Persona
    {
        private int _nro_matricula;
        public int NroMatricula
        {
            get { return _nro_matricula; }
            set { _nro_matricula = value; }
        }
    }
}
