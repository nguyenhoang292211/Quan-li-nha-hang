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
                list.Add( new OrderDetails(data.Rows[i]));
            }
            return list;
        }
        /// <summary>
        /// Cập nhật đơn khi đơn đó chưa thanh toán
        /// </summary>
        /// <param name="idDish"></param>
        /// <param name="quantity"></param>
        /// <param name="idOrder"></param>
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

        /// <summary>
        /// cập nhật lại số lượng món trong bản orderDetail khi bàn đó chưa thanh toán
        /// </summary>
        /// <param name="id"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public bool updateOrderdetail(int id,int quantity )
        {
            return (dao.MyExecuteNonQuery("updatequantityOrder", CommandType.StoredProcedure, new List<SqlParameter>() { new SqlParameter("@id", id), new SqlParameter("@quantity", quantity) })) ;

        }
        /// <summary>
        /// Kiểm tra xem món đã được lưu trong orderdetail hay chưa.
        /// </summary>
        /// <param name="idDish"></param>
        /// <param name="idOder"></param>

        public bool checkexistDish (int idDish, int idOrder)
        {
            DataTable a = dao.MyExecuteNonQuery_data("select  dbo.fn_getQuantityDish(@idDish, @idOrder) as Quantity", CommandType.Text, new List<SqlParameter>() { new SqlParameter("@idDish", idDish), new SqlParameter("@idOrder", idOrder) });
            if (a.Rows[0]["Quantity"].ToString() == "")
                return false;
            return true;
        }


        public int getQuantity(int idDish, int idOrder)
        {
           DataTable a = dao.MyExecuteNonQuery_data("select  dbo.fn_getQuantityDish(@idDish, @idOrder) as Quantity", CommandType.Text, new List<SqlParameter>() { new SqlParameter("@idDish", idDish), new SqlParameter("@idOrder", idOrder) });
            int t = Int32.Parse(a.Rows[0]["Quantity"].ToString());
            return t;
        }

        public float getPercentDiscount (int idevent)
        {
            DataTable a = dao.MyExecuteNonQuery_data("select  dbo.fn_getDiscountpercent(@idEvent) as percents", CommandType.Text, new List<SqlParameter>() { new SqlParameter("@idEvent", idevent) });
            float t = float.Parse(a.Rows[0]["percents"].ToString());
            return t;
        }
    }
}

