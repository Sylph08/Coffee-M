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
    public class RoomViewModel : BaseViewModel
    {
        public ICommand ClearAllFieldCommand { get; set; }
        public ICommand LoadCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand AddCommand { get; set; }
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
            set
            {
                _SearchContent = value;
                OnPropertyChanged();
                Search(SelectedSearchList, SearchContent);
            }
        }
        private string _DisplayName;
        public string DisplayName { get => _DisplayName; set { _DisplayName = value; OnPropertyChanged(); } }
        private string _Note;
        public string Note { get => _Note; set { _Note = value; OnPropertyChanged(); } }
        private Room _SelectedItem;
        public Room SelectedItem
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
                }
                else
                {
                    Note = null;
                    DisplayName = null;
                }
            }
        }
        private ObservableCollection<Room> _ListGrid;
        public ObservableCollection<Room> ListGrid { get => _ListGrid; set { _ListGrid = value; OnPropertyChanged(); } }
        private List<string> _SearchList;
        public List<string> SearchList { get => _SearchList; set { _SearchList = value; OnPropertyChanged(); } }

        private void InitSearchList()
        {
            SearchList = new List<string>();
            SearchList.Add("Mã");
            SearchList.Add("Tên phòng");
            SearchList.Add("Ghi chú");
        }
        public RoomViewModel()
        {
            LoadCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                try
                {
                    InitSearchList();
                    ListGrid = new ObservableCollection<Room>(DataProvider.Ins.DB.Rooms);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            });
            
            AddCommand = new RelayCommand<object>((p) =>
            {
                if (String.IsNullOrEmpty(DisplayName)) return false;
                var displayList = DataProvider.Ins.DB.Rooms.Where(x => x.DisplayName == DisplayName);
                if (displayList.Count() != 0) return false;
                return true;
            }, (p) =>
            {
                try
                {
                    Room room = new Room();
                    room.DisplayName = DisplayName;
                    room.Note = Note;
                    DataProvider.Ins.DB.Rooms.Add(room);
                    DataProvider.Ins.DB.SaveChanges();
                    ListGrid = new ObservableCollection<Room>(DataProvider.Ins.DB.Rooms);
                    SelectedItem = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            });
            EditCommand = new RelayCommand<object>((p) =>
            {
                if (String.IsNullOrEmpty(DisplayName) || SelectedItem == null) return false;
                var displayList = DataProvider.Ins.DB.Rooms.Where(x => x.DisplayName == DisplayName && x.Note == Note);
                if (displayList.Count() != 0) return false;
                return true;
            }, (p) =>
            {
                try
                {
                    var room = DataProvider.Ins.DB.Rooms.Where(x => x.Id == SelectedItem.Id).FirstOrDefault();
                    room.DisplayName = DisplayName;
                    room.Note = Note;
                    DataProvider.Ins.DB.SaveChanges();
                    ListGrid = new ObservableCollection<Room>(DataProvider.Ins.DB.Rooms);
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
                var displayList = DataProvider.Ins.DB.Rooms.Where(x => x.Id == SelectedItem.Id);
                if (displayList.Count() == 0) return false;
                return true;
            }, (p) =>
            {
                try
                {
                    if (MessageBox.Show("Bạn chắc chắn muốn xóa chứ", "Cảnh báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    {
                        DataProvider.Ins.DB.Rooms.Remove(SelectedItem);
                        DataProvider.Ins.DB.SaveChanges();
                        ListGrid = new ObservableCollection<Room>(DataProvider.Ins.DB.Rooms);
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
        private void Search(string SelectedSearchList, string SearchContent)
        {
            List<Room> filtered = new List<Room>();
            List<Room> source = DataProvider.Ins.DB.Rooms.ToList();
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
                    filtered = DataProvider.Ins.DB.Rooms.Where(x => x.Note.Contains(SearchContent)).ToList();
                }
                else
                {
                    filtered = source.Where(x => x.DisplayName.ToLower().Contains(SearchContent)).ToList();
                }
            }
            ListGrid = new ObservableCollection<Room>(filtered);
        }
    }
}
