using BusinessLogic.core;
using Entities;

namespace Presentation.form
{
    public partial class UserRegistration : Form
    {

        #region Private Varieble

        private UserBusinessLogic userBusinessLogic = new UserBusinessLogic();

        #endregion

        public UserRegistration()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            User user = new User()
            {
                Nickname = txtNickname.Text,
                Email = txtEmail.Text,
                Password = txtPassword.Text,
                MembershipId = 1
            };

            userBusinessLogic.Create(ref user);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
