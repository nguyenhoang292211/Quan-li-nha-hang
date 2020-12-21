using Restaurant.Controller;
using Restaurant.Model;
using System;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Restaurant.View
{
    public partial class Monan_page : Page
    {
        ObservableCollection<Dishes> listDishes = new ObservableCollection<Dishes>();
        ObservableCollection<TypeFoods> listType = new ObservableCollection<TypeFoods>();
        dishesController dbDishes = new dishesController();
        typeFoodController dbTypes = new typeFoodController();
       

        public Monan_page()
        {
            InitializeComponent();
            Thread thread = new Thread(delegate ()
            {
                Dispatcher.Invoke(() =>
                {
                    //load danh sách món ăn
                    listDishes = dbDishes.LoadDataLoaiMonAn_Dishes();
                    listProm.ItemsSource = listDishes;
                    cbxType.ItemsSource = dbTypes.loadTypeFood("0");
                    listType = dbTypes.loadTypeFood("1");
                    cbxType.ItemsSource = listType;
                    cbxType.DisplayMemberPath = "Name";
                });
            });
            thread.Start();   
        }
        private void btnAddProm_Click(object sender, RoutedEventArgs e)
        {
            if(txbID.Text!="")
            {
                txbID.Text = null;
                txbName.Text = null;
                txbPrice.Text = null;
                cbxState.SelectedIndex = -1;
                cbxType.SelectedIndex = -1;
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri("pack://application:,,,/Restaurant;component/view/Images/Image.png");
                image.EndInit();
                imgProduct.Source = image;
                imgProduct.Tag = null;
            }
            else
            {
                if (txbName.Text != "" && txbPrice.Text != "" && cbxType.SelectedIndex != -1 && cbxState.SelectedIndex != -1)
                {
                    if (cbxState.Text == "Còn phục vụ")
                    {
                        dbDishes.addDishes(txbName.Text, Convert.ToInt32(txbPrice.Text), (cbxType.SelectedValue as TypeFoods).Id, "True", imgProduct.Source.ToString());
                    }
                    else
                    {
                        dbDishes.addDishes(txbName.Text, Convert.ToInt32(txbPrice.Text), (cbxType.SelectedValue as TypeFoods).Id, "False", imgProduct.Source.ToString());
                    }
                    listProm.ItemsSource = dbDishes.LoadDataLoaiMonAn_Dishes();
                    BitmapImage image = new BitmapImage();
                    image.BeginInit();
                    image.UriSource = new Uri("pack://application:,,,/Restaurant;component/view/Images/Image.png");
                    image.EndInit();
                    imgProduct.Source = image;
                    imgProduct.Tag = null;
                    txbName.Text = null;
                    txbPrice.Text = null;
                    cbxType.SelectedIndex = -1;
                    cbxState.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!!!");
                }
            }
        }
        private void listProm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Dishes temp = listProm.SelectedItem as Dishes;
            if (temp != null)
            {
                txbID.Text = temp.Id.ToString();
                txbName.Text = temp.Name.ToString();
                txbPrice.Text = temp.Price.ToString();
                try
                {
                    BitmapImage image = new BitmapImage();
                    image.BeginInit();
                    image.UriSource = new Uri(temp.Img_source);
                    image.EndInit();
                    imgProduct.Source = image;
                    imgProduct.Tag = null;
                }
                catch
                {
                    BitmapImage image = new BitmapImage();
                    image.BeginInit();
                    image.UriSource = new Uri("pack://application:,,,/Restaurant;component/view/Images/Image.png");
                    image.EndInit();
                    imgProduct.Source = image;
                    imgProduct.Tag = null;
                }
                
                cbxState.Text = temp.State.ToString();

                cbxType.Text = temp.NameType;
            }
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (txbName.Text == "" || txbPrice.Text == ""||txbID.Text==""||cbxState.SelectedIndex==-1||cbxState.SelectedIndex==-1)
                MessageBox.Show("Vui lòng nhập đủ thông tin!!!");
            else
            {  
                TypeFoods a = cbxType.SelectedItem as TypeFoods;
                MessageBox.Show(a.Name.ToString());
                if(cbxState.Text=="Còn phục vụ")
                {
                    dbDishes.EditDishes(int.Parse(txbID.Text), txbName.Text, int.Parse(txbPrice.Text), (cbxType.SelectedValue as TypeFoods).Id, "0", imgProduct.Source.ToString());
                }
                else
                {
                    dbDishes.EditDishes(int.Parse(txbID.Text), txbName.Text, int.Parse(txbPrice.Text), (cbxType.SelectedValue as TypeFoods).Id, "1", imgProduct.Source.ToString());
                }
                listProm.ItemsSource = dbDishes.LoadDataLoaiMonAn_Dishes();
            }       
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            dbDishes.DeleteDishes(Convert.ToInt32(txbID.Text));
            listProm.ItemsSource = dbDishes.LoadDataLoaiMonAn_Dishes();
        }
        private void btnFindDishes_Click(object sender, RoutedEventArgs e)
        {
            if (txbFindDishes.Text == "")
            {
                listDishes = new ObservableCollection<Dishes>(dbDishes.LoadDataLoaiMonAn_Dishes());
                listProm.ItemsSource = listDishes;
            }
            else
            {
                ObservableCollection<Dishes> searchdishes = new ObservableCollection<Dishes>();

                searchdishes = dbDishes.SearchDishes(txbFindDishes.Text);
                if (searchdishes.Count > 0)
                    listProm.ItemsSource = searchdishes;
                else
                {
                    var dialog = new Dialog() { Message = "Do not find any dishes!" };
                    dialog.Owner = Window.GetWindow(this);
                    dialog.ShowDialog();
                }
                txbFindDishes.Text = "";
            }
        }
        private void txbFindDishes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnFindDishes_Click(sender, e);
            }
        }

        private void ComboBoxItem_Selected_1(object sender, RoutedEventArgs e)
        {
            listProm.ItemsSource = dbDishes.LoadDataLoaiMonAn_Dishes();
        }

        private void ComboBoxItem_Selected_2(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Dishes> searchdishes = new ObservableCollection<Dishes>();

            searchdishes = dbDishes.stateDishes("Còn phục vụ");
            if (searchdishes.Count > 0)
                listProm.ItemsSource = searchdishes;
        }

        private void ComboBoxItem_Selected_3(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Dishes> searchdishes = new ObservableCollection<Dishes>();
            searchdishes = dbDishes.stateDishes("Ngưng phục vụ");
            if (searchdishes.Count > 0)
                listProm.ItemsSource = searchdishes;
        }

        private void btnTypeDish_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Loaimonan_page());
        }

        private void cbxType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void btnAddImage_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();

            if (true == openFileDialog.ShowDialog())
            {
                string filename = openFileDialog.FileName;
                try
                {
                    BitmapImage source = new BitmapImage(new Uri(filename));
                    imgProduct.Source = source;
                    imgProduct.Tag = filename;
                }
                catch
                {
                    var dialogError = new Dialog() { Message = "Tập tin ảnh không hợp lệ" };
                    dialogError.Owner = Window.GetWindow(this);
                    dialogError.ShowDialog();
                    return;
                }
            }
        }

        private void txbPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
