using System;
using System.Collections;
using System.Collections.Generic;
<<<<<<< HEAD
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
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Model;
using System.Collections.ObjectModel;
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
namespace Restaurant.Controller
{
    public class orderdetailController
    {
        DAO dao = new DAO();

<<<<<<< HEAD
        public ObservableCollection<OrderDetails> getOrderDetailBySeatId(int id)
        {
            SqlParameter Id = new SqlParameter("@id", id);
            List<SqlParameter> t = new List<SqlParameter>();
            t.Add(Id);
            DataTable data = dao.ExecuteQueryDataSet("getOrderDetailBySeatId", CommandType.StoredProcedure, t);
            //tạo 1 list để luwu trữ dữ liệu lấy từ database
            ObservableCollection<OrderDetails> list = new ObservableCollection<OrderDetails>();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                OrderDetails a = new OrderDetails();
                a.IdDish = int.Parse(data.Rows[i][0].ToString());
                a.Quantity = int.Parse(data.Rows[i][1].ToString());
                a.IdOrder= int.Parse(data.Rows[i][2].ToString());
                list.Add(a);
            }
            return list;
        }
        public void updateOrderDetail(int idDish,int quantity,int idOrder)
        {
            SqlParameter IdDish = new SqlParameter("@idDish", idDish);
            SqlParameter Quantity = new SqlParameter("@quantity", quantity);
            SqlParameter IdOrder = new SqlParameter("@idOrder", idOrder);
            List<SqlParameter> t = new List<SqlParameter>();
            t.Add(IdDish);
            t.Add(Quantity);
            t.Add(IdOrder);
            dao.MyExecuteNonQuery("updateOrderDetail", CommandType.StoredProcedure, t);
        }
        public void addItemOrderDetail(int idDish, int quantity, int idOrder)
        {
            SqlParameter IdDish = new SqlParameter("@idDish", idDish);
            SqlParameter Quantity = new SqlParameter("@quantity", quantity);
            SqlParameter IdOrder = new SqlParameter("@idOrder", idOrder);
            List<SqlParameter> t = new List<SqlParameter>();
            t.Add(IdDish);
            t.Add(Quantity);
            t.Add(IdOrder);
            dao.MyExecuteNonQuery("addItemOrderDetail", CommandType.StoredProcedure, t);
        }
        public void deleteOrderDetail(int idOrder)
        {
            SqlParameter IdOrder = new SqlParameter("@idOrder", idOrder);
            List<SqlParameter> t = new List<SqlParameter>();
            t.Add(IdOrder);
            dao.MyExecuteNonQuery("deleteOrderDetail", CommandType.StoredProcedure, t);
        }
        /////////////////
        ////////////////
        /////Phaần của Hoàng
        ////////////////
        ///
        public bool addOrderDetail(int idDish, int idOrder, double price, int quantity)
        {
            OrderDetails ord = new OrderDetails();
            // int id = ord.getlastedId();
            string[] vars = { "@idOrder", "@idDish", "@price", "@quantity" };
            ArrayList array = new ArrayList(new Object[] { idOrder, idDish, price, quantity });
=======
        public bool addOrderDetail(int idDish, int idOrder, double price, int quantity)
        {
            OrderDetails ord = new OrderDetails();
           // int id = ord.getlastedId();
            string[] vars = {  "@idOrder", "@idDish", "@price", "@quantity"};
            ArrayList array = new ArrayList(new Object[] {idOrder, idDish, price, quantity });
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151

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
<<<<<<< HEAD
        public ObservableCollection<OrderDetails> loadlistOrderDetail(int idOrder)
        {
            DataTable data = dao.MyExecuteNonQuery_data("getDishesofaOrder", CommandType.StoredProcedure, new List<SqlParameter>() { new SqlParameter("@idorder", idOrder) });
            if (data == null)
=======
        public ObservableCollection<OrderDetails> loadlistOrderDetail (int idOrder)
        {
            DataTable data= dao.MyExecuteNonQuery_data("getDishesofaOrder",CommandType.StoredProcedure,new List<SqlParameter>() {new SqlParameter("@idorder",idOrder) });
            if (data ==null)
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
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
<<<<<<< HEAD
            if (data != null)
=======
            if (data!=null)
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
            {
                Customers cus = new Customers(data.Rows[0]);
                return cus;
            }
            return null;
        }

<<<<<<< HEAD
        public bool updateOrderdetail(int id, int quantity)
        {
            return (dao.MyExecuteNonQuery("updatequantityOrder", CommandType.StoredProcedure, new List<SqlParameter>() { new SqlParameter("@id", id), new SqlParameter("@quantity", quantity) }));
=======
        public bool updateOrderdetail(int id,int quantity )
        {
            return (dao.MyExecuteNonQuery("updatequantityOrder", CommandType.StoredProcedure, new List<SqlParameter>() { new SqlParameter("@id", id), new SqlParameter("@quantity", quantity) })) ;
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
        }
        /// <summary>
        /// Kiểm tra xem món đã đường lưu trong orderdetail hay chưa.
        /// </summary>
        /// <param name="idDish"></param>
        /// <param name="idOder"></param>
        /// <returns></returns>
<<<<<<< HEAD
        public bool checkexistDish(int idDish, int idOrder)
        {
            DataTable a = dao.MyExecuteNonQuery_data("checkexistDish", CommandType.StoredProcedure, new List<SqlParameter>() { new SqlParameter("@idDish", idDish), new SqlParameter("@idOrder", idOrder) });
=======
        public bool checkexistDish (int idDish, int idOrder)
        {
            DataTable a=  dao.MyExecuteNonQuery_data("checkexistDish", CommandType.StoredProcedure, new List<SqlParameter>() { new SqlParameter("@idDish", idDish), new SqlParameter("@idOrder", idOrder) });
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
            if (a == null)
                return false;
            return true;
        }

        public int getQuantity(int idDish, int idOrder)
        {
<<<<<<< HEAD
            DataTable a = dao.MyExecuteNonQuery_data("getQuantity", CommandType.StoredProcedure, new List<SqlParameter>() { new SqlParameter("@idDish", idDish), new SqlParameter("@idOrder", idOrder) });
            int t = Int32.Parse(a.Rows[0]["quantity"].ToString());
            return t;
        }
    }
}
=======
            DataTable a = dao.MyExecuteNonQuery_data("getQuantity", CommandType.StoredProcedure, new List<SqlParameter>() { new SqlParameter("@idDish",idDish), new SqlParameter("@idOrder",idOrder)});
            int t = Int32.Parse(a.Rows[0]["quantity"].ToString());
            return t;
        }

    }
}
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
