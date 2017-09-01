using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SantaMaria.Servicios.Seguridad;
using SantaMaria.Servicios;
using SantaMaria.Servicios.Excepciones;
using System.Windows.Forms;
using SantaMaria.Servicios.UI;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
namespace SantaMaria.Servicios.Bitacora
{
    /// <summary>
    /// Clase encargada de loggear las actividades y errores del programa. 
    /// Utiliza el padrón observer para notificar a los diferentes loggers que se necesita un nuevo log.
    /// </summary>
    public class Bitacora
    {

        #region singleton
        private static readonly Bitacora instance = new Bitacora();

        private Bitacora()
        {
            eventoError = new Subject<ErrorParameters>();
            eventoActividad = new Subject<ActivityParameters>();

            eventoError.AgregarAEvento(FileLogger.Instance);
            eventoError.AgregarAEvento(DBLogger.Instance);

            eventoActividad.AgregarAEvento(FileLogger.Instance);
            eventoActividad.AgregarAEvento(DBLogger.Instance);
        }

        public static Bitacora Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion

        // Esto es un failsafe para cuando se produce un error en el log, para que no se use ese logger para loggear ese error.

        ISubject<ErrorParameters> eventoError;
        ISubject<ActivityParameters> eventoActividad;
        public void LogError(string mensaje, Exception exep)
        {
            ErrorParameters param = new ErrorParameters();

            param.Message = mensaje;
            param.Exception = exep;
            param.IpAddress = LocalIPAddress;
            param.ErrorDate = DateTime.Now;
            param.CreatedOn = DateTime.Now;
            param.CreatedBy = (null == Contexto.UsuarioActual) ? Guid.Empty : Contexto.UsuarioActual.Id;
            try
            {
                eventoError.Notificar(param);
            }
            catch (BLLException ex)
            {
                FormMensaje.CrearError(ex.Message);
            }
        }
        public void LogActividad(string actividad, string resultado)
        {
            ActivityParameters param = new ActivityParameters();

            param.Activity = actividad;
            param.Result = resultado;
            param.IpAddress = LocalIPAddress;
            param.LogDate = DateTime.Now;
            param.CreatedOn = DateTime.Now;
            param.CreatedBy = (null == Contexto.UsuarioActual) ? Guid.Empty : Contexto.UsuarioActual.Id;

            try
            {
                eventoActividad.Notificar(param);
            }
            catch (BLLException ex)
            {
                FormMensaje.CrearError(ex.Message);
            }
        }

        private String LocalIPAddress
        {
            get
            {
                if (_localIpAdress == null || _localIpAdress == "null")
                {

                    if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                    {
                        return "null";
                    }

                    System.Net.IPHostEntry host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());

                    _localIpAdress = host
                        .AddressList
                        .FirstOrDefault(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).ToString();
                }
                return _localIpAdress;
            }
        }
        private string _localIpAdress;

        public void EliminarLoggerDeLosEventos(ILogger logger)
        {
            eventoActividad.EliminarDeEvento(logger);
            eventoError.EliminarDeEvento(logger);
        }

    }
}
