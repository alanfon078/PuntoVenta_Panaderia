using System;
using System.Collections.Generic;
using System.Text;

namespace Panaderia.Clases
{
    internal class clsUsuario
    {
        private int userID;
        private string user;
        private string nombre;
        private string apellidos;  
        private string email;
        private string telefono;
        private string password;
        private string fechaNacimiento;
        private string fechaCreacion;
        private bool status;
        private string rol;

        public clsUsuario()
        {
        }

        public int UsuarioID
        {
            get { return userID; }
            set { userID = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }

        public string User
        {
            get { return user; }
            set { user = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public bool Status
        {
            get { return status; }
            set { status = value; }
        }

        public string Correo
        {
            get { return email; }
            set { email = value; }
        }

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public string FechaNacimiento
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value; }
        }

        public string FechaCreacion
        {
            get { return fechaCreacion; }
            set { fechaCreacion = value; }
        }

        public string Rol
        {
            get { return rol; }
            set { rol = value; }
        }
    }
}
