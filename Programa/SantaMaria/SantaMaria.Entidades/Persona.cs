using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantaMaria.Entidades
{
    /// <summary>
    /// Contiene los datos de una persona
    /// </summary>
    public class Persona : EntidadBase, IEntidadBase
    {

        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        private int _dni;

        public int DNI
        {
            get { return _dni; }
            set { _dni = value; }
        }

        private string _direccion;

        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }

        

    }
}
