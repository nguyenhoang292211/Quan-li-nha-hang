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

namespace Restaurant.View
{
    /// <summary>
    /// Interaction logic for Baocao_page.xaml
    /// </summary>
    public partial class Baocao_page : Page
    {
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
        }
    }
}
