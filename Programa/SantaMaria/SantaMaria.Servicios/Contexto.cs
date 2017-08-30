using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SantaMaria.Servicios.Seguridad.Entidades;
using SantaMaria.Servicios.Seguridad.BLL;
using System.Globalization;

namespace SantaMaria.Servicios
{
    public static class Contexto
    {
        public static Usuario UsuarioActual { get; private set; }
        public static void NuevoUsuario(Usuario usuario)
        {
            BLLUsuario bll = new BLLUsuario();
            ///Buscar usuario
            if (usuario.usuario != null && usuario.usuario != "")
            {
                UsuarioActual = bll.ObtenerPorUsuario(usuario.usuario);
            }
            if (usuario.Nombre != null && usuario.Nombre != "")
            {
                UsuarioActual = bll.ObtenerPorNombre(usuario.Nombre);
            }
            if (usuario.Id != null && usuario.Id != Guid.Empty)
            {
                UsuarioActual = bll.ObtenerPorId(usuario.Id);
            }
            ///Si no encuentra el usuario, excepción
            if (UsuarioActual == null)
            throw new Exception("No se pudo encontrar el usuario");
            ///Rellena los permisos del usuario
            usuario = UsuarioActual;
            bll.RellenarPermisos(ref usuario);
            UsuarioActual = usuario;


        }
        public static CultureInfo Cultura { get; set; }
    }
}
