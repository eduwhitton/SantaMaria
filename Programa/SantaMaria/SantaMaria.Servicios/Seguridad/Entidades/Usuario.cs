using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantaMaria.Servicios.Seguridad.Entidades
{
    /// <summary>
    /// Clase que contiene patentes y familias con patentes aplicando el patron composite.
    /// Contiene los permisos (o patentes) del usuario.
    /// Tambien contiene los datos utilizados para el login del usuario.
    /// </summary>
    public class Usuario : ComponenteBase
    {
        public Usuario()
        {
            componentes = new List<ComponenteBase>();
        }

        #region permisos
        List<ComponenteBase> componentes;
        public Usuario(string nombre, string descripcion) : base(nombre, descripcion)
        {
            componentes = new List<ComponenteBase>();
        }
        public override void Agregar(ComponenteBase comp)
        {
            componentes.Add(comp);
        }

        public override List<ComponenteBase> ObtenerComponentes()
        {
            return componentes;
        }

        public override void Eliminar(ComponenteBase comp)
        {
            componentes.Remove(comp);
        }

        public override int CantHijos
        {
            get { 
                return componentes.Count; 
            }
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

        #endregion

        List<string> _permisos;
        public List<string> Permisos
        {
            get
            {
                if (_permisos == null)
                {
                    _permisos = ObtenerNombrePatentes().Distinct().ToList();
                }
                return _permisos;
            }
        }

        public string usuario;          
        public string contraseña;
        public string Nombre
        {
            get { return NombreComponente; }
            set { NombreComponente = value;}
        }
            
        public int dni;
        public bool habilitado;
        public string CheckSum;

        public bool VerificarPermiso(string permiso)
        {
            for (int i = 0; i < Permisos.Count; i++)
            {
                if (Permisos[i] == permiso) return true;
            }
            return false;
        }
    }
}
