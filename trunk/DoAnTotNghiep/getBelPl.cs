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

namespace DoAnTotNghiep
{
    class getBelPl
    {


        public static double calculateBelPl(ArrayList value_v3, ArrayList name_v3, object node_v3, int bel_pl)
        {

            
          
            object node = new object();


            double[,] value_matrix = null;
            string[] name_matrix = null;
            double[,] value_duong = null;
            double[,] value_am = null;

            //tạo 1 mảng a int để đánh dấu và số k để trỏ tới từng phần tử khi trả về tập cuối
            int[] a = new int[100];
            int[] k = new int[1] { 0 };

            node = node_v3;

            //Tao ma tran co ban value
            int s = (int)(Math.Pow(2, value_v3.Count)) - 1;
            //MessageBox.Show("n = "+ n.ToString());
            value_matrix = new double[s, value_v3.Count];
            //Tao ma tran co ban name tuong ứng
            name_matrix = new string[s];
            //tao ma tran duong la 1 ma tran vuong
            value_duong = new double[s, s];
            //tao ma tran am la 1 ma tran vuong
            value_am = new double[s, s];

            //điền giá trị và ma trận cơ bản value và name
            recursiveSubSet(1, a, value_v3, name_v3, value_matrix, name_matrix, k);
            
            // điền gia trị vào 2 ma trận âm và dương

            for (int i = 0; i < s; i++)
            {
                for (int j = 0; j < s; j++)
                {
                    if (i.Equals(j))
                    {
                        value_duong[i, j] = 1;
                        value_am[i, j] = -1;
                    }
                    else
                    {
                        value_duong[i, j] = 0;
                        value_am[i, j] = 0;
                    }
                }
            }
            //Tính toán Pha 1
            //Tạo ma trận tổng quát
            int n = 2 * value_matrix.GetLength(0) + 2;
            int m = value_matrix.GetLength(1) + value_duong.GetLength(1) + value_am.GetLength(1) + value_duong.GetLength(1) + 3;
            double[,] matrix = new double[n, m];

            int[] acb = new int[2 * value_matrix.GetLength(0)];// đánh dấu vị trí của ẩn

            //Gán giá trị cho hàng đầu matrix[0,j]
            for (int j = 0; j < m; j++)
            {
                if (j < (m - value_duong.GetLength(1)))
                {
                    matrix[0, j] = 0;
                }
                else matrix[0, j] = 1;
            }

            //Gán giá trị cho cột đầu

            //Gán giá trị cho matrix[i,j] với i từ 1 tới n-1, j từ 3 tới m
            //phần 1 là các giá trị pl
            for (int i = 1; i < value_matrix.GetLength(0) + 1; i++)
                for (int j = 3; j < m; j++)
                {
                    if (j < 3 + value_matrix.GetLength(1))//Gán value_matrix vào trước
                    {
                        matrix[i, j] = value_matrix[i - 1, j - 3];
                    }
                    else if (j < 3 + value_matrix.GetLength(1) + value_duong.GetLength(1))//gán thêm value_duong vào
                    {
                        matrix[i, j] = value_duong[i - 1, j - 3 - value_matrix.GetLength(1)];
                        acb[j - 3 - value_matrix.GetLength(1)] = j;//Pl vị trí ẩn cơ bản
                    }
                    else// 2 phần còn lại gán ma trận 0 vào
                    {
                        matrix[i, j] = 0;
                    }
                }

            //Phần 2 là các giá trị Bel
            for (int i = value_matrix.GetLength(0) + 1; i < n - 1; i++)
                for (int j = 3; j < m; j++)
                {
                    if (j < 3 + value_matrix.GetLength(1))//Gán value_matrix vào trước
                    {
                        matrix[i, j] = value_matrix[i - value_matrix.GetLength(0) - 1, j - 3];
                    }
                    else if (j < 3 + value_matrix.GetLength(1) + value_duong.GetLength(1))// Gán ma trận 0 vào
                    {
                        matrix[i, j] = 0;
                    }
                    else if (j < 3 + value_matrix.GetLength(1) + value_duong.GetLength(1) + value_am.GetLength(1))//gán value_am vào 
                    {
                        matrix[i, j] = value_am[i - value_matrix.GetLength(0) - 1, j - 3 - value_matrix.GetLength(1) - value_duong.GetLength(1)];
                    }
                    else// phần còn lại gán ma trận value_duong vào
                    {
                        matrix[i, j] = value_duong[i - value_matrix.GetLength(0) - 1, j - 3 - value_matrix.GetLength(1) - value_duong.GetLength(1) - value_am.GetLength(1)];
                        acb[j - 3 - value_matrix.GetLength(1) - value_am.GetLength(1)] = j;//Bel vị trí ẩn cơ bản
                    }
                }

            //Gán giá trị cho cột đầu từ vị trí i = 1 tới i = n-1
            for (int i = 1; i < n - 1; i++)
            {
                int index = acb[i - 1];
                matrix[i, 0] = matrix[0, index];
            }
            //Gán giá trị cho cột thứ 2 là cột ẩn cơ bản
            for (int i = 1; i < n - 1; i++)
            {

                matrix[i, 1] = acb[i - 1];
            }
            //Gán giá trị cho cột thứ 3 là phương án
            for (int i = 1; i < n - 1; i++)
            {
                if (i < value_matrix.GetLength(0) + 1)
                {

                    string queryString_get_Pl_index = @"Select dbo." + node.ToString() + ".Pl From dbo." + node.ToString() + " Where dbo." + node.ToString() + ".NameSubSet = '" + name_matrix[i - 1].ToString() + "'";
                    //MessageBox.Show(queryString_get_Pl_index);

                    double pl_index = Convert.ToDouble(ketnoisql.ExecuteScalar(queryString_get_Pl_index));
                    //MessageBox.Show(pl_index.ToString());
                    matrix[i, 2] = pl_index;
                }
                else
                {
                    string queryString_get_Bel_index = @"Select dbo." + node.ToString() + ".Bel From dbo." + node.ToString() + " Where dbo." + node.ToString() + ".NameSubSet = '" + name_matrix[i - value_matrix.GetLength(0) - 1].ToString() + "'";
                    //MessageBox.Show(queryString_get_mBPA);
                    double bel_index = Convert.ToDouble(ketnoisql.ExecuteScalar(queryString_get_Bel_index));
                    //MessageBox.Show(pl_index.ToString());
                    matrix[i, 2] = bel_index;

                }
            }

            //Gán giá trị cho hàng cuối matrix
            for (int j = 0; j < m; j++)
            {
                matrix[n - 1, j] = 0;
            }
            
            
            //Tính toán pha 1 và nó trả lại 1 ma trận được biến đổi và lưu vào
            matrix = phase1.calculateMatrix(matrix, bel_pl);
           
            //Tính toán pha 2
            // tạo ma trận pha 2 đã lược bỏ các ẩn giả
            double[,] matrix_phase2 = new double[n, m - value_duong.GetLength(1)];
           
            if (formAnalyze.resurtGetBelPl == false)
            {
                MessageBox.Show("Vô nghiệm");
            }
            else
            {
                //gán giá trị matrix_phase2 đã lược bỏ đi các biến giả
                for (int i = 0; i < matrix_phase2.GetLength(0); i++)
                    for (int j = 0; j < matrix_phase2.GetLength(1); j++)
                    {
                        matrix_phase2[i, j] = matrix[i, j];
                    }

               
                //Thay đổi giá trị hàng đầu và giá trị cột đầu
                for (int j = 3; j < matrix_phase2.GetLength(1); j++)
                {
                    if (j < 3 + value_v3.Count)
                    {
                        matrix_phase2[0, j] = Convert.ToDouble(value_v3[j - 3]);
                    }
                    else
                        matrix_phase2[0, j] = 0;

                }
               
                //cột đầu của ma trận a là các giá trị bj
                for (int i = 1; i < matrix_phase2.GetLength(0) - 1; i++)
                {
                    int index_matrix_phase2 = Convert.ToInt32(matrix[i, 1]);//lấy nội dung từ hàng 0
                    matrix_phase2[i, 0] = matrix_phase2[0, index_matrix_phase2];

                }
            }



            return phase2.calculateBelPl(matrix_phase2, bel_pl);
        }

