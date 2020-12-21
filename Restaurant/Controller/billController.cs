using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using Restaurant.Model;

namespace Restaurant.Controller
{
    class billController
    {
        DAO DAO = new DAO();
        //hàm lấy dữ liệu từ database đổ lên
        public ObservableCollection<Bills> loadBill()
        {
            DataTable data = DAO.ExecuteQueryDataSet("Select * from Bill", CommandType.Text);
            //tạo 1 list để luwu trữ dữ liệu lấy từ database
            ObservableCollection<Bills> list = new ObservableCollection<Bills>();
            for (int i = 0; i < data.Rows.Count; i++)
            {

                Bills a = new Bills();
                a.Id = int.Parse(data.Rows[i][0].ToString());
              //  a.IdOrder = int.Parse(data.Rows[i][2].ToString());
                a.TimePayment = DateTime.Parse(data.Rows[i][1].ToString());
                a.Deal = double.Parse(data.Rows[i][2].ToString());
                a.TotalCost = double.Parse(data.Rows[i][3].ToString());
                a.Totalcoststring = a.TotalCost.ToString() + " VND";
                if (data.Rows[i][7].ToString() == "True")
                {
                    a.State = stateBill.finish;
                }
                else if (data.Rows[i][7].ToString() == "False")
                {
                    a.State = stateBill.spending;
                }
                a.LoyalFriend = int.Parse(data.Rows[i][7].ToString());
                list.Add(a);
            }
            return list;
        }


        public ObservableCollection<Bills> templateFunction(string nameFunction, string[] listNotationPara, ArrayList listParaValue)
        {
            DataTable data;
            if (listNotationPara != null)
            {
                List<SqlParameter> para = new List<SqlParameter>();
                for (int i = 0; i < listNotationPara.Length; i++)
                {
                    para.Add(new SqlParameter(listNotationPara[i], listParaValue[i]));
                }

                data = DAO.ExecuteQueryDataSet("select * from " + nameFunction, CommandType.Text, para);
            }
            else
            {
                data = DAO.ExecuteQueryDataSet("select * from " + nameFunction, CommandType.Text);
            }



            ObservableCollection<Bills> list = new ObservableCollection<Bills>();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                Bills a = new Bills(data.Rows[i]);
                list.Add(a);
            }
            return list;
        }

        // 1. Load All Bills
        public ObservableCollection<Bills> load()
        {
            return templateFunction("loadBill", null, null);
        }


        public ObservableCollection<Bills> findById(int idBill)
        {
            return templateFunction("fn_billById(@id)", new string[] { "@id" }, new ArrayList() { idBill });
        }

        // State 0 - Find Bill by state - cancel, complete
        public ObservableCollection<Bills> findByState(int state)
        {
            return templateFunction("fn_billByState(@state)", new string[] { "@state" }, new ArrayList() { (state == 0) ? false : true });
        }


        public ObservableCollection<Bills> findByNameCus(string cus)
        {
            return templateFunction("fn_billByNameCus(@name)", new string[] { "@name" }, new ArrayList() { cus });
        }

        public ObservableCollection<Bills> findByNameEmp(string emp)
        {
            return templateFunction("fn_billByNameEmp(@name)", new string[] { "@name" }, new ArrayList() { emp });
        }

        public ObservableCollection<Bills> findByDateTime(DateTime startTime, DateTime endTime)
        {
            return templateFunction("fn_billByDateTime(@start, @end)", new string[] { "@start", "@end" }, new ArrayList() { startTime, endTime });
        }
        public Invoice load_Invoice(int id)
        {
            DataTable da1;
            DataTable da2;
            List<SqlParameter> listPara = new List<SqlParameter>() { new SqlParameter("@id", id) };
            Invoice i_result;
            da1 = DAO.ExecuteQueryDataSet("load_Invoice", CommandType.StoredProcedure, listPara);
            da2 = DAO.ExecuteQueryDataSet("pro_loadDishInBill", CommandType.StoredProcedure, listPara);

            i_result = new Invoice(da1.Rows[0]);
            List<dish_invoice> i2 = new List<dish_invoice>();
            for (int i = 0; i < da2.Rows.Count; i++)
            {
                dish_invoice itemDish = new dish_invoice(da2.Rows[i]);
                i2.Add(itemDish);
            }
            i_result.Dishes = i2;
            return i_result;


        }


        public bool addNewBill( int deal, int totalcost, int idem, int idcus, int state, int discountpoint, int idOrder)
        {
            string[] vars = {  "@deal", "@totalcost", "@idem","@idcus","@state","@loyalFriend" ,"@idOrder"};
            ArrayList array = new ArrayList(new Object[] { deal, totalcost, idem,idcus, state, discountpoint, idOrder });

            List<SqlParameter> t = DAO.turntoListParam(array, vars);

            return DAO.MyExecuteNonQuery("pro_addNewBill", CommandType.StoredProcedure, t);
        }


    }
}
