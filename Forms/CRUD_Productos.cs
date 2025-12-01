using Panaderia.Clases;
using Panaderia.DAO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
// Funcionalidad completa
namespace Panaderia
{
    public partial class frmProductos : Form
    {
        //Variables para la seccion de eliminar productos
        private List<PictureBox> listaPictureZones;
        private List<Label> listaLabels;
        private List<clsProducto> inventario;
        private List<clsProducto> listaEliminar;
        private int indiceInicio = 0;

        //Variables para la seccion de agregar productos
        private string filePath = string.Empty;

        //Variables para la seccion de modificar productos
        private List<PictureBox> listaPictureZonesModificar;
        private List<Label> listaLabelsModificar;
        private int indiceInicioModificar = 0;
        private clsProducto productoSeleccionadoModificar;

        public frmProductos()
        {
            this.WindowState = FormWindowState.Maximized;
            listaEliminar = new List<clsProducto>();
            InitializeComponent();
            cargarTodo();
        }

        private void cargarTodo()
        {
            CargarListasDeControles();
            CargarDatosDeBaseDatos();
            RenderizarProductos();
            CargarListasDeControlesModificar();
            RenderizarProductosModificar();
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
                    indiceInicio = 0;
                    cargarTodo();

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
                filePath = ofdArchivo.FileName;
                picBoxvp.Image = Image.FromFile(filePath);
                picBoxvp.SizeMode = PictureBoxSizeMode.StretchImage;

            }
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPrecio.Text) || string.IsNullOrEmpty(txtNombre.Text) || picBoxvp.Image == null)
            {
                MessageBox.Show("Por favor, complete todos los campos y seleccione una imagen antes de agregar el producto", "Administrador de productos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }

            DAOcls dao = new DAOcls();
            byte[] imagenBlob = null;

            if (!string.IsNullOrEmpty(filePath))
            {
                Imagen_A_Bloop imgABlob = new Imagen_A_Bloop();
                imagenBlob = imgABlob.ConvertirImagenABlob(filePath);
            }

            if (dao.RegistrarProducto(txtNombre.Text, Double.Parse(txtPrecio.Text), int.Parse(nudStock.Value.ToString()), imagenBlob))
            {
                MessageBox.Show("Producto registrado correctamente.");
                cargarTodo();
                txtNombre.Clear();
                txtPrecio.Clear();
                nudStock.Value = 1;
                picBoxvp.Image = null;

            }

            

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            lblNombrevp.Text = txtNombre.Text;
        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {
            lblPreciovp.Text = "Precio: $" + txtPrecio.Text;
        }

        private void nudPrecio_ValueChanged(object sender, EventArgs e)
        {
            lblStockvp.Text = "Stock: " + nudStock.Value.ToString();
        }
        private void nudStock_TabIndexChanged(object sender, EventArgs e)
        {
            lblStockvp.Text = "Stock: " + nudStock.Value.ToString();
        }

        private bool verificarDatos()
        {
            if (string.IsNullOrEmpty(txtPrecioNuevo.Text) || string.IsNullOrEmpty(txtNombreNuevo.Text))
            {
                return false;
            }

            return true;
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPrecio.Focus();
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void txtPrecio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                nudStock.Focus();
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void nudStock_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSelectImg.Focus();
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void btnSelectImg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                btnAgregarProducto.PerformClick();
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void CargarListasDeControlesModificar()
        {
            listaPictureZonesModificar = new List<PictureBox>
    {
        pictureBox24, pictureBox23, pictureBox22, pictureBox21,
        pictureBox20, pictureBox19, pictureBox18, pictureBox17,
        pictureBox16, pictureBox15, pictureBox14, pictureBox13
    };

            listaLabelsModificar = new List<Label>
    {
        label29, label28, label27, label26,
        label25, label24, label23, label22,
        label21, label16, label15, label14
    };

            foreach (var pb in listaPictureZonesModificar)
            {
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                pb.BackColor = Color.WhiteSmoke;
                pb.Cursor = Cursors.Hand;
                pb.Click += ProductoModificar_Click;
            }

            btnDerecha.Click += new EventHandler(btnDerecha_Click);
            btnIzquierda.Click += new EventHandler(btnIzquierda_Click);
        }

        private void ProductoModificar_Click(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;

            if (pb != null && pb.Tag != null)
            {
                productoSeleccionadoModificar = (clsProducto)pb.Tag;

                txtNombreNuevo.Text = productoSeleccionadoModificar.Nombre;
                txtPrecioNuevo.Text = productoSeleccionadoModificar.Precio.ToString();
                nudStockNuevo.Value = productoSeleccionadoModificar.Stock;

                picboxViejaImg.Image = productoSeleccionadoModificar.Imagen;
                picboxViejaImg.SizeMode = PictureBoxSizeMode.Zoom;
                picboxNuevaImg.Image = productoSeleccionadoModificar.Imagen;
                picboxNuevaImg.SizeMode = PictureBoxSizeMode.Zoom;

                lblNombreAntiguo.Text = productoSeleccionadoModificar.Nombre;
                lblPrecioAntiguo.Text = "Precio: $" + productoSeleccionadoModificar.Precio.ToString();
                lblStockAntiguo.Text = "Stock: " + productoSeleccionadoModificar.Stock.ToString();
            }
        }

        private void RenderizarProductosModificar()
        {
            if (listaPictureZonesModificar == null || inventario == null) return;

            int totalEspacios = listaPictureZonesModificar.Count;

            for (int i = 0; i < totalEspacios; i++)
            {
                int indiceProducto = indiceInicioModificar + i;

                if (indiceProducto < inventario.Count && indiceProducto >= 0)
                {
                    clsProducto p = inventario[indiceProducto];

                    listaPictureZonesModificar[i].Image = p.Imagen;
                    listaLabelsModificar[i].Text = $"{p.Nombre}\n(ID: {p.ProductoID})";
                    listaLabelsModificar[i].Visible = true;
                    listaPictureZonesModificar[i].Visible = true;

                    listaPictureZonesModificar[i].Tag = p;
                }
                else
                {
                    listaPictureZonesModificar[i].Image = null;
                    listaLabelsModificar[i].Text = "";
                    listaPictureZonesModificar[i].Tag = null;
                }
            }
        }

        private void btnIzquierda_Click(object sender, EventArgs e)
        {
            if (indiceInicioModificar > 0)
            {
                indiceInicioModificar--;
                RenderizarProductosModificar();
            }
            else
            {
                MessageBox.Show("Estás al inicio del catálogo.");
            }
        }

        private void btnDerecha_Click(object sender, EventArgs e)
        {
            if (listaPictureZonesModificar != null && inventario != null)
            {
                if (indiceInicioModificar + listaPictureZonesModificar.Count < inventario.Count + 1)
                {
                    indiceInicioModificar++;
                    RenderizarProductosModificar();
                }
                else
                {
                    MessageBox.Show("No hay más productos para mostrar.");
                }
            }
        }

        private void btnConfCambio_Click(object sender, EventArgs e)
        {
            DAOcls dao = new DAOcls();
            byte[] imagenBlob = null;
            if (productoSeleccionadoModificar == null)
            {
                MessageBox.Show("Por favor, seleccione un producto para modificar.");
                return;
            }

            if (!verificarDatos())
            {
                MessageBox.Show("Por favor, complete todos los campos antes de modificar el producto", "Administrador de productos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                imagenBlob = new Imagen_A_Bloop().ConvertirImagenABlob2(picboxNuevaImg.Image);

                if (dao.ModificarProducto(productoSeleccionadoModificar.ProductoID, txtNombreNuevo.Text, Double.Parse(txtPrecioNuevo.Text), int.Parse(nudStockNuevo.Value.ToString()), imagenBlob))
                {
                    cargarTodo();
                    txtNombreNuevo.Clear();
                    txtPrecioNuevo.Clear();
                    nudStockNuevo.Value = 1;
                    picboxNuevaImg.Image = null;
                    picboxViejaImg.Image = null;
                    MessageBox.Show("Producto modificado correctamente.");
                }
            }
        }

        private void btnNuevaImagen_Click(object sender, EventArgs e)
        {
            ofdArchivo.Title = "Seleccione un archivo";
            ofdArchivo.Filter = "Imagenes (.jpg; .jpeg; .png;)|*.jpg;*.jpeg;*.png;";
            if (ofdArchivo.ShowDialog() == DialogResult.OK)
            {
                Imagen_A_Bloop imgablop = new Imagen_A_Bloop();
                filePath = ofdArchivo.FileName;
                picboxNuevaImg.Image = Image.FromFile(filePath);
                picboxNuevaImg.SizeMode = PictureBoxSizeMode.StretchImage;

            }
        }

        private void txtNombreNuevo_TextChanged(object sender, EventArgs e)
        {
            lblNombreNuevo.Text = txtNombreNuevo.Text;
        }

        private void txtNombreNuevo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPrecioNuevo.Focus();
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void txtPrecioNuevo_TextChanged(object sender, EventArgs e)
        {
            lblPrecioNuevo.Text = "Precio: $" + txtPrecioNuevo.Text;
        }

        private void txtPrecioNuevo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                nudStockNuevo.Focus();
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void nudStockNuevo_ValueChanged(object sender, EventArgs e)
        {
            lblStockNuevo.Text = "Stock: " + nudStockNuevo.Value.ToString();
        }

        private void nudStockNuevo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnNuevaImagen.Focus();
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void btnNuevaImagen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnNuevaImagen.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
    }
}