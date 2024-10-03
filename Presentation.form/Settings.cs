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
        private UserBusinessLogic _userBusinessLogic = new UserBusinessLogic();
        private Entities.User _loggedUser;

        public Settings(ref Entities.User user)
        {
            InitializeComponent();
            _loggedUser = user;
            txtNickname.Text = user.Nickname;
            txtPassword.Text = user.Password;
            txtEmail.Text = user.Email;
            txtCreationDate.Text = Convert.ToString(user.CreatedAt);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Settings_Load(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Entities.User user = new Entities.User()
            {
                UserId = _loggedUser.UserId,
                Nickname = txtNickname.Text,
                Email = txtEmail.Text,
                Password = txtPassword.Text
            };

            _userBusinessLogic.Update(ref user);
            this.Hide();
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            Entities.User user = new Entities.User()
            {
                UserId = Convert.ToUInt32(_loggedUser.UserId)
            };

            _userBusinessLogic.Delete(ref user);
            MessageBox.Show("This account has been eliminated.", "Account eliminated", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            this.Hide();
            Login login = new Login();
            login.Show();
        }
    }
}
