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


        // Agrega esto dentro de la clase DAOcls en DAOcls.cs

        public bool GuardarVenta(decimal total, List<clsDetalleVenta> detalles)
        {
            bool exito = false;
            MySqlConnection conexion = null;
            MySqlTransaction transaccion = null;

            try
            {
                Conection c = new Conection();
                conexion = c.ObtenerConexion();

                // Iniciamos una transacción para asegurar que todo se guarde o nada se guarde
                transaccion = conexion.BeginTransaction();

                // 1. Obtener el ID del usuario actual (basado en el nombre guardado en Login)
                string queryUser = "SELECT userID FROM Usuarios WHERE user = @user LIMIT 1";
                int usuarioID = 1; // ID por defecto (o Admin) si no se encuentra

                MySqlCommand cmdUser = new MySqlCommand(queryUser, conexion, transaccion);
                cmdUser.Parameters.AddWithValue("@user", UsuarioSesion.UsuarioActual);
                object result = cmdUser.ExecuteScalar();
                if (result != null) usuarioID = Convert.ToInt32(result);

                // 2. Insertar la Venta (Cabecera)
                string queryVenta = "INSERT INTO Ventas (fecha, total, userID) VALUES (NOW(), @total, @userID); SELECT LAST_INSERT_ID();";
                MySqlCommand cmdVenta = new MySqlCommand(queryVenta, conexion, transaccion);
                cmdVenta.Parameters.AddWithValue("@total", total);
                cmdVenta.Parameters.AddWithValue("@userID", usuarioID);

                // Obtener el ID de la venta recién creada
                int ventaID = Convert.ToInt32(cmdVenta.ExecuteScalar());

                // 3. Insertar los Detalles y Descontar Stock
                foreach (var item in detalles)
                {
                    // Insertar detalle
                    string queryDetalle = "INSERT INTO DetalleVentas (ventaID, productoID, cantidad, precioUnitario, total) VALUES (@ventaID, @prodID, @cant, @precio, @subtotal)";
                    MySqlCommand cmdDetalle = new MySqlCommand(queryDetalle, conexion, transaccion);
                    cmdDetalle.Parameters.AddWithValue("@ventaID", ventaID);
                    cmdDetalle.Parameters.AddWithValue("@prodID", item.ProductoID);
                    cmdDetalle.Parameters.AddWithValue("@cant", item.Cantidad);
                    cmdDetalle.Parameters.AddWithValue("@precio", item.Precio);
                    cmdDetalle.Parameters.AddWithValue("@subtotal", item.Subtotal);
                    cmdDetalle.ExecuteNonQuery();

                    // Descontar Stock del inventario
                    string queryStock = "UPDATE Productos SET stock = stock - @cant WHERE ProductoID = @prodID";
                    MySqlCommand cmdStock = new MySqlCommand(queryStock, conexion, transaccion);
                    cmdStock.Parameters.AddWithValue("@cant", item.Cantidad);
                    cmdStock.Parameters.AddWithValue("@prodID", item.ProductoID);
                    cmdStock.ExecuteNonQuery();
                }

                // Si todo salió bien, confirmamos los cambios
                transaccion.Commit();
                exito = true;
            }
            catch (Exception ex)
            {
                // Si hubo error, revertimos todo
                if (transaccion != null) transaccion.Rollback();
                Console.WriteLine("Error en transacción: " + ex.Message);
                exito = false;
            }
            finally
            {
                if (conexion != null && conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }

            return exito;
        }

    }
}
