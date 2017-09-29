using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SantaMaria.Entidades;
using SantaMaria.DAL;
using System.Data.SqlClient;
using System.Transactions;
using SantaMaria.Servicios.Excepciones;

namespace SantaMaria.BLL
{
    /// <summary>
    /// Clase encargada de la logica de negocios
    /// </summary>
    public class BLLCobertura
    {
        public void AgregarCobertura(Cobertura cobertura)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                DAL.DAO.DAOCobertura dao = new DAL.DAO.DAOCobertura();
                try
                {
                    dao.AgregarCobertura(cobertura);
                    transaction.Complete();
                }
                catch (Exception ex)
                {
                    throw new BLLException("Error al acceder a la base de datos.", ex);
                }

            }
        }
        public void EliminarCobertura(Cobertura cobertura)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                DAL.DAO.DAOCobertura dao = new DAL.DAO.DAOCobertura();
                try
                {
                    dao.EliminarCobertura(cobertura);
                    transaction.Complete();
                }
                catch (Exception ex)
                {
                    throw new BLLException("Error al acceder a la base de datos.", ex);
                }
            }
        }
        public void ModificarCobertura(Cobertura cobertura)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                DAL.DAO.DAOCobertura dao = new DAL.DAO.DAOCobertura();
                try
                {
                    dao.ModificarCobertura(cobertura);
                    transaction.Complete();
                }
                catch (Exception ex)
                {
                    throw new BLLException("Error al acceder a la base de datos.", ex);
                }
            }
        }
        public Cobertura ObtenerPorCodCobertura(int CodCobertura)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                Cobertura cobertura;
                DAL.DAO.DAOCobertura dao = new DAL.DAO.DAOCobertura();
                try
                {
                    cobertura = dao.ObtenerPorCodCobertura(CodCobertura);
                    transaction.Complete();
                    return cobertura;
                }
                catch (Exception ex)
                {
                    throw new BLLException("Error al acceder a la base de datos.", ex);
                }
            }
        }
        public Cobertura ObtenerPorId(Guid id)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                Cobertura cobertura;
                DAL.DAO.DAOCobertura dao = new DAL.DAO.DAOCobertura();
                try
                {
                    cobertura = dao.ObtenerPorID(id);
                    transaction.Complete();
                    return cobertura;
                }
                catch (Exception ex)
                {
                    throw new BLLException("Error al acceder a la base de datos.", ex);
                }
            }
        }
        public List<Cobertura> ObtenerTodo()
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                List<Cobertura> lista;
                DAL.DAO.DAOCobertura dao = new DAL.DAO.DAOCobertura();
                try
                {
                    lista = dao.ObtenerTodo();
                    transaction.Complete();
                    return lista;
                }
                catch (Exception ex)
                {
                    throw new BLLException("Error al acceder a la base de datos.", ex);
                }
            }
        }
    }
}