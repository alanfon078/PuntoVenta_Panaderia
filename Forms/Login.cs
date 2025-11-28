using Panaderia.DAO;
using Panaderia.Forms;

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
            DAOcls d = new DAOcls();
            string rol = d.Login(user, password);
            if (rol != null)
            {
                // Autenticación exitosa
                this.Hide();
                if (rol == "Admin")
                {
                    // Si es administrador va a MenuAdmin
                    MenuAdmin menu = new MenuAdmin();
                    menu.Show();
                }
                else { 
                    Ventas v = new Ventas();
                    v.Show();
                }
            }
            else
            {
                MessageBox.Show("Usuario o Contraseña Incorrectos", "Error al iniciar Sesion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
