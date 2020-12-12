using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Model
{
    class Area
    {
        private int idArea;
        private string nameArea;
        private int amountTable;

        public int IdArea { get => idArea; set => idArea = value; }
        public string NameArea { get => nameArea; set => nameArea = value; }
        public int AmountTable { get => amountTable; set => amountTable = value; }

        public Area()
        {

        }
<<<<<<< HEAD
        public Area(int id,String name)
        {
            this.IdArea = id;
            this.NameArea = name;
            this.AmountTable = 0;
        }

        
=======
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
       
    }
}
