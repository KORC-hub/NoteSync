namespace Presentation.form
{
    partial class UserRegistration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserRegistration));
            txtNickname = new TextBox();
            txtPassword = new TextBox();
            pictureBox1 = new PictureBox();
            lblAppName = new Label();
            lblLogIn = new Label();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            txtPssword = new TextBox();
            btnLogIn = new Button();
            lblExit = new Label();
            lblCreateAccount = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // txtNickname
            // 
            txtNickname.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtNickname.BackColor = Color.FromArgb(19, 19, 19);
            txtNickname.BorderStyle = BorderStyle.None;
            txtNickname.Cursor = Cursors.IBeam;
            txtNickname.Font = new Font("Segoe UI", 10.8F);
            txtNickname.ForeColor = Color.White;
            txtNickname.Location = new Point(162, 272);
            txtNickname.Margin = new Padding(3, 2, 3, 2);
            txtNickname.MinimumSize = new Size(0, 30);
            txtNickname.Name = "txtNickname";
            txtNickname.Size = new Size(275, 30);
            txtNickname.TabIndex = 4;
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPassword.BackColor = Color.FromArgb(19, 19, 19);
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Cursor = Cursors.IBeam;
            txtPassword.Font = new Font("Segoe UI", 10.8F);
            txtPassword.ForeColor = Color.White;
            txtPassword.Location = new Point(261, 343);
            txtPassword.Margin = new Padding(3, 2, 3, 2);
            txtPassword.MinimumSize = new Size(0, 30);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(0, 30);
            txtPassword.TabIndex = 6;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(111, 35);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(96, 87);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // lblAppName
            // 
            lblAppName.AutoSize = true;
            lblAppName.Font = new Font("Consolas", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAppName.ForeColor = SystemColors.ControlLight;
            lblAppName.Location = new Point(247, 64);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(179, 43);
            lblAppName.TabIndex = 8;
            lblAppName.Text = "NoteSync";
            // 
            // lblLogIn
            // 
            lblLogIn.AutoSize = true;
            lblLogIn.Font = new Font("Consolas", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLogIn.ForeColor = SystemColors.ControlLight;
            lblLogIn.Location = new Point(216, 182);
            lblLogIn.Name = "lblLogIn";
            lblLogIn.Size = new Size(104, 32);
            lblLogIn.TabIndex = 9;
            lblLogIn.Text = "LOG IN";
            lblLogIn.Click += lblLogIn_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(85, 266);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(41, 42);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 10;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(85, 363);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(41, 44);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 11;
            pictureBox3.TabStop = false;
            // 
            // txtPssword
            // 
            txtPssword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPssword.BackColor = Color.FromArgb(19, 19, 19);
            txtPssword.BorderStyle = BorderStyle.None;
            txtPssword.Cursor = Cursors.IBeam;
            txtPssword.Font = new Font("Segoe UI", 10.8F);
            txtPssword.ForeColor = Color.White;
            txtPssword.Location = new Point(162, 370);
            txtPssword.Margin = new Padding(3, 2, 3, 2);
            txtPssword.MinimumSize = new Size(0, 30);
            txtPssword.Name = "txtPssword";
            txtPssword.PasswordChar = '*';
            txtPssword.Size = new Size(275, 30);
            txtPssword.TabIndex = 12;
            txtPssword.UseSystemPasswordChar = true;
            // 
            // btnLogIn
            // 
            btnLogIn.BackColor = Color.DodgerBlue;
            btnLogIn.FlatAppearance.BorderSize = 0;
            btnLogIn.FlatStyle = FlatStyle.Flat;
            btnLogIn.Font = new Font("Consolas", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogIn.ForeColor = SystemColors.ControlLight;
            btnLogIn.Location = new Point(73, 494);
            btnLogIn.Name = "btnLogIn";
            btnLogIn.Size = new Size(378, 47);
            btnLogIn.TabIndex = 13;
            btnLogIn.Text = "LOG IN";
            btnLogIn.UseVisualStyleBackColor = false;
            btnLogIn.Click += btnLogIn_Click;
            // 
            // lblExit
            // 
            lblExit.AutoSize = true;
            lblExit.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblExit.ForeColor = SystemColors.ControlLight;
            lblExit.Location = new Point(240, 567);
            lblExit.Name = "lblExit";
            lblExit.Size = new Size(45, 19);
            lblExit.TabIndex = 14;
            lblExit.Text = "Exit";
            lblExit.Click += lblExit_Click;
            // 
            // lblCreateAccount
            // 
            lblCreateAccount.AutoSize = true;
            lblCreateAccount.Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCreateAccount.ForeColor = SystemColors.ControlLight;
            lblCreateAccount.Location = new Point(262, 465);
            lblCreateAccount.Name = "lblCreateAccount";
            lblCreateAccount.Size = new Size(189, 15);
            lblCreateAccount.TabIndex = 15;
            lblCreateAccount.Text = "Don't have an account yet?";
            // 
            // UserRegistration
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 25);
            ClientSize = new Size(533, 626);
            Controls.Add(lblCreateAccount);
            Controls.Add(lblExit);
            Controls.Add(btnLogIn);
            Controls.Add(txtPssword);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(lblLogIn);
            Controls.Add(lblAppName);
            Controls.Add(pictureBox1);
            Controls.Add(txtPassword);
            Controls.Add(txtNickname);
            Cursor = Cursors.Hand;
            Margin = new Padding(3, 2, 3, 2);
            Name = "UserRegistration";
            Text = "Register";
            Load += UserRegistration_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtNickname;
        private TextBox txtPassword;
        private PictureBox pictureBox1;
        private Label lblAppName;
        private Label lblLogIn;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private TextBox txtPssword;
        private Button btnLogIn;
        private Label lblExit;
        private Label lblCreateAccount;
    }

}