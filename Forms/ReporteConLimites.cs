using Panaderia.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Panaderia.Forms
{
    public partial class ReporteConLimites : Form
    {
        public ReporteConLimites()
        {
            InitializeComponent();
            CargarReporte();
        }

        private void dtpFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            CargarReporte();
        }

        private void dtpFechaFin_ValueChanged(object sender, EventArgs e)
        {
            CargarReporte();
        }

        private void CargarReporte()
        {
            try
            {
                DateTime inicio = dtpFechaInicio.Value;
                DateTime fin = dtpFechaFin.Value;

                if (inicio > fin)
                {
                    return;
                }
                DAOcls dao = new DAOcls();

                DataTable tablaDatos = dao.ObtenerReporteVentas(inicio, fin);

                dgvVentas.DataSource = tablaDatos;
                dgvVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar reporte: " + ex.Message);
            }
        }
    }
}
