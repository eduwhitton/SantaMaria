using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SantaMaria.Servicios.Seguridad.Entidades;
using SantaMaria.Servicios.Seguridad.BLL;
using SantaMaria.Servicios.Encriptacion;

namespace SantaMaria.Servicios.Seguridad
{
    /// <summary>
    /// Clase encargada de verificar los permisos y credenciales del usuario
    /// </summary>
    public static class Autorizacion
    {
        public static bool VerificarUsuarioContraseña(Usuario usuario)
        {
            usuario.contraseña = Codificador.Hash(usuario.contraseña);
            
            BLLUsuario bll = new BLLUsuario();
            Usuario autentico = bll.ObtenerPorUsuario(usuario.usuario);
            if (autentico == null) return false;
            autentico.contraseña = Codificador.Desencriptar(autentico.contraseña);

            if (usuario.contraseña == autentico.contraseña) return true;

            return false;

        }

        public static bool VerificarPermiso(string permiso)
        {
            for (int i = 0; i < Contexto.UsuarioActual.Permisos.Count; i++)
            {
                if (Contexto.UsuarioActual.Permisos[i] == permiso) return true;
            }
            return false;
        }
    }
}
