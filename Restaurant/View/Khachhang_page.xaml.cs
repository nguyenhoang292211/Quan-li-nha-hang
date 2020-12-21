using Restaurant.Controller;
using Restaurant.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Text.RegularExpressions;


namespace Restaurant.View
{
    /// <summary>
    /// Interaction logic for Khachhang_page.xaml
    /// </summary>
    public partial class Khachhang_page : Page
    {
        customersControllers dbCustomers = new customersControllers();
        ObservableCollection<Customers> listCustomers = new ObservableCollection<Customers>();
        public Khachhang_page()
        {
            InitializeComponent();
            listCustomers = dbCustomers.LoadData_Customers();
            listCus.ItemsSource = listCustomers;
        }
        private void btnAddProm_Click(object sender, RoutedEventArgs e)
        {
            if (txbID.Text != "")
            {
                txbID.Text = null;
                txbName.Text = null;
                txbPhone.Text = null;
                txbPoint.Text = null;
            }
            else
            {
                txbID.Text = null;
                if (txbName.Text != "" && txbPhone.Text != "" && txbPoint.Text != "")
                {
                    dbCustomers.addCustomers(Convert.ToString(txbPhone.Text), Convert.ToString(txbName.Text), Convert.ToInt32(txbPoint.Text));
                    listCus.ItemsSource = dbCustomers.LoadData_Customers();
                    txbName.Text = null;
                    txbPhone.Text = null;
                    txbPoint.Text = null;
                }
                else
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin trước khi thêm KHÁCH HÀNG!!!");
            }
        }
        private void listCus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Customers temp = listCus.SelectedItem as Customers;
            if (temp != null)
            {
                txbID.Text = temp.Id.ToString();
                txbPhone.Text = temp.Phone.ToString();
                txbName.Text = temp.Name.ToString();
                txbPoint.Text = temp.Point.ToString();
            }
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int idd = int.Parse(txbID.Text);
            txbID.Text = "";
            txbName.Text = "";
            txbPhone.Text = "";
            txbPoint.Text = "";

            dbCustomers.DeleteCustomers(idd);
            listCus.ItemsSource = dbCustomers.LoadData_Customers();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (txbID.Text == null)
            {
               MessageBox.Show("Vui lòng chọn KHÁCH HÀNG trước khi chỉnh sửa!!!");
            }
            else
            {
                if (txbName.Text != "" || txbPhone.Text != "" || txbPoint.Text != "")
                {
                    dbCustomers.EditCustomers(Convert.ToInt32(txbID.Text), Convert.ToString(txbName.Text), txbPhone.Text, Convert.ToInt32(txbPoint.Text));
                    listCustomers = dbCustomers.LoadData_Customers();
                    listCus.ItemsSource = listCustomers;
                }
            }
        }

        private void btnFindCustomers_Click(object sender, RoutedEventArgs e)
        {
            if (txbFindCus.Text == "")
            {
                listCustomers = new ObservableCollection<Customers>(dbCustomers.LoadData_Customers());
                listCus.ItemsSource = listCustomers;
            }
            else
            {
                ObservableCollection<Customers> searchcustomers = new ObservableCollection<Customers>();

                searchcustomers = dbCustomers.SearchCustomers(txbFindCus.Text);
                if (searchcustomers.Count > 0)
                    listCus.ItemsSource = searchcustomers;
                else
                {
                    var dialog = new Dialog() { Message = "Do not find any customers!" };
                    dialog.Owner = Window.GetWindow(this);
                    dialog.ShowDialog();
                }
                txbFindCus.Text = "";
            }
        }

        private void txbFindCus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnFindCustomers_Click(sender, e);
            }
        }
        private void ComboBoxItem_Selected_1(object sender, RoutedEventArgs e)
        {
            listCus.ItemsSource = dbCustomers.LoadData_Customers();
        }

        private void ComboBoxItem_Selected_2(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Customers> searchpoint = new ObservableCollection<Customers>();
            searchpoint = dbCustomers.PointBTCustomers();
            if (searchpoint.Count > 0)
                listCus.ItemsSource = searchpoint;
        }

        private void ComboBoxItem_Selected_3(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Customers> searchpoint = new ObservableCollection<Customers>();
            searchpoint = dbCustomers.PointTTCustomers();
            if (searchpoint.Count > 0)
                listCus.ItemsSource = searchpoint;
        }

        private void txbPoint_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void btnReload_Click(object sender, RoutedEventArgs e)
        {
            txbID.Text = null;
            listCus.ItemsSource = dbCustomers.LoadData_Customers();
            txbName.Text = null;
            txbPhone.Text = null;
            txbPoint.Text = null;
        }

        private void txbPhone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}

