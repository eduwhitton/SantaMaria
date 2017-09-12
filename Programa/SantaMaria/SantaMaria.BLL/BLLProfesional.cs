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
    public class BLLProfesional
    {

        public void AgregarProfesional(Profesional profesional)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                DAL.DAO.DAOProfesional dao = new DAL.DAO.DAOProfesional();
                try
                {
                    dao.AgregarProfesional(profesional);
                    transaction.Complete();
                }
                catch (Exception ex)
                {
                    throw new BLLException("Error al acceder a la base de datos.", ex);
                }

            }
        }
        public void EliminarProfesional(Profesional profesional)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                DAL.DAO.DAOProfesional dao = new DAL.DAO.DAOProfesional();
                try
                {
                    dao.EliminarProfesional(profesional);
                    transaction.Complete();
                }
                catch (Exception ex)
                {
                    throw new BLLException("Error al acceder a la base de datos.", ex);
                }
            }
        }
        public void ModificarProfesional(Profesional profesional)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                DAL.DAO.DAOProfesional dao = new DAL.DAO.DAOProfesional();
                try
                {
                    dao.ModificarProfesional(profesional);
                    transaction.Complete();
                }
                catch (Exception ex)
                {
                    throw new BLLException("Error al acceder a la base de datos.", ex);
                }
            }
        }
        public Profesional ObtenerPorDNI(int dni)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                Profesional profesional;
                DAL.DAO.DAOProfesional dao = new DAL.DAO.DAOProfesional();
                try
                {
                    profesional = dao.ObtenerPorDNI(dni);
                    transaction.Complete();
                    return profesional;
                }
                catch (Exception ex)
                {
                    throw new BLLException("Error al acceder a la base de datos.", ex);
                }
            }
        }
        public Profesional ObtenerPorId(Guid id)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                Profesional profesional;
                DAL.DAO.DAOProfesional dao = new DAL.DAO.DAOProfesional();
                try
                {
                    profesional = dao.ObtenerPorID(id);
                    transaction.Complete();
                    return profesional;
                }
                catch (Exception ex)
                {
                    throw new BLLException("Error al acceder a la base de datos.", ex);
                }
            }
        }
        public List<Profesional> ObtenerTodo()
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                List<Profesional> lista;
                DAL.DAO.DAOProfesional dao = new DAL.DAO.DAOProfesional();
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
