
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using DoAnTotNghiep.DATNDataSetTableAdapters;

namespace DoAnTotNghiep
{
    public partial class Main : Form
    {
        
        //Khai báo biến toàn cục tổng số lượng chuyên gia
        public static string totalExperts;
        public static int levelNumber;
        int[] buttonSpace = new int[100];
        //tạo 1 ảnh image để vẽ, và 1 điểm để vẽ ảnh tại đó
        Bitmap image;

        //k để xác định button k, j để xác định số button đã đủ vẽ đường thẳng chưa
        int indexButton = 1, totalButtonToDraw = 0;
        //Luu id button so 1 bang text id_button_1 = select id_button from BUTTON with button_name = bt1.Name, id connect = 0
        string indexFirstButton = "";
        string indexSecondButton = "";
        int indexConnect = 1;
        //Kiểm tra xem click vào  menu nào, nếu click form main(vẽ cây) = 0, click (nhập dữ liệu) = 1 mục đích để quản lí các event
        int clickMenu = 0;
        //Khai báo đồ họa để vẽ đường thẳng
        Graphics graphics;
        Pen penDraw = new Pen(Color.Blue);
        Point pointLeft = new Point();
        Point pointRight = new Point();
        //mục đích đem các button được click tạo ra bảng SQL vào 1 mảng rồi khi xóa sẽ xóa tất cả các bảng đó, q để đánh dấu phần tử của mảng này
        //string[] arrayButtonClick=new string[100];
        //int q = 0;
        //Point q_trai = new Point();
        //Point q_phai = new Point();
        //Khai báo số array list để lưu các table phải xóa khi thoát
        public static ArrayList arrayTableToDelete = new ArrayList();


