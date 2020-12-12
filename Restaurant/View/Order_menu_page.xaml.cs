<<<<<<< HEAD
﻿//cmbcustomer


using System;
=======
﻿using System;
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
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
<<<<<<< HEAD
=======
using System.Collections;
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151

namespace Restaurant.View
{
    /// <summary>
    /// Interaction logic for Order_menu.xaml
    /// </summary>
    public partial class Order_menu : Page
    {
<<<<<<< HEAD
        //Bình thêm
        tableController dbTable = new tableController();
        //tạo 1 biến để lưu id bàn truyền vào
        int idSeat;
        orderController dbod = new orderController();
        //
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

=======
        dishesController discn = new dishesController();
        orderdetailController ordercn = new orderdetailController();
        employeeController empcn = new employeeController();
        //danh sách món đã chọn trong database
        ObservableCollection<OrderDetails> ordereds = new ObservableCollection<OrderDetails>();
        //Trở lại trạng thái cũ
       // ObservableCollection<OrderDetails> combacklist= new ObservableCollection<OrderDetails>();

        Orders GetOrders;
        public Order_menu()
        {

        }

        public Order_menu(Orders order)
        {
            
            InitializeComponent();
            this.GetOrders = order;
            txbthungan.IsReadOnly = true;
            txbtkhachang.IsReadOnly = true;
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151

            Thread thread = new Thread(delegate ()
            {
                Dispatcher.Invoke(() =>
<<<<<<< HEAD
                {
                    Customers a = new Customers();
                    cmbcustomer.ItemsSource = a.loadAllCustomer();

                    grid_addcustomer.Visibility = Visibility.Hidden;

                    pl_pay_bill.Visibility = Visibility.Hidden;
                    listviewtypes.ItemsSource = discn.loadallTypeDishes();
                    listviewtypes.SelectedIndex = 1;
                    //listviewShowFood.ItemsSource = discn.loadallDishes();
                    Progressbar.Visibility = Visibility.Hidden;
                    Progressbar.IsEnabled = false;
=======
                {               
                    listviewtypes.ItemsSource = discn.loadallTypeDishes();
                    listviewtypes.SelectedIndex = 0;
                    //listviewShowFood.ItemsSource = discn.loadallDishes();
                    Progressbar.Visibility = Visibility.Hidden;
                    Progressbar.IsEnabled = false;

                    //mới thêm
                    
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
                });

            });
            thread.Start();
<<<<<<< HEAD
            //kiểm tra bàn này có đang order hay ko>
            if (ordercn.loadlistOrderDetail(GetOrders.Id) != null)
            {
                //Danh sách các món đã vào bếp

                ordereds = ordercn.loadlistOrderDetail(GetOrders.Id);
                listviewBill.ItemsSource = ordereds;

            }
            if (GetOrders.IdCus != 0)
            {
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
            //lấy thông tin nhân viên
            if (GetOrders.IdEmp != 0)
            {
                if (empcn.getEmpByID(GetOrders.IdEmp) != null)
                    txbthungan.Text = empcn.getEmpByID(GetOrders.IdEmp).Name;
            }

=======

            Thread thread1 = new Thread(delegate ()
            {
                Dispatcher.Invoke(() =>
                {
                    Customers a = new Customers();
                    cmbcustomer.ItemsSource = a.loadAllCustomer();

                    grid_addcustomer.Visibility = Visibility.Hidden;
                    pl_pay_bill.Visibility = Visibility.Hidden;
                    cmbdiscount.ItemsSource = discn.loadlistEvents();

                    //kiểm tra bàn này có đang order hay ko>
                    if (ordercn.loadlistOrderDetail(GetOrders.Id) != null)
                    {
                        //Danh sách các món đã vào bếp
                        ordereds = ordercn.loadlistOrderDetail(GetOrders.Id);
                        //combacklist = ordereds;
                        listviewBill.ItemsSource = ordereds;

                    }
                    if (GetOrders.IdCus != 0)
                    {
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
                    //lấy thông tin nhân viên
                    if (GetOrders.IdEmp != 0)
                    {
                        if (empcn.getEmpByID(GetOrders.IdEmp) != null)
                            txbthungan.Text = empcn.getEmpByID(GetOrders.IdEmp).Name;
                    }

                    //Mới thêm điểm khách
                    if(cmbcustomer.SelectedIndex >=0 || txbtkhachang.Text!="")
                    {
                        Customers cus = cmbcustomer.SelectedItem as Customers;
                        int point = cus.getPoint(cus.Id);
                        txbpoint.Text = point.ToString();
                    }

                });
            });
            thread1.Start();
                    
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
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
<<<<<<< HEAD
            if (btnfindcus.Content.ToString() == "Tìm kiếm")
                cmbcustomer.Visibility = Visibility;
            if (btnfindcus.Content.ToString() == "Chi tiết")
=======
            if(btnfindcus.Content.ToString()=="Tìm kiếm")
            cmbcustomer.Visibility = Visibility;
            if(btnfindcus.Content.ToString()=="Chi tiết")
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
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
<<<<<<< HEAD

        private void Btn_pay_Click(object sender, RoutedEventArgs e)
        {
            pl_pay_bill.Visibility = Visibility.Visible;
=======
        //-----------------------MỚI THÊM NHA -----------------------------------------------

        private void Btn_pay_Click(object sender, RoutedEventArgs e)
        {
            Double total = 0;
            //ẩn các button
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
            lb_origin_price.Content = total.ToString();
            lbtablenumber.Content = lb_table.Content;
            lb_area_.Content = lb_area.Content;
            lb_cus.Content = txbtkhachang.Text;


            pl_pay_bill.Visibility = Visibility.Visible;

>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
        }
        //Lưu thông tin món ăn vào bảng OrderDetail
        private void Btnenter_Click(object sender, RoutedEventArgs e)
        {
<<<<<<< HEAD
            if (btnenter.Content.ToString() == "Vào bếp")
            {
                //nếu như chưa có món nào khách đã đặt trước đó
                if (ordereds.Count == 0)
                {
                    if(listviewBill.Items.Count==0)
                    {
                        MessageBox.Show("Danh sách món ăn Order trống, không thể chuyển vào bếp!!!");
                        return;
                    }  
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
                        if(cmbcustomer.SelectedIndex==-1)
                        {
                            dbod.updateCustomerOrder("null");
                        }
                        else
                        {
                            dbod.updateCustomerOrder(cmbcustomer.Text.ToString());
                        }
=======
            
            if(btnenter.Content.ToString()=="Vào bếp")
            {
                //nếu như chưa có món nào khách đã đặt trước đó
                if(ordereds.Count==0)
                {
                    for (int i = 0; i < listviewBill.Items.Count; i++)
                    {
                        OrderDetails a = listviewBill.Items[i] as OrderDetails;
                        if (!ordercn.addOrderDetail(a.IdDish, a.IdOrder, a.Price, a.Quantity))
                        {
                            MessageBox.Show("Lỗi vào bếp chưa được " + a.NameDish);
                            return;
                        }

>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
                    }
                }
                //nếu đã đặt r và muốn đặt tiếp
                else
                {   //thêm món mới
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
<<<<<<< HEAD
                    for (int i = 0; i < ordereds.Count; i++)
                    {
                        OrderDetails orderDetails = listviewBill.Items[i] as OrderDetails;
                        
                        if (orderDetails.IdDish == ordereds[i].IdDish && ordereds[i].Quantity < orderDetails.Quantity)
                        {

=======
                    for(int i=0;i<ordereds.Count;i++)
                    {
                        OrderDetails orderDetails = listviewBill.Items[i] as OrderDetails;                        
                        if (orderDetails.IdDish == ordereds[i].IdDish && ordereds[i].Quantity < orderDetails.Quantity)
                        {                           
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
                            if (!ordercn.updateOrderdetail(orderDetails.Id, orderDetails.Quantity))
                            {
                                MessageBox.Show("Cập nhật vào đơn bị lỗi !");
                                return;
<<<<<<< HEAD
                            }
=======
                            }                              
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
                        }
                    }

                    MessageBox.Show("Đã cập nhật thành công");
                    ordereds = ordercn.loadlistOrderDetail(GetOrders.Id);
<<<<<<< HEAD

                }

=======
                  
                }
                
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
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
<<<<<<< HEAD
            if (txbfind.Text == "")
=======
            if (txbfind.Text=="")
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
            {
                listviewShowFood.ItemsSource = discn.loadDishesWithType(type.Id);
            }
            else
                listviewShowFood.ItemsSource = discn.SearchDish(txbfind.Text, type.Id);


        }
        ObservableCollection<Orders> listbill = new ObservableCollection<Orders>();

        private void ListviewShowFood_SelectionChanged(object sender, SelectionChangedEventArgs e)
<<<<<<< HEAD
        {
            //tránh trường hợp chuyển loại món
            /* if(listviewShowFood.SelectedIndex!=-1)
             {
                 bool availabledish = false;
                 Dishes a = listviewShowFood.SelectedItem as Dishes;
                 //danh sách món khách đã chọn
                 List<OrderDetails> listorder = new List<OrderDetails>();
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
                         listviewBill.ItemsSource = listorder;
                         return;
                     }
                 }

                 //khi món đó chưa có trong order thì set số lượng =1

                 OrderDetails b = new OrderDetails(a.Id, GetOrders.Id, a.Price, 1);
                 listorder.Add(b);
                 listviewBill.ItemsSource = listorder;
             }*/

=======
        {   
            //tránh trường hợp chuyển loại món
           /* if(listviewShowFood.SelectedIndex!=-1)
            {
                bool availabledish = false;
                Dishes a = listviewShowFood.SelectedItem as Dishes;
                //danh sách món khách đã chọn
                List<OrderDetails> listorder = new List<OrderDetails>();
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
                        listviewBill.ItemsSource = listorder;
                        return;
                    }
                }

                //khi món đó chưa có trong order thì set số lượng =1

                OrderDetails b = new OrderDetails(a.Id, GetOrders.Id, a.Price, 1);
                listorder.Add(b);
                listviewBill.ItemsSource = listorder;
            }*/
            
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151

        }
        //Hàm tìm kiếm món ăn theo tên
        private void Txbfind_TextChanged(object sender, TextChangedEventArgs e)
        {
            TypeFoods type = listviewtypes.SelectedItem as TypeFoods;
            listviewShowFood.ItemsSource = discn.SearchDish(txbfind.Text, type.Id);
        }

<<<<<<< HEAD
        private void DeleteListItem(object sender, RoutedEventArgs e)
        {
            var curItem = ((ListBoxItem)listviewBill.ContainerFromElement((Button)sender));
            listviewBill.SelectedItem = (ListBoxItem)curItem;
            MessageBox.Show($"Selected index = {listviewBill.SelectedIndex}");
        }

        private void Btn_Delete_Item_In_Cart_Click(object sender, RoutedEventArgs e)
        {
            var curItem = ((ListBoxItem)listviewBill.ContainerFromElement((Button)sender));
            listviewBill.SelectedItem = (ListBoxItem)curItem;
            MessageBox.Show($"Selected index = {listviewBill.SelectedIndex}");
=======
       

        private void Btn_Delete_Item_In_Cart_Click(object sender, RoutedEventArgs e)
        {
          
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151

        }

        private void ListviewShowFood_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
<<<<<<< HEAD
            if (btnenter.Content.ToString() == "Vào bếp" && btnenter.IsEnabled == true)
=======
            if (btnenter.Content.ToString()=="Vào bếp" && btnenter.IsEnabled== true)
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
            {
                bool availabledish = false;
                Dishes a = listviewShowFood.SelectedItem as Dishes;
                //danh sách món khách đã chọn
                List<OrderDetails> listorder = new List<OrderDetails>();
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
                        listviewBill.ItemsSource = listorder;
                        return;
                    }
                }
<<<<<<< HEAD
                //bình sửa
                if(a!=null)
                {
                    //khi món đó chưa có trong order thì set số lượng =1
                    OrderDetails b = new OrderDetails(a.Id, GetOrders.Id, a.Price, 1);
                    listorder.Add(b);
                    listviewBill.ItemsSource = listorder;
                }    
                //
            }
        }

        private void ListViewItem_PreviewGotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            ListViewItem item = (ListViewItem)sender;
            item.IsSelected = true;
        }
=======

                //khi món đó chưa có trong order thì set số lượng =1
                OrderDetails b = new OrderDetails(a.Id, GetOrders.Id, a.Price, 1);
                listorder.Add(b);
                listviewBill.ItemsSource = listorder;
            }
        }

    
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151

        private void Cmbcustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Customers a = cmbcustomer.SelectedItem as Customers;
            if (a != null)
                txbtkhachang.Text = a.Name;
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
<<<<<<< HEAD
            txbDiscount_point.Text = "0";
=======
            txbDiscount_point.Text="0";
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
            btnSave.IsEnabled = true;

            grid_addcustomer.Visibility = Visibility.Hidden;
            rightgrid.IsEnabled = true;
        }
<<<<<<< HEAD
        //có thể xóa

        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;
            if (item != null && item.IsSelected)
            {
                MessageBox.Show(listviewBill.SelectedIndex.ToString());
            }
        }


=======
       
        
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
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
<<<<<<< HEAD
            if (txbname.Text.Trim() == "" || txbphone.Text.Trim() == "" || txbpoint.Text.Trim() == "")
=======
            if(txbname.Text.Trim()=="" || txbphone.Text.Trim()==""|| txbpoint.Text.Trim()=="")
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
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
<<<<<<< HEAD
                cmbcustomer.SelectedIndex = cmbcustomer.Items.Count - 1;
=======
                cmbcustomer.SelectedIndex = cmbcustomer.Items.Count-1;
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
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

        }

        private void Descrease_quantity_Click(object sender, RoutedEventArgs e)
        {
<<<<<<< HEAD
            if (listviewBill.SelectedIndex >= 0)
=======
            if(listviewBill.SelectedIndex>=0)
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
            {
                OrderDetails order = listviewBill.SelectedItem as OrderDetails;
                ObservableCollection<OrderDetails> list = new ObservableCollection<OrderDetails>();
                if (!ordercn.checkexistDish(order.IdDish, order.IdOrder))
                {
                    if (order.Quantity > 1)
                    {
<<<<<<< HEAD
                        for (int i = 0; i < listviewBill.Items.Count; i++)
=======
                        for (int i=0;i<listviewBill.Items.Count; i++)
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
                        {
                            OrderDetails orders = listviewBill.Items[i] as OrderDetails;
                            if (orders.IdDish == order.IdDish)
                            {
                                orders.Quantity--;
<<<<<<< HEAD

=======
                               
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
                            }
                            list.Add(orders);
                        }
                        listviewBill.ItemsSource = list;
                    }
                    else
<<<<<<< HEAD
                        MessageBox.Show("Số lương ko hợp lí");
                }
                else
                {
                    if (order.Quantity > ordercn.getQuantity(order.IdDish, order.IdOrder))
                    {
                        //update listviewBill lại cho đến số lượng đã vào bếp
=======
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
                        listviewBill.ItemsSource = list;

>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151

                    }
                }
            }
        }

<<<<<<< HEAD
=======
        //----------------------MỚI THÊM NHA

        //xóa món ra khỏi listorder khi món đó chưa vào bếp
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

>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
        private void Btn_delete_Click(object sender, RoutedEventArgs e)
        {
            if (listviewBill.SelectedIndex >= 0)
            {
<<<<<<< HEAD

            }
        }

        private void listviewShowFood_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (btnenter.Content.ToString() == "Vào bếp" && btnenter.IsEnabled == true)
            {
                bool availabledish = false;
                Dishes a = listviewShowFood.SelectedItem as Dishes;
                //danh sách món khách đã chọn
                List<OrderDetails> listorder = new List<OrderDetails>();
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
                        listviewBill.ItemsSource = listorder;
                        return;
                    }
                }

                //khi món đó chưa có trong order thì set số lượng =1
                OrderDetails b = new OrderDetails(a.Id, GetOrders.Id, a.Price, 1);
                listorder.Add(b);
                listviewBill.ItemsSource = listorder;
            }
        }
    }
=======
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
                      listviewBill.ItemsSource = items;
                        MessageBox.Show("Đã xóa");
                    }
                  
                }
            }
        }

        private void ListviewBill_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Comback_icon_MouseDown(object sender, MouseButtonEventArgs e)
        {

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
                        listviewBill.ItemsSource = items;
                        MessageBox.Show("Đã xóa");
                    }

                }
            }
        }


        private void Btn_thanhtoan_Click(object sender, RoutedEventArgs e)
        {
            pl_pay_bill.Visibility = Visibility.Hidden;
            listviewpayBill.Visibility = Visibility.Visible;
            listviewShowFood.IsEnabled = true;
        }
    }   
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
}
