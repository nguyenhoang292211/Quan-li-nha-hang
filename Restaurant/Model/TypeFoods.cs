using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Model
{
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
    }
}
