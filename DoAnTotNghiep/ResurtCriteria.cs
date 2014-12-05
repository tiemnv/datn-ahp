using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace DoAnTotNghiep
{
    public partial class Form3 : Form
    {
        
        public Form3()
        {
            InitializeComponent();
        }
       
        public Form3(string button_name, string button_text)
        {
            InitializeComponent();

            string button_text_copy = button_text;
            string button_name_copy = button_name;
             //Show bảng button lên datagrid view gồm các cột button_name, button_space
            string table = button_name_copy +"_Bel_Pl";
            //MessageBox.Show(button_name_copy.ToString());
            string dtg = "dtgButtonBelPl";
            string queryString_get_button = @"SELECT * FROM dbo."+table.ToString()+"";
            //MessageBox.Show(queryString_get_button.ToString());
            this.dtgButtonBelPl.DataSource = ketnoisql.getDatabase(queryString_get_button, table, dtg);



            Label lb_1 = new Label();
            lb_1.Text = "NHÓM";
            lb_1.Location = new System.Drawing.Point(0, 0);
            lb_1.Size = new System.Drawing.Size(150, 30);
            this.panel1.Controls.Add(lb_1);
           
            Label lb_2 = new Label();
            lb_2.Text = "GIÁ TRỊ BEL";
            lb_2.Location = new System.Drawing.Point(200, 0);
            lb_2.Size = new System.Drawing.Size(150, 30);
            this.panel1.Controls.Add(lb_2);
            

            Label lb_3 = new Label();
            lb_3.Text = "GIÁ TRỊ PL";
            lb_3.Location = new System.Drawing.Point(350, 0);
            lb_3.Size = new System.Drawing.Size(150, 30);
            this.panel1.Controls.Add(lb_3);


            Label[] lb = new Label[frmInputData.subsetTextRecusive.Length];


            for (int i = 0; i < frmInputData.subsetTextRecusive.Length; i++)
            {
                
                lb[i] = new Label();
                lb[i].Name = i.ToString();
                lb[i].Text = "Nhóm " + frmInputData.subsetTextRecusive[i];
                lb[i].Location = new System.Drawing.Point(0, i * 30 + 30);
                lb[i].Size = new System.Drawing.Size(150, 30);
                lb[i].BorderStyle = BorderStyle.FixedSingle;
                this.panel1.Controls.Add(lb[i]);
            }

            TextBox[] tb = new TextBox[frmInputData.subsetTextRecusive.Length];
            for (int i = 0; i < frmInputData.subsetTextRecusive.Length; i++)
            {
                tb[i] = new TextBox();
                tb[i].Name = i.ToString();
                try
                {
                    string query_getValue = @"SELECT Bel FROM " + button_name_copy + "_Bel_Pl" + " Where NameSetPhuongAn ='" + frmInputData.subsetButtonRecusive[i] + "'";
                    //MessageBox.Show(query_getValue);
                    tb[i].Text = Convert.ToString(ketnoisql.ExecuteScalar(query_getValue));
                }
                catch (SqlException)
                {

                }
                tb[i].ReadOnly = true;
                tb[i].Location = new System.Drawing.Point(200, i * 30 + 30); ;
                tb[i].Size = new System.Drawing.Size(50, 30);
                this.panel1.Controls.Add(tb[i]);
            }

            TextBox[] tb1 = new TextBox[frmInputData.subsetTextRecusive.Length];
            for (int i = 0; i < frmInputData.subsetTextRecusive.Length; i++)
            {

                tb1[i] = new TextBox();
                tb1[i].Name = i.ToString();
                try
                {
                    string query_getValue = @"SELECT Pl FROM " + button_name_copy + "_Bel_Pl" + " Where NameSetPhuongAn ='" + frmInputData.subsetButtonRecusive[i] + "'";
                    tb1[i].Text = Convert.ToString(ketnoisql.ExecuteScalar(query_getValue));
                }
                catch (SqlException)
                {

                }
                if (tb1[i].Text.ToString() == "") tb[i].Text = "0";
                tb1[i].ReadOnly = true;
                tb1[i].Location = new System.Drawing.Point(350, i * 30 + 30); ;
                tb1[i].Size = new System.Drawing.Size(50, 30);
                this.panel1.Controls.Add(tb1[i]);
            }

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        
        private void buttonOkClick(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
