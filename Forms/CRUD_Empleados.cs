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
        public CRUD_Empleados()
        {
            InitializeComponent();
            cmbRol.SelectedIndex = 1;
            dtpFechaNacimiento.CustomFormat = "yyyy-mm-dd";
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
            // Validar si tiene numero
            if (!tieneNumero)
            {
                MessageBox.Show("La contraseña debe incluir al menos un numero.",
                    "Error de contraseña", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Validar que las contraseñas coincidan
            if (txtContrasena.Text != txtConfirContrasenia.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Datos para registrar usuario
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
            // Validar si el usuario ya existe
            if (!dao.ValidarUsuarioDisponible(usuario))
            {
                MessageBox.Show("Este usuario ya existe, introduzca otros datos",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Registrar usuario
            bool resultado = dao.RegistrarUsuario(usuario, nombre, apellidos, email, telefono, contrasena, fechaNac, rolEmpleado);

            if (resultado)
            {
                MessageBox.Show("El usuario ha sido creado exitosamente", "Exito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
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
    }
}
