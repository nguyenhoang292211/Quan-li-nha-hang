using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace Restaurant.Model
{
    public class DAO
    {
        public static string username;
        public static string password;

        //string ConnStr = @"Data Source=DESKTOP-L9FILE2\SQLEXPRESS;Initial Catalog=ManagementRestaurant;Integrated Security=False;userid=" + username + ";password=" + password + ";";
        SqlConnection conn = null;
        SqlCommand comm = null;
        SqlDataAdapter da = null;
        public DAO(string userName, string passWord)
        {
            username = userName;
            password = passWord;
            string ConnStr = @"Data Source=DESKTOP-S3G5KIT\SQLEXPRESS;Initial Catalog=ManagementRestaurant;Integrated Security=False;User Id=" + username + ";password=" + password + ";";
            conn = new SqlConnection(ConnStr);
            comm = conn.CreateCommand();
        }
        public DAO()
        {
            string ConnStr = @"Data Source=DESKTOP-S3G5KIT\SQLEXPRESS;Initial Catalog=ManagementRestaurant;Integrated Security=True";
            conn = new SqlConnection(ConnStr);
            comm = conn.CreateCommand();
            
        } 
            public DataTable ExecuteQueryDataSet(string strSQL, CommandType ct)
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
            comm.Parameters.Clear();
            conn.Open();
            comm.CommandText = strSQL;
            comm.CommandType = ct;
            da = new SqlDataAdapter(comm);
            DataTable ds = new DataTable();
            da.Fill(ds);
            return ds;
        }

        public DataTable ExecuteQueryDataSet(string strSQL, CommandType ct, List<SqlParameter> para)
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
            comm.CommandText = strSQL;
            comm.CommandType = ct;
            comm.Parameters.Clear();
            foreach (SqlParameter iParamater in para)
                comm.Parameters.Add(iParamater);

            da = new SqlDataAdapter(comm);
            //   da = comm.ExecuteQ
            DataTable ds = new DataTable();
            da.Fill(ds);



            return ds;
        }

        public bool MyExecuteNonQuery(string strSQL, CommandType ct, List<SqlParameter> param)
        {
            bool f = false;
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
            comm.Parameters.Clear();
            comm.CommandText = strSQL;
            comm.CommandType = ct;
            foreach (SqlParameter p in param)
                comm.Parameters.Add(p);
            try
            {
                comm.ExecuteNonQuery();
                f = true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            finally
            {
                conn.Close();
            }

            return f;
        }

        public bool MyExecuteNonQuery(string strSQL, CommandType ct)
        {
            bool f = false;
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
            comm.Parameters.Clear();
            comm.CommandText = strSQL;
            comm.CommandType = ct;
            try
            {
                comm.ExecuteNonQuery();
                f = true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            finally
            {
                conn.Close();
            }

            return f;
        }

        public string FindOneValue(string strSQL, CommandType ct, SqlParameter parameter)
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
            comm.Parameters.Clear();
            comm.CommandText = strSQL;
            comm.CommandType = ct;
            comm.Parameters.Add(parameter);
            try
            {
                da = new SqlDataAdapter(comm);
                DataTable ds = new DataTable();
                da.Fill(ds);
                if (ds.Rows.Count == 0) return "";
                else
                    return ds.Rows[0][0].ToString();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }

            finally
            {
                conn.Close();
            }
        }

        public DataTable MyExecuteNonQuery_data(string strSQL, CommandType ct, List<SqlParameter> param)
        {
            bool f = false;
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
            comm.Parameters.Clear();
            comm.CommandText = strSQL;
            comm.CommandType = ct;
            foreach (SqlParameter p in param)
                comm.Parameters.Add(p);
            try
            {
                da = new SqlDataAdapter(comm);
                DataTable ds = new DataTable();
                da.Fill(ds);
                if (ds.Rows.Count == 0) return null;
                else
                    return ds;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }

            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Đưa vào một list các biến và chuỗi các @bien tạo thanh list <sqlparameter>
        /// </summary>
        /// <param name="array"></param>
        /// <param name="vars"></param>
        /// <returns></returns>
        public List<SqlParameter> turntoListParam(ArrayList array, string[] vars)
        {
            List<SqlParameter> list = new List<SqlParameter>();

            for (int i = 0; i < vars.Length; i++)
            {
                SqlParameter parameter = new SqlParameter(vars[i], array[i]);
                list.Add(parameter);
            }

            return list;
        }

        
    }

}
