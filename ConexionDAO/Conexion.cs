using MySql.Data.MySqlClient;
using Panaderia.Clases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panaderia.ConexionDAO
{
    internal class Conexion
    {
        /// <summary>
        /// Obtiene una conexión a la base de datos MySQL.
        /// </summary
        /// <returns> Objeto MySqlConnection abierto.</returns>

        public static MySqlConnection ObtenerConexion()
        {
            MySqlConnection conexion = new MySqlConnection("server=localhost; database=Panaderia; user=root; pwd=root");
            conexion.Open();
            return conexion;
        }

        /// <summary>
        /// Verifica las credenciales del usuario en la base de datos.
        /// </summary>
        /// <param name="user">Nombre de usuario</param>
        /// <param name="password">Contraseña sin encriptar</param>
        /// <returns>True si el login es exitoso, False en caso contrario.</returns>
        public bool Login(string user, string password)
        {
            bool loginExitoso = false;
            try
            {
                using (MySqlConnection conexion = ObtenerConexion())
                {
                    string query = "set @usuarioActivo=0; call spLogin(@user, @password, @usuarioActivo);";
                    MySqlCommand comando = new MySqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@user", user);
                    comando.Parameters.AddWithValue("@password", password);
                    int count = Convert.ToInt32(comando.ExecuteScalar());

                    if (count > 0)
                    {
                        loginExitoso = true;
                    }
                }
            }
            catch (MySqlException ex)
            {
                // Manejar la excepción (por ejemplo, mostrar un mensaje de error)
                Console.WriteLine("Error de conexión: " + ex.Message);
            }
            return loginExitoso;
        }

        /// <summary>
        /// Función para validar si un usuario está disponible.
        /// Verifica si un nombre de usuario ya está registrado en la base de datos.
        /// </summary>
        /// <param name="user">Nombre de usuario a verificar</param>
        /// <returns>True si el usuario está disponible, False si ya existe.</returns>
        public bool ValidarUsuarioDisponible(string user)
        {
            bool UsuarioDisponible = true;
            try
            {
                using (MySqlConnection conexion = ObtenerConexion())
                {
                    string query = "SELECT COUNT(*) FROM user WHERE user = @user";
                    MySqlCommand comando = new MySqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@user", user);

                    int count = Convert.ToInt32(comando.ExecuteScalar());

                    if (count > 0)
                    {
                        UsuarioDisponible = false;
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error de conexión: " + ex.Message);
            }
            return UsuarioDisponible;
        }
    }
}
