﻿namespace Presentation.form
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            lblEditProfile = new Label();
            lblNickname = new Label();
            txtNickname = new TextBox();
            txtPassword = new TextBox();
            txtEmail = new TextBox();
            txtCreationDate = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            pictureBox2 = new PictureBox();
            btnUpdate = new Button();
            btnDeleteAccount = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // lblEditProfile
            // 
            lblEditProfile.AutoSize = true;
            lblEditProfile.Font = new Font("Consolas", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEditProfile.ForeColor = SystemColors.ControlLight;
            lblEditProfile.Location = new Point(301, 40);
            lblEditProfile.Name = "lblEditProfile";
            lblEditProfile.Size = new Size(259, 43);
            lblEditProfile.TabIndex = 0;
            lblEditProfile.Text = "Edit Profile";
            // 
            // lblNickname
            // 
            lblNickname.AutoSize = true;
            lblNickname.Font = new Font("Consolas", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNickname.ForeColor = SystemColors.ControlLight;
            lblNickname.Location = new Point(55, 183);
            lblNickname.Name = "lblNickname";
            lblNickname.Size = new Size(116, 28);
            lblNickname.TabIndex = 1;
            lblNickname.Text = "Nickname";
            // 
            // txtNickname
            // 
            txtNickname.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtNickname.BackColor = Color.FromArgb(19, 19, 19);
            txtNickname.BorderStyle = BorderStyle.None;
            txtNickname.Cursor = Cursors.IBeam;
            txtNickname.Font = new Font("Segoe UI", 10.8F);
            txtNickname.ForeColor = Color.White;
            txtNickname.Location = new Point(55, 225);
            txtNickname.MaxLength = 15;
            txtNickname.MinimumSize = new Size(0, 30);
            txtNickname.Name = "txtNickname";
            txtNickname.Size = new Size(278, 24);
            txtNickname.TabIndex = 12;
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPassword.BackColor = Color.FromArgb(19, 19, 19);
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Cursor = Cursors.IBeam;
            txtPassword.Font = new Font("Segoe UI", 10.8F);
            txtPassword.ForeColor = Color.White;
            txtPassword.Location = new Point(55, 392);
            txtPassword.MaxLength = 15;
            txtPassword.MinimumSize = new Size(0, 30);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(278, 24);
            txtPassword.TabIndex = 14;
            // 
            // txtEmail
            // 
            txtEmail.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtEmail.BackColor = Color.FromArgb(19, 19, 19);
            txtEmail.BorderStyle = BorderStyle.None;
            txtEmail.Cursor = Cursors.IBeam;
            txtEmail.Font = new Font("Segoe UI", 10.8F);
            txtEmail.ForeColor = Color.White;
            txtEmail.Location = new Point(418, 225);
            txtEmail.MaxLength = 100;
            txtEmail.MinimumSize = new Size(0, 30);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(278, 24);
            txtEmail.TabIndex = 15;
            // 
            // txtCreationDate
            // 
            txtCreationDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCreationDate.BackColor = Color.FromArgb(19, 19, 19);
            txtCreationDate.BorderStyle = BorderStyle.None;
            txtCreationDate.Cursor = Cursors.IBeam;
            txtCreationDate.Font = new Font("Segoe UI", 10.8F);
            txtCreationDate.ForeColor = Color.White;
            txtCreationDate.Location = new Point(418, 392);
            txtCreationDate.MaxLength = 15;
            txtCreationDate.MinimumSize = new Size(0, 30);
            txtCreationDate.Name = "txtCreationDate";
            txtCreationDate.Size = new Size(278, 24);
            txtCreationDate.TabIndex = 16;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Consolas", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLight;
            label1.Location = new Point(418, 183);
            label1.Name = "label1";
            label1.Size = new Size(181, 28);
            label1.TabIndex = 17;
            label1.Text = "Email Address";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Consolas", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ControlLight;
            label2.Location = new Point(55, 351);
            label2.Name = "label2";
            label2.Size = new Size(116, 28);
            label2.TabIndex = 18;
            label2.Text = "Password";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Consolas", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ControlLight;
            label3.Location = new Point(418, 351);
            label3.Name = "label3";
            label3.Size = new Size(181, 28);
            label3.TabIndex = 19;
            label3.Text = "Creation Date";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(240, 37);
            pictureBox2.Margin = new Padding(3, 4, 3, 4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(46, 52);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 20;
            pictureBox2.TabStop = false;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.DodgerBlue;
            btnUpdate.Cursor = Cursors.Hand;
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Consolas", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdate.ForeColor = SystemColors.ControlLight;
            btnUpdate.Location = new Point(142, 511);
            btnUpdate.Margin = new Padding(3, 4, 3, 4);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(217, 43);
            btnUpdate.TabIndex = 21;
            btnUpdate.Text = "Update and Exit";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDeleteAccount
            // 
            btnDeleteAccount.BackColor = Color.Brown;
            btnDeleteAccount.Cursor = Cursors.Hand;
            btnDeleteAccount.FlatAppearance.BorderSize = 0;
            btnDeleteAccount.FlatStyle = FlatStyle.Flat;
            btnDeleteAccount.Font = new Font("Consolas", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDeleteAccount.ForeColor = SystemColors.ControlLight;
            btnDeleteAccount.Location = new Point(392, 511);
            btnDeleteAccount.Margin = new Padding(3, 4, 3, 4);
            btnDeleteAccount.Name = "btnDeleteAccount";
            btnDeleteAccount.Size = new Size(221, 43);
            btnDeleteAccount.TabIndex = 22;
            btnDeleteAccount.Text = "Delete Account";
            btnDeleteAccount.UseVisualStyleBackColor = false;
            btnDeleteAccount.Click += btnDeleteAccount_Click;
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 25);
            ClientSize = new Size(760, 599);
            Controls.Add(btnDeleteAccount);
            Controls.Add(btnUpdate);
            Controls.Add(pictureBox2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtCreationDate);
            Controls.Add(txtEmail);
            Controls.Add(txtPassword);
            Controls.Add(txtNickname);
            Controls.Add(lblNickname);
            Controls.Add(lblEditProfile);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Settings";
            Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblEditProfile;
        private Label lblNickname;
        private TextBox txtNickname;
        private TextBox txtPassword;
        private TextBox txtEmail;
        private TextBox txtCreationDate;
        private Label label1;
        private Label label2;
        private Label label3;
        private PictureBox pictureBox2;
        private Button btnUpdate;
        private Button btnDeleteAccount;
    }
}