        private string nameMucTieu;
        private int idMucTieu;
        // Xac dinh trang thay import du lieu de kiem tra trong event cua gridview;
        private bool importData = true;
        //Luu cac button 
        Dictionary<string, Button> dicTieuChi = new Dictionary<string, Button>();
        CONNECTTableAdapter connectTableAdapter = new CONNECTTableAdapter();
        bool isUserDeleted = false;
        string nameButtonDeleted = "";
        public Main()
        {
            InitializeComponent();

            //this.StartPosition = FormStartPosition.CenterParent;
            //this.StartPosition = FormStartPosition.CenterScreen;
            //tạo panel 1
            panelDrawMain.Width = 3000;
            panelDrawMain.Height = 2000;
            //this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw, true);

            //tạo image để vẽ đường thẳng
            image = new Bitmap(panelDrawMain.ClientSize.Width, panelDrawMain.ClientSize.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            
            //tạo khung đo
            for (int i = 0; i < 20; i++)
            {
                TextBox tb = new TextBox();
                tb.Width = 150;
                tb.Height = 30;
                tb.Left = 150 * i;
                tb.Top = 0;
                tb.ReadOnly = true;
                tb.Enabled = false;
                tb.Text = "";
                panelDrawMain.Controls.Add(tb);
            }
            
        }

        public Main(String name, int id, DATNDataSet dataset)
        {           

            importData = true;
            InitializeComponent();

            //tạo panel 1
            panelDrawMain.Width = 3000;
            panelDrawMain.Height = 2000;
            //this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw, true);

            //tạo image để vẽ đường thẳng
            image = new Bitmap(panelDrawMain.ClientSize.Width, panelDrawMain.ClientSize.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);

            //tạo khung đo
            for (int i = 0; i < 20; i++)
            {
                TextBox tb = new TextBox();
                tb.Width = 150;
                tb.Height = 30;
                tb.Left = 150 * i;
                tb.Top = 0;
                tb.ReadOnly = true;
                tb.Enabled = false;
                tb.Text = "";
                panelDrawMain.Controls.Add(tb);
            }

            //khoi tao du lieu
            nameMucTieu = name;
            idMucTieu = id;
            dATNDataSet = dataset;
            importData = false;            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dATNDataSet.BUTTON' table. You can move, or remove it, as needed.
            this.bUTTONTableAdapter.FillBySurveyId(this.dATNDataSet.BUTTON, idMucTieu);
            connectTableAdapter.Fill(dATNDataSet.CONNECT);
            bUTTONBindingSource.DataSource = this.dATNDataSet.BUTTON;
            


            int iInCol = 0;
            int top = 40;
            int left = 1;
            int numCol = 0;
            //Ve lai cac button
            foreach (DataRow row in dATNDataSet.BUTTON.OrderBy(c => c.button_space))
            {
                Button btn = null;
                // khoi tao so space
                if (numCol == 0)
                {
                    numCol = Convert.ToInt32(row["button_space"].ToString());
                }
                // neu qua space khac thi gan lai so thu tu trong space = 0
                if (numCol != Convert.ToInt32(row["button_space"].ToString()))
                {
                    numCol = Convert.ToInt32(row["button_space"].ToString());
                    iInCol = 0;
                    top = 40;
                }
                left = Convert.ToInt32(row["button_space"].ToString()) * 150;
                btn = TaoButton(new Button(), row["button_name"].ToString(), row["button_text"].ToString(), top + iInCol * 30, left, 30, 100);
                top = top + iInCol * 30;
                iInCol++;

                //Luu button lai
                dicTieuChi.Add(btn.Name, btn);
            }

            string parent;
            string child;
            //Ve lai cac duong noi giua cac button
            foreach (DataRow row in dATNDataSet.CONNECT.Rows)
            {
                parent = row["connect_button_highLevel"].ToString();
                child = row["connect_button_lowLevel"].ToString();

                pointRight.X = dicTieuChi[parent].Left + 100;
                pointRight.Y = dicTieuChi[parent].Top + 15;
                pointLeft.X = dicTieuChi[parent].Left;
                pointLeft.Y = dicTieuChi[parent].Top + 15;

                DrawLineConnectButton(dicTieuChi[child]);
            }

            //khoi tao lai biet i indexButton;
            DataRow rowLast =  dATNDataSet.BUTTON.Rows[dATNDataSet.BUTTON.Count - 1];
            indexButton = Convert.ToInt32(rowLast["button_id"]) + 1;

            //khoi tao lai biet i indexConnect;
            rowLast = dATNDataSet.CONNECT.Rows[dATNDataSet.CONNECT.Count - 1];
            indexConnect = Convert.ToInt32(rowLast["connect_button_id"]) + 1;
            
        }

        private void ReDrawMain()
        {
            //fill lai vi co the da them cai moi roi
            this.bUTTONTableAdapter.FillBySurveyId(this.dATNDataSet.BUTTON, idMucTieu);
            connectTableAdapter.Fill(dATNDataSet.CONNECT);
            bUTTONBindingSource.DataSource = this.dATNDataSet.BUTTON;

            connectTableAdapter.Fill(dATNDataSet.CONNECT);
            //Xoa cac ket noi thua
            foreach (DataRow row in dATNDataSet.CONNECT.Rows)
            {
                if (row["connect_button_highLevel"].ToString() == nameButtonDeleted || row["connect_button_lowLevel"].ToString() == nameButtonDeleted)
                {
                    row.Delete();
                }
            }
            connectTableAdapter.Update(dATNDataSet.CONNECT);

            int iInCol = 0;
            int top = 40;
            int left = 1;
            int numCol = 0;
            //Ve lai cac button
            foreach (DataRow row in dATNDataSet.BUTTON.OrderBy(c => c.button_space))
            {
                Button btn = null;
                // khoi tao so space
                if (numCol == 0)
                {
                    numCol = Convert.ToInt32(row["button_space"].ToString());
                }
                // neu qua space khac thi gan lai so thu tu trong space = 0
                if (numCol != Convert.ToInt32(row["button_space"].ToString()))
                {
                    numCol = Convert.ToInt32(row["button_space"].ToString());
                    iInCol = 0;
                    top = 40;
                }
                left = Convert.ToInt32(row["button_space"].ToString()) * 150;
                btn = TaoButton(new Button(), row["button_name"].ToString(), row["button_text"].ToString(), top + iInCol * 30, left, 30, 100);
                top = top + iInCol * 30;
                iInCol++;

                //Luu button lai
                dicTieuChi.Add(btn.Name, btn);
            }

            string parent;
            string child;

            connectTableAdapter.Fill(dATNDataSet.CONNECT);
            //Ve lai cac duong noi giua cac button
            foreach (DataRow row in dATNDataSet.CONNECT.Rows)
            {
                parent = row["connect_button_highLevel"].ToString();
                child = row["connect_button_lowLevel"].ToString();

                pointRight.X = dicTieuChi[parent].Left + 100;
                pointRight.Y = dicTieuChi[parent].Top + 15;
                pointLeft.X = dicTieuChi[parent].Left;
                pointLeft.Y = dicTieuChi[parent].Top + 15;

                DrawLineConnectButton(dicTieuChi[child]);
            }
        }

        private Button TaoButton(Button btn, string nameButton, string textButton, int top, int left, int height, int with)
        {
            btn.Name = nameButton;
            btn.Text = textButton;
            btn.Width = with;
            btn.Top = top;
            btn.Left = left;
            btn.Click += clickButtonToDraw;
            panelDrawMain.Controls.Add(btn);
            return btn;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(image, Point.Empty);
        }

        private void panel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //MessageBox.Show("click trong panel 1");
            //Khi nhấn double chuột tạo 1 textboxt  tại vị trí x y
            TextBox tb1 = new TextBox();
            //MessageBox.Show(i.ToString());
            tb1.Name = indexButton.ToString();
            tb1.Multiline = true;
            tb1.Height = 30;
            tb1.Width = 100;
            tb1.Top = 50 * (e.Y / 50) + 20;
            tb1.Left = 150 * (e.X / 150) + 50;
            //this.Controls.Add(tb1);


            panelDrawMain.Controls.Add(tb1);
            tb1.Focus();
            //tb1.KeyDown += new KeyEventHandler(tb1_KeyDown);
            tb1.KeyDown += textboxKeyDown;
            //Gõ Enter thì tạo 1 button
        }

