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
    public class TableViewModel : BaseViewModel
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
        private string _ChairAmount;
        public string ChairAmount { get => _ChairAmount; set { _ChairAmount = value; OnPropertyChanged(); } }
        private Room _SelectedRoom;
        public Room SelectedRoom { get => _SelectedRoom; set { _SelectedRoom = value; OnPropertyChanged(); } }
        private State _SelectedState;
        public State SelectedState { get => _SelectedState; set { _SelectedState = value; OnPropertyChanged(); } }
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
        private TableInfo _SelectedItem;
        public TableInfo SelectedItem
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
                    ChairAmount = SelectedItem.ChairAmount.ToString();
                    SelectedState = SelectedItem.IsUsing == true ? StateList[0] : StateList[1];
                    SelectedRoom = SelectedItem.Room;
                }
                else
                {
                    Note = null;
                    DisplayName = null;
                    ChairAmount = null;
                    SelectedState = null;
                    SelectedRoom = null;
                }
            }
        }
        private ObservableCollection<TableInfo> _ListGrid;
        public ObservableCollection<TableInfo> ListGrid { get => _ListGrid; set { _ListGrid = value; OnPropertyChanged(); } }
        private List<string> _SearchList;
        public List<string> SearchList { get => _SearchList; set { _SearchList = value; } }
        private void InitSearchList()
        {
            SearchList = new List<string>();
            SearchList.Add("Mã bàn");
            SearchList.Add("Tên bàn");
            SearchList.Add("Số ghế");
            SearchList.Add("Trạng thái");
            SearchList.Add("Mã phòng");
            SearchList.Add("Tên phòng");
            SearchList.Add("Ghi chú");
        }
        private ObservableCollection<Room> _RoomList;
        public ObservableCollection<Room> RoomList { get => _RoomList; set { _RoomList = value; OnPropertyChanged(); } }
        private ObservableCollection<State> _StateList;
        public ObservableCollection<State> StateList { get => _StateList; set { _StateList = value; OnPropertyChanged(); } }
        #endregion

        public TableViewModel()
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
                if (String.IsNullOrEmpty(DisplayName) || SelectedState == null || SelectedRoom == null) return false;
                var displayList = DataProvider.Ins.DB.TableInfoes.Where(x => x.DisplayName == DisplayName && x.RoomID == SelectedRoom.Id);
                if (displayList.Count() != 0) return false;
                return true;
            }, (p) =>
            {
                try
                {
                    TableInfo tableInfo = new TableInfo();
                    tableInfo.DisplayName = DisplayName;
                    tableInfo.ChairAmount = String.IsNullOrEmpty(ChairAmount) ? (short?)null : Convert.ToInt16(ChairAmount);
                    tableInfo.IsUsing = SelectedState.Id;
                    tableInfo.RoomID = SelectedRoom.Id;
                    tableInfo.Note = Note;
                    DataProvider.Ins.DB.TableInfoes.Add(tableInfo);
                    DataProvider.Ins.DB.SaveChanges();
                    ListGrid = new ObservableCollection<TableInfo>(DataProvider.Ins.DB.TableInfoes);
                    SelectedItem = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            });

            EditCommand = new RelayCommand<object>((p) =>
            {

                if (String.IsNullOrEmpty(DisplayName) || SelectedState == null || SelectedRoom == null || ListGrid.Count() == 0 || SelectedItem == null) return false;
                short? chairAmount = String.IsNullOrEmpty(ChairAmount) ? (short?)null : Convert.ToInt16(ChairAmount);
                var displayList = DataProvider.Ins.DB.TableInfoes.Where(x => x.DisplayName == DisplayName && x.RoomID == SelectedRoom.Id && x.Note == Note && x.IsUsing == SelectedState.Id && x.ChairAmount == chairAmount);
                if (displayList.Count() > 0) return false;
                return true;
            }, (p) =>
            {
                try
                {
                    var table = DataProvider.Ins.DB.TableInfoes.Where(x => x.Id == SelectedItem.Id).FirstOrDefault();
                    table.DisplayName = DisplayName;
                    table.ChairAmount = String.IsNullOrEmpty(ChairAmount) ? (short?)null : Convert.ToInt16(ChairAmount);
                    table.IsUsing = SelectedState.Id;
                    table.RoomID = SelectedRoom.Id;
                    table.Note = Note;
                    DataProvider.Ins.DB.SaveChanges();
                    ListGrid = new ObservableCollection<TableInfo>(DataProvider.Ins.DB.TableInfoes);
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
                 var tables = DataProvider.Ins.DB.TableInfoes.Where(x => x.Id == SelectedItem.Id);
                 if (tables.Count() == 0) return false;
                 return true;
             }, (p) =>
             {
                 try
                 {
                     if (MessageBox.Show("Bạn chắc chắn muốn xóa chứ", "Cảnh báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
                     {
                         DataProvider.Ins.DB.TableInfoes.Remove(SelectedItem);
                         DataProvider.Ins.DB.SaveChanges();
                         ListGrid = new ObservableCollection<TableInfo>(DataProvider.Ins.DB.TableInfoes);
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
            StateList = new ObservableCollection<State>();
            State state1 = new State(true, "Đang sử dụng", "Ngưng sử dụng");
            State state2 = new State(false, "Đang sử dụng", "Ngưng sử dụng");
            StateList.Add(state1);
            StateList.Add(state2);
            RoomList = new ObservableCollection<Room>(DataProvider.Ins.DB.Rooms);
            ListGrid = new ObservableCollection<TableInfo>(DataProvider.Ins.DB.TableInfoes);
            SelectedItem = null;
        }

        private void Search(string SelectedSearchList, string SearchContent)
        {
           
            List<TableInfo> filtered = new List<TableInfo>();
            List<TableInfo> source = DataProvider.Ins.DB.TableInfoes.ToList();
            if (SearchContent!=null) SearchContent = SearchContent.ToLower();
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
                    int i;
                    if (Int32.TryParse(SearchContent, out i))
                    {
                        filtered = source.Where(x => x.ChairAmount == i).ToList();
                    }
                }
                else if (SelectedSearchList == SearchList[3])
                {
                    if (SearchContent.Contains("đang")) filtered = source.Where(x => x.IsUsing == true).ToList();
                    if (SearchContent.Contains("ngưng")) filtered = source.Where(x => x.IsUsing == false).ToList();
                    if (SearchContent.Contains("t")) filtered = source.Where(x => x.IsUsing == true).ToList();
                    if (SearchContent.Contains("f")) filtered = source.Where(x => x.IsUsing == false).ToList();
                }
                else if (SelectedSearchList == SearchList[4])
                {
                    int i;
                    if (Int32.TryParse(SearchContent, out i))
                    {
                        filtered = source.Where(x => x.RoomID == i).ToList();
                    }
                }
                else if (SelectedSearchList == SearchList[5])
                {
                    filtered = source.Where(x => x.Room.DisplayName.Contains(SearchContent)).ToList();
                }
                else if (SelectedSearchList == SearchList[6])
                {
                    filtered = DataProvider.Ins.DB.TableInfoes.Where(x => x.Note.Contains(SearchContent)).ToList();
                }
                else
                {
                    filtered = source.Where(x => x.DisplayName.Contains(SearchContent)).ToList();
                }
            }
            ListGrid = new ObservableCollection<TableInfo>(filtered);
        }
    }
}
