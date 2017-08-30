using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SantaMaria.Servicios.Excepciones;

namespace SantaMaria.Servicios.Seguridad.Entidades
{
    public class Patente : ComponenteBase
    {
        /// <summary>
        /// Clase que contiene los datos de una patente utilizada para la organización de permisos (o patentes)
        /// de los usuarios aplicando el patron composite.
        /// </summary>
        public Patente() { }
        public Patente(string nombre, string descripcion) : base (nombre, descripcion)
        {
        }
        public override void Agregar(ComponenteBase comp)
        {
            throw new DALException("No se puede agregar patentes a una patente.");
        }

        public override void Eliminar(ComponenteBase comp)
        {
            throw new DALException("No se puede eliminar patentes a una patente.");
        }
        public override List<ComponenteBase> ObtenerComponentes()
        {
            throw new DALException("No se puede obtener patentes de una patente.");
        }

        public override int CantHijos
        {
            get{return 0;}
        }

        public override List<String> ObtenerNombrePatentes()
        {
            List<string> nuevo = new List<string>();
            nuevo.Add(NombreComponente);
            return nuevo;
        } 
    }
}
