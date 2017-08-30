using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SantaMaria.Servicios.Bitacora
{
    /// <summary>
    /// Interfaz que debe implementar el observador en el patrón Observer
    /// </summary>
    /// <typeparam name="T">Tipo de parametro a observar</typeparam>
    public interface IObservador<T>
    {
        void Update(T nuevo);
    }
    
}
