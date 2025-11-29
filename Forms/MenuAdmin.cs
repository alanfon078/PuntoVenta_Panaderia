using MySqlX.XDevAPI.CRUD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Panaderia.Forms
{
    public partial class MenuAdmin : Form
    {
        public MenuAdmin()
        {
            InitializeComponent();
        }

        private void btnRegistrarVenta_Click(object sender, EventArgs e)
        {
            Ventas v = new Ventas();
            v.Show();
        }

        private void btnRegistrarUsuarios_Click(object sender, EventArgs e)
        {
            RegistroUsuarios r = new RegistroUsuarios();
            r.Show();
        }

        private void btnRegistrarProductos_Click(object sender, EventArgs e)
        {
            frmProductos p = new frmProductos();
            p.Show();
        }

        private void btnEliminarUsuarios_Click(object sender, EventArgs e)
        {
            EliminarUsuarios E = new EliminarUsuarios();
            E.Show();
        }

        private void btnRegistrarUsuarios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnRegistrarUsuarios.PerformClick();
                e.SuppressKeyPress = true;

            }
            else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                btnEliminarUsuarios.Focus();
                e.SuppressKeyPress = true;

            }
            else if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                btnAdministrarProductos.Focus();
                e.SuppressKeyPress = true;

            }
        }
        private void btnRegistrarProductos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAdministrarProductos.PerformClick();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                btnRegistrarVenta.Focus();
                e.SuppressKeyPress = true;

            }
            else if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                btnRegistrarUsuarios.Focus();
                e.SuppressKeyPress = true;

            }
        }

        private void btnEliminarUsuarios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnEliminarUsuarios.PerformClick();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                btnRegistrarUsuarios.Focus();
                e.SuppressKeyPress = true;

            }
            else if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                btnRegistrarVenta.Focus();
                e.SuppressKeyPress = true;

            }
        }

        private void btnRegistrarVenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnRegistrarVenta.PerformClick();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                btnEliminarUsuarios.Focus();
                e.SuppressKeyPress = true;

            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                btnAdministrarProductos.Focus();
                e.SuppressKeyPress = true;

            }
        }

        private void btnRegistrarUsuarios_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                case Keys.Up:
                case Keys.Left:
                case Keys.Right:
                    e.IsInputKey = true;
                    break;
            }
        }

        private void btnRegistrarProductos_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                case Keys.Up:
                case Keys.Left:
                case Keys.Right:
                    e.IsInputKey = true;
                    break;
            }
        }

        private void btnEliminarUsuarios_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                case Keys.Up:
                case Keys.Left:
                case Keys.Right:
                    e.IsInputKey = true;
                    break;
            }
        }

        private void btnRegistrarVenta_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                case Keys.Up:
                case Keys.Left:
                case Keys.Right:
                    e.IsInputKey = true;
                    break;
            }
        }
    }
}
