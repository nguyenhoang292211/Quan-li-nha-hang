using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Collections.ObjectModel;
using Restaurant.Model;
using Restaurant.Controller;
using System.Threading;
using System.Drawing;

namespace Restaurant.View
{
    /// <summary>
    /// Interaction logic for Nhanvien_page.xaml
    /// </summary>
    public partial class Nhanvien_page : Page
    {

        employeeController empCon = new employeeController();
        ObservableCollection<Employees> employees = new ObservableCollection<Employees>();
<<<<<<< HEAD
        List<string> listManager = new List<string>();
        List<Level> listPosition = new List<Level>();
        List<string> listFilter = new List<string>() { "Tất cả", "Nam", "Nữ", "Địa chỉ", "Nhân viên", "Quản lí" };
=======
        List<string> listManager=new List<string>();
        List<Level> listPosition = new List<Level>();
        List<string> listFilter = new List<string>() {"Tất cả","Nam","Nữ","Địa chỉ","Nhân viên","Quản lí"};
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
        public Nhanvien_page()
        {
            InitializeComponent();
            editNv_form.Visibility = Visibility.Hidden;

<<<<<<< HEAD
            Thread thread = new Thread(delegate ()
=======
            Thread thread = new Thread(delegate()
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
            {
                Dispatcher.Invoke(() =>
                {
                    //load source combobox chức vụ
                    listPosition = Enum.GetValues(typeof(Level)).Cast<Level>().ToList();
                    cmbposition.ItemsSource = listPosition;

                    //load source combobox filter
                    cmbfilter.ItemsSource = listFilter;
                    cmbfilter.SelectedIndex = 0;
                    //load source combobox người quản lí
                    listManager = empCon.getListNameManager();
                    cmbmanager.ItemsSource = listManager;

                    //load danh sách NV
                    employees = empCon.loadallEmployees();
                    listStaff.ItemsSource = employees;
                    txbamountstaff.Text = employees.Count.ToString();
<<<<<<< HEAD
                    txbamountstaff.IsReadOnly = true;
=======
                    txbamountstaff.IsReadOnly = true;   
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151

                    //Ẩn thanh load
                    Progressbar.IsEnabled = false;
                    Progressbar.Visibility = Visibility.Hidden;
<<<<<<< HEAD

                });
            });
            thread.Start();
=======
                    
                });
            });
            thread.Start();          
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
        }

        /// <summary>
        /// Chọn vào listview nhân viên sẽ hiện ra chi tiết nhân viên
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListStaff_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnSave.IsEnabled = false;
            btnSave.Content = "Save";
            if (listStaff.SelectedItem == null) return;
            Employees emp = listStaff.SelectedItem as Employees;

            for (int i = 0; i < cmbposition.Items.Count; i++)
                if (emp.Level.ToString().Trim() == cmbposition.Items[i].ToString().Trim())
                {
<<<<<<< HEAD
                    cmbposition.SelectedIndex = i;
=======
                    cmbposition.SelectedIndex = i;                   
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
                }

            for (int i = 0; i < cmbmanager.Items.Count; i++)
                if (empCon.getNameManagerbyid(emp.IdMan) == cmbmanager.Items[i].ToString())
                {
                    cmbmanager.SelectedIndex = i;
                }
            if (emp.State == "Doing") cmbstate.SelectedIndex = 0;
            if (emp.State == "Undoing") cmbstate.SelectedIndex = 1;


            txbId.Text = emp.Id.ToString();
            txbname.Text = emp.Name;
            txbaddress.Text = emp.Address;
            txbphone.Text = emp.Phone;
            txbusername.Text = emp.UserName;
            txbsalary.Text = emp.Salary.ToString();
            txbpass.Text = emp.PassWord;
<<<<<<< HEAD
            if (emp.Sex == 'F') chbgender.IsChecked = false;
