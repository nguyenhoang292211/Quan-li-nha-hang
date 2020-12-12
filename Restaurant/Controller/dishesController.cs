using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Model;
namespace Restaurant.Controller
{
    class dishesController
    {
        DAO DAO = new DAO();
        /// <summary>
        /// Lấy danh sách tất cả món ăn
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Dishes> loadallDishes()
        {
            DataTable data = DAO.ExecuteQueryDataSet("Select * from Dishes", CommandType.Text);
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
            DataTable data = DAO.ExecuteQueryDataSet("Select * from TypeFoods", CommandType.Text);
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

    }
}