        void textboxKeyDown(object sender, KeyEventArgs e)
        {

            //throw new NotImplementedException();
            TextBox txt = (TextBox)sender;
           //MessageBox.Show("Keydown");
            if (e.KeyData == Keys.Enter)
            {
                if (txt.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập dữ liệu");
                }
                else
                {


                        //MessageBox.Show("Da nhan Enter");
                        txt.Visible = false;
                        Button bt1 = new Button();
                        bt1.Name = "bt" + indexButton.ToString();// dạng bt2, bt3

                        //MessageBox.Show(i.ToString()+" Name là "+bt1.Name);
                        bt1.Height = 30;
                        bt1.Width = 100;
                        bt1.Top = txt.Top;
                        bt1.Left = txt.Left;
                        bt1.Text = txt.Text;
                        
                        Button btn = TaoButton(new Button(), bt1.Name, bt1.Text, bt1.Top, bt1.Left, 30, 100);

                        dicTieuChi.Add(bt1.Name, btn);

                        DataRow row = dATNDataSet.BUTTON.NewRow();
                        row["survey_id"] = idMucTieu;
                        row["button_name"] = bt1.Name;
                        row["button_id"] = indexButton.ToString();
                        row["button_text"] = bt1.Text;
                        row["button_space"] = (bt1.Left / 150).ToString();
                        dATNDataSet.BUTTON.Rows.Add(row);
                        bUTTONTableAdapter.Update(dATNDataSet.BUTTON);

                        //Dua vao SQL button gom ten button = bt1.Name, khoang button = bt1.Left /150,

//                        string queryString = @"insert into BUTTON(button_name, button_id, button_text, button_space)
//                                            values          (N'" + bt1.Name + "',N'" + indexButton.ToString() + "',N'" + bt1.Text + "',N'" + (bt1.Left / 150).ToString() + "')";

//                        try
//                        {
//                            ketnoisql.ExecuteNonQuery(queryString);
//                        }
//                        catch (SqlException)
//                        {
//                            MessageBox.Show("Dữ liệu thực sự đã tồn tại");
//                        }
                        indexButton++;
                       
                        
                        
                }
            }

        }


