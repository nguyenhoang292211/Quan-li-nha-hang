using System;
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

namespace Restaurant.Controller
{
    class orderController
    {
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
        /// <summary>
        /// Lấy order mới nhất
        /// </summary>
        /// <returns></returns>
        public Orders getLastOrder()
        {
            DataTable data;
            data = dao.ExecuteQueryDataSet("getLastOrder",CommandType.StoredProcedure);
            return new Orders(data.Rows[0]);
        }

        /// <summary>
        /// Lấy order bằng id bàn
        /// </summary>
        /// <param name="idSeat"></param>
        /// <returns></returns>
        public Orders GetOrders(int idSeat)
        {
            DataTable data;
            SqlParameter IdSeat = new SqlParameter("@idSeat", idSeat);
            List<SqlParameter> t = new List<SqlParameter>();
            t.Add(IdSeat);
            data = dao.ExecuteQueryDataSet("GetOrders", CommandType.StoredProcedure,t);
            if(data.Rows.Count>0 && data!=null)
            {
                Orders temp = new Orders(data.Rows[0]);              
                return temp;
            }
            return null;
        }

        /// <summary>
        /// Nếu tồn tại một order trước đó chưa đặt món thì xóa order đó trước
        /// </summary>
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


    }
}
