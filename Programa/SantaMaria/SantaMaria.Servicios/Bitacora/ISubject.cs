using System;
using System.Collections.Generic;
namespace SantaMaria.Servicios.Bitacora
{
    /// <summary>
    /// Interfaz que debe implementar el sujeto que se observa en el patron observer
    /// </summary>
    /// <typeparam name="T">Tipo de parametro observado</typeparam>
    public interface ISubject<T>
    {
        void AgregarAEvento(IObservador<T> obs);
        void EliminarDeEvento(IObservador<T> obs);
        void Notificar(T nuevo);
        List<IObservador<T>> ObtenerTodos();
    }
    /// <summary>
    /// Implementación generica del sujeto observado en el patron observer
    /// </summary>
    /// <typeparam name="T">Tipo de parametro observado</typeparam>
    public class Subject<T> : ISubject<T>
    {

        private List<IObservador<T>> Observadores = new List<IObservador<T>>();

        void ISubject<T>.AgregarAEvento(IObservador<T> obs)
        {
            Observadores.Add(obs);
        }

        void ISubject<T>.EliminarDeEvento(IObservador<T> obs)
        {
            Observadores.Remove(obs);
        }
        void ISubject<T>.Notificar(T nuevo)
        {
            for (int i = 0; i < Observadores.Count; i++)
            {
                Observadores[i].Update(nuevo);
            }
        }
        List<IObservador<T>> ISubject<T>.ObtenerTodos()
        {
            throw new NotImplementedException();
        }
    }
}
