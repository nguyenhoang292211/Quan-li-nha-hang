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
using System.Windows.Shapes;
using Restaurant.Controller;
using Restaurant.Model;
namespace Restaurant.View
{
    /// <summary>
    /// Interaction logic for Invoice_page.xaml
    /// </summary>
    public partial class Invoice_page : Window
    {
        private Invoice item;
        billController billDB = new billController();
        public Invoice_page()
        {
            InitializeComponent();
        }
        public Invoice_page(int id)
        {
            InitializeComponent();
            Item = billDB.load_Invoice(id);
            this.DataContext = Item;
            lvlistDish.ItemsSource = Item.Dishes;
        }

        public Invoice Item { get => item; set => item = value; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                if(printDialog.ShowDialog()== true)
                {
                    printDialog.PrintVisual(print, "invoice");
                }
            }
            finally
            {
                this.IsEnabled = true;
            }
        }
    }
}



