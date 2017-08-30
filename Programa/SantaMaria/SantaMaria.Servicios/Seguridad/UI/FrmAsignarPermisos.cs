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

namespace SantaMaria.Servicios.Seguridad.UI
{
    public partial class FrmAsignarPermisos : FormBase
    {
        Entidades.Usuario usuario;
        Entidades.Familia familia;
        public FrmAsignarPermisos()
        {
            InitializeComponent();
        }

        private void FrmAsignarPermisos_Load(object sender, EventArgs e)
        {
            PopularTreeViewPermisosBase();
            PopularTreeViewPermisosPersonalizados();
            FillCmbxPermisosPersonalizados();

            MultiIdiioma.MultiIdioma.TraducirForm(this);

            LblNombre.Text = "";
            PnlAsignar.Enabled = false;
        }

        private void PopularTreeViewPermisosBase()
        {
            TreeNode rootNode;
            //Permisos Básicos
            BLL.BLLFamilia bll = new BLL.BLLFamilia();
            Entidades.Familia familia = bll.ObtenerPorNombre("Permisos Basicos");
            bll.RellenarPermisos(ref familia);

            rootNode = new TreeNode(familia.NombreComponente);
            rootNode.ToolTipText = familia.DescripcionComponente;

            RecursionAsignarHijos(rootNode, familia);
            treeView1.Nodes.Add(rootNode);

        }
        private void PopularTreeViewPermisosPersonalizados()
        {
            TreeNode rootNode;
            //Permisos Básicos
            BLL.BLLFamilia bll = new BLL.BLLFamilia();
            Entidades.Familia familia = bll.ObtenerPorNombre("Permisos personalizados");
            bll.RellenarPermisos(ref familia);

            rootNode = new TreeNode(familia.NombreComponente);
            rootNode.ToolTipText = familia.DescripcionComponente;

            RecursionAsignarHijos(rootNode, familia);

            treeView1.Nodes.Add(rootNode);

        }

        private void RecursionAsignarHijos(TreeNode nodo, Entidades.Familia fama)
        {
            TreeNode hijo;
            foreach (Entidades.ComponenteBase item in fama.ObtenerComponentes())
            {
                hijo = new TreeNode(item.NombreComponente);
                hijo.ToolTipText = item.DescripcionComponente;
                if (item.CantHijos > 0)
                {
                    RecursionAsignarHijos(hijo, (Entidades.Familia)item);
                }
                nodo.Nodes.Add(hijo);
            }
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (treeView1.Nodes.Contains(e.Node) && e.Node.Checked) e.Node.Checked = false;
            if (e.Action == TreeViewAction.Unknown) return;
            if (!e.Node.Checked)
            {
                Action<TreeNode> accion = x => x.Checked = false;
                NodeRecursionDown(e.Node, accion);
                NodeRecursionUp(e.Node, accion);
            }
            else
            {
                NodeRecursionUp(e.Node, x =>
                {
                    foreach (TreeNode item in x.Nodes)
                    {
                        if (!item.Checked) return;
                    }
                    x.Checked = true;
                });
                NodeRecursionDown(e.Node, x => x.Checked = true);
            }
        }
        private void NodeRecursionDown(TreeNode nodo, Action<TreeNode> accion)
        {
            foreach (TreeNode item in nodo.Nodes)
            {
                accion(item);
                NodeRecursionDown(item, accion);
            }
        }
        private void NodeRecursionUp(TreeNode nodo, Action<TreeNode> accion)
        {
            if (nodo.Parent != null)
            {
                accion(nodo.Parent);
                NodeRecursionUp(nodo.Parent, accion);
            }
        }
        private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            e.Cancel = true;
        }

