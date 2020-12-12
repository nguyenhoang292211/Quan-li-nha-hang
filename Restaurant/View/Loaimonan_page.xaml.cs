using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Restaurant.Controller;
using Restaurant.Model;
namespace Restaurant.View
{
    /// <summary>
    /// Interaction logic for Loaimonan_page.xaml
    /// </summary>
    public partial class Loaimonan_page : Page
    {
        ObservableCollection<TypeFoods> listTypeFood;
        typeFoodController typeDB = new typeFoodController();
        private int idType = 0;
        private bool isNew = false;
        private bool isCancel = false;

        private int stateFood = 0;
        private ObservableCollection<Dishes> listDishes = new ObservableCollection<Dishes>();
        private TypeFoods itemType = new TypeFoods();

        private ObservableCollection<string> listFilterState = new ObservableCollection<string> { "All", "On", "Off" };
        private ObservableCollection<string> listEditState = new ObservableCollection<string> { "On", "Off" };

        public ObservableCollection<Dishes> ListDishes
        {
            get { return listDishes; }
            set { listDishes = value;
                listviewTypes.ItemsSource = ListDishes;
                lbQuantity.Content = (ListDishes == null || ListDishes.Count == 0) ? '0'.ToString() : ListDishes.Count.ToString(); }
        }
        public ObservableCollection<TypeFoods> ListTypeFood
        {
            get { return listTypeFood; }
            set { listTypeFood = value; listCategory.ItemsSource = ListTypeFood; }
        }

        public TypeFoods ItemType
        {
            get { return itemType; }
            set
            {
                itemType = value; updateGetInforOfType();
            }
        }

        public ObservableCollection<string> ListFilterState { get => listFilterState; set => listFilterState = value; }
        public int StateFood
        {
            get { return stateFood; }
            set
            {
                stateFood = value; loadTypeFood();
            }
        }

        public ObservableCollection<string> ListEditState { get => listEditState; set => listEditState = value; }
        public bool IsNew
        {
            get => isNew;
            set
            {
                isNew = value;
                if (isNew)
                {
                    listCategory.IsEnabled = false;
                    listviewTypes.IsEnabled = false;
                }

                else
                {
                    listCategory.IsEnabled = true;
                    listviewTypes.IsEnabled = true;
                }
            }
        }

        public bool IsCancel { get => isCancel; set => isCancel = value; }

        private void loadTypeFood()

        {
            //Reset values
            txbFindTypeFood.Text = "";
            if (StateFood == 0)
            {
                ListTypeFood = typeDB.loadTypeFood(null);
            }
            else
            {
                ListTypeFood = typeDB.loadTypeFood((StateFood - 1).ToString());
            }
            // ListTypeFood = typeDB.loadTypeFood((StateFood == 0) ? null : (StateFood - 1).ToString());
            listCategory.ItemsSource = ListTypeFood;

        }
        void initial()
        {
            cmbfilterMain.ItemsSource = ListFilterState;
            cmbfilterMain.SelectedIndex = 0;
            cmbState.ItemsSource = ListEditState;

        }
        public Loaimonan_page()
        {
            InitializeComponent();
            initial();
            loadTypeFood();

        }

