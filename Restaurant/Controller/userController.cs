using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using Restaurant.Model;

namespace Restaurant.Controller
{
    class userController
    {
        DAO DAO = new DAO();

        //Kiểm tra có tồn tại tài khoản khi đăng nhập hay không
        public bool checkAccount(String userName, String passWord)
        {
            SqlParameter UserName = new SqlParameter("@userName", userName);
            SqlParameter Password = new SqlParameter("@passWord", passWord);
            List<SqlParameter> CheckAcc = new List<SqlParameter>();
            CheckAcc.Add(UserName);
            CheckAcc.Add(Password);
            DataTable a = DAO.ExecuteQueryDataSet("checkAccount", CommandType.StoredProcedure, CheckAcc);
            if (a.Rows.Count > 0)
                return true;
            return false;
        }

        //lấy phân quyền của tài khoản
        public bool getLevelAccount(String userName, String passWord)
        {
            SqlParameter UserName = new SqlParameter("@userName", userName);
            SqlParameter Password = new SqlParameter("@passWord", passWord);
            List<SqlParameter> CheckAcc = new List<SqlParameter>();
            CheckAcc.Add(UserName);
            CheckAcc.Add(Password);
            DataTable a = DAO.ExecuteQueryDataSet("getLevelAccount", CommandType.StoredProcedure, CheckAcc);
            if (a.Rows.Count > 0)
            {
                return true;//nhân viên
            }

            return false;//chủ
        }
    }
}
