using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Model
{
    class Cancels
    {
        public Cancels()
        {

        }
        private int id;
        private int idOrder;
        private int idEmp;
        private int idCus;
        private DateTime timeCancel;
        private double totalCost;

        public int Id { get => id; set => id = value; }
        public int IdOrder { get => idOrder; set => idOrder = value; }
        public int IdEmp { get => idEmp; set => idEmp = value; }
        public int IdCus { get => idCus; set => idCus = value; }
        public DateTime TimeCancel { get => timeCancel; set => timeCancel = value; }
        public double TotalCost { get => totalCost; set => totalCost = value; }
    }
}
