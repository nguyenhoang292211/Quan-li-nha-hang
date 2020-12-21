using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Controls;
using Restaurant.Controller;
namespace Restaurant.Model
{
    public class OrderDetails
    {
        DAO dao = new DAO();
        private int id;
        private int idDish;
        private int idBill;
        private int quantity;
        private double price;
        private string nameDish;
        private int idOrder;

        private int stt = 0;
        private double totalcost = 0;

        public int Id { get => id; set => id = value; }
        public int IdDish { get => idDish; set => idDish = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public double Price { get => price; set => price = value; }
        public int IdBill { get => idBill; set => idBill = value; }
        public string NameDish { get => nameDish; set => nameDish = value; }
        public int IdOrder { get => idOrder; set => idOrder = value; }
        public double Totalcost { get => totalcost; set => totalcost = value; }
        public int Stt { get => stt; set => stt = value; }

        public OrderDetails() { }

        public OrderDetails(DataRow row)
        {
            this.Id = Int32.Parse(row["id"].ToString());
            this.IdDish = row["idDish"] == null ? 0 : Int32.Parse(row["idDish"].ToString());
            this.quantity = Int32.Parse(row["quantity"].ToString());
            this.Price = Double.Parse(row["price"].ToString());

            this.IdBill = 0;
            this.IdOrder = row["idOrder"] == null ? 0 : Int32.Parse(row["idOrder"].ToString());
            this.NameDish = dao.FindOneValue("getnameDishbyID", CommandType.StoredProcedure, new System.Data.SqlClient.SqlParameter("@id", idDish));
            //mới thêm
            this.totalcost = quantity * price;
        }

        public int getlastedId()
        {
            return Int32.Parse(dao.FindOneValue("getlastid", CommandType.StoredProcedure, new System.Data.SqlClient.SqlParameter("@table", "OrderDetail")));
        } 
        public OrderDetails( int idDish ,int idOrder, double price, int quantity)
        {
                       this.IdDish = idDish;
            this.IdBill = 0;
            this.Price = price;
            this.Quantity = quantity;
            this.IdOrder = idOrder;
            DataTable a = dao.ExecuteQueryDataSet("SELECT name from Dishes where id='" + IdDish.ToString() + "'", CommandType.Text);
            this.NameDish = a.Rows[0]["name"].ToString();
        
            this.totalcost = Price * Quantity;
        }

        public OrderDetails(int idDish, int idOrder,int idBill, double price, int quantity)
        {
            // this.id = id;
            this.IdDish = idDish;
            this.IdBill = idBill;
            this.Price = price;
            this.Quantity = quantity;
            this.IdOrder = idOrder;
            this.NameDish = dao.FindOneValue("getnameDishbyID", CommandType.StoredProcedure, new System.Data.SqlClient.SqlParameter("@id",idDish));
            this.totalcost = Price * Quantity;
        }

       
    }
}
