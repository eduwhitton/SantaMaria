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
    public class BLLDisponibilidad
    {
        public void AgregarDisponibilidad(Disponibilidad disponibilidad)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                DAL.DAO.DAODisponibilidad dao = new DAL.DAO.DAODisponibilidad();
                try
                {
                    dao.AgregarDisponibilidad(disponibilidad);
                    transaction.Complete();
                }
                catch (Exception ex)
                {
                    throw new BLLException("Error al acceder a la base de datos.", ex);
                }

            }
        }
        public void EliminarDisponibilidad(Disponibilidad disponibilidad)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                DAL.DAO.DAODisponibilidad dao = new DAL.DAO.DAODisponibilidad();
                try
                {
                    dao.EliminarDisponibilidad(disponibilidad);
                    transaction.Complete();
                }
                catch (Exception ex)
                {
                    throw new BLLException("Error al acceder a la base de datos.", ex);
                }
            }
        }
        public void ModificarDisponibilidad(Disponibilidad disponibilidad)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                DAL.DAO.DAODisponibilidad dao = new DAL.DAO.DAODisponibilidad();
                try
                {
                    dao.ModificarDisponibilidad(disponibilidad);
                    transaction.Complete();
                }
                catch (Exception ex)
                {
                    throw new BLLException("Error al acceder a la base de datos.", ex);
                }
            }
        }
        public List<Disponibilidad> ObtenerPorCodEspecialidad(int CodEspecialidad)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                List<Disponibilidad> disponibilidad;
                DAL.DAO.DAODisponibilidad dao = new DAL.DAO.DAODisponibilidad();
                try
                {
                    disponibilidad = dao.ObtenerPorCodEspecialidad(CodEspecialidad);
                    transaction.Complete();
                    return disponibilidad;
                }
                catch (Exception ex)
                {
                    throw new BLLException("Error al acceder a la base de datos.", ex);
                }
            }
        }
        public List<Disponibilidad> ObtenerPorNroMatricula(int NroMatricula)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                List<Disponibilidad> disponibilidad;
                DAL.DAO.DAODisponibilidad dao = new DAL.DAO.DAODisponibilidad();
                try
                {
                    disponibilidad = dao.ObtenerPorNroMatricula(NroMatricula);
                    transaction.Complete();
                    return disponibilidad;
                }
                catch (Exception ex)
                {
                    throw new BLLException("Error al acceder a la base de datos.", ex);
                }
            }
        }
        public Disponibilidad ObtenerPorId(Guid id)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                Disponibilidad disponibilidad;
                DAL.DAO.DAODisponibilidad dao = new DAL.DAO.DAODisponibilidad();
                try
                {
                    disponibilidad = dao.ObtenerPorID(id);
                    transaction.Complete();
                    return disponibilidad;
                }
                catch (Exception ex)
                {
                    throw new BLLException("Error al acceder a la base de datos.", ex);
                }
            }
        }
    }
}