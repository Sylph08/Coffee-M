using CoffeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CoffeeManagement.ViewModels
{
    public class CustomerViewModel : BaseViewModel
    {
        #region Property chung
        public ICommand ClearAllFieldCommand { get; set; }
        public ICommand LoadCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand AddCommand { get; set; }
        private string _DisplayName;
        public string DisplayName { get => _DisplayName; set { _DisplayName = value; OnPropertyChanged(); } }
        private string _Note;
        public string Note { get => _Note; set { _Note = value; OnPropertyChanged(); } }
        private string _Phone;
        public string Phone { get => _Phone; set { _Phone = value; OnPropertyChanged(); } }
        private string _CustomerID;
        public string CustomerID { get => _CustomerID; set { _CustomerID = value; OnPropertyChanged(); } }
        private string _TotalPurchased;
        public string TotalPurchased { get=> _TotalPurchased; set { _TotalPurchased = value;OnPropertyChanged(); } }
        private string _CurrentPoint;
        public string CurrentPoint
        {
            get => _CurrentPoint;
            set
            {
                _CurrentPoint = value;
                OnPropertyChanged();
            }
        }
        private CustomerType _SelectedCustomerType;
        public CustomerType SelectedCustomerType { get=> _SelectedCustomerType; set { _SelectedCustomerType = value;OnPropertyChanged(); } }
        private State _SelectedState;
        public State SelectedState { get=> _SelectedState; set { _SelectedState = value;OnPropertyChanged(); } }
        private string _SelectedSearchList;
        public string SelectedSearchList
        {
            get => _SelectedSearchList;
            set { _SelectedSearchList = value; OnPropertyChanged(); Search(SelectedSearchList, SearchContent); }
        }
        private string _SearchContent;
        public string SearchContent
        {
            get => _SearchContent;
            set { _SearchContent = value; OnPropertyChanged(); Search(SelectedSearchList, SearchContent); }
        }
        private Customer _SelectedItem;
        public Customer SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    Note = SelectedItem.Note;
                    DisplayName = SelectedItem.DisplayName;
                    Phone = SelectedItem.Phone;
                    CustomerID = SelectedItem.CustomerID;
                    TotalPurchased = SelectedItem.TotalPurchased.ToString();
                    CurrentPoint = SelectedItem.CurrentPoint.ToString();
                    SelectedCustomerType = SelectedItem.CustomerType;
                    SelectedState = SelectedItem.IsActive == true ? StateList[0] : StateList[1];
                }
                else
                {
                    Note = null;
                    DisplayName = null;
                    Phone = null;
                    CustomerID = null;
                    TotalPurchased = null;
                    CurrentPoint = null;
                    SelectedCustomerType = null;
                    SelectedState = null;
                }
            }
        }
        private ObservableCollection<CustomerType> _CustomerTypeList;
        public ObservableCollection<CustomerType> CustomerTypeList { get => _CustomerTypeList; set { _CustomerTypeList = value;OnPropertyChanged(); } }

        private ObservableCollection<Customer> _ListGrid;
        public ObservableCollection<Customer> ListGrid { get => _ListGrid; set { _ListGrid = value; OnPropertyChanged(); } }
        private List<string> _SearchList;
        public List<string> SearchList { get => _SearchList; set { _SearchList = value; OnPropertyChanged(); } }
        private List<State> _StateList;
        public List<State> StateList { get=> _StateList; set { _StateList = value;OnPropertyChanged(); } }
        private void InitSearchList()
        {
            SearchList = new List<string>();
            SearchList.Add("Tên khách hàng");
            SearchList.Add("Số điện thoại");
            SearchList.Add("Chứng minh thư");
            SearchList.Add("Loại khách hàng");
            SearchList.Add("Trạng thái");
            SearchList.Add("Ghi chú");
        }
        #endregion

        public CustomerViewModel()
        {
            LoadCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                try
                {
                    InitData();
                    InitSearchList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            });

            AddCommand = new RelayCommand<object>((p) =>
            {
                if (String.IsNullOrEmpty(DisplayName) || String.IsNullOrEmpty(Phone) || SelectedCustomerType ==null || SelectedState==null) return false;
                var displayList = DataProvider.Ins.DB.Customers.Where(x => x.Phone == Phone);
                if (displayList.Count() > 0) return false;
                return true;
            }, (p) =>
            {
                try
                {
                    if (LocalDictionary.CheckIsDoubleType(CurrentPoint))
                    {
                        Customer customer = new Customer();
                        customer.DisplayName = DisplayName;
                        customer.Phone = Phone;
                        customer.CustomerID = CustomerID;
                        customer.TotalPurchased= String.IsNullOrEmpty(TotalPurchased) ? 0 : Convert.ToInt32(TotalPurchased);
                        customer.CurrentPoint = String.IsNullOrEmpty(CurrentPoint) ? 0 : Convert.ToDouble(CurrentPoint);
                        customer.CustomerTypeID = SelectedCustomerType.Id;
                        if (SelectedState != null) customer.IsActive = SelectedState.Id;
                        else customer.IsActive = true;
                        customer.Note = Note;
                        DataProvider.Ins.DB.Customers.Add(customer);
                        DataProvider.Ins.DB.SaveChanges();
                        ListGrid = new ObservableCollection<Customer>(DataProvider.Ins.DB.Customers);
                        SelectedItem = null;
                    }
                    else MessageBox.Show("Lỗi! Điểm tích lũy chỉ chứa kí tự số và 1 kí tự '.'!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            });

            EditCommand = new RelayCommand<object>((p) =>
            {
                if (String.IsNullOrEmpty(DisplayName) || String.IsNullOrEmpty(Phone) || SelectedCustomerType == null || ListGrid.Count() == 0 || SelectedItem == null|| SelectedState == null) return false;
                int? totalPurchase = String.IsNullOrEmpty(TotalPurchased) ? (int?)null : Convert.ToInt32(TotalPurchased);
                double? currentPoint = String.IsNullOrEmpty(CurrentPoint) ? (double?)null : Convert.ToDouble(CurrentPoint);
                var displayList = DataProvider.Ins.DB.Customers.Where(x => x.DisplayName == DisplayName && x.Phone == Phone && x.Note == Note && x.CustomerID == CustomerID && x.TotalPurchased == totalPurchase && x.CurrentPoint == currentPoint && x.CustomerTypeID == SelectedCustomerType.Id && x.IsActive == SelectedState.Id);
                if (displayList.Count() > 0) return false;
                return true;
            }, (p) =>
            {
                try
                {
                    if (LocalDictionary.CheckIsDoubleType(CurrentPoint))
                    {
                        var customer = DataProvider.Ins.DB.Customers.Where(x => x.CustomerID == CustomerID).FirstOrDefault();
                        customer.DisplayName = DisplayName;
                        //customer.Phone = Phone;
                        customer.CustomerID = CustomerID;
                        customer.TotalPurchased = String.IsNullOrEmpty(TotalPurchased) ? 0 : Convert.ToInt32(TotalPurchased);
                        customer.CurrentPoint = String.IsNullOrEmpty(CurrentPoint) ? 0 : Convert.ToDouble(CurrentPoint);
                        customer.CustomerTypeID = SelectedCustomerType.Id;
                        if (SelectedState != null) customer.IsActive = SelectedState.Id;
                        else customer.IsActive = true;
                        customer.Note = Note;
                        DataProvider.Ins.DB.SaveChanges();
                        ListGrid = new ObservableCollection<Customer>(DataProvider.Ins.DB.Customers);
                        SelectedItem = null;
                    }
                    else MessageBox.Show("Lỗi! Điểm tích lũy chỉ chứa kí tự số và 1 kí tự '.'!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            });

            DeleteCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null) return false;
                var tables = DataProvider.Ins.DB.Customers.Where(x => x.CustomerID == CustomerID);
                if (tables.Count() == 0) return false;
                return true;
            }, (p) =>
            {
                try
                {
                    if (MessageBox.Show("Bạn chắc chắn muốn xóa chứ", "Cảnh báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    {
                        DataProvider.Ins.DB.Customers.Remove(SelectedItem);
                        DataProvider.Ins.DB.SaveChanges();
                        ListGrid = new ObservableCollection<Customer>(DataProvider.Ins.DB.Customers);
                        SelectedItem = null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            });
            ClearAllFieldCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null) return false;
                return true;
            }, (p) =>
            {
                SelectedItem = null;
            });
        }

        private void InitData()
        {
            StateList = new List<State>();
            StateList.Add(new State(true, "Còn hiệu lực", "Hết hiệu lực"));
            StateList.Add(new State(false, "Còn hiệu lực", "Hết hiệu lực"));
            CustomerTypeList = new ObservableCollection<CustomerType>(DataProvider.Ins.DB.CustomerTypes);
            ListGrid = new ObservableCollection<Customer>(DataProvider.Ins.DB.Customers);
            SelectedItem = null;
        }
        private void Search(string SelectedSearchList, string SearchContent)
        {
            List<Customer> filtered = new List<Customer>();
            List<Customer> source = DataProvider.Ins.DB.Customers.ToList();
            if (SearchContent != null) SearchContent = SearchContent.ToLower();
            if (String.IsNullOrEmpty(SearchContent))
            {
                filtered = source;
            }
            else
            {
                if (SelectedSearchList == SearchList[0])
                {
                    
                        filtered = source.Where(x => x.DisplayName.ToLower().Contains(SearchContent)).ToList();
                    
                }
                else if (SelectedSearchList == SearchList[2])
                {
                    filtered = source.Where(x => x.CustomerID.ToLower().Contains(SearchContent)).ToList();
                }
                else if (SelectedSearchList == SearchList[3])
                {  
                    filtered = source.Where(x => x.CustomerType.DisplayName.ToLower().Contains(SearchContent)).ToList();
                }
                else if (SelectedSearchList == SearchList[4])
                {
                    if (SearchContent.Contains("c") || SearchContent.Contains("t"))
                        filtered = DataProvider.Ins.DB.Customers.Where(x => x.IsActive == true).ToList();
                    if (SearchContent.Contains("h") || SearchContent.Contains("f"))
                        filtered = DataProvider.Ins.DB.Customers.Where(x => x.IsActive == false).ToList();
                }
                else if (SelectedSearchList == SearchList[5])
                {
                    filtered = DataProvider.Ins.DB.Customers.Where(x => x.Note.Contains(SearchContent)).ToList();
                }
                else
                {
                    filtered = source.Where(x => x.Phone.Contains(SearchContent)).ToList();
                }
            }
            ListGrid = new ObservableCollection<Customer>(filtered);
        }
    }
}
