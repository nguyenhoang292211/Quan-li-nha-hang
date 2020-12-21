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
using System.Collections;

namespace Restaurant.Controller
{
    class eventsController
    {
        DAO DAO = new DAO();
        public ObservableCollection<Events> LoadData_Events()
        {
            DataTable data = DAO.ExecuteQueryDataSet("Select * from Events", CommandType.Text);
            ObservableCollection<Events> list = new ObservableCollection<Events>();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                Events a = new Events();
                a.Id = (int)data.Rows[i][0];
                a.Name = data.Rows[i][1].ToString();
                a.StartDate = DateTime.Parse(data.Rows[i][2].ToString());
                a.EndDate = DateTime.Parse(data.Rows[i][3].ToString());
                a.Discount = Convert.ToDouble(data.Rows[i][4]);
                list.Add(a);
            }
            return list;

        }

        public int Create_NewIdevents_Auto()
        {
            ObservableCollection<Events> events = LoadData_Events();
            int count = events.Count();
            int s1 =events[count - 1].Id;
            int Id;
            Id = s1 + 1;
            return Id;
        }

        /*public void EditProduct(string IdType, string NameType)
        {
            DataTable a = DAO.ExecuteQueryDataSet("Select * from Type_product where ID='" + IdType + "'", CommandType.Text);

            SqlParameter ID = new SqlParameter("@ID", IdType);
            SqlParameter Name = new SqlParameter("@Name", IdType);
            SqlParameter num = new SqlParameter("@Number", (int)a.Rows[0][2]);
            List<SqlParameter> t = new List<SqlParameter>();
            t.Add(ID);
            t.Add(Name);
            t.Add(num);
            DAO.MyExecuteNonQuery("Update_Type_Product", CommandType.StoredProcedure, t);

        }*/


        /*public void AddStaff(bool isEdit, string ID, string Name, string address, DateTime birthday, DateTime startwork, string sex, string Phone, string position, string img_Path)
        {

            SqlParameter id = new SqlParameter("@ID", ID);
            SqlParameter addr = new SqlParameter("@Address", address);
            SqlParameter name = new SqlParameter("@Name", Name);
            SqlParameter birth = new SqlParameter("@Birthday", birthday);
            SqlParameter phone = new SqlParameter("@phone", Phone);
            SqlParameter Image = new SqlParameter("@Image_path", img_Path);
            SqlParameter postion = new SqlParameter("@position", position);
            SqlParameter start = new SqlParameter("@start", startwork);
            SqlParameter se = new SqlParameter("@sex", sex);


            List<SqlParameter> parameters_product = new List<SqlParameter>();
            parameters_product.Add(id);
            parameters_product.Add(addr);
            parameters_product.Add(name);
            parameters_product.Add(birth);
            parameters_product.Add(phone);
            parameters_product.Add(postion);
            parameters_product.Add(Image);
            parameters_product.Add(se);


        }*/

        public void addEvents(string name, DateTime startDate, DateTime endDate, double discount)
        {
            // DataTable dataTable;
            SqlParameter Name = new SqlParameter("@name", name);
            SqlParameter StartDate = new SqlParameter("@startDate", startDate);
            SqlParameter EndDate = new SqlParameter("@endDate", endDate);
            SqlParameter Discount = new SqlParameter("@discount", discount);

            List<SqlParameter> parameters_Events = new List<SqlParameter>();
            parameters_Events.Add(Name);
            parameters_Events.Add(StartDate);
            parameters_Events.Add(EndDate);
            parameters_Events.Add(Discount);
            string query = "AddEvents";

            DAO.MyExecuteNonQuery(query, CommandType.StoredProcedure, parameters_Events);
        }
        public void EditEvents(int id, string name, DateTime startDate, DateTime endDate, double discount)
        {
            SqlParameter ID = new SqlParameter("@id", id);
            SqlParameter Name = new SqlParameter("@name", name);
            SqlParameter StartDate = new SqlParameter("@startDate", startDate);
            SqlParameter EndDate = new SqlParameter("@endDate", endDate);
            SqlParameter Discount = new SqlParameter("@discount", discount);

            List<SqlParameter> parameters_Events = new List<SqlParameter>();
            parameters_Events.Add(ID);
            parameters_Events.Add(Name);
            parameters_Events.Add(StartDate);
            parameters_Events.Add(EndDate);
            parameters_Events.Add(Discount);
            string query = "EditEvents";
            DAO.MyExecuteNonQuery(query, CommandType.StoredProcedure, parameters_Events);

            /*string[] vars = { "@id", "@name", "@startDate", "@endDate", "@name", "@discount" };
            ArrayList array = new ArrayList(new Object[] { id, name, startDate, endDate,discount });

            List<SqlParameter> t = DAO.turntoListParam(array, vars);
            DAO.MyExecuteNonQuery("EditEvents", CommandType.StoredProcedure, t);*/

        }

        public void DeleteEvents(int id)
        {
            SqlParameter ID = new SqlParameter("@id", id);
            List<SqlParameter> parameters_Events = new List<SqlParameter>();
            parameters_Events.Add(ID);
            string query = "DeleteEvents";
            DAO.MyExecuteNonQuery(query, CommandType.StoredProcedure, parameters_Events);
        }
        /*public bool DeletEvents(int id)
        {

            SqlParameter ID = new SqlParameter("@id", id);
            List<SqlParameter> parameters_Events = new List<SqlParameter>();
            parameters_Events.Add(ID);
            string query = "DeleteEvents";
            DAO.MyExecuteNonQuery(query, CommandType.StoredProcedure, parameters_Events);



            List<SqlParameter> parameters_Events = new List<SqlParameter>();
            parameters_Events.Add(new SqlParameter("@id",id));
            
            string query = "DeleteEvents";
            return (DAO.MyExecuteNonQuery(query, CommandType.StoredProcedure, parameters_Events));
        }*/

        public ObservableCollection<Events> SearchEvents(string text)
        {
            ObservableCollection<Events> events = LoadData_Events();
            ObservableCollection<Events> searchevents = new ObservableCollection<Events>();

            for (int i = 0; i < events.Count; i++)
            {
                if (events[i].Name.Contains(text))
                    searchevents.Add(events[i]);
            }
            return searchevents;
        }
        public ObservableCollection<Events> stateEvents(string textt)
        {
            ObservableCollection<Events> state1 = LoadData_Events();
            ObservableCollection<Events> searchstate = new ObservableCollection<Events>();
            DateTime a = state1[1].EndDate;
            for (int i = 0; i < state1.Count; i++)
            {
                if ( state1[i].EndDate.ToString().Contains(textt))
                    searchstate.Add(state1[i]);
            }
            return searchstate;
        }
        public ObservableCollection<Events> TrangThaiHetHanEvents()
        {
            ObservableCollection<Events> state1 = LoadData_Events();
            ObservableCollection<Events> searchstate = new ObservableCollection<Events>();
            DateTime a = state1[1].EndDate;
            for (int i = 0; i < state1.Count; i++)
            {
                if ( state1[i].EndDate < DateTime.Now)
                    searchstate.Add(state1[i]);
            }
            return searchstate;
        }
        public ObservableCollection<Events> TrangThaiConHanEvents()
        {
            ObservableCollection<Events> state1 = LoadData_Events();
            ObservableCollection<Events> searchstate = new ObservableCollection<Events>();
            DateTime a = state1[1].EndDate;
            for (int i = 0; i < state1.Count; i++)
            {
                if (state1[i].EndDate > DateTime.Now)
                    searchstate.Add(state1[i]);
            }
            return searchstate;
        }

    }
}
