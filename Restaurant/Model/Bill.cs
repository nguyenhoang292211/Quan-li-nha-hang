using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Model
{
    class Bill
    {
        private string idBill;
        private DateTime datetime;
        private double price;

        public string IdBill { get => idBill; set => idBill = value; }
        public DateTime Datetime { get => datetime; set => datetime = value; }
        public double Price { get => price; set => price = value; }

        public Bill()
        {

        }
        public Bill(string id, DateTime date,double price)
        {
            this.idBill = id;
            this.datetime = date;
            this.price = price;
        }
    }
}
