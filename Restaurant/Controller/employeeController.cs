using Restaurant.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Controller
{
    class employeeController
    {
        DAO DAO = new DAO();

        public ObservableCollection<Employees> loadallEmployees()
        {
            DataTable data = DAO.ExecuteQueryDataSet("Select * from Employees", CommandType.Text);
            //tạo 1 list để luwu trữ dữ liệu lấy từ database
            ObservableCollection<Employees> list = new ObservableCollection<Employees>();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                Employees a = new Employees(data.Rows[i]);
                list.Add(a);
            }
            return list;
        }
<<<<<<< HEAD


=======
      
        
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151

        /// <summary>
        /// Thêm nhân viên mới vào database
        /// </summary>
        ///
        public bool addEmployees(int id, int idMan, string userName,
                        string pass, string name, char sex, string phone, string add,
                        double salary, Level level, string state)
        {

<<<<<<< HEAD
            string[] vars = { "@id", "@idMan", "@userName", "@passWord", "@name", "@sex", "@phone", "@address", "@salary", "@level", "@state" };
            ArrayList array = new ArrayList(new Object[] { id, idMan, userName, pass, name, sex, phone, add, salary, level, state });

            List<SqlParameter> t = DAO.turntoListParam(array, vars);

=======
            string[] vars = { "@id","@idMan", "@userName", "@passWord", "@name", "@sex", "@phone", "@address", "@salary", "@level", "@state" };
            ArrayList array = new ArrayList(new Object[] { id, idMan, userName, pass, name, sex, phone, add, salary, level, state });

            List<SqlParameter> t = DAO.turntoListParam(array, vars);
           
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
            if (DAO.MyExecuteNonQuery("addEmployees", CommandType.StoredProcedure, t))
                return true;
            return false;

        }

        /// <summary>
        /// Lấy danh sách tên người quản lí
        /// </summary>
        /// <returns></returns>
<<<<<<< HEAD
        public List<string> getListNameManager()
=======
        public List<string> getListNameManager ()
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
        {
            List<string> listname = new List<string>();
            DataTable a = DAO.ExecuteQueryDataSet("getlistManager", CommandType.StoredProcedure);
            if (a.Rows.Count > 0)
            {
                foreach (DataRow i in a.Rows)
                {
                    Employees manager = new Employees(i);
                    listname.Add(manager.Name);
                }
                return listname;
            }
            else
                return null;
        }

        /// <summary>
        /// Lấy tên người quản lí bằng id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string getNameManagerbyid(int id)
        {
            DataTable a = DAO.ExecuteQueryDataSet("getlistManager", CommandType.StoredProcedure);
            if (a.Rows.Count > 0)
            {
                foreach (DataRow i in a.Rows)
                {
                    Employees manager = new Employees(i);
                    if (manager.Id == id)
                        return manager.Name;
                }
            }

            return null;
        }
        /// <summary>
        /// Lấy ID người quản lí bằng tên
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int getIdManagebyName(string name)
        {
            DataTable a = DAO.ExecuteQueryDataSet("getlistManager", CommandType.StoredProcedure);
            if (a.Rows.Count > 0)
            {
                foreach (DataRow i in a.Rows)
                {
                    Employees manager = new Employees(i);
<<<<<<< HEAD
                    if (manager.Name == name)
=======
                    if (manager.Name ==name)
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
                        return manager.Id;
                }
            }

            return 0;
        }

        /// <summary>
        /// Xóa nhân viên bằng id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool deleteEmployees(int id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ID", id));
            return (DAO.MyExecuteNonQuery("deleteEmployees", CommandType.StoredProcedure, parameters));
        }

        /// <summary>
        /// Chỉnh sửa thông tin nhân viên
        /// </summary>
        /// <param name="id"></param>
        /// <param name="idMan"></param>
        /// <param name="userName"></param>
        /// <param name="pass"></param>
        /// <param name="name"></param>
        /// <param name="sex"></param>
        /// <param name="phone"></param>
        /// <param name="add"></param>
        /// <param name="salary"></param>
        /// <param name="level"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool editEmployees(int id, int idMan, string userName,
                        string pass, string name, char sex, string phone, string add,
                        double salary, Level level, string state)
        {


            string[] vars = { "@id", "@idMan", "@userName", "@passWord", "@name", "@sex", "@phone", "@address", "@salary", "@level", "@state" };
            ArrayList array = new ArrayList(new Object[] { id, idMan, userName, pass, name, sex, phone, add, salary, level, state });

            List<SqlParameter> t = DAO.turntoListParam(array, vars);
            if (DAO.MyExecuteNonQuery("updateEmployees", CommandType.StoredProcedure, t))
                return true;
            return false;
        }

