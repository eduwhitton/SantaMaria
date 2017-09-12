using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantaMaria.Entidades
{
    public class Paciente : Persona
    {
        private int _cod_cobertura;

        public int CodCobertura
        {
            get { return _cod_cobertura; }
            set { _cod_cobertura = value; }
        }
    }
}
