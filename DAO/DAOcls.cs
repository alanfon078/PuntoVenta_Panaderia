using MySql.Data.MySqlClient;
using Mysqlx.Connection;
using Panaderia.Clases;
using Panaderia.Conexion;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panaderia.DAO
{
    public static class UsuarioSesion
    {
        public static string UsuarioActual { get; set; } = "Desconocido";
    }

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
                cn = c.ObtenerConexion();
                {
                    string query = "call spLogin(@user, @password);";
                    MySqlCommand comando = new MySqlCommand(query, cn);
                    comando.Parameters.AddWithValue("@user", user);
                    comando.Parameters.AddWithValue("@password", password);
                    int count = Convert.ToInt32(comando.ExecuteScalar());

                    if (count > 0)
                    {
                        loginExitoso = true;
                        UsuarioSesion.UsuarioActual = user;
                        Console.WriteLine(UsuarioSesion.UsuarioActual);
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

        /// <summary>
        /// Obtiene la lista de productos con sus imágenes.
        /// </summary>
        public List<clsProducto> ObtenerProductos()
        {
            List<clsProducto> lista = new List<clsProducto>();
            try
            {
                Conection c = new Conection();
                cn = c.ObtenerConexion();

                string query = "SELECT ProductoID, nombre, precio, stock, fotoProducto FROM Productos";
                MySqlCommand comando = new MySqlCommand(query, cn);

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    clsProducto p = new clsProducto();
                    p.ProductoID = reader.GetInt32("ProductoID");
                    p.Nombre = reader.GetString("nombre");
                    p.Precio = reader.GetDecimal("precio");
                    p.Stock = reader.GetInt32("stock");

                    // Convertir BLOB a Imagen
                    if (!reader.IsDBNull(reader.GetOrdinal("fotoProducto")))
                    {
                        byte[] imgBytes = (byte[])reader["fotoProducto"];
                        using (MemoryStream ms = new MemoryStream(imgBytes))
                        {
                            p.Imagen = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        p.Imagen = null;
                    }

                    lista.Add(p);
                }
                reader.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al obtener productos: " + ex.Message);
            }
            return lista;
        }

    }
}
