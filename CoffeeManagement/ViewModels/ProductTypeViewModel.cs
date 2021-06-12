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
    public class ProductTypeViewModel : BaseViewModel
    {
        public ICommand ClearAllFieldCommand { get; set; }
        private ObservableCollection<MealType> _MealTypeList;
        public ObservableCollection<MealType> MealTypeList { get => _MealTypeList; set { _MealTypeList = value; OnPropertyChanged(); } }
        private MealType _SelectedMealType;
        public MealType SelectedMealType { get=> _SelectedMealType; set { _SelectedMealType = value;OnPropertyChanged(); } }
        #region Property chung
        public ICommand LoadCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand AddCommand { get; set; }
        private string _DisplayName;
        public string DisplayName { get => _DisplayName; set { _DisplayName = value; OnPropertyChanged(); } }
        private string _Note;
        public string Note { get => _Note; set { _Note = value; OnPropertyChanged(); } }
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
        private ProductType _SelectedItem;
        public ProductType SelectedItem
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
                    SelectedMealType = SelectedItem.MealType;
                }
                else
                {
                    DisplayName = null;
                    SelectedMealType = null;
                    Note = null;
                }
            }
        }
        private ObservableCollection<ProductType> _ListGrid;
        public ObservableCollection<ProductType> ListGrid { get => _ListGrid; set { _ListGrid = value; OnPropertyChanged(); } }
        private List<string> _SearchList;
        public List<string> SearchList { get => _SearchList; set { _SearchList = value; OnPropertyChanged(); } }
        private void InitSearchList()
        {
            SearchList = new List<string>();
            SearchList.Add("Mã nhóm hàng");
            SearchList.Add("Tên nhóm hàng");
            SearchList.Add("Mã thực đơn");
            SearchList.Add("Tên thực đơn");
            SearchList.Add("Ghi chú");
        }
        #endregion
        public ProductTypeViewModel()
        {
            LoadCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                try
                {
                    InitSearchList();
                    ListGrid = new ObservableCollection<ProductType>(DataProvider.Ins.DB.ProductTypes);
                    MealTypeList = new ObservableCollection<MealType>(DataProvider.Ins.DB.MealTypes);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            });
            
            AddCommand = new RelayCommand<object>((p) =>
            {
                if (String.IsNullOrEmpty(DisplayName) || SelectedMealType == null) return false;
                var displayList = DataProvider.Ins.DB.ProductTypes.Where(x => x.DisplayName == DisplayName && x.MealTypeID == SelectedMealType.Id);
                if (displayList.Count() != 0) return false;
                return true;
            }, (p) =>
            {
                try
                {
                    ProductType productType = new ProductType();
                    productType.DisplayName = DisplayName;
                    productType.MealTypeID = SelectedMealType.Id;
                    productType.Note = Note;
                    DataProvider.Ins.DB.ProductTypes.Add(productType);
                    DataProvider.Ins.DB.SaveChanges();
                    ListGrid = new ObservableCollection<ProductType>(DataProvider.Ins.DB.ProductTypes);
                    SelectedItem = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            });
            EditCommand = new RelayCommand<object>((p) =>
            {
                if (String.IsNullOrEmpty(DisplayName) || SelectedItem == null || SelectedMealType == null) return false;
                var displayList = DataProvider.Ins.DB.ProductTypes.Where(x => x.DisplayName == DisplayName && x.Note == Note && x.MealTypeID == SelectedMealType.Id);
                if (displayList.Count() > 0) return false;
                return true;
            }, (p) =>
            {
                try
                {
                    var productType = DataProvider.Ins.DB.ProductTypes.Where(x => x.Id == SelectedItem.Id).FirstOrDefault();
                    productType.DisplayName = DisplayName;
                    productType.MealTypeID = SelectedMealType.Id;
                    productType.Note = Note;
                    DataProvider.Ins.DB.SaveChanges();
                    ListGrid = new ObservableCollection<ProductType>(DataProvider.Ins.DB.ProductTypes);
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
                var displayList = DataProvider.Ins.DB.ProductTypes.Where(x => x.Id == SelectedItem.Id);
                if (displayList.Count() == 0) return false;
                return true;
            }, (p) =>
            {
                try
                {
                    if (MessageBox.Show("Bạn chắc chắn muốn xóa chứ", "Cảnh báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    {
                        DataProvider.Ins.DB.ProductTypes.Remove(SelectedItem);
                        DataProvider.Ins.DB.SaveChanges();
                        ListGrid = new ObservableCollection<ProductType>(DataProvider.Ins.DB.ProductTypes);
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
            ObservableCollection<ProductType> filtered;            
            if (String.IsNullOrEmpty(SearchContent))
            {
                filtered = new ObservableCollection<ProductType>(DataProvider.Ins.DB.ProductTypes);
            }
            else
            {                
                if (SelectedSearchList == SearchList[0]) //mã nhóm hàng
                {
                    int i;
                    if (Int32.TryParse(SearchContent, out i))
                    {
                        filtered = new ObservableCollection<ProductType>(DataProvider.Ins.DB.ProductTypes.Where(x => x.Id == i));
                    }
                    else filtered = new ObservableCollection<ProductType>();
                }
                else if (SelectedSearchList == SearchList[2]) //mã thực đơn
                {
                    int i;
                    if (Int32.TryParse(SearchContent, out i))
                    {
                        filtered = new ObservableCollection<ProductType>(DataProvider.Ins.DB.ProductTypes.Where(x => x.MealTypeID == i));
                    }
                    else filtered = new ObservableCollection<ProductType>();
                }
                else if (SelectedSearchList == SearchList[3]) //tên thực đơn
                {
                   filtered = new ObservableCollection<ProductType>();
                    List<MealType> listMeal = new List<MealType>(DataProvider.Ins.DB.MealTypes.Where(x => x.DisplayName.Contains(SearchContent)));
                    foreach (MealType item in listMeal)
                    {
                        ObservableCollection<ProductType> sublist = new ObservableCollection<ProductType>(DataProvider.Ins.DB.ProductTypes.Where(x => x.MealTypeID == item.Id));
                        foreach (var item1 in sublist)
                        {
                            filtered.Add(item1);
                        }                        
                    }
                }
                else if (SelectedSearchList == SearchList[4]) //ghi chú
                {
                    filtered = new ObservableCollection<ProductType>(DataProvider.Ins.DB.ProductTypes.Where(x => x.Note.Contains(SearchContent)));
                }
                else //tên nhóm hang
                {
                    filtered = new ObservableCollection<ProductType>(DataProvider.Ins.DB.ProductTypes.Where(x => x.DisplayName.Contains(SearchContent)));
                }
            }
            ListGrid = filtered;
        }
    }
}
