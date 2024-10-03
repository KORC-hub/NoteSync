using BusinessLogic.core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.form
{
    public partial class CreateAccount : Form
    {
        UserAuthentication _userAuthentication = new UserAuthentication();
        Login login = new Login();
        public CreateAccount()
        {
            InitializeComponent();
            this.AcceptButton = btnCreateAccount;
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            Entities.User user = new Entities.User
            {
                Email = txtEmailAddress.Text,
                Nickname = txtNickname.Text,
                Password = txtPassword.Text
            };

            if (txtPassword.Text == txtConfirmPassword.Text)
            {

                _userAuthentication.Create(ref user);
                this.Hide();
                login.Show();
            }
            else if (!_userAuthentication.IsValidEmail(txtNickname.Text))
            {
                MessageBox.Show("The email doesn't have the correct format", "Email error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("The passwords are not the same", "Password error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void lblAppName_Click(object sender, EventArgs e)
        {
            this.Hide();
            login.Show();
        }

        private void CreateAccount_Load(object sender, EventArgs e)
        {

        }
    }
}
