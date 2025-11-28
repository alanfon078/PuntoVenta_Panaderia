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

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
