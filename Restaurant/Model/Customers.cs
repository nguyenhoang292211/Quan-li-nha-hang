using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Data;
using System.Collections;
using System.Data.SqlClient;

namespace Restaurant.Model
{
    public class Customers
    {
        DAO dao = new DAO();
        public Customers()
        {

        }
        private int id;
        private string phone;
        private string name;
        private int point;

        public int Id { get => id; set => id = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Name { get => name; set => name = value; }
        public int Point { get => point; set => point = value; }

        public Customers(DataRow row)
        {
            this.id = Int32.Parse(row["id"].ToString());
            this.phone = row["phone"].ToString();
            this.name = row["name"].ToString();
            this.point =Int32.Parse(row["point"].ToString());
        }

       
        public ObservableCollection<Customers> loadAllCustomer()
        {
            ObservableCollection<Customers> listreturn = new ObservableCollection<Customers>();
            DataTable data = dao.ExecuteQueryDataSet("Select * from Customers", CommandType.Text);
            foreach(DataRow row in data.Rows)
            {
                Customers cus = new Customers(row);
                listreturn.Add(cus);
            }
            return listreturn;
        }

        public bool addNewCustomer(string name, string phone, int point)
        {
            string[] vars = { "@phone", "@name", "@point" };
            ArrayList array = new ArrayList(new Object[] { phone,name, point });

            List<SqlParameter> t = dao.turntoListParam(array, vars);

            return dao.MyExecuteNonQuery("addCustomer",CommandType.StoredProcedure,t);
        }

        public Customers findCusByid(int id)
        {
            DataTable data = dao.MyExecuteNonQuery_data("getCustomerByID", CommandType.StoredProcedure, new List<SqlParameter>() { new SqlParameter("@id", id) });
            if (data.Rows.Count > 0)
            {
                Customers cus = new Customers(data.Rows[0]);
                return cus;
            }
            return null;
        }

        public int getLastedID ()
        {
            DataTable data = dao.ExecuteQueryDataSet("Select * from Customers", CommandType.Text);
            return Int32.Parse( data.Rows[data.Rows.Count - 1]["id"].ToString());
        }

        public int getPoint(int idCus)
        {
            int t =Int32.Parse(dao.FindOneValue("getCustomerPoint", CommandType.StoredProcedure, new SqlParameter("@id", idCus)));
            return t;
        }

    }
}
