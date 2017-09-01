using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SantaMaria.Servicios.Seguridad.Entidades;
using SantaMaria.Servicios.Seguridad.Dal;
using SantaMaria.Servicios.Encriptacion;
using SantaMaria.Servicios.Excepciones;

namespace SantaMaria.Servicios.Seguridad
{
    /// <summary>
    /// Clase encargada de generar CheckSums
    /// </summary>
    public class CheckSum
    {
        static public string CalcularCheckSum(Usuario usuario)
        {
            string usuariohasheado;

            usuariohasheado = Codificador.Hash(usuario.Id.ToString());
            usuariohasheado += Codificador.Hash(usuario.usuario);
            usuariohasheado += Codificador.Hash(usuario.contraseña);
            usuariohasheado += Codificador.Hash(usuario.NombreComponente);
            usuariohasheado += Codificador.Hash(usuario.dni.ToString());
            usuariohasheado += Codificador.Hash(usuario.habilitado.ToString());

            return Codificador.Hash(usuariohasheado);
        }

        static public void CompararTodosConDB()
        {
            DAOUsuario dao = new DAOUsuario();
            try
            {

                List<Usuario> usuarios = dao.ObtenerTodo();
                string checksum;
                for (int i = 0; i < usuarios.Count; i++)
                {
                    checksum = CalcularCheckSum(usuarios[i]);
                    if (checksum != usuarios[i].CheckSum)
                    {

                        throw new CheckSumException(String.Format("El usuario {0} tiene el checksum corrupto", usuarios[i].Nombre));
                    }
                }   
            }
            catch (Exception ex)
            {
                throw new BLLException("La base de datos está corrupta.", ex);
            }
        }
    }
}
