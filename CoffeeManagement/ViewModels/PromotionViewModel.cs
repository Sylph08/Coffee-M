using CoffeeManagement.Models;
using MaterialDesignThemes.Wpf;
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
    public class PromotionViewModel : BaseViewModel
    {
        public ICommand KeyUpCommand { get; set; }
        public ICommand ClearAllFieldCommand { get; set; }
        public ICommand LoadCommand { get; set; }
        public ICommand AddProductCommand { get; set; }
        public ICommand EditProductCommand { get; set; }
        public ICommand DeleteProductCommand { get; set; }
        public ICommand AddPromotionCommand { get; set; }
        public ICommand EditPromotionCommand { get; set; }
        public ICommand DeletePromotionCommand { get; set; }
        private bool _CheckRBProductType;
        public bool CheckRBProductType
        {
            get => _CheckRBProductType;
            set
            {
                _CheckRBProductType = value;
                OnPropertyChanged();
                if (CheckRBProductType == true)
                {
                    SelectedProductResultList = null;
                }
            }
        }
        private bool _CheckRBProduct;
        public bool CheckRBProduct
        {
            get => _CheckRBProduct;
            set
            {
                _CheckRBProduct = value;
                OnPropertyChanged();
                if (CheckRBProductType == true)
                {
                    SelectedProductTypeResultList = null;
                }
            }
        }
        private List<SimpleType> _ListPromotionType;
        public List<SimpleType> ListPromotionType { get => _ListPromotionType; set { _ListPromotionType = value; OnPropertyChanged(); } }
        private SimpleType _SelectedPromotionType;
        public SimpleType SelectedPromotionType
        {
            get => _SelectedPromotionType;
            set
            {
                _SelectedPromotionType = value;
                OnPropertyChanged();
                EnableControls();
                if (SelectedPromotionType != null)
                    switch (SelectedPromotionType.Id)
                    {
                        case 1:
                            (thisControl.FindName("txbAmountValue") as TextBox).IsEnabled = false;
                            (thisControl.FindName("txbPriceBillRequire") as TextBox).IsEnabled = false;
                            (thisControl.FindName("cardProduct") as Grid).IsEnabled = false;
                            break;
                        case 2:
                            (thisControl.FindName("txbAmountValue") as TextBox).IsEnabled = false;
                            (thisControl.FindName("txbPriceBillRequire") as TextBox).IsEnabled = false;
                            (thisControl.FindName("txbPercentValue") as TextBox).IsEnabled = false;
                            (thisControl.FindName("rbProductType") as RadioButton).IsEnabled = false;
                            (thisControl.FindName("rbProduct") as RadioButton).IsChecked = true;
                            break;
                        case 3:
                            (thisControl.FindName("gbProductGift") as GroupBox).IsEnabled = false;
                            (thisControl.FindName("txbPriceBillRequire") as TextBox).IsEnabled = false;
                            (thisControl.FindName("txbPercentValue") as TextBox).IsEnabled = false;
                            SelectedProductType = ProductTypeList[0];
                            (thisControl.FindName("cbProductType") as ComboBox).IsEnabled = false;
                            ListGridProductType0 = new ObservableCollection<ProductApplyForPromotion>();
                            break;
                        case 4:
                            (thisControl.FindName("cardProduct") as Grid).IsEnabled = false;
                            (thisControl.FindName("txbAmountValue") as TextBox).IsEnabled = false;
                            break;
                        case 5:
                            (thisControl.FindName("txbPriceBillRequire") as TextBox).IsEnabled = false;
                            (thisControl.FindName("gbProductGift") as GroupBox).IsEnabled = false;
                            SelectedProductType = ProductTypeList[0];
                            (thisControl.FindName("cbProductType") as ComboBox).IsEnabled = false;
                            ListGridProductType0 = new ObservableCollection<ProductApplyForPromotion>();
                            break;
                        default:
                            break;
                    }
            }
        }
        private string _PromotionIdStable;
        public string PromotionIdStable
        {
            get => _PromotionIdStable;
            set
            {
                _PromotionIdStable = value;
                OnPropertyChanged();
                if (SelectedPromotionType != null)
                {
                    switch (SelectedPromotionType.Id)
                    {
                        case 1:
                        case 4:
                            PromotionIdChangable = null;
                            break;
                        case 2:
                        case 3:
                        case 5:
                            PromotionIdChangable = PromotionIdStable;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    PromotionIdChangable = null;
                }
            }
        }
        private string _DisplayName;
        public string DisplayName { get => _DisplayName; set { _DisplayName = value; OnPropertyChanged(); } }
        private DateTime? _FromDate;
        public DateTime? FromDate
        {
            get => _FromDate;
            set
            {
                _FromDate = value;
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
        private string _AmountValue;
        public string AmountValue
        {
            get => _AmountValue;
            set
            {
                try
                {
                    _AmountValue = value;
                    OnPropertyChanged();
                    if (!String.IsNullOrEmpty(AmountValue)) iAmountValue = Convert.ToInt32(AmountValue);
                    else iAmountValue = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        public int? iAmountValue;
        private string _PercentValue;
        public string PercentValue
        {
            get => _PercentValue;
            set
            {
                _PercentValue = value;
                OnPropertyChanged();
                if (String.IsNullOrEmpty(PercentValue) == false && LocalDictionary.CheckIsDoubleType(PercentValue))
                {
                    dPercentValue = Convert.ToDouble(PercentValue);
                }
                else dPercentValue = null;
            }
        }
        public double? dPercentValue;
        private string _PriceBillRequire;
        public string PriceBillRequire { get => _PriceBillRequire; set { _PriceBillRequire = value; OnPropertyChanged(); iPriceBillRequire = String.IsNullOrEmpty(PriceBillRequire) ? (int?)null : Convert.ToInt32(PriceBillRequire); } }
        public int? iPriceBillRequire;
        private List<State> _StateList;
        public List<State> StateList { get => _StateList; set { _StateList = value; OnPropertyChanged(); } }
        private State _SelectedState;
        public State SelectedState { get => _SelectedState; set { _SelectedState = value; OnPropertyChanged(); } }
        private string _Note;
        public string Note { get => _Note; set { _Note = value; OnPropertyChanged(); } }
        private List<string> _SearchList;
        public List<string> SearchList { get => _SearchList; set { _SearchList = value; OnPropertyChanged(); } }
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
        private ObservableCollection<Promotion> _ListGridPromotion;
        public ObservableCollection<Promotion> ListGridPromotion { get => _ListGridPromotion; set { _ListGridPromotion = value; OnPropertyChanged(); } }
        private Promotion _SelectedPromotionItem;
        public Promotion SelectedPromotionItem
        {
            get => _SelectedPromotionItem;
            set
            {
                try
                {
                    _SelectedPromotionItem = value;
                    OnPropertyChanged();
                    if (SelectedPromotionItem != null)
                    {
                        SelectedPromotionType = ListPromotionType.Where(x => x.Id == SelectedPromotionItem.PromotionType).FirstOrDefault();
                        DisplayName = SelectedPromotionItem.DisplayName;
                        PromotionIdStable = SelectedPromotionItem.Id;
                        txtFromDate = SelectedPromotionItem.FromDate.ToString();
                        txtToDate = SelectedPromotionItem.ToDate.ToString();
                        AmountValue = SelectedPromotionItem.AmountValue.ToString();
                        PercentValue = SelectedPromotionItem.PercentValue.ToString();
                        PriceBillRequire = SelectedPromotionItem.PriceBillRequire.ToString();
                        SelectedState = SelectedPromotionItem.IsApply == true ? StateList[0] : StateList[1];
                        Note = SelectedPromotionItem.Note;
                        initCombineList = new List<ProductApplyForPromotion>(DataProvider.Ins.DB.ProductApplyForPromotions.Where(x => x.PromotionId == PromotionIdStable));
                        ListGridProductType1 = new ObservableCollection<ProductApplyForPromotion>(initCombineList.Where(x => x.ProductType == true));
                        ListGridProductType0 = new ObservableCollection<ProductApplyForPromotion>(initCombineList.Where(x => x.ProductType == false));
                        (thisControl.FindName("txbPromotionId") as TextBox).IsEnabled = false;
                        (thisControl.FindName("cbPromotionType") as ComboBox).IsEnabled = false;
                    }
                    else
                    {
                        SelectedPromotionType = null;
                        DisplayName = null;
                        PromotionIdStable = null;
                        txtFromDate = null;
                        txtToDate = null;
                        AmountValue = null;
                        PercentValue = null;
                        PriceBillRequire = null;
                        SelectedState = null;
                        Note = null;
                        ListGridProductType1 = new ObservableCollection<ProductApplyForPromotion>();
                        ListGridProductType0 = new ObservableCollection<ProductApplyForPromotion>();
                        (thisControl.FindName("txbPromotionId") as TextBox).IsEnabled = true;
                        (thisControl.FindName("cbPromotionType") as ComboBox).IsEnabled = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        //----------------------------------------------------------------------------------------
        private ObservableCollection<Product> _ProductResultList;
        public ObservableCollection<Product> ProductResultList
        {
            get => _ProductResultList;
            set
            {
                _ProductResultList = value;
                OnPropertyChanged();
                if (ProductResultList != null)
                    SelectedProductResultList = ProductResultList.FirstOrDefault();
                else SelectedProductResultList = null;
            }
        }
        private Product _SelectedProductResultList;
        public Product SelectedProductResultList { get => _SelectedProductResultList; set { _SelectedProductResultList = value; OnPropertyChanged(); } }
        private ObservableCollection<ProductType> _ProductTypeResultList;
        public ObservableCollection<ProductType> ProductTypeResultList { get => _ProductTypeResultList; set { _ProductTypeResultList = value; OnPropertyChanged(); } }
        private ProductType _SelectedProductTypeResultList;
        public ProductType SelectedProductTypeResultList { get => _SelectedProductTypeResultList; set { _SelectedProductTypeResultList = value; OnPropertyChanged(); } }
        private string _PPDisplayName;
        public string PPDisplayName { get => _PPDisplayName; set { _PPDisplayName = value; OnPropertyChanged(); } }
        private string _ProductAmount;
        public string ProductAmount { get => _ProductAmount; set { _ProductAmount = value; OnPropertyChanged(); iProductAmount = String.IsNullOrEmpty(ProductAmount) ? 1 : Convert.ToInt32(ProductAmount); } }//thay (int?)null = 1
        public int? iProductAmount;
        private string _PromotionIdChangable;
        public string PromotionIdChangable { get => _PromotionIdChangable; set { _PromotionIdChangable = value; OnPropertyChanged(); } }
        private List<State> _ProductTypeList;
        public List<State> ProductTypeList { get => _ProductTypeList; set { _ProductTypeList = value; OnPropertyChanged(); } }
        private State _SelectedProductType;
        public State SelectedProductType { get => _SelectedProductType; set { _SelectedProductType = value; OnPropertyChanged(); } }
        private ObservableCollection<ProductApplyForPromotion> _ListGridProductType1;
        public ObservableCollection<ProductApplyForPromotion> ListGridProductType1
        {
            get => _ListGridProductType1;
            set
            {
                try
                {
                    _ListGridProductType1 = value;
                    OnPropertyChanged();
                    if (combineTwoGrid != null) combineTwoGrid.RemoveAll(x => x.ProductType == true);
                    if (ListGridProductType1 != null)
                    {
                        foreach (var item in ListGridProductType1)
                        {
                            ProductApplyForPromotion pa = new ProductApplyForPromotion();
                            pa.ProductId = item.ProductId;
                            pa.PPDisplayName = item.PPDisplayName;
                            pa.ProductAmount = item.ProductAmount;
                            pa.PromotionId = PromotionIdStable;
                            pa.ProductType = item.ProductType;
                            combineTwoGrid.Add(pa);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        private ProductApplyForPromotion _SelectedProductType1Item;
        public ProductApplyForPromotion SelectedProductType1Item
        {
            get => _SelectedProductType1Item;
            set
            {
                try
                {
                    _SelectedProductType1Item = value;
                    OnPropertyChanged();
                    if (SelectedProductType1Item != null)
                    {
                        SelectedProductType0Item = null;
                        if (CheckRBProduct == false) CheckRBProduct = true;
                        SelectedProductResultList = allProducts.Where(x => x.Id == SelectedProductType1Item.ProductId).FirstOrDefault();
                        ProductAmount = SelectedProductType1Item.ProductAmount.ToString();
                        PromotionIdChangable = SelectedProductType1Item.PromotionId;
                        SelectedProductType = ProductTypeList[0];
                    }
                    else
                    {
                        SelectedProductResultList = null;
                        if (CheckRBProduct == true) CheckRBProduct = false;
                        ProductAmount = null;
                        PromotionIdChangable = null;
                        if (SelectedPromotionType != null)
                        {
                            if (SelectedPromotionType.Id != 3 && SelectedPromotionType.Id != 5)
                            {
                                SelectedProductType = null;
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        private ObservableCollection<ProductApplyForPromotion> _ListGridProductType0;
        public ObservableCollection<ProductApplyForPromotion> ListGridProductType0
        {
            get => _ListGridProductType0;
            set
            {
                _ListGridProductType0 = value;
                OnPropertyChanged();
                if (combineTwoGrid != null) combineTwoGrid.RemoveAll(x => x.ProductType == false);
                if (ListGridProductType0 != null)
                {
                    foreach (var item in ListGridProductType0)
                    {
                        ProductApplyForPromotion pa = new ProductApplyForPromotion();
                        pa.ProductId = item.ProductId;
                        pa.PPDisplayName = item.PPDisplayName;
                        pa.ProductAmount = item.ProductAmount;
                        pa.PromotionId = PromotionIdStable;
                        pa.ProductType = item.ProductType;
                        combineTwoGrid.Add(pa);
                    }
                }
            }
        }
        private ProductApplyForPromotion _SelectedProductType0Item;
        public ProductApplyForPromotion SelectedProductType0Item
        {
            get => _SelectedProductType0Item;
            set
            {
                try
                {
                    _SelectedProductType0Item = value;
                    OnPropertyChanged();
                    if (SelectedProductType0Item != null)
                    {
                        SelectedProductType1Item = null;
                        if (CheckRBProduct == false) CheckRBProduct = true;
                        ProductResultList = new ObservableCollection<Product>(allProducts.Where(x => x.Id == SelectedProductType0Item.ProductId));
                        ProductAmount = SelectedProductType0Item.ProductAmount.ToString();
                        PromotionIdChangable = SelectedProductType0Item.PromotionId;
                        SelectedProductType = ProductTypeList[1];
                    }
                    else
                    {
                        SelectedProductResultList = null;
                        if (CheckRBProduct == true) CheckRBProduct = false;
                        ProductAmount = null;
                        PromotionIdChangable = null;
                        if (SelectedPromotionType != null)
                        {
                            if (SelectedPromotionType.Id != 3 && SelectedPromotionType.Id != 5) SelectedProductType = null;
                        }

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        //---------------------------------------------------------------------------------------
        public UserControl _thisControl;
        public UserControl thisControl { get => _thisControl; set { _thisControl = value; } }
        public List<Product> allProducts;
        private List<ProductApplyForPromotion> _combineTwoGrid;
        public List<ProductApplyForPromotion> combineTwoGrid { get => _combineTwoGrid; set { _combineTwoGrid = value; } }
        private List<ProductApplyForPromotion> _initCombineList;
        public List<ProductApplyForPromotion> initCombineList { get => _initCombineList; set { _initCombineList = value; } }
        public PromotionViewModel(/*bool ShowOnly*/)
        {
            LoadCommand = new RelayCommand<UserControl>((p) =>
            {
                return true;
            }, (p) =>
            {
                try
                {
                    InitData();

                    thisControl = new UserControl();
                    thisControl = p;

                    SelectedPromotionItem = null;
                    SelectedProductType0Item = null;
                    SelectedProductType1Item = null;

                    if (LocalDictionary.ListBools.ContainsKey(ProjectConstants.IsCalledFromSaleWindow) && LocalDictionary.ListBools[ProjectConstants.IsCalledFromSaleWindow])
                    {
                        ListGridPromotion = new ObservableCollection<Promotion>(DataProvider.Ins.DB.Promotions.Where(x => x.IsApply == true));
                        (thisControl.FindName("Item1") as Card).IsEnabled = false;
                        (thisControl.FindName("Item2") as Card).IsEnabled = false;
                        (thisControl.FindName("Item3") as Card).IsEnabled = false;
                        (thisControl.FindName("Item4") as WrapPanel).IsEnabled = false;
                        (thisControl.FindName("Item5") as StackPanel).IsEnabled = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            });
            KeyUpCommand = new RelayCommand<ComboBox>((p) =>
            {
                return true;
            }, (p) =>
            {
                try
                {
                    string input = p.Text.ToLower();
                    p.IsDropDownOpen = true;
                    if (String.IsNullOrEmpty(input)) ProductResultList = new ObservableCollection<Product>(allProducts);
                    else ProductResultList = new ObservableCollection<Product>(allProducts.Where(x => x.DisplayName.ToLower().Contains(input)));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            });

            ClearAllFieldCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                try
                {
                    SelectedPromotionItem = null;
                    SelectedProductType1Item = null;
                    SelectedProductType0Item = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            });
            #region PromotionCommand

            AddPromotionCommand = new RelayCommand<object>((p) =>
             {
                 if (SelectedPromotionType == null || String.IsNullOrEmpty(PromotionIdStable) || String.IsNullOrEmpty(DisplayName) || String.IsNullOrEmpty(txtFromDate)
                 || String.IsNullOrEmpty(txtToDate) || SelectedState == null) return false;
                 if (SelectedPromotionType.Id == 1)
                 {
                     if (String.IsNullOrEmpty(PercentValue)) return false;
                 }
                 if (SelectedPromotionType.Id == 2)
                 {
                     if (ListGridProductType1.Count == 0 || ListGridProductType0.Count == 0) return false;
                 }
                 if (SelectedPromotionType.Id == 3)
                 {
                     if (String.IsNullOrEmpty(AmountValue) || ListGridProductType1.Count == 0) return false;
                 }
                 if (SelectedPromotionType.Id == 4)
                 {
                     if (String.IsNullOrEmpty(PriceBillRequire) || String.IsNullOrEmpty(PercentValue)) return false;
                     if (DataProvider.Ins.DB.Promotions.Where(x => x.PromotionType == 4 && x.PriceBillRequire == iPriceBillRequire).Count() > 0) return false;
                 }
                 if (SelectedPromotionType.Id == 5)
                 {
                     if (String.IsNullOrEmpty(PercentValue + AmountValue) || ListGridProductType1.Count == 0) return false;
                     if (!String.IsNullOrEmpty(PercentValue) && !String.IsNullOrEmpty(AmountValue)) return false;
                 }
                 var displayList = DataProvider.Ins.DB.Promotions.Where(x => x.Id == PromotionIdStable);
                 if (displayList.Count() > 0) return false;
                 return true;
             }, (p) =>
             {
                 try
                 {
                     if (DateTime.Compare((DateTime)ToDate, (DateTime)FromDate) < 0)
                     {
                         MessageBox.Show("Chú ý! Ngày kết thúc phải lớn hơn ngày bắt đầu!");
                         txtToDate = null;
                     }
                     else if (DateTime.Compare((DateTime)ToDate, System.DateTime.Now) < 0)
                     {
                         MessageBox.Show("Ngày kết thúc phải lớn hơn ngày hiện tại!");
                         txtToDate = null;
                     }
                     else if (LocalDictionary.CheckIsDoubleType(PercentValue))
                     {
                         Promotion promotion = new Promotion();
                         promotion.Id = PromotionIdStable;
                         promotion.DisplayName = DisplayName;
                         promotion.FromDate = FromDate;
                         promotion.ToDate = ToDate;
                         promotion.AmountValue = String.IsNullOrEmpty(AmountValue) ? (int?)null : Convert.ToInt32(AmountValue);
                         promotion.PercentValue = dPercentValue;
                         promotion.PriceBillRequire = String.IsNullOrEmpty(PriceBillRequire) ? (int?)null : Convert.ToInt32(PriceBillRequire);
                         promotion.PromotionType = SelectedPromotionType.Id;
                         promotion.IsApply = SelectedState.Id;
                         promotion.Note = Note;
                         DataProvider.Ins.DB.Promotions.Add(promotion);
                         DataProvider.Ins.DB.SaveChanges();

                         if (SelectedPromotionType.Id == 2 || SelectedPromotionType.Id == 3 || SelectedPromotionType.Id == 5)
                         {
                             foreach (var item in combineTwoGrid)
                             {
                                 ProductApplyForPromotion pa = new ProductApplyForPromotion();
                                 pa.ProductId = item.ProductId;
                                 pa.PPDisplayName = item.PPDisplayName;
                                 pa.ProductAmount = item.ProductAmount;
                                 pa.PromotionId = item.PromotionId;
                                 pa.ProductType = item.ProductType;
                                 DataProvider.Ins.DB.ProductApplyForPromotions.Add(pa);
                             }
                             DataProvider.Ins.DB.SaveChanges();
                         }

                         ListGridPromotion = new ObservableCollection<Promotion>(DataProvider.Ins.DB.Promotions);
                         SelectedPromotionItem = null;
                     }
                     else MessageBox.Show("Lỗi! Phần trăm khuyến mãi chỉ chứa kí tự số và 1 kí tự '.'");
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show(ex.ToString());
                 }
             });

            EditPromotionCommand = new RelayCommand<object>((p) =>
             {
                 if (SelectedPromotionItem == null || SelectedPromotionType == null || String.IsNullOrEmpty(PromotionIdStable) || String.IsNullOrEmpty(DisplayName) || String.IsNullOrEmpty(txtFromDate)
                 || String.IsNullOrEmpty(txtToDate) || SelectedState == null) return false;
                 var displayList1 = DataProvider.Ins.DB.Promotions.Where(x => x.Id == PromotionIdStable && x.DisplayName == DisplayName
                     && x.FromDate == FromDate && x.ToDate == ToDate && x.IsApply == SelectedState.Id && x.Note == Note);
                 if (SelectedPromotionType.Id == 1)
                 {
                     if (String.IsNullOrEmpty(PercentValue)) return false;
                     var displayList2 = displayList1.Where(x => x.PercentValue == dPercentValue);
                     if (displayList2.Count() > 0) return false;
                 }
                 if (SelectedPromotionType.Id == 2 || SelectedPromotionType.Id == 3 || SelectedPromotionType.Id == 5)
                 {
                     if (combineTwoGrid.Count == 0) return false;
                     // phat hien xem grid1 co su thay doi khong

                     if (initCombineList.Count == combineTwoGrid.Count)
                     {
                         for (int i = 0; i < initCombineList.Count; i++)
                         {
                             if (initCombineList[i].ProductId != combineTwoGrid[i].ProductId || initCombineList[i].ProductAmount != combineTwoGrid[i].ProductAmount
                             || initCombineList[i].PromotionId != combineTwoGrid[i].PromotionId || initCombineList[i].ProductType != combineTwoGrid[i].ProductType) return true;
                         }
                     }
                     else return true;
                     //end
                     if (SelectedPromotionType.Id == 2 && displayList1.Count() > 0) return false;
                     if (SelectedPromotionType.Id == 3)
                     {
                         if (String.IsNullOrEmpty(AmountValue)) return false;
                         var check2 = displayList1.Where(x => x.AmountValue == iAmountValue);
                         if (check2.Count() > 0) return false;
                     }
                     if (SelectedPromotionType.Id == 5)
                     {
                         if (String.IsNullOrEmpty(PercentValue + AmountValue)) return false;
                         if (!String.IsNullOrEmpty(PercentValue) && !String.IsNullOrEmpty(AmountValue)) return false;
                         var check2 = displayList1.Where(x => x.AmountValue == iAmountValue && x.PercentValue == dPercentValue);
                         if (check2.Count() > 0) return false;
                     }
                 }
                 if (SelectedPromotionType.Id == 4)
                 {
                     if (String.IsNullOrEmpty(PriceBillRequire) || String.IsNullOrEmpty(PercentValue)) return false;
                     var displayList2 = displayList1.Where(x => x.PercentValue == dPercentValue && x.PriceBillRequire == iPriceBillRequire);
                     if (displayList2.Count() > 0) return false;
                 }
                 return true;
             }, (p) =>
             {
                 try
                 {
                     if (DateTime.Compare((DateTime)ToDate, (DateTime)FromDate) < 0)
                     {
                         MessageBox.Show("Chú ý! Ngày kết thúc phải lớn hơn ngày bắt đầu!");
                         txtToDate = null;
                     }
                     else if (DateTime.Compare((DateTime)ToDate, System.DateTime.Now) < 0)
                     {
                         MessageBox.Show("Ngày kết thúc phải lớn hơn ngày hiện tại!");
                         txtToDate = null;
                     }
                     else if (LocalDictionary.CheckIsDoubleType(PercentValue))
                     {
                         var promotion = DataProvider.Ins.DB.Promotions.Where(x => x.Id == PromotionIdStable).FirstOrDefault();
                         promotion.DisplayName = DisplayName;
                         promotion.FromDate = FromDate;
                         promotion.ToDate = ToDate;
                         promotion.AmountValue = iAmountValue;
                         promotion.PercentValue = dPercentValue;
                         promotion.PriceBillRequire = iPriceBillRequire;
                         promotion.PromotionType = SelectedPromotionType.Id;
                         promotion.IsApply = SelectedState.Id;
                         promotion.Note = Note;
                         DataProvider.Ins.DB.SaveChanges();

                         if (SelectedPromotionType.Id == 2 || SelectedPromotionType.Id == 3 || SelectedPromotionType.Id == 5)
                         {

                             foreach (var item in initCombineList)
                             {
                                 DataProvider.Ins.DB.ProductApplyForPromotions.Remove(item);
                             }
                             DataProvider.Ins.DB.SaveChanges();
                             foreach (var item in combineTwoGrid)
                             {
                                 ProductApplyForPromotion pa = new ProductApplyForPromotion();
                                 pa.ProductId = item.ProductId;
                                 pa.PPDisplayName = item.PPDisplayName;
                                 pa.ProductAmount = item.ProductAmount;
                                 pa.PromotionId = PromotionIdStable;
                                 pa.ProductType = item.ProductType;
                                 DataProvider.Ins.DB.ProductApplyForPromotions.Add(pa);
                             }
                             DataProvider.Ins.DB.SaveChanges();
                         }

                         ListGridPromotion = new ObservableCollection<Promotion>(DataProvider.Ins.DB.Promotions);
                         SelectedPromotionItem = null;
                     }
                     else MessageBox.Show("Lỗi! Phần trăm khuyến mãi chứa kí tự số và 1 kí tự '.'");
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show(ex.ToString());
                 }
             });

            DeletePromotionCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedPromotionItem == null) return false;
                var tables = DataProvider.Ins.DB.Promotions.Where(x => x.Id == PromotionIdStable);
                if (tables.Count() == 0) return false;
                return true;
            }, (p) =>
            {
                try
                {
                    if (MessageBox.Show("Bạn chắc chắn muốn xóa chứ", "Cảnh báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    {
                        DataProvider.Ins.DB.Promotions.Remove(SelectedPromotionItem);
                        DataProvider.Ins.DB.SaveChanges();
                        ListGridPromotion = new ObservableCollection<Promotion>(DataProvider.Ins.DB.Promotions);
                        SelectedPromotionItem = null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            });
            #endregion
            //--------------------------------------------------------------------------------------
            #region ProductCommand

            AddProductCommand = new RelayCommand<object>((p) =>
             {
                 if (SelectedProductTypeResultList == null && SelectedProductResultList == null) return false;
                 if (String.IsNullOrEmpty(ProductAmount) || String.IsNullOrEmpty(PromotionIdChangable) || SelectedProductType == null) return false;
                 if (iProductAmount < 1) return false;
                 //var truePromotionId = DataProvider.Ins.DB.Promotions.Where(x => x.Id == PromotionIdChangable).ToList();
                 //if (truePromotionId.Count != 1) return false;
                 if (SelectedProductType == ProductTypeList[0])
                 {
                     if (ListGridProductType1.Where(x => x.ProductId == SelectedProductResultList.Id).ToList().Count() > 0) return false;
                 }
                 if (SelectedProductType == ProductTypeList[1])
                 {
                     if (ListGridProductType0.Where(x => x.ProductId == SelectedProductResultList.Id).ToList().Count() > 0) return false;
                 }
                 return true;
             }, (p) =>
             {
                 try
                 {
                     if (SelectedPromotionType.Id == 3 || SelectedPromotionType.Id == 5)
                     {
                         if (CheckRBProductType && SelectedProductTypeResultList != null)
                         {
                             List<Product> products = new List<Product>(DataProvider.Ins.DB.Products.Where(x => x.ProductTypeID == SelectedProductTypeResultList.Id));
                             foreach (var item in products)
                             {
                                 if (combineTwoGrid.Where(x => x.ProductId == item.Id && x.ProductType == true).Count() > 0) continue;
                                 ProductApplyForPromotion forPromotion = new ProductApplyForPromotion();
                                 forPromotion.PPDisplayName = item.DisplayName;
                                 forPromotion.ProductId = item.Id;
                                 forPromotion.ProductAmount = iProductAmount;
                                 forPromotion.PromotionId = PromotionIdStable;
                                 forPromotion.ProductType = true;
                                 CheckProductExistInTypeP(SelectedPromotionType.Id, forPromotion);
                             }
                             ListGridProductType1 = new ObservableCollection<ProductApplyForPromotion>(combineTwoGrid.Where(x => x.ProductType == true));
                         }
                     }

                     if (CheckRBProduct)
                     {
                         ProductApplyForPromotion forPromotion = new ProductApplyForPromotion();
                         forPromotion.PPDisplayName = SelectedProductResultList.DisplayName;
                         forPromotion.ProductId = SelectedProductResultList.Id;
                         forPromotion.ProductAmount = iProductAmount;
                         forPromotion.PromotionId = PromotionIdChangable;
                         forPromotion.ProductType = SelectedProductType.Id;
                         CheckProductExistInTypeP(SelectedPromotionType.Id, forPromotion);
                         ListGridProductType1 = new ObservableCollection<ProductApplyForPromotion>(combineTwoGrid.Where(x => x.ProductType == true));
                         ListGridProductType0 = new ObservableCollection<ProductApplyForPromotion>(combineTwoGrid.Where(x => x.ProductType == false));
                     }

                     SelectedProductType1Item = null;
                     SelectedProductType0Item = null;
                     PromotionIdChangable = PromotionIdStable;
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show(ex.ToString());
                 }
             });

            EditProductCommand = new RelayCommand<object>((p) =>
             {
                 if (SelectedProductTypeResultList == null && SelectedProductResultList == null) return false;
                 if (SelectedProductType1Item == null && SelectedProductType0Item == null) return false;
                 if (String.IsNullOrEmpty(ProductAmount) || String.IsNullOrEmpty(PromotionIdChangable) || SelectedProductType == null) return false;
                 if (iProductAmount < 1) return false;
                 var check1 = combineTwoGrid.Where(x => x.ProductId == SelectedProductResultList.Id && x.ProductAmount == iProductAmount && x.ProductType == SelectedProductType.Id);
                 if (check1.Count() > 0) return false;
                 return true;
             }, (p) =>
             {
                 try
                 {
                     ProductApplyForPromotion pa = new ProductApplyForPromotion();
                     pa.ProductId = SelectedProductResultList.Id;
                     pa.PPDisplayName = SelectedProductResultList.DisplayName;
                     pa.PromotionId = PromotionIdChangable;
                     pa.ProductAmount = iProductAmount;
                     pa.ProductType = SelectedProductType.Id;
                     // back up then delete
                     int amount1 = combineTwoGrid.Count;
                     List<ProductApplyForPromotion> backupList1 = new List<ProductApplyForPromotion>();
                     List<ProductApplyForPromotion> backupList2 = new List<ProductApplyForPromotion>();
                     if (SelectedProductType1Item != null)
                     {
                         backupList1 = combineTwoGrid.Where(x => x.ProductId == SelectedProductType1Item.ProductId && x.ProductType == SelectedProductType1Item.ProductType).ToList();
                         combineTwoGrid.RemoveAll(x => x.ProductId == SelectedProductType1Item.ProductId && x.ProductType == SelectedProductType1Item.ProductType);
                     }
                     if (SelectedProductType0Item != null)
                     {
                         backupList2 = combineTwoGrid.Where(x => x.ProductId == SelectedProductType0Item.ProductId && x.ProductType == SelectedProductType0Item.ProductType).ToList();
                         combineTwoGrid.RemoveAll(x => x.ProductId == SelectedProductType0Item.ProductId && x.ProductType == SelectedProductType0Item.ProductType);
                     }
                     CheckProductExistInTypeP(SelectedPromotionType.Id, pa);
                     // neu count combineTwoGrid ko doi => them thanh cong=> ko can add lai                 
                     // nguoc lai thi add lai
                     if (combineTwoGrid.Count != amount1)
                     {
                         foreach (var item in backupList1)
                         {
                             combineTwoGrid.Add(item);
                         }
                         foreach (var item in backupList2)
                         {
                             combineTwoGrid.Add(item);
                         }
                     }

                     ListGridProductType1 = new ObservableCollection<ProductApplyForPromotion>(combineTwoGrid.Where(x => x.ProductType == true));
                     ListGridProductType0 = new ObservableCollection<ProductApplyForPromotion>(combineTwoGrid.Where(x => x.ProductType == false));
                     SelectedProductType1Item = null;
                     SelectedProductType0Item = null;
                     PromotionIdChangable = PromotionIdStable;
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show(ex.ToString());
                 }
             });
            DeleteProductCommand = new RelayCommand<object>((p) =>
             {
                 if (SelectedProductType1Item == null && SelectedProductType0Item == null) return false;
                 return true;
             }, (p) =>
             {
                 try
                 {
                     combineTwoGrid.RemoveAll(x => x.ProductId == SelectedProductResultList.Id && x.ProductType == SelectedProductType.Id);
                     ListGridProductType1 = new ObservableCollection<ProductApplyForPromotion>(combineTwoGrid.Where(x => x.ProductType == true));
                     ListGridProductType0 = new ObservableCollection<ProductApplyForPromotion>(combineTwoGrid.Where(x => x.ProductType == false));
                     SelectedProductType1Item = null;
                     SelectedProductType0Item = null;
                     PromotionIdChangable = PromotionIdStable;
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show(ex.ToString());
                 }
             });
            #endregion
        }

        private void CheckProductExistInTypeP(int? currentPromotionType, ProductApplyForPromotion checkPro)
        {
            Tuple<bool, string> result = Tuple.Create(false, "");
            int P = 0;
            if (currentPromotionType == 3 || currentPromotionType == 5)
            {
                if (currentPromotionType == 3) P = 5;
                else P = 3;
                if (checkPro.ProductType == true)
                {
                    List<Promotion> promotions = DataProvider.Ins.DB.Promotions.Where(x => x.PromotionType == P).ToList();
                    if (promotions != null)
                    {
                        foreach (var item in promotions)
                        {
                            List<ProductApplyForPromotion> listcon = DataProvider.Ins.DB.ProductApplyForPromotions.Where(x => x.PromotionId == item.Id && x.ProductType == true).ToList();
                            int _count = listcon.Where(x => x.ProductId == checkPro.ProductId).Count();
                            if (_count > 0)
                            {
                                result = Tuple.Create(true, item.Id);
                            }
                        }
                    }
                }
            }
            if (result.Item1 == true)
            {
                string message = String.Format("Cảnh báo! Sản phẩm này đã xuất hiện trong chương trình khuyến mãi mã {0}." +
                    "\nViệc áp dụng thêm chương trình giảm giá cho sản phẩm này có thể gây lỗi!!!\nTiếp tục thêm sản phẩm?", result.Item2);
                if (MessageBox.Show(message, "Cảnh báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
                {
                    combineTwoGrid.Add(checkPro);
                }
                else return;
            }
            else combineTwoGrid.Add(checkPro);
        }

        private void InitData()
        {
            InitListPromotionType();
            StateList = new List<State>();
            StateList.Add(new State(true, "Áp dụng", "Ngưng áp dụng"));
            StateList.Add(new State(false, "Áp dụng", "Ngưng áp dụng"));
            InitSearchList();
            ListGridPromotion = new ObservableCollection<Promotion>(DataProvider.Ins.DB.Promotions);
            ProductTypeList = new List<State>();
            ProductTypeList.Add(new State(true, "SP áp dụng", "SP quà tặng"));
            ProductTypeList.Add(new State(false, "SP áp dụng", "SP quà tặng"));
            ProductTypeResultList = new ObservableCollection<ProductType>(DataProvider.Ins.DB.ProductTypes);
            allProducts = new List<Product>(DataProvider.Ins.DB.Products.Where(x => x.IsTrading == true));
            ProductResultList = new ObservableCollection<Product>(allProducts);
            combineTwoGrid = new List<ProductApplyForPromotion>();
            ListGridProductType1 = new ObservableCollection<ProductApplyForPromotion>();
            ListGridProductType0 = new ObservableCollection<ProductApplyForPromotion>();
            initCombineList = new List<ProductApplyForPromotion>();
        }
        private void InitListPromotionType()
        {
            ListPromotionType = new List<SimpleType>();
            ListPromotionType.Add(new SimpleType(1, "Tăng % điểm tích thẻ"));
            ListPromotionType.Add(new SimpleType(2, "Mua sản phẩm tặng sản phẩm"));
            ListPromotionType.Add(new SimpleType(3, "Đồng giá sản phẩm"));
            ListPromotionType.Add(new SimpleType(4, "Giảm giá hóa đơn"));
            ListPromotionType.Add(new SimpleType(5, "Giảm giá sản phẩm"));
        }
        private void InitSearchList()
        {
            SearchList = new List<string>();
            SearchList.Add("Mã chương trình");
            SearchList.Add("Tên chương trình");
            SearchList.Add("Loại chương trình");
            SearchList.Add("Trạng thái");
            SearchList.Add("Ghi chú");
        }
        void EnableControls()
        {
            (thisControl.FindName("cardProduct") as Grid).IsEnabled = true;
            (thisControl.FindName("txbAmountValue") as TextBox).IsEnabled = true;
            (thisControl.FindName("txbPriceBillRequire") as TextBox).IsEnabled = true;
            (thisControl.FindName("gbProductGift") as GroupBox).IsEnabled = true;
            (thisControl.FindName("txbPercentValue") as TextBox).IsEnabled = true;
            (thisControl.FindName("rbProductType") as RadioButton).IsEnabled = true;
            (thisControl.FindName("cbProductType") as ComboBox).IsEnabled = true;
            (thisControl.FindName("rbProduct") as RadioButton).IsEnabled = true;
        }
        private void Search(string SelectedSearchList, string SearchContent)
        {
            //("Mã chương trình");
            //("Tên chương trình");
            //("Loại chương trình");
            //("Trạng thái");
            //("Ghi chú");
            List<Promotion> filtered = new List<Promotion>();
            List<Promotion> source = DataProvider.Ins.DB.Promotions.ToList();
            if (SearchContent != null) SearchContent = SearchContent.ToLower();
            if (String.IsNullOrEmpty(SearchContent))
            {
                filtered = source;
            }
            else
            {
                if (SelectedSearchList == SearchList[0])
                {

                    filtered = source.Where(x => x.Id.ToLower().Contains(SearchContent)).ToList();

                }
                else if (SelectedSearchList == SearchList[2])
                {
                    int i;
                    if (Int32.TryParse(SearchContent, out i))
                    {
                        filtered = source.Where(x => x.PromotionType == i).ToList();
                    }

                }
                else if (SelectedSearchList == SearchList[3])
                {
                    if (SearchContent.Contains("t")) filtered = source.Where(x => x.IsApply == true).ToList();
                    if (SearchContent.Contains("f")) filtered = source.Where(x => x.IsApply == true).ToList();
                }
                else if (SelectedSearchList == SearchList[4])
                {
                    filtered = DataProvider.Ins.DB.Promotions.Where(x => x.Note.ToLower().Contains(SearchContent)).ToList();
                }
                else
                {
                    filtered = source.Where(x => x.DisplayName.ToLower().Contains(SearchContent)).ToList();
                }
            }
            ListGridPromotion = new ObservableCollection<Promotion>(filtered);
        }
    }
}
