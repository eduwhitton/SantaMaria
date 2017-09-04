using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Windows.Forms;
using SantaMaria.Servicios.UI;
using SantaMaria.Servicios.Excepciones;
namespace SantaMaria.Servicios
{
    public static class Informes
    {
        /// <summary>
        /// Crea reportes mostrando una tabla de forma genérica
        /// </summary>
        /// <param name="arr">Matriz que contiene los datos. La primera fila son los títulos.</param>
        /// <param name="titulo"></param>
        public static void CrearReporte(string[][] arr, string titulo)
        {

            SaveFileDialog sfd = new SaveFileDialog();

            sfd.AddExtension = true;
            sfd.DefaultExt = ".pdf";
            sfd.FileName = "Reporte.pdf";
            sfd.Filter = "Archivos pdf (*.pdf)|*.pdf";
            sfd.FilterIndex = 0;
            sfd.OverwritePrompt = true;
            sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            DialogResult resultado = sfd.ShowDialog();

            PdfWriter writer;
            if (resultado == System.Windows.Forms.DialogResult.Cancel) return;

            Document doc = new Document(PageSize.A4);
            try
            {
                writer = PdfWriter.GetInstance(doc, sfd.OpenFile());
            }
            catch (Exception ex)
            {
                doc.Close();

                throw new BLLException("Cerrar al archivo antes de intentar sobreescribirlo.",ex);
            }

            doc.AddTitle(titulo);
            doc.AddCreator("Santa María");

            doc.Open();

            Font letraGrande = new Font(Font.FontFamily.HELVETICA, 18, Font.BOLD, BaseColor.BLACK);
            Font letraNormal = new Font(Font.FontFamily.HELVETICA, 14, Font.NORMAL, BaseColor.BLACK);
            Font letraChica = new Font(Font.FontFamily.HELVETICA, 10, Font.NORMAL, BaseColor.BLACK);

            doc.Add(new Paragraph(titulo, letraGrande));
            doc.Add(Chunk.NEWLINE);

            //Tabla
            PdfPTable tabla = new PdfPTable(arr[0].Length);
            tabla.WidthPercentage = 100;

            PdfPCell celda;
            // Columnas
            for (int i = 0; i < arr[0].Length; i++)
            {
                celda = new PdfPCell(new Phrase(arr[0][i], letraNormal));
                celda.BorderWidth = 0;
                celda.BorderWidthBottom = 0.75f;
                tabla.AddCell(celda);
            }

            // Celdas
            for (int i = 1; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[0].Length; j++)
                {
                    celda = new PdfPCell(new Phrase(arr[i][j], letraChica));
                    celda.BorderWidth = 0;
                    tabla.AddCell(celda);
                }
            }

            doc.Add(tabla);

            doc.Close();
            writer.Close();

            FormMensaje.CrearExito("<InformesExito>");
        }
    }
}
