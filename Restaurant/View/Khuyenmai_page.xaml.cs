using Restaurant.Controller;
using Restaurant.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Text.RegularExpressions;

using System.Windows.Input;

namespace Restaurant.View
{

    public partial class Khuyenmai_page : Page
    {
        eventsController dbEvents = new eventsController();
        ObservableCollection<Events> listEvent = new ObservableCollection<Events>();

        public Khuyenmai_page()
        {
            InitializeComponent();
            Thread thread = new Thread(delegate ()
            {
                Dispatcher.Invoke(() =>
                {
                    //load danh sách khuyeesn mai
                    listEvent = dbEvents.LoadData_Events();
                    listProm.ItemsSource = listEvent;
                });
            });
            thread.Start();
        }

        private void btnAddProm_Click(object sender, RoutedEventArgs e)
        {
            if (txbID.Text != "")
            {
                txbID.Text = null;
                txbName.Text = null;
                txbDiscount.Text = null;
                startDate.Text = null;
                endtDate.Text = null;
            }
            else
            {
                if (txbName.Text != "" && txbDiscount.Text != "" && startDate.Text != "" && endtDate.Text != "")
                {

                    dbEvents.addEvents(Convert.ToString(txbName.Text), Convert.ToDateTime(startDate.SelectedDate), Convert.ToDateTime(endtDate.SelectedDate), Convert.ToDouble(txbDiscount.Text));
                    listProm.ItemsSource = dbEvents.LoadData_Events();
                    txbName.Text = null; txbDiscount.Text = null; startDate.Text = null; endtDate.Text = null;
                }
                else
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin trước khi thêm khuyến mãi!!!");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int idd = int.Parse(txbID.Text);
            txbID.Text = "";
            txbName.Text = "";
            startDate.Text = "";
            endtDate.Text = "";
            txbDiscount.Text = "";

            dbEvents.DeleteEvents(idd);
            listProm.ItemsSource = dbEvents.LoadData_Events();
        }

        private void listProm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Events temp = listProm.SelectedItem as Events;
            if (temp != null)
            {
                txbID.Text = temp.Id.ToString();
                txbName.Text = temp.Name.ToString();
                txbDiscount.Text = temp.Discount.ToString();
                startDate.SelectedDate = temp.StartDate;
                endtDate.SelectedDate = temp.EndDate;
            }
        }

        private void btnFindEvents_Click(object sender, RoutedEventArgs e)
        {
            if (txbFindEvents.Text == "")
            {
                listEvent = new ObservableCollection<Events>(dbEvents.LoadData_Events());
                listProm.ItemsSource = listEvent;
            }
            else
            {
                ObservableCollection<Events> searchcustomers = new ObservableCollection<Events>();

                searchcustomers = dbEvents.SearchEvents(txbFindEvents.Text);
                if (searchcustomers.Count > 0)
                    listProm.ItemsSource = searchcustomers;
                else
                {
                    var dialog = new Dialog() { Message = "Do not find any events!" };
                    dialog.Owner = Window.GetWindow(this);
                    dialog.ShowDialog();
                }
                txbFindEvents.Text = "";
            }
        }

        private void txbFindEvents_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                btnFindEvents_Click(sender, e);
        }
        private void ComboBoxItem_Selected_1(object sender, RoutedEventArgs e)
        {
            listProm.ItemsSource = dbEvents.LoadData_Events();
        }

        private void ComboBoxItem_Selected_2(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Events> searchevents = new ObservableCollection<Events>();
            searchevents = dbEvents.TrangThaiConHanEvents();
            if (searchevents.Count > 0)
                listProm.ItemsSource = searchevents;
        }

        private void ComboBoxItem_Selected_3(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Events> searchevents = new ObservableCollection<Events>();
            searchevents = dbEvents.TrangThaiHetHanEvents();
            if (searchevents.Count > 0)
                listProm.ItemsSource = searchevents;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (txbName.Text != "" || txbDiscount.Text != "" || startDate.Text != "" || endtDate.Text != "")
            {
                dbEvents.EditEvents(Convert.ToInt32(txbID.Text), Convert.ToString(txbName.Text), Convert.ToDateTime(startDate.SelectedDate), Convert.ToDateTime(endtDate.SelectedDate), Convert.ToDouble(txbDiscount.Text));
                listEvent = dbEvents.LoadData_Events();
                listProm.ItemsSource = listEvent;
            }
            else if(txbID.Text==null)
            {
                MessageBox.Show("Vui lòng chọn khuyến mãi trước khi chỉnh sửa!!!");
            }    
        }

        //hàm kiểm tra cái nhập vào có phải là số hay không
        private void txbDiscount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
