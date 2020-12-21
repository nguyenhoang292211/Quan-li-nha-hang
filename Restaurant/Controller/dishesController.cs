using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Restaurant.Model;
namespace Restaurant.Controller
{
    class dishesController
    {
        DAO DAO = new DAO();
        /// <summary>
        /// Lấy danh sách tất cả món ăn đang kinh doanh
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Dishes> loadallDishes()
        {
            DataTable data = DAO.ExecuteQueryDataSet("GETDATA", CommandType.StoredProcedure, new List<SqlParameter>() { new SqlParameter("@table", "Dishes") });
            //tạo 1 list để luwu trữ dữ liệu lấy từ database
            ObservableCollection<Dishes> list = new ObservableCollection<Dishes>();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                Dishes a = new Dishes(data.Rows[i]);
                list.Add(a);
            }
            return list;
        }
        /// <summary>
        /// Lất danh sách tất cả các loại món
        /// </summary>
        public ObservableCollection<TypeFoods> loadallTypeDishes()
        {
            DataTable data = DAO.ExecuteQueryDataSet("pro_loadTypeFood", System.Data.CommandType.StoredProcedure, new List<SqlParameter> { new SqlParameter("@state", 1) });
            //tạo 1 list để luwu trữ dữ liệu lấy từ database
            ObservableCollection<TypeFoods> list = new ObservableCollection<TypeFoods>();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                TypeFoods a = new TypeFoods(data.Rows[i]);
                list.Add(a);
            }
            return list;
        }
        /// <summary>
        /// Lấy danh sách món ăn theo loại món
        /// </summary>
        /// <param name="idType"></param>
        /// <returns></returns>
        public ObservableCollection<Dishes> loadDishesWithType(int idType)
        {
            DataTable data = DAO.ExecuteQueryDataSet("Select * from Dishes where idType='" + idType.ToString() + "'", CommandType.Text);
            ObservableCollection<Dishes> list = new ObservableCollection<Dishes>();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                Dishes a = new Dishes(data.Rows[i]);
                list.Add(a);
            }
            return list;
        }

        public ObservableCollection<Dishes> SearchDish(string keyword, int idtype)
        {
            ObservableCollection<Dishes> list = new ObservableCollection<Dishes>();

            list = loadDishesWithType(idtype);
            ObservableCollection<Dishes> returnlist = new ObservableCollection<Dishes>();

            // string query = "Select * from Employees where name like'" + keyword + "%'";
            // DataTable emp = DAO.ExecuteQueryDataSet(query, CommandType.Text);

            foreach (Dishes a in list)
            {
                if (a.Name.Contains(keyword)) returnlist.Add(a);
            }
            return returnlist;
        }

        //để ké

        public ObservableCollection<Events> loadlistEvents()
        {
            ObservableCollection<Events> events = new ObservableCollection<Events>();
            DataTable data = DAO.ExecuteQueryDataSet("GETDATA", CommandType.StoredProcedure, new List<SqlParameter>() { new SqlParameter("@table", "Events") });
            foreach (DataRow row in data.Rows)
            {
                Events a = new Events(row);
                events.Add(a);
            }
            return events;
        }

        public ObservableCollection<Dishes> LoadDataLoaiMonAn_Dishes()
        {
            DataTable data = DAO.ExecuteQueryDataSet("Select Dishes.id, Dishes.name, price, TypeFoods.name,TypeFoods.id, Dishes.state ,image from Dishes, TypeFoods Where Dishes.idType=TypeFoods.id", CommandType.Text);
            ObservableCollection<Dishes> list = new ObservableCollection<Dishes>();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                Dishes a = new Dishes();
                a.Id = (int)data.Rows[i][0];
                a.Name = data.Rows[i][1].ToString();
                a.Price = (int)data.Rows[i][2];
                a.IdType =(Int32.Parse(data.Rows[i][4].ToString()));
                a.NameType = data.Rows[i][3].ToString();
                a.State = data.Rows[i][5].ToString();
                if (a.State == "1") a.State = "Ngưng phục vụ";
                else a.State = "Còn phục vụ";
                a.Img_source = data.Rows[i][6].ToString();

                list.Add(a);
            }
            return list;
        }

        public void addDishes(string name, int price, int idType, string state, string img_source)
        {
            //DataTable dataTable;
            SqlParameter Name = new SqlParameter("@name", name);
            SqlParameter Price = new SqlParameter("@price", price);
            SqlParameter IdType = new SqlParameter("@idType", idType);
            SqlParameter State = new SqlParameter("@state", state);
            SqlParameter Img_source = new SqlParameter("img_source", img_source);
            List<SqlParameter> parameters_Dishes = new List<SqlParameter>();
            parameters_Dishes.Add(Name);
            parameters_Dishes.Add(Price);
            parameters_Dishes.Add(IdType);
            parameters_Dishes.Add(State);
            parameters_Dishes.Add(Img_source);
            string query = "AddDishes";
            DAO.MyExecuteNonQuery(query, CommandType.StoredProcedure, parameters_Dishes);
        }
        public int Create_NewIdcustomers_Auto()
        {
            ObservableCollection<Dishes> dishes = LoadDataLoaiMonAn_Dishes();
            int count = dishes.Count();
            int s1 = dishes[count - 1].Id;
            int Id;
            Id = s1 + 1;
            return Id;
        }

        public void EditDishes(int id, string name, int price, int idType, string state, string img_source)
        {
            // DataTable dataTable;
            SqlParameter ID = new SqlParameter("@id", id);
            SqlParameter Name = new SqlParameter("@name", name);
            SqlParameter Price = new SqlParameter("@price", price);
            SqlParameter IdType = new SqlParameter("@idType", idType);
            SqlParameter State = new SqlParameter("@state", state);
            SqlParameter Img_source = new SqlParameter("img_source", img_source);

            List<SqlParameter> parameters_Dishes = new List<SqlParameter>();
            parameters_Dishes.Add(ID);
            parameters_Dishes.Add(Name);
            parameters_Dishes.Add(Price);
            parameters_Dishes.Add(IdType);
            parameters_Dishes.Add(State);
            parameters_Dishes.Add(Img_source);

            DAO.MyExecuteNonQuery("EditDishes", CommandType.StoredProcedure, parameters_Dishes);
        }
        public void DeleteDishes(int id)
        {
            SqlParameter ID = new SqlParameter("@id", id);
            List<SqlParameter> parameters_Dishes = new List<SqlParameter>();
            parameters_Dishes.Add(ID);
            string query = "DeleteDishes";
            DAO.MyExecuteNonQuery(query, CommandType.StoredProcedure, parameters_Dishes);
        }
        public ObservableCollection<Dishes> SearchDishes(string text)
        {
            ObservableCollection<Dishes> dishes = LoadDataLoaiMonAn_Dishes();
            ObservableCollection<Dishes> searchdishes = new ObservableCollection<Dishes>();

            for (int i = 0; i < dishes.Count; i++)
            {
                if (dishes[i].Name.Contains(text))
                    searchdishes.Add(dishes[i]);
            }
            return searchdishes;
        }
        public ObservableCollection<Dishes> stateDishes(string text)
        {
            ObservableCollection<Dishes> state = LoadDataLoaiMonAn_Dishes();
            ObservableCollection<Dishes> searchstate = new ObservableCollection<Dishes>();

            for (int i = 0; i < state.Count; i++)
            {
                if (state[i].State.Contains(text))
                    searchstate.Add(state[i]);
            }
            return searchstate;
        }


        //mới thêm
        public ObservableCollection<Dishes> getBestSeller  (int idtype)
        {

            DataTable data = DAO.ExecuteQueryDataSet("getBestSeller", CommandType.StoredProcedure, new List<SqlParameter>() { new SqlParameter("@idType", idtype) });
            //tạo 1 list để luwu trữ dữ liệu lấy từ database
            ObservableCollection<Dishes> list = new ObservableCollection<Dishes>();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                Dishes a = new Dishes(data.Rows[i]);
                list.Add(a);
            }
            return list;
        }
    }
}