=======
            if (emp.Sex == 'F') chbgender.IsChecked =false;
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
            else chbgender.IsChecked = true;
            editNv_form.Visibility = Visibility.Visible;
            IsREADonly(true);
            btnadd.IsEnabled = false;
        }

        /// <summary>
        /// Xét các textbox chỉ được đọc khi nhấn vào item trong danh sách nhân viên
        /// </summary>
        /// <param name="t"></param>
        void IsREADonly(bool t)
        {
<<<<<<< HEAD
            txbId.IsReadOnly = txbname.IsReadOnly = txbaddress.IsReadOnly =
            txbphone.IsReadOnly = txbusername.IsReadOnly = txbpass.IsReadOnly = t;
            chbgender.IsEnabled = !t;
=======
            txbId.IsReadOnly = txbname.IsReadOnly = txbaddress.IsReadOnly = 
            txbphone.IsReadOnly = txbusername.IsReadOnly = txbpass.IsReadOnly = t;
            chbgender.IsEnabled =!t;
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151

        }

        /// <summary>
        /// Xóa các textbox trong form edit
        /// </summary>

<<<<<<< HEAD
        void ClearEditForm()
=======
        void ClearEditForm ()
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
        {
            txbaddress.Clear();
            txbId.Clear();
            txbname.Clear();
            txbpass.Clear();
            txbphone.Clear();
            txbusername.Clear();
            txbsalary.Clear();
<<<<<<< HEAD
            chbgender.IsChecked = false;
=======
            chbgender.IsChecked = false ;
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151

            btnSave.Content = "Lưu";

        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            ClearEditForm();
            cmbstate.IsEnabled = false;
            editNv_form.Visibility = Visibility.Hidden;
            btnadd.IsEnabled = true;

        }

        private void PackIcon_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
<<<<<<< HEAD
            if (editNv_form.Visibility == Visibility.Visible)
