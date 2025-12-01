using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series; // Aquí vive BarSeries y BarItem
using OxyPlot.WindowsForms;

namespace Panaderia.Forms
{
    public partial class GraficaForm : Form
    {
        private PlotView plotView;

        public GraficaForm()
        {

            this.Text = "Visualización de Ventas";
            this.Size = new Size(900, 600);

            plotView = new PlotView
            {
                Dock = DockStyle.Fill,
                Location = new Point(0, 0),
                Name = "plotView"
            };

            this.Controls.Add(plotView);
        }

        public void CargarDatos(DataTable datos)
        {
            try
            {
                if (datos == null || datos.Rows.Count == 0)
                {
                    plotView.Model = null;
                    return;
                }

                var model = new PlotModel { Title = "Ventas por Producto" };

                string keyEjeCategorias = "CatAxis";
                string keyEjeValores = "ValAxis";

                var ejeCategorias = new CategoryAxis
                {
                    Position = AxisPosition.Left, 
                    Key = keyEjeCategorias,
                    Title = "Productos",
                    IsZoomEnabled = false,
                    IsPanEnabled = false
                };

                var ejeValores = new LinearAxis
                {
                    Position = AxisPosition.Bottom,
                    Key = keyEjeValores,
                    Title = "Monto ($)",
                    Minimum = 0
                };

                model.Axes.Add(ejeCategorias);
                model.Axes.Add(ejeValores);

                var serieBarras = new BarSeries
                {
                    Title = "Ventas",
                    FillColor = OxyColor.Parse("#1f77b4"),
                    StrokeColor = OxyColors.Black,
                    StrokeThickness = 1,

                    YAxisKey = keyEjeCategorias,
                    XAxisKey = keyEjeValores
                };

                foreach (DataRow row in datos.Rows)
                {
                    string producto = row["Producto"].ToString();
                    double monto = 0;

                    if (row["Monto"] != DBNull.Value)
                    {
                        double.TryParse(row["Monto"].ToString(), out monto);
                    }

                    serieBarras.Items.Add(new BarItem { Value = monto });

                    ejeCategorias.Labels.Add(producto);
                }

                model.Series.Add(serieBarras);
                plotView.Model = model;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar gráfica: " + ex.Message);
            }
        }
    }
}