using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantaMaria.Servicios.Excepciones
{
    /// <summary>
    /// Excepción personalizada de la BLL
    /// </summary>
    public class BLLException : Exception
    {
        private BLLException()
        {
        }
        public BLLException(string mensaje) : base(mensaje)
        {
            Bitacora.Bitacora.Instance.LogError(mensaje, this);
        }
        public BLLException(string mensaje, Exception ex)
            : base(mensaje, ex)
        {
            Bitacora.Bitacora.Instance.LogError(mensaje, ex);
        }
    }
}
