using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Controller;
using System.Collections.ObjectModel;

namespace Restaurant.Model
{
    public enum Level
    {
        employee=1,
        boss=2
    }

    class Employees
    {
        public Employees()
        {
            
        }
        private int id;
        private int idMan;
        private string userName;
        private string passWord;
        private string name;
        private char sex;
        private string phone;
        private string address;
        private double salary;
        private Level level;
        private string state;

        public int Id { get => id; set => id = value; }
        public int IdMan { get => idMan; set => idMan = value; }
        public string UserName { get => userName; set => userName = value; }
        public string PassWord { get => passWord; set => passWord = value; }
        public string Name { get => name; set => name = value; }
        public char Sex { get => sex; set => sex = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Address { get => address; set => address = value; }
        public double Salary { get => salary; set => salary = value; }
        public Level Level { get => level; set => level = value; }
        public string State { get => state; set => state = value; }

        public Employees(DataRow row )
        {
        
                this.Id = int.Parse(row["id"].ToString());
                this.IdMan = (int)row["idMan"];
                this.UserName = row["userName"].ToString();
                this.PassWord = row["passWord"].ToString();
                this.Name = row["name"].ToString();
                this.Sex = char.Parse(row["sex"].ToString());
                this.Phone = row["phone"].ToString();
                this.Address = row["address"].ToString();
                this.Salary = double.Parse(row["salary"].ToString());
                this.Level = (Level)Convert.ToInt32(row["level"]);
                this.State = row["state"].ToString();
            
        }

        public Employees (int id, int idman, string username,
                        string pass, string name, char sex, string phone, string add,
                        double salary, Level level, string state)
        {
            this.Id = id;
            this.IdMan = idman;
            this.UserName = username;
            this.PassWord = pass;
            this.Phone = phone;
            this.Name = name;
            this.Sex = sex;
            this.Salary = salary;
            this.Address = add;
            this.Level = level;
            this.State = state;

        }
<<<<<<< HEAD
=======

        
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
    }
}
