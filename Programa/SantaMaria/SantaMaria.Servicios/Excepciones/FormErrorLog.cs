using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SantaMaria.Servicios.UI;
using SantaMaria.Servicios.MultiIdiioma;

namespace SantaMaria.Servicios.Excepciones
{
    public partial class FrmErrorLog : FormBase
    {
        public FrmErrorLog()
        {
            InitializeComponent();
        }
        void Actualizar()
        {
            DAOErrorLog dao = new DAOErrorLog();
            try
            {
                LlenarDataGrid(dao.ObtenerErrorLog());
            }
            catch (BLLException ex)
            {
                FormMensaje.CrearError(ex.Message);
            }
        }
        private void FormErrorLog_Load(object sender, EventArgs e)
        {
            MultiIdioma.TraducirForm(this);

            metroGrid1.AutoGenerateColumns = false;
            metroGrid1.AutoSize = true;
            DateTimeHasta.Value = DateTime.Now;

            Actualizar();

        }
        /// <summary>
        /// Filtra 200 entradas del ErrorLog por Fecha, Usuario o actividad.
        /// </summary>
        private void BtnFiltrar_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Limpia el Datagrid y lo vuelve a llenar con una lista
        /// </summary>
        /// <param name="lista">Datos a mostrar</param>
        void LlenarDataGrid(List<ErrorLogRow> lista)
        {
            metroGrid1.Rows.Clear();
            for (int i = 0; i < lista.Count; i++)
            {
                metroGrid1.Rows.Add();
                metroGrid1.Rows[i].Cells[0].Value = lista[i].fecha;
                metroGrid1.Rows[i].Cells[1].Value = lista[i].usuario;
                metroGrid1.Rows[i].Cells[2].Value = lista[i].mensaje;
                metroGrid1.Rows[i].Cells[3].Value = lista[i].excepcion;
                metroGrid1.Rows[i].Cells[4].Value = lista[i].ip;
            }
            metroGrid1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            metroGrid1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        void ImprimirDataGrid()
        {
            List<string[]> items = new List<string[]>();
            string[] item = new string[5];

            item[0] = "Fecha";
            item[1] = "Usuario";
            item[2] = "Mensaje";
            item[3] = "Excepción";
            item[4] = "Direción IP";

            items.Add(item);

            foreach (DataGridViewRow dr in metroGrid1.Rows)
            {
                item = new string[5];
                item[0] = dr.Cells[0].Value.ToString();
                item[1] = dr.Cells[1].Value != null ? dr.Cells[1].Value.ToString() : "";
                item[2] = dr.Cells[2].Value.ToString();
                item[3] = dr.Cells[3].Value.ToString();
                item[4] = dr.Cells[4].Value != null ? dr.Cells[4].Value.ToString() : "";

                items.Add(item);
            }
            Informes.CrearReporte(items.ToArray(), "Reporte de Errores");
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            ImprimirDataGrid();
        }


    }
}
