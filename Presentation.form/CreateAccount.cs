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
        UserBusinessLogic _userBusinessLogic = new UserBusinessLogic();
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

                _userBusinessLogic.Create(ref user);
                this.Hide();
                login.Show();
            }
            else if (!_userBusinessLogic.IsValidEmail(txtNickname.Text))
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
    }
}
