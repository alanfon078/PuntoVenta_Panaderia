using Panaderia.Clases;
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
    public partial class EliminarUsuarios : Form
    {
        public EliminarUsuarios()
        {
            InitializeComponent();
            CargarTablaUsuarios();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un usuario a eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idUsuario = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells[0].Value);
            string nombreUsuario = dgvUsuarios.SelectedRows[0].Cells[1].Value.ToString();

            DialogResult confirmacion = MessageBox.Show(
                $"¿Estas seguro que deseas eliminar al usuario permanentemente? '{nombreUsuario}'?\nEl usuario se eliminara de forma permanente.",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                DAOcls dao = new DAOcls();
                bool resultado = dao.EliminarUsuario(idUsuario);

                if (resultado)
                {
                    MessageBox.Show("Usuario eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarTablaUsuarios();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void CargarTablaUsuarios()
        {
            try
            {
                DAOcls dao = new DAOcls();
                List<clsUsuario> listaUsuarios = dao.ObtenerUsuarios();
                dgvUsuarios.DataSource = null;
                dgvUsuarios.DataSource = listaUsuarios;
                if (dgvUsuarios.Columns["Password"] != null)
                {
                    dgvUsuarios.Columns["Password"].Visible = false;
                }
                dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la tabla: " + ex.Message);
            }
        }

    }
}
