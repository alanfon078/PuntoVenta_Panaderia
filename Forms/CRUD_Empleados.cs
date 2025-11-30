using Panaderia.Clases;
using Panaderia.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Panaderia
{
    public partial class CRUD_Empleados : Form
    {
        private int idEmpleadoAModificar = -1;
        //private bool _modoEdicion = false;

        public CRUD_Empleados()
        {
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
            cmbRol.SelectedIndex = 1;
            dtpFechaNacimiento.CustomFormat = "yyyy-mm-dd";
            cargarTodo();
        }

        private void cargarTodo()
        {
            CargarTablaUsuarios();
            LimpiarFormulario();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellidos.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(txtContrasena.Text) ||
                string.IsNullOrWhiteSpace(txtConfirContrasenia.Text))
            {
                MessageBox.Show("Asegurese de llenar todos los campos obligatorios",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string passTemporal = txtContrasena.Text;

            if (passTemporal.Length < 8)
            {
                MessageBox.Show("La contraseña debe tener al menos 8 caracteres.",
                    "Error de contraseña", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool tieneNumero = false;
            foreach (char car in passTemporal)
            {
                if (char.IsDigit(car))
                {
                    tieneNumero = true;
                    break;
                }
            }
            if (!tieneNumero)
            {
                MessageBox.Show("La contraseña debe incluir al menos un numero.",
                    "Error de contraseña", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtContrasena.Text != txtConfirContrasenia.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string usuario = txtUsuario.Text.Trim();
            string nombre = txtNombre.Text.Trim();
            string apellidos = txtApellidos.Text.Trim();
            string email = txtEmail.Text.Trim();
            string telefono = txtTelefono.Text.Trim();
            string contrasena = txtContrasena.Text.Trim();
            DateTime fechaNac = dtpFechaNacimiento.Value;
            string rolSeleccionado = cmbRol.SelectedItem.ToString();
            string rolEmpleado = "";
            if (rolSeleccionado == "Administrador")
            {
                rolEmpleado = "Admin";
            }
            else
            {
                rolEmpleado = "Empleado";
            }

            DAOcls dao = new DAOcls();
            if (!dao.ValidarUsuarioDisponible(usuario))
            {
                MessageBox.Show("Este usuario ya existe, introduzca otros datos",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            bool resultado = dao.RegistrarUsuario(usuario, nombre, apellidos, email, telefono, contrasena, fechaNac, rolEmpleado, true);

            if (resultado)
            {
                MessageBox.Show("El usuario ha sido creado exitosamente", "Exito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                cargarTodo();
            }
            else
            {
                MessageBox.Show("No se ha podido crear el usuario.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormulario()
        {
            txtUsuario.Clear();
            txtNombre.Clear();
            txtApellidos.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();
            txtContrasena.Clear();
            txtConfirContrasenia.Clear();
            cmbRol.SelectedIndex = 1;
            dtpFechaNacimiento.Value = DateTime.Now;
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
                e.SuppressKeyPress = true;
            }
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
                e.SuppressKeyPress = true;
            }
        }

        private void txtApellidos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
                e.SuppressKeyPress = true;
            }
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
                e.SuppressKeyPress = true;
            }
        }

        private void txtTelefono_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
                e.SuppressKeyPress = true;
            }
        }

        private void txtContrasena_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
                e.SuppressKeyPress = true;
            }
        }

        private void txtConfirContrasenia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAgregar.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void btnAgregar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAgregar.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void chBoxShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chBoxShowPass.Checked)
            {
                txtContrasena.UseSystemPasswordChar = false;
                txtConfirContrasenia.UseSystemPasswordChar = false;
            }
            else
            {
                txtContrasena.UseSystemPasswordChar = true;
                txtConfirContrasenia.UseSystemPasswordChar = true;
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
                if (dgvUsuarios.Columns["Status"] != null)
                {
                    dgvUsuarios.Columns["Status"].Visible = false;
                }
                dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la tabla: " + ex.Message);
            }

            try
            {
                DAOcls dao = new DAOcls();
                List<clsUsuario> listaUsuarios = dao.ObtenerUsuarios();
                dgvModificar.DataSource = null;
                dgvModificar.DataSource = listaUsuarios;
                if (dgvModificar.Columns["Password"] != null)
                {
                    dgvModificar.Columns["Password"].Visible = false;
                }
                if (dgvModificar.Columns["Status"] != null)
                {
                    dgvModificar.Columns["Status"].Visible = false;
                }
                dgvModificar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la tabla: " + ex.Message);
            }
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

                    cargarTodo();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEliminar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnEliminar.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void dgvModificar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvModificar.Rows[e.RowIndex];

                idEmpleadoAModificar = Convert.ToInt32(fila.Cells["UsuarioID"].Value);

                txtNuevoUs.Text = fila.Cells["User"].Value.ToString();

                txtNuevoNom.Text = fila.Cells["Nombre"].Value.ToString();

                txtNuevoCorr.Text = fila.Cells["Correo"].Value.ToString();

                txtNuevoTel.Text = fila.Cells["Telefono"].Value.ToString();

                txtNuevoApellido.Text = fila.Cells["Apellidos"].Value.ToString();

                cboNuevoRol.Text = fila.Cells["Rol"].Value.ToString();


            }
        }

        private void btnConfirmarCambios_Click(object sender, EventArgs e)
        {
            bool exito = false;
            DAOcls dao = new DAOcls();

            exito = dao.modificarUsuario(idEmpleadoAModificar, 
                txtNuevoUs.Text,
                txtNuevoNom.Text,
                txtNuevoApellido.Text,
                cboNuevoRol.SelectedItem.ToString(),
                txtNuevoTel.Text, txtNuevoCorr.Text);

            if (exito)
            {
                cargarTodo();
                MessageBox.Show("Usuario modificado con exito", "Administrador de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }else
            {
                MessageBox.Show("Ocurrio un error al modificar el usuario", "Administrador de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
