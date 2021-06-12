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

namespace CoffeeManagement.ViewModels
{
    public class ProductsViewModel : BaseViewModel
    {        
        public ICommand DoubleClickListViewCommand { get; set; }
        public ICommand ProductTypeCommand { get; set; }
        public ICommand MealTypeCommand { get; set; }
        public ICommand RadioButtonCommand { get; set; }
        public ICommand LoadCommand { get; set; }
        #region Property chung
        public ICommand DeleteCommand { get; set; }
        public ICommand AddCommand { get; set; }
        private string _DisplayName;
        public string DisplayName { get => _DisplayName; set { _DisplayName = value; OnPropertyChanged(); } }
        private string _Note;
        public string Note { get => _Note; set { _Note = value; OnPropertyChanged(); } }
        private string _SelectedSearchList;
        public string SelectedSearchList
        {
            get => _SelectedSearchList;
            set
            {
                _SelectedSearchList = value; OnPropertyChanged(); Search(SelectedSearchList, SearchContent);
            }
        }
        private string _SearchContent;
        public string SearchContent
        {
            get => _SearchContent;
            set
            {
                _SearchContent = value; OnPropertyChanged(); Search(SelectedSearchList, SearchContent);
            }
        }
        private Product _SelectedItem;
        public Product SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();           
                
            }
        }
        private ObservableCollection<Product> _ListGrid;
        public ObservableCollection<Product> ListGrid { get => _ListGrid; set { _ListGrid = value; OnPropertyChanged(); } }
        private List<string> _SearchList;
        public List<string> SearchList { get => _SearchList; set { _SearchList = value; OnPropertyChanged(); } }
        private void InitSearchList()
        {
            SearchList = new List<string>();
            SearchList.Add("Mã hàng hóa");
            SearchList.Add("Tên hàng hóa");
            SearchList.Add("Giá bán");
        }
        #endregion
        private List<MealType> _listMealTypes;
        public List<MealType> listMealTypes  { get=> _listMealTypes; set { _listMealTypes = value;OnPropertyChanged(); } }
        List<CheckBox> _mealTypeListCB;
        public List<CheckBox> mealTypeListCB { get=> _mealTypeListCB; set { _mealTypeListCB = value;OnPropertyChanged(); } }
        List<ProductType> _listProductTypes;
        public List<ProductType> listProductTypes { get=> _listProductTypes; set { _listProductTypes = value;OnPropertyChanged(); } }
        List<CheckBox> _productTypeListCB;
        public List<CheckBox> productTypeListCB { get=> _productTypeListCB; set { _productTypeListCB = value;OnPropertyChanged(); } }
        private List<Product> _sourceData;
        public List<Product> sourceData { get => _sourceData;set { _sourceData = value;OnPropertyChanged(); } }
        private void InitData()
        {
            listMealTypes = new List<MealType>(DataProvider.Ins.DB.MealTypes);
            mealTypeListCB = new List<CheckBox>();
            listProductTypes = new List<ProductType>(DataProvider.Ins.DB.ProductTypes);
            productTypeListCB = new List<CheckBox>();
            sourceData = new List<Product>(DataProvider.Ins.DB.Products);
        }
        public ProductsViewModel()
        {           
            
            LoadCommand = new RelayCommand<UserControl>((p) =>
            {
                return true;
            }, (p) =>
            {
                try
                {
                    InitData();
                    InitSearchList();
                    ListGrid = new ObservableCollection<Product>(sourceData);
                    LocalDictionary.AddItemToProductMap(ProjectConstants.ListProductBeforeSort, sourceData);
                    //1. check 2 checkboxs all
                    CheckBox allMealType = (CheckBox)p.FindName("allMealType");
                    allMealType.IsChecked = true;
                    allMealType.Tag = null;
                    mealTypeListCB.Add(allMealType);
                    CheckBox allProductType = (CheckBox)p.FindName("allProductType");
                    allProductType.IsChecked = true;
                    allProductType.Tag = null;
                    productTypeListCB.Add(allProductType);
                    //2. Load list checkbox mealtype
                    StackPanel mealTypeSp = (StackPanel)p.FindName("mealTypeSP");
                    foreach (var item in listMealTypes)
                    {
                        CheckBox checkBox = new CheckBox();
                        checkBox.Tag = item;///////////////
                        checkBox.Content = item.DisplayName;
                        checkBox.Command = MealTypeCommand;
                        checkBox.CommandParameter = checkBox;
                        mealTypeListCB.Add(checkBox);
                        mealTypeSp.Children.Add(checkBox);
                    }
                    //3. Load list checkbox producttype
                    StackPanel productTypeSP = (StackPanel)p.FindName("proTypeSP");
                    foreach (var item in listProductTypes)
                    {
                        CheckBox checkBox = new CheckBox();
                        checkBox.Tag = item;///////////////
                        checkBox.Content = item.DisplayName;
                        checkBox.Command = ProductTypeCommand;
                        checkBox.CommandParameter = checkBox;
                        productTypeListCB.Add(checkBox);
                        productTypeSP.Children.Add(checkBox);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            });
            RadioButtonCommand = new RelayCommand<RadioButton>((p) =>
            {
                return true;
            }, (p) =>
            {
                try
                {

                    StackPanel panel = p.Parent as StackPanel;
                    List<Product> sortList = new List<Product>(ListGrid);
                    switch (panel.Name)
                    {
                        case "buyValueSP":
                            if (p.Name == "AscBuyValue") sortList = ListGrid.OrderBy(i => i.BuyValue).ToList();
                            else if (p.Name == "DecBuyValue") sortList = ListGrid.OrderByDescending(i => i.BuyValue).ToList();
                            else
                            {
                                sortList = LocalDictionary.ProductMap[ProjectConstants.ListProductBeforeSort];
                            }
                            break;
                        case "sellValueSP":
                            if (p.Name == "AscSellValue") sortList = ListGrid.OrderBy(i => i.SellValue).ToList();
                            else if (p.Name == "DecSellValue") sortList = ListGrid.OrderByDescending(i => i.SellValue).ToList();
                            else
                            {
                                sortList = LocalDictionary.ProductMap[ProjectConstants.ListProductBeforeSort];
                            }
                            break;
                        case "wareHouse":
                            if (p.Name == "MaxWH") sortList = ListGrid.OrderByDescending(i => i.CurrentQuantity).ToList();
                            if (p.Name == "MinWH") sortList = ListGrid.OrderBy(i => i.CurrentQuantity).ToList();
                            else
                            {
                                sortList = LocalDictionary.ProductMap[ProjectConstants.ListProductBeforeSort];
                            }
                            break;
                        case "Trade":
                            sortList = LocalDictionary.ProductMap[ProjectConstants.ListProductBeforeSort];
                            if (p.Name == "TradingState") sortList = sortList.Where(i => i.IsTrading == true).ToList();
                            if (p.Name == "NotTradingState") sortList = sortList.Where(i => i.IsTrading == false).ToList();
                            break;
                        default:
                            break;
                    }
                    ListGrid = new ObservableCollection<Product>(sortList);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            });

            MealTypeCommand = new RelayCommand<CheckBox>((p) =>
            {
                return true;
            }, (p) =>
            {
                try
                {
                    if (p.Tag == null && p.IsChecked == true)
                    {
                        foreach (var item in mealTypeListCB)
                        {
                            if (item != mealTypeListCB[0])
                                item.IsChecked = false;
                        }
                    }
                    else
                    {
                        mealTypeListCB[0].IsChecked = false;
                    }
                    MealTypeFilter();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            });


            ProductTypeCommand = new RelayCommand<CheckBox>((p) =>
            {
                return true;
            }, (p) =>
            {
                try
                {
                    if (p.Tag == null && p.IsChecked == true)
                    {
                        foreach (var item in productTypeListCB)
                        {
                            if (item != productTypeListCB[0])
                                item.IsChecked = false;
                        }
                    }
                    else
                    {
                        productTypeListCB[0].IsChecked = false;
                    }
                    ProductTypeFilter();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            });

            DoubleClickListViewCommand = new RelayCommand<object>((p) =>
             {
                 if (SelectedItem == null) return false;
                 return true;
             }, (p) =>
             {
                 try
                 {
                     LocalDictionary.AddItemToSmallProductMap(ProjectConstants.ProductSelectedItem, SelectedItem);
                     Window window = new ProductDetail();
                     window.ShowDialog();
                     if (window.IsActive == false) ListGrid = new ObservableCollection<Product>(DataProvider.Ins.DB.Products);
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show(ex.ToString());
                 }
             });

            AddCommand = new RelayCommand<object>((p) =>
             {
                 return true;
             }, (p) =>
             {
                 try
                 {
                     LocalDictionary.AddItemToSmallProductMap(ProjectConstants.ProductSelectedItem, null);
                     Window window = new ProductDetail();
                     window.ShowDialog();
                     if (window.IsActive == false)
                     {
                         sourceData = DataProvider.Ins.DB.Products.ToList();
                         ListGrid = new ObservableCollection<Product>(sourceData);
                     }
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show(ex.ToString());
                 }
             });

            DeleteCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null) return false;
                var displayList = sourceData.Where(x => x.Id == SelectedItem.Id);
                if (displayList.Count() == 0) return false;
                return true;
            }, (p) =>
            {
                try
                {
                    if (MessageBox.Show("Bạn chắc chắn muốn xóa chứ", "Cảnh báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    {
                        DataProvider.Ins.DB.Products.Remove(SelectedItem);
                        DataProvider.Ins.DB.SaveChanges();
                        sourceData = DataProvider.Ins.DB.Products.ToList();
                        ListGrid.Remove(SelectedItem);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            });
        }


        private void ProductTypeFilter()
        {
            try
            {
                List<Product> filterData = new List<Product>();
                foreach (var item in productTypeListCB)
                {
                    CheckBox checkBox = item as CheckBox;
                    if (checkBox.IsChecked == true)
                    {
                        if (checkBox.Tag == null)
                        {
                            filterData = sourceData;
                            break;
                        }
                        else
                        {
                            int id = (checkBox.Tag as ProductType).Id;
                            List<Product> listProduct = sourceData.Where(x => x.ProductTypeID == id).ToList();
                            foreach (var item1 in listProduct)
                            {
                                filterData.Add(item1);
                            }
                        }
                    }
                }
                ListGrid = new ObservableCollection<Product>(filterData);
                if (LocalDictionary.ProductMap.ContainsKey("ListProductBeforeSort"))
                {
                    LocalDictionary.ProductMap.Remove("ListProductBeforeSort");
                    LocalDictionary.ProductMap.Add(ProjectConstants.ListProductBeforeSort, filterData);
                }
                else LocalDictionary.ProductMap.Add(ProjectConstants.ListProductBeforeSort, filterData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void MealTypeFilter()
        {
            try
            {
                List<Product> filterData = new List<Product>();
                foreach (var item in mealTypeListCB)
                {
                    CheckBox checkBox = item as CheckBox;
                    if (checkBox.IsChecked == true)
                    {
                        if (checkBox.Tag == null)
                        {
                            filterData = sourceData;
                            break;
                        }
                        else
                        {
                            int id = (checkBox.Tag as MealType).Id;
                            List<ProductType> listPT = new List<ProductType>(listProductTypes.Where(x => x.MealTypeID == id));
                            foreach (var item1 in listPT)
                            {
                                List<Product> products = sourceData.Where(x => x.ProductTypeID == item1.Id).ToList();
                                foreach (var item2 in products)
                                {
                                    filterData.Add(item2);
                                }
                            }
                        }
                    }
                }
                ListGrid = new ObservableCollection<Product>(filterData);
                if (LocalDictionary.ProductMap.ContainsKey("ListProductBeforeSort"))
                {
                    LocalDictionary.ProductMap.Remove("ListProductBeforeSort");
                    LocalDictionary.ProductMap.Add(ProjectConstants.ListProductBeforeSort, filterData);
                }
                else LocalDictionary.ProductMap.Add(ProjectConstants.ListProductBeforeSort, filterData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        private void Search(string SelectedSearchList, string SearchContent)
        {
            List<Product> filtered = new List<Product>();
            if (String.IsNullOrEmpty(SearchContent))
            {
                filtered = sourceData;
            }
            else
            {
                SearchContent = SearchContent.ToLower();
                if (SelectedSearchList == SearchList[0]) //mã nhóm hàng
                {
                    filtered = sourceData.Where(x => x.Id.ToLower().Contains(SearchContent)).ToList();
                }
                else if (SelectedSearchList == SearchList[2]) //gia ban
                {
                    filtered = sourceData.Where(x => x.SellValue.ToString().Contains(SearchContent)).ToList();
                }
                else //tên hang
                {
                    filtered = sourceData.Where(x => x.DisplayName.ToLower().Contains(SearchContent)).ToList();
                }
            }
            if(filtered!=null) ListGrid = new ObservableCollection<Product>(filtered);
        }
        //get list children

        //public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        //{
        //    if (depObj != null)
        //    {
        //        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
        //        {
        //            DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
        //            if (child != null && child is T)
        //            {
        //                yield return (T)child;
        //            }

        //            foreach (T childOfChild in FindVisualChildren<T>(child))
        //            {
        //                yield return childOfChild;
        //            }
        //        }
        //    }
        //}
        //use
        //foreach (RadioButton tb in FindVisualChildren<RadioButton>(p))
        //{}
       
    }
}
