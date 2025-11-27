using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Panaderia.Clases
{
    public class clsProducto
    {
        public int ProductoID { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public Image Imagen { get; set; } 
    }
}