        void clickButtonToDraw(object sender, EventArgs e)
        {
            Button bt1 = (Button)sender;
            if (clickMenu == 1)
            {    
                //Lấy level của nút này
                try
                {
                    string query_getLevel = @"SELECT button_level FROM dbo.BUTTON WHERE button_name=N'"+bt1.Name+"'";
                    int getlevel = Convert.ToInt32(ketnoisql.ExecuteScalar(query_getLevel));
                    
                    if (getlevel < Main.levelNumber - 1)
                    {
                        InputData f = new InputData(bt1.Name, bt1.Text);
                        f.Show();
                    }
                   
                }
                catch (SqlException)
                {

                }
                
            }
            else if (clickMenu == 2)
            {
                try
                {
                    string query_getLevel = @"SELECT button_level FROM dbo.BUTTON WHERE button_name=N'" + bt1.Name + "'";
                    int getlevel = Convert.ToInt32(ketnoisql.ExecuteScalar(query_getLevel));
                    //MessageBox.Show(Form1.levelNumber.ToString());

                    //MessageBox.Show("có level ="+getlevel.ToString());
                    if (getlevel < Main.levelNumber - 1 - 1)
                    {
                        Form3 f = new Form3(bt1.Name, bt1.Text);
                        f.Show();
                    }
                    
                }
                catch (SqlException)
                {

                }
                
                
            }
            else
            {
                totalButtonToDraw++;

                if (totalButtonToDraw == 1)
                {
                    pointRight.X = bt1.Left + 100;
                    pointRight.Y = bt1.Top + 15;
                    pointLeft.X = bt1.Left;
                    pointLeft.Y = bt1.Top + 15;
                    //Luu id button so 1 bang text id_button_1 = select id_button from BUTTON with button_name = bt1.Name
                    indexFirstButton = bt1.Name;
                }
                if (totalButtonToDraw == 2)
                {
                    //Luu id button so 1 bang text indexSecondButton = select id_button from BUTTON with button_name = bt1.Name
                    indexSecondButton = bt1.Name;
                    //Kiểm tra xem 2 button này có trong bảng kết nối không
                    string queryString_connect_scalar_1 = @"select count(*) FROM CONNECT
                                                        WHERE (CONNECT.connect_button_highLevel = N'" + indexFirstButton + "' AND  CONNECT.connect_button_lowLevel = N'" + indexSecondButton + "')";
                    //MessageBox.Show("Nút "+id_button_1+" và "+indexSecondButton+" có EXECUTESCALR = "+ketnoisql.ExecuteScalar(queryString_connect_scalar_1).ToString());
                    string queryString_connect_scalar_2 = @"select count(*) FROM CONNECT
                                                        WHERE (CONNECT.connect_button_highLevel = N'" + indexSecondButton + "' AND  CONNECT.connect_button_lowLevel = N'" + indexFirstButton + "')";


                    //MessageBox.Show("space cua button  " + id_button_1 + " la " + (string)ketnoisql.ExecuteScalar(queryString_space_button1));
                    string queryString_space_button1 = @"SELECT  button_space  FROM   BUTTON  
                                                        WHERE   (button_name = N'" + indexFirstButton + "')";
                    string queryString_space_button2 = @"SELECT  button_space  FROM   BUTTON  
                                                        WHERE   (button_name = N'" + indexSecondButton + "')";
                    string space_button_1 = (string)ketnoisql.ExecuteScalar(queryString_space_button1);
                    string space_button_2 = (string)ketnoisql.ExecuteScalar(queryString_space_button2);
                    string queryString_space = "";
                    //MessageBox.Show("space cua button " + id_button_1 + " la " + ketnoisql.ExecuteScalar(queryString_space_button1).ToString() + "\n space cua button " + indexSecondButton + " la " + ketnoisql.ExecuteScalar(queryString_space_button2).ToString());
                    if (Convert.ToInt32(space_button_1) > Convert.ToInt32(space_button_2))
                        queryString_space = @"select count (*) FROM BUTTON
                                                        WHERE( button_space < N'" + space_button_1 + "' AND button_space > N'" + space_button_2 + "')";

                    else
                        queryString_space = @"select count (*) FROM BUTTON
                                                        WHERE( button_space > N'" + space_button_1 + "' AND button_space < N'" + space_button_2 + "')";
                    if ((int)ketnoisql.ExecuteScalar(queryString_connect_scalar_1) != 0 || (int)ketnoisql.ExecuteScalar(queryString_connect_scalar_2) != 0)
                    {
                        MessageBox.Show("Đã có nét vẽ rồi");
                        totalButtonToDraw = 0;
                    }
                    //Kiểm tra xem có vẽ nhảy cóc hay không
                    else if ((int)ketnoisql.ExecuteScalar(queryString_space) != 0)
                    {
                        MessageBox.Show("Không vẽ nhảy cóc");
                        totalButtonToDraw = 0;
                    }
                    else
                    {
                        //Vẽ
                        DrawLineConnectButtonAndInsertData(bt1);

                        totalButtonToDraw = 0;
                    }

                }

            }
        }


        public void DrawLineConnectButton(Button bt1)
        {
            if (bt1.Left > pointLeft.X)
            {
                using (graphics = Graphics.FromImage(image))
                {
                    graphics.DrawLine(penDraw, pointRight.X, pointRight.Y, bt1.Left, bt1.Top + 15);
                }
                panelDrawMain.Invalidate();
            }
            else if (bt1.Left < pointLeft.X)
            {
                using (graphics = Graphics.FromImage(image))
                {
                    graphics.DrawLine(penDraw, pointLeft.X, pointLeft.Y, bt1.Left + 100, bt1.Top + 15);
                }
                panelDrawMain.Invalidate();
            }
            else
            {
                MessageBox.Show("Không thể vẽ");
            }
        }

