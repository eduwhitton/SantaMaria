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
using SantaMaria.Servicios.Excepciones;

namespace SantaMaria.Servicios.Seguridad.UI
{
    public partial class FrmUsuarios : FormBase
    {
        public FrmUsuarios()
        {
            InitializeComponent();
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            MultiIdiioma.MultiIdioma.TraducirForm(this);
            ActualizarListview();
            VerificarAutorizacion();
        }

        private void VerificarAutorizacion()
        {
            BtnHabilitar.Enabled = Servicios.Seguridad.Autorizacion.VerificarPermiso("Habilitar Usuario");

            BtnDeshabilitar.Enabled = Servicios.Seguridad.Autorizacion.VerificarPermiso("Deshabilitar Usuario");

            BtnDelete.Enabled = Servicios.Seguridad.Autorizacion.VerificarPermiso("Eliminar Usuario");
        }


        void ActualizarListview()
        {
            listView1.Clear();

            listView1.Columns.Add("Usuario", -1);
            listView1.Columns.Add("Nombre", -1);
            listView1.Columns.Add("Descripcion", -1);

            BLL.BLLUsuario bll = new BLL.BLLUsuario();
            List<Entidades.Usuario> col = bll.ObtenerTodo();

            ListViewItem item = new ListViewItem();
            item.UseItemStyleForSubItems = true;
            item.SubItems.Add("wow");
            item.SubItems.Add("doge");
            item.SubItems.Add("Id papa");
            for (int i = 0; i < col.Count; i++)
            {
                item.SubItems[0] = new ListViewItem.ListViewSubItem(item, col[i].usuario);
                item.SubItems[1] = new ListViewItem.ListViewSubItem(item, col[i].Nombre);
                item.SubItems[2] = new ListViewItem.ListViewSubItem(item, col[i].DescripcionComponente);
                item.SubItems[3] = new ListViewItem.ListViewSubItem(item, col[i].Id.ToString());
                if (col[i].habilitado) item.ForeColor = Color.Black;
                else item.ForeColor = Color.Gray;

                listView1.Items.Add((ListViewItem)item.Clone());
            }
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.Columns[2].Width = -2;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BtnHabilitar_Click(object sender, EventArgs e)
        {
            try
            {
                BLL.BLLUsuario bll = new BLL.BLLUsuario();
                bll.HabilitarUsuario(bll.ObtenerPorId(new Guid(listView1.SelectedItems[0].SubItems[3].Text)));

                Bitacora.Bitacora.Instance.LogActividad("Habilitación del usuario " + listView1.SelectedItems[0].SubItems[0].Text, "Success");
                ActualizarListview();
            }
            catch (BLLException ex)
            {
                FormMensaje.CrearError(ex.Message);
            }
        }

        private void BtnDesHabilitar_Click(object sender, EventArgs e)
        {
            try
            {
                BLL.BLLUsuario bll = new BLL.BLLUsuario();
                bll.DeshabilitarUsuario(bll.ObtenerPorId(new Guid(listView1.SelectedItems[0].SubItems[3].Text)));
                Bitacora.Bitacora.Instance.LogActividad("Deshabilitación del usuario " + listView1.SelectedItems[0].SubItems[0].Text, "Success");
                ActualizarListview();
            }
            catch (BLLException ex)
            {
                FormMensaje.CrearError(ex.Message);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                BLL.BLLUsuario bll = new BLL.BLLUsuario();
                bll.EliminarUsuario(bll.ObtenerPorId(new Guid(listView1.SelectedItems[0].SubItems[3].Text)));
                Bitacora.Bitacora.Instance.LogActividad("Eliminación del usuario " + listView1.SelectedItems[0].SubItems[0].Text, "Success");
                ActualizarListview();
            }
            catch (BLLException ex)
            {
                FormMensaje.CrearError(ex.Message);
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {

            List<string[]> items = new List<string[]>();
            string[] item = new string[3];

            item[0] = "Usuario";
            item[1] = "Nombre";
            item[2] = "Descripción";

            items.Add(item);

            foreach (ListViewItem row in listView1.Items)
            {
                item = new string[3];
                item[0] = row.SubItems[0].Text;
                item[1] = row.SubItems[1].Text;
                item[2] = row.SubItems[2].Text;

                items.Add(item);
            }
            try
            {
                Informes.CrearReporte(items.ToArray(), "Reporte de Usuarios");
            }
            catch (BLLException ex)
            {
                FormMensaje.CrearError(ex.Message);
            }
        }
    }

}
