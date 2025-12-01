using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Panaderia.DAO;
using Panaderia.Clases;

namespace Panaderia.Forms
{
    public partial class ReporteConLimites : Form
    {
        DAOcls dao = new DAOcls();
        private GraficaForm _ventanaGrafica = null;

        public ReporteConLimites()
        {
            InitializeComponent();
            dtpFechaInicio.Value = DateTime.Now;
            dtpFechaFin.Value = DateTime.Now;
            CargarFiltroProductos();
            CargarReporte();
        }

        private void CargarFiltroProductos()
        {
            try
            {
                List<clsProducto> productos = dao.ObtenerProductos();
                clbProductos.DataSource = null;
                clbProductos.DataSource = productos;
                clbProductos.DisplayMember = "Nombre";
                clbProductos.ValueMember = "ProductoID";
                clbProductos.CheckOnClick = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void CargarReporte()
        {
            try
            {
                List<int> idsSeleccionados = new List<int>();

                foreach (var item in clbProductos.CheckedItems)
                {
                    clsProducto prod = (clsProducto)item;
                    idsSeleccionados.Add(prod.ProductoID);
                }

                DataTable datos = dao.ObtenerReporteVentas(
                    dtpFechaInicio.Value,
                    dtpFechaFin.Value,
                    idsSeleccionados
                );

                dgvVentas.DataSource = datos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGenerarGrafica_Click(object sender, EventArgs e)
        {
            GenerarReporte(true);
        }

        private void dtpFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            GenerarReporte(false);
        }

        private void dtpFechaFin_ValueChanged(object sender, EventArgs e)
        {
            GenerarReporte(false);
        }

        private void clbProductos_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke(new Action(() =>
            {
                GenerarReporte(false);
            }));
        }

        private void clbProductos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (clbProductos.SelectedIndex != -1)
                {
                    int index = clbProductos.SelectedIndex;
                    bool estadoActual = clbProductos.GetItemChecked(index);
                    clbProductos.SetItemChecked(index, !estadoActual);
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CargarReporte();
        }

        private void btnEliminarFiltros_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbProductos.Items.Count; i++)
            {
                clbProductos.SetItemChecked(i, false);
            }
            dtpFechaInicio.Value = DateTime.Now;
            dtpFechaFin.Value = DateTime.Now;
            CargarReporte();
        }

        // En ReporteConLimites.cs -> Método GenerarReporte

        private void GenerarReporte(bool abrirGraficaSiCerrada)
        {
            try
            {
                // ... (Tu código de obtener IDs y Datos sigue igual) ...
                List<int> idsSeleccionados = new List<int>();
                foreach (var item in clbProductos.CheckedItems)
                {
                    clsProducto prod = (clsProducto)item;
                    idsSeleccionados.Add(prod.ProductoID);
                }

                DataTable datos = dao.ObtenerReporteVentas(
                    dtpFechaInicio.Value,
                    dtpFechaFin.Value,
                    idsSeleccionados
                );

                dgvVentas.DataSource = datos;

                // ... (Lógica de ventana) ...

                if (_ventanaGrafica == null || _ventanaGrafica.IsDisposed)
                {
                    if (abrirGraficaSiCerrada)
                    {
                        _ventanaGrafica = new GraficaForm();
                        _ventanaGrafica.Show();
                        // El try-catch interno en GraficaForm ahora manejará errores de dibujo
                        _ventanaGrafica.CargarDatos(datos);
                    }
                }
                else
                {
                    // Si la ventana ya existe, actualizamos
                    _ventanaGrafica.CargarDatos(datos);
                    if (abrirGraficaSiCerrada) _ventanaGrafica.BringToFront();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el reporte: " + ex.Message);
            }
        }


    }
}