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

namespace Restaurant.View
{
    /// <summary>
    /// Interaction logic for TrangChu.xaml
    /// </summary>
    public partial class TrangChu : Page
    {
        public TrangChu()
        {
            InitializeComponent();
        }

        private void btn_DoanhThu_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Baocao_page());
        }

        private void btn_Order_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new orderTable());
        }

        private void btn_Sale_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Khuyenmai_page());
        }

        private void btn_Dishes_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Monan_page());
        }

        private void btn_Cus_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Khachhang_page());
        }

        private void btn_Emp_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Nhanvien_page());
        }

        private void btn_Bill_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Hoadon_page());
        }
    }
}
