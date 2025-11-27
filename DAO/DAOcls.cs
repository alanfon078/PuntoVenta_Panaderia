using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using Panaderia.Conexion;
using Mysqlx.Connection;

namespace Panaderia.DAO
{
    internal class DAOcls
    {
        private MySqlConnection cn;

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
                Conection c = new Conection();
                cn =  c.ObtenerConexion(user, password);
                {
                    string query = "call spLogin(@user, @password);";
                    MySqlCommand comando = new MySqlCommand(query, cn);
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
                // Manejar la excepción
                Console.WriteLine("Error de conexión: " + ex.Message);
                MessageBox.Show("Usuario o Contraseña Incorrectos", "Error al iniciar Sesion", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                {
                    string query = "SELECT COUNT(*) FROM user WHERE user = @user";
                    MySqlCommand comando = new MySqlCommand(query, cn);
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
