using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Restaurant.Model;
using System.Data;

namespace Restaurant.Controller
{
    class promotionController
    {
        DAO db = new DAO();

        //Select Customers List
        public ObservableCollection<Customers> loadCustomer()
        {
            //DataTable data = db.ExecuteQueryDataSet("Select * from Customers", CommandType.Text);
            DataTable data = db.ExecuteQueryDataSet("select * from loadCustomer() ", CommandType.Text);
            ObservableCollection<Customers> list = new ObservableCollection<Customers>();
            for (int i = 0; i < data.Rows.Count; i++)
            {
               Customers a = new Customers();
                a.Id = Convert.ToInt32(data.Rows[i][0]);
               
                a.Name = data.Rows[i][2].ToString();
                a.Phone = data.Rows[i][1].ToString();
                a.Point=Convert.ToInt32( data.Rows[i][3].ToString());
           
                list.Add(a);
            }
            return list;
        }
    }
}
