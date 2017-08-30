using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SantaMaria.Servicios.Excepciones;
using SantaMaria.Servicios.UI;

namespace SantaMaria.Servicios.Seguridad.UI
{
    public partial class FrmCrearPermisosPersonalizados : FormBase
    {
        public FrmCrearPermisosPersonalizados()
        {
            InitializeComponent();
        }

        private void FrmCrearPermisosPersonalizados_Load(object sender, EventArgs e)
        {
            MultiIdiioma.MultiIdioma.TraducirForm(this);
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (TxbxDescripcion.Text == "" || TxbxNombre.Text == "")
            {
                Servicios.UI.FormMensaje.CrearAdvertencia("Es necesario llenar todos los campos antes de aceptar.");
                return;
            }
            try
            {
                Seguridad.BLL.BLLFamilia bllfam = new Seguridad.BLL.BLLFamilia();

                Seguridad.Entidades.Familia fam;
                Seguridad.Entidades.Familia fam2 = new Seguridad.Entidades.Familia();

                fam2.NombreComponente = TxbxNombre.Text;
                fam2.DescripcionComponente = TxbxDescripcion.Text;
                bllfam.AgregarFamilia(fam2);
                fam2 = bllfam.ObtenerPorNombre(fam2.NombreComponente);
                fam = bllfam.ObtenerPorNombre("Permisos personalizados");
                bllfam.AgregarRelacion(fam, fam2);

                FormMensaje.CrearExito("<CPermPersExito>");
            }
            catch (BLLException exep)
            {
                FormMensaje.CrearError(exep.Message);
            }
            
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
