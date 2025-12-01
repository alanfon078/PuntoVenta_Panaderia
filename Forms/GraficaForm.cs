using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
// Funcionalidad completa
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

        public void CargarDatos(DataTable datos, bool esCantidad = false)
        {
            try
            {
                if (datos == null || datos.Rows.Count == 0)
                {
                    plotView.Model = null;
                    return;
                }

                string columnaDatos = esCantidad ? "Cantidad" : "Monto";
                string tituloGrafica = esCantidad ? "Unidades Vendidas" : "Ventas Totales por Producto";
                string tituloEjeX = esCantidad ? "Cantidad" : "Monto ($)";
                string colorBarra = esCantidad ? "#2ca02c" : "#1f77b4";

                var model = new PlotModel { Title = tituloGrafica };

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
                    Title = tituloEjeX,
                    Minimum = 0 
                };

                if (esCantidad)
                {
                    ejeValores.Maximum = 30;  
                    ejeValores.MajorStep = 1; 

                }

                model.Axes.Add(ejeCategorias);
                model.Axes.Add(ejeValores);

                var serieBarras = new BarSeries
                {
                    Title = esCantidad ? "Unidades" : "Dinero",
                    FillColor = OxyColor.Parse(colorBarra),
                    StrokeColor = OxyColors.Black,
                    StrokeThickness = 1,
                    YAxisKey = keyEjeCategorias,
                    XAxisKey = keyEjeValores
                };


                foreach (DataRow row in datos.Rows)
                {

                    string producto = row["Producto"].ToString();
                    double valor = 0;

                    if (row[columnaDatos] != DBNull.Value)
                    {
                        double.TryParse(row[columnaDatos].ToString(), out valor);
                    }

                    serieBarras.Items.Add(new BarItem { Value = valor });
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