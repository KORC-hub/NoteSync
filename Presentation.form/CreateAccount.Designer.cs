namespace Presentation.form
{
    partial class CreateAccount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateAccount));
            lblAppName = new Label();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            txtNickname = new TextBox();
            lblUserRegistration = new Label();
            txtPassword = new TextBox();
            pictureBox3 = new PictureBox();
            txtConfirmPassword = new TextBox();
            pictureBox4 = new PictureBox();
            pictureBox5 = new PictureBox();
            txtEmailAddress = new TextBox();
            btnCreateAccount = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            SuspendLayout();
            // 
            // lblAppName
            // 
            lblAppName.AutoSize = true;
            lblAppName.Cursor = Cursors.Hand;
            lblAppName.Font = new Font("Consolas", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAppName.ForeColor = SystemColors.ControlLight;
            lblAppName.Location = new Point(239, 56);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(179, 43);
            lblAppName.TabIndex = 10;
            lblAppName.Text = "NoteSync";
            lblAppName.Click += lblAppName_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(125, 35);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(82, 80);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(92, 324);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(41, 42);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 12;
            pictureBox2.TabStop = false;
            // 
            // txtNickname
            // 
            txtNickname.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtNickname.BackColor = Color.FromArgb(19, 19, 19);
            txtNickname.BorderStyle = BorderStyle.None;
            txtNickname.Cursor = Cursors.IBeam;
            txtNickname.Font = new Font("Segoe UI", 10.8F);
            txtNickname.ForeColor = Color.White;
            txtNickname.Location = new Point(165, 259);
            txtNickname.Margin = new Padding(3, 2, 3, 2);
            txtNickname.MaxLength = 15;
            txtNickname.MinimumSize = new Size(0, 30);
            txtNickname.Name = "txtNickname";
            txtNickname.PlaceholderText = "Nickname";
            txtNickname.Size = new Size(275, 30);
            txtNickname.TabIndex = 11;
            // 
            // lblUserRegistration
            // 
            lblUserRegistration.AutoSize = true;
            lblUserRegistration.Font = new Font("Consolas", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUserRegistration.ForeColor = SystemColors.ControlLight;
            lblUserRegistration.Location = new Point(216, 183);
            lblUserRegistration.Name = "lblUserRegistration";
            lblUserRegistration.Size = new Size(119, 32);
            lblUserRegistration.TabIndex = 13;
            lblUserRegistration.Text = "Sign Up";
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPassword.BackColor = Color.FromArgb(19, 19, 19);
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Cursor = Cursors.IBeam;
            txtPassword.Font = new Font("Segoe UI", 10.8F);
            txtPassword.ForeColor = Color.White;
            txtPassword.Location = new Point(165, 412);
            txtPassword.Margin = new Padding(3, 2, 3, 2);
            txtPassword.MinimumSize = new Size(0, 30);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.PlaceholderText = "Password";
            txtPassword.Size = new Size(275, 30);
            txtPassword.TabIndex = 15;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(92, 404);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(41, 44);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 14;
            pictureBox3.TabStop = false;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtConfirmPassword.BackColor = Color.FromArgb(19, 19, 19);
            txtConfirmPassword.BorderStyle = BorderStyle.None;
            txtConfirmPassword.Cursor = Cursors.IBeam;
            txtConfirmPassword.Font = new Font("Segoe UI", 10.8F);
            txtConfirmPassword.ForeColor = Color.White;
            txtConfirmPassword.Location = new Point(165, 487);
            txtConfirmPassword.Margin = new Padding(3, 2, 3, 2);
            txtConfirmPassword.MinimumSize = new Size(0, 30);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '*';
            txtConfirmPassword.PlaceholderText = "Confirm Password";
            txtConfirmPassword.Size = new Size(275, 30);
            txtConfirmPassword.TabIndex = 17;
            txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(92, 478);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(41, 44);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 16;
            pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(92, 252);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(41, 42);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 19;
            pictureBox5.TabStop = false;
            // 
            // txtEmailAddress
            // 
            txtEmailAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtEmailAddress.BackColor = Color.FromArgb(19, 19, 19);
            txtEmailAddress.BorderStyle = BorderStyle.None;
            txtEmailAddress.Cursor = Cursors.IBeam;
            txtEmailAddress.Font = new Font("Segoe UI", 10.8F);
            txtEmailAddress.ForeColor = Color.White;
            txtEmailAddress.Location = new Point(165, 332);
            txtEmailAddress.Margin = new Padding(3, 2, 3, 2);
            txtEmailAddress.MaxLength = 100;
            txtEmailAddress.MinimumSize = new Size(0, 30);
            txtEmailAddress.Name = "txtEmailAddress";
            txtEmailAddress.PlaceholderText = "Email Address";
            txtEmailAddress.Size = new Size(275, 30);
            txtEmailAddress.TabIndex = 18;
            // 
            // btnCreateAccount
            // 
            btnCreateAccount.BackColor = Color.DodgerBlue;
            btnCreateAccount.Cursor = Cursors.Hand;
            btnCreateAccount.FlatAppearance.BorderSize = 0;
            btnCreateAccount.FlatStyle = FlatStyle.Flat;
            btnCreateAccount.Font = new Font("Consolas", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCreateAccount.ForeColor = SystemColors.ControlLight;
            btnCreateAccount.Location = new Point(77, 566);
            btnCreateAccount.Name = "btnCreateAccount";
            btnCreateAccount.Size = new Size(378, 47);
            btnCreateAccount.TabIndex = 20;
            btnCreateAccount.Text = "CREATE ACCOUNT";
            btnCreateAccount.UseVisualStyleBackColor = false;
            btnCreateAccount.Click += btnLogIn_Click;
            // 
            // CreateAccount
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 25);
            ClientSize = new Size(533, 688);
            Controls.Add(btnCreateAccount);
            Controls.Add(pictureBox5);
            Controls.Add(txtEmailAddress);
            Controls.Add(txtConfirmPassword);
            Controls.Add(pictureBox4);
            Controls.Add(txtPassword);
            Controls.Add(pictureBox3);
            Controls.Add(lblUserRegistration);
            Controls.Add(pictureBox2);
            Controls.Add(txtNickname);
            Controls.Add(lblAppName);
            Controls.Add(pictureBox1);
            Name = "CreateAccount";
            Text = "CreateAccount";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblAppName;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private TextBox txtNickname;
        private Label lblUserRegistration;
        private TextBox txtPassword;
        private PictureBox pictureBox3;
        private TextBox txtConfirmPassword;
        private PictureBox pictureBox4;
        private PictureBox pictureBox5;
        private TextBox txtEmailAddress;
        private Button btnCreateAccount;
    }
}