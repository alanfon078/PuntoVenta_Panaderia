using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.IO;

namespace Panaderia.Clases
{
    internal class Imagen_A_Bloop
    {
        
        public byte[] ConvertirImagenABlob(string rutaImagen)
            {
                byte[] imageBytes = File.ReadAllBytes(rutaImagen);
                return imageBytes;
            }

    }
}