        private List<TreeNode> ObtenerUltimosNodos()
        {
            List<TreeNode> lista = new List<TreeNode>();

            for (int i = 0; i < treeView1.Nodes.Count; i++)
            {
                RecursionPrimerNodoChecked(treeView1.Nodes[i], x => lista.Add(x));
            }
            return lista;
        }
        void RecursionPrimerNodoChecked(TreeNode nodo, Action<TreeNode> accion)
        {
            foreach (TreeNode item in nodo.Nodes)
            {
                if (item.Checked) accion(item);
                else
                {
                    RecursionPrimerNodoChecked(item, accion);
                }
            }
        }
        private void treeView1_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            if (treeView1.Nodes.Contains(e.Node) && e.Node.Checked) e.Cancel = true;
        }

        private void BtnAsignar_Click(object sender, EventArgs e)
        {
            if (usuario != null)
            {
                BLL.BLLUsuario bll = new BLL.BLLUsuario();
                bll.AsignarNuevasPatenes(usuario, ObtenerUltimosNodos());
            }
            if (familia != null)
            {
                BLL.BLLFamilia bll = new BLL.BLLFamilia();
                bll.AsignarNuevasPatenes(familia, ObtenerUltimosNodos());
            }
        }

        private void FillCmbxPermisosPersonalizados()
        {
            CmbxPermisosPersonalizados.Items.Clear();
            BLL.BLLFamilia bll = new BLL.BLLFamilia();
            Entidades.Familia familia = bll.ObtenerPorNombre("Permisos personalizados");
            bll.RellenarPermisos(ref familia);
            foreach (Entidades.ComponenteBase item in familia.ObtenerComponentes())
            {
                CmbxPermisosPersonalizados.Items.Add(item.NombreComponente);
            }
        }
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            BLL.BLLUsuario blluse = new BLL.BLLUsuario();
            Entidades.Usuario user = blluse.ObtenerPorUsuario(TxbxUsuario.Text);
            if (user == null)
            {
                Servicios.UI.FormMensaje.CrearAdvertencia("No se encontró el usuario indicado.");
            }
            else
            {
                blluse.RellenarPermisos(ref user);
                usuario = user;
                familia = null;
                LblNombre.Text = MultiIdiioma.MultiIdioma.TraducirFrase("<LblUsuario>: " + user.Nombre);
                PnlBuscar.Enabled = false;
                PnlAsignar.Enabled = true;
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            usuario = null;
            familia = null;
            LblNombre.Text = "";
            PnlBuscar.Enabled = true;
            PnlAsignar.Enabled = false;
        }

        private void BtnElegir_Click(object sender, EventArgs e)
        {
            if (CmbxPermisosPersonalizados.SelectedItem == null)
            {
                Servicios.UI.FormMensaje.CrearAdvertencia("No se seleccionó un permiso personalizado.");
                return;
            }
            BLL.BLLFamilia bllfam = new BLL.BLLFamilia();
            Entidades.Familia fam = bllfam.ObtenerPorNombre(CmbxPermisosPersonalizados.SelectedItem.ToString());
            if (fam == null)
            {
                Servicios.UI.FormMensaje.CrearAdvertencia("No se encontró el permiso pesonalizado indicado.");
            }
            else
            {
                bllfam.RellenarPermisos(ref fam);
                usuario = null;
                familia = fam;
                LblNombre.Text = MultiIdiioma.MultiIdioma.TraducirFrase("<LblFamilia>: " + fam.NombreComponente);
                PnlAsignar.Enabled = true;
                PnlBuscar.Enabled = false;
            }
        }
        private void TreeViewUncheckAll()
        {
            for (int i = 0; i < treeView1.Nodes.Count; i++)
            {
                NodeRecursionDown(treeView1.Nodes[i], x =>
                {
                    foreach (TreeNode item in x.Nodes)
                    {
                        item.Checked = false;
                    }
                });
            }
        }

        private void BtnCargarPermisosActuales_Click(object sender, EventArgs e)
        {
            List<string> listapatentes;
            if (usuario != null) listapatentes = usuario.ObtenerComponentes().Select(x => x.NombreComponente).ToList();
            else listapatentes = familia.ObtenerComponentes().Select(x => x.NombreComponente).ToList();
            TreeViewUncheckAll();
            for (int i = 0; i < treeView1.Nodes.Count; i++)
            {
                ///Checkear nodos que se encuentre en la lista de componentes
                ///Y
                ///Chequea nodos hijos o padres en caso de que sea necesario
                NodeRecursionDown(treeView1.Nodes[i], x =>
                {
                    foreach (string patente in listapatentes)
                    {
                        if (x.Text == patente)
                        {
                            x.Checked = true;
                            listapatentes.Remove(patente);
                            NodeRecursionUp(x, y =>
                            {
                                foreach (TreeNode item in y.Nodes)
                                {
                                    if (!item.Checked) return;
                                }
                                y.Checked = true;
                            });
                            NodeRecursionDown(x, y => y.Checked = true);
                            break;
                        }

                    }
                });

            }




        }
    }
}