        public void DrawLineConnectButtonAndInsertData(Button bt1)
        {
            if (bt1.Left > pointLeft.X)
            {
                using (graphics = Graphics.FromImage(image))
                {
                    graphics.DrawLine(penDraw, pointRight.X, pointRight.Y, bt1.Left, bt1.Top + 15);
                }
                panelDrawMain.Invalidate();
                //dua vao SQL ket noi gom button_HightLever = id_button_1, button_LowLever = indexSecondButton
                string queryString2 = @"insert into CONNECT(connect_button_id, connect_button_highLevel, connect_button_lowLevel)
                                                values          (N'" + indexConnect.ToString() + "',N'" + indexFirstButton + "',N'" + indexSecondButton + "')";

                try
                {
                    ketnoisql.ExecuteNonQuery(queryString2);

                }
                catch (SqlException)
                {
                    MessageBox.Show("sai này 1");
                }

                indexConnect++;
                //MessageBox.Show("muc 1 co connect_button_id = " + connect_button_id.ToString());



            }
            else if (bt1.Left < pointLeft.X)
            {
                using (graphics = Graphics.FromImage(image))
                {
                    graphics.DrawLine(penDraw, pointLeft.X, pointLeft.Y, bt1.Left + 100, bt1.Top + 15);
                }
                panelDrawMain.Invalidate();
                //dua vao SQL ket noi gom button_HightLever = bt, button_LowLever = p
                string queryString3 = @"insert into CONNECT(connect_button_id, connect_button_highLevel, connect_button_lowLevel)
                                                values          (N'" + indexConnect.ToString() + "',N'" + indexSecondButton + "',N'" + indexFirstButton + "')";
                try
                {
                    ketnoisql.ExecuteNonQuery(queryString3);

                }
                catch (SqlException)
                {
                    MessageBox.Show("sai này 2");
                }
                indexConnect++;
                //MessageBox.Show("muc 2 co connect_button_id = " + connect_button_id.ToString());

            }
            else
            {
                MessageBox.Show("Không thể vẽ");
            }
        }

  
        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            //Button bt1 = (Button)sender;
            //bt1.Click += bt1_Click_Input_Data;
        }

