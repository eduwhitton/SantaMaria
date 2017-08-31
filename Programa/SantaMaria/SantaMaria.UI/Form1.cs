using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SantaMaria.Servicios;
using Seguridad = SantaMaria.Servicios.Seguridad;
using SantaMaria.Servicios.MultiIdiioma;
using SantaMaria.Servicios.Bitacora;
using System.Globalization;
using SantaMaria.Servicios.Excepciones;
using SantaMaria.Servicios.UI;

namespace SantaMaria.UI
{
    public partial class Form1 : FormBase
    {
        public Form1()
        {
            InitializeComponent();

            //El usuario no debería setearse al inicio del programa, tendría que ser lo primero que se pregunta
            Contexto.NuevoUsuario(new Seguridad.Entidades.Usuario() { Id = new Guid("17C75B98-AC22-464E-9A49-F68D75EC80A0") });


        }

        private void button1_Click(object sender, EventArgs e)
        {
            SantaMaria.BLL.BLLPersona bll = new BLL.BLLPersona();
            bll.AgregarPersona(new Entidades.Persona()
            {
                Direccion = "Lacroze 300",
                DNI = 23875483,
                Nombre = "Esteban Quito"
            });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Entidades.Persona persona;
            SantaMaria.BLL.BLLPersona bll = new BLL.BLLPersona();
            persona = bll.ObtenerPorDNI(23875483);
            MessageBox.Show("Se ha encontrado: " + persona.Nombre + " que vive en " + persona.Direccion);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SantaMaria.BLL.BLLPersona bll = new BLL.BLLPersona();

            Entidades.Persona persona = bll.ObtenerTodo()[0];

            persona.Direccion = "Echeverria 293";
            persona.DNI = 13515;
            persona.Nombre = "Roberto Goyeneche";

            bll.ModificarPersona(persona);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SantaMaria.BLL.BLLPersona bll = new BLL.BLLPersona();

            Entidades.Persona persona = bll.ObtenerTodo()[0];

            bll.EliminarPersona(persona);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SantaMaria.Servicios.Backup.Backup.CrearBackup();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string saludo = "Hola! Todo bien?";

            string encriptacion = SantaMaria.Servicios.Encriptacion.Codificador.Encriptar(saludo);

            string mensaje = "Mensaje encriptado: " + encriptacion;

            string desencriptado = SantaMaria.Servicios.Encriptacion.Codificador.Desencriptar(encriptacion);

            mensaje += " Mensaje desencriptado: " + desencriptado;

            MessageBox.Show(mensaje);

        }

        private void button8_Click(object sender, EventArgs e)
        {
            SantaMaria.Servicios.Bitacora.Bitacora.Instance.LogActividad("Nuevo loggin", "Correcto!");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SantaMaria.Servicios.Bitacora.Bitacora.Instance.LogError("Esto es un problema", new Exception("Hay un problema"));
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SantaMaria.Servicios.Seguridad.BLL.BLLFamilia bll = new Servicios.Seguridad.BLL.BLLFamilia();
            bll.AgregarRelacion(new SantaMaria.Servicios.Seguridad.Entidades.Familia(), new SantaMaria.Servicios.Seguridad.Entidades.Patente());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Seguridad.BLL.BLLUsuario bllusu = new Seguridad.BLL.BLLUsuario();
            Seguridad.BLL.BLLFamilia bllfam = new Seguridad.BLL.BLLFamilia();
            Seguridad.BLL.BLLPatente bllpat = new Seguridad.BLL.BLLPatente();

            Seguridad.Entidades.Patente pat = new Seguridad.Entidades.Patente();
            pat.NombreComponente = "Poderes infinitos";
            pat.DescripcionComponente = "Le da poderes infinitos al usuario que posea este permiso";
            bllpat.AgregarPatente(pat);

            Seguridad.Entidades.Familia fam = new Seguridad.Entidades.Familia();
            fam.NombreComponente = "Familia poderosa";
            fam.DescripcionComponente = "Es la familia más poderosa de la cuadra";
            bllfam.AgregarFamilia(fam);

            pat = bllpat.ObtenerPorNombre("Poderes infinitos");
            fam = bllfam.ObtenerPorNombre("Familia poderosa");
            bllfam.AgregarRelacion(fam, pat);

            Seguridad.Entidades.Usuario usu = new Seguridad.Entidades.Usuario();
            usu.Nombre = "Juan Carlos Armada";
            usu.DescripcionComponente = "Jefe de los jefes.";
            usu.usuario = "JCArmada";
            usu.contraseña = "12345678";
            usu.dni = 9183427;
            usu.habilitado = true;
            bllusu.AgregarUsuario(usu);

            usu = bllusu.ObtenerPorNombre("Juan Carlos Armada");

            bllusu.AgregarRelacion(usu, fam);

            bllusu.RellenarPermisos(ref usu);

            StringBuilder mensaje = new StringBuilder();
            mensaje.AppendLine(usu.NombreComponente);
            mensaje.AppendLine(usu.DescripcionComponente);
            for (int i = 0; i < usu.Permisos.Count; i++)
            {
                mensaje.AppendLine(usu.Permisos[0]);
            }

            MessageBox.Show(mensaje.ToString());
        }

