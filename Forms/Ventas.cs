using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Panaderia.Clases;
using Panaderia.DAO;

namespace Panaderia
{
    public partial class Ventas : Form
    {
        // Listas para manejar los controles existentes de forma ordenada
        private List<PictureBox> listaPictureZones;
        private List<Label> listaLabels;

        // Lista de productos de la BD
        private List<clsProducto> inventario;

        // Puntero para el carrusel
        private int indiceInicio = 0;

        public Ventas()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.Sizable;

            lblFecha.Text = "Fecha: " + DateTime.Now.ToLongDateString();

            CargarListasDeControles();
            CargarDatosDeBaseDatos();
            RenderizarProductos();
        }

        private void CargarListasDeControles()
        {
            // Agrupamos tus controles en el orden visual de izquierda a derecha, fila por fila.

            listaPictureZones = new List<PictureBox>
            {
                pictureBox1, pictureBox2, pictureBox3, pictureBox4,   // Fila 1
                pictureBox7, pictureBox8, pictureBox9, pictureBox10,  // Fila 2
                pictureBox12, pictureBox11, pictureBox6, pictureBox5  // Fila 3 
            };

            listaLabels = new List<Label>
            {
                label1, label2, label3, label4,
                label5, label6, label7, label8,
                label9, label10, label11, label12
            };

            // Configuración visual básica para las imágenes
            foreach (var pb in listaPictureZones)
            {
                pb.SizeMode = PictureBoxSizeMode.Zoom; // Ajustar la imagen
                pb.BackColor = Color.WhiteSmoke;
            }
        }

        private void CargarDatosDeBaseDatos()
        {
            DAOcls dao = new DAOcls();
            inventario = dao.ObtenerProductos();

            // Si no hay productos, se inicia la lista vacía 
            if (inventario == null) inventario = new List<clsProducto>();
        }

        /// <summary>
        /// Dibuja los productos en los PictureBox basándose en el indiceInicio
        /// </summary>
        private void RenderizarProductos()
        {
            int totalEspacios = listaPictureZones.Count; // Deberían ser 12

            for (int i = 0; i < totalEspacios; i++)
            {
                // Calculamos qué producto del inventario toca en este espacio
                int indiceProducto = indiceInicio + i;

                if (indiceProducto < inventario.Count && indiceProducto >= 0)
                {
                    // Hay producto para mostrar
                    clsProducto p = inventario[indiceProducto];

                    listaPictureZones[i].Image = p.Imagen;
                    listaLabels[i].Text = $"{p.Nombre}\n${p.Precio}";
                    listaLabels[i].Visible = true;
                    listaPictureZones[i].Visible = true;
                }
                else
                {
                    // No hay producto (fin de la lista o índice negativo), se limpia el espacio
                    listaPictureZones[i].Image = null;
                    listaLabels[i].Text = "";
                    //Para que no se vean grises
                    // listaPictureZones[i].Visible = false; 
                }
            }
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            // Recorrer 1 columna hacia la derecha (avanzar 1 ítem en la lista lineal)
            // Verificar que queden productos por mostrar
            if (indiceInicio + listaPictureZones.Count < inventario.Count + 11) // El +11 permite navegar hasta ver el último item solo
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
            // Recorrer 1 columna hacia la izquierda 
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
    }
}