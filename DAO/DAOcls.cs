using MySql.Data.MySqlClient;
using Mysqlx.Connection;
using Panaderia.Clases;
using Panaderia.Conexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;

namespace Panaderia.DAO
{
    public static class UsuarioSesion
    {
        public static string UsuarioActual { get; set; } = "Desconocido";
    }

    internal class DAOcls
    {   

        private MySqlConnection cn = new Conection().ObtenerConexion();
 

        /// <summary>
        /// Verifica las credenciales del usuario en la base de datos.
        /// </summary>
        /// <param name="user">Nombre de usuario</param>
        /// <param name="password">Contraseña sin encriptar</param>
        /// <returns>True si el login es exitoso, False en caso contrario.</returns>
        public string Login(string user, string password){
            string rolEncontrado = null; 
            try{
                using (cn){
                    MySqlCommand comando = new MySqlCommand("spLogin", cn);
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@us", user);
                    comando.Parameters.AddWithValue("@pas", password);

                    using (MySqlDataReader lect = comando.ExecuteReader()){
                        if (lect.Read())
                        {
                            rolEncontrado = lect["rol"].ToString();

                            UsuarioSesion.UsuarioActual = user;
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error de conexión: " + ex.Message);
            }
            return rolEncontrado; 
        }



        /// <summary>
        /// Función para validar si un usuario está disponible.
        /// Verifica si un nombre de usuario ya está registrado en la base de datos.
        /// </summary>
        /// <param name="user">Nombre de usuario a verificar</param>
        /// <returns>True si el usuario está disponible, False si ya existe.</returns>
        public bool ValidarUsuarioDisponible(string user)
        {
            MySqlConnection connection = cn;
            bool UsuarioDisponible = true;
            try
            {
                {
                    string query = "SELECT COUNT(*) FROM usuarios WHERE user = @user";
                    MySqlCommand comando = new MySqlCommand(query, connection);
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
                Console.WriteLine("Error de conexion: " + ex.Message);
            }
            finally 
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return UsuarioDisponible;
        }

        /// <summary>
        /// Obtiene la lista de productos con sus imágenes.
        /// </summary>
        /// <params>Ninguno</params>
        /// <returns>Lista de productos con imágenes.</returns>
        public List<clsProducto> ObtenerProductos()
        {
            List<clsProducto> lista = new List<clsProducto>();
            try
            {

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

        /// <summary>
        /// Funcion para insertar nuevos usuarios en el formulario "RegistroUsuarios.cs"
        /// </summary>
        /// <param name="usuario">Nombre de usuario</param>
        /// <param name="nombre">Nombre del usuario</param>
        /// <param name="apellidos">Apellidos del usuario</param>
        /// <param name="email">Email del usuario</param>
        /// <param name="telefono">Telefono del usuario</param>
        /// <param name="password">Contraseña del usuario</param>
        /// <param name="fechaNacimiento">Fecha de nacimiento del usuario</param>
        /// <rerturns>True si el registro fue exitoso, False en caso contrario.</returns>
        public bool RegistrarUsuario(string usuario, string nombre, string apellidos, string email, string telefono, string password, DateTime fechaNacimiento, string rol){
            MySqlConnection con = cn;
            MySqlTransaction transaccion = null;
            bool exito = false;
            try{ 
                transaccion = con.BeginTransaction();
                MySqlCommand comando = new MySqlCommand("spCrearEmp", cn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Transaction = transaccion;
                comando.Parameters.AddWithValue("@usu", usuario);
                comando.Parameters.AddWithValue("@nom", nombre);
                comando.Parameters.AddWithValue("@ape", apellidos);
                comando.Parameters.AddWithValue("@emaill", email);
                comando.Parameters.AddWithValue("@tel", telefono);
                comando.Parameters.AddWithValue("@pass", password);
                comando.Parameters.AddWithValue("@feNac", fechaNacimiento.ToString("yyyy-MM-dd"));
                comando.Parameters.AddWithValue("@roll", rol);

                comando.ExecuteNonQuery();
                transaccion.Commit();
                exito = true;
            }
            catch (Exception ex){
                // Rollback
                if (transaccion != null)
                {
                    try { 
                        transaccion.Rollback(); 
                    } 
                    catch { 
                    }
                }

                Console.WriteLine("Error al realizar la transaccion: " + ex.Message);
            }
            finally
            {
                // Cerrar conexion
                if (con != null && con.State == ConnectionState.Open){
                    con.Close();
                }
            }
            return exito;
        }

        /// <summary>
        /// Metodo para eliminar  un empleado por su ID usando el SP spEliminarEmp.
        /// </summary>
        /// <param name="idUsuario">ID del usuario a eliminar.</param>
        /// <returns>True si la eliminacion fue exitosa, False en caso contrario.</returns>
        public bool EliminarUsuario(int idUsuario){
            bool exito = false;
            MySqlConnection con = cn;
            try{
                using (con){
                    MySqlCommand comando = new MySqlCommand("spEliminarEmp", con);
                    comando.CommandType = CommandType.StoredProcedure;
                    // Parametro que coincida con el del SP
                    comando.Parameters.AddWithValue("@uID", idUsuario);

                    int filas = comando.ExecuteNonQuery();

                    if (filas > 0)
                    {
                        exito = true;
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al eliminar usuario: " + ex.Message);
            }
            finally
            {
                if (cn != null && cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }
            return exito;
        }

        /// <summary>
        /// Funcion para obtener la lista de usuarios desde la base de datos.
        /// </summary>
        /// <params>ninguna</params>
        /// <returns>Lista de usuarios.</returns>
        public List<clsUsuario> ObtenerUsuarios(){
            List<clsUsuario> lista = new List<clsUsuario>();
            MySqlConnection conexion = cn;
            try
            {
                using (conexion){
                    MySqlCommand comando = new MySqlCommand("spLeerEmp", conexion);
                    comando.CommandType = CommandType.StoredProcedure;

                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            clsUsuario u = new clsUsuario();
                            u.UsuarioID = reader.GetInt32("userID");
                            u.User = reader.GetString("user");
                            u.Nombre = reader.GetString("nombre");
                            u.Apellidos = reader.GetString("apellidos");
                            u.Correo = reader.IsDBNull(reader.GetOrdinal("email")) ? "" : reader.GetString("email");
                            u.Telefono = reader.GetString("telefono");
                            u.Rol = reader.GetString("rol");
                            u.FechaNacimiento = reader.GetDateTime("fechaNacimiento").ToShortDateString();
                            u.FechaCreacion = reader.GetDateTime("fechaCreacion").ToString();
                            lista.Add(u);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar los usuarios " + ex.Message);
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            return lista;
        }


        /// <summary>
        /// Funcion para guardar una venta y sus detalles en la base de datos
        /// </summary>
        /// <param name="detalles">Lista de detalles de la venta</param>
        /// </returns> True si la venta se guardo exitosamente, False en caso contrario.</returns>
        public bool GuardarVenta(decimal total, List<clsDetalleVenta> detalles)
        {
            bool exito = false;
            MySqlConnection conexion = cn;
            MySqlTransaction transaccion = null;

            try
            {

                transaccion = conexion.BeginTransaction();

                string queryUser = "SELECT userID FROM Usuarios WHERE user = @user LIMIT 1";
                int usuarioID = 1; 

                MySqlCommand cmdUser = new MySqlCommand(queryUser, cn, transaccion);
                cmdUser.Parameters.AddWithValue("@user", UsuarioSesion.UsuarioActual);
                object result = cmdUser.ExecuteScalar();
                if (result != null) usuarioID = Convert.ToInt32(result);


                string queryVenta = "INSERT INTO Ventas (fecha, total, userID) VALUES (NOW(), @total, @userID); SELECT LAST_INSERT_ID();";
                MySqlCommand cmdVenta = new MySqlCommand(queryVenta, conexion, transaccion);
                cmdVenta.Parameters.AddWithValue("@total", total);
                cmdVenta.Parameters.AddWithValue("@userID", usuarioID);

                
                int ventaID = Convert.ToInt32(cmdVenta.ExecuteScalar());

                
                foreach (var item in detalles)
                {
                    string queryDetalle = "INSERT INTO DetalleVentas (ventaID, productoID, cantidad, precioUnitario, total) VALUES (@ventaID, @prodID, @cant, @precio, @subtotal)";
                    MySqlCommand cmdDetalle = new MySqlCommand(queryDetalle, conexion, transaccion);
                    cmdDetalle.Parameters.AddWithValue("@ventaID", ventaID);
                    cmdDetalle.Parameters.AddWithValue("@prodID", item.ProductoID);
                    cmdDetalle.Parameters.AddWithValue("@cant", item.Cantidad);
                    cmdDetalle.Parameters.AddWithValue("@precio", item.Precio);
                    cmdDetalle.Parameters.AddWithValue("@subtotal", item.Subtotal);
                    cmdDetalle.ExecuteNonQuery();

                    
                    string queryStock = "UPDATE Productos SET stock = stock - @cant WHERE ProductoID = @prodID";
                    MySqlCommand cmdStock = new MySqlCommand(queryStock, conexion, transaccion);
                    cmdStock.Parameters.AddWithValue("@cant", item.Cantidad);
                    cmdStock.Parameters.AddWithValue("@prodID", item.ProductoID);
                    cmdStock.ExecuteNonQuery();
                }

                transaccion.Commit();
                exito = true;
            }
            catch (Exception ex)
            {
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
