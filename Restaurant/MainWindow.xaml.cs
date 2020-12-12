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
using Restaurant.Model;
using Restaurant.View;

namespace Restaurant
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        
        private void Info_Loaded_1(object sender, RoutedEventArgs e)
        {

        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

       

        private void EnterNVpage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            showFrame.Navigate(new Nhanvien_page());
        }

        private void EnterBHpage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            showFrame.Navigate(new Order_menu(new Orders(17,3,3,2,DateTime.Now)));
        }

        private void EnterMApage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            showFrame.Navigate(new Monan_page());
        }

        private void EnterKHpage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            showFrame.Navigate(new Khachhang_page());
        }

        private void EnterBillpage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            showFrame.Navigate(new Hoadon_page());
        }

        private void EnterDTpage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            showFrame.Navigate(new Baocao_page());
        }

      
    }
}
