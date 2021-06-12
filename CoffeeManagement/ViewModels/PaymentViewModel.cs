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

namespace CoffeeManagement.ViewModels
{
    public class PaymentViewModel: BaseViewModel
    {
        public ICommand LoadCommand { get; set; }
        public ICommand AcceptCommand { get; set; }
        private string _Seller;
        public string Seller { get => _Seller; set { _Seller = value; OnPropertyChanged(); } }
        public string UserName;
        private Employee _EmpSelected;
        public Employee EmpSelected { get=> _EmpSelected; set { _EmpSelected = value; } }
        private string _WhatTime;
        public string WhatTime { get => _WhatTime; set { _WhatTime = value; OnPropertyChanged(); } }
        public DateTime? DateCreated;
        private string _Where;
        public string Where { get=> _Where; set { _Where = value;OnPropertyChanged(); } }
        public TableInfo tableInfo;
        private string _Who;
        public string Who { get => _Who; set { _Who = value; OnPropertyChanged(); } }
        private Customer _Buyer;
        public Customer Buyer  { get=> _Buyer; set { _Buyer = value; } }
        private string _Total;
        public string Total { get => _Total; set { _Total = value; OnPropertyChanged(); } }
        public double? OriginBillValue;
        private string _HowMuch;
        public string HowMuch { get => _HowMuch; set { _HowMuch = value; OnPropertyChanged(); } }
        public double? TrueBillValue;
        private string _InputMoney;
        public string InputMoney
        {
            get => _InputMoney;
            set
            {
                _InputMoney = value;
                OnPropertyChanged();
            }
        }
        private string _OutputMoney;
        public string OutputMoney { get => _OutputMoney; set { _OutputMoney = value; OnPropertyChanged(); } }
        private string _AddPoint;
        public string AddPoint { get => _AddPoint; set { _AddPoint = value; OnPropertyChanged(); } }
        public double? PointAdd;
        private string _SubPoint;
        public string SubPoint { get => _SubPoint; set { _SubPoint = value; OnPropertyChanged(); } }
        public int? PointSub;
        private string _IsPaid;
        public string IsPaid { get => _IsPaid; set { _IsPaid = value; OnPropertyChanged(); } }
        private string _Note;
        public string Note { get => _Note; set { _Note = value; OnPropertyChanged(); } }
        private bool _IsUsingAtStore;
        public bool IsUsingAtStore { get => _IsUsingAtStore; set { _IsUsingAtStore = value;  } }
        private bool _IsCusMember;
        public bool IsCusMember { get => _IsCusMember; set { _IsCusMember = value;  } }
        private bool _bIsPaid;
        public bool bIsPaid { get => _bIsPaid; set { _bIsPaid = value; } }

