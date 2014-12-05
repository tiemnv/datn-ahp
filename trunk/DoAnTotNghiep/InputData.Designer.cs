namespace DoAnTotNghiep
{
    partial class InputData
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
            this.dataGridView_connect = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOk = new System.Windows.Forms.Button();
            this.dtgElement = new System.Windows.Forms.DataGridView();
            this.dgtPl = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_connect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgElement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgtPl)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_connect
            // 
            this.dataGridView_connect.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_connect.Location = new System.Drawing.Point(656, 136);
            this.dataGridView_connect.Name = "dataGridView_connect";
            this.dataGridView_connect.Size = new System.Drawing.Size(159, 186);
            this.dataGridView_connect.TabIndex = 0;
            this.dataGridView_connect.Visible = false;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(37, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(336, 337);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint_1);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(111, 374);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.buttonOkClick);
            // 
            // dtgElement
            // 
            this.dtgElement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgElement.Location = new System.Drawing.Point(527, 38);
            this.dtgElement.Name = "dtgElement";
            this.dtgElement.Size = new System.Drawing.Size(280, 72);
            this.dtgElement.TabIndex = 2;
            this.dtgElement.Visible = false;
            // 
            // dgtPl
            // 
            this.dgtPl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgtPl.Location = new System.Drawing.Point(527, 125);
            this.dgtPl.Name = "dgtPl";
            this.dgtPl.Size = new System.Drawing.Size(73, 171);
            this.dgtPl.TabIndex = 3;
            this.dgtPl.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(222, 374);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonOkClick);
            // 
            // InputData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 435);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView_connect);
            this.Controls.Add(this.dtgElement);
            this.Controls.Add(this.dgtPl);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.panel1);
            this.Name = "InputData";
            this.Text = "Nhập dữ liệu đánh giá";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_connect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgElement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgtPl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_connect;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.DataGridView dtgElement;
        private System.Windows.Forms.DataGridView dgtPl;
        private System.Windows.Forms.Button button1;
    }
}