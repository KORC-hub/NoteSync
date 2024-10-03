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
    public partial class Settings : Form
    {
        private UserAuthentication _userAuthentication = new UserAuthentication();
        private Entities.User _loggedUser;
        private Label _lblWelcom;
        private Menu _menu;

        public Settings(ref Entities.User user)
        {
            _userAuthentication.GetById(ref user);

            InitializeComponent();
            _loggedUser = user;
            txtNickname.Text = user.Nickname;
            txtPassword.Text = user.Password;
            txtEmail.Text = user.Email;
            txtCreationDate.Text = Convert.ToString(user.CreatedAt);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(txtNickname.Text) || String.IsNullOrEmpty(txtEmail.Text) || String.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Fields are empty.", "Empty fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(!_userAuthentication.IsValidEmail(txtEmail.Text)) 
            {
                MessageBox.Show("The email doesn't have the correct format", "Email error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
            { 
                Entities.User user = new Entities.User()
                {
                    UserId = _loggedUser.UserId,
                    Nickname = txtNickname.Text,
                    Email = txtEmail.Text,
                    Password = txtPassword.Text
                };

                _userAuthentication.Update(ref user);
                this.Hide();
            }
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            Entities.User user = new Entities.User()
            {
                UserId = Convert.ToUInt32(_loggedUser.UserId)
            };

            _userAuthentication.Delete(ref user);
            MessageBox.Show("This account has been eliminated.", "Account eliminated", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            this.Hide();
            Login login = new Login();
            login.Show();

        }
    }
}
