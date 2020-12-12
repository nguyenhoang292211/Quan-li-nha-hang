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
using DevExpress.Utils.CommonDialogs.Internal;
using Microsoft.Win32;

namespace Restaurant
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        userController userControl = new userController();
        //tạo biến để lưu triwx giá trị phân quyền =0 là nhân viên, 1 là chủ
        bool level;
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(txbName.Text.Length==0||txbPass.Password.Length==0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu để truy cập!");
            }    
            else
            {
                if(userControl.checkAccount(txbName.Text.ToString(), txbPass.Password.ToString()))
                {
                    level=userControl.getLevelAccount(txbName.Text.ToString(), txbPass.Password.ToString());
                    MessageBox.Show(level.ToString());
                }    
            }    
        }

        private void login_load(object sender, RoutedEventArgs e)
        {
            //Đây là code để load tất cả các server đang có không càn phải chọn
            try
            {
                RegistryKey rk = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server");
                String[] instances = (String[])rk.GetValue("InstalledInstances");
                if(instances.Length>0)
                {
                    foreach(string element in instances)
                    {
                        if (element == "MSSQLSERVER")
                        {
                            cmbServer.Items.Add(System.Environment.MachineName);
                        }
                        else
                            cmbServer.Items.Add(System.Environment.MachineName + @"\" + element);
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}
