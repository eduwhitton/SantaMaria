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

        public void CrearReporte(List<BitacoraRow> lista, string titulo)
        {

            SaveFileDialog sfd = new SaveFileDialog();

            sfd.AddExtension = true;
            sfd.DefaultExt = ".pdf";
            sfd.FileName = "Reporte.pdf";
            sfd.Filter = "Archivos pdf (*.pdf)|*.pdf";
            sfd.FilterIndex = 0;
            sfd.OverwritePrompt = true;


            DialogResult resultado = sfd.ShowDialog();
            
            if (resultado == System.Windows.Forms.DialogResult.Cancel) return;

            Document doc = new Document(PageSize.A4);
            PdfWriter writer = PdfWriter.GetInstance(doc,sfd.OpenFile());

            doc.AddTitle(titulo);
            doc.AddCreator("Santa María");

            doc.Open();

            Font letraGrande = new Font(Font.FontFamily.HELVETICA, 18, Font.BOLD, BaseColor.BLACK);
            Font letraNormal = new Font(Font.FontFamily.HELVETICA, 14, Font.NORMAL, BaseColor.BLACK);
            Font letraChica = new Font(Font.FontFamily.HELVETICA, 10, Font.NORMAL, BaseColor.BLACK);

            doc.Add(new Paragraph(titulo, letraGrande));
            doc.Add(Chunk.NEWLINE);

            //Tabla
            PdfPTable tabla = new PdfPTable(5);
            tabla.WidthPercentage = 100;
            tabla.SetWidths(new int[]{20,10,40,15,15});

            // Columnas
            PdfPCell celda = new PdfPCell(new Phrase("Fecha", letraNormal));
            celda.BorderWidth = 0;
            celda.BorderWidthBottom = 0.75f;
            celda.BorderWidthRight = 0.5f;
            tabla.AddCell(celda);

            celda = new PdfPCell(new Phrase("Usuario", letraNormal));
            celda.BorderWidth = 0;
            celda.BorderWidthBottom = 0.75f;
            celda.BorderWidthRight = 0.5f;
            celda.BorderWidthLeft = 0.5f;
            tabla.AddCell(celda);

            celda = new PdfPCell(new Phrase("Actividad", letraNormal));
            celda.BorderWidth = 0;
            celda.BorderWidthRight = 0.5f;
            celda.BorderWidthLeft = 0.5f;
            celda.BorderWidthBottom = 0.75f;
            tabla.AddCell(celda);

            celda = new PdfPCell(new Phrase("Resultado", letraNormal));
            celda.BorderWidth = 0;
            celda.BorderWidthRight = 0.5f;
            celda.BorderWidthLeft = 0.5f;
            celda.BorderWidthBottom = 0.75f;
            tabla.AddCell(celda);

            celda = new PdfPCell(new Phrase("Dirección IP", letraNormal));
            celda.BorderWidth = 0;
            celda.BorderWidthLeft = 0.5f;
            celda.BorderWidthBottom = 0.75f;
            tabla.AddCell(celda);

            // Celdas
            for (int i = 0; i < lista.Count; i++)
            {
                celda = new PdfPCell(new Phrase(lista[i].fecha.ToString(), letraChica));
                celda.BorderWidth = 0;
                tabla.AddCell(celda);

                celda = new PdfPCell(new Phrase(lista[i].usuario, letraChica));
                celda.BorderWidth = 0;
                tabla.AddCell(celda);

                celda = new PdfPCell(new Phrase(lista[i].actividad, letraChica));
                celda.BorderWidth = 0;
                tabla.AddCell(celda);

                celda = new PdfPCell(new Phrase(lista[i].resultado, letraChica));
                celda.BorderWidth = 0;
                tabla.AddCell(celda);

                celda = new PdfPCell(new Phrase(lista[i].ip, letraChica));
                celda.BorderWidth = 0;
                tabla.AddCell(celda);
            }

            doc.Add(tabla);

            doc.Close();
            writer.Close();
        }
    }
}
