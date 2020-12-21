
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using Restaurant.Model;
using Restaurant.Controller;
using System.Collections.ObjectModel;
using System.Collections;

namespace Restaurant.View
{
    /// <summary>
    /// Interaction logic for Order_menu.xaml
    /// </summary>
    public partial class Order_menu : Page
    {
        //Bình thêm
        tableController dbTable = new tableController();
        //tạo 1 biến để lưu id bàn truyền vào
        int idSeat;
        orderController dbod = new orderController();
        //
        private ObservableCollection<OrderDetails> sourceOrder;
        public ObservableCollection<OrderDetails> SourceOrder
        {
            get
            {
                return sourceOrder;
            }
            set
            {
               sourceOrder = value;
                listviewBill.ItemsSource = sourceOrder;
                ObservableCollection<OrderDetails> orders = ConvertoList();
                if (orders != null)
                {
                    double totalcosst = 0;
                    foreach (OrderDetails a in orders)
                    {
                        totalcosst += a.Price * a.Quantity;
                    }

                    txbtotalcost.Text = totalcosst.ToString();
                    Events events = cmbdiscount.SelectedItem as Events;
                    txblastcost.Text = (totalcosst * (100-ordercn.getPercentDiscount(events.Id))/100).ToString();
                }


            }
        }

        dishesController discn = new dishesController();
        orderdetailController ordercn = new orderdetailController();
        employeeController empcn = new employeeController();
        ObservableCollection<OrderDetails> ordereds = new ObservableCollection<OrderDetails>();
        Orders GetOrders;

        public Order_menu(Orders order,string idArea)
        {

            InitializeComponent();
           
            lb_table.Content = order.IdSeat.ToString();
            lb_area.Content = idArea;
            idSeat=int.Parse(order.IdSeat.ToString());
            this.GetOrders = order;
            btn_pay.IsEnabled = false;

            Thread thread = new Thread(delegate ()
            {
                Dispatcher.Invoke(() =>
                {
                    Customers a = new Customers();
                    cmbcustomer.ItemsSource = a.loadAllCustomer();

                    grid_addcustomer.Visibility = Visibility.Hidden;

                    pl_pay_bill.Visibility = Visibility.Hidden;
                    listviewtypes.ItemsSource = discn.loadallTypeDishes();
                    listviewtypes.SelectedIndex = 0;
                    //listviewShowFood.ItemsSource = discn.loadallDishes();
                    Progressbar.Visibility = Visibility.Hidden;
                    Progressbar.IsEnabled = false;
                });

            });
            thread.Start();

            Thread thread1 = new Thread(delegate ()
            {
                Dispatcher.Invoke(() =>
                {
                    Customers a = new Customers();
                    cmbcustomer.ItemsSource = a.loadAllCustomer();

                    grid_addcustomer.Visibility = Visibility.Hidden;
                    pl_pay_bill.Visibility = Visibility.Hidden;
                  
                    cmbdiscount.ItemsSource = discn.loadlistEvents();
                    cmbdiscount.SelectedIndex = 0;
                    //kiểm tra bàn này có đang order hay ko>
                    if (ordercn.loadlistOrderDetail(GetOrders.Id) != null)
                    {
                        btn_pay.IsEnabled = true;
                        //Danh sách các món đã vào bếp
                        ordereds = ordercn.loadlistOrderDetail(GetOrders.Id);
                        //combacklist = ordereds;
                        SourceOrder = ordereds;

                    }

                    if (GetOrders.IdCus != 0)
                    {
                        Customers c = new Customers();
                        txbDiscount_point.Text = c.getPoint(GetOrders.IdCus).ToString();
                        Customers customer = ordercn.findCusByid(GetOrders.IdCus);
                        if (customer != null)
                        {
                            ObservableCollection<Customers> cus = customer.loadAllCustomer();
                            for (int i = 0; i < cus.Count; i++)
                            {
                                if (cus[i].Phone == customer.Phone)
                                {
                                    cmbcustomer.SelectedIndex = i;
                                    break;
                                }
                            }
                        }
                    }
                    else txbDiscount_point.Text = "0";
                    //lấy thông tin nhân viên
                    if (GetOrders.IdEmp != 0)
                    {
                        if (empcn.getEmpByID(GetOrders.IdEmp) != null)
                            txbthungan.Text = empcn.getEmpByID(GetOrders.IdEmp).Name;
                    }
                });
            });
            thread1.Start();
                    
        }

