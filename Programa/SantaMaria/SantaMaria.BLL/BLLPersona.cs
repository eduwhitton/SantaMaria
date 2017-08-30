using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SantaMaria.Entidades;
using SantaMaria.DAL;
using System.Data.SqlClient;
using System.Transactions;


namespace SantaMaria.BLL
{
    /// <summary>
    /// Clase encargada de la logica de negocios
    /// </summary>
    public class BLLPersona
    {
        public void AgregarPersona(Persona persona)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                DAL.DAO.DAOPersona dao = new DAL.DAO.DAOPersona();
                dao.AgregarPersona(persona);
                transaction.Complete();
                
            }
        }
        public void EliminarPersona(Persona persona)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                DAL.DAO.DAOPersona dao = new DAL.DAO.DAOPersona();
                dao.EliminarPersona(persona);
                transaction.Complete();
            }
        }
        public void ModificarPersona(Persona persona)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                DAL.DAO.DAOPersona dao = new DAL.DAO.DAOPersona();
                dao.ModificarPersona(persona);
                transaction.Complete();
            }
        }
        public Persona ObtenerPorDNI(int dni)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                Persona persona;
                DAL.DAO.DAOPersona dao = new DAL.DAO.DAOPersona();
                persona = dao.ObtenerPorDNI(dni);
                transaction.Complete();
                return persona;
            }
        }
        public Persona ObtenerPorId(Guid id)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                Persona persona;
                DAL.DAO.DAOPersona dao = new DAL.DAO.DAOPersona();
                persona = dao.ObtenerPorID(id);
                transaction.Complete();
                return persona;
            }
        }
        public List<Persona> ObtenerTodo()
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                List<Persona> lista;
                DAL.DAO.DAOPersona dao = new DAL.DAO.DAOPersona();
                lista = dao.ObtenerTodo();
                transaction.Complete();
                return lista;
            }
        }
    }
}
