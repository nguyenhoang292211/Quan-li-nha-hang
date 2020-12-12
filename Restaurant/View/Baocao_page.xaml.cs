using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
<<<<<<< HEAD

=======
using Restaurant.Controller;
using Restaurant.Model;
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
namespace Restaurant.View
{
    /// <summary>
    /// Interaction logic for Baocao_page.xaml
    /// </summary>
    public partial class Baocao_page : Page
    {
<<<<<<< HEAD
        private ObservableCollection<TypeFood> listType;
        //private ObservableCollection<TypeFood> listType = new ObservableCollection<TypeFood>() {
        //    new TypeFood(){ Name="Com",Value=22},
        //    new TypeFood(){Name="Nuoc", Value=23},
        //    new TypeFood(){Name="Trang mieng", Value=24}
        //};

        private ObservableCollection<Reveneu> listReveneu = new ObservableCollection<Reveneu>()
        {
            new Reveneu(){Name="Quan", TotalReveneu=2000},
            new Reveneu(){Name="Ao", TotalReveneu=2003},
            new Reveneu(){Name="Tui", TotalReveneu=4000}
        };
        public Baocao_page()
        {
            ListType = new ObservableCollection<TypeFood>() {
            new TypeFood(){ Name="Com",Value=22},
            new TypeFood(){Name="Nuoc", Value=23},
            new TypeFood(){Name="Trang mieng", Value=24}
        };

            InitializeComponent();
            double sum = 0;
            for (int i = 0; i < 3; i++)
            {
                sum += listReveneu[i].TotalReveneu;
            }
            for (int i = 0; i < 3; i++)
            {
                listReveneu[i].TotalReveneu = (listReveneu[i].TotalReveneu * 100 / sum);
            }
            pieChart1.ItemsSource = ListReveneu;
            columnChart2.ItemsSource = ListType;
            //double sum = 0;
            //for (int i = 0; i < 3; i++)
            //{
            //    sum += listType[i].Value;
            //}
        }

        public ObservableCollection<Reveneu> ListReveneu 
        {
            get
            { return listReveneu; }
            set
            {
                listReveneu = value;

            }
        }
        public ObservableCollection<TypeFood> ListType 
        {
            get
            {
                return listType;
            }
            set
            {
                listType = value;
            }
        }

        public class Reveneu
        {
            private string name;
            private double totalReveneu;
            public Reveneu()
            {

            }
            public string Name { get => name; set => name = value; }
            public double TotalReveneu { get => totalReveneu; set => totalReveneu = value; }
        }

        public class TypeFood
        {
            public TypeFood()
            {

            }
            private string name;
            private double iValue;

            public string Name { get => name; set => name = value; }
            public double Value { get => iValue; set => iValue = value; }
=======
        private ObservableCollection<string> listBy = new ObservableCollection<string> { "Loại món ăn", "Món ăn" };
        private int bySelected = 0;
        private DateTime startDate;
        private DateTime endDate;
        private statistics objStatistic;
        statisticController dataOn = new statisticController();
        public DateTime StartDate
        {
            get
            {
                return  startDate;
            }
            set { startDate = value;

                DateTime? startDay = StartDate;
                DateTime? endDay = EndDate;
                if (endDay.HasValue && startDay.HasValue)
                {
                    if (endDay >= startDay)
                    {

                        DateTime trueStart = startDay.Value;
                        DateTime trueEnd = endDay.Value;
                        //Cal function statitis By
                        loadStatisticByDate(trueStart, trueEnd);
                        mappingData();
                    }
                }
            }
        }
        public void mappingData()
        {
            this.DataContext = ObjStatistic;
            if(BySelected==0)
            {
                pieChart1.ItemsSource = ObjStatistic.XyPieChart;

                // AddItem Resource
                //   pieChart1.ItemsSource = ObjStatistic.XyPieChart;
                columnChart1.ItemsSource = objStatistic.XyBarChart;

            }
            else if (BySelected==1)
            {
                pieChart1.ItemsSource = ObjStatistic.XyPieChart;

                // AddItem Resource
                //   pieChart1.ItemsSource = ObjStatistic.XyPieChart;
                columnChart1.ItemsSource = objStatistic.XyBarChart;

            }
        }
        public void loadStatisticByDate(DateTime start, DateTime end)
        {
            if (BySelected == 0)  //Category
            {
                ObjStatistic = dataOn.loadData(0, StartDate, EndDate);
            }
            else if (BySelected == 1)  //Dish
            {
                ObjStatistic = dataOn.loadData(1, StartDate, EndDate);

            }
            else if (BySelected == 2)  //Type Of Bill
            {

            }
        }
        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value;

                DateTime? startDay = StartDate;
                DateTime? endDay = EndDate;
                if (endDay.HasValue && startDay.HasValue)
                {
                    if (endDay >= startDay)
                    {
                       
                        DateTime trueStart = startDay.Value;
                        DateTime trueEnd = endDay.Value;
                        //Cal function statitis By
                        loadStatisticByDate(trueStart, trueEnd);
                        mappingData();
                    }
                }
            }
        }

        public int BySelected
        {
            get { return bySelected; }

            set { bySelected = value;  loadStatisticByDate(startDate, endDate); loadStatistic(); }
        }
        public statistics ObjStatistic { get => objStatistic; set => objStatistic = value; }
      
    

        public void loadStatistic()
        {
            cmbBy.ItemsSource = listBy;
            this.DataContext = objStatistic;
            editFromDate.SelectedDate = DateTime.Now;
            editToDate.SelectedDate = DateTime.Now;
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;

            pieChart1.ItemsSource = ObjStatistic.XyPieChart;
           
            // AddItem Resource
            //   pieChart1.ItemsSource = ObjStatistic.XyPieChart;
            columnChart1.ItemsSource = objStatistic.XyBarChart;
       
            
        }
        public Baocao_page()
        {
            
            InitializeComponent();

            loadStatistic();

            editFromDate.SelectedDate = startDate;
            editToDate.SelectedDate = endDate;
            cmbBy.SelectedIndex = 0;
          
        }

  
       

        private void editToDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            EndDate = editToDate.SelectedDate.Value;
        }

        private void editFromDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            StartDate = editFromDate.SelectedDate.Value;

         
        }

        private void cmbBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BySelected = cmbBy.SelectedIndex;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            loadStatistic();

            editFromDate.SelectedDate = startDate;
            editToDate.SelectedDate = endDate;
            cmbBy.SelectedIndex = 0;
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
        }
    }
}