        public static void recursiveSubSet(int u, int[] a, ArrayList value, ArrayList name, double[,] value_matrix, string[] name_matrix, int[] k)
        {
            // ta có u = 1, k = 0
            int n = Convert.ToInt32(value.Count);
            if (u == n + 1) //ngắt khi có dấu hiệu u = n+1 = 4
            {
                //gọi hàm lấy giá trị
                getElementSet(a, value, name, value_matrix, name_matrix, k);
                return;
            }
            // nhánh sai
            a[u - 1] = 0;
            recursiveSubSet(u + 1, a, value, name, value_matrix, name_matrix, k);
            // nhánh đúng
            a[u - 1] = 1;
            recursiveSubSet(u + 1, a, value, name, value_matrix, name_matrix, k);
        }

        public static void getElementSet(int[] a, ArrayList value, ArrayList name, double[,] value_matrix, string[] name_matrix, int[] k)
        {
            int n = Convert.ToInt32(value.Count); ;
            int q = Convert.ToInt32(k[0]);

            int danh_dau = 0;

            for (int i = 0; i < n; i++)

                if (a[i] != 0)  //nếu a[i] = 1 thì ghi dữ liệu vào mảng
                {


                    name_matrix[q] = name_matrix[q] + (string)name[i];

                    danh_dau = 1;

                }

            if (danh_dau == 1)
            {
                for (int i = 0; i < n; i++)
                {
                    value_matrix[q, i] = a[i];
                };

                k[0] = Convert.ToInt32(k[0]) + 1;
            }
        }

    }
}
