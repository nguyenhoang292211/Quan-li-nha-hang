using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Restaurant.Model;
namespace Restaurant.View
{
    /// <summary>
    /// Interaction logic for Loaimonan_page.xaml
    /// </summary>
    public partial class Loaimonan_page : Page
    {
        public class FoodOfType
        {
            public FoodOfType()
            {

            }
            private string name;
            private int price;
            private string image;

            public string Name { get => name; set => name = value; }
            public int Price { get => price; set => price = value; }
            public string Image { get => image; set => image = value; }
        }


        public Loaimonan_page()
        {
            InitializeComponent();
            List<FoodOfType> listFood = new List<FoodOfType>();

            for (int i = 0; i < 10; i++)
            {
                FoodOfType food = new FoodOfType() { Name = "Cơm tấm", Price = 20000, Image = "/View/Images/Food/egg.jpg" };
                listFood.Add(food);
            }
            listviewTypes.ItemsSource = listFood;
           
        }

        //    public Loaimonan_page()
        //    {
        //        InitializeComponent();
        //       /
        //        List < Type_dish > Types = new List<Type_dish>();
        //        int j = 0;
        //        while (j < 8)
        //        {
        //            Type_dish b = new Type_dish() { Type_dishes = "Type " + j.ToString() };
        //            j++;
        //            //types.Add(b);
        //        }
        //        listviewtypes.ItemsSource = types;

        //        List<Dishes> listDishes = new List<Dishes>();
        //        int i = 0;
        //        while (i < 10)
        //        {
        //            Dishes a = new Dishes();
        //            a.Id = i.ToString();
        //            a.Name = "Mon so " + i.ToString();
        //            a.Img_source = "/View/Images/Food/egg.jpg";
        //            a.Price = 100000 + i * 1000;

        //            listDishes.Add(a);
        //            i++;
        //        }
        //        listviewShowFood.ItemsSource = listDishes;

        //  }

        //    private void Button_Click(object sender, RoutedEventArgs e)
        //    {

        //    }

        //    private void Btnaddcus_Click(object sender, RoutedEventArgs e)
        //    {
        //        grid_addcustomer.Visibility = Visibility;
        //    }

        //    private void Btnfindcus_Click(object sender, RoutedEventArgs e)
        //    {
        //        cmbcustomer.Visibility = Visibility;
        //    }

        //    private void ListviewBill_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //    {

        //    }

        //    private void Btn_pay_Click(object sender, RoutedEventArgs e)
        //    {

        //        if (pl_pay_bill.Visibility == Visibility.Hidden)
        //        {
        //            int i = 0;
        //            List<Bill> bills = new List<Bill>();
        //            while (i < 8)
        //            {
        //                Bill a = new Bill();
        //                a.stt = (i + 1).ToString();
        //                a.name = "Món số " + i.ToString();
        //                a.price = 50000;
        //                a.amount = i + 1;
        //                a.totalcost = a.amount * a.price;
        //                i++;
        //                bills.Add(a);
        //            }
        //            listviewpayBill.ItemsSource = bills;

        //            pl_pay_bill.Visibility = Visibility;
        //        }
        //        if (pl_pay_bill.Visibility == Visibility.Visible)
        //        {
        //            pl_pay_bill.Visibility = Visibility.Hidden;
        //        }

        //    }

        //    private void Btnenter_Click(object sender, RoutedEventArgs e)
        //    {
        //        if (plsuccessenter.Visibility == Visibility.Hidden)
        //            plsuccessenter.Visibility = Visibility.Visible;

        //        if (plsuccessenter.Visibility == Visibility.Visible)
        //            plsuccessenter.Visibility = Visibility.Hidden;

        //    }
        //}

        //public class Bill
        //{
        //    public string stt { get; set; }
        //    public string name { get; set; }
        //    public double price { get; set; }
        //    public int amount { get; set; }
        //    public double totalcost { get; set; }

        //}

        //public class Type_dish
        //{
        //    string type_dishes;
        //    public string Type_dishes
        //    {

        //        get { return type_dishes; }
        //        set { type_dishes = value; }
        //    }
    }
}

