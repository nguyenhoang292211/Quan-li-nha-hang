using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Model;
using System.Collections.ObjectModel;
namespace Restaurant.Controller
{
    public class orderdetailController
    {
        DAO dao = new DAO();

        public bool addOrderDetail(int idDish, int idOrder, double price, int quantity)
        {
            OrderDetails ord = new OrderDetails();
           // int id = ord.getlastedId();
            string[] vars = {  "@idOrder", "@idDish", "@price", "@quantity"};
            ArrayList array = new ArrayList(new Object[] {idOrder, idDish, price, quantity });

            List<SqlParameter> t = dao.turntoListParam(array, vars);

            if (dao.MyExecuteNonQuery("addOrderDetail", CommandType.StoredProcedure, t))
                return true;
            return false;
        }
        /// <summary>
        /// Tìm lại các món đã được đặt ở bàn này
        /// </summary>
        /// <param name="idOrder"></param>
        /// <returns></returns>
        public ObservableCollection<OrderDetails> loadlistOrderDetail (int idOrder)
        {
            DataTable data= dao.MyExecuteNonQuery_data("getDishesofaOrder",CommandType.StoredProcedure,new List<SqlParameter>() {new SqlParameter("@idorder",idOrder) });
            if (data ==null)
                return null;
            ObservableCollection<OrderDetails> orderlist = new ObservableCollection<OrderDetails>();
            foreach (DataRow row in data.Rows)
            {
                OrderDetails order = new OrderDetails(row);
                orderlist.Add(order);
            }
            return orderlist;
        }

        public Customers findCusByid(int id)
        {
            DataTable data = dao.MyExecuteNonQuery_data("getCustomerByID", CommandType.StoredProcedure, new List<SqlParameter>() { new SqlParameter("@id", id) });
            if (data!=null)
            {
                Customers cus = new Customers(data.Rows[0]);
                return cus;
            }
            return null;
        }

        public bool updateOrderdetail(int id,int quantity )
        {
            return (dao.MyExecuteNonQuery("updatequantityOrder", CommandType.StoredProcedure, new List<SqlParameter>() { new SqlParameter("@id", id), new SqlParameter("@quantity", quantity) })) ;
        }
        /// <summary>
        /// Kiểm tra xem món đã đường lưu trong orderdetail hay chưa.
        /// </summary>
        /// <param name="idDish"></param>
        /// <param name="idOder"></param>
        /// <returns></returns>
        public bool checkexistDish (int idDish, int idOrder)
        {
            DataTable a=  dao.MyExecuteNonQuery_data("checkexistDish", CommandType.StoredProcedure, new List<SqlParameter>() { new SqlParameter("@idDish", idDish), new SqlParameter("@idOrder", idOrder) });
            if (a == null)
                return false;
            return true;
        }

        public int getQuantity(int idDish, int idOrder)
        {
            DataTable a = dao.MyExecuteNonQuery_data("getQuantity", CommandType.StoredProcedure, new List<SqlParameter>() { new SqlParameter("@idDish",idDish), new SqlParameter("@idOrder",idOrder)});
            int t = Int32.Parse(a.Rows[0]["quantity"].ToString());
            return t;
        }

    }
}
