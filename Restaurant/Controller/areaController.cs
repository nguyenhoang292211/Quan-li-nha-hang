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
    class areaController
    {
        DAO DAO = new DAO();
        //hàm lấy dữ liệu từ database đổ lên
        public ObservableCollection<Area> loadArea()
        {
            DataTable data = DAO.ExecuteQueryDataSet("Select * from Area", CommandType.Text);
            //tạo 1 list để luwu trữ dữ liệu lấy từ database
            ObservableCollection<Area> list = new ObservableCollection<Area>();
            for (int i = 0; i < data.Rows.Count; i++)
            {

                Area a = new Area();
                a.IdArea= int.Parse(data.Rows[i][0].ToString());
                a.NameArea= data.Rows[i][1].ToString();
                a.AmountTable= int.Parse(data.Rows[i][2].ToString());
                list.Add(a);
            }
            return list;
        }
    }
}
