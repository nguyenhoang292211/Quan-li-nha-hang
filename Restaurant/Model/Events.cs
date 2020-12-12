using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Model
{
    class Events
    {
        private int id;
        private string name;
        private DateTime startDate;
        private DateTime endDate;
        private double discount;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public DateTime StartDate { get => startDate; set => startDate = value; }
        public DateTime EndDate { get => endDate; set => endDate = value; }
        public double Discount { get => discount; set => discount = value; }
    }
}