        private ObservableCollection<BillInfo> _ListBillInfo;
        public ObservableCollection<BillInfo> ListBillInfo { get=> _ListBillInfo; set { _ListBillInfo = value;OnPropertyChanged(); } }
        private ObservableCollection<PromotionAndBill> _ListPromoAndBill;
        public ObservableCollection<PromotionAndBill> ListPromoAndBill { get => _ListPromoAndBill; set { _ListPromoAndBill = value; OnPropertyChanged(); } }
        public PaymentViewModel(Bill bill, List<BillInfo> billInfos, List<PromotionAndBill> promotionAndBills, int? input) //xem tu SaleWindow thi truyen input
        {
            LoadCommand = new RelayCommand<Window>((p) =>
            {
                return true;
            }, (p) =>
            {
                try
                {

                    EmpSelected = DataProvider.Ins.DB.Employees.Where(x => x.UserName == bill.UserName).FirstOrDefault();
                    Seller = EmpSelected.FullName;
                    UserName = EmpSelected.UserName;
                    //
                    WhatTime = bill.DateCreated.ToString();
                    DateCreated = bill.DateCreated;
                    //
                    if (bill.IsUsingAtStore == true)
                    {
                        IsUsingAtStore = true;
                        if (bill.TableID != null)
                        {
                            tableInfo = DataProvider.Ins.DB.TableInfoes.Where(x => x.Id == bill.TableID).FirstOrDefault();
                            Room r = DataProvider.Ins.DB.Rooms.Where(x => x.Id == tableInfo.RoomID).FirstOrDefault();
                            Where = String.Format("Sử dụng tại quán - {0} - {1}", r.DisplayName, tableInfo.DisplayName);
                        }
                    }
                    else
                    {
                        IsUsingAtStore = false;
                        tableInfo = null;
                        Where = "Mang về";
                    }
                    //
                    if (bill.IsCusMember == true)
                    {
                        IsCusMember = true;
                        Buyer = DataProvider.Ins.DB.Customers.Where(x => x.Phone == bill.CustomerPhone).FirstOrDefault();
                        Who = String.Format("Thành viên - SĐT: {0} - Họ tên: {1}", Buyer.Phone, Buyer.DisplayName);
                    }
                    else
                    {
                        Buyer = null;
                        Who = "Khách vãng lai";
                        IsCusMember = false;
                    }
                    //
                    Total = bill.OriginBillValue.ToString();
                    OriginBillValue = bill.OriginBillValue;
                    //
                    HowMuch = bill.TrueBillValue.ToString();
                    TrueBillValue = bill.TrueBillValue;
                    //
                    if (input != null)
                    {
                        (p.FindName("CusMoney") as Grid).Visibility = Visibility.Visible;
                        (p.FindName("CusMoney") as Grid).Height = 30.4;
                        (p.FindName("ActionGrid") as Grid).Visibility = Visibility.Visible;
                        (p.FindName("ActionGrid") as Grid).Height = 32;
                        InputMoney = input.ToString();
                        OutputMoney = (Convert.ToInt32(InputMoney) - bill.TrueBillValue).ToString();
                        IsPaid = "Chưa thanh toán";
                    }
                    else
                    {
                        (p.FindName("CusMoney") as Grid).Visibility = Visibility.Hidden;
                        (p.FindName("CusMoney") as Grid).Height = 0;
                        (p.FindName("ActionGrid") as Grid).Visibility = Visibility.Hidden;
                        (p.FindName("ActionGrid") as Grid).Height = 0;
                        IsPaid = "Đã thanh toán";
                    }
                    //
                    AddPoint = bill.PointAdd.ToString();
                    PointAdd = bill.PointAdd;
                    //
                    SubPoint = bill.PointSub.ToString();
                    PointSub = bill.PointSub;
                    //
                    Note = bill.Note.ToString();
                    ListPromoAndBill = new ObservableCollection<PromotionAndBill>(promotionAndBills);
                    ListBillInfo = new ObservableCollection<BillInfo>(billInfos);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            });

            AcceptCommand = new RelayCommand<Window>((p) =>
            {
                return true;
            }, (p) =>
            {
                try
                {

                    //bill
                    Bill newBill = new Bill();
                    newBill.Id = Guid.NewGuid().ToString();
                    newBill.DateCreated = DateCreated;
                    newBill.UserName = UserName;
                    newBill.CustomerPhone = Buyer == null ? null : Buyer.Phone;
                    newBill.TableID = tableInfo == null ? (int?)null : tableInfo.Id;
                    newBill.OriginBillValue = OriginBillValue;
                    newBill.TrueBillValue = TrueBillValue;
                    newBill.PointAdd = PointAdd;
                    newBill.PointSub = PointSub;
                    newBill.IsPaid = true;
                    newBill.Note = Note;
                    newBill.IsUsingAtStore = IsUsingAtStore;
                    newBill.IsCusMember = IsCusMember;
                    DataProvider.Ins.DB.Bills.Add(newBill);
                    DataProvider.Ins.DB.SaveChanges();
                    //bill info
                    List<BillInfoNotNull> cloneListBillInfo = new List<BillInfoNotNull>();
                    foreach (var item in ListBillInfo)
                    {
                        BillInfo bi = new BillInfo();
                        BillInfoNotNull temp = new BillInfoNotNull();
                        bi.BillID = newBill.Id;
                        bi.ProductID = item.ProductID;
                        bi.ProductName = item.ProductName;
                        bi.Quantity = item.Quantity;
                        bi.Price = item.Price;
                        bi.IntoMoney = item.IntoMoney;
                        bi.Note = item.Note;
                        bi.IsGift = item.IsGift;
                        temp = bi.ConvertToBINotNull();
                        DataProvider.Ins.DB.BillInfoes.Add(bi);
                        cloneListBillInfo.Add(temp);
                    }
                    DataProvider.Ins.DB.SaveChanges();
                    //promotion and bill
                    foreach (var item in ListPromoAndBill)
                    {
                        PromotionAndBill pab = new PromotionAndBill();
                        pab.BillId = newBill.Id;
                        pab.PromotionId = item.PromotionId;
                        pab.PromotionName = item.PromotionName;
                        DataProvider.Ins.DB.PromotionAndBills.Add(pab);
                    }
                    DataProvider.Ins.DB.SaveChanges();
                    LocalDictionary.AddToListBools(ProjectConstants.BillIsClosedAfterPayment, true);
                    AfterPayment(billInfos, Buyer, newBill);
                    using (FrmBillRpt frmBillRpt = new FrmBillRpt(newBill, cloneListBillInfo, InputMoney, OutputMoney))
                    {
                        frmBillRpt.ShowDialog();
                    }
                    MessageBox.Show("Thanh toán thành công!");
                    p.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }                
            });

            
        }
        private void AfterPayment(List<BillInfo> billInfos, Customer buyer, Bill bill)
        {
            try
            {

                //product impact
                foreach (var item in billInfos)
                {
                    //cap nhat lai CurrentQuantity
                    Product p = DataProvider.Ins.DB.Products.Where(x => x.Id == item.ProductID).FirstOrDefault();
                    if (p.CurrentQuantity != null && p.CurrentQuantity > 0) p.CurrentQuantity -= item.Quantity;
                    if (p.CurrentQuantity < 0) p.CurrentQuantity = null;
                    // thong bao neu current < minimum quantity
                    if (p.MinimumQuantity != null && p.CurrentQuantity != null && p.MinimumQuantity > p.CurrentQuantity) MessageBox.Show(String.Format("Cảnh báo! Số lượng hiện tại của sản phẩm {0} ({1}) đang nhỏ hơn hạn mức ({2})", p.DisplayName, p.CurrentQuantity, p.MinimumQuantity));
                }
                DataProvider.Ins.DB.SaveChanges();
                //customer impact
                List<CustomerType> ct = DataProvider.Ins.DB.CustomerTypes.ToList();
                if (buyer != null && ct.Count > 0)
                {
                    Customer c = DataProvider.Ins.DB.Customers.Where(x => x.Phone == buyer.Phone && x.IsActive == true).FirstOrDefault();
                    if (c.TotalPurchased == null) c.TotalPurchased = 0;
                    c.TotalPurchased += Convert.ToInt32(bill.TrueBillValue);
                    if (c.CurrentPoint == null) c.CurrentPoint = 0;
                    c.CurrentPoint = c.CurrentPoint + bill.PointAdd - bill.PointSub;

                    if (c.CustomerTypeID != null)
                    {
                        if (ct != null && ct.Count > 0)
                        {
                            int temp = 999999999;
                            int id = (int)c.CustomerTypeID;
                            foreach (var item in ct)
                            {
                                if (c.TotalPurchased > item.TotalPurchaseNeeded)
                                {
                                    if (c.TotalPurchased - item.TotalPurchaseNeeded < temp)
                                    {
                                        temp = Convert.ToInt32(c.TotalPurchased - item.TotalPurchaseNeeded);
                                        id = item.Id;
                                    }
                                }
                            }
                            c.CustomerTypeID = id;
                            DataProvider.Ins.DB.SaveChanges();
                        }
                    }
                }
                //end
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
