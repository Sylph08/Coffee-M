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
    public class CustomerTypeViewModel: BaseViewModel
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
        private string _AddPoint;
        public string AddPoint { get => _AddPoint; set { _AddPoint = value; OnPropertyChanged(); } }
        private string _TotalPurchaseNeeded;
        public string TotalPurchaseNeeded { get => _TotalPurchaseNeeded; set { _TotalPurchaseNeeded = value; OnPropertyChanged(); } }
        
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
        private CustomerType _SelectedItem;
        public CustomerType SelectedItem
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
                    AddPoint = SelectedItem.AddPoint.ToString();
                    TotalPurchaseNeeded = SelectedItem.TotalPurchaseNeeded.ToString();
                }
                else
                {
                    Note = null;
                    DisplayName = null;
                    AddPoint = null;
                    TotalPurchaseNeeded = null;
                }
            }
        }
        private ObservableCollection<CustomerType> _ListGrid;
        public ObservableCollection<CustomerType> ListGrid { get => _ListGrid; set { _ListGrid = value; OnPropertyChanged(); } }
        private List<string> _SearchList;
        public List<string> SearchList { get => _SearchList; set { _SearchList = value; OnPropertyChanged(); } }
        private void InitSearchList()
        {
            SearchList = new List<string>();
            SearchList.Add("Mã loại");
            SearchList.Add("Tên loại");
            SearchList.Add("Điểm cộng");
            SearchList.Add("Điểm tích lũy cần thiết");
            SearchList.Add("Ghi chú");
        }
        #endregion
        public CustomerTypeViewModel()
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
                if (String.IsNullOrEmpty(DisplayName) || String.IsNullOrEmpty(AddPoint) || String.IsNullOrEmpty(TotalPurchaseNeeded)) return false;
                var check1 = DataProvider.Ins.DB.CustomerTypes.Where(x => x.DisplayName == DisplayName);
                if (check1.Count() > 0) return false;
                int? totalPoint = String.IsNullOrEmpty(TotalPurchaseNeeded) ? (int?)null : Convert.ToInt32(TotalPurchaseNeeded);
                var check2 = DataProvider.Ins.DB.CustomerTypes.Where(x => x.TotalPurchaseNeeded == totalPoint);
                if (check2.Count() > 0) return false;
                return true;
            }, (p) =>
            {
                try
                {
                    if (LocalDictionary.CheckIsDoubleType(AddPoint))
                    {
                        CustomerType customerType = new CustomerType();
                        customerType.DisplayName = DisplayName;
                        customerType.AddPoint = String.IsNullOrEmpty(AddPoint) ? (double?)null : Convert.ToDouble(AddPoint);
                        customerType.TotalPurchaseNeeded = String.IsNullOrEmpty(TotalPurchaseNeeded) ? (int?)null : Convert.ToInt32(TotalPurchaseNeeded);
                        customerType.Note = Note;
                        DataProvider.Ins.DB.CustomerTypes.Add(customerType);
                        DataProvider.Ins.DB.SaveChanges();
                        ListGrid = new ObservableCollection<CustomerType>(DataProvider.Ins.DB.CustomerTypes);
                        SelectedItem = null;
                    }
                    else MessageBox.Show("Lỗi! Điểm cộng chỉ chứa kí tự số và 1 kí tự '.'!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            });

            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem != null && SelectedItem.Id == 1) return false;
                if (String.IsNullOrEmpty(DisplayName) || String.IsNullOrEmpty(AddPoint) || String.IsNullOrEmpty(TotalPurchaseNeeded) || ListGrid.Count() == 0 || SelectedItem == null) return false;
                int? totalPoint = String.IsNullOrEmpty(TotalPurchaseNeeded) ? (int?)null : Convert.ToInt32(TotalPurchaseNeeded);
                double? addPoint = String.IsNullOrEmpty(AddPoint) ? (double?)null : Convert.ToDouble(AddPoint);
                var displayList = DataProvider.Ins.DB.CustomerTypes.Where(x => x.DisplayName == DisplayName && x.AddPoint == addPoint && x.Note == Note && x.TotalPurchaseNeeded == totalPoint);
                if (displayList.Count() > 0) return false;                
                return true;
            }, (p) =>
            {
                try
                {
                    if(!LocalDictionary.CheckIsDoubleType(AddPoint))
                    {
                        MessageBox.Show("Lỗi! Điểm cộng chỉ chứa kí tự số và 1 kí tự '.'");
                        return;
                    }
                    var check1 = DataProvider.Ins.DB.CustomerTypes.Where(x => x.DisplayName != SelectedItem.DisplayName && x.DisplayName == DisplayName);
                    if (check1.Count() > 0)
                    {
                        MessageBox.Show("Lỗi! Loại khách hàng đã tồn tại.");
                        return;
                    }
                    int? totalPoint = String.IsNullOrEmpty(TotalPurchaseNeeded) ? (int?)null : Convert.ToInt32(TotalPurchaseNeeded);
                    var check2 = DataProvider.Ins.DB.CustomerTypes.Where(x => x.TotalPurchaseNeeded != SelectedItem.TotalPurchaseNeeded && x.TotalPurchaseNeeded == totalPoint);
                    if (check2.Count() > 0)
                    {
                        MessageBox.Show("Lỗi! Mức điểm tích lũy cần thiết đã tồn tại.");
                        return;
                    }
                    var editCustomerType = DataProvider.Ins.DB.CustomerTypes.Where(x => x.Id == SelectedItem.Id).FirstOrDefault();
                        editCustomerType.DisplayName = DisplayName;
                        editCustomerType.TotalPurchaseNeeded = String.IsNullOrEmpty(TotalPurchaseNeeded) ? (int?)null : Convert.ToInt32(TotalPurchaseNeeded);
                        editCustomerType.AddPoint = String.IsNullOrEmpty(AddPoint) ? (double?)null : Convert.ToDouble(AddPoint);
                        editCustomerType.Note = Note;
                        DataProvider.Ins.DB.SaveChanges();
                        ListGrid = new ObservableCollection<CustomerType>(DataProvider.Ins.DB.CustomerTypes);
                        SelectedItem = null;
                    
                     
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            });

            DeleteCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null) return false;
                if (SelectedItem != null && SelectedItem.Id == 1) return false;
                var tables = DataProvider.Ins.DB.CustomerTypes.Where(x => x.Id == SelectedItem.Id);
                if (tables.Count() == 0) return false;
                return true;
            }, (p) =>
            {
                try
                {
                    if (MessageBox.Show("Bạn chắc chắn muốn xóa chứ", "Cảnh báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    {
                        DataProvider.Ins.DB.CustomerTypes.Remove(SelectedItem);
                        DataProvider.Ins.DB.SaveChanges();
                        ListGrid = new ObservableCollection<CustomerType>(DataProvider.Ins.DB.CustomerTypes);
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
            ListGrid = new ObservableCollection<CustomerType>(DataProvider.Ins.DB.CustomerTypes);
            SelectedItem = null;
        }

        private void Search(string SelectedSearchList, string SearchContent)
        {
            List<CustomerType> filtered = new List<CustomerType>();
            List<CustomerType> source = DataProvider.Ins.DB.CustomerTypes.ToList();
            if (SearchContent != null) SearchContent = SearchContent.ToLower();
            if (String.IsNullOrEmpty(SearchContent))
            {
                filtered = source;
            }
            else
            {
                if (SelectedSearchList == SearchList[0])
                {
                    int i;
                    if (Int32.TryParse(SearchContent, out i))
                    {
                        filtered = source.Where(x => x.Id == i).ToList();
                    }
                }
                else if (SelectedSearchList == SearchList[2])
                {
                    double i;
                    if (Double.TryParse(SearchContent, out i))
                    {
                        filtered = source.Where(x => x.AddPoint == i).ToList();
                    }
                }
                else if (SelectedSearchList == SearchList[3])
                {
                    int i;
                    if (Int32.TryParse(SearchContent, out i))
                    {
                        filtered = source.Where(x => x.TotalPurchaseNeeded == i).ToList();
                    }
                }
                else if (SelectedSearchList == SearchList[4])
                {
                    filtered = DataProvider.Ins.DB.CustomerTypes.Where(x => x.Note.Contains(SearchContent)).ToList();
                }
                else
                {
                    filtered = source.Where(x => x.DisplayName.Contains(SearchContent)).ToList();
                }
            }
            ListGrid = new ObservableCollection<CustomerType>(filtered);
        }
    }
}
