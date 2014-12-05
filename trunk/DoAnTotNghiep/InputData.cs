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


    public partial class InputData : Form
    {

        public InputData()
        {
            InitializeComponent();
        }
        //Khai báo biến toàn cục
        string getNameButtonReceive = null;
        string getTextButtonReceive = null;
        string[] setButtonLowLevel = null;
        //string[] subset_button = null;
        public static string[] subsetTextRecusive = null;
        public static string[] subsetButtonRecusive = null;
        TextBox[] textboxInput = new TextBox[100];
        //tạo 1 mảng a int để đánh dấu và số k để trỏ tới từng phần tử khi trả về tập cuối
        int[] indexRecusive = new int[100];
        int[] indexElementPlanSet = new int[1] { 0 };

        public InputData(string button_name, string button_text)
        {
            InitializeComponent();

            string button_text_connect = button_text;
            string button_name_connect = button_name;

            getNameButtonReceive = button_name;
            getTextButtonReceive = button_text;
            //Hiện tất cả các kết nối của button truyền sang
            string table = "CONNECT";
            string dtg = "dataGridView_connect";

            string queryString_get_connect = @"SELECT DISTINCT dbo.BUTTON.button_id, dbo.CONNECT.connect_button_highLevel,dbo.CONNECT.connect_button_lowLevel, dbo.BUTTON.button_name, dbo.BUTTON.button_text FROM dbo.CONNECT JOIN dbo.BUTTON ON dbo.CONNECT.connect_button_lowLevel = dbo.BUTTON.button_name WHERE(connect_button_highLevel = N'" + button_name_connect + "')";
            this.dataGridView_connect.DataSource = ketnoisql.getDatabase(queryString_get_connect, table, dtg);

            setButtonLowLevel = new string[dataGridView_connect.Rows.Count - 1];
            for (int i = 0; i < dataGridView_connect.Rows.Count - 1; i++)
            {
                setButtonLowLevel[i] = dataGridView_connect.Rows[i].Cells["button_name"].Value.ToString();
            }
            //sắp xếp mảng button_id theo thấp lên cao

            int n = setButtonLowLevel.Length;
            int m = (int)Math.Pow(2, n);
            //Tạo và gán nội dung cho mảng subset_button = 7 phần tử
            subsetButtonRecusive = new string[m - 1];
            subsetTextRecusive = new string[m - 1];
            

            //hàm đệ qui đưa vào 
            //m = số phần tử subset, a= tập , 2 mag, k= phần tử đếm không phụ thuộc
            recursiveGetSetElementToCreateDB(1, indexRecusive, setButtonLowLevel, subsetButtonRecusive, subsetTextRecusive, indexElementPlanSet);

            //add SQL
            try
            {
                string queryString_addTableSubset = @"CREATE TABLE " + button_name_connect + " (Id nvarchar(10) NOT NULL PRIMARY KEY(Id), NameSubSet nvarchar(50)NOT NULL, Value nvarchar(50) NULL, mBPA nvarchar(50), Bel nvarchar(50) NULL, Pl nvarchar(50) NULL)";
                ketnoisql.ExecuteNonQuery(queryString_addTableSubset);
                //bảng này cần xóa
                Main.arrayTableToDelete.Add(button_name_connect);
            }
            catch (SqlException)// Nếu đã có rồi
            {
                //MessageBox.Show("có rồi");
            }
        }

        //Hàm đệ quy
        private void recursiveGetSetElementToCreateDB(int u, int[] a, string[] set_button_lowLevel, string[] subset_button, string[] subset_text, int[] k)
        {
            // ta có u = 1, k = 0
            int n = Convert.ToInt32(this.setButtonLowLevel.Length);
            if (u == n + 1) //ngắt khi có dấu hiệu u = n+1 = 4
            {
                //gọi hàm lấy giá trị
                getSetElementToCreateDB(a, set_button_lowLevel, subset_button, subset_text, k);
                return;
            }
            // nhánh sai
            a[u - 1] = 0;
            recursiveGetSetElementToCreateDB(u + 1, a, set_button_lowLevel, subset_button, subset_text, k);
            // nhánh đúng
            a[u - 1] = 1;
            recursiveGetSetElementToCreateDB(u + 1, a, set_button_lowLevel, subset_button, subset_text, k);

        }
        //Hàm tạo phần tử
        private void getSetElementToCreateDB(int[] a, string[] set_button_lowLevel, string[] subset_button, string[] subset_text, int[] k)
        {
            int n = Convert.ToInt32(this.setButtonLowLevel.Length); ;
            int q = Convert.ToInt32(k[0]);
            int danh_dau = 0;
            string NameTableSubsetElement;
            //lấy tên bảng 
            for (int i = 0; i < n; i++)
                if (a[i] != 0)  //nếu a[i] = 1 thì ghi dữ liệu vào mảng subset_button[k]
                {
                    subset_button[q] = subset_button[q] + set_button_lowLevel[i];
                    danh_dau = 1;
                }
            //Tạo bảng chứa các phần tử của tập subset
            if (subset_button[q] != null)
            {

                try
                {
                    string queryString_addTableSubsetElement = @"CREATE TABLE " + (getNameButtonReceive + "_" + subset_button[q]) + " (Id nvarchar(10) NOT NULL PRIMARY KEY(Id), NameSubsetElement nvarchar(50)NOT NULL)";
                    ketnoisql.ExecuteNonQuery(queryString_addTableSubsetElement);

                    //bảng này cũng cần xóa
                    Main.arrayTableToDelete.Add(getNameButtonReceive + "_" + subset_button[q]);
                }
                catch (SqlException)//Nếu đã có bảng này rồi
                {

                }

                //lưu giữ tên
                NameTableSubsetElement = subset_button[q];
                //xóa đi mảng 
                subset_button[q] = null;
                int id_tangdan_subsetElement = 1;
                int dem = 0;
                for (int i = 0; i < n; i++)
                    if (a[i] != 0)  //nếu a[i] = 1 thì ghi dữ liệu vào mảng subset_button[k]
                    {
                        dem++;
                        subset_button[q] = subset_button[q] + set_button_lowLevel[i];

                        try
                        {
                            string queryString_getText = @"SELECT button_text FROM BUTTON Where BUTTON.button_name='"+set_button_lowLevel[i]+"'";
                            
                            ketnoisql.ExecuteNonQuery(queryString_getText);

                            string getText = Convert.ToString(ketnoisql.ExecuteScalar(queryString_getText));
                            //MessageBox.Show(getText.ToString());
                            if (dem == 1) subset_text[q] = getText;
                            else subset_text[q] = subset_text[q] + " và " + getText;
                            //MessageBox.Show(subset_text[q]);
                        }
                        catch (SqlException)
                        {
                            MessageBox.Show("Sai text");
                        }

                        
                        try
                        {
                            string queryString_addValueSubsetElement = @"INSERT into " + (getNameButtonReceive + "_" + NameTableSubsetElement) + " (Id, NameSubsetElement) values('" + id_tangdan_subsetElement.ToString() + "','" + set_button_lowLevel[i] + "')";
                            //MessageBox.Show(queryString_addValueSubsetElement);
                            ketnoisql.ExecuteNonQuery(queryString_addValueSubsetElement);
                        }
                        catch (SqlException)
                        {
                            
                        }
                        id_tangdan_subsetElement++;
                        //MessageBox.Show(id_tangdan_subsetElement.ToString());
                        danh_dau = 1;
                    }
            }
            if (danh_dau == 1) k[0] = Convert.ToInt32(k[0]) + 1;


        }


      
        private void Form2_Load(object sender, EventArgs e)
        {
            //tạo trên panel các label và 
            Label[] lb = new Label[subsetTextRecusive.Length];

            for (int i = 0; i < subsetTextRecusive.Length; i++)
            {

                lb[i] = new Label();
                lb[i].Name = i.ToString();
                lb[i].Text = "Nhóm " + subsetTextRecusive[i];
                lb[i].Location = new System.Drawing.Point(0, i * 30);
                lb[i].Size = new System.Drawing.Size(150, 30);
                lb[i].BorderStyle = BorderStyle.FixedSingle;
                this.panel1.Controls.Add(lb[i]);
            }
            //TextBox[] tb = new TextBox[subset_text.Length];
            for (int i = 0; i < subsetButtonRecusive.Length; i++)
            {
                textboxInput[i] = new TextBox();
                textboxInput[i].Name = i.ToString();
                try
                {
                    string query_getValue = @"SELECT Value FROM " + getNameButtonReceive + " Where NameSubSet ='" + subsetButtonRecusive[i] + "'";
                    textboxInput[i].Text = Convert.ToString(ketnoisql.ExecuteScalar(query_getValue));
                }
                catch (SqlException)
                {

                }
                if (textboxInput[i].Text.ToString() == "") textboxInput[i].Text = "0";
                textboxInput[i].Location = new System.Drawing.Point(250, i * 30); ;
                textboxInput[i].Size = new System.Drawing.Size(50, 30);
                this.panel1.Controls.Add(textboxInput[i]);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        

        //kiem tra trung lap
        private bool test(string resurt, ArrayList resurtPl)
        {
            string obj1 = resurt;
            for (int s = 0; s < resurtPl.Count; s++)
            {
                
                string obj2 = resurtPl[s].ToString();
               if(obj2.Equals(obj1)) return true;// nếu đúng là đã có thì trả về true
            }
            return false;
        }

        private void recursiveGetSubSet(int u, int[] a, string[] Element, string[] subsetElement, int[] k)
        {
            // ta có u = 1, k = 0

            int n = Convert.ToInt32(Element.Length);
            if (u == n + 1) //ngắt khi có dấu hiệu u = n+1 = 4
            {
                //gọi hàm lấy giá trị
                getElementSubSet(a, Element, subsetElement, k);
                return;
            }
            // nhánh sai
            a[u - 1] = 0;
            recursiveGetSubSet(u + 1, a, Element, subsetElement, k);
            // nhánh đúng
            a[u - 1] = 1;
            recursiveGetSubSet(u + 1, a, Element, subsetElement, k);

        }


        //Hàm tạo phần tử
        private void getElementSubSet(int[] a, string[] Element, string[] subsetElement, int[] k)
        {

            int n = Convert.ToInt32(Element.Length); ;
            int q = Convert.ToInt32(k[0]);

            int danh_dau = 0;

            //xóa đi mảng 

            for (int i = 0; i < n; i++)

                if (a[i] != 0)  //nếu a[i] = 1 thì ghi dữ liệu vào mảng subset_button[k]
                {
                    subsetElement[q] = subsetElement[q] + Element[i];
                    danh_dau = 1;
                }
            if (danh_dau == 1)
            {
                k[0] = Convert.ToInt32(k[0]) + 1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOkClick(object sender, EventArgs e)
        {

            //Tính tổng số lượng chuyên gia tham gia


            for (int i = 0; i < subsetButtonRecusive.Length; i++)
            {

                try
                {
                    string queryString_addValue = @"INSERT into " + getNameButtonReceive + " (Id, NameSubSet, Value, mBPA) values('" + (i + 1).ToString() + "','" + subsetButtonRecusive[i] + "','" + this.textboxInput[i].Text + "','" + (Convert.ToDouble(this.textboxInput[i].Text) / Convert.ToInt32(Main.totalExperts)).ToString() + "')";
                    //MessageBox.Show(queryString_addValue);
                    ketnoisql.ExecuteNonQuery(queryString_addValue);
                }
                catch (SqlException)
                {
                    // MessageBox.Show("update này ");

                    string queryString_addValue = @"UPDATE dbo." + getNameButtonReceive + " SET Value = N'" + textboxInput[i].Text + "', mBPA = N'" + (Convert.ToDouble(this.textboxInput[i].Text) / Convert.ToInt32(Main.totalExperts)).ToString() + "' WHERE  NameSubSet=N'" + subsetButtonRecusive[i] + "'";
                    //MessageBox.Show(queryString_addValue);
                    ketnoisql.ExecuteNonQuery(queryString_addValue);

                }
            }

            // Tính giá trị Bel và Pl cho từng cấp tiêu chí

            for (int i = 0; i < subsetButtonRecusive.Length; i++)
            {
                //MessageBox.Show("Lần "+i.ToString());
                //Gán giá trị từng phần tử subset_button vào 1 hàm


                string table = (getNameButtonReceive + "_" + subsetButtonRecusive[i]);
                //MessageBox.Show("table = "+table);
                string dtg = "dtgElement";
                try
                {
                    string queryString_get_elementSubset = @"SELECT dbo." + table + ".* From dbo." + table + "";
                    //MessageBox.Show("queryString_get_elementSubset = " + queryString_get_elementSubset);
                    this.dtgElement.DataSource = ketnoisql.getDatabase(queryString_get_elementSubset, table, dtg);
                }
                catch (SqlException)
                {
                    MessageBox.Show("Sai chỗ lấy phần tử tập element để bỏ vào datagridview");
                }

                string[] Element = new string[dtgElement.Rows.Count - 1];

                //MessageBox.Show((dtgElement.Rows.Count - 1).ToString());


                for (int j = 0; j < dtgElement.Rows.Count - 1; j++)
                {
                    Element[j] = dtgElement.Rows[j].Cells["NameSubsetElement"].Value.ToString();
                }

                int n = Element.Length;

                //------------------------------------------------------------------------------------------------------------------------------------------------------


                //Tính giá trị Bel cho từng tập con
                double bel = 0;
                //Tạo và gán nội dung cho mảng subset_button = 7 phần tử

                int m = (int)Math.Pow(2, n);
                string[] subsetElement = new string[m - 1];
                for (int j = 0; j < m - 1; j++)
                {
                    subsetElement[j] = "";
                }
                indexElementPlanSet[0] = 0;
                //gọi hàm đệ quy, sau đó add Bel vào SQL

                recursiveGetSubSet(1, indexRecusive, Element, subsetElement, indexElementPlanSet);
                //sau khi gọi ta có mảng các phần tử 
                //MessageBox.Show("Kiểm tra tập các phần tử của subElement");

                for (int j = 0; j < m - 1; j++)
                {


                    string queryString_get_mBPA = @"Select dbo." + getNameButtonReceive + ".mBPA From dbo." + getNameButtonReceive + " Where dbo." + getNameButtonReceive + ".NameSubSet = '" + subsetElement[j].ToString() + "'";
                    //MessageBox.Show(queryString_get_mBPA);
                    string mBPA = (string)ketnoisql.ExecuteScalar(queryString_get_mBPA);


                    bel = bel + Convert.ToDouble(mBPA);
                    //MessageBox.Show("subsetElement["+j.ToString()+"] "+subsetElement[j]);
                }

                //MessageBox.Show("Bel kết quả  = " + bel.ToString());

                try
                {
                    string queryString_add_bel = @"update dbo." + getNameButtonReceive + " Set dbo." + getNameButtonReceive + ".Bel = N'" + bel.ToString() + "' Where dbo." + getNameButtonReceive + ".NameSubSet = N'" + subsetButtonRecusive[i] + "'";
                    //MessageBox.Show(queryString_add_bel);
                    ketnoisql.ExecuteNonQuery(queryString_add_bel);
                }
                catch (SqlException)
                {
                    MessageBox.Show("Sai chỗ add vào SQL bel");
                }
                //Xóa bel để tính tiếp tập khác

                bel = 0;


                //------------------------------------------------------------------------------------------------------------------------------------------------------


                //Tính giá trị Pl cho từng tập con
                double pl = 0;
                ArrayList resurtPl = new ArrayList();
                /*
                for (int j = 0; j < n; j++)
                {
                    MessageBox.Show("Element[" + j.ToString() + "] = " + Element[j]);
                }
                 */

                for (int j = 0; j < n; j++)
                {

                    //fill lên bảng dgtPl với những giá trị like element[j]
                    string table_1 = getNameButtonReceive;
                    string dtg_1 = "dtgPl";
                    try
                    {
                        string queryString_get_elementSubset = @"SELECT dbo." + table_1 + ".* From dbo." + table_1 + " Where dbo." + table_1 + ".NameSubSet LIKE N'%" + Element[j] + "%'";
                        //MessageBox.Show("queryString_get_elementSubset = " + queryString_get_elementSubset);
                        this.dgtPl.DataSource = ketnoisql.getDatabase(queryString_get_elementSubset, table_1, dtg_1);
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Sai chỗ lấy phần tử tập element để bỏ vào datagridview");
                    }



                    //Khi lấy được dữ liệu giống element[j] rồi ta add vào list nhưng có kiểm tra điều kiện đã có chưa trong list đó
                    for (int s = 0; s < dgtPl.Rows.Count - 1; s++)
                    {
                        string resurt = dgtPl.Rows[s].Cells["NameSubSet"].Value.ToString();
                        if (test(resurt, resurtPl) == false)
                        {
                            resurtPl.Add(resurt);
                        }
                    }
                }
                //In ra giá trị của resurtPl
                /* for (int s = 0; s < resurtPl.Count; s++)
                 {
                     MessageBox.Show("Gía trị resurtPl[" + s + "] là " + resurtPl[s]);
                 }
                 */
                //Tính giá trị PL sau khi ta có list resurtPl
                for (int s = 0; s < resurtPl.Count; s++)
                {
                    try
                    {
                        string queryString_get_mBPA = @"Select dbo." + getNameButtonReceive + ".mBPA From dbo." + getNameButtonReceive + " Where dbo." + getNameButtonReceive + ".NameSubSet = '" + resurtPl[s].ToString() + "'";
                        //MessageBox.Show(queryString_get_mBPA);
                        string mBPA = (string)ketnoisql.ExecuteScalar(queryString_get_mBPA);

                        pl = pl + Convert.ToDouble(mBPA);
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Sai chỗ tính pl");
                    }
                }
                try
                {
                    string queryString_add_pl = @"update dbo." + getNameButtonReceive + " Set dbo." + getNameButtonReceive + ".Pl = N'" + pl.ToString() + "' Where dbo." + getNameButtonReceive + ".NameSubSet = N'" + subsetButtonRecusive[i] + "'";
                    //MessageBox.Show(queryString_add_bel);
                    ketnoisql.ExecuteNonQuery(queryString_add_pl);
                }
                catch (SqlException)
                {
                    MessageBox.Show("Sai chỗ add vào SQL bel");
                }
                pl = 0;

            }




            MessageBox.Show("Lưu dữ liệu thành công");
            this.Close();
        }
    }
}
