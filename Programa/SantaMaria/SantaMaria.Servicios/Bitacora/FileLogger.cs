using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;
using SantaMaria.Servicios.Excepciones;

namespace SantaMaria.Servicios.Bitacora
{
    /// <summary>
    /// Clase que loguea en un archivo plano. Implementa el patrón observador al observar cada vez que se
    /// levanta el evento de error o el evento de actividad
    /// </summary>
    public class FileLogger : ILogger
    {
        public string MensajeDeError { get { return "Error al loggear en la base de datos"; } }
        #region singleton
        private static readonly FileLogger instance = new FileLogger();

        private FileLogger() { }

        public static FileLogger Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion
        public void Update(ActivityParameters nuevo)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("ACTIVIDAD");
            sb.AppendLine();
            sb.Append("Hora: ");
            sb.AppendFormat("{0:HH:mm:ss.ffff}", nuevo.LogDate);
            sb.AppendLine();
            sb.Append("Actividad: ");
            sb.Append(nuevo.Activity);
            sb.AppendLine();
            sb.Append("Resultado: ");
            sb.Append(nuevo.Result);
            sb.AppendLine();
            sb.Append("Dirección IP: ");
            sb.Append(nuevo.IpAddress);
            sb.AppendLine();
            if (nuevo.CreatedOn != null)
            {
                sb.Append("Creado el: ");
                sb.Append(nuevo.CreatedOn);
                sb.AppendLine();
            }

            if (nuevo.CreatedBy != null)
            {
                sb.Append("Creado por: ");
                sb.Append(nuevo.CreatedBy);
                sb.AppendLine();
            }

            if (nuevo.ChangedOn != null)
            {
                sb.Append("Modificado en: ");
                sb.Append(nuevo.ChangedOn);
                sb.AppendLine();
            }

            if (nuevo.ChangedBy != null)
            {
                sb.Append("Modificado por: ");
                sb.Append(nuevo.ChangedBy);
                sb.AppendLine();
            }

            sb.Append('=', 20);
            sb.AppendLine();

            try
            {
                NuevoLog(sb.ToString());
            }
            catch (Exception ex)
            {
                throw new BLLException("Error al loggear en la base de datos", ex);
            }
        }

        public void Update(ErrorParameters nuevo)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("ERROR");
            sb.AppendLine();
            sb.Append("Hora: ");
            sb.AppendFormat("{0:HH:mm:ss.ffff}", nuevo.ErrorDate);
            sb.AppendLine();
            sb.Append("Mensaje: ");
            sb.Append(nuevo.Message);
            sb.AppendLine();
            sb.Append("Exception: ");
            sb.Append(nuevo.Exception);
            sb.AppendLine();
            sb.Append("Dirección IP: ");
            sb.Append(nuevo.IpAddress);
            sb.AppendLine();
            if (nuevo.CreatedOn != null)
            {
                sb.Append("Creado el: ");
                sb.Append(nuevo.CreatedOn);
                sb.AppendLine();
            }

            if (nuevo.CreatedBy != null)
            {
                sb.Append("Creado por: ");
                sb.Append(nuevo.CreatedBy);
                sb.AppendLine();
            }

            if (nuevo.ChangedOn != null)
            {
                sb.Append("Modificado en: ");
                sb.Append(nuevo.ChangedOn);
                sb.AppendLine();
            }

            if (nuevo.ChangedBy != null)
            {
                sb.Append("Modificado por: ");
                sb.Append(nuevo.ChangedBy);
                sb.AppendLine();
            }

            sb.Append('=', 20);
            sb.AppendLine();
            try
            {
                NuevoLog(sb.ToString());
            }
            catch (Exception ex)
            {
                Bitacora.Instance.EliminarLoggerDeLosEventos(Instance);
                throw new BLLException("Error al loggear en la base de datos", ex);
            }
        }
        string Path
        {
            get
            {
                return ConfigurationManager.AppSettings["LogsPath"];
            }
        }
        public void NuevoLog(string mensaje)
        {
            //Verifica que exista la carpeta
            if (!Directory.Exists(Path))
            {
                Directory.CreateDirectory(Path);
            }

            //Verifica que exista el archivo
            string ArchivoPath = Path + "Log " + String.Format("{0:yy}-{0:MM}-{0:dd}", DateTime.Now) + ".txt";

            using (FileStream archivo = File.Open(ArchivoPath, FileMode.OpenOrCreate, FileAccess.ReadWrite)) { }

            //Crea el Log
            using (FileStream archivo = File.Open(ArchivoPath, FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter escritor = new StreamWriter(archivo))
                {
                    escritor.WriteLine(mensaje);
                }
            }
        }







    }
}
