using CoffeeManagement.Models;
using CoffeeManagement.UserControlCoffee;
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
using MaterialDesignThemes.Wpf;
using System.Threading;

namespace CoffeeManagement.ViewModels
{
    public class SaleViewModel : BaseViewModel
    {
        public ICommand ContentRenderedCommand { get; set; }
        public ICommand ClosedWindowCommand { get; set; }
        public ICommand ShowListPromotionCommand { get; set; }
        public ICommand NewBillCommand { get; set; }
        public ICommand ApplyPromotion { get; set; }
        public ICommand RejectPromotion { get; set; }
        public ICommand LoadCommand { get; set; }
        public ICommand ChangePasswordCommand { get; set; }
        public ICommand PayCommand { get; set; }
        public ICommand DeleteProductCommand { get; set; }
        public ICommand SaveProductCommand { get; set; }
        public ICommand AddCustomerCommand { get; set; }
        public ICommand CloseWindowCommand { get; set; }
        public ICommand MaximizeWindowCommand { get; set; }
        public ICommand MinimizeWindowCommand { get; set; }
        public ICommand MouseMoveWindowCommand { get; set; }


        #region Fields
        private bool _BringHomeChecked;
        public bool BringHomeChecked { get => _BringHomeChecked; set { _BringHomeChecked = value; OnPropertyChanged(); } }
        private bool _AtStoreChecked;
        public bool AtStoreChecked
        {
            get => _AtStoreChecked;
            set
            {
                _AtStoreChecked = value;
                OnPropertyChanged();
                if (AtStoreChecked == false)
                {
                    RoomSelected = null;
                    TableSelected = null;
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
                }
                else
                {
                    TableList = sourceTable.ToList();
                }
            }
        }
        private TableInfo _TableSelected;
        public TableInfo TableSelected { get => _TableSelected; set { _TableSelected = value; OnPropertyChanged(); } }
        private bool _NonMemberChecked;
        public bool NonMemberChecked { get => _NonMemberChecked; set { _NonMemberChecked = value; OnPropertyChanged(); Phone = null; } }
        private bool _IsMemberChecked;
        public bool IsMemberChecked { get => _IsMemberChecked; set { _IsMemberChecked = value; OnPropertyChanged(); } }
        private Customer _CustomerSelected;
        public Customer CustomerSelected
        {
            get => _CustomerSelected;
            set
            {
                bool ChangetoCus = false;
                if (value != null) ChangetoCus = true;
                _CustomerSelected = value;
                //OnPropertyChanged();
                if (CustomerSelected != null)
                {
                    CustomerDisplayName = CustomerSelected.DisplayName;
                    CustomerID = CustomerSelected.CustomerID;
                    CustomerTypeSelected = CustomerSelected.CustomerType;
                    CurrentPoint = CustomerSelected.CurrentPoint.ToString();
                    if (txbPointAdd != null) txbPointAdd.IsEnabled = true;
                    if (txbPointSub != null) txbPointSub.IsEnabled = true;
                    // disable cac text ben canh phone
                    if (thisWindow != null)
                    {
                        (thisWindow.FindName("CusName") as TextBox).IsEnabled = false;
                        (thisWindow.FindName("CusID") as TextBox).IsEnabled = false;
                        (thisWindow.FindName("CusPoint") as TextBox).IsEnabled = false;
                        (thisWindow.FindName("CusType") as ComboBox).IsEnabled = false;
                    }
                }
                else
                {
                    CustomerDisplayName = null;
                    CustomerID = null;
                    CustomerTypeSelected = null;
                    CurrentPoint = null;
                    dPointAdd = 0;
                    PointSub = null;
                    if (txbPointAdd != null) txbPointAdd.IsEnabled = false;
                    if (txbPointSub != null) txbPointSub.IsEnabled = false;
                    // enable cac text ben canh phone
                    if (thisWindow != null)
                    {
                        (thisWindow.FindName("CusName") as TextBox).IsEnabled = true;
                        (thisWindow.FindName("CusID") as TextBox).IsEnabled = true;
                        (thisWindow.FindName("CusPoint") as TextBox).IsEnabled = true;
                        (thisWindow.FindName("CusType") as ComboBox).IsEnabled = true;
                    }

                }
                if (ChangetoCus)
                {
                    if (BeforeCalProm) //chua ap dung khuyen mai
                    {
                        dPointAdd = dOriginBV / 10000 * CustomerSelected.CustomerType.AddPoint;
                    }
                    if (AfterCalProm)
                    {
                        RejectPromotion.Execute(null);
                        dPointAdd = dOriginBV / 10000 * CustomerSelected.CustomerType.AddPoint;
                        ApplyPromotion.Execute(null);
                    }
                }
            }
        }
        private string _Phone;
        public string Phone
        {
            get => _Phone;
            set
            {
                _Phone = value;
                OnPropertyChanged();
                CustomerSelected = sourceCustomer.Where(x => x.Phone == Phone).FirstOrDefault();
            }
        }
        private string _CustomerDisplayName;
        public string CustomerDisplayName { get => _CustomerDisplayName; set { _CustomerDisplayName = value; OnPropertyChanged(); } }
        private string _CustomerID;
        public string CustomerID { get => _CustomerID; set { _CustomerID = value; OnPropertyChanged(); } }
        private CustomerType _CustomerTypeSelected;
        public CustomerType CustomerTypeSelected { get => _CustomerTypeSelected; set { _CustomerTypeSelected = value; OnPropertyChanged(); } }
        private string _CurrentPoint;
        public string CurrentPoint // #recode
        {
            get => _CurrentPoint;
            set
            {
                _CurrentPoint = value;
                OnPropertyChanged();
                dCurrentPoint = CustomerSelected == null ? 0 : (double)CustomerSelected.CurrentPoint;
                if (CustomerSelected != null && iPointSub > CustomerSelected.CurrentPoint)
                {
                    MessageBox.Show("Khách hàng không đủ điểm để trừ!");
                    PointSub = null;
                }
            }
        }
        public double dCurrentPoint;
        private MealType _MealSelected;
        public MealType MealSelected
        {
            get => _MealSelected;
            set
            {
                _MealSelected = value;
                OnPropertyChanged();
                if (MealSelected != null)
                {
                    ProductTypeList = sourceProType.Where(x => x.MealTypeID == MealSelected.Id).ToList();
                }
                else
                {
                    ProductTypeList = sourceProType;
                }
                FilterByMeal(ProductTypeList);
            }
        }

