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
            lblTitle = new Label();
            lblNickName = new Label();
            lblEmail = new Label();
            lblPassword = new Label();
            txtNickname = new TextBox();
            txtEmail = new TextBox();
            UserDataGrid = new DataGridView();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            txtUserId = new TextBox();
            lblUserId = new Label();
            btnRead = new Button();
            txtPassword = new TextBox();
            btnLoad = new Button();
            ((System.ComponentModel.ISupportInitialize)UserDataGrid).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(451, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(382, 62);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "User Registration";
            // 
            // lblNickName
            // 
            lblNickName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblNickName.AutoSize = true;
            lblNickName.BackColor = Color.FromArgb(19, 19, 19);
            lblNickName.Font = new Font("Segoe UI", 10.8F);
            lblNickName.ForeColor = Color.White;
            lblNickName.Location = new Point(348, 123);
            lblNickName.Margin = new Padding(0);
            lblNickName.MaximumSize = new Size(0, 30);
            lblNickName.MinimumSize = new Size(110, 30);
            lblNickName.Name = "lblNickName";
            lblNickName.Size = new Size(110, 30);
            lblNickName.TabIndex = 1;
            lblNickName.Text = "Nickname:";
            lblNickName.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblEmail
            // 
            lblEmail.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblEmail.AutoSize = true;
            lblEmail.BackColor = Color.FromArgb(19, 19, 19);
            lblEmail.Font = new Font("Segoe UI", 10.8F);
            lblEmail.ForeColor = Color.White;
            lblEmail.Location = new Point(348, 190);
            lblEmail.Margin = new Padding(0);
            lblEmail.MaximumSize = new Size(80, 0);
            lblEmail.MinimumSize = new Size(80, 30);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(80, 30);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "Email:";
            lblEmail.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblPassword
            // 
            lblPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblPassword.AutoSize = true;
            lblPassword.BackColor = Color.FromArgb(19, 19, 19);
            lblPassword.Font = new Font("Segoe UI", 10.8F);
            lblPassword.ForeColor = Color.White;
            lblPassword.Location = new Point(348, 255);
            lblPassword.Margin = new Padding(0);
            lblPassword.MinimumSize = new Size(107, 30);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(107, 30);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Password:";
            lblPassword.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtNickname
            // 
            txtNickname.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtNickname.BackColor = Color.FromArgb(19, 19, 19);
            txtNickname.BorderStyle = BorderStyle.None;
            txtNickname.Cursor = Cursors.IBeam;
            txtNickname.Font = new Font("Segoe UI", 10.8F);
            txtNickname.ForeColor = Color.White;
            txtNickname.Location = new Point(451, 123);
            txtNickname.MinimumSize = new Size(0, 30);
            txtNickname.Name = "txtNickname";
            txtNickname.Size = new Size(477, 30);
            txtNickname.TabIndex = 4;
            // 
            // txtEmail
            // 
            txtEmail.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtEmail.BackColor = Color.FromArgb(19, 19, 19);
            txtEmail.BorderStyle = BorderStyle.None;
            txtEmail.Cursor = Cursors.IBeam;
            txtEmail.Font = new Font("Segoe UI", 10.8F);
            txtEmail.ForeColor = Color.White;
            txtEmail.Location = new Point(424, 190);
            txtEmail.MinimumSize = new Size(0, 30);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(504, 30);
            txtEmail.TabIndex = 5;
            // 
            // UserDataGrid
            // 
            UserDataGrid.BackgroundColor = Color.FromArgb(25, 25, 25);
            UserDataGrid.BorderStyle = BorderStyle.None;
            UserDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            UserDataGrid.Location = new Point(59, 435);
            UserDataGrid.Name = "UserDataGrid";
            UserDataGrid.RowHeadersWidth = 51;
            UserDataGrid.Size = new Size(1168, 188);
            UserDataGrid.TabIndex = 7;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(243, 178, 175);
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 10.8F);
            btnDelete.Location = new Point(1055, 381);
            btnDelete.Margin = new Padding(0);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(90, 39);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Delete";
            btnDelete.TextAlign = ContentAlignment.TopCenter;
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(162, 175, 248);
            btnUpdate.Cursor = Cursors.Hand;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 10.8F);
            btnUpdate.Location = new Point(952, 381);
            btnUpdate.Margin = new Padding(0);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(93, 39);
            btnUpdate.TabIndex = 9;
            btnUpdate.Text = "Update";
            btnUpdate.TextAlign = ContentAlignment.TopCenter;
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(47, 206, 254);
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAdd.Location = new Point(513, 313);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(267, 39);
            btnAdd.TabIndex = 11;
            btnAdd.Text = "Create Account";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtUserId
            // 
            txtUserId.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtUserId.BackColor = Color.FromArgb(19, 19, 19);
            txtUserId.BorderStyle = BorderStyle.None;
            txtUserId.Cursor = Cursors.IBeam;
            txtUserId.Font = new Font("Segoe UI", 10.8F);
            txtUserId.ForeColor = Color.White;
            txtUserId.Location = new Point(166, 390);
            txtUserId.MinimumSize = new Size(0, 30);
            txtUserId.Name = "txtUserId";
            txtUserId.Size = new Size(107, 30);
            txtUserId.TabIndex = 13;
            // 
            // lblUserId
            // 
            lblUserId.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblUserId.AutoSize = true;
            lblUserId.BackColor = Color.FromArgb(19, 19, 19);
            lblUserId.Font = new Font("Segoe UI", 10.8F);
            lblUserId.ForeColor = Color.White;
            lblUserId.Location = new Point(63, 390);
            lblUserId.Margin = new Padding(0);
            lblUserId.MinimumSize = new Size(107, 30);
            lblUserId.Name = "lblUserId";
            lblUserId.Size = new Size(107, 30);
            lblUserId.TabIndex = 12;
            lblUserId.Text = "User Id:";
            lblUserId.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnRead
            // 
            btnRead.BackColor = Color.FromArgb(249, 215, 172);
            btnRead.Cursor = Cursors.Hand;
            btnRead.FlatStyle = FlatStyle.Flat;
            btnRead.Font = new Font("Segoe UI", 10.8F);
            btnRead.Location = new Point(1154, 381);
            btnRead.Margin = new Padding(0);
            btnRead.Name = "btnRead";
            btnRead.Size = new Size(73, 39);
            btnRead.TabIndex = 14;
            btnRead.Text = "Read";
            btnRead.TextAlign = ContentAlignment.TopCenter;
            btnRead.UseVisualStyleBackColor = false;
            btnRead.Click += btnRead_Click;
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPassword.BackColor = Color.FromArgb(19, 19, 19);
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Cursor = Cursors.IBeam;
            txtPassword.Font = new Font("Segoe UI", 10.8F);
            txtPassword.ForeColor = Color.White;
            txtPassword.Location = new Point(451, 255);
            txtPassword.MinimumSize = new Size(0, 30);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(477, 30);
            txtPassword.TabIndex = 6;
            // 
            // btnLoad
            // 
            btnLoad.BackColor = Color.FromArgb(213, 254, 197);
            btnLoad.Cursor = Cursors.Hand;
            btnLoad.FlatStyle = FlatStyle.Flat;
            btnLoad.Font = new Font("Segoe UI", 10.8F);
            btnLoad.Location = new Point(806, 381);
            btnLoad.Margin = new Padding(0);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(137, 39);
            btnLoad.TabIndex = 15;
            btnLoad.Text = "Load Table";
            btnLoad.TextAlign = ContentAlignment.TopCenter;
            btnLoad.UseVisualStyleBackColor = false;
            btnLoad.Click += btnLoad_Click;
            // 
            // UserRegistration
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 25);
            ClientSize = new Size(1264, 701);
            Controls.Add(btnLoad);
            Controls.Add(btnRead);
            Controls.Add(txtUserId);
            Controls.Add(lblUserId);
            Controls.Add(btnAdd);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(UserDataGrid);
            Controls.Add(txtPassword);
            Controls.Add(txtEmail);
            Controls.Add(txtNickname);
            Controls.Add(lblPassword);
            Controls.Add(lblEmail);
            Controls.Add(lblNickName);
            Controls.Add(lblTitle);
            Cursor = Cursors.Hand;
            Name = "UserRegistration";
            Text = "Register";
            Load += UserRegistration_Load;
            ((System.ComponentModel.ISupportInitialize)UserDataGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblNickName;
        private Label lblEmail;
        private Label lblPassword;
        private TextBox txtNickname;
        private TextBox txtEmail;
        private DataGridView UserDataGrid;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnAdd;
        private TextBox txtUserId;
        private Label lblUserId;
        private Button btnRead;
        private TextBox txtPassword;
        private Button btnLoad;
    }

}