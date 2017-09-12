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
    public class BLLPaciente
    {
        public void AgregarPaciente(Paciente paciente)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                DAL.DAO.DAOPaciente dao = new DAL.DAO.DAOPaciente();
                try
                {
                    dao.AgregarPaciente(paciente);
                    transaction.Complete();
                }
                catch (Exception ex)
                {
                    throw new BLLException("Error al acceder a la base de datos.", ex);
                }

            }
        }
        public void EliminarPaciente(Paciente paciente)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                DAL.DAO.DAOPaciente dao = new DAL.DAO.DAOPaciente();
                try
                {
                    dao.EliminarPaciente(paciente);
                    transaction.Complete();
                }
                catch (Exception ex)
                {
                    throw new BLLException("Error al acceder a la base de datos.", ex);
                }
            }
        }
        public void ModificarPaciente(Paciente paciente)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                DAL.DAO.DAOPaciente dao = new DAL.DAO.DAOPaciente();
                try
                {
                    dao.ModificarPaciente(paciente);
                    transaction.Complete();
                }
                catch (Exception ex)
                {
                    throw new BLLException("Error al acceder a la base de datos.", ex);
                }
            }
        }
        public Paciente ObtenerPorDNI(int dni)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                Paciente paciente;
                DAL.DAO.DAOPaciente dao = new DAL.DAO.DAOPaciente();
                try
                {
                    paciente = dao.ObtenerPorDNI(dni);
                    transaction.Complete();
                    return paciente;
                }
                catch (Exception ex)
                {
                    throw new BLLException("Error al acceder a la base de datos.", ex);
                }
            }
        }
        public Paciente ObtenerPorId(Guid id)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                Paciente paciente;
                DAL.DAO.DAOPaciente dao = new DAL.DAO.DAOPaciente();
                try
                {
                    paciente = dao.ObtenerPorID(id);
                    transaction.Complete();
                    return paciente;
                }
                catch (Exception ex)
                {
                    throw new BLLException("Error al acceder a la base de datos.", ex);
                }
            }
        }
        public List<Paciente> ObtenerTodo()
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                List<Paciente> lista;
                DAL.DAO.DAOPaciente dao = new DAL.DAO.DAOPaciente();
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