        private ProductType _ProductTypeSelected;
        public ProductType ProductTypeSelected
        {
            get => _ProductTypeSelected;
            set
            {
                _ProductTypeSelected = value;
                OnPropertyChanged();
                FilterByProductType(ProductTypeSelected);

            }
        }

        private string _SearchContent;
        public string SearchContent
        {
            get => _SearchContent;
            set
            {
                _SearchContent = value;
                OnPropertyChanged();                
                Search(SearchContent);
            }
        }
        private string _Id;
        public string Id { get => _Id; set { _Id = value; OnPropertyChanged(); iId = String.IsNullOrEmpty(Id) ? (int?)null : Convert.ToInt32(Id); } }
        public int? iId;
        private string _ProductName;
        public string ProductName { get => _ProductName; set { _ProductName = value; OnPropertyChanged(); } }
        private string _Quantity;
        public string Quantity
        {
            get => _Quantity;
            set
            {
                _Quantity = value;
                OnPropertyChanged();
                iQuantity = String.IsNullOrEmpty(Quantity) ? (int?)null : Convert.ToInt32(Quantity);
                iIntoMoney = iQuantity * iPrice;
                IntoMoney = iIntoMoney.ToString();
            }
        }
        public int? iQuantity;
        private string _Price;
        public string Price
        {
            get => _Price;
            set
            {
                _Price = value;
                OnPropertyChanged();
                iPrice = String.IsNullOrEmpty(Price) ? (int?)null : Convert.ToInt32(Price);
                iIntoMoney = iQuantity * iPrice;
                IntoMoney = iIntoMoney.ToString();
            }
        }
        public int? iPrice;
        private string _IntoMoney;
        public string IntoMoney { get => _IntoMoney; set { _IntoMoney = value; OnPropertyChanged(); iIntoMoney = String.IsNullOrEmpty(IntoMoney) ? (int?)null : Convert.ToInt32(IntoMoney); } }
        public int? iIntoMoney;
        private string _Note;
        public string Note { get => _Note; set { _Note = value; OnPropertyChanged(); } }
        private BillInfo _BuySelectedItem;
        public BillInfo BuySelectedItem
        {
            get => _BuySelectedItem;
            set
            {
                _BuySelectedItem = value;
                OnPropertyChanged();
                if (BuySelectedItem != null)
                {
                    GiftSelectedItem = null;
                    Id = BuySelectedItem.Id.ToString();
                    ProductName = BuySelectedItem.ProductName;
                    Quantity = BuySelectedItem.Quantity.ToString();
                    Price = BuySelectedItem.Price.ToString();
                    IntoMoney = BuySelectedItem.IntoMoney.ToString();
                    Note = BuySelectedItem.Note;
                }
                else
                {
                    Id = null;
                    ProductName = null;
                    Quantity = null;
                    Price = null;
                    IntoMoney = null;
                    Note = null;
                }
            }
        }
        private BillInfo _GiftSelectedItem;
        public BillInfo GiftSelectedItem
        {
            get => _GiftSelectedItem;
            set
            {
                _GiftSelectedItem = value;
                OnPropertyChanged();
                if (GiftSelectedItem != null)
                {
                    BuySelectedItem = null;
                    Id = GiftSelectedItem.Id.ToString();
                    ProductName = GiftSelectedItem.ProductName;
                    Quantity = GiftSelectedItem.Quantity.ToString();
                    Price = GiftSelectedItem.Price.ToString();
                    IntoMoney = GiftSelectedItem.IntoMoney.ToString();
                    Note = GiftSelectedItem.Note;
                }
                else
                {
                    Id = null;
                    ProductName = null;
                    Quantity = null;
                    Price = null;
                    IntoMoney = null;
                    Note = null;
                }
            }
        }
        private string _PointAdd;
        public string PointAdd // #recode
        {
            get => _PointAdd;
            set
            {
                _PointAdd = String.IsNullOrEmpty(value) ? "0" : value;
                OnPropertyChanged();
            }
        }
        private double? _dPointAdd;
        public double? dPointAdd
        {
            get => _dPointAdd;
            set
            {
                _dPointAdd = value;
                PointAdd = dPointAdd.ToString();
            }
        }
        private string _PointSub;
        public string PointSub
        {
            get => _PointSub;
            set
            {
                _PointSub = String.IsNullOrEmpty(value) ? "0" : value;
                OnPropertyChanged();

                iPointSub = String.IsNullOrEmpty(PointSub) ? 0 : Convert.ToInt32(PointSub);
                if (InCalProm) return;
                if (iPointSub > dCurrentPoint)
                {
                    MessageBox.Show("Khách hàng không đủ điểm để trừ!");
                    PointSub = null;
                }
                else if (iPointSub * 1000 > (LocalDictionary.ListDoubles.ContainsKey(ProjectConstants.PushTrueBillValue) == false ? 0 : LocalDictionary.ListDoubles[ProjectConstants.PushTrueBillValue]))
                {
                    MessageBox.Show("Lỗi! Số điểm trừ vượt quá giá trị đơn hàng!");
                    PointSub = null;
                }
                else
                {
                    // giup dTrueBV đc cập nhật ngay khi pointsub thay đổi 
                    double temp = LocalDictionary.ListDoubles.ContainsKey(ProjectConstants.PushTrueBillValue) == false ? 0 : LocalDictionary.ListDoubles[ProjectConstants.PushTrueBillValue];
                    dTrueBV = temp - iPointSub * 1000;
                    TrueBillValue = dTrueBV.ToString();
                    LocalDictionary.AddToListDoubles(ProjectConstants.PushTrueBillValue, temp);
                }

            }
        }
        public int? iPointSub;
        private string _OriginBillValue;
        public string OriginBillValue // #recode //cant change manually
        {
            get => _OriginBillValue;
            set
            {
                _OriginBillValue = String.IsNullOrEmpty(value) ? "0" : value;
                OnPropertyChanged();
            }
        }
        private double? _dOriginBV;
        public double? dOriginBV
        {
            get => _dOriginBV;
            set
            {
                _dOriginBV = value;
                OriginBillValue = dOriginBV.ToString();
            }
        }
        private string _TrueBillValue;
        public string TrueBillValue
        {
            get => _TrueBillValue;
            set
            {
                _TrueBillValue = String.IsNullOrEmpty(value) ? "0" : value;
                OnPropertyChanged();
                if (String.IsNullOrEmpty(TrueBillValue) == false && LocalDictionary.CheckIsDoubleType(TrueBillValue))
                {
                    dTrueBV = Convert.ToDouble(TrueBillValue);
                }
                else dTrueBV = 0;
                // cap nhat lai output money
                if (MoneyIn != null)
                {
                    MoneyIn = MoneyIn;
                }
            }
        }
        private double? _dTrueBV;
        public double? dTrueBV
        {
            get => _dTrueBV;
            set
            {
                _dTrueBV = value == null ? 0 : value;
                LocalDictionary.AddToListDoubles(ProjectConstants.PushTrueBillValue, (double)dTrueBV);
            }
        }

