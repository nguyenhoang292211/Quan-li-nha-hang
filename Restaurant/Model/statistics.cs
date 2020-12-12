using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Model
{
    public class statistics
    {
        private Revenue revenue;
        private List<xyStatistic> xyPieChart= new List<xyStatistic>();
        private List<xyStatistic> xyBarChart;

        public Revenue Revenue { get => revenue; set => revenue = value; }
        public List<xyStatistic> XyPieChart { get => xyPieChart; set => xyPieChart = value; }
        public List<xyStatistic> XyBarChart { get => xyBarChart; set => xyBarChart = value; }

        public void convertToPercent()
        {
           double  sumNumber=0, sumTotalRevenue = 0;

            foreach (xyStatistic item in this.XyBarChart)
            {
                sumNumber += item.Number;
                sumTotalRevenue += item.TotalRevenue;
            }
           
            for(int i=0; i< this.XyBarChart.Count; i++)
            {
                xyStatistic temp = new xyStatistic();

                temp.Name = XyBarChart[i].Name;
                temp.Number =Math.Round((double) XyBarChart[i].Number *100/ sumNumber,2);
                temp.TotalRevenue = Math.Round((double)XyBarChart[i].TotalRevenue *100/ sumTotalRevenue,2);
                XyPieChart.Add(temp);
            }
        }


    }

    public class Revenue
    {
        public Revenue()
        {

        }
        public Revenue(DataRow row)
        {
            this.ID =Convert.ToInt32( row[0]);
            this.StatisticDate = Convert.ToDateTime(row[1]);
            this.TotalRevenue = Convert.ToInt32(row[2]);
            this.NumCancel = Convert.ToInt32(row[3]);
            this.NumBill = Convert.ToInt32(row[4]);
            this.NumBooking = Convert.ToInt32(row[5]);
        }
        private int iD;
        private DateTime statisticDate;
        private int totalRevenue;
        private int numCancel;
        private int numBill;
        private int numBooking;

        public int ID { get => iD; set => iD = value; }
        public DateTime StatisticDate { get => statisticDate; set => statisticDate = value; }
        public int TotalRevenue { get => totalRevenue; set => totalRevenue = value; }
        public int NumCancel { get => numCancel; set => numCancel = value; }
        public int NumBill { get => numBill; set => numBill = value; }
        public int NumBooking { get => numBooking; set => numBooking = value; }


    }
    public class xyStatistic
    {
        public xyStatistic()
        {

        }
        public xyStatistic(DataRow dataRow)
        {
            this.Name = dataRow[0].ToString();
            this.Number = Convert.ToDouble(dataRow[1]);
            this.TotalRevenue = Convert.ToDouble(dataRow[2]);

        }

      
        private Double number;
        private string name;
        private double totalRevenue;

        public double Number { get => number; set => number = value; }
        public string Name { get => name; set => name = value; }
        public double TotalRevenue { get => totalRevenue; set => totalRevenue = value; }
    }
}