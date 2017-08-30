using System;
using System.Collections.Generic;
namespace SantaMaria.Servicios.Seguridad.Entidades
{
    /// <summary>
    /// Clase abstracta que tiene que ser heredada por todos los Patente-Familia-Usuario que contienen
    /// los parametros básicos de todos y esta hecha teneniendo en cuenta el patron Composite.
    /// </summary>
    public abstract class ComponenteBase : SantaMaria.Entidades.EntidadBase
    {

        string _nombreComponente;
        public string NombreComponente
        {
            get { return _nombreComponente; }
            set { _nombreComponente = value; }
        }
        string _descripcionComponente;
        public string DescripcionComponente
        {
            get { return _descripcionComponente; }
            set { _descripcionComponente = value; }
        }
        public ComponenteBase() { }
        public ComponenteBase(string nombre, string descripcion)
        {
            _nombreComponente = nombre;
            _descripcionComponente = descripcion;
        }
        public abstract void Agregar(ComponenteBase comp);
        public abstract void Eliminar(ComponenteBase comp);
        public virtual int CantHijos { get; private set; }
        public abstract List<ComponenteBase> ObtenerComponentes();
        public abstract List<String> ObtenerNombrePatentes();
    }
}
