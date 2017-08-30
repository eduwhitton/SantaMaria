using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using SantaMaria.Servicios.Seguridad.Entidades;
using SantaMaria.Servicios.Seguridad.Dal;
using SantaMaria.Servicios.Encriptacion;

namespace SantaMaria.Servicios.Seguridad.BLL
{
    /// <summary>
    /// Clase encargada de la logica de negocios
    /// </summary>
    public class BLLUsuario
    {
        public void AgregarUsuario(Usuario usuario)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                DAOUsuario dao = new DAOUsuario();
                usuario.contraseña = Codificador.Hash(usuario.contraseña);
                usuario.contraseña = Codificador.Encriptar(usuario.contraseña);
                dao.AgregarUsuario(usuario);
                transaction.Complete();

            }
        }
        public void AgregarRelacion(Usuario usuario, ComponenteBase componente)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                DAOUsuario dao = new DAOUsuario();
                dao.AgregarRelacion(usuario, componente);
                transaction.Complete();

            }
        }

        public void EliminarRelacion(Usuario usuario, ComponenteBase componente)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                DAOUsuario dao = new DAOUsuario();
                dao.EliminarRelacion(usuario, componente);
                transaction.Complete();
            }
        }


        public void EliminarUsuario(Usuario usuario)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                DAOUsuario dao = new DAOUsuario();
                dao.EliminarUsuario(usuario);
                transaction.Complete();
            }
        }

        public void HabilitarUsuario(Usuario usuario)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                try
                {
                    DAOUsuario dao = new DAOUsuario();
                    dao.HabilitarUsuario(usuario);
                    usuario.habilitado = true;
                    dao.ActualizarCheckSum(usuario);
                    transaction.Complete();
                }
                catch (Excepciones.DALException ex)
                {
                    throw new Excepciones.BLLException("Problema al actualizar en la base de datos", ex);
                }
            }
        }
        public void DeshabilitarUsuario(Usuario usuario)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                try
                {
                    DAOUsuario dao = new DAOUsuario();
                    dao.DeshabilitarUsuario(usuario);
                    usuario.habilitado = false;
                    dao.ActualizarCheckSum(usuario);
                    transaction.Complete();
                }
                catch (Excepciones.DALException ex)
                {
                    throw new Excepciones.BLLException("Problema al actualizar en la base de datos", ex);
                }
            }
        }
        public void ModificarUsuario(Usuario usuario)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                DAOUsuario dao = new DAOUsuario();
                dao.ModificarUsuario(usuario);
                dao.ActualizarCheckSum(usuario);
                transaction.Complete();
            }
        }
        public Usuario ObtenerPorId(Guid usu)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                Usuario usuario;
                DAOUsuario dao = new DAOUsuario();
                usuario = dao.ObtenerPorId(usu);
                transaction.Complete();
                return usuario;
            }
        }

        public Usuario ObtenerPorNombre(string nombre)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                Usuario usuario;
                DAOUsuario dao = new DAOUsuario();
                usuario = dao.ObtenerPorNombre(nombre);
                transaction.Complete();
                return usuario;
            }
        }


        public Usuario ObtenerPorUsuario(string usu)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                Usuario usuario;
                DAOUsuario dao = new DAOUsuario();
                usuario = dao.ObtenerPorUsuario(usu);

                transaction.Complete();
                return usuario;
            }
        }

        public List<Familia> ObtenerFamilias(Usuario usuario)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                List<Familia> lista;
                DAOUsuario dao = new DAOUsuario();
                lista = dao.ObtenerFamilias(usuario);
                transaction.Complete();
                return lista;
            }
        }
        public List<Patente> ObtenerPatentes(Usuario usuario)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                List<Patente> lista;
                DAOUsuario dao = new DAOUsuario();
                lista = dao.ObtenerPatentes(usuario);
                transaction.Complete();
                return lista;
            }
        }
        public List<Usuario> ObtenerTodo()
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                List<Usuario> lista;
                DAOUsuario dao = new DAOUsuario();
                lista = dao.ObtenerTodo();
                transaction.Complete();
                return lista;
            }
        }
        public void RellenarPermisos(ref Usuario usuario)
        {

            List<Patente> listapatente;
            DAOUsuario dao = new DAOUsuario();
            listapatente = dao.ObtenerPatentes(usuario);
            for (int i = 0; i < listapatente.Count; i++)
            {
                usuario.Agregar(listapatente[i]);
            }

            List<Familia> listafamilia;
            listafamilia = dao.ObtenerFamilias(usuario);
            BLLFamilia bllfam = new BLLFamilia();
            for (int i = 0; i < listafamilia.Count; i++)
            {
                Familia fam = listafamilia[i];
                bllfam.RellenarPermisos(ref fam);
                usuario.Agregar(fam);
            }
        }



        public void AsignarNuevasPatenes(Usuario usuario, List<System.Windows.Forms.TreeNode> nodos)
        {
            using (TransactionScope transaction = new TransactionScope())
            {

                BLL.BLLFamilia bllfam = new BLL.BLLFamilia();
                BLL.BLLUsuario bllusu = new BLL.BLLUsuario();
                BLL.BLLPatente bllpat = new BLL.BLLPatente();

                Entidades.Familia fam;
                Entidades.Patente pat;

                ///eliminar relaciones existentes
                List<Entidades.Patente> listapantentes = bllusu.ObtenerPatentes(usuario);
                for (int i = 0; i < listapantentes.Count; i++)
                {
                    bllusu.EliminarRelacion(usuario, listapantentes[i]);
                }
                List<Entidades.Familia> listafamilias = bllusu.ObtenerFamilias(usuario);
                for (int i = 0; i < listafamilias.Count; i++)
                {
                    bllusu.EliminarRelacion(usuario, listafamilias[i]);
                }
                ///cargar relaciones nuevas
                foreach (System.Windows.Forms.TreeNode item in nodos)
                {
                    fam = bllfam.ObtenerPorNombre(item.Text);
                    if (fam.Id != Guid.Empty)
                    {
                        bllusu.AgregarRelacion(usuario, fam);
                    }
                    else
                    {
                        pat = bllpat.ObtenerPorNombre(item.Text);
                        bllusu.AgregarRelacion(usuario, pat);
                    }
                }
                transaction.Complete();
            }
        }
    }
}