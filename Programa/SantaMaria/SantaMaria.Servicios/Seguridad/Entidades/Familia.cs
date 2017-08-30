using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantaMaria.Servicios.Seguridad.Entidades
{
    /// <summary>
    /// Clase que contiene patentes y familias con patentes aplicando el patron composite.
    /// Utilizada para la organización de permisos (o patentes) de los usuarios.
    /// </summary>
    public class Familia : ComponenteBase
    {
        List<ComponenteBase> componentes;
        public Familia() 
        {
            componentes = new List<ComponenteBase>();
        }
        public Familia(string nombre, string descripcion)
            : base(nombre, descripcion)
        {
            componentes = new List<ComponenteBase>();
        }
        public override void Agregar(ComponenteBase comp)
        {
            componentes.Add(comp);
        }

        public override void Eliminar(ComponenteBase comp)
        {
            componentes.Remove(comp);
        }

        public override int CantHijos
        {
            get { return componentes.Count; }
        }

        public override List<string> ObtenerNombrePatentes()
        {

            List<string> lista = new List<string>();
            for (int i = 0; i < CantHijos; i++)
            {

                lista.AddRange(componentes[i].ObtenerNombrePatentes());

            }
            return lista;
        }

        public override List<ComponenteBase> ObtenerComponentes()
        {
            return componentes;
        }
    }
}
