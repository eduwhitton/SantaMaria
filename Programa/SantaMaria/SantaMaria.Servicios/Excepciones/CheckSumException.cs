using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantaMaria.Servicios.Excepciones
{
    public class CheckSumException : Exception
    {
        private CheckSumException() { }
        public CheckSumException(string mensaje) : base(mensaje)
        { }
    }
}