=======
            if(editNv_form.Visibility==Visibility.Visible)
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
            {
                if (MessageBox.Show("Bạn muốn xóa nhân viên này", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (empCon.deleteEmployees(int.Parse(txbId.Text)))
                    {
                        MessageBox.Show("Đã xóa nhân viên này!");
                        editNv_form.Visibility = Visibility.Hidden;
                        listStaff.ItemsSource = empCon.loadallEmployees();
                    }
                    else
                        MessageBox.Show("Bị lỗi");
                }
<<<<<<< HEAD

=======
               
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
            }
        }
        /// <summary>
        /// Thêm nhân viên vào danh sách
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btnadd_Click(object sender, RoutedEventArgs e)
        {
            IsREADonly(false);
            btnSave.IsEnabled = true;

<<<<<<< HEAD
            editNv_form.Visibility = Visibility.Visible;
=======
            editNv_form.Visibility = Visibility.Visible;         
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
            btnadd.IsEnabled = false;
            btnSave.Content = "Thêm";
        }

        /// <summary>
        /// Kiểm tra các textbox khi thêm hoặc sửa thông tin nhân viên
        /// </summary>
        /// <returns></returns>
        bool checkInput()
        {
            if (txbId.Text == "")
            {
                txbId.Foreground = System.Windows.Media.Brushes.Red;
                txbId.Text = "You have to fill this field!";
<<<<<<< HEAD
                return false;
=======
                    return false; 
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
            }
            if (txbname.Text == "")
            {
                txbname.Foreground = System.Windows.Media.Brushes.Red;
                txbname.Text = "You have to fill this field!";
<<<<<<< HEAD
                return false;
            }
            if (txbaddress.Text == "")
            {
                txbaddress.Foreground = System.Windows.Media.Brushes.Red;
                txbaddress.Text = "You have to fill this field!";
                return false;
=======
                    return false;
            }
            if (txbaddress.Text == "")
            {
               txbaddress.Foreground = System.Windows.Media.Brushes.Red;
                txbaddress.Text = "You have to fill this field!";
                    return false;
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
            }

            if (txbpass.Text == "")
            {
                txbpass.Foreground = System.Windows.Media.Brushes.Red;
                txbpass.Text = "You have to fill this field!";
<<<<<<< HEAD
                return false;
=======
                    return false;
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
            }

            if (txbphone.Text == "")
            {
                txbphone.Foreground = System.Windows.Media.Brushes.Red;
                txbphone.Text = "You have to fill this field!";
<<<<<<< HEAD
                return false;
=======
                    return false;
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
            }
            if (txbusername.Text == "")
            {
                txbusername.Foreground = System.Windows.Media.Brushes.Red;
                txbusername.Text = "You have to fill this field!";
<<<<<<< HEAD
                return false;
=======
                    return false;
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
            }

            if (txbsalary.Text == "")
            {
                txbsalary.Foreground = System.Windows.Media.Brushes.Red;
                txbsalary.Text = "You have to fill this field!";
                return false;
            }

            return true;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {

            //thêm nhân viên mới

            if (!checkInput())
                return;

<<<<<<< HEAD
            if (btnSave.Content.ToString() == "Thêm")
=======
            if(btnSave.Content.ToString()== "Thêm")
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
            {
                char sex = new char();
                int idman = empCon.getIdManagebyName(cmbmanager.SelectedItem.ToString());
                if (chbgender.IsChecked == true) sex = 'M';
                else sex = 'F';
<<<<<<< HEAD
                Level level = (Level)cmbposition.SelectedItem;
=======
                Level level =(Level) cmbposition.SelectedItem;
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151

                if (empCon.addEmployees(int.Parse(txbId.Text.Trim()), idman, txbusername.Text, txbpass.Text, txbname.Text,
                     sex, txbphone.Text, txbaddress.Text, Double.Parse(txbsalary.Text.Trim()), level, "Doing"))

                {
                    MessageBox.Show("Đã thêm thành công");
                    listStaff.ItemsSource = empCon.loadallEmployees();
                    editNv_form.Visibility = Visibility.Hidden;
                    txbamountstaff.Text = listStaff.Items.Count.ToString();
                    ClearEditForm();
                    btnadd.IsEnabled = true;
                }

                else
                    MessageBox.Show("Lỗi");

            }


            //Thay đổi thông tin nhân viên

<<<<<<< HEAD
            if (btnSave.Content.ToString() == "Lưu")
=======
            if(btnSave.Content.ToString()=="Lưu")
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
            {
                char sex = new char();
                int idman = empCon.getIdManagebyName(cmbmanager.SelectedItem.ToString());
                if (chbgender.IsChecked == true) sex = 'M';
                else sex = 'F';
                Level level = (Level)cmbposition.SelectedItem;

                if (empCon.editEmployees(int.Parse(txbId.Text.Trim()), idman, txbusername.Text, txbpass.Text, txbname.Text,
                     sex, txbphone.Text, txbaddress.Text, Double.Parse(txbsalary.Text.Trim()), level, cmbstate.Text))

                {
                    MessageBox.Show("Đã sửa thông tin thành công");
                    listStaff.ItemsSource = empCon.loadallEmployees();
                    editNv_form.Visibility = Visibility.Hidden;
                    txbamountstaff.Text = listStaff.Items.Count.ToString();
                    ClearEditForm();
                    btnadd.IsEnabled = true;
                }
                else
                    MessageBox.Show("Không edit được");
            }
        }

        private void PackIcon_MouseDown_1(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            btnSave.IsEnabled = true;
            btnSave.Content = "Lưu";
            IsREADonly(false);
            cmbstate.IsEnabled = true;
<<<<<<< HEAD


=======
            txbId.IsEnabled = false ;

            
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
        }

        private void CmbFilter_amountstaff_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
<<<<<<< HEAD


=======
           
            
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
        }

        private void Txbfindstaff_TextChanged(object sender, TextChangedEventArgs e)
        {
<<<<<<< HEAD
            if (cmbfilter.Text == "Tất cả")
                listStaff.ItemsSource = empCon.SearchEmployees(txbfindstaff.Text);
=======
            if(cmbfilter.Text=="Tất cả")
            listStaff.ItemsSource = empCon.SearchEmployees(txbfindstaff.Text);
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
            else
            {
                listStaff.ItemsSource = empCon.SearchEmployees(txbfindstaff.Text, cmbfilter.Text);
            }
        }

        private void Cmbfilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
<<<<<<< HEAD
        {
            if (txbfindstaff.Text == null)
                txbfindstaff.Text = "";
            listStaff.ItemsSource = empCon.SearchEmployees(txbfindstaff.Text, cmbfilter.Text);
        }
    }


=======
        {  if (txbfindstaff.Text == null)
                txbfindstaff.Text = "";
            listStaff.ItemsSource = empCon.SearchEmployees(txbfindstaff.Text, cmbfilter.Text);                
        }
    }

   
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
}
