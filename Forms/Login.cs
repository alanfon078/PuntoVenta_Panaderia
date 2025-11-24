using Panaderia.ConexionDAO;

namespace Panaderia
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Lógica de autenticación aquí
            string user = txtUser.Text;
            string password = txtPassword.Text;
            Conexion c = new Conexion();
            bool b = c.Login(user, password);
            b=true;
            if (b)
            {
                // Autenticación exitosa
                this.Hide();
                Ventas v = new Ventas();
                v.Show();
            }
            else
            {
                MessageBox.Show("Usuario o Contraseña Incorrectos", "Error al iniciar Sesion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