        private string _MoneyIn;
        public string MoneyIn
        {
            get => _MoneyIn;
            set
            {
                _MoneyIn = String.IsNullOrEmpty(value) ? "0" : value;
                OnPropertyChanged();
                iMoneyIn = String.IsNullOrEmpty(MoneyIn) ? 0 : Convert.ToInt32(MoneyIn);
                dMoneyOut = (double)iMoneyIn - (double)dTrueBV;
            }
        }
        public int? iMoneyIn;
        private string _MoneyOut;
        public string MoneyOut
        {
            get => _MoneyOut;
            set
            {
                _MoneyOut = String.IsNullOrEmpty(value) ? "0" : value;
                OnPropertyChanged();
            }
        }
        private double _dMoneyOut;
        public double dMoneyOut { get => _dMoneyOut; set { _dMoneyOut = value; MoneyOut = dMoneyOut.ToString(); } }
        private string _NotePromotion;
        public string NotePromotion { get => _NotePromotion; set { _NotePromotion = value; OnPropertyChanged(); } }
        //--------------------------------------------------

        private string _UserName;
        public string UserName { get => _UserName; set { _UserName = value; OnPropertyChanged(); } }
        private Employee _LoginEmployee;
        public Employee LoginEmployee { get => _LoginEmployee; set { _LoginEmployee = value; OnPropertyChanged(); } }
        #endregion

        #region Lists
        private List<Room> _RoomList;
        public List<Room> RoomList { get => _RoomList; set { _RoomList = value; OnPropertyChanged(); } }
        private List<TableInfo> _TableList;
        public List<TableInfo> TableList { get => _TableList; set { _TableList = value; OnPropertyChanged(); } }
        private List<CustomerType> _CustomerTypeList;
        public List<CustomerType> CustomerTypeList
        {
            get => _CustomerTypeList;
            set
            {
                _CustomerTypeList = value;
                OnPropertyChanged();
                if (CustomerTypeList == null || CustomerTypeList.Count == 0) CustomerTypeSelected = null;
            }
        }

        private List<MealType> _MealList;
        public List<MealType> MealList { get => _MealList; set { _MealList = value; OnPropertyChanged(); } }
        private List<ProductType> _ProductTypeList;
        public List<ProductType> ProductTypeList { get => _ProductTypeList; set { _ProductTypeList = value; OnPropertyChanged(); } }
        private ObservableCollection<BillInfo> _BuyListGrid;
        public ObservableCollection<BillInfo> BuyListGrid // #recode
        {
            get => _BuyListGrid;
            set
            {
                // chi thay doi duoc BuyList trc khi ap dung khuyen mai
                _BuyListGrid = value;
                OnPropertyChanged();
                if (BuyListGrid == null)
                {
                    BuySelectedItem = null;
                }
                CalculateOriginBV();
                if (BeforeCalProm && CustomerSelected != null) dPointAdd = dOriginBV / 10000 * CustomerSelected.CustomerType.AddPoint;
                ConvertToString();
            }
        }

        private ObservableCollection<BillInfo> _GiftListGrid;
        public ObservableCollection<BillInfo> GiftListGrid // #recode
        {
            get => _GiftListGrid;
            set
            {
                _GiftListGrid = value;
                OnPropertyChanged();
                if (GiftListGrid == null)
                {
                    GiftSelectedItem = null;
                }
                CalculateOriginBV();
                //tinh lai promotion type 4
                if (AfterCalProm)
                {
                    foreach (var item in UsedPromotion.ToList())
                    {
                        Promotion promotion = AvaiablePromotion.Where(x => x.Id == item.PromotionId).FirstOrDefault();
                        if (promotion.PromotionType == 4) UsedPromotion.Remove(item);
                    }
                    List<Promotion> listType4 = AvaiablePromotion.Where(x => x.PromotionType == 4).ToList();
                    ApplyPromotionType4(listType4);
                }
            }
        }

        #endregion

        //-----------------------------------------------
        private List<TableInfo> _sourceTable;
        public List<TableInfo> sourceTable { get => _sourceTable; set { _sourceTable = value; OnPropertyChanged(); } }
        private List<ProductType> _sourceProType;
        public List<ProductType> sourceProType { get => _sourceProType; set { _sourceProType = value; OnPropertyChanged(); } }
        private List<Product> _sourceProduct;
        public List<Product> sourceProduct { get => _sourceProduct; set { _sourceProduct = value; OnPropertyChanged(); } }
        private List<PromotionAndBill> _UsedPromotion;
        public List<PromotionAndBill> UsedPromotion { get => _UsedPromotion; set { _UsedPromotion = value; } }
        private List<Customer> _sourceCustomer;
        public List<Customer> sourceCustomer { get => _sourceCustomer; set => _sourceCustomer = value; }


