using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantaMaria.Servicios.Excepciones
{
    public class DALException : Exception
    {
        public DALException(string mensaje) : base(mensaje) { }

        public DALException(string mensaje, Exception ex) : base(mensaje, ex) { }

        public DALException(Exception ex) : base(ex.Message, ex) { }
    }
}
