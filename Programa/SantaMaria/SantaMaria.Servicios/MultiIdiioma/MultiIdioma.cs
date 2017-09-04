using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using SantaMaria.Servicios.Bitacora;
using System.Text.RegularExpressions;

namespace SantaMaria.Servicios.MultiIdiioma
{
    /// <summary>
    /// Clase estática que traduce los controles dentro de un form a diferentes idiomas
    /// </summary>
    public static class MultiIdioma
    {
        private static Dictionary<string, string> _palabras;
        private static Dictionary<string, string> Palabras
        {
            get
            {
                if (_palabras == null)
                {
                    ObtenerDiccionarioIdioma();
                }
                return _palabras;
            }
            set
            { _palabras = value; }
        }

        private static Dictionary<string, string> palabrasViejasInvertidas;

        private static CultureInfo _cultura;

        public static void TraducirForm(Control control)
        {
            MultiIdioma.Destraducir(control);
            MultiIdioma.Traducir(control);
        }
        private static void Destraducir(Control control)
        {
            if (palabrasViejasInvertidas == null) return;
            Traducir(control, palabrasViejasInvertidas);
        }
        private static void Traducir(Control control)
        {
            Traducir(control, Palabras);
        }
        private static void Traducir(Control control, Dictionary<string, string> dic)
        {
            if (control is Label || control is Button) //Controles traducibles sin controles adentro
            {
                if (dic.ContainsKey(control.Text)) ///buscar texto a remplazar
                    control.Text = dic[control.Text]; //remplazar
            }
            else if (control is Form)//controles traducibles con controles adentro
            {
                if (dic.ContainsKey(control.Text)) ///buscar texto a remplazar
                    control.Text = dic[control.Text]; //remplazar
                foreach (Control child in control.Controls)
                {
                    Traducir(child, dic);
                }
            }            
            else if (control is MenuStrip)//Excepcion para menustrip
            {
                foreach (ToolStripMenuItem menu in ((MenuStrip)control).Items)
                {
                    TraducirToolStripMenuItem(menu, dic);
                }
                foreach (ToolStripItem item in ((MenuStrip)control).Items)
                {
                    if (dic.ContainsKey(item.Text)) ///buscar texto a remplazar
                        item.Text = dic[item.Text]; //remplazar
                }
            }
            else if (control is TabControl)
            {
                foreach (TabPage item in ((TabControl)control).TabPages)
                {
                    if (dic.ContainsKey(item.Text)) ///buscar texto a remplazar
                        item.Text = dic[item.Text]; //remplazar
                } 
                foreach (Control child in control.Controls)
                {
                    Traducir(child, dic);
                }
            }
            else foreach (Control child in control.Controls) //controles intraducibles
                {
                    Traducir(child, dic);
                }
        }
        /// <summary>
        /// Caso excepcional para traducir ToolStripMenu ya que necesitan un caso especial de recursividad
        /// </summary>
        /// <param name="control"></param>
        /// <param name="dic"></param>
        private static void TraducirToolStripMenuItem(ToolStripMenuItem control, Dictionary<string, string> dic)
        {
            foreach (ToolStripMenuItem menu in control.DropDownItems)
            {
                if (dic.ContainsKey(menu.Text)) ///buscar texto a remplazar
                    menu.Text = dic[menu.Text]; //remplazar
                TraducirToolStripMenuItem(menu, dic);
            }
            foreach (ToolStripItem item in control.DropDownItems)
            {
                if (dic.ContainsKey(item.Text)) ///buscar texto a remplazar
                    item.Text = dic[item.Text]; //remplazar
            }
        }
        public static string TraducirFrase(String frase)
        {
            Regex reg = new Regex("<(.*?)>");
            foreach (Match item in reg.Matches(frase))
            {
                if (Palabras.ContainsKey(item.Value)) ///buscar texto a remplazar
                    frase = frase.Replace(item.Value, Palabras[item.Value]);
            }

            return frase;
        }

        public static CultureInfo CulturaActual
        {
            get
            {///fix traduccion
                if (_cultura == null) _cultura = new CultureInfo("es-AR");
                return _cultura;
            }
            set
            {
                _cultura = value;
            }
        }

        static ISubject<CultureInfo> eventoCambioCultura = new Subject<CultureInfo>();

        public static void AgregarAlEvento(IObservador<CultureInfo> observador)
        {
            eventoCambioCultura.AgregarAEvento(observador);
        }

        public static void ElminarDelEvento(IObservador<CultureInfo> observador)
        {
            eventoCambioCultura.EliminarDeEvento(observador);
        }

        public static void CambiarIdioma(string cultura)
        {
            CambiarIdioma(new CultureInfo(cultura));
        }
        public static void CambiarIdioma(CultureInfo cultura)
        {
            CulturaActual = cultura;
            DAOMultiidioma dao = new DAOMultiidioma();
            if (Palabras != null)
               palabrasViejasInvertidas = Palabras.ToDictionary(kp => kp.Value, kp => kp.Key); //Invierte el diccionario viejo y lo guarda
            ObtenerDiccionarioIdioma();
            eventoCambioCultura.Notificar(CulturaActual);
        }
        public static List<string> ListarIdiomas()
        {
            DAOMultiidioma dao = new DAOMultiidioma();
            return dao.ObtenerIdiomas();
        }

        private static void ObtenerDiccionarioIdioma()
        {
            try
            {
                DAOMultiidioma dao = new DAOMultiidioma();
                Palabras = dao.ObtenerDiccionarioIdioma(CulturaActual.ToString());
            }
            catch (Exception ex)
            {
                UI.FormMensaje.CrearError(ex.Message);
            }
        }

    }
}
