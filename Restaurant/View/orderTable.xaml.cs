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
        //taoj 2 list để chứa orderdetail của 2 bàn cần gộp
        ObservableCollection<OrderDetails> od1;
        ObservableCollection<OrderDetails> od2;


        //tạo 1 biến để kiểm tra có đang nhấn nút cài đặt hay không
        bool setting = false;
        //tạo 1 biến lưu tên của khu vực và 1 biến lưu id của khu vực khi nhấn vào tab khu vực
        String nameArea;
        int idArea;
        //tạo 1 biến lưu id bàn khi nhấn
        int idTable;
        //tạo biến cho biết đang vào chế độ đặt bàn
        bool boolReserve = false;
        //tao bien de biet dang vao che do chuyen ban
        bool boolChangeSeat = false;
        //tạo biến để biết đang trong chế độ gộp bàn
        bool boolMergeSeat = false;
        //tao biem chua id cua ban muon chuyen di
        int idSeatChange=-1;
        //tạo biến để biết idDisk đã tồn tại hay chưa trong chức năng gộp bàn
        bool trung = false;
        //
        tableController dbSeats = new tableController();
        //
        billController dbBills = new billController();
        //
        areaController dbArea = new areaController();
        //
        orderdetailController dbOD = new orderdetailController();
        //
        orderController dbOrder = new orderController();
        public orderTable()
        {
            InitializeComponent();

            //ẩn grib chỉnh sửa
            gridSetting.Visibility = Visibility.Hidden;
            //chỉnh select của cbx chọn bàn về 0
            cbxState.SelectedIndex = 0;
            idArea = int.Parse(dbArea.GetFirstIDArea());
            nameArea = dbArea.GetFirstNameArea();
            Thread thread = new Thread(delegate ()
            {
                
                //Seats
                Tables = new ObservableCollection<Seats>(dbSeats.loadSeat(idArea,0));
                //Bill
                Bills = new ObservableCollection<Bills>(dbBills.loadBill());
                //Areas
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
        public ObservableCollection<OrderDetails> Od1 { get => od1; set => od1 = value; }
        public ObservableCollection<OrderDetails> Od2 { get => od2; set => od2 = value; }

        private void tagarea_Loaded(object sender, RoutedEventArgs e)
        {

        }
       private void listviewShowArea_SelectionChanged(object sender, SelectionChangedEventArgs e)
       {
            Area temp = listviewShowArea.SelectedItem as Area;
            if (temp != null)
            {
                idArea = temp.IdArea;
                nameArea = temp.NameArea;
                Tables = new ObservableCollection<Seats>(dbSeats.loadSeat(temp.IdArea,0));
                listviewShowTable.ItemsSource = Tables;
                //chỉnh lại select của combobox chọn bàn
                cbxState.SelectedIndex = 0;
            }
       }

        private void listviewShowTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Seats temp = listviewShowTable.SelectedItem as Seats;
            if (temp != null)
            {
                if (boolReserve)//đặt bàn
                {
                    if (temp.State == stateSeat.emty && dbSeats.ChangeStateSeat(temp.Id, 3) == true)
                    {
                        Tables = new ObservableCollection<Seats>(dbSeats.loadSeat(idArea, 0));
                        listviewShowTable.ItemsSource = Tables;
                        MessageBox.Show("Đã đặt bàn "+temp.Id.ToString());
                        boolReserve = false;
                        btnDatTruoc.Content = "Đặt trước";
                        //cho nhấn nút setting
                        btnSetting.IsEnabled = true;
                    }
                    // hiện thông báo nếu bàn này đã có khách
                    else if (temp.State == stateSeat.use)
                    {
                        MessageBox.Show("Bàn này đang được sử dụng, hãy chọn bàn khác!");
                    }
                    // hiện thông báo nếu bàn này đã đặt rồi
                    else
                    {
                        DialogResult dialogResult= (DialogResult)MessageBox.Show("Bàn này đã được đặt trước, bạn muốn hủy đặt bàn?", "", MessageBoxButton.YesNo);
                        if (dialogResult==DialogResult.Yes)
                        {
                            dbSeats.ChangeStateSeat(temp.Id, 1);
                            Tables = new ObservableCollection<Seats>(dbSeats.loadSeat(idArea, 0));
                            listviewShowTable.ItemsSource = Tables;
                            boolReserve = false;
                            btnDatTruoc.Content = "Đặt trước";
                            //cho nhấn nút setting
                            btnSetting.IsEnabled = true;
                        } 
                    }
                }
                else if(boolChangeSeat)//chuyển bàn
                {
                    if(idSeatChange==-1)
                    {
                        if (temp.State == stateSeat.emty || temp.State == stateSeat.book)
                        {
                            MessageBox.Show("Bàn này hiện đang trống!!!");
                        }
                        else
                            idSeatChange = temp.Id;
                    }
                    else
                    {
                        if (temp.State == stateSeat.book)
                        {
                            MessageBox.Show("Bàn này đang được đặt, vui lòng chọn bàn khác !!!");
                        }
                        else if (temp.State == stateSeat.use)
                        {
                            MessageBox.Show("Bàn này đang có khách, vui lòng chọn bàn khác !!!");
                        }
                        else
                        {
                            DialogResult dialogResult = (DialogResult)MessageBox.Show("Chuyển bàn "+idSeatChange.ToString()+" sang bàn "+temp.Id.ToString()+"?", "Xác nhận chuyển bàn", MessageBoxButton.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                dbSeats.ChangeSeat(idSeatChange, temp.Id);
                                Tables = new ObservableCollection<Seats>(dbSeats.loadSeat(idArea, 0));
                                listviewShowTable.ItemsSource = Tables;
                                boolChangeSeat = false;
                                btnChuyenBan.Content = "Chuyển bàn";
                                idSeatChange = -1;
                                //cho nhấn lại nut setting
                                btnSetting.IsEnabled = true;
                            }
                        }

                    }    

                }
                else if(boolMergeSeat)//gộp bàn
                {
                    if (idSeatChange == -1)
                    {
                        if (temp.State == stateSeat.emty || temp.State == stateSeat.book)
                        {
                            MessageBox.Show("Bàn này hiện đang trống!!!");
                        }
                        else
                            idSeatChange = temp.Id;
                    }
                    else
                    {
                        if (temp.State == stateSeat.book)
                        {
                            MessageBox.Show("Bàn này đang được đặt, vui lòng chọn bàn khác !!!");
                        }
                        else if (temp.State == stateSeat.emty)
                        {
                            MessageBox.Show("Bàn này đang trống, vui lòng chọn bàn khác !!!");
                        }
                        ////////////////////////////////////////////////////////////////////////////////////////////
                        else
                        {
                            DialogResult dialogResult = (DialogResult)MessageBox.Show("Gộp bàn " + idSeatChange.ToString() + " và bàn " + temp.Id.ToString() + "?", "Xác nhận chuyển bàn", MessageBoxButton.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                //lấy order detail của 2 bàn để so sánh
                                Od1=new ObservableCollection<OrderDetails>(dbOD.getOrderDetailBySeatId(idSeatChange));
                                Od2=new ObservableCollection<OrderDetails>(dbOD.getOrderDetailBySeatId(temp.Id));
                                //lấy idOrder cuae bàn q
                                int idOrder1 = Od1[0].IdOrder;
                                //lấy idOrder của bàn 2
                                int idOrder2 = Od2[0].IdOrder;
                                //lặp từng phần tử 1 của Od1 với Od2 để tìm cái nào trùng cái nào ko
                                for(int i=0;i<Od1.Count;i++)
                                {
                                    for(int j=0;j<Od2.Count;j++)
                                    {
                                        if(Od1[i].IdDish==Od2[j].IdDish)
                                        {
                                            trung = true;
                                            //gọi hàm cộng thêm vào
                                            dbOD.updateOrderDetail(Od1[i].IdDish, Od1[i].Quantity, idOrder2);
                                        }    
                                    }   
                                    if(trung==false)
                                    {
                                        //gọi đến hàm tạo mới
                                        dbOD.addItemOrderDetail(Od1[i].IdDish, Od1[i].Quantity, idOrder2);
                                    }
                                    //đặt lại biến trùng
                                    trung = false;
                                }
                                //xóa orderdetail của bàn đầu sau khi đã gộp bàn
                                dbOD.deleteOrderDetail(idOrder1);
                                dbSeats.ChangeStateSeat(idSeatChange, 1);
                                ///////////////////
                                Tables = new ObservableCollection<Seats>(dbSeats.loadSeat(idArea, 0));
                                listviewShowTable.ItemsSource = Tables;
                                boolMergeSeat = false;
                                btnGopban.Content = "Gộp bàn";
                                MessageBox.Show(idSeatChange.ToString());
                                //cho nhấn nút setting
                                btnSetting.IsEnabled = true;
                            }
                        }

                    }

                }
                else if (setting == false)//vao ban
                {
                    //kiểm tra orderdetail của bàn phía trên
                    dbOrder.check_Orderdetail();

                    if(temp.State==stateSeat.emty||temp.State==stateSeat.book)
                    {
                        //tạo 1 order mới
                        if (!dbOrder.addOrder(temp.Id, 2)) return;
                        
                        this.NavigationService.Navigate(new Order_menu(dbOrder.getLastOrder(),idArea.ToString()));
                    }
                    else if(temp.State==stateSeat.use)
                    {
                        this.NavigationService.Navigate(new Order_menu(dbOrder.GetOrders(temp.Id), idArea.ToString()));
                    }    
                }
                else if (setting)
                {
                    //disable 2 nut bật và hiển thị lại bàn
                    btnDeleteSeat.IsEnabled = false;
                    btnEnableSeat.IsEnabled = false;
                    idTable = temp.Id;
                    if (temp.State == stateSeat.emty)
                    {
                        btnDeleteSeat.IsEnabled = true;
                    }
                    else if (temp.State == stateSeat.disable)
                    {
                        btnEnableSeat.IsEnabled = true;
                    }

                }
            }
        }

        private void btnSetting_Click(object sender, RoutedEventArgs e)
        {
            if(setting==false)
            {
                setting = true;
                btnSetting.Content = "Xong";
                gridSetting.Visibility = Visibility.Visible;
                //chỉnh lại độ dài của vùng chọn bàn
                borderlistviewShowTable.Margin = new Thickness(10, 79, 341, 193);
                //đặt text trong txtNameArea bằng tên của area đang chỉnh sửa
                txtNameArea.Text = nameArea;
                //không cho thay đổi tag khác
                listviewShowArea.IsEnabled = false;
                //cho load tất cả các bàn
                Tables = new ObservableCollection<Seats>(dbSeats.loadSeat(idArea, 4));
                listviewShowTable.ItemsSource = Tables;
                //disable 2 nut bật và hiển thị lại bàn và combobox chọn bàn
                btnDeleteSeat.IsEnabled = false;
                btnEnableSeat.IsEnabled = false;
                cbxState.IsEnabled = false;
            }   
            else
            {
                setting = false;
                btnSetting.Content = "Cài đặt";
                gridSetting.Visibility = Visibility.Hidden;
                //kiểm tra có thay đổi tên khu vực không
                if(txtNameArea.Text!=nameArea)
                {
                    dbArea.editAreaName(idArea, txtNameArea.Text);
                    nameArea = txtNameArea.Text;

                    //cho load lại thanh area
                    Areas = new ObservableCollection<Area>(dbArea.loadArea());
                    listviewShowArea.ItemsSource = Areas;
                    Area temp = dbArea.getAreaByID(idArea);
                    //chỉnh lại selectedindex về area trước khi sửa
                    listviewShowArea.SelectedIndex = temp.IdArea - 1;
                }
                //chỉnh lại độ dài của vùng chọn bàn
                borderlistviewShowTable.Margin = new Thickness(10, 79, 341, 100);
                listviewShowArea.IsEnabled = true;
                //enable lại combobox chọn bàn
                cbxState.IsEnabled = true;
                //load lại thông tin bàn
                Tables = new ObservableCollection<Seats>(dbSeats.loadSeat(idArea, cbxState.SelectedIndex));
                listviewShowTable.ItemsSource = Tables;
            }
        }

        private void btnXoaBan_Click(object sender, RoutedEventArgs e)
        {
            dbSeats.DisableSeat(idTable);
            //load lại thông tin bàn
            Tables = new ObservableCollection<Seats>(dbSeats.loadSeat(idArea,4));
            listviewShowTable.ItemsSource = Tables;
        }

        private void btnEnableSeat_Click(object sender, RoutedEventArgs e)
        {
            dbSeats.EnableSeat(idTable);
            //load lại thông tin bàn
            Tables = new ObservableCollection<Seats>(dbSeats.loadSeat(idArea,4));
            listviewShowTable.ItemsSource = Tables;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //hien thi tat ca cac ban tru ban bi disable
            if(cbxState.SelectedIndex ==0)
            {
                Tables = new ObservableCollection<Seats>(dbSeats.loadSeat(idArea, 0));
                listviewShowTable.ItemsSource = Tables;
            }
            //load cac ban dang trong
            else if(cbxState.SelectedIndex==1)
            {
                Tables = new ObservableCollection<Seats>(dbSeats.loadSeat(idArea, 1));
                listviewShowTable.ItemsSource = Tables;
            }  
            //load cac ban dang co khach
            else if(cbxState.SelectedIndex==2)
            {
                Tables = new ObservableCollection<Seats>(dbSeats.loadSeat(idArea, 2));
                listviewShowTable.ItemsSource = Tables;
            }
            //load cac ban dat truoc
            else if(cbxState.SelectedIndex==3)
            {
                Tables = new ObservableCollection<Seats>(dbSeats.loadSeat(idArea, 3));
                listviewShowTable.ItemsSource = Tables;
            }
        }
        //sự kiện khi nhấn vào nút đặt trước
        private void btnDatTruoc_Click(object sender, RoutedEventArgs e)
        {
            if (boolReserve == false)
            {
                boolReserve = true;
                btnDatTruoc.Content = "Hủy đặt";
                btnSetting.IsEnabled = false;
            }
            else if (boolReserve)
            {
                boolReserve = false;
                btnDatTruoc.Content = "Đặt trước";
                btnSetting.IsEnabled = true;
            }
        }
        //sự kiện khi nhấn vào nút gộp bàn
        private void btnGopban_Click(object sender, RoutedEventArgs e)
        {
            boolReserve = false;
            if (boolMergeSeat == false)
            {
                boolMergeSeat = true;
                btnGopban.Content = "Hủy gộp bàn";
                btnSetting.IsEnabled = false;
            }
            else if (boolMergeSeat)
            {
                boolMergeSeat = false;
                btnGopban.Content = "Gộp bàn";
                idSeatChange = -1;
                btnSetting.IsEnabled = true;
            }
        }
        //sự kiện khi nhấn vào nút chuyển bàn
        private void btnChuyenBan_Click(object sender, RoutedEventArgs e)
        {
            boolReserve = false;
            if (boolChangeSeat==false)
            {
                boolChangeSeat = true;
                btnChuyenBan.Content = "Hủy chuyển bàn";
                btnSetting.IsEnabled = false;
            }
            else if(boolChangeSeat)
            {
                boolChangeSeat = false;
                btnChuyenBan.Content = "Chuyển bàn";
                idSeatChange = -1;
                btnSetting.IsEnabled = true;
            }    
            
        }

        private void btnAddSeat_Click(object sender, RoutedEventArgs e)
        {
            dbSeats.addNewSeat(idArea);
            //load lại thông tin bàn
            Tables = new ObservableCollection<Seats>(dbSeats.loadSeat(idArea, 4));
            listviewShowTable.ItemsSource = Tables;
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
