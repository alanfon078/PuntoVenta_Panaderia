using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq; // Necesario para buscar en la lista
using System.Windows.Forms;
using Panaderia.Clases;
using Panaderia.DAO;

namespace Panaderia
{
    public partial class Ventas : Form
    {
        // ... (Tus listas existentes) ...
        private List<PictureBox> listaPictureZones;
        private List<Label> listaLabels;
        private List<clsProducto> inventario;
        private int indiceInicio = 0;

        // NUEVO: Lista para manejar el carrito
        private List<clsDetalleVenta> carrito;

        public Ventas()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            // this.FormBorderStyle = FormBorderStyle.Sizable; // Opcional

            lblFecha.Text = "Fecha: " + DateTime.Now.ToLongDateString();

            // Inicializar carrito
            carrito = new List<clsDetalleVenta>();

            CargarListasDeControles();
            CargarDatosDeBaseDatos();
            RenderizarProductos();

            // Configurar el DataGridView del carrito
            ConfigurarTablaCarrito();
        }

        private void ConfigurarTablaCarrito()
        {
            if (dwvCarrito != null)
            {
                dwvCarrito.AutoGenerateColumns = false;

                // Definir columnas manualmente para tener control
                dwvCarrito.Columns.Add("Nombre", "Producto");
                dwvCarrito.Columns.Add("Precio", "Precio");
                dwvCarrito.Columns.Add("Cantidad", "Cant.");
                dwvCarrito.Columns.Add("Subtotal", "Subtotal");

                // Mapear datos
                dwvCarrito.Columns[0].DataPropertyName = "Nombre";
                dwvCarrito.Columns[1].DataPropertyName = "Precio";
                dwvCarrito.Columns[2].DataPropertyName = "Cantidad";
                dwvCarrito.Columns[3].DataPropertyName = "Subtotal";

                // Formato de moneda
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

            // Configuración visual y EVENTOS
            foreach (var pb in listaPictureZones)
            {
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                pb.BackColor = Color.WhiteSmoke;
                pb.Cursor = Cursors.Hand; // Cambiar cursor para indicar clic

                // NUEVO: Asignar el evento Click a todas las cajas de imagen
                pb.Click += Producto_Click;
            }
        }

        // NUEVO: Evento al hacer clic en un producto
        private void Producto_Click(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;

            // Recuperamos el producto guardado en la propiedad Tag (ver RenderizarProductos)
            if (pb != null && pb.Tag != null)
            {
                clsProducto productoSeleccionado = (clsProducto)pb.Tag;
                AgregarAlCarrito(productoSeleccionado);
            }
        }

        private void AgregarAlCarrito(clsProducto prod)
        {
            // 1. Verificar si hay stock (opcional, pero recomendado)
            if (prod.Stock <= 0)
            {
                MessageBox.Show("Producto agotado.");
                return;
            }

            // 2. Buscar si el producto ya está en el carrito
            var itemExistente = carrito.FirstOrDefault(x => x.ProductoID == prod.ProductoID);

            if (itemExistente != null)
            {
                // Si existe, aumentamos cantidad
                // Validar que no exceda el stock real
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
                // Si no existe, creamos nuevo ítem
                clsDetalleVenta nuevoItem = new clsDetalleVenta
                {
                    ProductoID = prod.ProductoID,
                    Nombre = prod.Nombre,
                    Precio = prod.Precio,
                    Cantidad = 1
                };
                carrito.Add(nuevoItem);
            }

            // 3. Refrescar la tabla y totales
            RefrescarCarritoUI();
        }

        private void RefrescarCarritoUI()
        {
            // Refrescar DataGridView
            // Usamos BindingSource o simplemente reasignamos DataSource
            dwvCarrito.DataSource = null;
            dwvCarrito.DataSource = carrito;

            // Calcular Total General
            decimal total = carrito.Sum(x => x.Subtotal);

            // Actualizar Label
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

                    // Guardamos el objeto producto completo dentro del PictureBox
                    // para poder recuperarlo cuando le den clic.
                    listaPictureZones[i].Tag = p;
                }
                else
                {
                    listaPictureZones[i].Image = null;
                    listaLabels[i].Text = "";
                    listaPictureZones[i].Tag = null; // Limpiar tag
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
            // 1. Validaciones básicas
            if (carrito == null || carrito.Count == 0)
            {
                MessageBox.Show("El carrito está vacío, selecciona productos primero.");
                return;
            }

            // Calcular el total final
            decimal totalVenta = carrito.Sum(x => x.Subtotal);

            // Confirmación opcional
            DialogResult confirmacion = MessageBox.Show($"¿Desea procesar la venta por un total de {totalVenta:C2}?",
                                                        "Confirmar Venta",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                DAOcls dao = new DAOcls();

                // 2. Llamar al método que creamos en el DAO
                bool resultado = dao.GuardarVenta(totalVenta, carrito);

                if (resultado)
                {
                    MessageBox.Show("¡Venta realizada con éxito!");

                    // 3. Limpiar todo para la siguiente venta
                    carrito.Clear();
                    RefrescarCarritoUI(); // Actualiza la tabla visualmente (quedará vacía)

                    // Recargar inventario para ver los stocks actualizados
                    CargarDatosDeBaseDatos();
                    RenderizarProductos(); // Refrescar las imágenes/etiquetas
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al guardar la venta en la base de datos.");
                }
            }
        }

    }
}