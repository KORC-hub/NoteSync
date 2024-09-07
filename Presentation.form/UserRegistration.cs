﻿using BusinessLogic.core;
using Entities;
using System.ComponentModel;

namespace Presentation.form
{
    public partial class UserRegistration : Form
    {

        #region Private Varieble

        private UserBusinessLogic _userBusinessLogic = new UserBusinessLogic();
        private BindingList<User> _users = new BindingList<User>();

        #endregion

        public UserRegistration()
        {
            InitializeComponent();
            UserDataGrid.DataSource = _users;
        }

        #region Buttons

        private void btnAdd_Click(object sender, EventArgs e)
        {
            User user = new User()
            {
                Nickname = txtNickname.Text,
                Email = txtEmail.Text,
                Password = txtPassword.Text,
            };

            _userBusinessLogic.Create(ref user);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            User user = new User()
            {
                UserId = Convert.ToUInt32(txtUserId.Text),
                Nickname = txtNickname.Text,
                Email = txtEmail.Text,
                Password = txtPassword.Text
            };

            _userBusinessLogic.Update(ref user); 

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            User user = new User()
            {
                UserId = Convert.ToUInt32(txtUserId.Text)
            };

            _userBusinessLogic.Delete(ref user);

        }
        private void btnRead_Click(object sender, EventArgs e)
        {
            User user = new User()
            {
                UserId = Convert.ToUInt32(txtUserId.Text)
            };

            _userBusinessLogic.Read(ref user);


            if (!_users.Any(u => u.UserId == user.UserId))
            {
                _users.Add(user);
            }

        }

        #endregion

    }
}
