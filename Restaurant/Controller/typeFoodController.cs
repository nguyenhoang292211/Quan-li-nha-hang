using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Model;
using System.Data;
using System.Data.SqlClient;
using System.Collections.ObjectModel;

namespace Restaurant.Controller
{
   public class typeFoodController
    {
        DAO db = new DAO();
        public typeFoodController()
        {

        }
        //Template for get data
        public ObservableCollection<TypeFoods> templateFunction(string nameFunction, string[] listNotationPara, ArrayList listParaValue)
        {
            DataTable data;
            if (listNotationPara != null)
            {
                List<SqlParameter> para = new List<SqlParameter>();
                para = db.turntoListParam(listParaValue, listNotationPara);
                data = db.ExecuteQueryDataSet(  nameFunction, CommandType.StoredProcedure, para);
            }
            else
            {
                data = db.ExecuteQueryDataSet(  nameFunction, CommandType.StoredProcedure);
            }



            ObservableCollection<TypeFoods> list = new ObservableCollection<TypeFoods>();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                TypeFoods a = new TypeFoods(data.Rows[i]);
                list.Add(a);
            }
            return list;
        }
        public ObservableCollection<TypeFoods> loadTypeFood(String state)
        {
            // return templateFunction("pro_loadTypeFood", new string[] { "@state" }, new ArrayList() { state});

            DataTable a = new DataTable();
            ObservableCollection<TypeFoods> listDish = new ObservableCollection<TypeFoods>();
            a = db.ExecuteQueryDataSet("pro_loadTypeFood",System.Data.CommandType.StoredProcedure, new List<SqlParameter> { new SqlParameter("@state", state) });
            for (int i = 0; i < a.Rows.Count; i++)
            {
                TypeFoods d = new TypeFoods(a.Rows[i]);
                listDish.Add(d);
            }
            return listDish;
        }
        public ObservableCollection<TypeFoods> findTypeFoodByName(string name, string state)
        {
            return templateFunction("pro_loadTypeFoodByName", new string[] { "@name", "@state"}, new ArrayList() {name,state});
        }
        public ObservableCollection<Dishes> listDishByIdType(int idType)
        {
            DataTable a = new DataTable();
            ObservableCollection<Dishes> listDish = new ObservableCollection<Dishes>();
            a = db.ExecuteQueryDataSet("pro_findTypeFoodByName", CommandType.StoredProcedure, new List<SqlParameter> { new SqlParameter("@id", idType) });
            for(int i=0; i< a.Rows.Count; i++)
            {
                Dishes d = new Dishes(a.Rows[i]);
                listDish.Add(d);
            }
            return listDish;
        }   

        public void pro_editTypeFood(int id, bool state, string name)
        {
           List<SqlParameter> listPara = db.turntoListParam(new ArrayList() { id, name, state }, new string[] { "@id", "@name", "@state" });

            db.MyExecuteNonQuery("pro_editTypeFood", CommandType.StoredProcedure, listPara);

        }
        public void pro_addTyeFood(string name, bool state)
        {
            List<SqlParameter> listPara = db.turntoListParam(new ArrayList() { name, state }, new string[] { "@name", "@state" });
            db.MyExecuteNonQuery("pro_addTypeFood", CommandType.StoredProcedure, listPara);
        }
    }
}
