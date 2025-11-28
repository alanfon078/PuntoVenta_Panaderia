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
                // Lee todos los bytes del archivo y los guarda en un array
                byte[] imageBytes = File.ReadAllBytes(rutaImagen);
                return imageBytes;
            }

    }
}
