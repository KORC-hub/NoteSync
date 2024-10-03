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

        private UserBusinessLogic _userBusinessLogic = new UserBusinessLogic();
        //private BindingList<User> _users = new BindingList<User>();

        #endregion

        public Login()
        {
            InitializeComponent();
            this.AcceptButton = btnLogIn;
        }


        //private void btnAdd_Click(object sender, EventArgs e)
        //{
        //    User user = new User()
        //    {
        //        Nickname = txtNickname.Text,
        //        Email = txtEmail.Text,
        //        Password = txtPassword.Text,
        //    };

        //    _userBusinessLogic.Create(ref user);
        //}

        //private void btnUpdate_Click(object sender, EventArgs e)
        //{
        //    User user = new User()
        //    {
        //        UserId = Convert.ToUInt32(txtUserId.Text),
        //        Nickname = txtNickname.Text,
        //        Email = txtEmail.Text,
        //        Password = txtPassword.Text
        //    };

        //    _userBusinessLogic.Update(ref user);

        //}

        //private void btnDelete_Click(object sender, EventArgs e)
        //{
        //    User user = new User()
        //    {
        //        UserId = Convert.ToUInt32(txtUserId.Text)
        //    };

        //    _userBusinessLogic.Delete(ref user);

        //}
        //private void btnRead_Click(object sender, EventArgs e)
        //{
        //    User user = new User()
        //    {
        //        UserId = Convert.ToUInt32(txtUserId.Text)
        //    };

        //    _userBusinessLogic.Read(ref user);


        //    if (!_users.Any(u => u.UserId == user.UserId))
        //    {
        //        _users.Add(user);
        //    }

        //}


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

            if (_userBusinessLogic.Login(ref user))
            {
                this.Hide();
                Menu menu = new Menu(ref user);
                menu.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("The account doesn't exist or credentials are incorrect", "Sign in error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
