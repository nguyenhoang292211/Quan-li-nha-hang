using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Model
{
    public class Orders
    {
        private int id;
        private int idSeat;
        private int idEmp;
        private int idCus;
        private DateTime timeOrder;

        public int Id { get => id; set => id = value; }
        public int IdSeat { get => idSeat; set => idSeat = value; }
        public int IdEmp { get => idEmp; set => idEmp = value; }
        public int IdCus { get => idCus; set => idCus = value; }
        public DateTime TimeOrder { get => timeOrder; set => timeOrder = value; }
        //thêm
        public Orders()
        {

        }    

        public Orders(DataRow row)
        {
            this.Id = Int32.Parse(row["id"].ToString());
            this.IdSeat = Int32.Parse(row["idSeat"].ToString());
            this.IdEmp = Int32.Parse(row["idEmp"].ToString());
            this.IdCus = Int32.Parse(row["idCus"].ToString());
            this.TimeOrder = DateTime.Parse(row["timeOrder"].ToString());
        }

        public Orders(int id, int idSeat, int idEmp, int idCus, DateTime time)
        {
            this.Id = id;
            this.IdCus = idCus;
            this.IdEmp = idEmp;
            this.IdSeat = idSeat;
            this.TimeOrder = time;
        }
        public Orders(int id, int idSeat, int idEmp, DateTime time)
        {
            this.Id = id;
            this.IdEmp = idEmp;
            this.IdSeat = idSeat;
            this.TimeOrder = time;
        }


    }
}
