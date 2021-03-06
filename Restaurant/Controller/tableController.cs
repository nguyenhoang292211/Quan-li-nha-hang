﻿using System;
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
        //hàm lấy dữ liệu từ database đổ lên
        public ObservableCollection<Seats> loadSeat()
        {
            DataTable data = DAO.ExecuteQueryDataSet("Select * from Seats", CommandType.Text);
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
                else
                {
                    a.State = stateSeat.book;
                    a.StateColor = "#abdee6";
                }
                a.IdArea = int.Parse(data.Rows[i][2].ToString());
                a.BookingTime = DateTime.Parse(data.Rows[i][3].ToString());
                list.Add(a);
            }
            return list;
        }





        //hàm thêm một bàn
        public bool addNewSeat(string id, string idArea)
        {

            SqlParameter Id = new SqlParameter("@id", id);
            SqlParameter IdArea = new SqlParameter("@idArea", idArea);
            SqlParameter State = new SqlParameter("@state", 1);
            List<SqlParameter> Seat = new List<SqlParameter>();
            Seat.Add(Id);
            Seat.Add(IdArea);
            Seat.Add(State);
            try
            {
                //gọi đến hàm thực thi procedure addNewSeat
                DAO.MyExecuteNonQuery("addNewSeat", CommandType.StoredProcedure, Seat);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            return true;
        }



        //xóa một bàn
        public bool deleteSeat(string id)
        {
            SqlParameter ID = new SqlParameter("@ID", id);
            List<SqlParameter> Seat = new List<SqlParameter>();
            Seat.Add(ID);
            try
            {
                //gọi đến procedure xóa bàn
                DAO.MyExecuteNonQuery("deleteSeat", CommandType.StoredProcedure, Seat);

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
