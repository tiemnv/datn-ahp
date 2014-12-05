namespace DoAnTotNghiep
{
    partial class Main
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.vẽCâyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inputDataMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.analyzeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.taskFinish = new System.Windows.Forms.ToolStripMenuItem();
            this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dtgButton = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgButton)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(406, 266);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
            this.panel1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDoubleClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vẽCâyToolStripMenuItem,
            this.inputDataMenu,
            this.analyzeMenu,
            this.taskFinish,
            this.thoátToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(683, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // vẽCâyToolStripMenuItem
            // 
            this.vẽCâyToolStripMenuItem.Name = "vẽCâyToolStripMenuItem";
            this.vẽCâyToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.vẽCâyToolStripMenuItem.Text = "Mô hình mới";
            this.vẽCâyToolStripMenuItem.Click += new System.EventHandler(this.newWindow);
            // 
            // inputDataMenu
            // 
            this.inputDataMenu.Enabled = false;
            this.inputDataMenu.Name = "inputDataMenu";
            this.inputDataMenu.Size = new System.Drawing.Size(87, 20);
            this.inputDataMenu.Text = "Nhập dữ liệu";
            this.inputDataMenu.Click += new System.EventHandler(this.inputData);
            // 
            // analyzeMenu
            // 
            this.analyzeMenu.Enabled = false;
            this.analyzeMenu.Name = "analyzeMenu";
            this.analyzeMenu.Size = new System.Drawing.Size(69, 20);
            this.analyzeMenu.Text = "Phân tích";
            this.analyzeMenu.Click += new System.EventHandler(this.anazyle);
            // 
            // taskFinish
            // 
            this.taskFinish.Name = "taskFinish";
            this.taskFinish.Size = new System.Drawing.Size(35, 20);
            this.taskFinish.Text = "OK";
            this.taskFinish.Click += new System.EventHandler(this.taskFinishClick);
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.thoátToolStripMenuItem.Text = "Thoát";
            this.thoátToolStripMenuItem.Click += new System.EventHandler(this.exit);
            // 
            // dtgButton
            // 
            this.dtgButton.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgButton.Location = new System.Drawing.Point(412, 27);
            this.dtgButton.Name = "dtgButton";
            this.dtgButton.Size = new System.Drawing.Size(271, 119);
            this.dtgButton.TabIndex = 2;
            this.dtgButton.Visible = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(680, 437);
            this.Controls.Add(this.dtgButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Mô hình quyết định";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem vẽCâyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inputDataMenu;
        private System.Windows.Forms.ToolStripMenuItem analyzeMenu;
        private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem;
        private System.Windows.Forms.DataGridView dtgButton;
        private System.Windows.Forms.ToolStripMenuItem taskFinish;
    }
}