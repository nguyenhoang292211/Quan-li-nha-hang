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
    class billController
    {
        DAO DAO = new DAO();
        //hàm lấy dữ liệu từ database đổ lên
        public ObservableCollection<Bills> loadBill()
        {
            DataTable data = DAO.ExecuteQueryDataSet("Select * from Bill", CommandType.Text);
            //tạo 1 list để luwu trữ dữ liệu lấy từ database
            ObservableCollection<Bills> list = new ObservableCollection<Bills>();
            for (int i = 0; i < data.Rows.Count; i++)
            {

                Bills a = new Bills();
                a.Id = int.Parse(data.Rows[i][0].ToString());
              //  a.IdOrder = int.Parse(data.Rows[i][2].ToString());
                a.TimePayment = DateTime.Parse(data.Rows[i][1].ToString());
                a.Deal = double.Parse(data.Rows[i][2].ToString());
                a.TotalCost = double.Parse(data.Rows[i][3].ToString());
                a.Totalcoststring = a.TotalCost.ToString() + " VND";
                if (data.Rows[i][7].ToString() == "True")
                {
                    a.State = stateBill.finish;
                }
                else if (data.Rows[i][7].ToString() == "False")
                {
                    a.State = stateBill.spending;
                }
                a.LoyalFriend = int.Parse(data.Rows[i][7].ToString());
                list.Add(a);
            }
            return list;
        }
    }
}
