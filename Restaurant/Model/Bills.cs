using System;
using System.Collections.Generic;
<<<<<<< HEAD
=======
using System.Data;
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Model
{
    public enum stateBill
    {
        spending,
        finish
    }

<<<<<<< HEAD
    class Bills
=======
    public class Bills
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
    {
        public Bills()
        {

        }

<<<<<<< HEAD
        private int id;
=======
        public Bills(DataRow row)
        {
            // Bills b = new Bills();

            this.Id = Convert.ToInt32(row[0]);


            this.NameCus = row[2].ToString();
            this.NameEmp = row[1].ToString();
            this.Quantity = Convert.ToInt32(row[3].ToString());
            this.TimePayment = DateTime.Parse(row[4].ToString());
            this.Deal = Convert.ToInt32(row[5]);
            this.TotalCost = Convert.ToInt32(row[6]);
            this.State = (stateBill)Convert.ToInt32(row[7]);
            this.LoyalFriend = Convert.ToInt32(row[8]);
        }
        private string nameEmp;
        private string nameCus;
        private int quantity;

        private int id;
        private int idOrder;
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
        private DateTime timePayment;
        private double deal;
        private double totalCost;
        private string totalcoststring;
        private stateBill state;
        private double loyalFriend;

        public int Id { get => id; set => id = value; }
<<<<<<< HEAD
=======
        public int IdOrder { get => idOrder; set => idOrder = value; }
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
        public DateTime TimePayment { get => timePayment; set => timePayment = value; }
        public double Deal { get => deal; set => deal = value; }
        public double TotalCost { get => totalCost; set => totalCost = value; }
        public stateBill State { get => state; set => state = value; }
        public double LoyalFriend { get => loyalFriend; set => loyalFriend = value; }
        public string Totalcoststring { get => totalcoststring; set => totalcoststring = value; }
<<<<<<< HEAD
=======
        public string NameEmp { get => nameEmp; set => nameEmp = value; }
        public string NameCus { get => nameCus; set => nameCus = value; }
        public int Quantity { get => quantity; set => quantity = value; }
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
    }
}
