using Panaderia.DAO;
using Panaderia.Forms;
// Funcionalidad completa
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
            string user = txtUser.Text;
            string password = txtPassword.Text;
            DAOcls d = new DAOcls();
            string rol = d.Login(user, password);
            if (rol != null)
            {
                this.Hide();
                if (rol == "Admin")
                {
                    MenuAdmin menu = new MenuAdmin();
                    menu.Show();
                }
                else
                {
                    Ventas v = new Ventas();
                    v.Show();
                }
            }
            else
            {
                MessageBox.Show("Usuario o Contraseña Incorrectos", "Error al iniciar Sesion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
                e.SuppressKeyPress = true;
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
                e.SuppressKeyPress = true;
            }
        }

        private void btnLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
