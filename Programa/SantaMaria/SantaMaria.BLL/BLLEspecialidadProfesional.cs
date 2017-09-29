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
    public class BLLEspecialidadProfesional
    {
        public void AgregarEspecialidadProfesional(EspecialidadProfesional especialidadProfesional)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                DAL.DAO.DAOEspecialidadProfesional dao = new DAL.DAO.DAOEspecialidadProfesional();
                try
                {
                    dao.AgregarEspecialidadProfesional(especialidadProfesional);
                    transaction.Complete();
                }
                catch (Exception ex)
                {
                    throw new BLLException("Error al acceder a la base de datos.", ex);
                }

            }
        }
        public void EliminarEspecialidadProfesional(EspecialidadProfesional especialidadProfesional)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                DAL.DAO.DAOEspecialidadProfesional dao = new DAL.DAO.DAOEspecialidadProfesional();
                try
                {
                    dao.EliminarEspecialidadProfesional(especialidadProfesional);
                    transaction.Complete();
                }
                catch (Exception ex)
                {
                    throw new BLLException("Error al acceder a la base de datos.", ex);
                }
            }
        }
        public void ModificarEspecialidadProfesional(EspecialidadProfesional especialidadProfesional)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                DAL.DAO.DAOEspecialidadProfesional dao = new DAL.DAO.DAOEspecialidadProfesional();
                try
                {
                    dao.ModificarEspecialidadProfesional(especialidadProfesional);
                    transaction.Complete();
                }
                catch (Exception ex)
                {
                    throw new BLLException("Error al acceder a la base de datos.", ex);
                }
            }
        }

        public EspecialidadProfesional ObtenerPorId(Guid id)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                EspecialidadProfesional especialidadProfesional;
                DAL.DAO.DAOEspecialidadProfesional dao = new DAL.DAO.DAOEspecialidadProfesional();
                try
                {
                    especialidadProfesional = dao.ObtenerPorID(id);
                    transaction.Complete();
                    return especialidadProfesional;
                }
                catch (Exception ex)
                {
                    throw new BLLException("Error al acceder a la base de datos.", ex);
                }
            }
        }
        public List<EspecialidadProfesional> ObtenerPorNroMatricula(int nroMatricula)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                List<EspecialidadProfesional> lista;
                DAL.DAO.DAOEspecialidadProfesional dao = new DAL.DAO.DAOEspecialidadProfesional();
                try
                {
                    lista = dao.ObtenerPorNroMatricula(nroMatricula);
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