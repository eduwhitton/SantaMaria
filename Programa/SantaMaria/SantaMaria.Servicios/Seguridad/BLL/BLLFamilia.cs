using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using SantaMaria.Servicios.Seguridad.Entidades;
using SantaMaria.Servicios.Seguridad.Dal;

namespace SantaMaria.Servicios.Seguridad.BLL
{
    /// <summary>
    /// Clase encargada de la logica de negocios
    /// </summary>
    public class BLLFamilia
    {
        public void AgregarFamilia(Familia familia)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                DAOFamilia dao = new DAOFamilia();
                dao.AgregarFamilia(familia);
                transaction.Complete();

            }
        }
        public void AgregarRelacion(Familia familia, ComponenteBase componente)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                DAOFamilia dao = new DAOFamilia();
                dao.AgregarRelacion(familia, componente);
                transaction.Complete();

            }
        }

        public void EliminarRelacion(Familia familia, ComponenteBase componente)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                DAOFamilia dao = new DAOFamilia();
                dao.EliminarRelacion(familia, componente);
                transaction.Complete();
            }
        }


        public void EliminarFamilia(Familia familia)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                DAOFamilia dao = new DAOFamilia();
                dao.EliminarFamilia(familia);
                transaction.Complete();
            }
        }
        public void ModificarFamilia(Familia familia)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                DAOFamilia dao = new DAOFamilia();
                dao.ModificarFamilia(familia);
                transaction.Complete();
            }
        }


        public Familia ObtenerPorNombre(string nombre)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                Familia familia;
                DAOFamilia dao = new DAOFamilia();
                familia = dao.ObtenerPorNombre(nombre);
                transaction.Complete();
                return familia;
            }
        }
        public List<Familia> ObtenerFamilias(Familia familia)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                List<Familia> lista;
                DAOFamilia dao = new DAOFamilia();
                lista = dao.ObtenerFamilias(familia);
                transaction.Complete();
                return lista;
            }
        }
        public List<Patente> ObtenerPatentes(Familia familia)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                List<Patente> lista;
                DAOFamilia dao = new DAOFamilia();
                lista = dao.ObtenerPatentes(familia);
                transaction.Complete();
                return lista;
            }
        }

        public void RellenarPermisos(ref Familia familia)
        {
            List<Patente> listapatente;
            DAOFamilia dao = new DAOFamilia();
            listapatente = dao.ObtenerPatentes(familia);
            for (int i = 0; i < listapatente.Count; i++)
            {
                familia.Agregar(listapatente[i]);
            }

            List<Familia> listafamilia;
            listafamilia = dao.ObtenerFamilias(familia);
            BLLFamilia bllfam = new BLLFamilia();
            for (int i = 0; i < listafamilia.Count; i++)
            {
                Familia fam = listafamilia[i];
                bllfam.RellenarPermisos(ref fam);    
                familia.Agregar(listafamilia[i]);
            }
        }
        public List<Familia> ObtenerTodo()
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                List<Familia> lista;
                DAOFamilia dao = new DAOFamilia();
                lista = dao.ObtenerTodo();
                transaction.Complete();
                return lista;
            }
        }



        public void AsignarNuevasPatenes(Familia familia, List<System.Windows.Forms.TreeNode> nodos)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                for (int i = 0; i < nodos.Count; i++)
                {
                    if (nodos[i].Text == familia.NombreComponente) nodos.RemoveAt(i);
                }
                BLL.BLLFamilia bllfam = new BLL.BLLFamilia();
                BLL.BLLUsuario bllusu = new BLL.BLLUsuario();
                BLL.BLLPatente bllpat = new BLL.BLLPatente();

                Entidades.Familia fam;
                Entidades.Patente pat;

                ///eliminar relaciones existentes
                List<Entidades.Patente> listapantentes = bllfam.ObtenerPatentes(familia);
                for (int i = 0; i < listapantentes.Count; i++)
                {
                    bllfam.EliminarRelacion(familia, listapantentes[i]);
                }
                List<Entidades.Familia> listafamilias = bllfam.ObtenerFamilias(familia);
                for (int i = 0; i < listafamilias.Count; i++)
                {
                    bllfam.EliminarRelacion(familia, listafamilias[i]);
                }
                ///cargar relaciones nuevas
                foreach (System.Windows.Forms.TreeNode item in nodos)
                {
                    fam = bllfam.ObtenerPorNombre(item.Text);
                    if (fam.Id != Guid.Empty)
                    {
                        bllfam.AgregarRelacion(familia, fam);
                    }
                    else
                    {
                        pat = bllpat.ObtenerPorNombre(item.Text);
                        bllfam.AgregarRelacion(familia, pat);
                    }
                }
                transaction.Complete();
            }
        }
    }
}