        private void button12_Click(object sender, EventArgs e)
        {
            new SantaMaria.Servicios.Seguridad.LoginForm().Show();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            MultiIdioma.TraducirForm(this);
            comboBox1.Items.AddRange(MultiIdioma.ListarIdiomas().ToArray());
            try
            {
                try
                {
                    SantaMaria.Servicios.Seguridad.CheckSum.CompararTodosConDB();
                }
                catch (Exception ex)
                {
                    throw new BLLException("<ErrCheckSumDBCorrupta>", ex);
                }
            }
            catch (BLLException exep)
            {
                FormMensaje.CrearError(exep.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MultiIdioma.CambiarIdioma(new System.Globalization.CultureInfo(((ComboBox)sender).SelectedItem.ToString()));
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            Seguridad.BLL.BLLUsuario bllusu = new Seguridad.BLL.BLLUsuario();
            Seguridad.BLL.BLLFamilia bllfam = new Seguridad.BLL.BLLFamilia();
            Seguridad.BLL.BLLPatente bllpat = new Seguridad.BLL.BLLPatente();


            Seguridad.Entidades.Familia fam = new Seguridad.Entidades.Familia();
            fam.NombreComponente = "Usuarios";
            fam.DescripcionComponente = "Permite ver la lista de Usuarios para habilitarlos, deshabilitarlos o eliminarlos.";
            fam = bllfam.ObtenerPorNombre("Usuarios");

            Seguridad.Entidades.Patente pat = new Seguridad.Entidades.Patente();
            pat.NombreComponente = "Habilitar Usuario";
            pat.DescripcionComponente = "Permite habilitar usuarios que se encontraban deshabilitados.";
            bllpat.AgregarPatente(pat);

            pat = bllpat.ObtenerPorNombre(pat.NombreComponente);
            bllfam.AgregarRelacion(fam, pat);

            pat = new Seguridad.Entidades.Patente();
            pat.NombreComponente = "Deshabilitar Usuario";
            pat.DescripcionComponente = "Permite deshabilitar usuarios que se encontraban habilitados.";
            bllpat.AgregarPatente(pat);

            pat = bllpat.ObtenerPorNombre(pat.NombreComponente);
            bllfam.AgregarRelacion(fam, pat);

            pat = new Seguridad.Entidades.Patente();
            pat.NombreComponente = "Eliminar Usuario";
            pat.DescripcionComponente = "Permite eliminar usuarios de la base de datos.";
            bllpat.AgregarPatente(pat);

            pat = bllpat.ObtenerPorNombre(pat.NombreComponente);
            bllfam.AgregarRelacion(fam, pat);

            pat = new Seguridad.Entidades.Patente();
            pat.NombreComponente = "Ver Usuarios";
            pat.DescripcionComponente = "Permite ver todos los usuarios que se encuentran almacenados.";
            bllpat.AgregarPatente(pat);

            pat = bllpat.ObtenerPorNombre(pat.NombreComponente);
            bllfam.AgregarRelacion(fam, pat);

            Seguridad.Entidades.Familia fam2 = bllfam.ObtenerPorNombre("Servicios");
            bllfam.AgregarRelacion(fam2, fam);
            

        }

    }
}
