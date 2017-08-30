using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantaMaria.Servicios.Bitacora
{
    /// <summary>
    /// Interfaz generica que deber heredar los diferentes tipos de logger
    /// </summary>
    public interface ILogger : IObservador<ErrorParameters>, IObservador<ActivityParameters>
    {
    }
}
