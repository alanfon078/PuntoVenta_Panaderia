using MySql.Data.MySqlClient;
using Panaderia.Clases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panaderia.Conexion
{
    internal class Conection
    {
        /// <summary>
        /// Obtiene una conexión a la base de datos MySQL.
        /// </summary
        /// <returns> Objeto MySqlConnection abierto.</returns>

        public MySqlConnection ObtenerConexion()
        {
            MySqlConnection conexion = new MySqlConnection("server=localhost; database=Panaderia; user='root'; pwd='root';");
            conexion.Open();
            return conexion;
        }

    }
}
