using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ScottPlot.WinForms; // Necesario para la versión 5
using ScottPlot;

namespace Panaderia.Forms
{
    public partial class GraficaForm : Form
    {
        private FormsPlot plotVentas;

        public GraficaForm()
        {
            // InitializeComponent(); // Descomenta si usas el diseñador

            this.Text = "Visualización de Ventas";
            this.Size = new Size(900, 600);

            // Instanciar el control FormsPlot (Versión 5)
            plotVentas = new FormsPlot() { Dock = DockStyle.Fill };
            this.Controls.Add(plotVentas);
        }

        public void CargarDatos(DataTable datos)
        {
            try
            {
                // 1. Limpiar gráfica anterior
                plotVentas.Plot.Clear();

                if (datos == null || datos.Rows.Count == 0)
                {
                    plotVentas.Refresh();
                    return;
                }

                // 2. Preparar listas
                List<double> valores = new List<double>();
                List<ScottPlot.TickGenerators.NumericManual> ticks = new List<ScottPlot.TickGenerators.NumericManual>();

                int i = 0;
                foreach (DataRow row in datos.Rows)
                {
                    string producto = row["Producto"].ToString();

                    double monto = 0;
                    if (row["Monto"] != DBNull.Value)
                    {
                        double.TryParse(row["Monto"].ToString(), out monto);
                    }

                    valores.Add(monto);

                    // Crear etiqueta personalizada para el Eje X
                    ticks.Add(new ScottPlot.TickGenerators.NumericManual.Tick(i, producto));
                    i++;
                }

                // 3. Agregar Barras (Sintaxis v5)
                var barPlot = plotVentas.Plot.Add.Bars(valores.ToArray());

                // Color (Azul)
                foreach (var bar in barPlot.Bars)
                {
                    bar.FillColor = ScottPlot.Color.FromHex("#1f77b4");
                }

                // 4. Configurar Eje X (Nombres de productos)
                plotVentas.Plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(ticks);
                plotVentas.Plot.Axes.Bottom.TickLabelStyle.Rotation = 45;
                plotVentas.Plot.Axes.Bottom.TickLabelStyle.Alignment = Alignment.MiddleLeft;

                // 5. Títulos
                plotVentas.Plot.Title("Ventas por Producto");
                plotVentas.Plot.Axes.Left.Label.Text = "Monto ($)";

                // Ajustar y mostrar
                plotVentas.Plot.Axes.AutoScale();
                plotVentas.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar gráfica: " + ex.Message);
            }
        }
    }
}