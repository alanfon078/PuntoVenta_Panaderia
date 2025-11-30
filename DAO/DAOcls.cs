using MySql.Data.MySqlClient;
using Mysqlx.Connection;
using Panaderia.Clases;
using Panaderia.Conexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Text;
using System.Transactions;

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
        /// Asegura que la conexión a la base de datos esté abierta.
        /// </summary>
        /// <returns>Ninguno</returns>
        private void AsegurarConexion()
        {
            if (cn.State != ConnectionState.Open)
            {
                cn.Open();
            }
        }


        /// <summary>
        /// Verifica las credenciales del usuario en la base de datos.
        /// </summary>
        /// <param name="user">Nombre de usuario</param>
        /// <param name="password">Contraseña sin encriptar</param>
        /// <returns>True si el login es exitoso, False en caso contrario.</returns>
        public string Login(string user, string password)
        {
            string rolEncontrado = null;
            try
            {
                MySqlCommand comando = new MySqlCommand("spLogin", cn);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@us", user);
                comando.Parameters.AddWithValue("@pas", password);

                using (MySqlDataReader lect = comando.ExecuteReader())
                {
                    if (lect.Read())
                    {
                        rolEncontrado = lect["rol"].ToString();
                        UsuarioSesion.UsuarioActual = user;
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
            bool UsuarioDisponible = true;
            try
            {
                AsegurarConexion();
                string query = "SELECT COUNT(*) FROM usuarios WHERE user = @user";
                MySqlCommand comando = new MySqlCommand(query, cn);
                comando.Parameters.AddWithValue("@user", user);

                int count = Convert.ToInt32(comando.ExecuteScalar());

                if (count > 0)
                {
                    UsuarioDisponible = false;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error de conexion: " + ex.Message);
            }
            return UsuarioDisponible;
        }

        /// <summary>
        /// Obtiene la lista de productos con sus imágenes.
        /// </summary>
        /// <params>Ninguno</params>
        /// <returns>List de productos con imágenes.</returns>
        /// <summary>
        /// Obtiene SOLO los productos activos para mostrar en el catálogo.
        /// </summary>
        public List<clsProducto> ObtenerProductos()
        {
            List<clsProducto> lista = new List<clsProducto>();
            try
            {
                AsegurarConexion();
                string query = "SELECT ProductoID, nombre, precio, stock, fotoProducto FROM Productos WHERE activo = true";
                MySqlCommand comando = new MySqlCommand(query, cn);

                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clsProducto p = new clsProducto();
                        p.ProductoID = reader.GetInt32("ProductoID");
                        p.Nombre = reader.GetString("nombre");
                        p.Precio = reader.GetDecimal("precio");
                        p.Stock = reader.GetInt32("stock");

                        if (!reader.IsDBNull(reader.GetOrdinal("fotoProducto")))
                        {
                            Imagen_A_Bloop imgConverter = new Imagen_A_Bloop();
                            byte[] imgBytes = (byte[])reader["fotoProducto"];
                            p.Imagen = Image.FromStream(imgConverter.ConvertirBlobAImagen(imgBytes));
                        }
                        else
                        {
                            p.Imagen = null;
                        }
                        lista.Add(p);
                    }
                }
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
        public bool RegistrarUsuario(string usuario, string nombre, string apellidos, string email, string telefono, string password, DateTime fechaNacimiento, string rol, bool status)
        {
            MySqlTransaction transaccion = null;
            bool exito = false;
            try
            {
                AsegurarConexion();
                transaccion = cn.BeginTransaction();
                string queryUserAct = "SET @usuarioapp = @us;";
                MySqlCommand cmdUserAct = new MySqlCommand(queryUserAct, cn, transaccion);
                cmdUserAct.Parameters.AddWithValue("@us", UsuarioSesion.UsuarioActual);
                cmdUserAct.ExecuteNonQuery();
                MySqlCommand comando = new MySqlCommand("spCrearEmp", cn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Transaction = transaccion;
                comando.Parameters.AddWithValue("@usu", usuario);
                comando.Parameters.AddWithValue("@nom", nombre);
                comando.Parameters.AddWithValue("@ape", apellidos);
                comando.Parameters.AddWithValue("@emaill", email);
                comando.Parameters.AddWithValue("@tel", telefono);
                comando.Parameters.AddWithValue("@pass", password);
                comando.Parameters.AddWithValue("@feNac", fechaNacimiento);
                comando.Parameters.AddWithValue("@roll", rol);
                comando.Parameters.AddWithValue("@sta", status);

                comando.ExecuteNonQuery();
                transaccion.Commit();
                exito = true;
            }
            catch (Exception ex)
            {
                if (transaccion != null)
                {
                    try
                    {
                        transaccion.Rollback();
                    }
                    catch { }
                }

                Console.WriteLine("Error al realizar la transaccion: " + ex.Message);
            }
            return exito;
        }

        /// <summary>
        /// Metodo para eliminar  un empleado por su ID usando el SP spEliminarEmp.
        /// </summary>
        /// <param name="idUsuario">ID del usuario a eliminar.</param>
        /// <returns>True si la eliminacion fue exitosa, False en caso contrario.</returns>
        public bool EliminarUsuario(int idUsuario)
        {
            bool exito = false;
            MySqlTransaction transaccion = null;
            try
            {
                AsegurarConexion();
                transaccion = cn.BeginTransaction();

                string queryUserAct = "SET @usuarioapp = @us;";
                MySqlCommand cmdUserAct = new MySqlCommand(queryUserAct, cn, transaccion);
                cmdUserAct.Parameters.AddWithValue("@us", UsuarioSesion.UsuarioActual);
                cmdUserAct.ExecuteNonQuery();

                MySqlCommand comando = new MySqlCommand("spEliminarEmp", cn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@uID", idUsuario);

                int filas = comando.ExecuteNonQuery();

                if (filas > 0)
                {
                    exito = true;
                }
                transaccion.Commit();
                return exito;
            }
            catch (MySqlException ex)
            {
                if(transaccion != null)
                {
                    try
                    {
                        transaccion.Rollback();
                    }
                    catch { }
                }

                Console.WriteLine("Error al eliminar usuario: " + ex.Message);
            }
            return exito;
        }

        /// <summary>
        /// Funcion para obtener la lista de usuarios desde la base de datos.
        /// </summary>
        /// <params>ninguna</params>
        /// <returns>Lista de usuarios.</returns>
        public List<clsUsuario> ObtenerUsuarios()
        {
            List<clsUsuario> lista = new List<clsUsuario>();
            try
            {
                AsegurarConexion();
                MySqlCommand comando = new MySqlCommand("spLeerEmp", cn);
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
                        u.Status = reader.GetBoolean("status");
                        u.Rol = reader.GetString("rol");
                        u.FechaNacimiento = reader.GetDateTime("fechaNacimiento").ToShortDateString();
                        u.FechaCreacion = reader.GetDateTime("fechaCreacion").ToString();
                        if(u.Status == true)
                        {
                            lista.Add(u);
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar los usuarios " + ex.Message);
            }
            return lista;
        }


        /// <summary>
        /// Funcion para guardar una venta y sus detalles en la base de datos
        /// </summary>
        /// <param name="totalVenta">Total de la venta</param>
        /// <param name="detalles">Lista de detalles de la venta</param>
        /// </returns> True si la venta se guardo exitosamente, False en caso contrario.</returns>
        public bool GuardarVenta(decimal totalVenta, List<clsDetalleVenta> detalles)
        {
            bool exito = false;
            MySqlTransaction transaccion = null;

            try
            {
                AsegurarConexion();
                transaccion = cn.BeginTransaction();
                string queryUserAct = "SET @usuarioapp = @us;";
                MySqlCommand cmdUserAct = new MySqlCommand(queryUserAct, cn, transaccion);
                cmdUserAct.Parameters.AddWithValue("@us", UsuarioSesion.UsuarioActual);
                cmdUserAct.ExecuteNonQuery();

                string queryUser = "SELECT userID FROM Usuarios WHERE user = @user LIMIT 1";
                MySqlCommand cmdUser = new MySqlCommand(queryUser, cn, transaccion);
                cmdUser.Parameters.AddWithValue("@user", UsuarioSesion.UsuarioActual);
                object resultUser = cmdUser.ExecuteScalar();

                int userID = (resultUser != null) ? Convert.ToInt32(resultUser) : 1; 

                string queryVenta = "INSERT INTO Ventas (fecha, total, userID) VALUES (NOW(), @total, @userID); SELECT LAST_INSERT_ID();";
                MySqlCommand cmdVenta = new MySqlCommand(queryVenta, cn, transaccion);
                cmdVenta.Parameters.AddWithValue("@total", totalVenta);
                cmdVenta.Parameters.AddWithValue("@userID", userID);

                int idVentaGenerada = Convert.ToInt32(cmdVenta.ExecuteScalar());

                foreach (var item in detalles)
                {
                    string queryDetalle = "INSERT INTO DetalleVentas (ventaID, productoID, cantidad, precioUnitario, total) VALUES (@ventaID, @prodID, @cant, @precioU, @subtotal)";
                    MySqlCommand cmdDetalle = new MySqlCommand(queryDetalle, cn, transaccion);
                    cmdDetalle.Parameters.AddWithValue("@ventaID", idVentaGenerada);
                    cmdDetalle.Parameters.AddWithValue("@prodID", item.ProductoID);
                    cmdDetalle.Parameters.AddWithValue("@cant", item.Cantidad);
                    cmdDetalle.Parameters.AddWithValue("@precioU", item.Precio);
                    cmdDetalle.Parameters.AddWithValue("@subtotal", item.Subtotal);
                    cmdDetalle.ExecuteNonQuery();

                    string queryStock = "UPDATE Productos SET stock = stock - @cant WHERE ProductoID = @prodID";
                    MySqlCommand cmdStock = new MySqlCommand(queryStock, cn, transaccion);
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
                Console.WriteLine("Error en transacción de venta: " + ex.Message);
            }

            return exito;
        }


        /// <summary>
        /// Elimina una lista de productos seleccionados por sus IDs.
        /// Configura la variable de sesión para que el Trigger de auditoría detecte el usuario.
        /// </summary>
        /// <param name="listaIds">Lista de ProductoID a eliminar.</param>
        /// <returns>True si todo salió bien, False si hubo error.</returns>
        public bool EliminarListaProductos(List<int> listaIds)
        {
            bool exito = true;
            foreach (int id in listaIds)
            {
                if (!EliminarProducto(id)) exito = false;
            }
            return exito;
        }

        /// <summary>
        /// Realiza un borrado lógico del producto estableciendo 'activo' a 0.
        /// Esto evita errores de llave foránea con DetalleVentas.
        /// </summary>
        /// <param name="idProducto">ID del producto a eliminar.</param>
        /// <returns>True si la eliminación fue exitosa, False en caso contrario.</returns>
        public bool EliminarProducto(int idProducto)
        {
            bool exito = false;
            MySqlTransaction transaction = null;

            try
            {
                AsegurarConexion();
                transaction = cn.BeginTransaction();

                string queryUserAct = "SET @usuarioapp = @us;";
                MySqlCommand cmdUserAct = new MySqlCommand(queryUserAct, cn, transaction);
                cmdUserAct.Parameters.AddWithValue("@us", UsuarioSesion.UsuarioActual);
                cmdUserAct.ExecuteNonQuery();

                string query = "call spEliminarProducto(@id)";
                MySqlCommand cmd = new MySqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@id", idProducto);

                int filasAfectadas = cmd.ExecuteNonQuery();
                if (filasAfectadas > 0) exito = true;
                transaction.Commit();
                return exito;
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    try
                    {
                        transaction.Rollback();
                    }
                    catch { }
                }
                Console.WriteLine("Error al eliminar producto: " + ex.Message);
            }
            return exito;
        }

        /// <summary>
        /// Registra un nuevo producto con su imagen en la base de datos
        /// </summary>
        /// <param name="nombre">Nombre del producto</param>
        /// <param name="precio">Precio del producto</param>
        /// <param name="stock">Cantidad en stock</param>
        /// <param name="imagen">Imagen del producto en formato BLOB (array de bytes)</param>
        /// returns>True si el registro fue exitoso, False en caso contrario.</returns>
        public bool RegistrarProducto(string nombre, double precio, int stock, byte[] imagen)
        {
            bool exito = false;
            MySqlTransaction transaction = null;
            try
            {
                AsegurarConexion();
                transaction = cn.BeginTransaction();
                string queryUserAct = "SET @usuarioapp = @us;";
                MySqlCommand cmdUserAct = new MySqlCommand(queryUserAct, cn, transaction);
                cmdUserAct.Parameters.AddWithValue("@us", UsuarioSesion.UsuarioActual);
                cmdUserAct.ExecuteNonQuery();

                string query = "call spAgregarProducto (@nom, @prec, @stk, true, @img);";
                MySqlCommand comando = new MySqlCommand(query, cn);
                comando.Parameters.AddWithValue("@nom", nombre);
                comando.Parameters.AddWithValue("@prec", precio);
                comando.Parameters.AddWithValue("@stk", stock);
                comando.Parameters.AddWithValue("@img", imagen);

                int filas = comando.ExecuteNonQuery();
                if (filas > 0) exito = true;
                transaction.Commit();
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    try
                    {
                        transaction.Rollback();
                    }
                    catch { }
                }
                MessageBox.Show("Error al registrar producto: " + ex.Message);
            }
            return exito;
        }
        /// <summary>
        /// Obtiene un reporte de ventas por producto en un rango de fechas.
        /// </summary>
        /// <param name="inicio"></param>
        /// <param name="fin"></param>
        /// <returns>DataTable con el reporte de ventas.</returns>
        public DataTable ObtenerReporteVentas(DateTime inicio, DateTime fin)
        {
            DataTable tablaReporte = new DataTable();
            try
            {
                AsegurarConexion(); 
                string consulta = @"
                select 
                    p.ProductoID as 'ID',
                    p.nombre as 'Producto',
                    sum(dv.cantidad) as 'Cantidad',
                    p.precio as 'Precio Unitario',
                    SUM(dv.total) as 'Monto'
                from Ventas v
                join DetalleVentas dv ON v.ventaID = dv.ventaID
                join Productos p ON dv.productoID = p.ProductoID
                where date(v.fecha) between @fechaInicio and @fechaFin
                group by p.ProductoID, p.nombre, p.precio
                order by sum(dv.cantidad) desc,
                sum(dv.total) desc";

                MySqlCommand comando = new MySqlCommand(consulta, cn);
                comando.CommandType = CommandType.Text; 

                comando.Parameters.AddWithValue("@fechaInicio", inicio.ToString("yyyy-MM-dd"));
                comando.Parameters.AddWithValue("@fechaFin", fin.ToString("yyyy-MM-dd"));
                MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
                adaptador.Fill(tablaReporte);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return tablaReporte;
        }

        /// <summary>
        /// Modifica un producto existente usando el SP spActProducto
        /// </summary>
        /// <param name="id">ID del producto a modificar</param>
        /// <param name="nombre">Nuevo nombre</param>
        /// <param name="precio">Nuevo precio</param>
        /// <param name="stock">Nuevo stock</param>
        /// <param name="imagen">Imagen en bytes (nueva o existente)</param>
        /// <returns>True si la modificación fue exitosa.</returns>
        public bool ModificarProducto(int id, string nombre, double precio, int stock, byte[] imagen)
        {
            bool exito = false;
            MySqlTransaction transaction = null;

            try
            {
                AsegurarConexion();
                transaction = cn.BeginTransaction();

                string queryUserAct = "SET @usuarioapp = @us;";
                MySqlCommand cmdUserAct = new MySqlCommand(queryUserAct, cn, transaction);
                cmdUserAct.Parameters.AddWithValue("@us", UsuarioSesion.UsuarioActual);
                cmdUserAct.ExecuteNonQuery();

                string query = "call spActProducto(@id, @nom, @prec, @stk, @img);";
                MySqlCommand comando = new MySqlCommand(query, cn);
                comando.Transaction = transaction;

                comando.Parameters.AddWithValue("@id", id);
                comando.Parameters.AddWithValue("@nom", nombre);
                comando.Parameters.AddWithValue("@prec", precio);
                comando.Parameters.AddWithValue("@stk", stock);
                comando.Parameters.AddWithValue("@img", imagen);

                int filas = comando.ExecuteNonQuery();

                transaction.Commit();
                exito = true;
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    try
                    {
                        transaction.Rollback();
                    }
                    catch { }
                }
                Console.WriteLine("Error al modificar producto: " + ex.Message);
            }

            return exito;
        }


        /// <summary>
        /// Modifica los datos de un usuario existente en la base de datos.
        /// </summary>
        /// <param name="UsuarioID">ID del usuario a modificar</param>
        /// <param name="usuario">Nuevo nombre de usuario</param>
        /// <param name="nombre">Nuevo nombre del usuario</param>
        /// <param name="apellidos">Nuevos apellidos del usuario</param>
        /// <param name="rol">Nuevo rol del usuario</param>
        /// <param name="telefono">Nuevo telefono del usuario</param>
        /// <param name="email">Nuevo email del usuario</param>
        /// <returns>True si la modificación fue exitosa, False en caso contrario.</returns>
        public bool modificarUsuario(int UsuarioID, string usuario, string nombre, string apellidos, string rol, string telefono, string email)
        {
            bool exito = false;
            MySqlTransaction transaccion = null;
            try
            {
                AsegurarConexion();
                transaccion = cn.BeginTransaction();
                string queryUserAct = "SET @usuarioapp = @us;";
                MySqlCommand cmdUserAct = new MySqlCommand(queryUserAct, cn, transaccion);
                cmdUserAct.Parameters.AddWithValue("@us", UsuarioSesion.UsuarioActual);
                cmdUserAct.ExecuteNonQuery();

                string queryAct = "call spActualizarEmp(@uID, @usu, @nom, @ape, @roll, @tel, @emaill);";
                MySqlCommand comando = new MySqlCommand(queryAct, cn, transaccion);
                comando.Parameters.AddWithValue("@uID", UsuarioID);
                comando.Parameters.AddWithValue("@usu", usuario);
                comando.Parameters.AddWithValue("@nom", nombre);
                comando.Parameters.AddWithValue("@ape", apellidos);
                comando.Parameters.AddWithValue("@roll", rol);
                comando.Parameters.AddWithValue("@tel", telefono);
                comando.Parameters.AddWithValue("@emaill", email);
                int filas = comando.ExecuteNonQuery();
                if (filas > 0)
                {
                    exito = true;
                    transaccion.Commit();
                }
                return exito;
            }
            catch (Exception ex)
            {
                if (transaccion != null)
                {
                    try
                    {
                        transaccion.Rollback();
                    }
                    catch { }
                }
                Console.WriteLine("Error al actualizar usuario: " + ex.Message);
            }
            return exito;
        }

    }
}
