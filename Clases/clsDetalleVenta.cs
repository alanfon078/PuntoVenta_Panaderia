using System;
using System.Collections.Generic;
using System.Text;

namespace Panaderia.Clases
{
    internal class clsDetalleVenta
    {
        public int ProductoID { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }

        public decimal Subtotal
        {
            get { return Precio * Cantidad; }
        }
    }
}
