namespace DoAnTotNghiep
{
    partial class frmSurvey
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSurvey));
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnTieuChi = new System.Windows.Forms.Button();
            this.bindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grvSurvey = new System.Windows.Forms.DataGridView();
            this.surveytargetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dATNDataSet = new DoAnTotNghiep.DATNDataSet();
            this.survey_targetTableAdapter = new DoAnTotNghiep.DATNDataSetTableAdapters.survey_targetTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.evaluatornumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.criterialevelnumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pessimisticargDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator)).BeginInit();
            this.bindingNavigator.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvSurvey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.surveytargetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dATNDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnTieuChi);
            this.panel2.Controls.Add(this.bindingNavigator);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 356);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(799, 75);
            this.panel2.TabIndex = 3;
            // 
            // btnTieuChi
            // 
            this.btnTieuChi.AccessibleDescription = "";
            this.btnTieuChi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTieuChi.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnTieuChi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTieuChi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTieuChi.Location = new System.Drawing.Point(475, 19);
            this.btnTieuChi.Name = "btnTieuChi";
            this.btnTieuChi.Size = new System.Drawing.Size(242, 44);
            this.btnTieuChi.TabIndex = 1;
            this.btnTieuChi.Text = "Quản Lý Tiêu Chí Phương Án";
            this.btnTieuChi.UseVisualStyleBackColor = false;
            this.btnTieuChi.Click += new System.EventHandler(this.btnTieuChi_Click);
            // 
            // bindingNavigator
            // 
            this.bindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigator.BindingSource = this.surveytargetBindingSource;
            this.bindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
            this.bindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator.Name = "bindingNavigator";
            this.bindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator.Size = new System.Drawing.Size(799, 25);
            this.bindingNavigator.TabIndex = 0;
            this.bindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(41, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
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
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(799, 80);
            this.panel1.TabIndex = 2;
            // 
            // grvSurvey
            // 
            this.grvSurvey.AutoGenerateColumns = false;
            this.grvSurvey.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grvSurvey.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvSurvey.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.evaluatornumberDataGridViewTextBoxColumn,
            this.criterialevelnumDataGridViewTextBoxColumn,
            this.pessimisticargDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn});
            this.grvSurvey.DataSource = this.surveytargetBindingSource;
            this.grvSurvey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grvSurvey.Location = new System.Drawing.Point(0, 80);
            this.grvSurvey.Name = "grvSurvey";
            this.grvSurvey.Size = new System.Drawing.Size(799, 276);
            this.grvSurvey.TabIndex = 4;
            this.grvSurvey.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.grvDSMucTieu_CellValidating);
            this.grvSurvey.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.grvDSMucTieu_RowValidated);
            // 
            // surveytargetBindingSource
            // 
            this.surveytargetBindingSource.DataMember = "survey_target";
            this.surveytargetBindingSource.DataSource = this.dATNDataSet;
            // 
            // dATNDataSet
            // 
            this.dATNDataSet.DataSetName = "DATNDataSet";
            this.dATNDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // survey_targetTableAdapter
            // 
            this.survey_targetTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(712, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "CHƯƠNG TRÌNH MÔ PHỎNG THUẬT TOÁN AHP";
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Tên Mục Tiêu";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // evaluatornumberDataGridViewTextBoxColumn
            // 
            this.evaluatornumberDataGridViewTextBoxColumn.DataPropertyName = "evaluator_number";
            this.evaluatornumberDataGridViewTextBoxColumn.HeaderText = "evaluator_number";
            this.evaluatornumberDataGridViewTextBoxColumn.Name = "evaluatornumberDataGridViewTextBoxColumn";
            this.evaluatornumberDataGridViewTextBoxColumn.Visible = false;
            // 
            // criterialevelnumDataGridViewTextBoxColumn
            // 
            this.criterialevelnumDataGridViewTextBoxColumn.DataPropertyName = "criteria_level_num";
            this.criterialevelnumDataGridViewTextBoxColumn.HeaderText = "criteria_level_num";
            this.criterialevelnumDataGridViewTextBoxColumn.Name = "criterialevelnumDataGridViewTextBoxColumn";
            this.criterialevelnumDataGridViewTextBoxColumn.Visible = false;
            // 
            // pessimisticargDataGridViewTextBoxColumn
            // 
            this.pessimisticargDataGridViewTextBoxColumn.DataPropertyName = "pessimistic_arg";
            this.pessimisticargDataGridViewTextBoxColumn.HeaderText = "pessimistic_arg";
            this.pessimisticargDataGridViewTextBoxColumn.Name = "pessimisticargDataGridViewTextBoxColumn";
            this.pessimisticargDataGridViewTextBoxColumn.Visible = false;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Miêu Tả";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            // 
            // frmSurvey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 431);
            this.Controls.Add(this.grvSurvey);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmSurvey";
            this.Text = "Chương trình mô phỏng thuật toán AHP";
            this.Load += new System.EventHandler(this.frmSurvey_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator)).EndInit();
            this.bindingNavigator.ResumeLayout(false);
            this.bindingNavigator.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvSurvey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.surveytargetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dATNDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnTieuChi;
        private System.Windows.Forms.BindingNavigator bindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView grvSurvey;
        private DATNDataSet dATNDataSet;
        private System.Windows.Forms.BindingSource surveytargetBindingSource;
        private DATNDataSetTableAdapters.survey_targetTableAdapter survey_targetTableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn evaluatornumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn criterialevelnumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pessimisticargDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
    }
}