        private void btnedit_Click(object sender, System.Windows.RoutedEventArgs e)
        {

            if (!IsNew) //Edit
            {
                // if(ItemType==null)
                //  {
                if (txbNameType.Text != "" && txbNameType.Text != null)
                {
                    //  if (cmbState.SelectedIndex == (int) stateService.Off)
                    //  {
                    if (txbNameType.IsEnabled == true)
                    {

                        MessageBoxResult result = MessageBox.Show("Trạng thái loại món ăn thay đổi sẽ áp dụng lên tất cả các món ăn thuộc loại đó!! Bạn có chắc chưa?", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                        if (result == MessageBoxResult.OK)
                        {
                            typeDB.pro_editTypeFood(ItemType.Id, (cmbState.SelectedIndex) == 1 ? true : false, txbNameType.Text);
                            ListTypeFood = typeDB.loadTypeFood((StateFood == 0) ? null : (StateFood - 1).ToString());
                            EnableFill(false);
                        }
                        else if (result == MessageBoxResult.Cancel)
                        {
                            EnableFill(false);
                            loadTypeFood();
                        }
                    }
                    else
                    {

                        EnableFill(true);
                    }

                    //  }
                }
                else  //Cancel
                {
                    initial();
                    loadTypeFood();
                }
                // }

            }
            else  //New typeFood
            {

                MessageBoxResult result = MessageBox.Show("Tạm dừng thêm mới?", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                if (result == MessageBoxResult.OK)
                {
                    listCategory.IsEnabled = true;
                    listviewTypes.IsEnabled = true;
                    ListEditState = null;
                    ListDishes = null;
                    isNew = false;
                    txbNameType.Clear();
                    cmbState.SelectedIndex = 0;
                    icon.Kind = MaterialDesignThemes.Wpf.PackIconKind.Edit;
                    EnableFill(false);
                }

            }
            // this.NavigationService.Navigate(new Baocao_page());
        }

        private void txbFindTypeFood_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void listCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)

        {
            TypeFoods type = listCategory.SelectedItem as TypeFoods;
            //   if(type!= null)
            ItemType = type;
            if (type != null)
            {
                ListDishes = typeDB.listDishByIdType(type.Id);

            }
            else
            {
                ListDishes = null;
            }


            //    }
        }

        void updateGetInforOfType()
        {
            if (ItemType != null)
            {
                txbNameType.Text = ItemType.Name;
                cmbState.SelectedIndex = (int)ItemType.State;
            }

        }
        private void txbFindTypeFood_SelectionChanged_1(object sender, RoutedEventArgs e)
        {
            if (txbFindTypeFood.Text == "" || txbFindTypeFood.Text == null)
            {
                if (StateFood == 0)
                {
                    ListTypeFood = typeDB.loadTypeFood(null);
                }
                else
                {
                    ListTypeFood = typeDB.loadTypeFood((StateFood - 1).ToString());
                }


            }
            else
            {
                if (StateFood == 0)
                {
                    ListTypeFood = typeDB.findTypeFoodByName(txbFindTypeFood.Text, null);
                }
                else
                {
                    ListTypeFood = typeDB.findTypeFoodByName(txbFindTypeFood.Text, (StateFood - 1).ToString());

                }
            }

        }

        private void cmbfilterMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StateFood = cmbfilterMain.SelectedIndex;
            txbFindTypeFood.Text = "";
        }

        private void btnAddProm_Click(object sender, RoutedEventArgs e)
        {
            if (IsNew)
            {
                if (txbNameType.Text != null && txbNameType.Text != "")
                {
                    try
                    {
                        typeDB.pro_addTyeFood(txbNameType.Text, (cmbState.SelectedIndex == 0) ? true : false);
                        IsNew = false;
                        ListTypeFood = typeDB.loadTypeFood(null);
                        itemType = null;
                        MessageBox.Show("Thêm thành công");
                        txbNameType.Clear();
                        cmbState.SelectedIndex = 0;
                        ListDishes = null;
                        icon.Kind = MaterialDesignThemes.Wpf.PackIconKind.Edit;
                    }
                    catch
                    {
                        MessageBox.Show("Hệ thống đang bảo trì, quay lại sau");
                    }

                }
                else
                {
                    MessageBox.Show("Tên món ăn không được để trống!!!");
                }
            }
            else
            {
                IsNew = true;
                txbNameType.Clear();
                cmbState.SelectedIndex = 0;
                icon.Kind = MaterialDesignThemes.Wpf.PackIconKind.Delete;
                EnableFill(true);
            }
        }

        private void EnableFill(bool state)
        {
            txbNameType.IsEnabled = state;
            cmbState.IsEnabled = state;
        }
        private void btnedit_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }

}

