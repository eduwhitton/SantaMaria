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
    public class BLLHistoriaClinica
    {
        public void AgregarHistoriaClinica(HistoriaClinica historiaClinica)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                DAL.DAO.DAOHistoriaClinica dao = new DAL.DAO.DAOHistoriaClinica();
                try
                {
                    dao.AgregarHistoriaClinica(historiaClinica);
                    transaction.Complete();
                }
                catch (Exception ex)
                {
                    throw new BLLException("Error al acceder a la base de datos.", ex);
                }

            }
        }
        public void EliminarHistoriaClinica(HistoriaClinica historiaClinica)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                DAL.DAO.DAOHistoriaClinica dao = new DAL.DAO.DAOHistoriaClinica();
                try
                {
                    dao.EliminarHistoriaClinica(historiaClinica);
                    transaction.Complete();
                }
                catch (Exception ex)
                {
                    throw new BLLException("Error al acceder a la base de datos.", ex);
                }
            }
        }
        public void ModificarHistoriaClinica(HistoriaClinica historiaClinica)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                DAL.DAO.DAOHistoriaClinica dao = new DAL.DAO.DAOHistoriaClinica();
                try
                {
                    dao.ModificarHistoriaClinica(historiaClinica);
                    transaction.Complete();
                }
                catch (Exception ex)
                {
                    throw new BLLException("Error al acceder a la base de datos.", ex);
                }
            }
        }
        public List<HistoriaClinica> ObtenerPorDNI(int dni)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                List<HistoriaClinica> historiasClinicas;
                DAL.DAO.DAOHistoriaClinica dao = new DAL.DAO.DAOHistoriaClinica();
                try
                {
                    historiasClinicas = dao.ObtenerPorDNI(dni);
                    transaction.Complete();
                    return historiasClinicas;
                }
                catch (Exception ex)
                {
                    throw new BLLException("Error al acceder a la base de datos.", ex);
                }
            }
        }
        public HistoriaClinica ObtenerPorId(Guid id)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                HistoriaClinica historiaClinica;
                DAL.DAO.DAOHistoriaClinica dao = new DAL.DAO.DAOHistoriaClinica();
                try
                {
                    historiaClinica = dao.ObtenerPorID(id);
                    transaction.Complete();
                    return historiaClinica;
                }
                catch (Exception ex)
                {
                    throw new BLLException("Error al acceder a la base de datos.", ex);
                }
            }
        }
    }
}