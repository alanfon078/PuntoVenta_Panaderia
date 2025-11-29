using Panaderia.Clases;
using Panaderia.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Panaderia
{
    public partial class frmProductos : Form
    {
        private List<PictureBox> listaPictureZones;
        private List<Label> listaLabels;
        private List<clsProducto> inventario;
        private int indiceInicio = 0;
        private List<clsDetalleVenta> lista;

        public frmProductos()
        {
            this.WindowState = FormWindowState.Maximized;
            lista = new List<clsDetalleVenta>();
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

                dgvLista.Columns.Add("Nombre", "Producto");
                dgvLista.Columns.Add("Precio", "Precio");
                dgvLista.Columns.Add("Cantidad", "Cant.");
                dgvLista.Columns.Add("Subtotal", "Subtotal");

                dgvLista.Columns[0].DataPropertyName = "Nombre";
                dgvLista.Columns[1].DataPropertyName = "Precio";
                dgvLista.Columns[2].DataPropertyName = "Cantidad";
                dgvLista.Columns[3].DataPropertyName = "Subtotal";

                dgvLista.Columns[1].DefaultCellStyle.Format = "C2";
                dgvLista.Columns[3].DefaultCellStyle.Format = "C2";
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
                AgregarAlCarrito(productoSeleccionado);
            }
        }

        private void AgregarAlCarrito(clsProducto prod)
        {
            if (prod.Stock <= 0)
            {
                MessageBox.Show("Producto agotado.");
                return;
            }

            var itemExistente = lista.FirstOrDefault(x => x.ProductoID == prod.ProductoID);

            if (itemExistente != null)
            {
                if (itemExistente.Cantidad + 1 <= prod.Stock)
                {
                    itemExistente.Cantidad++;
                }
                else
                {
                    MessageBox.Show("No hay suficiente stock para agregar más.");
                    return;
                }
            }
            else
            {
                clsDetalleVenta nuevoItem = new clsDetalleVenta
                {
                    ProductoID = prod.ProductoID,
                    Nombre = prod.Nombre,
                    Precio = prod.Precio,
                    Cantidad = 1
                };
                lista.Add(nuevoItem);
            }

            RefrescarCarritoUI();
        }

        private void RefrescarCarritoUI()
        {
            dgvLista.DataSource = null;
            dgvLista.DataSource = lista;

            decimal total = lista.Sum(x => x.Subtotal);
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
                    listaLabels[i].Text = $"{p.Nombre}\n${p.Precio}";
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
            if (indiceInicio + listaPictureZones.Count < inventario.Count + 11)
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
            List<int> idxAEliminar = new List<int>();

            foreach (DataGridViewRow fila in dgvLista.SelectedRows)
            {
                if (!fila.IsNewRow)
                {
                    int id = Convert.ToInt32(fila.Cells["ProductoID"].Value);
                    idxAEliminar.Add(id);
                }
            }

            if (idxAEliminar.Count == 0)
            {
                MessageBox.Show("Por favor selecciona al menos un producto.");
                return;
            }

            if (MessageBox.Show("¿Estás seguro de eliminar los productos seleccionados?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DAOcls dao = new DAOcls();
                if (dao.EliminarListaProductos(idxAEliminar))
                {
                    MessageBox.Show("Productos eliminados correctamente.");
                    dgvLista.ClearSelection();
                    lista.Clear();
                    CargarDatosDeBaseDatos();
                    RenderizarProductos();
                    RefrescarCarritoUI();
                }
                else
                {
                    MessageBox.Show("Error al eliminar los productos.");
                }
            }
        }
    }
}
