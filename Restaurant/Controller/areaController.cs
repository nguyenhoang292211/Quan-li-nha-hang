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
<<<<<<< HEAD
        //hàm lấy giá trị id đầu tiên
        public String GetFirstIDArea()
        {
            DataTable a = DAO.ExecuteQueryDataSet("Select * from Area", CommandType.Text);
            if (a.Rows.Count == 0) return null;
            return a.Rows[0][0].ToString();
        }
        //hàm lấy giá trị nameArea đầu tiên
        public String GetFirstNameArea()
        {
            DataTable a = DAO.ExecuteQueryDataSet("Select * from Area", CommandType.Text);
            if (a.Rows.Count == 0) return null;
            return a.Rows[0][1].ToString();
        }
        //hàm chỉnh sửa tên của một area
        public void editAreaName(int idArea, string nameArea)
        {
            SqlParameter id = new SqlParameter("@idArea", idArea);
            SqlParameter name = new SqlParameter("@nameArea", nameArea);
            List<SqlParameter> t = new List<SqlParameter>();
            t.Add(id);
            t.Add(name);
            DAO.MyExecuteNonQuery("editAreaName", CommandType.StoredProcedure, t);
        }

        public Area getAreaByID(int id)
        {
            string str = "Select * from Area where id=" + id.ToString();
             DataTable a= DAO.ExecuteQueryDataSet(str,CommandType.Text);
            Area b = new Area((int)a.Rows[0][0],a.Rows[0][1].ToString());
            return b;
        }
=======
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
    }
}
