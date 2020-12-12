using System;
using System.Collections.Generic;
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
using System.Collections.ObjectModel;
using Restaurant.Model;
using System.Threading;
using Restaurant.Controller;

namespace Restaurant.View
{
    /// <summary>
    /// Interaction logic for orderTable.xaml
    /// </summary>
    public partial class orderTable : Page
    {
        //kiểu dữ liệu giống như list nhưng sẽ có cập nhập nếu thay đổi
        ObservableCollection<Seats> tables;
        ObservableCollection<Bills> bills;
        ObservableCollection<Area> areas;
        public orderTable()
        {
            InitializeComponent();
           
            Thread thread = new Thread(delegate ()
            {
                
                //Seats
               tableController dbSeats = new tableController();
                Tables = new ObservableCollection<Seats>(dbSeats.loadSeat());
                //Bill
                billController dbBills = new billController();
                Bills = new ObservableCollection<Bills>(dbBills.loadBill());
                //Areas
                areaController dbArea = new areaController();
                Areas = new ObservableCollection<Area>(dbArea.loadArea());


                Dispatcher.Invoke(() =>
                {
                    listviewShowTable.ItemsSource = Tables;
                    ProgressBar.IsEnabled = false;
                    ProgressBar.Visibility = Visibility.Hidden;
                    //bill
                    listviewShowBill.ItemsSource = Bills;
                    //area
                    listviewShowArea.ItemsSource = Areas;
                });

            });
            thread.Start();
        }

        internal ObservableCollection<Seats> Tables { get => tables; set => tables = value; }
        internal ObservableCollection<Bills> Bills { get => bills; set => bills = value; }
        internal ObservableCollection<Area> Areas { get => areas; set => areas = value; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void tagarea_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void ListviewShowTable_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void ListviewShowTable_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            
           
        }

        private void Btn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Seats seats = listviewShowTable.SelectedItem as Seats;
            if (seats != null)
            {
                MessageBox.Show(seats.IdArea.ToString());
            }
            else
                MessageBox.Show("no");
        }
    }
}