        private void Cmbdiscount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Events a = cmbdiscount.SelectedItem as Events;
            lb_percent_discount.Content = (a.Discount).ToString()+"%";
            if(txbtotalcost.Text!="") 
            txblastcost.Text = (double.Parse(txbtotalcost.Text.ToString()) * (100-a.Discount) / 100).ToString();
        }

        private void Btnaddcus_Click(object sender, RoutedEventArgs e)
        {
            grid_addcustomer.Visibility = Visibility;
            btnSave.IsEnabled = true;
            Customers cus = new Customers();
            txbname.Clear();
            txbId.Text = cus.getLastedID().ToString();
            txbId.IsReadOnly = true;
            txbphone.Clear();
            txbDiscount_point.Clear();
            rightgrid.IsEnabled = false;
        }

        private void Btnfindcus_Click(object sender, RoutedEventArgs e)
        {

            if(btnfindcus.Content.ToString()=="Tìm kiếm")
            cmbcustomer.Visibility = Visibility;
            if(btnfindcus.Content.ToString()=="Chi tiết")
            {
                txbId.IsReadOnly = true;
                grid_addcustomer.Visibility = Visibility.Visible;
                rightgrid.IsEnabled = false;
                Customers customers = new Customers();
                customers = cmbcustomer.SelectedItem as Customers;
                txbname.Text = customers.Name;
                txbphone.Text = customers.Phone;
                txbId.Text = customers.Id.ToString();
                txbpoint.Text = customers.Point.ToString();
                btnSave.IsEnabled = false;
            }


        }

        private void ListviewBill_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        //-----------------------MỚI THÊM NHA -----------------------------------------------

        private void Btn_pay_Click(object sender, RoutedEventArgs e)
        {
            Double total = 0;
            //ẩn các button
            ordereds = ordercn.loadlistOrderDetail(GetOrders.Id);
            if(ordereds==null || ordereds.Count<=0)
            {
                MessageBox.Show("Chưa có món nào vào bếp !");
                return;
            }
            btn_thanhtoan.Visibility = Visibility.Visible;
            Button_pan.Visibility = Visibility.Hidden;
            ordereds = ordercn.loadlistOrderDetail(GetOrders.Id);
            for(int i=0;i<ordereds.Count;i++)
            {
                ordereds[i].Stt = i + 1;
                total += ordereds[i].Totalcost;
                
            }

            listviewpayBill.ItemsSource = ordereds;
            listviewShowFood.IsEnabled = false;

            //Hiển thị thông tin khách hàng
            lb_origin_price.Content = txbtotalcost.Text;
            lbtablenumber.Content = lb_table.Content;
            lb_area_.Content = lb_area.Content;
            lb_cus.Content = txbtkhachang.Text;
            lb_pay_price.Content = txblastcost.Text;
            lbdiscount.Content= lb_percent_discount.Content;
            lbpointused.Content = txbDiscount_point.Text;
            pl_pay_bill.Visibility = Visibility.Visible;

        }
        //Lưu thông tin món ăn vào bảng OrderDetail
        private void Btnenter_Click(object sender, RoutedEventArgs e)
        {
            if (btnenter.Content.ToString() == "Vào bếp")
            {
                //nếu như chưa có món nào khách đã đặt trước đó
                if (ordereds.Count == 0)
                {
                    if (listviewBill.Items.Count == 0)
                    {
                        MessageBox.Show("Danh sách món ăn Order trống, không thể chuyển vào bếp!!!");
                        return;
                    }
                    //đã đặt trước đó
                    else
                    {
                        for (int i = 0; i < listviewBill.Items.Count; i++)
                        {
                            OrderDetails a = listviewBill.Items[i] as OrderDetails;
                            if (!ordercn.addOrderDetail(a.IdDish, a.IdOrder, a.Price, a.Quantity))
                            {
                                MessageBox.Show("Lỗi vào bếp chưa được " + a.NameDish);
                                return;
                            }

                        }
                        //đổi trạng thái của bàn sang có khách
                        dbTable.ChangeStateSeat(idSeat, 2);
                        //lấy cái id của khách hàng 
                        //cập nhập lại id khách hàng
                        btn_pay.IsEnabled = true;
                        if (cmbcustomer.SelectedIndex == -1)
                        {
                            dbod.updateCustomerOrder("null");
                        }
                        else
                        {
                            dbod.updateCustomerOrder(cmbcustomer.Text.ToString());
                        }

                        ordereds = SourceOrder;
                    }
                 
                }
                //nếu đã đặt r và muốn đặt tiếp
                else
                {   //thêm món mới

                    //Sửa lại : xử lí ở tâng database
                    ordereds = ordercn.loadlistOrderDetail(GetOrders.Id);
                    if (listviewBill.Items.Count > ordereds.Count)
                    {
                        for (int i = ordereds.Count; i < listviewBill.Items.Count; i++)
                        {
                            OrderDetails a = listviewBill.Items[i] as OrderDetails;
                            if (!ordercn.addOrderDetail(a.IdDish, a.IdOrder, a.Price, a.Quantity))
                            {
                                MessageBox.Show("Lỗi vào bếp chưa được " + a.NameDish);
                                return;
                            }
                        }
                    }
                    //cập nhật những món chỉ tăng số lượng
                    for (int i = 0; i < ordereds.Count; i++)
                    {
                        OrderDetails orderDetails = listviewBill.Items[i] as OrderDetails;

                        if (orderDetails.IdDish == ordereds[i].IdDish && ordereds[i].Quantity < orderDetails.Quantity)
                        {

                            if (!ordercn.updateOrderdetail(orderDetails.Id, orderDetails.Quantity))
                            {
                                MessageBox.Show("Cập nhật vào đơn bị lỗi !");
                                return;

                            }
                        }
                    }

                    MessageBox.Show("Đã cập nhật thành công");
                    ordereds = ordercn.loadlistOrderDetail(GetOrders.Id);
                }
                plsuccessenter.Visibility = Visibility.Visible;
                btnenter.IsEnabled = false;
            }
            else
            if (btnenter.Content.ToString() == "Order thêm")
            {
                listviewBill.IsEnabled = true;
                btnenter.Content = "Vào bếp";
            }

        }

