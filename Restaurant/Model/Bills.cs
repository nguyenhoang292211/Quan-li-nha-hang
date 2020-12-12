using System;
using System.Collections.Generic;
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

    class Bills
    {
        public Bills()
        {

        }

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
    }
}
