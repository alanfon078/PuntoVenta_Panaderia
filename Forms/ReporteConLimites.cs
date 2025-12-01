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

        private bool cargandoFiltros = false;

        public ReporteConLimites()
        {
            InitializeComponent();
            dtpFechaInicio.Value = DateTime.Now;
            dtpFechaFin.Value = DateTime.Now;

            CargarFiltroProductos();
            GenerarReporte(false);
        }

        private void CargarFiltroProductos()
        {
            try
            {
                cargandoFiltros = true;

                List<clsProducto> productos = dao.ObtenerProductos();
                clbProductos.DataSource = null;
                clbProductos.DataSource = productos;
                clbProductos.DisplayMember = "Nombre";
                clbProductos.ValueMember = "ProductoID";
                clbProductos.CheckOnClick = true;

                cargandoFiltros = false;
            }
            catch (Exception ex)
            {
                cargandoFiltros = false;
                MessageBox.Show(ex.Message);
            }
        }

        private void GenerarReporte(bool abrirGraficaSiCerrada)
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

                if (_ventanaGrafica == null || _ventanaGrafica.IsDisposed)
                {
                    if (abrirGraficaSiCerrada)
                    {
                        _ventanaGrafica = new GraficaForm();
                        _ventanaGrafica.Show();
                        _ventanaGrafica.CargarDatos(datos);
                    }
                }
                else
                {
                    _ventanaGrafica.CargarDatos(datos);
                    if (abrirGraficaSiCerrada) _ventanaGrafica.BringToFront();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generando reporte: " + ex.Message);
            }
        }

        private void dtpFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            GenerarReporte(false);
        }

        private void dtpFechaFin_ValueChanged(object sender, EventArgs e)
        {
            GenerarReporte(false);
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            GenerarReporte(false);
        }

        private void clbProductos_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (cargandoFiltros) return;

            this.BeginInvoke(new Action(() =>
            {
                GenerarReporte(false);
            }));
        }

        private void btnEliminarFiltros_Click(object sender, EventArgs e)
        {
            cargandoFiltros = true;

            for (int i = 0; i < clbProductos.Items.Count; i++)
            {
                clbProductos.SetItemChecked(i, false);
            }

            dtpFechaInicio.Value = DateTime.Now;
            dtpFechaFin.Value = DateTime.Now;

            cargandoFiltros = false;
            GenerarReporte(false);
        }

        private void clbProductos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && clbProductos.SelectedIndex != -1)
            {
                int index = clbProductos.SelectedIndex;
                bool estadoActual = clbProductos.GetItemChecked(index);
                clbProductos.SetItemChecked(index, !estadoActual);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void btnGenerarGraficaMonto_Click(object sender, EventArgs e)
        {
            DAOcls dao = new DAOcls();
            DataTable dt = dao.ObtenerReporteVentas(dtpFechaInicio.Value, dtpFechaFin.Value);

            GraficaForm frm = new GraficaForm();
            frm.Show();
            frm.CargarDatos(dt, false);
        }

        private void btnGenerarGraficaCantidad_Click(object sender, EventArgs e)
        {
            DAOcls dao = new DAOcls();
            DataTable dt = dao.ObtenerReporteVentas(dtpFechaInicio.Value, dtpFechaFin.Value);

            GraficaForm frm = new GraficaForm();
            frm.Show();
            frm.CargarDatos(dt, true);
        }
    }
}