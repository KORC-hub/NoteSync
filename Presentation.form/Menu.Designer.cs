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
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            lblSettings = new Label();
            pictureBox1 = new PictureBox();
            lblSignOut = new Label();
            lblWelcome = new Label();
            lblMyFiles = new Label();
            richTextBox1 = new RichTextBox();
            treeView1 = new TreeView();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel1;
            splitContainer1.IsSplitterFixed = true;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = Color.FromArgb(19, 19, 19);
            splitContainer1.Panel1.Controls.Add(panel2);
            splitContainer1.Panel1.Controls.Add(panel1);
            splitContainer1.Panel1.Controls.Add(pictureBox3);
            splitContainer1.Panel1.Controls.Add(pictureBox2);
            splitContainer1.Panel1.Controls.Add(lblSettings);
            splitContainer1.Panel1.Controls.Add(pictureBox1);
            splitContainer1.Panel1.Controls.Add(lblSignOut);
            splitContainer1.Panel1.Controls.Add(lblWelcome);
            splitContainer1.Panel1.Paint += splitContainer1_Panel1_Paint;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(lblMyFiles);
            splitContainer1.Panel2.Controls.Add(richTextBox1);
            splitContainer1.Panel2.Controls.Add(treeView1);
            splitContainer1.Size = new Size(1388, 826);
            splitContainer1.SplitterDistance = 255;
            splitContainer1.TabIndex = 0;
            splitContainer1.SplitterMoved += splitContainer1_SplitterMoved;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlLight;
            panel2.Location = new Point(28, 740);
            panel2.Name = "panel2";
            panel2.Size = new Size(200, 2);
            panel2.TabIndex = 13;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLight;
            panel1.Location = new Point(28, 83);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 2);
            panel1.TabIndex = 12;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(14, 30);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(31, 36);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 11;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(38, 129);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(31, 30);
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
            lblSettings.Location = new Point(83, 131);
            lblSettings.Name = "lblSettings";
            lblSettings.Size = new Size(106, 24);
            lblSettings.TabIndex = 5;
            lblSettings.Text = "Settings";
            lblSettings.Click += lblSettings_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(38, 765);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(31, 30);
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
            lblSignOut.Location = new Point(83, 769);
            lblSignOut.Name = "lblSignOut";
            lblSignOut.Size = new Size(106, 24);
            lblSignOut.TabIndex = 3;
            lblSignOut.Text = "Sign Out";
            lblSignOut.Click += lblSignOut_Click;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Consolas", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWelcome.ForeColor = SystemColors.ControlLight;
            lblWelcome.Location = new Point(59, 37);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(0, 24);
            lblWelcome.TabIndex = 0;
            // 
            // lblMyFiles
            // 
            lblMyFiles.AutoSize = true;
            lblMyFiles.Font = new Font("Consolas", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMyFiles.ForeColor = SystemColors.ControlLight;
            lblMyFiles.Location = new Point(179, 69);
            lblMyFiles.Name = "lblMyFiles";
            lblMyFiles.Size = new Size(106, 24);
            lblMyFiles.TabIndex = 7;
            lblMyFiles.Text = "My Files";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(469, 246);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(600, 432);
            richTextBox1.TabIndex = 2;
            richTextBox1.Text = "";
            // 
            // treeView1
            // 
            treeView1.BackColor = SystemColors.ScrollBar;
            treeView1.Location = new Point(66, 111);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(336, 598);
            treeView1.TabIndex = 1;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 25);
            ClientSize = new Size(1388, 826);
            Controls.Add(splitContainer1);
            Name = "Menu";
            Text = "Menu";
            Load += Menu_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Label lblWelcome;
        private PictureBox pictureBox2;
        private Label lblSettings;
        private PictureBox pictureBox1;
        private Label lblSignOut;
        private RichTextBox richTextBox1;
        private TreeView treeView1;
        private Label lblMyFiles;
        private PictureBox pictureBox3;
        private Panel panel1;
        private Panel panel2;
    }
}