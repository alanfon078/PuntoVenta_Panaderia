using MySql.Data.MySqlClient;
using Mysqlx.Connection;
using Panaderia.Clases;
using Panaderia.Conexion;
using System;
using System.Collections.Generic;
using System.Data;
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
        public string Login(string user, string password){
            string rolEncontrado = null; 
            try{
                Conection c = new Conection();
                using (cn = c.ObtenerConexion()){
                    MySqlCommand comando = new MySqlCommand("spLogin", cn);
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@us", user);
                    comando.Parameters.AddWithValue("@pas", password);

                    using (MySqlDataReader lect = comando.ExecuteReader()){
                        // Si hay filas, leemos los datos
                        if (lect.Read())
                        {
                            // Se obtiene el rol del usuario en la base de datos
                            rolEncontrado = lect["rol"].ToString();

                            // Guardamos el usuario en la sesion actual
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
            bool UsuarioDisponible = true;
            try
            {
                {
                    string query = "SELECT COUNT(*) FROM usuarios WHERE user = @user";
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
        /// Funcion para insertar nuevos usuarios en el formulario "RegistroUsuarios.cs"
        public bool RegistrarUsuario(string usuario, string nombre, string apellidos, string email, string telefono, string password, DateTime fechaNacimiento, string rol){
            MySqlConnection cn = null;
            MySqlTransaction transaccion = null;
            bool exito = false;
            try{ 
                Conection c = new Conection();
                cn = c.ObtenerConexion(); 
                transaccion = cn.BeginTransaction();
                // Configurar el comando para usar la transaccion
                MySqlCommand comando = new MySqlCommand("spCrearEmp", cn);
                // Cambiar de consulta a procedimiento almacenado
                comando.CommandType = CommandType.StoredProcedure;
                // Asignar la transacción al comando 
                comando.Transaction = transaccion;
                // Parametros 
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
                if (cn != null && cn.State == ConnectionState.Open){
                    cn.Close();
                }
            }
            return exito;
        }

    }
}
