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
using Restaurant.Controller;
namespace Restaurant.View
{
    /// <summary>
    /// Interaction logic for Hoadon_page.xaml
    /// </summary>
    public partial class Hoadon_page : Page
    {

        ObservableCollection<Bills> listBills;
        ObservableCollection<string> listSortBy = new ObservableCollection<string> { "Trạng thái", "Mã Đơn hàng", "Nhân viên", "Khách hàng", "Thời gian " };
        ObservableCollection<string> listState = new ObservableCollection<string> { "Đã hủy", "Hoàn thành" };
        billController billDB = new billController();
        int totalBill = 0;
        int filterBy = 0;
        int filterByState = 0;

        //Paramater for tracking id Bill selection
        int selectionBill = 0;
        public int SelectionBill
        {
            get { return selectionBill; }
            set { selectionBill = value; }
        }

        DateTime? editStartDay;
        DateTime? editEndDay;
        public Hoadon_page()
        {
            InitializeComponent();

            ListBills = new ObservableCollection<Bills>();
            ListBills = billDB.findById(1);
            listViewBill.ItemsSource = ListBills;

            cmbfilterMain.ItemsSource = listSortBy;
            cmbfilterMain.SelectedIndex = 0;
            cmbfilterSecondary.ItemsSource = listState;
            cmbfilterSecondary.SelectedIndex = 0;
        }
        public void changeUIByFilter(int stateFilt)
        {
            if (stateFilt == 0)  // Filter by State
            {
                cmbfilterSecondary.Visibility = Visibility.Visible;
                txbFindBill.IsEnabled = false;
                editFromDate.IsEnabled = false;
                editToDate.IsEnabled = false;
            }
            else if (stateFilt >= 1 && stateFilt <= 3) // Filter by ID or Name
            {
                cmbfilterSecondary.Visibility = Visibility.Collapsed;
                txbFindBill.IsEnabled = true;
                editFromDate.IsEnabled = false;
                editToDate.IsEnabled = false;
                txbFindBill_TextChanged(null, null);
            }
            else //state==3_ filter by Time_ Time
            {

                cmbfilterSecondary.Visibility = Visibility.Collapsed;
                txbFindBill.IsEnabled = false;
                editFromDate.IsEnabled = true;
                editToDate.IsEnabled = true;
                listViewBill.ItemsSource = null;
            }
        }

        public int TotalBill
        {
            get
            {
                return totalBill;
            }
            set
            {
                totalBill = value;
                lbDataQuantity.Content = totalBill;
            }
        }
        public ObservableCollection<string> ListSortBy
        {
            get { return listSortBy; }
            set { listSortBy = value; }
        }
        public int FilterBy
        {
            get { return filterBy; }
            set
            {
                filterBy = value;
                changeUIByFilter(filterBy);
            }
        }

        public int FilterByState
        {
            get { return filterByState; }
            set { filterByState = value; }
        }

        public DateTime? EditStartDay
        {
            get { return editStartDay; }
            set
            {

                editStartDay = value;
                listViewBill.ItemsSource = null;
                DateTime? startDay = EditStartDay;
                DateTime? endDay = editEndDay;
                if (endDay.HasValue && startDay.HasValue)
                {
                    if (endDay >= startDay)
                    {
                        #region Check Format
                        //string startFormat = startDay.Value.ToString("MM.dd.yyyy HH:mm:ss.fffffff'Z'", System.Globalization.CultureInfo.InvariantCulture);
                        //string endFormat = endDay.Value.ToString("MM.dd.yyyy HH:mm:ss.fffffff'Z'", System.Globalization.CultureInfo.InvariantCulture);
                        //sortBillByPeriod("'"+startFormat+ "'", "'" + endFormat + "'");
                        #endregion

                        DateTime trueStart = startDay.Value;
                        DateTime trueEnd = endDay.Value;
                        sortBillByPeriod(trueStart, trueEnd);
                    }
                }
            }
        }
        public DateTime? EditEndDay
        {
            get { return editEndDay; }
            set
            {
                editEndDay = value;
                listViewBill.ItemsSource = null;
                DateTime? startDay = EditStartDay;
                DateTime? endDay = editEndDay;
                if (endDay.HasValue && startDay.HasValue)
                {
                    if (endDay >= startDay)
                    {
                        #region Check format
                        //string startFormat = startDay.Value.ToString("MM.dd.yyyy HH:mm:ss.fffffff'Z'", System.Globalization.CultureInfo.InvariantCulture);
                        //string endFormat = endDay.Value.ToString("MM.dd.yyyy HH:mm:ss.fffffff'Z'", System.Globalization.CultureInfo.InvariantCulture);
                        //sortBillByPeriod(startFormat, endFormat);
                        #endregion
                        DateTime trueStart = startDay.Value;
                        DateTime trueEnd = endDay.Value;
                        sortBillByPeriod(trueStart, trueEnd);
                    }
                }
            }
        }

        public ObservableCollection<Bills> ListBills
        {
            get { return listBills; }
            set { listBills = value; TotalBill = listBills.Count; }
        }


        private void cmbfilterMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterBy = cmbfilterMain.SelectedIndex;
            if (FilterBy == 0)
            {
                ListBills = billDB.findByState(filterByState);
                listViewBill.ItemsSource = ListBills;
                //  TotalBill = ListBills.Count;

            }

        }

        private void editToDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            EditEndDay = editToDate.SelectedDate;

        }
        public void sortBillByPeriod(DateTime startDate, DateTime endDate)
        {
            ListBills = billDB.findByDateTime(startDate, endDate);
            listViewBill.ItemsSource = ListBills;
            // TotalBill = ListBills.Count;
        }

        private void cmbfilterSecondary_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterByState = cmbfilterSecondary.SelectedIndex;
            ListBills = billDB.findByState(filterByState);
            listViewBill.ItemsSource = ListBills;

        }

        private void txbFindBill_TextChanged(object sender, TextChangedEventArgs e)
        {
            listViewBill.ItemsSource = null;
            if (FilterBy == 1)  //Find By id 
            {
                try
                {
                    string number = txbFindBill.Text.Trim();
                    ListBills = billDB.findById(Convert.ToInt32(number));
                    listViewBill.ItemsSource = ListBills;

                }
                catch
                {

                }

            }
            else if (FilterBy == 2) // Find by name employee
            {
                ListBills = billDB.findByNameEmp(txbFindBill.Text);
                listViewBill.ItemsSource = ListBills;

            }
            else    // Find by name customer
            {
                ListBills = billDB.findByNameCus(txbFindBill.Text);
                listViewBill.ItemsSource = ListBills;

            }

            TotalBill = ListBills.Count;
        }

        private void editFromDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            EditStartDay = editFromDate.SelectedDate;
        }

        private void listViewBill_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Invoice_page v = new Invoice_page(SelectionBill);
            v.ShowDialog();
        }

        private void listViewBill_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Bills b = (listViewBill.SelectedItem as Bills);
            if (b != null)
            {
                SelectionBill = b.Id;
            }

        }
    }
}
