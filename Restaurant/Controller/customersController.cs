using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Data.SqlClient;
using Restaurant.Model;

namespace Restaurant.Controller
{
    class customersControllers
    {
        DAO DAO = new DAO();
        public ObservableCollection<Customers> LoadData_Customers()
        {
            DataTable data = DAO.ExecuteQueryDataSet("Select * from Customers", CommandType.Text);
            ObservableCollection<Customers> list = new ObservableCollection<Customers>();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                Customers a = new Customers();
                a.Id = (int)data.Rows[i][0];
                a.Phone = data.Rows[i][1].ToString();
                a.Name = data.Rows[i][2].ToString();
                a.Point = (int)data.Rows[i][3];

                list.Add(a);
            }
            return list;
        }
        public void addCustomers(string phone, string name, int point)
        {
            // DataTable dataTable;
            SqlParameter Phone = new SqlParameter("@phone", phone);
            SqlParameter Name = new SqlParameter("@name", name);
            SqlParameter Point = new SqlParameter("@point", point);

            List<SqlParameter> parameters_Customers = new List<SqlParameter>();
            parameters_Customers.Add(Phone);
            parameters_Customers.Add(Name);
            parameters_Customers.Add(Point);
            string query = "AddCustomers";

            DAO.MyExecuteNonQuery(query, CommandType.StoredProcedure, parameters_Customers);
        }
        public int Create_NewIdcustomers_Auto()
        {
            ObservableCollection<Customers> customers = LoadData_Customers();
            int count = customers.Count();
            int s1 = customers[count - 1].Id;
            int Id;
            Id = s1 + 1;
            return Id;
        }
        public void DeleteCustomers(int id)
        {
            SqlParameter ID = new SqlParameter("@id", id);
            List<SqlParameter> parameters_Customers = new List<SqlParameter>();
            parameters_Customers.Add(ID);
            string query = "DeleteCustomers";
            DAO.MyExecuteNonQuery(query, CommandType.StoredProcedure, parameters_Customers);
        }
        public void EditCustomers(int id, string name, string phone, int point)
        {
            SqlParameter ID = new SqlParameter("@id", id);
            SqlParameter Name = new SqlParameter("@name", name);
            SqlParameter Phone = new SqlParameter("@phone", phone);
            SqlParameter Point = new SqlParameter("@point", point);

            List<SqlParameter> parameters_Customers = new List<SqlParameter>();
            parameters_Customers.Add(ID);
            parameters_Customers.Add(Name);
            parameters_Customers.Add(Phone);
            parameters_Customers.Add(Point);
            string query = "EditCustomers";
            DAO.MyExecuteNonQuery(query, CommandType.StoredProcedure, parameters_Customers);
        }
        public ObservableCollection<Customers> SearchCustomers(string text)
        {
            ObservableCollection<Customers> customers = LoadData_Customers();
            ObservableCollection<Customers> searchcustomers = new ObservableCollection<Customers>();

            for (int i = 0; i < customers.Count; i++)
            {
                if (customers[i].Name.Contains(text))
                    searchcustomers.Add(customers[i]);
            }
            return searchcustomers;
        }
        public ObservableCollection<Customers> PointTTCustomers()
        {
            ObservableCollection<Customers> customers = LoadData_Customers();
            ObservableCollection<Customers> searchcustomers = new ObservableCollection<Customers>();

            for (int i = 0; i < customers.Count; i++)
            {
                if (customers[i].Point>100)
                    searchcustomers.Add(customers[i]);
            }
            return searchcustomers;
        }
        public ObservableCollection<Customers> PointBTCustomers()
        {
            ObservableCollection<Customers> customers = LoadData_Customers();
            ObservableCollection<Customers> searchcustomers = new ObservableCollection<Customers>();

            for (int i = 0; i < customers.Count; i++)
            {
                if (customers[i].Point < 100)
                    searchcustomers.Add(customers[i]);
            }
            return searchcustomers;
        }
    }
}
