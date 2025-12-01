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

        public void CargarDatos(DataTable datos)
        {
            ch.Series.Clear();

            if (datos == null || datos.Rows.Count == 0) return;

            Series serie = new Series("Ventas");
            serie.ChartType = SeriesChartType.Column; 
            serie.XValueMember = "Producto";
            serie.YValueMembers = "Monto";
            serie.IsValueShownAsLabel = true;

            serie.Points.DataBind(datos.DefaultView, "Producto", "Monto", null);

            ch.Series.Add(serie);
            ch.Update();
        }
    }
}