using CoffeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CoffeeManagement.ViewModels
{
    public class UnitsViewModel : BaseViewModel
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
        
        private Unit _SelectedItem;
        public Unit SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    DisplayName = SelectedItem.DisplayName;
                }
                else
                {
                    DisplayName = null;
                }
            }
        }
        private ObservableCollection<Unit> _ListGrid;
        public ObservableCollection<Unit> ListGrid { get => _ListGrid; set { _ListGrid = value; OnPropertyChanged(); } }
        private List<string> _SearchList;
        public List<string> SearchList { get => _SearchList; set { _SearchList = value; OnPropertyChanged(); } }
        private void InitSearchList()
        {
            SearchList = new List<string>();
            SearchList.Add("Mã");
            SearchList.Add("Tên đơn vị");
        }
        public UnitsViewModel()
        {
            LoadCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                try
                {
                    InitSearchList();
                    ListGrid = new ObservableCollection<Unit>(DataProvider.Ins.DB.Units);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            });
            
            AddCommand = new RelayCommand<object>((p) =>
            {
                if (String.IsNullOrEmpty(DisplayName)) return false;
                var displayList = DataProvider.Ins.DB.Units.Where(x => x.DisplayName == DisplayName);
                if (displayList.Count() != 0) return false;
                return true;
            }, (p) =>
            {
                try
                {
                    Unit Unit = new Unit();
                    Unit.DisplayName = DisplayName;
                    DataProvider.Ins.DB.Units.Add(Unit);
                    DataProvider.Ins.DB.SaveChanges();
                    ListGrid = new ObservableCollection<Unit>(DataProvider.Ins.DB.Units);
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
                var displayList = DataProvider.Ins.DB.Units.Where(x => x.DisplayName == DisplayName);
                if (displayList.Count() != 0) return false;
                return true;
            }, (p) =>
            {
                try
                {
                    var unit = DataProvider.Ins.DB.Units.Where(x => x.Id == SelectedItem.Id).FirstOrDefault();
                    unit.DisplayName = DisplayName;
                    DataProvider.Ins.DB.SaveChanges();
                    ListGrid = new ObservableCollection<Unit>(DataProvider.Ins.DB.Units);
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
                var displayList = DataProvider.Ins.DB.Units.Where(x => x.Id == SelectedItem.Id);
                if (displayList.Count() == 0) return false;
                return true;
            }, (p) =>
            {
                try
                {
                    if (MessageBox.Show("Bạn chắc chắn muốn xóa chứ?", "Cảnh báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    {
                        DataProvider.Ins.DB.Units.Remove(SelectedItem);
                        DataProvider.Ins.DB.SaveChanges();
                        ListGrid = new ObservableCollection<Unit>(DataProvider.Ins.DB.Units);
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
            ObservableCollection<Unit> filtered;
            if (String.IsNullOrEmpty(SearchContent))
            {
                filtered = new ObservableCollection<Unit>(DataProvider.Ins.DB.Units);
            }
            else
            {                
                if (SelectedSearchList == SearchList[0])
                {
                    int i;
                    if (Int32.TryParse(SearchContent, out i))
                    {
                        filtered = new ObservableCollection<Unit>(DataProvider.Ins.DB.Units.Where(x => x.Id == i));
                    }
                    else filtered = new ObservableCollection<Unit>();
                }                
                else
                {
                    filtered = new ObservableCollection<Unit>(DataProvider.Ins.DB.Units.Where(x => x.DisplayName.Contains(SearchContent)));
                }                
            }
            ListGrid = filtered;
        }
    }
}
