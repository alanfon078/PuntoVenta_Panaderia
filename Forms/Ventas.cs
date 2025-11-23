using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Panaderia
{
    public partial class Ventas : Form
    {
        public Ventas()
        {
            InitializeComponent();
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }

    }
}
