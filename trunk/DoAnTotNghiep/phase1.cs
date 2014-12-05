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
    class phase1
    {
        public static double[,] calculateMatrix(double[,] a, int b)
        {

            //ma trận nhận được
            double[,] matrix = a;
            //số dòng
            int n = matrix.GetLength(0);//8 lấy dòng
            //số cột
            int m = matrix.GetLength(1);//14 lấy cột

            /*
            MessageBox.Show("matrix_phase1 ");
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {

                    MessageBox.Show("matrix_phase1[" + i.ToString() + "," + j.ToString() + "]=" + matrix[i, j].ToString());
                }
            */
            //dấu hiệu max hay min
            int min_max = b;
            //MessageBox.Show(min_max.ToString());

            //MessageBox.Show(m.ToString());

            //Đặt biến dừng
            bool stop = false;
            int dem = 1;
            while (!stop)//nếu stop = true thì thoát vòng lặp
            {

                //Tính P và các giá trị delta
                
                for (int j = 2; j < m; j++)
                {
                    double tong = 0;
                    for (int i = 1; i < n - 1; i++)
                    {
                        tong = tong + (matrix[i, 0] * matrix[i, j]);

                    }
                    if (j == 2) matrix[n - 1, j] = tong;
                    else
                    {
                        if (min_max == 0) matrix[n - 1, j] =  tong - matrix[0, j];
                        else matrix[n - 1, j] = matrix[0, j] - tong;
                    }                    
                }

               
                
                //MessageBox.Show("lần "+dem.ToString());
                /*
                for (int i = n-1; i < n; i++)
                    for (int j = 0; j < m; j++)
                    {

                        MessageBox.Show("matrix_phase1[" + i.ToString() + "," + j.ToString() + "]=" + matrix[i, j].ToString());
                    }
                 */
               /*
                if (dem >= 2)
                {
                    for (int i = 0; i < n; i++)
                        for (int j = 0; j < m; j++)
                        {

                            MessageBox.Show("matrix_phase1[" + i.ToString() + "," + j.ToString() + "]=" + matrix[i, j].ToString());
                        }
                }
                */
                dem++;
                
                //Kiểm tra 
                //Kiểm tra giá trị delta xem: nếu tồn tại 1 delta>0 mà mọi aij < 0 thì break,
                //nếu mọi delta < hoặc = 0 mà còn ẩn giả != 0 thì vô nghiệm, bài toán này sẽ không còn ẩn phụ
                for (int j = 3; j < m; j++)
                {
                    if (min_max == 0)
                    {   ////Dấu hiệu không giải được Bài toán min pha 1, nếu tồn tại 1 delta >0 và mọi dòng tại cột delta đó <0 thì vô nghiệm
                        if (matrix[n - 1, j] > 0)
                        {
                            for (int i = 1; i < n - 1; i++)
                            {
                                stop = true;
                                if (a[i, j] >= 0)
                                {
                                    stop = false;
                                    break;
                                }

                            }
                            if (stop == true)
                            {
                                MessageBox.Show("bi false so 1 pha 1");
                                formAnalyze.resurtGetBelPl = false;// vô nghiệm
                                goto exit_while;
                            }

                            goto continue_while;// Nếu có 1 cột delta > 0  và không bị điều kiện mọi cột < 0 thì nhảy tới phần biến đổi tiếp
                        }
                    }
                    else
                    {
                        //Dấu hiệu không giải được Bài toán max, nếu tồn tại 1 delta <0 và mọi dòng tại cột delta đó <0 thì vô nghiệm
                        if (matrix[n - 1, j] < 0)//Bài toán min của ẩn giả nên phải làm theo cách min
                        {
                            for (int i = 1; i < n - 1; i++)
                            {
                                stop = true;
                                if (a[i, j] >= 0)
                                {
                                    stop = false;
                                    break;
                                }

                            }
                            if (stop == true)
                            {
                                MessageBox.Show("bi false so 2 pha 1");
                                formAnalyze.resurtGetBelPl = false;// vô nghiệm
                                goto exit_while;
                            }

                            goto continue_while;// Nếu có 1 cột delta < 0  và không bị điều kiện mọi cột < 0 thì nhảy tới phần biến đổi tiếp
                        }
                    }

                }

                //Kiểm tra P, tới đây thì mọi delta đã thực sự <= 0(min) hoặc >=0(max),
                //Nên ta đã hoàn thành vòng lặp while
                //Nếu P != 0 thì vô nghiệm và dừng vòng lặp, ngược lại thì trả về mảng matrix đã được biến đổi, 
                //và độ dài hàng cột matrix để phục vụ việc đưa dữ liệu vào mảng 2 chiều tiếp theo
                stop = true;
                //MessageBox.Show("p khac 0");
                if (Math.Round(matrix[n - 1, 2], 4) != 0)
                {

                    MessageBox.Show("P= " + matrix[n - 1, 2].ToString());
                    formAnalyze.resurtGetBelPl = false;
                    MessageBox.Show("bi false so 3 pha 1");
                }// vô nghiệm                
                goto exit_while;

                /*
                for (int j = 0; j < m; j++)
                {
                    MessageBox.Show("matrix["+(n-1).ToString()+","+j.ToString()+"]="+matrix[n-1,j].ToString());
                }
                */
            continue_while:
                // if(dem_chay==4) MessageBox.Show("nhảy vào vòng while");
                //Tìm pivot cột
                int pivot_col = 0;
                //double max_delta = matrix[n - 1, 3];
                //if(dem_chay==4) MessageBox.Show(max_delta.ToString());
                pivot_col = 3;// lấy vị trí cột là địa chỉ delta đầu tiên
                //MessageBox.Show(max_delta.ToString());
                /*
                for (int j = 3; j < m; j++)
                {
                    if (max_delta <= matrix[n - 1, j])//sai chỗ này-----------------------------------------------------------------------------------------------
                    {

                        max_delta = matrix[n - 1, j];
                        pivot_col = j;

                    }
                }
                if (dem_chay == 4) MessageBox.Show(pivot_col.ToString());
                 */

                if (min_max == 0)//Tính max là bao nhiêu nằm tại vị trí trí nào trên ma trận a với bài toán tìm min
                {

                    double max_delta = matrix[n - 1, 3];
                    pivot_col = 3;
                    //MessageBox.Show(max_delta.ToString());
                    for (int j = 3; j < m; j++)
                    {
                        if (max_delta < matrix[n - 1, j])
                        {

                            max_delta = matrix[n - 1, j];
                            pivot_col = j;

                        }
                    }
                    //MessageBox.Show(pivot_col.ToString());
                }
                else
                {   //Tìm min delta
                    double min_delta = matrix[n - 1, 3];
                    pivot_col = 3;

                    for (int j = 3; j < m; j++)
                    {
                        if (min_delta > matrix[n - 1, j])
                        {

                            min_delta = matrix[n - 1, j];
                            pivot_col = j;

                        }
                    }
                }

                //Tìm pivot_row

                int element = 0;// tìm số phần tử >0 để tạo mảng

                for (int i = 1; i < n - 1; i++)
                {
                    if (matrix[i, pivot_col] > 0)
                    {
                        element++;
                    }
                }
                //if (dem_chay == 4) MessageBox.Show(element.ToString());
                // tạo 2 mảng lưu kết quả đã chia và lưu vị trí hàng đó
                double[] min = new double[element];
                int[] position = new int[element];
                element = 0;
                for (int i = 1; i < n - 1; i++)
                {
                    if (matrix[i, pivot_col] > 0)
                    {
                        position[element] = i;
                        min[element] = matrix[i, 2] / matrix[i, pivot_col];
                        element++;
                    }
                }
                /*
                
                //if (dem_chay == 4)
                //{
                    //MessageBox.Show("min[i]");
                    for (int i = 0; i < position.Length;i++ )
                    {
                        MessageBox.Show(min[i].ToString());
                    }
                    //MessageBox.Show(element.ToString());
                 

                //}
                 */
                //MessageBox.Show(element.ToString());
                //khi tìm min thì ta cũng có được vị trí hàng tương ứng với giá trị min đó
                int pivot_row = 0;
                double min_pivot = min[0];
                for (int i = 0; i < min.Length; i++)
                {
                    if (min_pivot >= min[i])//Sai chỗ này rồi-----------------------------------------------------------------------------------------------
                    {
                        min_pivot = min[i];
                        pivot_row = position[i];
                        //if (dem_chay == 4) MessageBox.Show(min_pivot.ToString() + " tại " + pivot_row.ToString());
                    }
                }

                //MessageBox.Show(pivot_row.ToString());

                //if (dem_chay == 4) MessageBox.Show(min_pivot.ToString() + " tại " + pivot_row.ToString());


                //Hoán đổi
                //Hoán đổi hàng tại vị trí min
                //đổi giá trị cj xuống hệ số
                matrix[pivot_row, 0] = matrix[0, pivot_col];
                matrix[pivot_row, 1] = pivot_col;

                //MessageBox.Show(a[pivot_row, 1].ToString());
                //đổi giá trị cột tại hàng pivot thành các giá trị tương ứng với 1
                for (int j = 3; j < m; j++)
                {
                    matrix[pivot_row, j] /= matrix[pivot_row, pivot_col];
                }

                //gán giá trị các vị trí nếu nó khác hàng và cột pivot
                for (int j = 2; j < m; j++)
                    for (int i = 1; i < n - 1; i++)
                    {
                        if (!(i.Equals(pivot_row) || j.Equals(pivot_col)))
                        {
                            matrix[i, j] = matrix[i, j] - ((matrix[i, pivot_col] * matrix[pivot_row, j]) / matrix[pivot_row, pivot_col]);
                        }
                    }

                //Gán 0 cho a[i, cột] nếu nó khác hàng 
                for (int i = 1; i < n - 1; i++)
                {
                    if (!i.Equals(pivot_row)) matrix[i, pivot_col] = 0;
                }

                //


            exit_while: ;
            }//end-while
            /*
            MessageBox.Show("matrix_phase1 dc xuất ra ");
            for (int i = 0; i < n; i++)
                for (int j = 0; j < 3; j++)
                {

                    MessageBox.Show("matrix_phase1[" + i.ToString() + "," + j.ToString() + "]=" + matrix[i, j].ToString());
                }
             */
            
            return matrix;
        }
    }
}
