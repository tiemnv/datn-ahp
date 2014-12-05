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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.panelDrawMain = new System.Windows.Forms.Panel();
            this.dtgButton = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.inputDataMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.analyzeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.taskFinish = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bUTTONBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dATNDataSet = new DoAnTotNghiep.DATNDataSet();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.grvTieuChi = new System.Windows.Forms.DataGridView();
            this.bUTTONTableAdapter = new DoAnTotNghiep.DATNDataSetTableAdapters.BUTTONTableAdapter();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.surveyidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttontextDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonspaceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonlevelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelDrawMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgButton)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator)).BeginInit();
            this.bindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bUTTONBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dATNDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTieuChi)).BeginInit();
            this.SuspendLayout();
            // 
            // panelDrawMain
            // 
            this.panelDrawMain.Controls.Add(this.dtgButton);
            this.panelDrawMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDrawMain.Location = new System.Drawing.Point(3, 16);
            this.panelDrawMain.Name = "panelDrawMain";
            this.panelDrawMain.Size = new System.Drawing.Size(811, 405);
            this.panelDrawMain.TabIndex = 0;
            this.panelDrawMain.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panelDrawMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
            this.panelDrawMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDoubleClick);
            // 
            // dtgButton
            // 
            this.dtgButton.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgButton.Location = new System.Drawing.Point(3, 3);
            this.dtgButton.Name = "dtgButton";
            this.dtgButton.Size = new System.Drawing.Size(10, 10);
            this.dtgButton.TabIndex = 2;
            this.dtgButton.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inputDataMenu,
            this.analyzeMenu,
            this.taskFinish});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(817, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // inputDataMenu
            // 
            this.inputDataMenu.Enabled = false;
            this.inputDataMenu.Name = "inputDataMenu";
            this.inputDataMenu.Size = new System.Drawing.Size(88, 20);
            this.inputDataMenu.Text = "Nhập dữ liệu";
            this.inputDataMenu.Click += new System.EventHandler(this.inputData);
            // 
            // analyzeMenu
            // 
            this.analyzeMenu.Enabled = false;
            this.analyzeMenu.Name = "analyzeMenu";
            this.analyzeMenu.Size = new System.Drawing.Size(70, 20);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panelDrawMain);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(817, 424);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.grvTieuChi);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 249);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(817, 199);
            this.panel1.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bindingNavigator);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 139);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(817, 60);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // bindingNavigator
            // 
            this.bindingNavigator.AddNewItem = null;
            this.bindingNavigator.BindingSource = this.bUTTONBindingSource;
            this.bindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator.DeleteItem = null;
            this.bindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.bindingNavigator.Location = new System.Drawing.Point(3, 16);
            this.bindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator.Name = "bindingNavigator";
            this.bindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator.Size = new System.Drawing.Size(811, 25);
            this.bindingNavigator.TabIndex = 0;
            this.bindingNavigator.Text = "bindingNavigator1";
            // 
            // bUTTONBindingSource
            // 
            this.bUTTONBindingSource.DataMember = "BUTTON";
            this.bUTTONBindingSource.DataSource = this.dATNDataSet;
            // 
            // dATNDataSet
            // 
            this.dATNDataSet.DataSetName = "DATNDataSet";
            this.dATNDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(41, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 22);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // grvTieuChi
            // 
            this.grvTieuChi.AllowUserToAddRows = false;
            this.grvTieuChi.AutoGenerateColumns = false;
            this.grvTieuChi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grvTieuChi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvTieuChi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.surveyidDataGridViewTextBoxColumn,
            this.buttonnameDataGridViewTextBoxColumn,
            this.buttonidDataGridViewTextBoxColumn,
            this.buttontextDataGridViewTextBoxColumn,
            this.buttonspaceDataGridViewTextBoxColumn,
            this.buttonlevelDataGridViewTextBoxColumn});
            this.grvTieuChi.DataSource = this.bUTTONBindingSource;
            this.grvTieuChi.Dock = System.Windows.Forms.DockStyle.Top;
            this.grvTieuChi.Location = new System.Drawing.Point(0, 0);
            this.grvTieuChi.Name = "grvTieuChi";
            this.grvTieuChi.Size = new System.Drawing.Size(817, 140);
            this.grvTieuChi.TabIndex = 0;
            this.grvTieuChi.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grvCriteria_CellValueChanged);
            this.grvTieuChi.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.grvCriteria_RowsAdded);
            this.grvTieuChi.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.grvCriteria_RowsRemoved);
            this.grvTieuChi.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.grvTieuChi_RowValidated);
            this.grvTieuChi.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.grvCriteria_UserDeletingRow);
            // 
            // bUTTONTableAdapter
            // 
            this.bUTTONTableAdapter.ClearBeforeFill = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Mã Tiêu Chí Phương Án";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // surveyidDataGridViewTextBoxColumn
            // 
            this.surveyidDataGridViewTextBoxColumn.DataPropertyName = "survey_id";
            this.surveyidDataGridViewTextBoxColumn.HeaderText = "survey_id";
            this.surveyidDataGridViewTextBoxColumn.Name = "surveyidDataGridViewTextBoxColumn";
            this.surveyidDataGridViewTextBoxColumn.Visible = false;
            // 
            // buttonnameDataGridViewTextBoxColumn
            // 
            this.buttonnameDataGridViewTextBoxColumn.DataPropertyName = "button_name";
            this.buttonnameDataGridViewTextBoxColumn.HeaderText = "button_name";
            this.buttonnameDataGridViewTextBoxColumn.Name = "buttonnameDataGridViewTextBoxColumn";
            this.buttonnameDataGridViewTextBoxColumn.Visible = false;
            // 
            // buttonidDataGridViewTextBoxColumn
            // 
            this.buttonidDataGridViewTextBoxColumn.DataPropertyName = "button_id";
            this.buttonidDataGridViewTextBoxColumn.HeaderText = "button_id";
            this.buttonidDataGridViewTextBoxColumn.Name = "buttonidDataGridViewTextBoxColumn";
            this.buttonidDataGridViewTextBoxColumn.Visible = false;
            // 
            // buttontextDataGridViewTextBoxColumn
            // 
            this.buttontextDataGridViewTextBoxColumn.DataPropertyName = "button_text";
            this.buttontextDataGridViewTextBoxColumn.HeaderText = "Tên Tiêu Chí Phương Án";
            this.buttontextDataGridViewTextBoxColumn.Name = "buttontextDataGridViewTextBoxColumn";
            // 
            // buttonspaceDataGridViewTextBoxColumn
            // 
            this.buttonspaceDataGridViewTextBoxColumn.DataPropertyName = "button_space";
            this.buttonspaceDataGridViewTextBoxColumn.HeaderText = "Phân Vùng";
            this.buttonspaceDataGridViewTextBoxColumn.Name = "buttonspaceDataGridViewTextBoxColumn";
            this.buttonspaceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // buttonlevelDataGridViewTextBoxColumn
            // 
            this.buttonlevelDataGridViewTextBoxColumn.DataPropertyName = "button_level";
            this.buttonlevelDataGridViewTextBoxColumn.HeaderText = "Cấp Độ";
            this.buttonlevelDataGridViewTextBoxColumn.Name = "buttonlevelDataGridViewTextBoxColumn";
            this.buttonlevelDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(817, 448);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Mô hình quyết định";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelDrawMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgButton)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator)).EndInit();
            this.bindingNavigator.ResumeLayout(false);
            this.bindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bUTTONBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dATNDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTieuChi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelDrawMain;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem inputDataMenu;
        private System.Windows.Forms.ToolStripMenuItem analyzeMenu;
        private System.Windows.Forms.DataGridView dtgButton;
        private System.Windows.Forms.ToolStripMenuItem taskFinish;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView grvTieuChi;
        private DATNDataSet dATNDataSet;
        private System.Windows.Forms.BindingSource bUTTONBindingSource;
        private DATNDataSetTableAdapters.BUTTONTableAdapter bUTTONTableAdapter;
        private System.Windows.Forms.BindingNavigator bindingNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn surveyidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn buttonnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn buttonidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn buttontextDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn buttonspaceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn buttonlevelDataGridViewTextBoxColumn;
    }
}