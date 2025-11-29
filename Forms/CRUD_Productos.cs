using Panaderia.Clases;
using Panaderia.DAO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Panaderia
{
    public partial class frmProductos : Form
    {
        private List<PictureBox> listaPictureZones;
        private List<Label> listaLabels;
        private List<clsProducto> inventario;
        private List<clsProducto> listaEliminar;
        private int indiceInicio = 0;

        public frmProductos()
        {
            this.WindowState = FormWindowState.Maximized;
            listaEliminar = new List<clsProducto>();
            InitializeComponent();
            CargarListasDeControles();
            CargarDatosDeBaseDatos();
            RenderizarProductos();
            ConfigurarTabla();
        }

        private void ConfigurarTabla()
        {
            if (dgvLista != null)
            {
                dgvLista.AutoGenerateColumns = false;
                dgvLista.DataSource = null;
                dgvLista.Columns.Clear();

                DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
                colId.Name = "id";
                colId.HeaderText = "ProductoID";
                colId.DataPropertyName = "ProductoID";
                colId.Width = 100;
                dgvLista.Columns.Add(colId);

                DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn();
                colNombre.Name = "Nombre";
                colNombre.HeaderText = "Producto";
                colNombre.DataPropertyName = "Nombre";
                colNombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvLista.Columns.Add(colNombre);
            }
        }

        private void CargarListasDeControles()
        {
            listaPictureZones = new List<PictureBox>
            {
                pictureBox1, pictureBox2, pictureBox3, pictureBox4,
                pictureBox7, pictureBox8, pictureBox9, pictureBox10,
                pictureBox12, pictureBox11, pictureBox6, pictureBox5
            };

            listaLabels = new List<Label>
            {
                label1, label2, label3, label4,
                label5, label6, label7, label8,
                label9, label10, label11, label12
            };

            foreach (var pb in listaPictureZones)
            {
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                pb.BackColor = Color.WhiteSmoke;
                pb.Cursor = Cursors.Hand;
                pb.Click += Producto_Click;
            }
        }

        private void Producto_Click(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;

            if (pb != null && pb.Tag != null)
            {
                clsProducto productoSeleccionado = (clsProducto)pb.Tag;
                AgregarALista(productoSeleccionado);
            }
        }

        private void AgregarALista(clsProducto prod)
        {
            bool yaExiste = listaEliminar.Any(x => x.ProductoID == prod.ProductoID);

            if (yaExiste)
            {
                MessageBox.Show("Este producto ya está en la lista para eliminar.");
                return;
            }

            listaEliminar.Add(prod);

            RefrescarGridUI();
        }

        private void RefrescarGridUI()
        {
            dgvLista.DataSource = null;
            dgvLista.DataSource = listaEliminar;
        }

        private void CargarDatosDeBaseDatos()
        {
            DAOcls dao = new DAOcls();
            inventario = dao.ObtenerProductos();
            if (inventario == null) inventario = new List<clsProducto>();
        }

        private void RenderizarProductos()
        {
            int totalEspacios = listaPictureZones.Count;

            for (int i = 0; i < totalEspacios; i++)
            {
                int indiceProducto = indiceInicio + i;

                if (indiceProducto < inventario.Count && indiceProducto >= 0)
                {
                    clsProducto p = inventario[indiceProducto];

                    listaPictureZones[i].Image = p.Imagen;
                    listaLabels[i].Text = $"{p.Nombre}\n(ID: {p.ProductoID})";
                    listaLabels[i].Visible = true;
                    listaPictureZones[i].Visible = true;

                    listaPictureZones[i].Tag = p;
                }
                else
                {
                    listaPictureZones[i].Image = null;
                    listaLabels[i].Text = "";
                    listaPictureZones[i].Tag = null;
                }
            }
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (indiceInicio > 0)
            {
                indiceInicio--;
                RenderizarProductos();
            }
            else
            {
                MessageBox.Show("Estás al inicio del catálogo.");
            }
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            if (indiceInicio + listaPictureZones.Count < inventario.Count + 1)
            {
                indiceInicio++;
                RenderizarProductos();
            }
            else
            {
                MessageBox.Show("No hay más productos para mostrar.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (listaEliminar.Count == 0)
            {
                MessageBox.Show("No hay productos en la lista para eliminar.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                $"¿Estás seguro de eliminar los {listaEliminar.Count} productos listados?\nEsta acción no se puede deshacer.",
                "Confirmar Eliminación Masiva",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (respuesta == DialogResult.Yes)
            {
                List<int> idsAEliminar = listaEliminar.Select(x => x.ProductoID).ToList();

                DAOcls dao = new DAOcls();

                if (dao.EliminarListaProductos(idsAEliminar))
                {
                    MessageBox.Show("Productos eliminados correctamente.");

                    listaEliminar.Clear();
                    RefrescarGridUI();

                    CargarDatosDeBaseDatos();
                    indiceInicio = 0;
                    RenderizarProductos();
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al intentar eliminar los productos.");
                }
            }
        }

        private void btnSelectImg_Click(object sender, EventArgs e)
        {
            ofdArchivo.Title = "Seleccione un archivo";
            ofdArchivo.Filter = "Imagenes (.jpg; .jpeg; .png;)|*.jpg;*.jpeg;*.png;";
            if (ofdArchivo.ShowDialog() == DialogResult.OK)
            {
                Imagen_A_Bloop imgablop = new Imagen_A_Bloop();
                string filePath = ofdArchivo.FileName;
                picBoxvp.Image = Image.FromFile(filePath);
                picBoxvp.SizeMode = PictureBoxSizeMode.StretchImage;

            }
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            lblNombrevp.Text = txtNombre.Text;
        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {
            lblPreciovp.Text = "Precio: $"+txtPrecio.Text;
        }

        private void nudPrecio_ValueChanged(object sender, EventArgs e)
        {
            lblStockvp.Text = "Stock: " + nudStock.Value.ToString();
        }
    }
}