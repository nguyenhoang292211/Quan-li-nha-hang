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
            showFrame.Navigate(new TrangChu());
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

            showFrame.Navigate(new orderTable());
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

        private void Banhang_dock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            showFrame.Navigate(new orderTable());
        }

        private void KM_btn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            showFrame.Navigate(new Khuyenmai_page());
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            showFrame.Navigate(new TrangChu());
        }

 
   
        private void Button_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Dialog a = new Dialog() { Message = "Bạn thực sự muốn thoát chương trình ?" };
            a.Owner = Window.GetWindow(this);
            a.ShowDialog();
            if (a.DialogResult == true)
                Application.Current.Shutdown();
        }

        private void Label_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            Dialog a = new Dialog() { Message = "Bạn thực sự muốn thoát chương trình ?" };
            a.Owner = Window.GetWindow(this);
            a.ShowDialog();
            if (a.DialogResult == true)
                Application.Current.Shutdown();
        }
    }
}
