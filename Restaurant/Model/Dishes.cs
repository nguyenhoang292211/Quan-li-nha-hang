using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Model
{
    public class Dishes
    {
        string name;
        int id;
        double price;
        string img_source;
        string state;
        int idType;

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
            }
        }

        public string Img_source
        {
            get { return img_source; }
            set
            {
                img_source = value;
            }
        }

        public string State { get => state; set => state = value; }
        public int IdType { get => idType; set => idType = value; }

        public Dishes(DataRow row)
        {
            this.Id =Int32.Parse(row["id"].ToString());
            this.Price =Double.Parse(row["price"].ToString());
            this.Name = row["name"].ToString();
            this.Img_source = row["image"].ToString();
            this.State = row["state"].ToString();
            this.IdType =Int32.Parse(row["idType"].ToString());
        }

        public Dishes (int id, double price, string name,int idType, string state, string img)
        {
            this.Img_source = img;
            this.Name = name;
            this.Price = price;
            this.Id = id;
            this.State = state;
            this.IdType = idType;
        }
    }
}
