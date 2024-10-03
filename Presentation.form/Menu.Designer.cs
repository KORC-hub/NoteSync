namespace Presentation.form
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            splitContainer1 = new SplitContainer();
            panel2 = new Panel();
            panel1 = new Panel();
            pictureBox2 = new PictureBox();
            lblSettings = new Label();
            pictureBox1 = new PictureBox();
            lblSignOut = new Label();
            lblWelcome = new Label();
            btnRead = new Button();
            lbFileId = new Label();
            txtFileId = new TextBox();
            btnCreate = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnLoad = new Button();
            dataGridFile = new DataGridView();
            lblMyFiles = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridFile).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel1;
            splitContainer1.IsSplitterFixed = true;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Margin = new Padding(3, 4, 3, 4);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = Color.FromArgb(19, 19, 19);
            splitContainer1.Panel1.Controls.Add(panel2);
            splitContainer1.Panel1.Controls.Add(panel1);
            splitContainer1.Panel1.Controls.Add(pictureBox2);
            splitContainer1.Panel1.Controls.Add(lblSettings);
            splitContainer1.Panel1.Controls.Add(pictureBox1);
            splitContainer1.Panel1.Controls.Add(lblSignOut);
            splitContainer1.Panel1.Controls.Add(lblWelcome);
            splitContainer1.Panel1.Paint += splitContainer1_Panel1_Paint;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(btnRead);
            splitContainer1.Panel2.Controls.Add(lbFileId);
            splitContainer1.Panel2.Controls.Add(txtFileId);
            splitContainer1.Panel2.Controls.Add(btnCreate);
            splitContainer1.Panel2.Controls.Add(btnUpdate);
            splitContainer1.Panel2.Controls.Add(btnDelete);
            splitContainer1.Panel2.Controls.Add(btnLoad);
            splitContainer1.Panel2.Controls.Add(dataGridFile);
            splitContainer1.Panel2.Controls.Add(lblMyFiles);
            splitContainer1.Size = new Size(1386, 679);
            splitContainer1.SplitterDistance = 291;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlLight;
            panel2.Location = new Point(32, 573);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(229, 3);
            panel2.TabIndex = 13;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLight;
            panel1.Location = new Point(32, 69);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(229, 3);
            panel1.TabIndex = 12;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(32, 90);
            pictureBox2.Margin = new Padding(3, 4, 3, 4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(35, 40);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 6;
            pictureBox2.TabStop = false;
            // 
            // lblSettings
            // 
            lblSettings.AutoSize = true;
            lblSettings.Cursor = Cursors.Hand;
            lblSettings.Font = new Font("Consolas", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSettings.ForeColor = SystemColors.ControlLight;
            lblSettings.Location = new Point(84, 93);
            lblSettings.Name = "lblSettings";
            lblSettings.Size = new Size(134, 32);
            lblSettings.TabIndex = 5;
            lblSettings.Text = "Settings";
            lblSettings.Click += lblSettings_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(43, 606);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(35, 40);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // lblSignOut
            // 
            lblSignOut.AutoSize = true;
            lblSignOut.Cursor = Cursors.Hand;
            lblSignOut.Font = new Font("Consolas", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSignOut.ForeColor = SystemColors.ControlLight;
            lblSignOut.Location = new Point(95, 611);
            lblSignOut.Name = "lblSignOut";
            lblSignOut.Size = new Size(134, 32);
            lblSignOut.TabIndex = 3;
            lblSignOut.Text = "Sign Out";
            lblSignOut.Click += lblSignOut_Click;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Consolas", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWelcome.ForeColor = SystemColors.ControlLight;
            lblWelcome.Location = new Point(32, 26);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(119, 32);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome";
            // 
            // btnRead
            // 
            btnRead.BackColor = Color.DodgerBlue;
            btnRead.Cursor = Cursors.Hand;
            btnRead.FlatAppearance.BorderSize = 0;
            btnRead.FlatStyle = FlatStyle.Flat;
            btnRead.Font = new Font("Consolas", 12.25F, FontStyle.Bold);
            btnRead.ForeColor = SystemColors.ControlLight;
            btnRead.Location = new Point(806, 111);
            btnRead.Margin = new Padding(3, 4, 3, 4);
            btnRead.Name = "btnRead";
            btnRead.Size = new Size(98, 43);
            btnRead.TabIndex = 28;
            btnRead.Text = "Read";
            btnRead.UseVisualStyleBackColor = false;
            btnRead.Click += btnRead_Click;
            // 
            // lbFileId
            // 
            lbFileId.AutoSize = true;
            lbFileId.Cursor = Cursors.Hand;
            lbFileId.Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbFileId.ForeColor = SystemColors.ControlLight;
            lbFileId.Location = new Point(53, 122);
            lbFileId.Name = "lbFileId";
            lbFileId.Size = new Size(72, 20);
            lbFileId.TabIndex = 27;
            lbFileId.Text = "FileId:";
            // 
            // txtFileId
            // 
            txtFileId.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtFileId.BackColor = Color.FromArgb(19, 19, 19);
            txtFileId.BorderStyle = BorderStyle.None;
            txtFileId.Cursor = Cursors.IBeam;
            txtFileId.Font = new Font("Segoe UI", 10.8F);
            txtFileId.ForeColor = Color.White;
            txtFileId.Location = new Point(131, 117);
            txtFileId.MaxLength = 15;
            txtFileId.MinimumSize = new Size(0, 30);
            txtFileId.Name = "txtFileId";
            txtFileId.Size = new Size(156, 30);
            txtFileId.TabIndex = 26;
            // 
            // btnCreate
            // 
            btnCreate.BackColor = Color.DodgerBlue;
            btnCreate.Cursor = Cursors.Hand;
            btnCreate.FlatAppearance.BorderSize = 0;
            btnCreate.FlatStyle = FlatStyle.Flat;
            btnCreate.Font = new Font("Consolas", 12.25F, FontStyle.Bold);
            btnCreate.ForeColor = SystemColors.ControlLight;
            btnCreate.Location = new Point(436, 111);
            btnCreate.Margin = new Padding(3, 4, 3, 4);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(98, 43);
            btnCreate.TabIndex = 25;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = false;
            btnCreate.Click += btnCreate_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.DodgerBlue;
            btnUpdate.Cursor = Cursors.Hand;
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Consolas", 12.25F, FontStyle.Bold);
            btnUpdate.ForeColor = SystemColors.ControlLight;
            btnUpdate.Location = new Point(557, 111);
            btnUpdate.Margin = new Padding(3, 4, 3, 4);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(98, 43);
            btnUpdate.TabIndex = 24;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.DodgerBlue;
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Consolas", 12.25F, FontStyle.Bold);
            btnDelete.ForeColor = SystemColors.ControlLight;
            btnDelete.Location = new Point(682, 111);
            btnDelete.Margin = new Padding(3, 4, 3, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(98, 43);
            btnDelete.TabIndex = 23;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnLoad
            // 
            btnLoad.BackColor = Color.DodgerBlue;
            btnLoad.Cursor = Cursors.Hand;
            btnLoad.FlatAppearance.BorderSize = 0;
            btnLoad.FlatStyle = FlatStyle.Flat;
            btnLoad.Font = new Font("Consolas", 12.25F, FontStyle.Bold);
            btnLoad.ForeColor = SystemColors.ControlLight;
            btnLoad.Location = new Point(933, 111);
            btnLoad.Margin = new Padding(3, 4, 3, 4);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(132, 43);
            btnLoad.TabIndex = 22;
            btnLoad.Text = "Load File";
            btnLoad.UseVisualStyleBackColor = false;
            btnLoad.Click += btnLoad_Click;
            // 
            // dataGridFile
            // 
            dataGridFile.BackgroundColor = Color.FromArgb(25, 25, 25);
            dataGridFile.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridFile.Location = new Point(67, 172);
            dataGridFile.Name = "dataGridFile";
            dataGridFile.RowHeadersWidth = 51;
            dataGridFile.Size = new Size(998, 451);
            dataGridFile.TabIndex = 8;
            // 
            // lblMyFiles
            // 
            lblMyFiles.AutoSize = true;
            lblMyFiles.Font = new Font("Consolas", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMyFiles.ForeColor = SystemColors.ControlLight;
            lblMyFiles.Location = new Point(67, 40);
            lblMyFiles.Name = "lblMyFiles";
            lblMyFiles.Size = new Size(134, 32);
            lblMyFiles.TabIndex = 7;
            lblMyFiles.Text = "My Files";
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 25);
            ClientSize = new Size(1386, 679);
            Controls.Add(splitContainer1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Menu";
            Text = "Menu";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridFile).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Label lblWelcome;
        private PictureBox pictureBox2;
        private Label lblSettings;
        private PictureBox pictureBox1;
        private Label lblSignOut;
        private Label lblMyFiles;
        private Panel panel1;
        private Panel panel2;
        private DataGridView dataGridFile;
        private Button btnLoad;
        private Button btnCreate;
        private Button btnUpdate;
        private Button btnDelete;
        private TextBox txtFileId;
        private Label lbFileId;
        private Button btnRead;
    }
}