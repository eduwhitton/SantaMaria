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
    public class BLLTurno
    {
        public void AgregarTurno(Turno turno)
        {

            DAL.DAO.DAOTurno dao = new DAL.DAO.DAOTurno();
            BLLDisponibilidad blldisp = new BLLDisponibilidad();
            List<Disponibilidad> disponibilidades =
            blldisp.ObtenerPorNroMatricula(turno.nroMatricula);
            bool disponible = false;
            for (int i = 0; i < disponibilidades.Count; i++)
            {
                if (disponibilidades[i].dia == turno.fecha.DayOfWeek.ToString())
                {
                    if (disponibilidades[i].horaInicio.TimeOfDay <= turno.fecha.TimeOfDay && disponibilidades[i].horaFinal.TimeOfDay > turno.fecha.TimeOfDay)
                    {
                        disponible = true;
                    }
                }
            }
            if (!disponible) throw new BLLException("No se puede crear un turno sin disponibilidad.");
            using (TransactionScope transaction = new TransactionScope())
            {
                try
                {
                    dao.AgregarTurno(turno);
                    transaction.Complete();
                }
                catch (Exception ex)
                {
                    throw new BLLException("Error al acceder a la base de datos.", ex);
                }

            }
        }
        public void EliminarTurno(Turno turno)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                DAL.DAO.DAOTurno dao = new DAL.DAO.DAOTurno();
                try
                {
                    dao.EliminarTurno(turno);
                    transaction.Complete();
                }
                catch (Exception ex)
                {
                    throw new BLLException("Error al acceder a la base de datos.", ex);
                }
            }
        }
        public void ModificarTurno(Turno turno)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                DAL.DAO.DAOTurno dao = new DAL.DAO.DAOTurno();
                try
                {
                    dao.ModificarTurno(turno);
                    transaction.Complete();
                }
                catch (Exception ex)
                {
                    throw new BLLException("Error al acceder a la base de datos.", ex);
                }
            }
        }

        public Turno ObtenerPorId(Guid id)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                Turno turno;
                DAL.DAO.DAOTurno dao = new DAL.DAO.DAOTurno();
                try
                {
                    turno = dao.ObtenerPorID(id);
                    transaction.Complete();
                    return turno;
                }
                catch (Exception ex)
                {
                    throw new BLLException("Error al acceder a la base de datos.", ex);
                }
            }
        }
        public List<Turno> ObtenerTodo()
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                List<Turno> lista;
                DAL.DAO.DAOTurno dao = new DAL.DAO.DAOTurno();
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