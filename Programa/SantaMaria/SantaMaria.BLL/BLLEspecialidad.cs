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
    public class BLLEspecialidad
    {
        public void AgregarEspecialidad(Especialidad especialidad)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                DAL.DAO.DAOEspecialidad dao = new DAL.DAO.DAOEspecialidad();
                try
                {
                    dao.AgregarEspecialidad(especialidad);
                    transaction.Complete();
                }
                catch (Exception ex)
                {
                    throw new BLLException("Error al acceder a la base de datos.", ex);
                }

            }
        }
        public void EliminarEspecialidad(Especialidad especialidad)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                DAL.DAO.DAOEspecialidad dao = new DAL.DAO.DAOEspecialidad();
                try
                {
                    dao.EliminarEspecialidad(especialidad);
                    transaction.Complete();
                }
                catch (Exception ex)
                {
                    throw new BLLException("Error al acceder a la base de datos.", ex);
                }
            }
        }
        public void ModificarEspecialidad(Especialidad especialidad)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                DAL.DAO.DAOEspecialidad dao = new DAL.DAO.DAOEspecialidad();
                try
                {
                    dao.ModificarEspecialidad(especialidad);
                    transaction.Complete();
                }
                catch (Exception ex)
                {
                    throw new BLLException("Error al acceder a la base de datos.", ex);
                }
            }
        }
        public Especialidad ObtenerPorCodEspecialidad(int CodEspecialidad)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                Especialidad especialidad;
                DAL.DAO.DAOEspecialidad dao = new DAL.DAO.DAOEspecialidad();
                try
                {
                    especialidad = dao.ObtenerPorCodEspecialidad(CodEspecialidad);
                    transaction.Complete();
                    return especialidad;
                }
                catch (Exception ex)
                {
                    throw new BLLException("Error al acceder a la base de datos.", ex);
                }
            }
        }
        public Especialidad ObtenerPorId(Guid id)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                Especialidad especialidad;
                DAL.DAO.DAOEspecialidad dao = new DAL.DAO.DAOEspecialidad();
                try
                {
                    especialidad = dao.ObtenerPorID(id);
                    transaction.Complete();
                    return especialidad;
                }
                catch (Exception ex)
                {
                    throw new BLLException("Error al acceder a la base de datos.", ex);
                }
            }
        }
        public List<Especialidad> ObtenerTodo()
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                List<Especialidad> lista;
                DAL.DAO.DAOEspecialidad dao = new DAL.DAO.DAOEspecialidad();
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