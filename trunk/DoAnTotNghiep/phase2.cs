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
    class phase2
    {
        public static double calculateBelPl(double[,] a, int bel_pl)
        {
            //biến chứa kết quả
            double fx = 0;
            //ma trận nhận được
            double[,] matrix_phase2 = a;

            //số dòng
            int n = matrix_phase2.GetLength(0);//8 lấy dòng
            //số cột
            int m = matrix_phase2.GetLength(1);//14 -3 lấy cột
            //MessageBox.Show("matrix_phase2[6,0]=" + matrix_phase2[6, 0].ToString());
            /*
            MessageBox.Show(" ma trận vào tính fx ");
            for (int i = 0; i < matrix_phase2.GetLength(0); i++)
            {
                for (int j = 0; j < matrix_phase2.GetLength(1); j++)
                {
                    MessageBox.Show("matrix_phase2[" + i.ToString() + "][" + j.ToString() + "]=" + matrix_phase2[i, j]);
                }
            }
             */
            //dấu hiệu max hay min
            int min_max = bel_pl;
            //MessageBox.Show(min_max.ToString());

            int dem = 1;
            //Đặt biến dừng
            bool stop = false;
            while (!stop)//nếu stop = true thì thoát vòng lặp
            {

                //Tính fx và các giá trị delta

                for (int j = 2; j < m; j++)
                {
                    double tong = 0;
                    for (int i = 1; i < n - 1; i++)
                    {
                        tong = tong + matrix_phase2[i, 0] * matrix_phase2[i, j];

                    }
                    if (j == 2) matrix_phase2[n - 1, j] = tong;
                    else
                    {
                        if (min_max == 0) matrix_phase2[n - 1, j] = tong - matrix_phase2[0, j] ;
                        else matrix_phase2[n - 1, j] = matrix_phase2[0, j] - tong;
                    }
                }
               // MessageBox.Show("lần " + dem.ToString());
                dem++;










                //Kiểm tra delta
                //Kiểm tra giá trị delta xem: nếu tồn tại 1 delta>0 mà mọi aij < 0 thì break,
                //nếu mọi delta < hoặc = 0 mà còn ẩn giả != 0 thì vô nghiệm, bài toán này sẽ không còn ẩn phụ
                for (int j = 3; j < m; j++)
                {
                    if (min_max == 0)
                    {
                        if (matrix_phase2[n - 1, j] > 0)
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
                                MessageBox.Show("bi false so 1 pha 2");
                                formAnalyze.resurtGetBelPl = false;// vô nghiệm
                                goto exit_while;
                            }

                            goto continue_while;// Nếu có 1 cột delta > 0  và không bị điều kiện mọi cột < 0 thì nhảy tới phần biến đổi tiếp
                        }
                    }

                    else
                    {// Bài toán max, nếu tồn tại 1 delta > 0 ta xét tiếp
                        if (matrix_phase2[n - 1, j] > 0)
                        {
                            //Nếu mọi hàng của cột delta này mà < 0 hết thì vô nghiệm
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
                                MessageBox.Show("bi false so 2 pha 2");
                                formAnalyze.resurtGetBelPl = false;// vô nghiệm
                                goto exit_while;
                            }

                            goto continue_while;// Nếu có 1 cột delta > 0  và không bị điều kiện mọi cột < 0 thì nhảy tới phần biến đổi tiếp
                        }
                    }


                }


                //tính fx, tới đây thì mọi delta đã thực sự <= 0, nếu có 1 delta >0 thì nó đã goto tới nhãn
                //Nên ta đã hoàn thành vòng lặp while
                stop = true;
                formAnalyze.resurtGetBelPl = true;//khẳng định có nghiệm
                fx = matrix_phase2[n - 1, 2];
                goto exit_while;
            continue_while:
                //Tìm pivot cột
                int pivot_col = 0;
                pivot_col = 3;// lấy vị trí cột là địa chỉ delta đầu tiên
                if (min_max == 0)//Tính max là bao nhiêu nằm tại vị trí trí nào trên ma trận a với bài toán tìm min
                {

                    double max_delta = matrix_phase2[n - 1, 3];
                    pivot_col = 3;
                    //MessageBox.Show(max_delta.ToString());
                    for (int j = 3; j < m; j++)
                    {
                        if (max_delta < matrix_phase2[n - 1, j])
                        {

                            max_delta = matrix_phase2[n - 1, j];
                            pivot_col = j;

                        }
                    }
                    //MessageBox.Show(pivot_col.ToString());
                }
                else
                {   //Bài toán max thì ta tìm delta max làm vị trí cột
                    double max_delta = matrix_phase2[n - 1, 3];
                    pivot_col = 3;

                    for (int j = 3; j < m; j++)
                    {
                        if (max_delta < matrix_phase2[n - 1, j])
                        {

                            max_delta = matrix_phase2[n - 1, j];
                            pivot_col = j;

                        }
                    }
                }

                //Tìm pivot_row

                int element = 0;// tìm số phần tử >0 để tạo mảng

                for (int i = 1; i < n - 1; i++)
                {
                    if (matrix_phase2[i, pivot_col] > 0)
                    {
                        element++;
                    }
                }

                // tạo 2 mảng lưu kết quả đã chia và lưu vị trí hàng đó
                double[] min = new double[element];
                int[] position = new int[element];
                element = 0;
                for (int i = 1; i < n - 1; i++)
                {
                    if (matrix_phase2[i, pivot_col] > 0)
                    {
                        position[element] = i;
                        min[element] = matrix_phase2[i, 2] / matrix_phase2[i, pivot_col];
                        element++;
                    }
                }

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

                //Hoán đổi
                //Hoán đổi hàng tại vị trí min
                //đổi giá trị cj xuống hệ số
                matrix_phase2[pivot_row, 0] = matrix_phase2[0, pivot_col];
                matrix_phase2[pivot_row, 1] = pivot_col;
                //đổi giá trị cột tại hàng pivot thành các giá trị tương ứng với 1
                for (int j = 3; j < m; j++)
                {
                    matrix_phase2[pivot_row, j] /= matrix_phase2[pivot_row, pivot_col];
                }

                //gán giá trị các vị trí nếu nó khác hàng và cột pivot
                for (int j = 2; j < m; j++)
                    for (int i = 1; i < n - 1; i++)
                    {
                        if (!(i.Equals(pivot_row) || j.Equals(pivot_col)))
                        {
                            matrix_phase2[i, j] = matrix_phase2[i, j] - ((matrix_phase2[i, pivot_col] * matrix_phase2[pivot_row, j]) / matrix_phase2[pivot_row, pivot_col]);
                        }
                    }

                //Gán 0 cho a[i, cột] nếu nó khác hàng 
                for (int i = 1; i < n - 1; i++)
                {
                    if (!i.Equals(pivot_row)) matrix_phase2[i, pivot_col] = 0;
                }
            exit_while: ;
            }//END WHILE
            /*
            MessageBox.Show("matrix_phase2_phase2_resurt ");
            for (int i = 0; i < n; i++)
                for (int j = 0; j < 5; j++)
                {

                    MessageBox.Show("matrix_phase2[" + i.ToString() + "," + j.ToString() + "]=" + matrix_phase2[i, j].ToString());
                }
             */
            /*
            MessageBox.Show("Kết quả ma trận khi tính fx ");
            for (int i = 4; i < 7; i++)
                for (int j = 0; j < 3; j++)
                {

                    MessageBox.Show("matrix_phase2[" + i.ToString() + "," + j.ToString() + "]=" + matrix_phase2[i, j].ToString());
                }*/
            //MessageBox.Show("fx = " + fx.ToString());
            return fx;
        }
    }
}
