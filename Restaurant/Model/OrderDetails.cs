using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
<<<<<<< HEAD
=======
using System.Windows.Controls;
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
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
<<<<<<< HEAD
=======
        private int stt = 0;
        private double totalcost = 0;
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151

        public int Id { get => id; set => id = value; }
        public int IdDish { get => idDish; set => idDish = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public double Price { get => price; set => price = value; }
        public int IdBill { get => idBill; set => idBill = value; }
        public string NameDish { get => nameDish; set => nameDish = value; }
        public int IdOrder { get => idOrder; set => idOrder = value; }
<<<<<<< HEAD
=======
        public double Totalcost { get => totalcost; set => totalcost = value; }
        public int Stt { get => stt; set => stt = value; }
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151

        public OrderDetails() { }

        public OrderDetails(DataRow row)
        {
            this.Id = Int32.Parse(row["id"].ToString());
<<<<<<< HEAD
            this.IdDish = row["idDish"] == null ? 0 : Int32.Parse(row["idDish"].ToString());
            this.quantity = Int32.Parse(row["quantity"].ToString());
            this.Price = Double.Parse(row["price"].ToString());
            this.IdBill = 0;
            this.IdOrder = row["idOrder"] == null ? 0 : Int32.Parse(row["idOrder"].ToString());
            this.NameDish = dao.FindOneValue("getnameDishbyID", CommandType.StoredProcedure, new System.Data.SqlClient.SqlParameter("@id", idDish));
=======
            this.IdDish = row["idDish"]==null? 0: Int32.Parse(row["idDish"].ToString());
            this.quantity = Int32.Parse(row["quantity"].ToString());
            this.Price = Double.Parse(row["price"].ToString());
            
            this.IdBill =0;
            this.IdOrder =row["idOrder"]==null ?0: Int32.Parse(row["idOrder"].ToString());
            this.NameDish = dao.FindOneValue("getnameDishbyID", CommandType.StoredProcedure, new System.Data.SqlClient.SqlParameter("@id", idDish));
            //mới thêm
            this.totalcost = quantity * price;
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
        }

        public int getlastedId()
        {
            return Int32.Parse(dao.FindOneValue("getlastid", CommandType.StoredProcedure, new System.Data.SqlClient.SqlParameter("@table", "OrderDetail")));
        }

<<<<<<< HEAD
        public OrderDetails(int idDish, int idOrder, double price, int quantity)
        {

=======
        public OrderDetails( int idDish ,int idOrder, double price, int quantity)
        {
           
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
            this.IdDish = idDish;
            this.IdBill = 0;
            this.Price = price;
            this.Quantity = quantity;
            this.IdOrder = idOrder;
            DataTable a = dao.ExecuteQueryDataSet("SELECT name from Dishes where id='" + IdDish.ToString() + "'", CommandType.Text);
            this.NameDish = a.Rows[0]["name"].ToString();
<<<<<<< HEAD
        }

        public OrderDetails(int idDish, int idOrder, int idBill, double price, int quantity)
=======
            this.totalcost = Price * Quantity;
        }

        public OrderDetails(int idDish, int idOrder,int idBill, double price, int quantity)
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
        {
            // this.id = id;
            this.IdDish = idDish;
            this.IdBill = idBill;
            this.Price = price;
            this.Quantity = quantity;
            this.IdOrder = idOrder;
<<<<<<< HEAD
            this.NameDish = dao.FindOneValue("getnameDishbyID", CommandType.StoredProcedure, new System.Data.SqlClient.SqlParameter("@id", idDish));

        }
    }
}
=======
            this.NameDish = dao.FindOneValue("getnameDishbyID", CommandType.StoredProcedure, new System.Data.SqlClient.SqlParameter("@id",idDish));
            this.totalcost = Price * Quantity;
        }

       
    }
}
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
