using CoffeeManagement.Models;
using CoffeeManagement.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using MaterialDesignThemes.Wpf;


namespace CoffeeManagement.ViewModels
{
    public class BillViewModel : BaseViewModel
    {
        public ICommand ClearCommand { get; set; }
        public ICommand DoubleClickCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand LoadCommand { get; set; }
        private bool _BringHomeChecked;
        public bool BringHomeChecked
        {
            get => _BringHomeChecked;
            set
            {
                _BringHomeChecked = value;
                OnPropertyChanged();
                if (BringHomeChecked == true) AtStoreChecked = false;
                OnSearch();
            }
        }
        private bool _AtStoreChecked;
        public bool AtStoreChecked
        {
            get => _AtStoreChecked;
            set
            {
                _AtStoreChecked = value;
                OnPropertyChanged();
                if (AtStoreChecked == true) BringHomeChecked = false;
                if (AtStoreChecked == false)
                {
                    RoomSelected = null;
                    TableSelected = null;
                }
                OnSearch();
            }
        }
        private bool _NonMemberChecked;
        public bool NonMemberChecked { get => _NonMemberChecked; set { _NonMemberChecked = value; OnPropertyChanged(); OnSearch(); } }
        private bool _IsMemberChecked;
        public bool IsMemberChecked { get => _IsMemberChecked; set { _IsMemberChecked = value; OnPropertyChanged(); if (IsMemberChecked == false) CusPhone = null; OnSearch(); } }
        private DateTime? _StartHour;
        public DateTime? StartHour
        {
            get => _StartHour;
            set
            {
                _StartHour = value;
                OnPropertyChanged();
                OnSearch();
            }
        }
        private DateTime? _EndHour;
        public DateTime? EndHour
        {
            get => _EndHour;
            set
            {
                _EndHour = value;
                OnPropertyChanged();
                OnSearch();
            }
        }
        private DateTime? _FromDate;
        public DateTime? FromDate
        {
            get => _FromDate;
            set
            {
                _FromDate = value;
                OnSearch();
            }
        }
        private string _txtFromDate;
        public string txtFromDate
        {
            get => _txtFromDate;
            set
            {
                try
                {
                    _txtFromDate = value;
                    OnPropertyChanged();
                    if (String.IsNullOrEmpty(txtFromDate)) FromDate = null;
                    else FromDate = Convert.ToDateTime(txtFromDate);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private DateTime? _ToDate;
        public DateTime? ToDate
        {
            get => _ToDate;
            set
            {
                _ToDate = value;
                OnSearch();
            }
        }
        private string _txtToDate;
        public string txtToDate
        {
            get => _txtToDate;
            set
            {
                try
                {
                    _txtToDate = value;
                    OnPropertyChanged();
                    if (String.IsNullOrEmpty(txtToDate)) ToDate = null;
                    else ToDate = Convert.ToDateTime(txtToDate);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        private Room _RoomSelected;
        public Room RoomSelected
        {
            get => _RoomSelected;
            set
            {
                _RoomSelected = value;
                OnPropertyChanged();
                if (RoomSelected != null)
                {
                    TableList = sourceTable.Where(x => x.RoomID == RoomSelected.Id).ToList();
                    OnSearch();
                }
                else
                {
                    TableList = sourceTable.ToList();
                }
            }
        }
        private TableInfo _TableSelected;
        public TableInfo TableSelected { get => _TableSelected; set { _TableSelected = value; OnPropertyChanged(); OnSearch(); } }
        private string _SearchContent;
        public string SearchContent
        {
            get => _SearchContent;
            set
            {
                _SearchContent = value; OnPropertyChanged();
                OnSearch();
            }
        }
        private string _CusPhone;
        public string CusPhone
        {
            get => _CusPhone;
            set
            {
                _CusPhone = value; OnPropertyChanged();
                OnSearch();
            }
        }
        private ObservableCollection<Bill> _ListGrid;
        public ObservableCollection<Bill> ListGrid
        {
            get => _ListGrid;
            set
            {
                _ListGrid = value;
                OnPropertyChanged();
            }
        }
        private Bill _SelectedItem;
        public Bill SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
            }
        }
        private List<string> _SearchList;
        public List<string> SearchList { get => _SearchList; set { _SearchList = value; OnPropertyChanged(); } }
        private string _SelectedSearchList;
        public string SelectedSearchList { get => _SelectedSearchList; set { _SelectedSearchList = value; OnPropertyChanged(); } }
        private List<Room> _RoomList;
        public List<Room> RoomList { get => _RoomList; set { _RoomList = value; OnPropertyChanged(); } }
        private List<TableInfo> _TableList;
        public List<TableInfo> TableList
        {
            get => _TableList;
            set
            {
                _TableList = value;
                OnPropertyChanged();
            }
        }
        private List<TableInfo> _sourceTable;
        public List<TableInfo> sourceTable { get => _sourceTable; set { _sourceTable = value; OnPropertyChanged(); } }
        private List<Room> _sourceRoom;
        public List<Room> sourceRoom { get => _sourceRoom; set { _sourceRoom = value; OnPropertyChanged(); } }

        private List<Bill> _sourceBills;
        public List<Bill> sourceBills { get => _sourceBills; set { _sourceBills = value; } }
        public BillViewModel()
        {
            LoadCommand = new RelayCommand<UserControl>((p) =>
            {
                return true;
            }, (p) =>
            {
                LoadFunction();
            });

            DoubleClickCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                try
                {
                    List<BillInfo> bis = new List<BillInfo>(DataProvider.Ins.DB.BillInfoes.Where(x => x.BillID == SelectedItem.Id));
                    List<PromotionAndBill> pab = new List<PromotionAndBill>(DataProvider.Ins.DB.PromotionAndBills.Where(x => x.BillId == SelectedItem.Id));
                    PaymentViewModel vm = new PaymentViewModel(SelectedItem, bis, pab, null);
                    PaymentWindow w = new PaymentWindow();
                    w.DataContext = vm;
                    w.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            });

            ClearCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                SetNullControl();
            });
            DeleteCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null) return false;
                return true;
            }, (p) =>
            {
                try
                {
                    DataProvider.Ins.DB.Bills.Remove(SelectedItem);
                    DataProvider.Ins.DB.SaveChanges();
                    sourceBills = new List<Bill>(DataProvider.Ins.DB.Bills);
                    ListGrid = new ObservableCollection<Bill>(sourceBills);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }                
            });
        }

        private void SetNullControl()
        {
            RoomSelected = null;
            TableSelected = null;
            txtFromDate = null;
            txtToDate = null;
            StartHour = null;
            EndHour = null;
            SelectedSearchList = null;
            SearchContent = null;
            BringHomeChecked = false;
            AtStoreChecked = false;
            NonMemberChecked = false;
            IsMemberChecked = false;
            CusPhone = null;
            SelectedItem = null;
        }

        private void LoadFunction()
        {
            InitSearchList();
            sourceBills = new List<Bill>(DataProvider.Ins.DB.Bills);
            sourceTable = new List<TableInfo>(DataProvider.Ins.DB.TableInfoes);
            sourceRoom = new List<Room>(DataProvider.Ins.DB.Rooms);
            ListGrid = new ObservableCollection<Bill>(sourceBills);
            TableList = new List<TableInfo>(sourceTable);
            RoomList = new List<Room>(sourceRoom);
            SetNullControl();
        }
        private void InitSearchList()
        {
            SearchList = new List<string>();
            SearchList.Add("Mã hóa đơn");
            SearchList.Add("Người bán");
        }
        private void OnSearch()
        {
            List<Bill> result = new List<Bill>();
            result = sourceBills;
            if (result == null) return;
            if (BringHomeChecked) result = result.Where(x => x.IsUsingAtStore == false).ToList();
            if (AtStoreChecked)
            {
                result = result.Where(x => x.IsUsingAtStore == true).ToList();
                if (RoomSelected != null) result = sourceBills.Where(x => x.TableID != null && x.TableInfo.RoomID == RoomSelected.Id).ToList();
                if (TableSelected != null)
                {
                    result = result.Where(x => x.TableID != null && x.TableID == TableSelected.Id).ToList();
                }
            }
            if (FromDate != null)
            {
                List<Bill> bills = new List<Bill>();
                foreach (var item in result)
                {
                    DateTime dt = Convert.ToDateTime(item.DateCreated);
                    if (DateTime.Compare(dt, Convert.ToDateTime(FromDate)) >= 0) bills.Add(item);
                }
                result = bills.ToList();
            }
            if (ToDate != null)
            {
                List<Bill> bills = new List<Bill>();
                foreach (var item in result)
                {
                    DateTime dt = Convert.ToDateTime(item.DateCreated);
                    if (DateTime.Compare(dt, Convert.ToDateTime(ToDate)) <= 0) bills.Add(item);
                }
                result = bills.ToList();
            }
            if (StartHour != null)
            {
                DateTime dateTime = Convert.ToDateTime(StartHour);
                List<Bill> temp1 = new List<Bill>();
                foreach (var item in result)
                {
                    DateTime dt = Convert.ToDateTime(item.DateCreated);
                    if (TimeSpan.Compare(dt.TimeOfDay, dateTime.TimeOfDay) == 1) temp1.Add(item);
                }
                result = temp1.ToList();
            }
            if (EndHour != null)
            {
                DateTime dateTime = Convert.ToDateTime(EndHour);
                List<Bill> temp1 = new List<Bill>();
                foreach (var item in result)
                {
                    DateTime dt = Convert.ToDateTime(item.DateCreated);
                    if (TimeSpan.Compare(dt.TimeOfDay, dateTime.TimeOfDay) == -1) temp1.Add(item);
                }
                result = temp1.ToList();
            }
            if (NonMemberChecked) result = result.Where(x => x.IsCusMember == false).ToList();
            if (IsMemberChecked)
            {
                result = result.Where(x => x.IsCusMember == true).ToList();
                if (!String.IsNullOrEmpty(CusPhone))
                {
                    result = result.Where(x => x.CustomerPhone.Contains(CusPhone)).ToList();
                }
            }
            if (SelectedSearchList != null && !String.IsNullOrEmpty(SearchContent))
            {
                string se = SearchContent.ToLower();
                if (SelectedSearchList == SearchList[0])
                {
                    result = result.Where(x => x.Id.ToLower().Contains(se)).ToList();
                }
                if (SelectedSearchList == SearchList[1])
                {
                    result = result.Where(x => x.UserName.ToLower().Contains(se)).ToList();
                }
            }
            ListGrid = new ObservableCollection<Bill>(result);
        }
        //private List<int> GetSpecificFromDateType(DateTime? dt)
        //{
        //    if (dt == null) return null;
        //    else
        //    {
        //        DateTime dt1 = Convert.ToDateTime(dt);
        //        List<int> re = new List<int>();
        //        re.Add(dt1.Year);//year
        //        re.Add(dt1.Month);
        //        re.Add(dt1.Day);
        //        re.Add(dt1.Hour);
        //        re.Add(dt1.Minute);
        //        re.Add(dt1.Second);
        //        return re;
        //    }
        //}
    }
}
