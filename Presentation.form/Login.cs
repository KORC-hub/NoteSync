using BusinessLogic.core;
using Entities;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace Presentation.form
{
    public partial class Login : Form
    {

        #region Private Varieble

        private UserAuthentication _userAuthentication = new UserAuthentication();
        //private BindingList<User> _users = new BindingList<User>();

        #endregion

        public Login()
        {
            InitializeComponent();
            this.AcceptButton = btnLogIn;
        }
        private void UserRegistration_Load(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblLogIn_Click(object sender, EventArgs e)
        {

        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            User user = new User
            {
                Email = txtEmail.Text,
                Password = txtPassword.Text
            };

            if (_userAuthentication.Login(ref user))
            {
                this.Hide();
                Menu menu = new Menu(ref user);
                menu.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show(user.ErrorMessage, "Sign in error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblCreateAccount_Click(object sender, EventArgs e)
        {
            CreateAccount createAccount = new CreateAccount();
            this.Hide();
            createAccount.Show();
        }
    }
}
