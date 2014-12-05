
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Drawing;
using System.Data.Common;


namespace DoAnTotNghiep
{
    class ketnoisql
    {
        public static SqlDataAdapter _dataAdapter;
        public static DataSet _dataSet;
        public static String cn = "Data Source=(local)\\SQLEXPRESS;Initial Catalog=DATN;User ID=sa;Password=123456";



        public static object ExecuteScalar(string sql)
        {
            using(SqlConnection con = new SqlConnection(cn))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteScalar();
                return cmd.ExecuteScalar();
            }
            
            
            
           
            //con.Close();
           
        }

        //Không trả về
        public static void ExecuteNonQuery(string sql)//, CommandType commandType)//, params object[] pars)
        {

            using (SqlConnection con = new SqlConnection(cn))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            //con.Close();
            //con.Dispose();
        }
        //Trả về data table DÁN LÊN DATAGRIDVIEW

        public static DataTable getDatabase(String sqlString, String Table, String dtg)
        {
            using (SqlConnection con = new SqlConnection(cn))
            {
                con.Open();
                _dataAdapter = new SqlDataAdapter(sqlString, cn);
                _dataSet = new DataSet();
                _dataAdapter.Fill(_dataSet, "\"" + Table + "\"");
                return _dataSet.Tables["\"" + Table + "\""];
            }
        }


        //Trả về data table KHÔNG DÁN LÊN DATAGRIDVIEW
        public static DataTable ExecuteDataTable(string sql)
        {
            using (SqlConnection con = new SqlConnection(cn))
            {
                con.Open();
                SqlDataAdapter dad = new SqlDataAdapter(sql, con);
                DataTable dtDataTable = new DataTable();
                dtDataTable.Clear();
                dad.Fill(dtDataTable);
                //dad.Disposed();
                //con.Close();

                return dtDataTable;

            }
           
        }
    }
}
