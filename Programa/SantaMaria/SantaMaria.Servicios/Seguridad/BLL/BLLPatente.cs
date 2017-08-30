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
    public class BLLPatente
    {
        public void AgregarPatente(Patente patente)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                DAOPatente dao = new DAOPatente();
                dao.AgregarPatente(patente);
                transaction.Complete();

            }
        }
        public void EliminarPatente(Patente patente)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                DAOPatente dao = new DAOPatente();
                dao.EliminarPatente(patente);
                transaction.Complete();
            }
        }
        public void ModificarPatente(Patente patente)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                DAOPatente dao = new DAOPatente();
                dao.ModificarPatente(patente);
                transaction.Complete();
            }
        }
        public Patente ObtenerPorNombre(string nombre)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                Patente patente;
                DAOPatente dao = new DAOPatente();
                patente = dao.ObtenerPorNombre(nombre);
                transaction.Complete();
                return patente;
            }
        }
        public List<Patente> ObtenerTodo()
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                List<Patente> lista;
                DAOPatente dao = new DAOPatente();
                lista = dao.ObtenerTodo();
                transaction.Complete();
                return lista;
            }
        }


    }
}
