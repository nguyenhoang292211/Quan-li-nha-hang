using System;
using System.Collections.Generic;
using System.Data;
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

    public class Bills
    {
        public Bills()
        {

        }

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
        private DateTime timePayment;
        private double deal;
        private double totalCost;
        private string totalcoststring;
        private stateBill state;
        private double loyalFriend;

        public int Id { get => id; set => id = value; }
        public int IdOrder { get => idOrder; set => idOrder = value; }
        public DateTime TimePayment { get => timePayment; set => timePayment = value; }
        public double Deal { get => deal; set => deal = value; }
        public double TotalCost { get => totalCost; set => totalCost = value; }
        public stateBill State { get => state; set => state = value; }
        public double LoyalFriend { get => loyalFriend; set => loyalFriend = value; }
        public string Totalcoststring { get => totalcoststring; set => totalcoststring = value; }
        public string NameEmp { get => nameEmp; set => nameEmp = value; }
        public string NameCus { get => nameCus; set => nameCus = value; }
        public int Quantity { get => quantity; set => quantity = value; }
    }
}
