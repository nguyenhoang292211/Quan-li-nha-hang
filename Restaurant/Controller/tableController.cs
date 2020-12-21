using System;
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
    class tableController
    {
        DAO DAO = new DAO();
        //hàm lấy toàn bộ bàn
        public ObservableCollection<Seats> loadSeat(int idArea,int type)
        {
            DataTable data;
            if (type==0)//load những bàn không bị disable
            {
                data = DAO.ExecuteQueryDataSet("Select * from Seats where idArea=" + idArea + "and state!=4", CommandType.Text);
            }
            else if (type == 1)//load những bàn đang trống
            {
                data = DAO.ExecuteQueryDataSet("Select * from Seats where idArea=" + idArea + "and state=1", CommandType.Text);
            }
            else if (type == 2)//load những bàn đang có khách
            {
                data = DAO.ExecuteQueryDataSet("Select * from Seats where idArea=" + idArea + "and state=2", CommandType.Text);
            }
            else if (type == 3)//load những bàn dat truoc
            {
                data = DAO.ExecuteQueryDataSet("Select * from Seats where idArea=" + idArea + "and state=3", CommandType.Text);
            }
            else//load toàn bộ bàn
            {
                data = DAO.ExecuteQueryDataSet("Select * from Seats where idArea=" + idArea, CommandType.Text);
            }    

            //tạo 1 list để luwu trữ dữ liệu lấy từ database
            ObservableCollection<Seats> list = new ObservableCollection<Seats>();
            for (int i = 0; i < data.Rows.Count; i++)
            {

                Seats a = new Seats();
                a.Id = int.Parse(data.Rows[i][0].ToString());
                a.NameSeat = "Bàn " + a.Id.ToString();
                if (int.Parse(data.Rows[i][1].ToString()) == 1)
                {
                    a.State = stateSeat.emty;
                    a.StateColor = "#cce2cb";
                }
                else if (int.Parse(data.Rows[i][1].ToString()) == 2)
                {
                    a.State = stateSeat.use;
                    a.StateColor = "#ffaea5";
                }
                else if (int.Parse(data.Rows[i][1].ToString()) == 3)

                {
                    a.State = stateSeat.book;
                    a.StateColor = "#abdee6";
                }
                else
                {
                    a.State = stateSeat.disable;
                    a.StateColor = "#957dad";
                }    
             
                a.IdArea = int.Parse(data.Rows[i][2].ToString());
                //a.BookingTime = DateTime.Parse(data.Rows[i][3].ToString());

                list.Add(a);
            }
            return list;
        }

        //hàm disable 1 bàn
        public bool DisableSeat(int id)
        {
            SqlParameter ID = new SqlParameter("@ID", id);
            List<SqlParameter> t = new List<SqlParameter>();
            t.Add(ID);
            try
            {
                DAO.MyExecuteNonQuery("DisableTable", CommandType.StoredProcedure, t);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            return true;
        }

        public bool EnableSeat(int id)
        {
            SqlParameter ID = new SqlParameter("@ID", id);
            List<SqlParameter> t = new List<SqlParameter>();
            t.Add(ID);
            try
            {
                DAO.MyExecuteNonQuery("EnableTable", CommandType.StoredProcedure, t);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            return true;
        }

        //hàm thêm một bàn
        public bool addNewSeat(int idArea)
        {
            SqlParameter IdArea = new SqlParameter("@idArea", idArea);
            List<SqlParameter> Seat = new List<SqlParameter>();
            Seat.Add(IdArea);
            try
            {
                //gọi đến hàm thực thi procedure addNewSeat
                DAO.MyExecuteNonQuery("AddNewSeat", CommandType.StoredProcedure, Seat);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            return true;
        }
        //hàm đổi trạng thái 1 bàn
        public bool ChangeStateSeat(int id, int state)
        {

            SqlParameter Id = new SqlParameter("@id", id);
            SqlParameter State = new SqlParameter("@state", state);
            List<SqlParameter> Seat = new List<SqlParameter>();
            Seat.Add(Id);
            Seat.Add(State);
            try
            {
                //gọi đến hàm thực thi procedure ChangeStateSeat
                DAO.MyExecuteNonQuery("ChangeStateSeat", CommandType.StoredProcedure, Seat);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            return true;
        }
        //hàm chuyển bàn
        public bool ChangeSeat(int id1,int id2)
        {
            SqlParameter Id1 = new SqlParameter("@id1", id1);
            SqlParameter Id2 = new SqlParameter("@id2", id2);
            List<SqlParameter> Seat = new List<SqlParameter>();
            Seat.Add(Id1);
            Seat.Add(Id2);
            try
            {
                //gọi đến hàm thực thi procedure ChangeSeat
                DAO.MyExecuteNonQuery("ChangeSeat", CommandType.StoredProcedure, Seat);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            return true;
        }
        //hàm gộp bàn
        public bool MergeSeat(int id1, int id2)
        {
            SqlParameter Id1 = new SqlParameter("@id1", id1);
            SqlParameter Id2 = new SqlParameter("@id2", id2);
            List<SqlParameter> Seat = new List<SqlParameter>();
            Seat.Add(Id1);
            Seat.Add(Id2);
            try
            {
                //gọi đến hàm thực thi procedure ChangeSeat
                DAO.MyExecuteNonQuery("MergeSeat", CommandType.StoredProcedure, Seat);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            return true;
        }
    }
}
