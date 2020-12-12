using System;
<<<<<<< HEAD
using System.Collections;
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
=======
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
namespace Restaurant.Controller
{
    class orderController
    {
<<<<<<< HEAD
        DAO dao = new DAO();
        public bool addOrder(int idSeat, int idEmp)
        {
            SqlParameter IdSeat = new SqlParameter("@idSeat", idSeat);
            SqlParameter IdEmp = new SqlParameter("@idEmp",idEmp );
            List<SqlParameter> t = new List<SqlParameter>();
            t.Add(IdSeat);
            t.Add(IdEmp);
            return dao.MyExecuteNonQuery("addOrder", CommandType.StoredProcedure, t);
        }
        public Orders getLastOrder()
        {
            DataTable data;
            data = dao.ExecuteQueryDataSet("getLastOrder",CommandType.StoredProcedure);
            Orders temp = new Orders();
            temp.Id= int.Parse(data.Rows[0][0].ToString());
            temp.IdSeat=int.Parse(data.Rows[0][1].ToString());
            temp.IdEmp= int.Parse(data.Rows[0][2].ToString());
            temp.TimeOrder=DateTime.Parse(data.Rows[0][4].ToString());
            return temp;
        }
        public Orders GetOrders(int idSeat)
        {
            DataTable data;
            SqlParameter IdSeat = new SqlParameter("@idSeat", idSeat);
            List<SqlParameter> t = new List<SqlParameter>();
            t.Add(IdSeat);
            data = dao.ExecuteQueryDataSet("GetOrders", CommandType.StoredProcedure,t);
            if(data.Rows.Count>0 && data!=null)
            {
                Orders temp = new Orders();
                temp.Id = int.Parse(data.Rows[0][0].ToString());
                temp.IdSeat = int.Parse(data.Rows[0][1].ToString());
                temp.IdEmp = int.Parse(data.Rows[0][2].ToString());
                temp.IdCus = int.Parse(data.Rows[0][3].ToString());
                temp.TimeOrder = DateTime.Parse(data.Rows[0][4].ToString());
                return temp;
            }
            return null;
        }
        public void check_Orderdetail()
        {
            dao.MyExecuteNonQuery("check_Orderdetail", CommandType.StoredProcedure);
        }
        //cập nhập lại idCustomer khi nhấn vào bếp(nếu ó thể thì sửa chỗ này cho ok hơn)
        /// <summary>
        /// ///////
        /// </summary>
        /// <param name="idCustomer"></param>
        /// <param name="idOrder"></param>
        public void updateCustomerOrder(String phone)
        {
            SqlParameter Phone = new SqlParameter("@phone", phone);
            List<SqlParameter> t = new List<SqlParameter>();
            t.Add(Phone);
            dao.MyExecuteNonQuery("updateCustomerOrder", CommandType.StoredProcedure, t);
        }
=======
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
    }
}