        private void DeleteTableTamp()
        {
            foreach (object obj in arrayTableToDelete)
            {
                string queryString_del_Buttonclick = @" DROP TABLE " + obj + "";
                //MessageBox.Show(queryString_del_Buttonclick);
                ketnoisql.ExecuteNonQuery(queryString_del_Buttonclick);
            }
                        
        }
        private void exit(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void inputData(object sender, EventArgs e)
        {

            clickMenu = 1;
            //Sếp các button lever
            //Show bảng button lên datagrid view gồm các cột button_name, button_space
            string table = "BUTTON";
            string dtg = "dtgButton";

            string queryString_get_button = @"SELECT DISTINCT button_space FROM dbo.BUTTON";
            this.dtgButton.DataSource = ketnoisql.getDatabase(queryString_get_button, table, dtg);
            levelNumber = dtgButton.RowCount - 1;
            //đưa vào mảng 1 chiều kiểu int, và sắp xếp lại theo chiều tăng của button_space
            buttonSpace = new int[levelNumber];

            //MessageBox.Show("a "+levelNumber.ToString());

            for (int j = 0; j < levelNumber; j++)
            {
                buttonSpace[j] = Convert.ToInt32(dtgButton.Rows[j].Cells[0].Value.ToString());

            }

            //MessageBox.Show("n = "+levelNumber.ToString());
            for (int i = 0; i < levelNumber; i++)
            {
                string queryString_level_button = @"UPDATE dbo.BUTTON set dbo.BUTTON.button_level = N'" + i.ToString() + "' Where dbo.BUTTON.button_space = N'" + buttonSpace[i] + "'";
                ketnoisql.ExecuteNonQuery(queryString_level_button);
            }


            panelDrawMain.MouseDoubleClick -= panel1_MouseDoubleClick;
            //Tổng số lượng chuyên gia tham gia đánh giá
            totalExperts f = new totalExperts();
            f.Show();
        }

        private void newWindow(object sender, EventArgs e)
        {
            clickMenu = 0;

            //Xóa hết database
            foreach (object obj in arrayTableToDelete)
            {
                string queryString_del_Buttonclick = @" DROP TABLE " + obj + "";
                //MessageBox.Show(queryString_del_Buttonclick);
                ketnoisql.ExecuteNonQuery(queryString_del_Buttonclick);
            }
            //Xóa database
            string queryString_del_BUTON = @" Delete From BUTTON";
            try
            {
                ketnoisql.ExecuteNonQuery(queryString_del_BUTON);
            }
            catch (SqlException)
            {
                MessageBox.Show("sai khi xóa button");
            }

            string queryString_del_CONNECT = @" Delete From CONNECT";
            try
            {
                ketnoisql.ExecuteNonQuery(queryString_del_CONNECT);
            }
            catch (SqlException)
            {
                MessageBox.Show("sai khi xóa connect");
            }
            Main.arrayTableToDelete.Clear();
            InputData.subsetTextRecusive = null;
            InputData.subsetButtonRecusive = null;

            this.Visible = false;
            Main f = new Main();
            //f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();

            panelDrawMain.MouseDoubleClick += panel1_MouseDoubleClick;
        }

        private void anazyle(object sender, EventArgs e)
        {
            clickMenu = 2;
            formAnalyze f = new formAnalyze();
            f.Show();
            f.Close();
            Form4 f4 = new Form4();
            f4.Show();
        }

        private void taskFinishClick(object sender, EventArgs e)
        {
            if (clickMenu == 0)
            {
                inputDataMenu.Enabled = true;
                analyzeMenu.Enabled = false;

            }
            if (clickMenu == 1)
            {
                inputDataMenu.Enabled = false;
                analyzeMenu.Enabled = true;
            }
            if (clickMenu == 2)
            {
                inputDataMenu.Enabled = false;
                analyzeMenu.Enabled = false;
            }
        }


        private void grvCriteria_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (importData)
                return;
            bUTTONTableAdapter.Update(dATNDataSet.BUTTON);
        }

        private void grvCriteria_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            bUTTONTableAdapter.Update(dATNDataSet.BUTTON);
            if (isUserDeleted)
            {
                image = new Bitmap(panelDrawMain.ClientSize.Width, panelDrawMain.ClientSize.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
                foreach (DataRow row in dATNDataSet.BUTTON.Rows)
                {
                    panelDrawMain.Controls.Remove(dicTieuChi[row["button_name"].ToString()]);
                }
                dicTieuChi.Clear();
                ReDrawMain();
            }
            
        }


        private void grvCriteria_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (importData)
                return;

            int idTieucChi = Convert.ToInt32(e.Row.Cells[0].Value.ToString());
            nameButtonDeleted = e.Row.Cells[2].Value.ToString();
            //foreach (DataRow row in dATNDataSet.CONNECT.Rows)
            //{
            //    if (row["connect_button_highLevel"].ToString() == nameButton || row["connect_button_lowLevel"].ToString() == nameButton)
            //    {
            //        row.Delete();
            //    }
            //}            

            Button btn = dicTieuChi[nameButtonDeleted];
            panelDrawMain.Controls.Remove(btn);
            isUserDeleted = true;
        }

        private void grvCriteria_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (importData)
                return;

            int idTieucChi = Convert.ToInt32(grvTieuChi.Rows[e.RowIndex].Cells[0].Value.ToString());
            string btnName = grvTieuChi.Rows[e.RowIndex].Cells[2].Value.ToString();

            Button btn = dicTieuChi[btnName];

            //neu sua cot text button
            if (e.ColumnIndex == 4)
                btn.Text = grvTieuChi.Rows[e.RowIndex].Cells[4].Value.ToString();

            //if (e.ColumnIndex == 4)
            //{
            //    grvTieuChi.Controls.Remove(btn);
            //    int soO = Convert.ToInt32(grvTieuChi.Rows[e.RowIndex].Cells[4].Value.ToString());
            //    TaoButton(btn, btn.Name, btn.Text, btn.Top, soO * 150, btn.Height, btn.Width);
            //}

            bUTTONTableAdapter.Update(dATNDataSet.BUTTON);
        }

        private void panelDrawMain_Resize(object sender, EventArgs e)
        {
            image = new Bitmap(panelDrawMain.ClientSize.Width, panelDrawMain.ClientSize.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            DeleteTableTamp();
        }
    }
}