        public WrapPanel wrapPanel;
        private List<Product> _FilterProduct;
        public List<Product> FilterProduct
        {
            get => _FilterProduct;
            set
            {
                _FilterProduct = value;
                if (!bOnInit)
                {
                    //Thread.Sleep(1000);
                    ShowFoodCard();
                }
            }
        }
        public List<Promotion> AvaiablePromotion;
        TextBox txbPointAdd;
        TextBox txbPointSub;
        List<Product> ProductHadPromotion;
        public Window thisWindow;
        //----------------------------
        private bool _BeforeCalProm;
        public bool BeforeCalProm
        {
            get => _BeforeCalProm;
            set
            {
                _BeforeCalProm = value;
                if (BeforeCalProm == true)
                {
                    InCalProm = false;
                    AfterCalProm = false;
                }
            }
        }
        private bool _InCalProm;
        public bool InCalProm
        {
            get => _InCalProm;
            set
            {
                _InCalProm = value;
                if (InCalProm == true)
                {
                    BeforeCalProm = false;
                    AfterCalProm = false;
                }
            }
        }
        private bool _AfterCalProm;
        public bool AfterCalProm
        {
            get => _AfterCalProm;
            set
            {
                _AfterCalProm = value;
                if (AfterCalProm == true)
                {
                    BeforeCalProm = false;
                    InCalProm = false;
                }
            }
        }
        private bool bOnInit = false;
        public SaleViewModel()
        {
            #region Control Bar
            CloseWindowCommand = new RelayCommand<Window>((p) => { return p == null ? false : true; }, (p) =>
            {
                if (p != null)
                {
                    p.Close();
                }
            });
            MaximizeWindowCommand = new RelayCommand<Window>((w) => { return w == null ? false : true; }, (w) =>
            {
                if (w != null)
                {
                    if (w.WindowState != WindowState.Maximized) w.WindowState = WindowState.Maximized;
                    else w.WindowState = WindowState.Normal;
                }
            });
            MinimizeWindowCommand = new RelayCommand<Window>((w) => { return w == null ? false : true; }, (w) =>
            {
                if (w != null)
                {
                    if (w.WindowState != WindowState.Minimized) w.WindowState = WindowState.Minimized;
                    else w.WindowState = WindowState.Maximized;
                }
            });
            MouseMoveWindowCommand = new RelayCommand<Window>((w) => { return w == null ? false : true; }, (w) =>
            {
                if (w != null)
                {
                    w.DragMove();
                }
            });
            #endregion
                        
            LoadCommand = new RelayCommand<Window>((p) =>
            {
                return true;
            }, (p) =>
            {
                bOnInit = true;
                LoadFunction(p);
                bOnInit = false;
            });
            ContentRenderedCommand = new RelayCommand<Window>((p) =>
            {
                return true;
            }, (p) =>
            {
                FilterProduct = new List<Product>(sourceProduct);
            });
            SaveProductCommand = new RelayCommand<object>((p) =>
            {
                if (BuySelectedItem == null && GiftSelectedItem == null) return false;
                if (String.IsNullOrEmpty(Quantity) || String.IsNullOrEmpty(Price) || String.IsNullOrEmpty(IntoMoney)) return false;
                if (BuySelectedItem != null)
                {
                    var check1 = BuyListGrid.Where(x => x.Id == iId && x.ProductName == ProductName && x.Quantity == iQuantity && x.Price == iPrice && x.IntoMoney == iIntoMoney && x.Note == Note);
                    if (check1.Count() > 0) return false;
                }
                if (GiftSelectedItem != null)
                {
                    var check2 = GiftListGrid.Where(x => x.Id == iId && x.ProductName == ProductName && x.Quantity == iQuantity && x.Price == iPrice && x.IntoMoney == iIntoMoney && x.Note == Note);
                    if (check2.Count() > 0) return false;
                }
                return true;
            }, (p) =>
            {
                try
                {
                    if (BuySelectedItem != null)
                    {
                        BillInfo bi = BuyListGrid.Where(x => x.Id == iId).FirstOrDefault();
                        bi.Quantity = iQuantity;
                        bi.Price = iPrice;
                        bi.IntoMoney = iIntoMoney;
                        bi.Note = Note;
                        BuyListGrid = new ObservableCollection<BillInfo>(BuyListGrid);
                        BuySelectedItem = null;
                    }
                    if (GiftSelectedItem != null)
                    {
                        BillInfo bi = GiftListGrid.Where(x => x.Id == iId).FirstOrDefault();
                        bi.Quantity = iQuantity;
                        bi.Price = iPrice;
                        bi.IntoMoney = iIntoMoney;
                        bi.Note = Note;
                        GiftListGrid = new ObservableCollection<BillInfo>(GiftListGrid);
                        GiftSelectedItem = null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            });

            DeleteProductCommand = new RelayCommand<object>((p) =>
            {
                if (BuySelectedItem == null && GiftSelectedItem == null) return false;
                return true;
            }, (p) =>
            {
                try
                {
                    if (BuySelectedItem != null)
                    {
                        BillInfo bi = BuyListGrid.Where(x => x.Id == iId).FirstOrDefault();
                        BuyListGrid.Remove(bi);
                        for (int i = 0; i < BuyListGrid.Count(); i++)
                        {
                            BuyListGrid[i].Id = i + 1;
                        }
                        BuyListGrid = new ObservableCollection<BillInfo>(BuyListGrid);
                        BuySelectedItem = null;
                    }
                    if (GiftSelectedItem != null)
                    {
                        BillInfo bi = GiftListGrid.Where(x => x.Id == iId).FirstOrDefault();
                        GiftListGrid.Remove(bi);
                        for (int i = 0; i < GiftListGrid.Count(); i++)
                        {
                            GiftListGrid[i].Id = i + 1;
                        }
                        GiftListGrid = new ObservableCollection<BillInfo>(GiftListGrid);
                        GiftSelectedItem = null;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            });

            AddCustomerCommand = new RelayCommand<object>((p) =>
            {
                if (CustomerSelected != null) return false;
                if (String.IsNullOrEmpty(CustomerDisplayName) || Phone.Length < 10) return false;
                return true;
            }, (p) =>
            {
                try
                {
                    Customer cus = DataProvider.Ins.DB.Customers.Where(x => x.Phone == Phone).FirstOrDefault();
                    if (cus != null && cus.IsActive == false)
                        MessageBox.Show("Khách hàng đã tồn tại trong cơ sở dữ liệu!" + Environment.NewLine + "Tài khoản này đã bị khóa.");
                    else
                    {
                        Customer newCus = new Customer();
                        newCus.DisplayName = CustomerDisplayName;
                        newCus.Phone = Phone;
                        newCus.CustomerID = CustomerID;
                        newCus.CustomerTypeID = CustomerTypeSelected == null ? 1 : CustomerTypeSelected.Id;
                        newCus.CurrentPoint = 0;
                        newCus.TotalPurchased = 0;
                        newCus.IsActive = true;
                        DataProvider.Ins.DB.Customers.Add(newCus);
                        DataProvider.Ins.DB.SaveChanges();
                        MessageBox.Show("Thêm mới thành công!");
                        sourceCustomer = DataProvider.Ins.DB.Customers.Where(x => x.IsActive == true).ToList();
                        CustomerSelected = newCus;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            });

            ApplyPromotion = new RelayCommand<object>((p) =>
            {
                if (AvaiablePromotion == null || AvaiablePromotion.Count == 0) return false;
                if (BuyListGrid.Count == 0 || BuyListGrid == null) return false;
                if (LocalDictionary.BillInfoMap.ContainsKey(ProjectConstants.BackupBuyListGrid)) return false;
                if (CustomerSelected != null)
                {
                    if (AvaiablePromotion.Where(x => x.PromotionType == 1).Count() > 0) return true;
                    if (AvaiablePromotion.Where(x => x.PromotionType == 4).Min(x => x.PriceBillRequire) < dOriginBV) return true;
                }
                foreach (var item in BuyListGrid)
                {
                    if (ProductHadPromotion.Where(x => x.Id == item.ProductID).Count() > 0) return true;
                }
                return false;
            }, (p) =>
            {
                try
                {
                    wrapPanel.IsEnabled = false;
                    //backup BuyListGrid
                    List<BillInfo> BuyListClone = new List<BillInfo>();
                    foreach (var item in BuyListGrid)
                    {
                        BillInfo bi = new BillInfo();
                        bi = item.Clone();
                        BuyListClone.Add(bi);
                    }
                    LocalDictionary.AddItemToBillInfoMap(ProjectConstants.BackupBuyListGrid, BuyListClone);
                    //execute promotion
                    ExecutePromotion();
                    ConvertToString();
                    //add key xac nhan da ap dung promotion
                    AfterCalProm = true;
                    OnOffGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            });

            RejectPromotion = new RelayCommand<object>((p) =>
            {
                if (!LocalDictionary.BillInfoMap.ContainsKey(ProjectConstants.BackupBuyListGrid)) return false;
                return true;
            }, (p) =>
            {
                try
                {
                    wrapPanel.IsEnabled = true;
                    GiftListGrid = new ObservableCollection<BillInfo>();
                    UsedPromotion = new List<PromotionAndBill>();
                    if (LocalDictionary.BillInfoMap.ContainsKey(ProjectConstants.BackupBuyListGrid))
                        BuyListGrid = new ObservableCollection<BillInfo>(LocalDictionary.BillInfoMap[ProjectConstants.BackupBuyListGrid]);
                    else BuyListGrid = new ObservableCollection<BillInfo>();
                    LocalDictionary.BillInfoMap.Remove(ProjectConstants.BackupBuyListGrid);
                    //add key xac nhan chua ap dung promotion
                    BeforeCalProm = true;
                    CustomerSelected = CustomerSelected;
                    OnOffGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            });

            NewBillCommand = new RelayCommand<object>((p) =>
            {
                if (BuyListGrid == null || BuyListGrid.Count == 0) return false;
                return true;
            }, (p) =>
            {
                try
                {
                    wrapPanel.IsEnabled = true;
                    BuyListGrid = new ObservableCollection<BillInfo>();
                    GiftListGrid = new ObservableCollection<BillInfo>();
                    UsedPromotion = new List<PromotionAndBill>();
                    NotePromotion = null;
                    (thisWindow.FindName("ScrollBuyList") as ScrollViewer).IsEnabled = true;
                    (thisWindow.FindName("ScrollGiftList") as ScrollViewer).IsEnabled = false;
                    if (LocalDictionary.BillInfoMap.ContainsKey(ProjectConstants.BackupBuyListGrid)) LocalDictionary.BillInfoMap.Remove(ProjectConstants.BackupBuyListGrid);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            });

            ShowListPromotionCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                try
                {
                    ShowPromotion w = new ShowPromotion();
                    PromotionViewModel vm = new PromotionViewModel();
                    w.DataContext = vm;
                    LocalDictionary.AddToListBools(ProjectConstants.IsCalledFromSaleWindow, true);
                    w.ShowDialog();
                    if (w.IsActive == false) LocalDictionary.AddToListBools(ProjectConstants.IsCalledFromSaleWindow, false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            });

            ChangePasswordCommand = new RelayCommand<object>((p) =>
            {
                if (LoginEmployee == null) return false;
                return true;
            }, (p) =>
            {
                try
                {
                    // gui emplyee len map
                    LocalDictionary.AddItemToSmallEmployeeMap(ProjectConstants.EmployeeChangePassword, LoginEmployee);
                    ChangeUserPassword w = new ChangeUserPassword();
                    w.ShowDialog();
                    //sau khi change pass xong update loginEmplyee van sd key day
                    if (w.IsActive == false)
                    {
                        Employee newEmp = LocalDictionary.SmallEmployeeMap[ProjectConstants.EmployeeChangePassword];
                        if (newEmp.UserName == LoginEmployee.UserName)
                        {
                            LoginEmployee = DataProvider.Ins.DB.Employees.Where(x => x.UserName == newEmp.UserName).FirstOrDefault();
                        }
                        LocalDictionary.SmallEmployeeMap.Remove(ProjectConstants.EmployeeChangePassword);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            });

            PayCommand = new RelayCommand<object>((p) =>
            {
                if (BuyListGrid == null && GiftListGrid == null) return false;
                if (GiftListGrid.Count == 0 && BuyListGrid.Count == 0) return false;
                if (String.IsNullOrEmpty(OriginBillValue) || String.IsNullOrEmpty(TrueBillValue) || String.IsNullOrEmpty(MoneyIn) || dMoneyOut < 0) return false;
                if (AtStoreChecked)
                    if (TableList != null && TableList.Count > 0)
                    {
                        if (TableSelected == null) return false;
                    }
                if (IsMemberChecked) if (CustomerSelected == null) return false;
                return true;
            }, (p) =>
            {
                try
                {
                    PaymentWindow pw = new PaymentWindow();
                    Bill bill = new Bill();
                    bill.DateCreated = System.DateTime.Now;
                    bill.UserName = LoginEmployee.UserName;
                    if (CustomerSelected == null)
                    {
                        bill.CustomerPhone = null;
                        bill.IsCusMember = false;
                    }
                    else
                    {
                        bill.CustomerPhone = CustomerSelected.Phone;
                        bill.IsCusMember = true;
                    }
                    if (TableSelected != null)
                    {
                        bill.IsUsingAtStore = true;
                        bill.TableID = TableSelected.Id;
                    }
                    else
                    {
                        bill.IsUsingAtStore = false;
                        bill.TableID = null;
                    }
                    bill.OriginBillValue = dOriginBV;
                    bill.TrueBillValue = dTrueBV;
                    bill.PointAdd = dPointAdd;
                    bill.PointSub = iPointSub;
                    bill.IsPaid = false;
                    bill.IsCusMember = CustomerSelected == null ? false : true;
                    bill.Note = NotePromotion == null ? "" : NotePromotion;
                    List<BillInfo> billInfos = new List<BillInfo>();
                    foreach (var item in BuyListGrid)
                    {
                        BillInfo bi = new BillInfo();
                        bi = item.Clone();
                        bi.Id = billInfos.Count() + 1;
                        billInfos.Add(bi);
                    }
                    if (GiftListGrid != null || GiftListGrid.Count > 0)
                    {
                        foreach (var item in GiftListGrid)
                        {
                            BillInfo bi = new BillInfo();
                            bi = item.Clone();
                            bi.Id = billInfos.Count() + 1;
                            billInfos.Add(bi);
                        }
                    }
                    PaymentViewModel vm = new PaymentViewModel(bill, billInfos, UsedPromotion, iMoneyIn);
                    pw.DataContext = vm;
                    pw.ShowDialog();
                    if (pw.IsActive == false)
                    {
                        if (LocalDictionary.ListBools.ContainsKey(ProjectConstants.BillIsClosedAfterPayment) && LocalDictionary.ListBools[ProjectConstants.BillIsClosedAfterPayment] == true)
                        {
                            ResetOriginUI();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            });

            ClosedWindowCommand = new RelayCommand<Window>((p) =>
             {
                 return true;
             }, (p) =>
             {
                 ResetOriginUI();
                 if (LocalDictionary.SmallEmployeeMap.ContainsKey(ProjectConstants.StaffSale)) LocalDictionary.SmallEmployeeMap.Remove(ProjectConstants.StaffSale);
                 if (LocalDictionary.SmallEmployeeMap.ContainsKey(ProjectConstants.EmployeeChangePassword)) LocalDictionary.SmallEmployeeMap.Remove(ProjectConstants.EmployeeChangePassword);
             });
        }
        private void ResetOriginUI()
        {
            wrapPanel.IsEnabled = true;
            RoomSelected = null;
            TableSelected = null;
            Phone = null;
            MealSelected = null;
            BuySelectedItem = null;
            BuyListGrid = new ObservableCollection<BillInfo>();
            GiftSelectedItem = null;
            UsedPromotion = new List<PromotionAndBill>();
            GiftListGrid = new ObservableCollection<BillInfo>();
            MoneyIn = null;
            BringHomeChecked = true; AtStoreChecked = false;
            NonMemberChecked = true; IsMemberChecked = false;
            (thisWindow.FindName("ScrollBuyList") as ScrollViewer).IsEnabled = true;
            (thisWindow.FindName("ScrollGiftList") as ScrollViewer).IsEnabled = false;
            if (LocalDictionary.BillInfoMap.ContainsKey(ProjectConstants.BackupBuyListGrid)) LocalDictionary.BillInfoMap.Remove(ProjectConstants.BackupBuyListGrid);
            if (LocalDictionary.ListDoubles.ContainsKey(ProjectConstants.PushTrueBillValue)) LocalDictionary.ListDoubles.Remove(ProjectConstants.PushTrueBillValue);
            if (LocalDictionary.ListBools.ContainsKey(ProjectConstants.IsCalledFromSaleWindow)) LocalDictionary.ListBools.Remove(ProjectConstants.IsCalledFromSaleWindow);
            if (LocalDictionary.ListBools.ContainsKey(ProjectConstants.BillIsClosedAfterPayment)) LocalDictionary.ListBools.Remove(ProjectConstants.BillIsClosedAfterPayment);
            BeforeCalProm = true;
        }
        private void OnOffGrid() // bat tat 2 grid
        {
            if (AfterCalProm)
            {
                (thisWindow.FindName("ScrollBuyList") as ScrollViewer).IsEnabled = false;
                (thisWindow.FindName("ScrollGiftList") as ScrollViewer).IsEnabled = true;
                BuySelectedItem = null;
            }
            if (BeforeCalProm)
            {
                (thisWindow.FindName("ScrollBuyList") as ScrollViewer).IsEnabled = true;
                (thisWindow.FindName("ScrollGiftList") as ScrollViewer).IsEnabled = false;
                GiftSelectedItem = null;
            }

        }

        private void LoadFunction(Window p)
        {
            //init data
            thisWindow = new Window();
            thisWindow = p;
            wrapPanel = new WrapPanel();
            wrapPanel = p.FindName("foodList") as WrapPanel;
            LocalDictionary.AddToListDoubles(ProjectConstants.PushTrueBillValue, 0);
            //
            //FilterProduct = new List<Product>();
            RoomList = new List<Room>(DataProvider.Ins.DB.Rooms);
            TableList = new List<TableInfo>();
            sourceTable = new List<TableInfo>(DataProvider.Ins.DB.TableInfoes.Where(x => x.IsUsing == true));
            CustomerTypeList = new List<CustomerType>(DataProvider.Ins.DB.CustomerTypes);
            MealList = new List<MealType>(DataProvider.Ins.DB.MealTypes);
            ProductTypeList = new List<ProductType>();
            sourceProType = new List<ProductType>(DataProvider.Ins.DB.ProductTypes);
            sourceCustomer = new List<Customer>(DataProvider.Ins.DB.Customers.Where(x => x.IsActive == true));

            UsedPromotion = new List<PromotionAndBill>();
            AvaiablePromotion = new List<Promotion>(DataProvider.Ins.DB.Promotions.Where(x => x.IsApply == true && (x.ToDate == null || DateTime.Compare(System.DateTime.Now, (DateTime)x.ToDate) <= 0)));
            BuyListGrid = new ObservableCollection<BillInfo>();
            GiftListGrid = new ObservableCollection<BillInfo>();

            LoginEmployee = new Employee();
            LoginEmployee = LocalDictionary.SmallEmployeeMap[ProjectConstants.StaffSale];
            sourceProduct = new List<Product>(DataProvider.Ins.DB.Products.Where(x => x.IsTrading == true));
            //
            ProductHadPromotion = new List<Product>();
            foreach (var item in AvaiablePromotion)
            {
                if (item.PromotionType == 2 || item.PromotionType == 3 || item.PromotionType == 5)
                {
                    List<ProductApplyForPromotion> temp = DataProvider.Ins.DB.ProductApplyForPromotions.Where(x => x.PromotionId == item.Id && x.ProductType == true).ToList();
                    foreach (var item1 in temp)
                    {
                        if (ProductHadPromotion.Where(x => x.Id == item1.ProductId).Count() > 0) continue;
                        else
                        {
                            Product product = sourceProduct.Where(x => x.Id == item1.ProductId).FirstOrDefault();
                            ProductHadPromotion.Add(product);
                        }
                    }
                }
            }
            //            
            txbPointAdd = new TextBox();
            txbPointAdd = p.FindName("txbPointAdd") as TextBox;
            txbPointSub = new TextBox();
            txbPointSub = p.FindName("txbPointSub") as TextBox;
            Phone = null;
            BringHomeChecked = true; AtStoreChecked = false;
            NonMemberChecked = true; IsMemberChecked = false;
            //
            BeforeCalProm = true;
            OnOffGrid();
            //
            if (LocalDictionary.BillInfoMap.ContainsKey(ProjectConstants.BackupBuyListGrid)) LocalDictionary.BillInfoMap.Remove(ProjectConstants.BackupBuyListGrid);
            //
            MoneyIn = null;
            MealSelected = null;
        }

        private void FilterByMeal(List<ProductType> productTypeList)
        {            
            List<Product> clone = new List<Product>();
            foreach (var item in productTypeList)
            {
                List<Product> temp = sourceProduct.Where(x => x.ProductTypeID == item.Id).ToList();
                foreach (var item1 in temp)
                {
                    clone.Add(item1);
                }
            }
            FilterProduct = new List<Product>(clone);
        }
        private void FilterByProductType(ProductType productTypeSelected)
        {
            if (productTypeSelected != null) FilterProduct = new List<Product>(sourceProduct.Where(x => x.ProductTypeID == productTypeSelected.Id));
            else MealSelected = null;
        }
        private void ShowFoodCard()
        {
            if (wrapPanel != null) wrapPanel.Children.Clear();
            if (FilterProduct == null || FilterProduct.Count < 1) return;
            foreach (var item in FilterProduct)
            {
                FoodCardUC foodCardUC = new FoodCardUC();
                FoodCardViewModel vm = new FoodCardViewModel(item);                
                foodCardUC.DataContext = vm;
                foodCardUC.Width = 170; foodCardUC.Height = 200;
                wrapPanel.Children.Add(foodCardUC);
            }            
        }
        private void Search(string searchContent)
        {
            if (FilterProduct != null) FilterProduct.Clear();
            if (!String.IsNullOrEmpty(searchContent))
            {
                searchContent = searchContent.ToLower();
                FilterProduct = sourceProduct.Where(x => x.DisplayName.ToLower().Contains(searchContent)).ToList();
            }
            else
            {
                FilterProduct = sourceProduct == null ? new List<Product>() : new List<Product>(sourceProduct);
            }
        }
        private void ExecutePromotion()
        {
            if (AvaiablePromotion == null || AvaiablePromotion.Count == 0) return;
            //
            InCalProm = true;
            List<Promotion> listType1 = AvaiablePromotion.Where(x => x.PromotionType == 1).ToList();
            List<Promotion> listType2 = AvaiablePromotion.Where(x => x.PromotionType == 2).ToList();
            List<Promotion> listType3 = AvaiablePromotion.Where(x => x.PromotionType == 3).ToList();
            List<Promotion> listType4 = AvaiablePromotion.Where(x => x.PromotionType == 4).ToList();
            List<Promotion> listType5 = AvaiablePromotion.Where(x => x.PromotionType == 5).ToList();
            if (listType1.Count > 0 && CustomerTypeList.Count > 0)
            {
                foreach (var item in listType1)
                {
                    ExecutePromotionType1(item);
                }
            }
            if (listType2.Count > 0)
            {
                foreach (var item in listType2)
                {
                    List<ProductApplyForPromotion> ConditionList = DataProvider.Ins.DB.ProductApplyForPromotions.Where(x => x.PromotionId == item.Id).ToList();
                    List<ProductApplyForPromotion> trueProduct = ConditionList.Where(x => x.ProductType == true).ToList();
                    List<ProductApplyForPromotion> falseProduct = ConditionList.Where(x => x.ProductType == false).ToList();
                    ExecutePromotionType2(item, trueProduct, falseProduct);
                }
            }
            if (listType3.Count > 0)
            {
                foreach (var item in listType3)
                {
                    List<ProductApplyForPromotion> ConditionList = DataProvider.Ins.DB.ProductApplyForPromotions.Where(x => x.PromotionId == item.Id).ToList();
                    List<ProductApplyForPromotion> trueProduct = ConditionList.Where(x => x.ProductType == true).ToList();
                    ExecutePromotionType3(item, trueProduct);
                }
            }
            if (listType5.Count > 0)
            {
                foreach (var item in listType5)
                {
                    List<ProductApplyForPromotion> ConditionList = DataProvider.Ins.DB.ProductApplyForPromotions.Where(x => x.PromotionId == item.Id).ToList();
                    List<ProductApplyForPromotion> trueProduct = ConditionList.Where(x => x.ProductType == true).ToList();
                    ExecutePromotionType5(item, trueProduct);
                }
            }
            // execute promotion type 4
            if (listType4.Count > 0)
            {
                ApplyPromotionType4(listType4);
            }
            //
            InCalProm = false;
        }
        private void ApplyPromotionType4(List<Promotion> listType4)
        {
            double maxBillRequire = 999999999;
            Promotion ProType4Apply = new Promotion();
            ProType4Apply = null;
            foreach (var item in listType4)
            {
                if (dOriginBV > item.PriceBillRequire)
                {
                    double temp = (double)dOriginBV - (double)item.PriceBillRequire;
                    if (temp < maxBillRequire)
                    {
                        temp = maxBillRequire;
                        ProType4Apply = item;
                    }
                }
            }
            ExecutePromotionType4(ProType4Apply);
        }
        private void CalculateOriginBV()
        {
            if (BuyListGrid != null && BuyListGrid.Count() > 0) dOriginBV = BuyListGrid.Sum(x => x.IntoMoney);
            else dOriginBV = 0;
            if (GiftListGrid != null && GiftListGrid.Count() > 0) dOriginBV += GiftListGrid.Sum(x => x.IntoMoney);

            dTrueBV = dOriginBV;
        }
        private void ConvertToString()
        {
            OriginBillValue = dOriginBV.ToString();
            TrueBillValue = dTrueBV.ToString();
            PointAdd = dPointAdd.ToString();
            PointSub = iPointSub.ToString();
            MoneyIn = iMoneyIn.ToString();
            MoneyOut = dMoneyOut.ToString();
        }
        private bool CheckExistInGiftList(string id)
        {
            if (GiftListGrid.Where(x => x.ProductID == id).Count() > 0) return true;
            return false;
        }
        private void AddToUsedPromotion(Promotion item)
        {
            if (UsedPromotion.Where(x => x.PromotionId == item.Id).Count() == 0)
            {
                PromotionAndBill pab = new PromotionAndBill();
                pab.Id = UsedPromotion.Count() + 1;
                pab.PromotionId = item.Id;
                pab.PromotionName = item.DisplayName;
                UsedPromotion.Add(pab);
            }
            else return;
        }
        private void ExecutePromotionType1(Promotion item)
        {
            if (CustomerSelected != null)
            {
                if (item.PercentValue == null) item.PercentValue = 0;
                dPointAdd = dPointAdd * (100 + item.PercentValue) / 100;
                //add to UsedPromotion
                AddToUsedPromotion(item);
            }
        }
        private void ExecutePromotionType2(Promotion item, List<ProductApplyForPromotion> trueProduct, List<ProductApplyForPromotion> falseProduct)
        {
            int mul = 99999;
            int check = 0;
            foreach (var con in trueProduct.ToList())
            {
                if (BuyListGrid.Where(x => x.ProductID == con.ProductId && x.Quantity >= con.ProductAmount).Count() > 0)
                {
                    BillInfo temp = BuyListGrid.Where(x => x.ProductID == con.ProductId && x.Quantity >= con.ProductAmount).FirstOrDefault();
                    int a = con.ProductAmount == null ? 1 : (int)con.ProductAmount;
                    int t = (int)temp.Quantity / a;
                    mul = t < mul ? t : mul;
                    check++;
                }
                else break;
            }
            if (check == trueProduct.Count())
            {
                foreach (var con in falseProduct)
                {
                    BillInfo bi = new BillInfo();
                    bi.Id = GiftListGrid.Count + 1;
                    bi.ProductID = con.ProductId;
                    bi.ProductName = con.Product.DisplayName;
                    bi.Quantity = con.ProductAmount * mul;
                    bi.Price = 0;
                    bi.IntoMoney = 0;
                    bi.IsGift = true;
                    GiftListGrid.Add(bi);
                }
                AddToUsedPromotion(item);
                GiftListGrid = new ObservableCollection<BillInfo>(GiftListGrid);
            }
        }
        private void ExecutePromotionType3(Promotion item, List<ProductApplyForPromotion> trueProduct)
        {
            int c = 0; //xac dinh xem promotion type 3 co duoc thuc hien khong
            foreach (var buy in BuyListGrid.ToList())
            {
                List<ProductApplyForPromotion> filter = trueProduct.Where(x => x.ProductId == buy.ProductID && x.ProductAmount <= buy.Quantity).ToList();
                if (filter.Count() == 1)
                {
                    c++;
                    ProductApplyForPromotion pa = filter.FirstOrDefault();
                    int? dif = buy.Quantity - pa.ProductAmount;
                    if (dif != null && dif >= 0)
                    {
                        //change in list buy
                        buy.Quantity = pa.ProductAmount - 1;
                        buy.IntoMoney = buy.Quantity * buy.Price;
                        if (buy.Quantity == 0)
                        {
                            BuyListGrid.Remove(buy);
                            for (int idex = 0; idex < BuyListGrid.Count(); idex++)
                            {
                                BuyListGrid[idex].Id = idex + 1;
                            }
                        }
                        BuyListGrid = new ObservableCollection<BillInfo>(BuyListGrid);
                        //----------------
                        //chang in list gift
                        if (CheckExistInGiftList(pa.ProductId))
                        {
                            BillInfo b1 = GiftListGrid.Where(x => x.ProductID == pa.ProductId).FirstOrDefault();
                            b1.Quantity = b1.Quantity + dif + 1;
                            b1.IntoMoney = b1.Quantity * b1.Price;
                        }
                        else
                        {
                            BillInfo bi = new BillInfo();
                            bi.Id = GiftListGrid.Count + 1;
                            bi.ProductID = pa.ProductId;
                            bi.ProductName = pa.Product.DisplayName;
                            bi.Quantity = dif + 1;
                            bi.Price = item.AmountValue;
                            bi.IntoMoney = bi.Quantity * bi.Price;
                            bi.IsGift = true;
                            GiftListGrid.Add(bi);
                        }
                    }
                }
            }
            if (c > 0)
            {
                AddToUsedPromotion(item);
            }
            GiftListGrid = new ObservableCollection<BillInfo>(GiftListGrid);
        }
        private void ExecutePromotionType4(Promotion item)
        {
            if (item == null) return;
            int billRequire = item.PriceBillRequire == null ? 0 : (int)item.PriceBillRequire;
            double d = item.PercentValue == null ? 0 : (double)item.PercentValue;
            if (dOriginBV >= billRequire)
            {
                dTrueBV = dOriginBV * (100 - d) / 100;
                AddToUsedPromotion(item);
            }
        }
        private void ExecutePromotionType5(Promotion item, List<ProductApplyForPromotion> trueProduct)
        {
            int c = 0;
            foreach (var buy in BuyListGrid.ToList())
            {
                List<ProductApplyForPromotion> filter = trueProduct.Where(x => x.ProductId == buy.ProductID && x.ProductAmount <= buy.Quantity).ToList();
                if (filter.Count() == 1)
                {
                    c++;
                    ProductApplyForPromotion pa = filter.FirstOrDefault();
                    int? dif = buy.Quantity - pa.ProductAmount;
                    if (dif != null && dif >= 0)
                    {
                        //change in list buy
                        buy.Quantity = pa.ProductAmount - 1;
                        buy.IntoMoney = buy.Quantity * buy.Price;
                        if (buy.Quantity == 0)
                        {
                            BuyListGrid.Remove(buy);
                            for (int idex = 0; idex < BuyListGrid.Count(); idex++)
                            {
                                BuyListGrid[idex].Id = idex + 1;
                            }
                        }
                        BuyListGrid = new ObservableCollection<BillInfo>(BuyListGrid);
                        //----------------
                        //chang in list gift
                        if (CheckExistInGiftList(pa.ProductId))
                        {
                            BillInfo b1 = GiftListGrid.Where(x => x.ProductID == pa.ProductId).FirstOrDefault();
                            b1.Quantity = b1.Quantity + dif + 1;
                            b1.IntoMoney = b1.Quantity * b1.Price;
                        }
                        else
                        {
                            BillInfo bi = new BillInfo();
                            bi.Id = GiftListGrid.Count + 1;
                            bi.ProductID = pa.ProductId;
                            bi.ProductName = pa.Product.DisplayName;
                            bi.Quantity = dif + 1;
                            int a = item.AmountValue == null ? 0 : (int)item.AmountValue;
                            double p = item.PercentValue == null ? 0 : (double)item.PercentValue;
                            bi.Price = Convert.ToInt32((pa.Product.SellValue - a) * (100 - p) / 100);
                            if (bi.Price < 0) bi.Price = 0;
                            bi.IntoMoney = bi.Quantity * bi.Price;
                            bi.IsGift = true;
                            GiftListGrid.Add(bi);
                        }
                    }
                }
            }
            if (c > 0)
            {
                AddToUsedPromotion(item);
            }
            GiftListGrid = new ObservableCollection<BillInfo>(GiftListGrid);
        }

    }
}
