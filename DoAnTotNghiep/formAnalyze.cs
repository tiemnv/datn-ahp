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
    public partial class formAnalyze : Form
    {
        public formAnalyze()
        {
            InitializeComponent();
        }

        //kiem tra tinh toan 2 pha co nghiem hay vo nghiem
        public static bool resurtGetBelPl = true;

        int indexToClearArrayNameValue = 0;

        int rowCountConnectDtg = 0;// phuc vu ham test_leafNode
        
        ArrayList valueLeafNode = new ArrayList();
        ArrayList nameLeafNode = new ArrayList();
        ArrayList valueParentNode = new ArrayList();
        ArrayList nameParentNode = new ArrayList();
        ArrayList valueToGetBelPl = new ArrayList();
        ArrayList nameToGetBelPl = new ArrayList();

        ArrayList totalMbaPl = new ArrayList();
        double totalBel = 0;
        double totalPl = 0;

        //mang chua cac nut phuong an thap nhat
        string[] buttonLowest = null;
        //mang chua cac tap phuong an
        string[] planSet = null;
        //tạo 1 mảng a int để đánh dấu và số k để trỏ tới từng phần tử cua mang phuong an
        int[] indexRecusive = new int[100];
        int[] indexElementPlanSet = new int[1] { 0 };

        //Lấy dữ liệu các nút có thể click để tính Bel, Pl
        string[] buttonCriteriaBelPl = null;
        //Lấy dữ liệu connect giữa các button có thể click tính Bel, Pl
        string[,] matrixConnect = null;
        private void formAnalyze_Load(object sender, EventArgs e)
        {

            
            
            //show các kết nối button có level từ 0 tới Main.levelNumber - 3
            string xem = (Main.levelNumber - 3).ToString();
            //MessageBox.Show(xem);

            string queryString_get_button1 = @"SELECT dbo.CONNECT.connect_button_highLevel, dbo.CONNECT.connect_button_lowLevel FROM            (SELECT button_name, button_level   FROM   dbo.BUTTON AS BUTTON_1   WHERE  (button_level BETWEEN '0' AND '" + xem + "')) AS derivedtbl_1 INNER JOIN  dbo.CONNECT ON derivedtbl_1.button_name = dbo.CONNECT.connect_button_highLevel";
            string table1 = "CONNECT";
            string dtg1 = "dtgConnect";
            this.dtgConnect.DataSource = ketnoisql.getDatabase(queryString_get_button1, table1, dtg1);
            //MessageBox.Show((dtgConnect.RowCount).ToString());
            //Tính toán
            //Đưa dữ liệu này vào mảng 2 chiều B[i,j]
            rowCountConnectDtg = dtgConnect.RowCount;
            //MessageBox.Show("connect_rowCount = " + connect_rowCount.ToString());

            matrixConnect = new string[rowCountConnectDtg - 1, 2];

            for (int row = 0; row < rowCountConnectDtg - 1; row++)
            {
                for (int cell = 0; cell < 2; cell++) 
                {
                    matrixConnect[row, cell] = dtgConnect.Rows[row].Cells[cell].Value.ToString();
                }
            }

            
            //Lấy dữ liệu các nút có thể click để tính Bel, Pl
            string queryString_get_button_BelPL = @"SELECT DISTINCT button_id, button_name, button_level   FROM   dbo.BUTTON   WHERE  (button_level BETWEEN '0' AND '" + xem + "')";
            string table_BelPl = "BUTTON";
            string dtg_BelPl = "dtgButtonBelPl";
            this.dtgButtonBelPl.DataSource = ketnoisql.getDatabase(queryString_get_button_BelPL, table_BelPl, dtg_BelPl);
            buttonCriteriaBelPl = new string[dtgButtonBelPl.RowCount - 1];
            for (int row = 0; row < dtgButtonBelPl.RowCount - 1; row++)
            {
                buttonCriteriaBelPl[row] = dtgButtonBelPl.Rows[row].Cells["button_name"].Value.ToString();
            }
            /*
            for (int row = 0; row < dtgButtonBelPl.RowCount - 1; row++)
            {
                MessageBox.Show("buttonBelPl[" + row.ToString() + "]= " + buttonBelPl[row]);
            }
            */

            //Tạo 1 arraylist chứa các lá và tìm các lá này
            ArrayList leafNode = new ArrayList();

            for (int row = 0; row < rowCountConnectDtg - 1; row++)
            {
                if (test_leafNode(matrixConnect, matrixConnect[row, 1])) leafNode.Add(matrixConnect[row, 1]);
            }
            //Show arraylist
            /*
            for (int i = 0; i < leafNode.Count; i++)
            {
                MessageBox.Show(leafNode[i].ToString());
            }
            */
            
            //Tạo 1 mảng chứa các tập phương án
            //Show các button có giá trị level thấp nhất
            string queryString_get_button2 = @"SELECT DISTINCT button_id, button_name, button_level   FROM   dbo.BUTTON   WHERE  (button_level = '" + (Main.levelNumber - 1).ToString() + "')";
            string table2 = "BUTTON";
            string dtg2 = "dtgButtonLow";
            this.dtgButtonLow.DataSource = ketnoisql.getDatabase(queryString_get_button2, table2, dtg2);
            //có 2^n - 1 tap phuong an
            int n = dtgButtonLow.RowCount - 1;
            buttonLowest = new string[n];
            for (int i = 0; i < dtgButtonLow.Rows.Count - 1; i++)
            {
                buttonLowest[i] = dtgButtonLow.Rows[i].Cells["button_name"].Value.ToString();
            }
            planSet = new string[(int)(Math.Pow(2, n) - 1)];

            recursiveGetPlaneSet(1, indexRecusive, buttonLowest, planSet, indexElementPlanSet);

         
            
            //Tạo 1 bảng chứa kết quả Bel, Pl

            for (int i = 0; i < buttonCriteriaBelPl.Length; i++)
                {
                    try
                    {

                        string queryString_addTableSetPhuongAn = @"CREATE TABLE " + buttonCriteriaBelPl[i].ToString() + "_Bel_Pl" + " (Id nvarchar(10) NOT NULL PRIMARY KEY(Id), NameSetPhuongAn nvarchar(50)NOT NULL, Bel nvarchar(50) NULL, Pl nvarchar(50) NULL)";
                        ketnoisql.ExecuteNonQuery(queryString_addTableSetPhuongAn);
                        Main.arrayTableToDelete.Add(buttonCriteriaBelPl[i].ToString() + "_Bel_Pl");
                    }
                    catch (SqlException)
                    {
                        goto exit;
                    }
                }
             
            //update cac gia tri vao
            //Tính giá trị bel và Pl của các lá
            
            //Gía trị bel là




            for (int i = 0; i < buttonCriteriaBelPl.Length; i++)
            {
                for (int j = 0; j < planSet.Length; j++)
                {
                    recursiveGetValueBelPl(matrixConnect, leafNode, buttonCriteriaBelPl[i], 0, planSet[j], 0);//Tính được tổng bel này
                    recursiveGetValueBelPl(matrixConnect, leafNode, buttonCriteriaBelPl[i], 0, planSet[j], 1);//Tính được tổng Pl này
                    string queryString = @"insert into " + buttonCriteriaBelPl[i].ToString() + "_Bel_Pl" + "(Id, NameSetPhuongAn, Bel, Pl)  values (N'" + j.ToString() + "',N'" + planSet[j].ToString() + "',N'" + totalBel.ToString() + "',N'" + totalPl.ToString() + "')";
                    ketnoisql.ExecuteNonQuery(queryString);

                    totalBel = 0;
                    totalPl = 0;
                }
            }
             
            



            























            
             // Tính thành phần Pl
           //MessageBox.Show(leafNode[3].ToString());
           //MessageBox.Show(buttonBelPl[0].ToString());

           //MessageBox.Show(phuongAn[2].ToString());
            //recursive(B, leafNode, buttonBelPl[0], 0, phuongAn[2], 0);//Tính được tổng bel này

            //MessageBox.Show(tongBel.ToString());
            //recursive(B, leafNode, buttonBelPl[0], 0, phuongAn[2], 1);//Tính được tổng Pl này
            //MessageBox.Show(tongPl.ToString());
          















        exit: ;
        }
        private void get_resurtPl(object leafNode1, object phuongAn1)
        {
            // Tính thành phần Pl

           
            string leafNode = leafNode1.ToString();
            string phuongAn = phuongAn1.ToString();

            //recursive(B, leafNode, buttonBelPl[0], 0, phuongAn[4], 1);//Tính được tổng Pl này

            //Lấy ra các phần tử của tập phuong án 4 

            string table_1 = leafNode + "_" + phuongAn;
            string dtg_1 = "dtgElement";
            try
            {
                string queryString_get_elementSubset = @"SELECT dbo." + table_1 + ".NameSubsetElement From dbo." + table_1 + "";
                //MessageBox.Show("queryString_get_elementSubset = " + queryString_get_elementSubset);
                this.dtgElement.DataSource = ketnoisql.getDatabase(queryString_get_elementSubset, table_1, dtg_1);
           }
           catch (SqlException)
           {
              MessageBox.Show("Sai chỗ lấy phần tử tập element để bỏ vào datagridview");
            }   

            //1 mảng element
            string[] Element = new string[dtgElement.Rows.Count - 1];

            //MessageBox.Show((dtgElement.Rows.Count - 1).ToString());


            for (int j = 0; j < dtgElement.Rows.Count - 1; j++)
            {
                Element[j] = dtgElement.Rows[j].Cells["NameSubsetElement"].Value.ToString();
            }


            //Lọc ra các row của leafNode nếu nó có phần tử giống phần tử này

            for (int j = 0; j < Element.Length; j++)
            {

                //fill lên bảng dgtPl với những giá trị like element[j]
                string table_2 = (string)(leafNode);
                string dtg_2 = "dtgPl";
                try
                {
                    string queryString_get_elementSubset1 = @"SELECT dbo." + table_2 + ".* From dbo." + table_2 + " Where dbo." + table_2 + ".NameSubSet LIKE N'%" + Element[j] + "%'";
                    //MessageBox.Show("queryString_get_elementSubset = " + queryString_get_elementSubset);
                    this.dtgPl.DataSource = ketnoisql.getDatabase(queryString_get_elementSubset1, table_2, dtg_2);
                }
                catch (SqlException)
                {
                    MessageBox.Show("Sai chỗ lấy phần tử tập element để bỏ vào datagridview 2");
                }



                //Khi lấy được dữ liệu giống element[j] rồi ta add vào list nhưng có kiểm tra điều kiện đã có chưa trong list đó
                for (int s = 0; s < dtgPl.Rows.Count - 1; s++)
                {
                    string resurt = dtgPl.Rows[s].Cells["NameSubSet"].Value.ToString();
                    if (test(resurt, totalMbaPl) == false)
                    {
                        totalMbaPl.Add(resurt);
                    }
                }
            }
            //Ta đã được 1 list chứa các kết quả có thể.

        }

        //kiem tra cac tap hop co bi trung lap khong
        private bool test(string resurt, ArrayList resurtPl)
        {
            string obj1 = resurt;
            for (int s = 0; s < resurtPl.Count; s++)
            {

                string obj2 = resurtPl[s].ToString();
                if (obj2.Equals(obj1)) return true;// nếu đúng là đã có thì trả về true
            }
            return false;
        }

        //Kiem tra de lay gia tri cac phuong an
        private bool test_leafNode(string[,] B, string leaf)
    {

        object obj1 = leaf;
        object obj2 = null;
        for (int row = 0; row < rowCountConnectDtg - 1; row++)
        {
            obj2 = B[row, 0];
            if (obj1.Equals(obj2)) return false;
        }
        return true;
    }

        //Ham de qui tinh Bel Pl
        public void recursiveGetValueBelPl(string[,] B, ArrayList leafNode, string node, int x, string phuongAn, int bel_pl)
        {
            object obj1 = node;
           
            for (int i = 0; i < leafNode.Count; i++)
            {

                object obj2 = leafNode[i];
                if (obj1.Equals(obj2))
                {
                    object obj3 = null;
                    if (bel_pl == 0)
                    {
                        string queryString_get_mBPA = @"Select dbo." + leafNode[i].ToString() + ".mBPA From dbo." + leafNode[i].ToString() + " Where dbo." + leafNode[i] + ".NameSubSet = '" + phuongAn + "'";
                        //MessageBox.Show(queryString_get_mBPA);
                        double mBPA = Convert.ToDouble(ketnoisql.ExecuteScalar(queryString_get_mBPA));
                        obj3 = mBPA;
                    }
                    else
                    {
                        get_resurtPl(leafNode[i], phuongAn);
                        double pl = 0;
                        for (int j = 0; j < totalMbaPl.Count; j++)
                        {
                            try
                            {
                                string queryString_get_mBPA = @"Select dbo." + leafNode[i].ToString() + ".mBPA From dbo." + leafNode[i].ToString() + " Where dbo." + leafNode[i] + ".NameSubSet = '" + totalMbaPl[j] + "'";
                                //MessageBox.Show(queryString_get_mBPA);
                                double mBPA = Convert.ToDouble(ketnoisql.ExecuteScalar(queryString_get_mBPA));
                                //MessageBox.Show(mBPA.ToString());
                                pl = pl + Convert.ToDouble(mBPA);
                            }
                            catch (SqlException)
                            {
                                MessageBox.Show("Sai chỗ tính pl");
                            }
                        }
                        obj3 = pl;
                        totalMbaPl.Clear();
                    }

                    valueLeafNode.Add(obj3);
                    nameLeafNode.Add(obj1);
                    return;
                };

            }
           
            x++;

            for (int j = 0; j < rowCountConnectDtg - 1; j++)
            {
                object obj3 = B[j, 0];
                if (obj3.Equals(obj1))
                {
                    recursiveGetValueBelPl(B, leafNode, B[j, 1], x, phuongAn, bel_pl);                   
                }
            }

            if ((valueLeafNode.Count != 0) && (nameLeafNode.Count != 0))
            {
              
                //gán value = value leafnode
                for (int i = 0; i < valueLeafNode.Count; i++)
                {
                    valueToGetBelPl.Add(valueLeafNode[i]);
                }
                for (int i = 0; i < nameLeafNode.Count; i++)
                {
                    nameToGetBelPl.Add(nameLeafNode[i]);
                }
                valueLeafNode.Clear();
                nameLeafNode.Clear();
               
            }
            else
            {

                if (x == 1) indexToClearArrayNameValue = 0;
                //Gán v3 = v2
                for (int i = indexToClearArrayNameValue; i < valueParentNode.Count; i++)
                {
                    valueToGetBelPl.Add(valueParentNode[i]);
                }
                for (int i = indexToClearArrayNameValue; i < nameParentNode.Count; i++)
                {
                    nameToGetBelPl.Add(nameParentNode[i]);
                }
                //clear tu indexToClearArrayNameValue toi het

                valueParentNode.RemoveRange(indexToClearArrayNameValue, valueParentNode.Count - indexToClearArrayNameValue);
                nameParentNode.RemoveRange(indexToClearArrayNameValue, nameParentNode.Count - indexToClearArrayNameValue);
                indexToClearArrayNameValue++;
            }

            //Nếu tính bel tức y = 0, nếu tính Pl tức y = 1
            if (bel_pl == 0)
            {
                //Sửa lại vị trí value và name
                //Hiện tất cả các kết nối của button truyền sang
                string table = "CONNECT";
                string dtg = "dtgButton";

                string queryString_get_connect = @"SELECT DISTINCT dbo.BUTTON.button_id, dbo.CONNECT.connect_button_highLevel,dbo.CONNECT.connect_button_lowLevel, dbo.BUTTON.button_name, dbo.BUTTON.button_text FROM dbo.CONNECT JOIN dbo.BUTTON ON dbo.CONNECT.connect_button_lowLevel = dbo.BUTTON.button_name WHERE(connect_button_highLevel = N'" + obj1.ToString() + "')";
                this.dtgButton.DataSource = ketnoisql.getDatabase(queryString_get_connect, table, dtg);


                string[] value_lowLevel = new string[dtgButton.Rows.Count - 1];
                for (int i = 0; i < dtgButton.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < valueToGetBelPl.Count; j++)
                    {
                        object obj4 = dtgButton.Rows[i].Cells["button_name"].Value.ToString();
                        object obj5 = nameToGetBelPl[j];
                        if (obj4.Equals(obj5)) value_lowLevel[i] = valueToGetBelPl[j].ToString();
                    }
                  
                }
                //Gán giá trị value và name sau khi đảo thứ tự
                for (int i = 0; i < dtgButton.Rows.Count - 1; i++)
                {
                    nameToGetBelPl[i] = dtgButton.Rows[i].Cells["button_name"].Value.ToString();
                    valueToGetBelPl[i] = value_lowLevel[i].ToString();
                }

                totalBel = DoAnTotNghiep.getBelPl.calculateBelPl(valueToGetBelPl, nameToGetBelPl, obj1, bel_pl);

                valueToGetBelPl.Clear();
                nameToGetBelPl.Clear();
                object objBel = totalBel;

                valueParentNode.Add(objBel);
                nameParentNode.Add(obj1);
            }
            else
            {
                
                //Sửa lại vị trí value và name
                //Hiện tất cả các kết nối của button truyền sang
                string table = "CONNECT";
                string dtg = "dtgButton";

                string queryString_get_connect = @"SELECT DISTINCT dbo.BUTTON.button_id, dbo.CONNECT.connect_button_highLevel,dbo.CONNECT.connect_button_lowLevel, dbo.BUTTON.button_name, dbo.BUTTON.button_text FROM dbo.CONNECT JOIN dbo.BUTTON ON dbo.CONNECT.connect_button_lowLevel = dbo.BUTTON.button_name WHERE(connect_button_highLevel = N'" + obj1.ToString() + "')";
                this.dtgButton.DataSource = ketnoisql.getDatabase(queryString_get_connect, table, dtg);
                 
                
                string[] value_lowLevel = new string[dtgButton.Rows.Count - 1];
                for (int i = 0; i < dtgButton.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < valueToGetBelPl.Count; j++)
                    {
                        object obj4 = dtgButton.Rows[i].Cells["button_name"].Value.ToString();
                        object obj5 = nameToGetBelPl[j];
                        if (obj4.Equals(obj5)) value_lowLevel[i] = valueToGetBelPl[j].ToString();
                    }
                    
                }
                //Gán giá trị value và name sau khi đảo thứ tự
                for (int i = 0; i < dtgButton.Rows.Count - 1; i++)
                {
                    nameToGetBelPl[i] = dtgButton.Rows[i].Cells["button_name"].Value.ToString();
                    valueToGetBelPl[i] = value_lowLevel[i].ToString();
                }

                totalPl = DoAnTotNghiep.getBelPl.calculateBelPl(valueToGetBelPl, nameToGetBelPl, obj1, bel_pl);
               
                valueToGetBelPl.Clear();
                nameToGetBelPl.Clear();
                object objPl = totalPl;

                valueParentNode.Add(objPl);
                nameParentNode.Add(obj1);
            }

            
            if (x == 1)
            {
                valueParentNode.Clear();
                nameParentNode.Clear();
            }
            return;
        }

        public void recursiveGetPlaneSet(int u, int[] a, string[] buttonLow, string[] phuongAn, int[] k)
        {
            // ta có u = 1, k = 0
            int n = Convert.ToInt32(this.buttonLowest.Length);
            if (u == n + 1) //ngắt khi có dấu hiệu u = n+1 = 4
            {
                //gọi hàm lấy giá trị
                getElementPlaneSet(a, buttonLow, phuongAn, k);
                return;
            }
            // nhánh sai
            a[u - 1] = 0;
            recursiveGetPlaneSet(u + 1, a, buttonLow, phuongAn, k);
            // nhánh đúng
            a[u - 1] = 1;
            recursiveGetPlaneSet(u + 1, a, buttonLow, phuongAn, k);
        }

        public void getElementPlaneSet(int[] a, string[] buttonLow, string[] phuongAn, int[] k)
        {
            int n = Convert.ToInt32(buttonLow.Length); ;
            int q = Convert.ToInt32(k[0]);

            int danh_dau = 0;

            //xóa đi mảng 

            for (int i = 0; i < n; i++)

                if (a[i] != 0)  //nếu a[i] = 1 thì ghi dữ liệu vào mảng subset_button[k]
                {
                    phuongAn[q] = phuongAn[q] + buttonLow[i];
                    danh_dau = 1;
                }
            if (danh_dau == 1)
            {
                k[0] = Convert.ToInt32(k[0]) + 1;
            }
        }

     

    }
}


