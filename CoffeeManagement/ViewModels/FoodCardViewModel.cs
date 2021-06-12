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
using System.Windows.Media.Imaging;
using MaterialDesignThemes.Wpf;

namespace CoffeeManagement.ViewModels
{
    public class FoodCardViewModel : BaseViewModel
    {
        public ICommand InitializedCommand { get; set; }
        public ICommand Btn2ClickCommand { get; set; }
        public ICommand Btn1ClickCommand { get; set; }
        public ICommand LoadCommand { get; set; }
        public ICommand SelectCommand { get; set; }
        private BitmapImage _ProductImage;
        public BitmapImage ProductImage { get => _ProductImage; set { _ProductImage = value; OnPropertyChanged(); } }
        private string _ProductName;
        public string ProductName { get => _ProductName; set { _ProductName = value; OnPropertyChanged(); } }
        private string _ProductPrice;
        public string ProductPrice { get => _ProductPrice; set { _ProductPrice = value; OnPropertyChanged(); } }
        private string _ProductAmount;
        public string ProductAmount
        {
            get => _ProductAmount;
            set
            {
                _ProductAmount = value;
                OnPropertyChanged();
                if (!String.IsNullOrEmpty(ProductAmount)) iAmount = Convert.ToInt32(ProductAmount);
                else iAmount = null;
            }
        }
        public int? iAmount;
        private string _Note;
        public string Note { get => _Note; set { _Note = value; OnPropertyChanged(); } }
        public Product mainProduct;
        public Button flip = new Button();
        public FoodCardViewModel(Product sp)
        {
            mainProduct = new Product();
            mainProduct = sp;
            LoadCommand = new RelayCommand<UserControl>((p) =>
            {
                return true;
            }, (p) =>
            {
                try
                {
                    ProductName = mainProduct.DisplayName;
                    ProductPrice = mainProduct.SellValue.ToString();
                    ProductImage = LocalDictionary.Base64ToImage(mainProduct.ProductImage);
                    flip = p.FindName("btnFlip2") as Button;
                    flip.Command = MaterialDesignThemes.Wpf.Flipper.FlipCommand;
                    //
                    //p.Uid = mainProduct.Id;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }                
            });
            SelectCommand = new RelayCommand<UserControl>((p) =>
            {
                if (String.IsNullOrEmpty(ProductAmount)) return false;
                return true;
            }, (p) =>
            {
                try
                {
                    if (Convert.ToInt32(ProductAmount) > mainProduct.CurrentQuantity || mainProduct.CurrentQuantity == null)
                        if (MessageBox.Show(String.Format("Số lượng không đủ ({0}). Bạn muốn tiếp tục chứ?", mainProduct.CurrentQuantity == null ? 0 : mainProduct.CurrentQuantity), "Cảnh báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.Cancel) return;
                    FrameworkElement window = GetWindowParent(p);
                    var w = window as Window;
                    ListView listView = w.FindName("BuyList") as ListView;
                    List<BillInfo> buyList = new List<BillInfo>((listView.DataContext as SaleViewModel).BuyListGrid);
                    BillInfo filter = buyList.Where(x => x.ProductID == mainProduct.Id).FirstOrDefault();
                    if (filter != null)
                    {
                        filter.Quantity += iAmount;
                        filter.IntoMoney = filter.Price * filter.Quantity;
                        filter.Note += Note;
                    }
                    else
                    {
                        BillInfo billInfo = new BillInfo();
                        billInfo.ProductID = mainProduct.Id;
                        billInfo.ProductName = mainProduct.DisplayName;
                        billInfo.Quantity = iAmount;
                        billInfo.Price = mainProduct.SellValue;
                        billInfo.IntoMoney = billInfo.Quantity * billInfo.Price;
                        billInfo.Note = Note;
                        billInfo.Id = buyList.Count() + 1;
                        billInfo.IsGift = false;
                        buyList.Add(billInfo);
                    }
                (listView.DataContext as SaleViewModel).BuyListGrid = new ObservableCollection<BillInfo>(buyList);
                    ProductAmount = null;
                    Note = null;
                    var thisVM = p.DataContext as FoodCardViewModel;
                    flip.Command.Execute(null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }                
            });
            Btn1ClickCommand= new RelayCommand<UserControl>((p) =>
            {
                return true;
            }, (p) =>
            {
                //if(LocalDictionary.ListString.ContainsKey(ProjectConstants.OldUCUid))
                //{
                //    FrameworkElement window = GetWindowParent(p);
                //    var w = window as Window;
                //    WrapPanel wp = w.FindName("foodList") as WrapPanel;
                //    string uid = LocalDictionary.ListString[ProjectConstants.OldUCUid];
                //    foreach (UserControl item in wp.Children)
                //    {
                //        if(item.Uid==uid)
                //        {
                //            Button btn = item.FindName("btnFlip2") as Button;
                //            btn.Command.Execute(null);
                //            break;
                //        }
                //    }
                    
                //}
                //LocalDictionary.AddToListString(ProjectConstants.OldUCUid, p.Uid);
            });
            Btn2ClickCommand = new RelayCommand<UserControl>((p) =>
            {
                return true;
            }, (p) =>
            {
                ProductAmount = null;
                Note = null;
            });
        }

        FrameworkElement GetWindowParent(UserControl p)
        {
            FrameworkElement parent = p;

            while (parent.Parent != null)
            {
                parent = parent.Parent as FrameworkElement;
            }

            return parent;
        }
    }
}
