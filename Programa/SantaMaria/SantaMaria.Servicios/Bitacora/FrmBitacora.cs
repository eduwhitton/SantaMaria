using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using SantaMaria.Servicios.Excepciones;
using SantaMaria.Servicios.UI;
using SantaMaria.Servicios.MultiIdiioma;
namespace SantaMaria.Servicios.Bitacora
{

    public partial class FrmBitacora : Servicios.UI.FormBase
    {
        public FrmBitacora()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Muestra los primeros 200 resultados de la bitacora
        /// </summary>
        void Actualizar()
        {
            DAOBitacora dao = new DAOBitacora();
            try
            {
                LlenarDataGrid(dao.ObtenerBitacora());
            }
            catch (BLLException ex)
            {
                FormMensaje.CrearError(ex.Message);
            }
        }
        private void FrmBitacora_Load(object sender, EventArgs e)
        {
            MultiIdioma.TraducirForm(this);

            metroGrid1.AutoGenerateColumns = false;
            metroGrid1.AutoSize = true;
            DateTimeHasta.Value = DateTime.Now;

            Actualizar();

        }
        /// <summary>
        /// Filtra 200 entradas de la bitacora por Fecha, Usuario o actividad.
        /// </summary>
        private void BtnFiltrar_Click(object sender, EventArgs e)
        {
            DAOBitacora dao = new DAOBitacora();
            try
            {
                List<BitacoraRow> lista = dao.ObtenerBitacoraFiltrada(
                DateTimeDesde.Value,
                DateTimeHasta.Value,
                TxBxUsuario.Text.Trim(),
                TxbxActividad.Text.Trim()
                );

                LlenarDataGrid(lista);
            }
            catch (BLLException ex)
            {
                FormMensaje.CrearError(ex.Message);
            }
        }

        /// <summary>
        /// Limpia el Datagrid y lo vuelve a llenar con una lista
        /// </summary>
        /// <param name="lista">Datos a mostrar</param>
        void LlenarDataGrid(List<BitacoraRow> lista)
        {
            metroGrid1.Rows.Clear();
            for (int i = 0; i < lista.Count; i++)
            {
                metroGrid1.Rows.Add();
                metroGrid1.Rows[i].Cells[0].Value = lista[i].fecha;
                metroGrid1.Rows[i].Cells[1].Value = lista[i].usuario;
                metroGrid1.Rows[i].Cells[2].Value = lista[i].actividad;
                metroGrid1.Rows[i].Cells[3].Value = lista[i].resultado;
                metroGrid1.Rows[i].Cells[4].Value = lista[i].ip;
            }
            metroGrid1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            metroGrid1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        void ImprimirDataGrid()
        {
            List<BitacoraRow> items = new List<BitacoraRow>();
            BitacoraRow item;
            foreach (DataGridViewRow dr in metroGrid1.Rows)
            {
                item = new BitacoraRow();
                item.fecha = (DateTime)dr.Cells[0].Value;
                item.usuario = dr.Cells[1].Value != null ? dr.Cells[1].Value.ToString() : "" ;
                item.actividad = dr.Cells[2].Value.ToString();
                item.resultado = dr.Cells[3].Value.ToString();
                item.ip = dr.Cells[4].Value != null ? dr.Cells[4].Value.ToString() : "";

                items.Add(item);
            }

            Bitacora.Instance.CrearReporte(items, "Reporte de Bitacora");
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            ImprimirDataGrid();
        }
    }
}
