using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;
using System.Windows.Forms.DataVisualization.Charting;

namespace DoAnTotNghiep
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        //he so bi quan

        double pessimistic = 0.6;
        private void Form4_Load(object sender, EventArgs e)
        {
            textBox1.Text = pessimistic.ToString();
            //Show bảng button lên datagrid view gồm các cột button_name, button_space
            string table = "bt1_Bel_Pl";
            //MessageBox.Show(button_name_copy.ToString());
            string dtg = "dtgButtonBelPl";
            string queryString_get_button = @"SELECT * FROM dbo." + table.ToString() + "";
            //MessageBox.Show(queryString_get_button.ToString());
            this.dtgButtonBelPl.DataSource = ketnoisql.getDatabase(queryString_get_button, table, dtg);
            int rows = dtgButtonBelPl.RowCount - 1;
            //MessageBox.Show(dtgButtonBelPl.Rows[0].Cells[1].Value.ToString());
            //Tạo 1 datagridview gồm tên phần tử + giá trị bi quan
            pessimistic = 0.6;
            chart1.ChartAreas[0].AxisY.Maximum = 1;
            for (int i = 0; i < rows; i++ )
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells[0].Value = dtgButtonBelPl.Rows[i].Cells[1].Value.ToString();
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells[1].Value = (Convert.ToDouble(dtgButtonBelPl.Rows[i].Cells[2].Value) * pessimistic + Convert.ToDouble(dtgButtonBelPl.Rows[i].Cells[3].Value) * (1 - pessimistic)).ToString();
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells[2].Value = InputData.subsetTextRecusive[i];

                    }



            for (int i = 0; i < rows; i++)
            {
                this.chart1.Series["Series1"].Points.AddXY(dataGridView1.Rows[i].Cells[2].Value.ToString(), Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value.ToString()));
            }


            //string queryString_get_button1 = @"SELECT NameSetPhuongAn,Pl FROM dbo." + table.ToString() + "";
            //DataTable dt = new DataTable();
            //dt = ketnoisql.ExecuteDataTable(queryString_get_button1);




            /*
            DataTable dt = new DataTable();
            dt.Columns.Add("col1");
            dt.Columns.Add("col2");
            
            dt = (DataTable)dataGridView1.DataSource;
            
            /*
            DataTable dt = new DataTable();
            DataColumn dc1 = new DataColumn();
            DataColumn dc2 = new DataColumn();
            for (int i = 0; i < rows; i++)
            {
                DataRow dtrow = dt.NewRow();
                //Giả sử DataGridView của mình có 2 cột.
                dtrow[0] = dataGridView1.Rows[i].Cells[0].Value.ToString();
                dtrow[1] = dataGridView1.Rows[i].Cells[1].Value.ToString();
                dt.Rows.Add(dtrow);
            }
            //MessageBox.Show(dt.Columns[0].DefaultValue.ToString());
            
            chart1.DataSource = dt;
            chart1.ChartAreas["ChartArea1"].AxisX.Title = "Nhóm Phương án";
            chart1.ChartAreas["ChartArea1"].AxisY.Title = "Gía trị";

            chart1.Series["Series1"].XValueMember = "col1";
            chart1.Series["Series1"].YValueMembers = "col2";
             */
             
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
           // chart1.Series["Series1"].EmptyPointStyle(null);
            /*
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
             * */
            chart1.Series.Clear();
            Series s = new Series("Series1");
            chart1.Series.Add(s);
            pessimistic = Convert.ToDouble(trackBar1.Value) / 10;
            textBox1.Text = pessimistic.ToString();

            chart1.ChartAreas[0].AxisY.Maximum = 1;
            //Show bảng button lên datagrid view gồm các cột button_name, button_space
            string table = "bt1_Bel_Pl";
            //MessageBox.Show(button_name_copy.ToString());
            string dtg = "dtgButtonBelPl";
            string queryString_get_button = @"SELECT * FROM dbo." + table.ToString() + "";
            //MessageBox.Show(queryString_get_button.ToString());
            this.dtgButtonBelPl.DataSource = ketnoisql.getDatabase(queryString_get_button, table, dtg);
            int rows = dtgButtonBelPl.RowCount - 1;

            //biquan = 0.6;

            for (int i = 0; i < rows; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dtgButtonBelPl.Rows[i].Cells[1].Value.ToString();
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[1].Value = (Convert.ToDouble(dtgButtonBelPl.Rows[i].Cells[2].Value) * pessimistic + Convert.ToDouble(dtgButtonBelPl.Rows[i].Cells[3].Value) * (1 - pessimistic)).ToString();
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[2].Value = InputData.subsetTextRecusive[i];

            }



            for (int i = 0; i < rows; i++)
            {
                this.chart1.Series["Series1"].Points.AddXY(dataGridView1.Rows[i].Cells[2].Value.ToString(), Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value.ToString()));
            }
        }

        private void buttonOkClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
