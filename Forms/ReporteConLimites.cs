using Panaderia.DAO;
using System.Data;
using Panaderia.Clases;

namespace Panaderia.Forms
{

    public partial class ReporteConLimites : Form
    {
        DAOcls dao = new DAOcls();

        public ReporteConLimites()
        {
            InitializeComponent();
            cargarTodo();
        }

        private void cargarTodo()
        {
            CargarFiltroProductos();
            CargarReporte();
        }


        private void CargarFiltroProductos()
        {
            List<clsProducto> productos = dao.ObtenerProductos();

            clbProductos.DataSource = null;
            clbProductos.DataSource = productos;
            clbProductos.DisplayMember = "Nombre";
            clbProductos.ValueMember = "ProductoID";

            for (int i = 0; i < clbProductos.Items.Count; i++)
            {
                clbProductos.SetItemChecked(i, true);
            }

            clbProductos.CheckOnClick = true;
        }

        public void CargarReporte()
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

        private void dtpFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            CargarReporte();
        }

        private void dtpFechaFin_ValueChanged(object sender, EventArgs e)
        {
            CargarReporte();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CargarReporte();
        }
    }
}
