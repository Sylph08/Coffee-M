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
    public class MealTypeViewModel : BaseViewModel
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
        public string SearchContent {
            get => _SearchContent;
            set {
                _SearchContent = value;
                OnPropertyChanged();
                Search(SelectedSearchList, SearchContent);
            }
        }
        private string _DisplayName;
        public string DisplayName { get=> _DisplayName; set { _DisplayName = value;OnPropertyChanged(); } }
        private string _Note;
        public string Note { get => _Note; set { _Note = value; OnPropertyChanged(); } }
        private MealType _SelectedItem;
        public MealType SelectedItem {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if(SelectedItem!=null)
                {
                    Note = SelectedItem.Note;
                    DisplayName = SelectedItem.DisplayName;
                }
                else
                {
                    DisplayName = null;
                    Note = null;
                }
            }
        }
        private ObservableCollection<MealType> _ListGrid;
        public ObservableCollection<MealType> ListGrid { get => _ListGrid; set { _ListGrid = value; OnPropertyChanged(); } }
        private List<string> _SearchList;
        public List<string> SearchList { get => _SearchList; set { _SearchList = value; OnPropertyChanged(); } }
        private void InitSearchList()
        {
            SearchList = new List<string>();
            SearchList.Add("Mã");
            SearchList.Add("Tên thực đơn");
            SearchList.Add("Ghi chú");
        }
        public MealTypeViewModel()
        {
            LoadCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                try
                {
                    InitSearchList();
                    ListGrid = new ObservableCollection<MealType>(DataProvider.Ins.DB.MealTypes);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            });
                     
            AddCommand = new RelayCommand<object>((p) =>
            {
                if (String.IsNullOrEmpty(DisplayName)) return false;
                var displayList = DataProvider.Ins.DB.MealTypes.Where(x => x.DisplayName == DisplayName);
                if (displayList.Count() != 0) return false;
                return true;
            }, (p) =>
            {
                try
                {
                    MealType mealtype = new MealType();
                    mealtype.DisplayName = DisplayName;
                    mealtype.Note = Note;
                    DataProvider.Ins.DB.MealTypes.Add(mealtype);
                    DataProvider.Ins.DB.SaveChanges();
                    ListGrid = new ObservableCollection<MealType>(DataProvider.Ins.DB.MealTypes);
                    SelectedItem = null;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            });
            EditCommand = new RelayCommand<object>((p) =>
            {
                if (String.IsNullOrEmpty(DisplayName) || SelectedItem == null) return false;
                var displayList = DataProvider.Ins.DB.MealTypes.Where(x => x.DisplayName == DisplayName && x.Note==Note);
                if (displayList.Count() != 0) return false;
                return true;
            }, (p) =>
            {
                try
                {
                    var mealtype = DataProvider.Ins.DB.MealTypes.Where(x => x.Id == SelectedItem.Id).FirstOrDefault();
                    mealtype.DisplayName = DisplayName;
                    mealtype.Note = Note;
                    DataProvider.Ins.DB.SaveChanges();
                    ListGrid = new ObservableCollection<MealType>(DataProvider.Ins.DB.MealTypes);
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
                var displayList = DataProvider.Ins.DB.MealTypes.Where(x => x.Id == SelectedItem.Id);
                if (displayList.Count() == 0) return false;
                return true;
            }, (p) =>
            {
                try
                {
                    if(MessageBox.Show("Bạn chắc chắn muốn xóa chứ","Cảnh báo",MessageBoxButton.OKCancel,MessageBoxImage.Warning)==MessageBoxResult.OK)
                    {
                        DataProvider.Ins.DB.MealTypes.Remove(SelectedItem);
                        DataProvider.Ins.DB.SaveChanges();
                        ListGrid = new ObservableCollection<MealType>(DataProvider.Ins.DB.MealTypes);
                        SelectedItem = null;
                        DisplayName = null;
                        Note=null;
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
            ObservableCollection<MealType> filtered;
            if (String.IsNullOrEmpty(SearchContent))
            {
                filtered = new ObservableCollection<MealType>(DataProvider.Ins.DB.MealTypes);
            }
            else
            {
                if (SelectedSearchList == SearchList[0])
                {
                    int i;
                    if (Int32.TryParse(SearchContent, out i))
                    {
                        filtered = new ObservableCollection<MealType>(DataProvider.Ins.DB.MealTypes.Where(x => x.Id == i));
                    }
                    else filtered = new ObservableCollection<MealType>();
                }
                else if (SelectedSearchList == SearchList[2])
                {
                    filtered = new ObservableCollection<MealType>(DataProvider.Ins.DB.MealTypes.Where(x => x.Note.Contains(SearchContent)));
                }
                else
                {
                    filtered = new ObservableCollection<MealType>(DataProvider.Ins.DB.MealTypes.Where(x => x.DisplayName.Contains(SearchContent)));
                }
            }
            ListGrid = filtered;
        }
    }
}
