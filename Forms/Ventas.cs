using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq; 
using System.Windows.Forms;
using Panaderia.Clases;
using Panaderia.DAO;
// Funcionalidad completa
namespace Panaderia
{
    public partial class Ventas : Form
    {
        private List<PictureBox> listaPictureZones;
        private List<Label> listaLabels;
        private List<clsProducto> inventario;
        private int indiceInicio = 0;
        private List<clsDetalleVenta> carrito;
        public static string usuarioActual;

        public Ventas()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            lblFecha.Text = "Fecha: " + DateTime.Now.ToLongDateString();
            usuarioActual = UsuarioSesion.UsuarioActual;
            lblUser.Text +=usuarioActual;

            carrito = new List<clsDetalleVenta>();

            CargarListasDeControles();
            CargarDatosDeBaseDatos();
            RenderizarProductos();

            ConfigurarTablaCarrito();
        }

        private void ConfigurarTablaCarrito()
        {
            if (dwvCarrito != null)
            {
                dwvCarrito.AutoGenerateColumns = false;

                dwvCarrito.Columns.Add("Nombre", "Producto");
                dwvCarrito.Columns.Add("Precio", "Precio");
                dwvCarrito.Columns.Add("Cantidad", "Cant.");
                dwvCarrito.Columns.Add("Subtotal", "Subtotal");

                dwvCarrito.Columns[0].DataPropertyName = "Nombre";
                dwvCarrito.Columns[1].DataPropertyName = "Precio";
                dwvCarrito.Columns[2].DataPropertyName = "Cantidad";
                dwvCarrito.Columns[3].DataPropertyName = "Subtotal";

                dwvCarrito.Columns[1].DefaultCellStyle.Format = "C2";
                dwvCarrito.Columns[3].DefaultCellStyle.Format = "C2";
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

            var itemExistente = carrito.FirstOrDefault(x => x.ProductoID == prod.ProductoID);

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
                carrito.Add(nuevoItem);
            }

            RefrescarCarritoUI();
        }

        private void RefrescarCarritoUI()
        {
            dwvCarrito.DataSource = null;
            dwvCarrito.DataSource = carrito;

            decimal total = carrito.Sum(x => x.Subtotal);

            if (lblTotal != null)
            {
                lblTotal.Text = $"Total: {total:C2}";
            }
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

        private void btnLeft_Click_1(object sender, EventArgs e)
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


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dwvCarrito.CurrentRow != null)
            {
                var itemSeleccionado = (clsDetalleVenta)dwvCarrito.CurrentRow.DataBoundItem;
                carrito.Remove(itemSeleccionado);
                RefrescarCarritoUI();
            }
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            if (carrito == null || carrito.Count == 0)
            {
                MessageBox.Show("El carrito está vacío, selecciona productos primero.");
                return;
            }

            decimal totalVenta = carrito.Sum(x => x.Subtotal);

            DialogResult confirmacion = MessageBox.Show($"¿Desea procesar la venta por un total de {totalVenta:C2}?",
                                                        "Confirmar Venta",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                DAOcls dao = new DAOcls();

                bool resultado = dao.GuardarVenta(totalVenta, carrito);

                if (resultado)
                {
                    MessageBox.Show("¡Venta realizada con éxito!");

                    carrito.Clear();
                    RefrescarCarritoUI();

                    CargarDatosDeBaseDatos();
                    RenderizarProductos();
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al guardar la venta en la base de datos.");
                }
            }
        }

    }
}