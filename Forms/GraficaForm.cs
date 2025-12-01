using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Panaderia.Forms
{
    public partial class GraficaForm : Form
    {
        private Chart ch;

        public GraficaForm()
        {
            this.Text = "Visualización de Ventas";

            ch = new Chart();
            ch.Dock = DockStyle.Fill;

            ChartArea area = new ChartArea("AreaVentas");
            area.AxisX.Title = "Producto";
            area.AxisX.Interval = 1;
            area.AxisY.Title = "Monto ($)";
            ch.ChartAreas.Add(area);

            ch.Titles.Add("Reporte de Ventas");
            this.Controls.Add(ch);
        }

        // En GraficaForm.cs

        public void CargarDatos(DataTable datos)
        {
            try
            {
                // 1. Limpiar datos previos
                ch.Series.Clear();

                if (datos == null || datos.Rows.Count == 0) return;

                // 2. Configurar la serie
                Series serie = new Series("Ventas");
                serie.ChartType = SeriesChartType.Column;

                // Es importante asignar el ChartArea si se borraron las series
                serie.ChartArea = "AreaVentas";

                // 3. LLENADO MANUAL (SOLUCIÓN AL CRASH)
                // Recorremos la tabla fila por fila. Esto evita el error de DataBind.
                foreach (DataRow row in datos.Rows)
                {
                    string producto = row["Producto"].ToString();

                    // Convertimos de forma segura a Decimal. 
                    // Si viene nulo o vacío, usamos 0 para que no truene.
                    decimal monto = 0;
                    if (row["Monto"] != DBNull.Value)
                    {
                        decimal.TryParse(row["Monto"].ToString(), out monto);
                    }

                    // Agregamos el punto a la gráfica
                    serie.Points.AddXY(producto, monto);
                }

                serie.IsValueShownAsLabel = true;

                // 4. Agregar la serie al control
                ch.Series.Add(serie);
                ch.Update();
            }
            catch (Exception ex)
            {
                // Esto evitará que se cierre el programa si hay un error en la gráfica
                MessageBox.Show("Error al dibujar la gráfica: " + ex.Message);
            }
        }
    }
}