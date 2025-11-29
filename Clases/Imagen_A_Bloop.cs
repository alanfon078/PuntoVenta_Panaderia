using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.IO;
using Org.BouncyCastle.Utilities;

namespace Panaderia.Clases
{
    internal class Imagen_A_Bloop
    {
        
        public byte[] ConvertirImagenABlob(string rutaImagen)
            {
                byte[] imageBytes = File.ReadAllBytes(rutaImagen);
                return imageBytes;
            }

        public MemoryStream ConvertirBlobAImagen(byte[] blobImagen)
            {
                MemoryStream memoryStream = new MemoryStream(blobImagen);
                return memoryStream;
        }

        public string BytesAStringHex(byte[] blobImagen)
        {
            string hexString = Convert.ToHexString(blobImagen);
            return hexString;
        }

    }
}
