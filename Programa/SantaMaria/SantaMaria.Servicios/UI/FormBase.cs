using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SantaMaria.Servicios.Bitacora;
using System.Globalization;
using SantaMaria.Servicios.MultiIdiioma;

namespace SantaMaria.Servicios.UI
{
    public partial class FormBase : MetroFramework.Forms.MetroForm, IObservador<CultureInfo>, IDisposable
    {
        public FormBase()
        {
            MultiIdioma.AgregarAlEvento(this);
        }

        private void FormBase_Load(object sender, EventArgs e)
        {
            MultiIdioma.TraducirForm(this);
        }
        public void Update(CultureInfo nuevo)
        {
            MultiIdioma.TraducirForm(this);
        }

        void IDisposable.Dispose()
        {
            MultiIdioma.ElminarDelEvento(this);
        }
    }
}
