using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Model
{
<<<<<<< HEAD
    class TypeFoods
    {
        int id;
        string name;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }

        public TypeFoods(DataRow row)
        {
            this.Id =Int32.Parse(row["id"].ToString());
            this.Name = row["name"].ToString();
        }

        public TypeFoods(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
=======
    public enum stateService
    {
        Available, Unavailable
    }

    public class TypeFoods
    {
        private int id;
        private string name;
        private int quantity;
        private stateService state;
        public TypeFoods()
        {

        }

        public TypeFoods(DataRow row)
        {
            this.id = Convert.ToInt32(row["id"]);
            this.name = row["name"].ToString();
            this.quantity = 0;// Convert.ToInt32(row[2]);
            this.state = (stateService)Convert.ToInt32(row["state"]);
        }
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public stateService State { get => state; set => state = value; }
        public int Quantity { get => quantity; set => quantity = value; }
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
    }
}