        private void Listviewtypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TypeFoods type = listviewtypes.SelectedItem as TypeFoods;
            listview_bestuse.ItemsSource = discn.getBestSeller(type.Id);
            if (txbfind.Text=="")
            {

                listviewShowFood.ItemsSource = discn.loadDishesWithType(type.Id);
            }
            else
                listviewShowFood.ItemsSource = discn.SearchDish(txbfind.Text, type.Id);


        }
        ObservableCollection<Orders> listbill = new ObservableCollection<Orders>();


        //Hàm tìm kiếm món ăn theo tên
        private void Txbfind_TextChanged(object sender, TextChangedEventArgs e)
        {
            TypeFoods type = listviewtypes.SelectedItem as TypeFoods;
            listviewShowFood.ItemsSource = discn.SearchDish(txbfind.Text, type.Id);
        }       

        private void Btn_Delete_Item_In_Cart_Click(object sender, RoutedEventArgs e)
        {
          
        }

        private void ListviewShowFood_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

            if (btnenter.Content.ToString()=="Vào bếp" && btnenter.IsEnabled== true)
            {
                bool availabledish = false;
                Dishes a = listviewShowFood.SelectedItem as Dishes;
                //danh sách món khách đã chọn
                ObservableCollection<OrderDetails> listorder = new ObservableCollection<OrderDetails>();
                //Lấy danh sách món đã chọn
                if (listviewBill.Items.Count > 0)
                {
                    for (int i = 0; i < listviewBill.Items.Count; i++)
                    {
                        OrderDetails temp = listviewBill.Items[i] as OrderDetails;
                        if (a.Id == temp.IdDish)
                        {
                            temp.Quantity++;
                            availabledish = true;
                        }
                        listorder.Add(temp);
                    }
                    if (availabledish)
                    {
                        SourceOrder = listorder;
                        return;
                    }
                }
                //bình sửa
                if(a!=null)
                {
                    //khi món đó chưa có trong order thì set số lượng =1
                    OrderDetails b = new OrderDetails(a.Id, GetOrders.Id, a.Price, 1);
                    listorder.Add(b);
                    SourceOrder = listorder;
                }    
                //
            }
        }

        private void ListViewItem_PreviewGotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            ListViewItem item = (ListViewItem)sender;
            item.IsSelected = true;
        }


        private void Cmbcustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Customers a = cmbcustomer.SelectedItem as Customers;
            if (a != null)
            {
                txbtkhachang.Text = a.Name;
                txbDiscount_point.Text = a.Point.ToString();
            }
            else txbtkhachang.Text = "";

            if (txbtkhachang.Text != "")
                btnfindcus.Content = "Chi tiết";
        }

        //Nhấn hủy form thêm khách hàng

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            txbname.Clear();
            txbId.Clear();
            txbphone.Clear();
            txbDiscount_point.Text = "0";

            btnSave.IsEnabled = true;

            grid_addcustomer.Visibility = Visibility.Hidden;
            rightgrid.IsEnabled = true;
        }

        private void Btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            txbname.Clear();
            txbId.Clear();
            txbphone.Clear();
            txbDiscount_point.Clear();
            btnSave.IsEnabled = true;

            grid_addcustomer.Visibility = Visibility.Hidden;
            rightgrid.IsEnabled = true;
        }

        bool checkinput_customer()
        {

            if(txbname.Text.Trim()=="" || txbphone.Text.Trim()==""|| txbpoint.Text.Trim()=="")
            {
                MessageBox.Show("Bạn phải điền hết thông tin");
                return false;
            }
            return true;
        }
        //thêm một khách hàng mới
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!checkinput_customer())
                return;
            Customers cus = new Customers();
            if (cus.addNewCustomer(txbname.Text, txbphone.Text, Int32.Parse(txbpoint.Text)))
            {
                MessageBox.Show("Thêm thành công");
                txbname.Clear();
                txbId.Clear();
                txbphone.Clear();
                txbDiscount_point.Clear();
                btnSave.IsEnabled = true;
                grid_addcustomer.Visibility = Visibility.Hidden;
                rightgrid.IsEnabled = true;

                cmbcustomer.ItemsSource = cus.loadAllCustomer();

                cmbcustomer.SelectedIndex = cmbcustomer.Items.Count-1;
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
                txbname.Clear();
                txbId.Clear();
                txbphone.Clear();
                txbDiscount_point.Clear();
                btnSave.IsEnabled = true;

                grid_addcustomer.Visibility = Visibility.Hidden;
                rightgrid.IsEnabled = true;
            }
        }

        private void PackIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            plsuccessenter.Visibility = Visibility.Hidden;
            btnenter.IsEnabled = true;
            listviewBill.IsEnabled = false;
            btnenter.Content = "Order thêm";
        }

        private void Btncomeback_Click(object sender, RoutedEventArgs e)
        {
            ordereds = ordercn.loadlistOrderDetail(GetOrders.Id);
            if (sourceOrder != ordereds)
            {
                Dialog dialog = new Dialog();
                dialog.Message = "Một số món vẫn chưa lưu vào bếp. Bạn chắc chắn muốn thoát ?";
                dialog.Owner = Window.GetWindow(this);
                dialog.ShowDialog();

                if (dialog.DialogResult == true)
                {
                    this.NavigationService.Navigate(new orderTable());
                }

            }
        }

        private void Descrease_quantity_Click(object sender, RoutedEventArgs e)
        {
            if (listviewBill.SelectedIndex >= 0)
            {
                OrderDetails order = listviewBill.SelectedItem as OrderDetails;
                ObservableCollection<OrderDetails> list = new ObservableCollection<OrderDetails>();
                if (!ordercn.checkexistDish(order.IdDish, order.IdOrder))
                {
                    if (order.Quantity > 1)
                    {
                        for (int i = 0; i < listviewBill.Items.Count; i++)

                        {
                            OrderDetails orders = listviewBill.Items[i] as OrderDetails;
                            if (orders.IdDish == order.IdDish)
                            {
                                orders.Quantity--;

                            }
                            list.Add(orders);
                        }
                        SourceOrder = list;
                    }
                    else

                    MessageBox.Show("Số lương ko hợp lí");
                }
                else
                {
                    //số lượng đã vào bếp nên chỉ được giảm đến con số này
                    int forcequantity = ordercn.getQuantity(order.IdDish, order.IdOrder);
                    if (order.Quantity > forcequantity)
                    {
                        //update listviewBill lại cho đến số lượng đã vào bếp
                        for (int i = 0; i < listviewBill.Items.Count; i++)
                        {
                            OrderDetails orders = listviewBill.Items[i] as OrderDetails;
                            if (orders.IdDish == order.IdDish)
                            {
                                orders.Quantity--;

                            }
                            list.Add(orders);
                        }
                        SourceOrder= list;


                    }
                }
            }
        }

        ObservableCollection<OrderDetails> ConvertoList()
        {
            ObservableCollection<OrderDetails> listorder = new ObservableCollection<OrderDetails>();
            if (listviewBill.Items.Count > 0)
            {
                for (int i = 0; i < listviewBill.Items.Count; i++)
                {
                    OrderDetails temp = listviewBill.Items[i] as OrderDetails;
                    
                    listorder.Add(temp);
                }
                return listorder;
            }
            return null;
        }
        //xóa món ra khỏi listorder khi món đó chưa vào bếp

        private void Btn_delete_Click(object sender, RoutedEventArgs e)
        {
            if (listviewBill.SelectedIndex >= 0)
            {

                OrderDetails order = listviewBill.SelectedItem as OrderDetails;
                int index = listviewBill.SelectedIndex;

                ObservableCollection<OrderDetails> listorder = new ObservableCollection<OrderDetails>();
                //Lấy danh sách món đã chọn

                if (listviewBill.Items.Count > 0)
                {
                    if( ordereds.Count>index && order.IdDish== ordereds[index].IdDish)
                    {
                        MessageBox.Show("Không thể xóa món đã vào bếp!");
                        return;
                    }
                    else
                    {
                        ObservableCollection<OrderDetails> items = ConvertoList();
                        items.RemoveAt(index);
                      SourceOrder = items;
                        MessageBox.Show("Đã xóa");
                    }
                  
                }
            }
        }
 
        private void Delete_icon_MouseDown(object sender, MouseButtonEventArgs e)
        {

            if (listviewBill.SelectedIndex >= 0)
            {
                OrderDetails order = listviewBill.SelectedItem as OrderDetails;
                int index = listviewBill.SelectedIndex;

                ObservableCollection<OrderDetails> listorder = new ObservableCollection<OrderDetails>();
                //Lấy danh sách món đã chọn

                if (listviewBill.Items.Count > 0)
                {
                    if (ordereds.Count > index && order.IdDish == ordereds[index].IdDish)
                    {
                        MessageBox.Show("Không thể xóa món đã vào bếp!");
                        return;
                    }
                    else
                    {
                        ObservableCollection<OrderDetails> items = ConvertoList();
                        items.RemoveAt(index);
                       SourceOrder= items;
                        MessageBox.Show("Đã xóa");
                    }

                }
            }
        }


        private void Btn_thanhtoan_Click(object sender, RoutedEventArgs e)
        {
            if (ordereds.Count > 0)
            {
                Events a = cmbdiscount.SelectedItem as Events;
                billController billController = new billController();
                int idcus = 0;
                if (cmbcustomer.SelectedIndex >= 0)
                {
                    Customers cus = cmbcustomer.SelectedItem as Customers;
                    idcus = cus.Id;
                }
                else idcus = 0;

                    
                    int point ;
                    if (txbDiscount_point.Text == "") point = 0;
                    point = Convert.ToInt32(txbDiscount_point.Text);

                    if (billController.addNewBill(a.Id, Convert.ToInt32(txblastcost.Text), GetOrders.IdEmp, idcus, 1,point, GetOrders.Id))
                    {
                        MessageBox.Show("Thanh toán thành công");
                       // pl_pay_bill.Visibility = Visibility.Hidden;
                        //listviewpayBill.Visibility = Visibility.Visible;
                        //listviewShowFood.IsEnabled = true;
                        this.NavigationService.Navigate(new orderTable());
                    }
                    else
                    {
                        MessageBox.Show("Thanh toán chưa thành công ");
                    }
                

            }
            else
                MessageBox.Show("Chưa có món ");

           
        }

        private void PackIcon_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            pl_pay_bill.Visibility = Visibility.Hidden;
            btn_thanhtoan.Visibility = Visibility.Hidden;
            Button_pan.Visibility = Visibility.Visible;
            listviewpayBill.Visibility = Visibility.Visible;
            listviewShowFood.IsEnabled = true;
        }
    }   
}
