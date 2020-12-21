using System.Windows;
using Restaurant.Model;
using Restaurant.Controller;
using Restaurant.View;

namespace Restaurant
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            txbName.Text = null;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(txbName.Text.Length==0||txbPass.Password.Length==0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu để truy cập!");
            }    
            else
            {
                    DAO.username = txbName.Text.ToString();
                    DAO.password = txbPass.Password.ToString();
                    DAO a = new DAO(txbName.Text.ToString(), txbPass.Password.ToString());
                try
                {
                    userController userControl = new userController();
                    //userControl.checkAccount(txbName.Text.ToString(), txbPass.Password.ToString());
                    MainWindow temp = new MainWindow();
                    this.Close();
                    temp.ShowDialog();
                }
                catch
                {
                    MessageBox.Show("Sai mật khẩu hoặc tên đăng nhập!!!");
                }
                    
            }    
        }

        private void PackIcon_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Dialog a= new Dialog() { Message="Bạn thực sự muốn thoát chương trình ?"};
            a.Owner = Window.GetWindow(this);
            a.ShowDialog();
            if (a.DialogResult == true)
                Application.Current.Shutdown();
            
        }
    }
}
