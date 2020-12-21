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
            DataTable data = DAO.ExecuteQueryDataSet("GETDATA", CommandType.StoredProcedure, new List<SqlParameter>() { new SqlParameter("@table", "Employees") });
            //tạo 1 list để luwu trữ dữ liệu lấy từ database
            ObservableCollection<Employees> list = new ObservableCollection<Employees>();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                Employees a = new Employees(data.Rows[i]);
                list.Add(a);
            }
            return list;
        }

        /// <summary>
        /// Thêm nhân viên mới vào database
        /// </summary>
        ///
        public bool addEmployees(int idMan, string userName,
                        string pass, string name, char sex, string phone, string add,
                        double salary, Level level, int state)
        {

            string[] vars = { "@idMan", "@userName", "@passWord", "@name", "@sex", "@phone", "@address", "@salary", "@level", "@state" };
            ArrayList array = new ArrayList(new Object[] { idMan, userName, pass, name, sex, phone, add, salary, level, state });

            List<SqlParameter> t = DAO.turntoListParam(array, vars);

            if (DAO.MyExecuteNonQuery("addEmployees", CommandType.StoredProcedure, t))
                return true;
            return false;

        }

        /// <summary>
        /// Lấy danh sách tên người quản lí
        /// </summary>
        /// <returns></returns>
        public List<string> getListNameManager()

        {
            List<string> listname = new List<string>();
            DataTable a = DAO.ExecuteQueryDataSet("GETDATA", CommandType.StoredProcedure, new List<SqlParameter>() { new SqlParameter("@table", "Manager") });
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
            DataTable a = DAO.ExecuteQueryDataSet("GETDATA", CommandType.StoredProcedure, new List<SqlParameter>() { new SqlParameter("@table", "Employees") });
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
            DataTable a = DAO.ExecuteQueryDataSet("GETDATA", CommandType.StoredProcedure, new List<SqlParameter>() { new SqlParameter("@table", "Employees") });
            if (a.Rows.Count > 0)
            {
                foreach (DataRow i in a.Rows)
                {
                    Employees manager = new Employees(i);
                    if (manager.Name == name)

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
                        double salary, Level level, int state)
        {

            string[] vars = { "@id", "@idMan", "@userName", "@passWord", "@name", "@sex", "@phone", "@address", "@salary", "@level", "@state" };
            ArrayList array = new ArrayList(new Object[] { id, idMan, userName, pass, name, sex, phone, add, salary, level, state });

            List<SqlParameter> t = DAO.turntoListParam(array, vars);
            if (DAO.MyExecuteNonQuery("updateEmployees", CommandType.StoredProcedure, t))
                return true;
            return false;
        }
        //Mới bổ sung

        public ObservableCollection<Employees> SearchEmployees(string keyword, string condition)
        {
            ObservableCollection<Employees> returnlist = new ObservableCollection<Employees>();

            if (keyword == "")
                keyword = "null";
            DataTable data = DAO.MyExecuteNonQuery_data("pro_searchEmployee", CommandType.StoredProcedure, new List<SqlParameter>() { new SqlParameter("@key", keyword), new SqlParameter("@condition", condition) });

            if (data != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    returnlist.Add(new Employees(row));
                }
                return returnlist;
            }
            return null;
        }


        public bool ExistUsername(string username)
        {
            DataTable data = DAO.MyExecuteNonQuery_data("isExistUsername", CommandType.StoredProcedure, new List<SqlParameter>() { new SqlParameter("@username", username) });
            if (data == null || data.Rows.Count == 0)
                return false;
            return true;
            
        }


        public Employees getEmpByID(int id)
        {
            DataTable data = DAO.MyExecuteNonQuery_data("SELECT * FROM fn_getEmpByID(@id)", CommandType.Text,
                                                            new List<SqlParameter>() { new SqlParameter("@id", id) });
            if (data != null)
                return new Employees(data.Rows[0]);
            else
                return null;
        }
    }

}