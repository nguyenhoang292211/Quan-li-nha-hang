using Restaurant.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;

namespace Restaurant.Controller
{
    class statisticController
    {
        DAO db = new DAO();

        public statisticController()
        {

        }


        // 1. Load All Bills
        public statistics loadData(int groupBy, DateTime start, DateTime end)
        {
            DataTable tableReveue = new DataTable();
            DataTable tableXYItem = new DataTable();

            List<SqlParameter> listPara = new List<SqlParameter>();
            listPara = db.turntoListParam(new ArrayList() { start, end }, new string[] { "@start", "@end" });
            tableReveue = db.MyExecuteNonQuery_data("select * from fn_RevenuePerDay(@start, @end)", CommandType.Text, listPara);

            if (groupBy == 0) // Group By Type Of Food
            {
                tableXYItem = db.MyExecuteNonQuery_data("select * from fn_getStatisticByTypeFood(@start, @end)", CommandType.Text, listPara);
            }
            else if (groupBy == 1)
            {
                tableXYItem = db.MyExecuteNonQuery_data("select * from fn_getStatisticBySpecificalFood(@start, @end)", CommandType.Text, listPara);
            }
            Revenue myRevenueValue=null;
            if(tableReveue != null)
            {
                if (tableReveue.Rows.Count <= 1 )
                {
                    if (tableReveue.Rows.Count > 0)
                        myRevenueValue = new Revenue(tableReveue.Rows[0]);
                    else
                        myRevenueValue = new Revenue();
                }
                else
                {
                    myRevenueValue = new Revenue(tableReveue.Rows[0]);
                    for (int i = 1; i < tableReveue.Rows.Count; i++)
                    {
                        myRevenueValue.NumBill += Convert.ToInt32(tableReveue.Rows[i].ItemArray[4]);
                        myRevenueValue.TotalRevenue += Convert.ToInt32(tableReveue.Rows[i].ItemArray[2]);
                        myRevenueValue.NumCancel += Convert.ToInt32(tableReveue.Rows[i].ItemArray[3]);
                        myRevenueValue.NumBooking += Convert.ToInt32(tableReveue.Rows[i].ItemArray[5]);
                    }
                }

            }
                    
            List<xyStatistic> myXYValue = new List<xyStatistic>();
            if(tableXYItem!=null)
            for (int i = 0; i < tableXYItem.Rows.Count; i++)
            {
                myXYValue.Add(new xyStatistic(tableXYItem.Rows[i]));
            }
            statistics resultStatistic = new statistics();
            resultStatistic.Revenue = myRevenueValue;
            resultStatistic.XyBarChart = myXYValue;
            resultStatistic.convertToPercent();

            return resultStatistic;
        }
    }
}