<<<<<<< HEAD
        public ObservableCollection<Employees> SearchEmployees(string keyword, string condition = null)
=======
        public ObservableCollection<Employees> SearchEmployees(string keyword, string condition=null)
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
        {
            ObservableCollection<Employees> list = new ObservableCollection<Employees>();
            list = loadallEmployees();
            ObservableCollection<Employees> returnlist = new ObservableCollection<Employees>();

            if (condition == null)
<<<<<<< HEAD
            {
=======
            {              
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
                // string query = "Select * from Employees where name like'" + keyword + "%'";
                // DataTable emp = DAO.ExecuteQueryDataSet(query, CommandType.Text);

                foreach (Employees a in list)
                {
                    if (a.Name.Contains(keyword)) returnlist.Add(a);
                }
                return returnlist;
            }
            else
            {
                switch (condition)
                {
                    case "Nam":
                        foreach (Employees a in list)
                        {
<<<<<<< HEAD
                            if ((a.Name.Contains(keyword) == true || keyword == "") && a.Sex == 'M') returnlist.Add(a);
=======
                            if ((a.Name.Contains(keyword)==true|| keyword=="" ) && a.Sex=='M') returnlist.Add(a);
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
                        }
                        return returnlist;
                    case "Nữ":
                        foreach (Employees a in list)
                        {
<<<<<<< HEAD
                            if ((a.Name.Contains(keyword) == true || keyword == "") && a.Sex == 'F') returnlist.Add(a);
=======
                            if ((a.Name.Contains(keyword) == true || keyword == "")&& a.Sex == 'F') returnlist.Add(a);
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
                        }
                        return returnlist;

                    case "Địa chỉ":
                        foreach (Employees a in list)
                        {
<<<<<<< HEAD
                            if (a.Address.Contains(keyword) == true) returnlist.Add(a);
=======
                            if (a.Address.Contains(keyword) == true ) returnlist.Add(a);
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
                        }
                        return returnlist;

                    case "Nhân viên":
                        foreach (Employees a in list)
                        {
<<<<<<< HEAD
                            if ((a.Name.Contains(keyword) == true || keyword == "") && a.Level == Level.employee) returnlist.Add(a);
=======
                            if ((a.Name.Contains(keyword) == true || keyword == "") && a.Level ==Level.employee) returnlist.Add(a);
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
                        }
                        return returnlist;
                    case "Quản lí":
                        foreach (Employees a in list)
                        {
<<<<<<< HEAD
                            if ((a.Name.Contains(keyword) == true || keyword == "") && a.Level == Level.boss) returnlist.Add(a);
=======
                            if ((a.Name.Contains(keyword) == true || keyword == "") && a.Level== Level.boss) returnlist.Add(a);
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
                        }
                        return returnlist;
                    default:
                        return list;

                }
            }
<<<<<<< HEAD

=======
            
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
        }

        public Employees getEmpByID(int id)
        {
            DataTable data = DAO.MyExecuteNonQuery_data("getEmpByID", CommandType.StoredProcedure,
                                                            new List<SqlParameter>() { new SqlParameter("@id", id) });
<<<<<<< HEAD
            if (data != null)
=======
            if (data!=null)
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
                return new Employees(data.Rows[0]);
            else
                return null;
        }
    }
}
