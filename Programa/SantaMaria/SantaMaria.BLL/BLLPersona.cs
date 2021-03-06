﻿using System;
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
    public class BLLPersona
    {
        public void AgregarPersona(Persona persona)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                DAL.DAO.DAOPersona dao = new DAL.DAO.DAOPersona();
                try
                {
                    dao.AgregarPersona(persona);
                    transaction.Complete();
                }
                catch (Exception ex)
                {
                    throw new BLLException("Error al acceder a la base de datos.", ex);
                }
                
            }
        }
        public void EliminarPersona(Persona persona)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                DAL.DAO.DAOPersona dao = new DAL.DAO.DAOPersona();
                try
                {
                    dao.EliminarPersona(persona);
                    transaction.Complete();
                }
                catch (Exception ex)
                {
                    throw new BLLException("Error al acceder a la base de datos.", ex);
                }
            }
        }
        public void ModificarPersona(Persona persona)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                DAL.DAO.DAOPersona dao = new DAL.DAO.DAOPersona();
                try
                {
                    dao.ModificarPersona(persona); 
                    transaction.Complete();
                }
                catch (Exception ex)
                {
                    throw new BLLException("Error al acceder a la base de datos.", ex);
                }
            }
        }
        public Persona ObtenerPorDNI(int dni)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                Persona persona;
                DAL.DAO.DAOPersona dao = new DAL.DAO.DAOPersona();
                try
                {
                    persona = dao.ObtenerPorDNI(dni);
                    transaction.Complete();
                    return persona;
                }
                catch (Exception ex)
                {
                    throw new BLLException("Error al acceder a la base de datos.", ex);
                }
            }
        }
        public Persona ObtenerPorId(Guid id)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                Persona persona;
                DAL.DAO.DAOPersona dao = new DAL.DAO.DAOPersona();
                try
                {
                    persona = dao.ObtenerPorID(id); 
                    transaction.Complete();
                    return persona;
                }
                catch (Exception ex)
                {
                    throw new BLLException("Error al acceder a la base de datos.", ex);
                }
            }
        }
        public List<Persona> ObtenerTodo()
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                List<Persona> lista;
                DAL.DAO.DAOPersona dao = new DAL.DAO.DAOPersona();
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
