using CoffeeManagement.UserControlCoffee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace CoffeeManagement.ViewModels
{
    public class AdminViewModel : BaseViewModel
    {
        #region MenuTab
        private Grid gridRow1;
        UserControl addedUC;
        private string _UCSelectedProduct;        
        public string UCSelectedProduct
        {
            get => _UCSelectedProduct;
            set
            {
                if (value != "" || value != null)
                {
                    _UCSelectedProduct = value;
                    OnPropertyChanged();
                    if (gridRow1 != null) gridRow1.Children.Clear();
                    ShowUC(value);
                }
                
            }
        }
        private string _UCSelectedTable;
        public string UCSelectedTable
        {
            get => _UCSelectedTable;
            set
            {
                if (value != "" || value != null)
                {
                    _UCSelectedTable = value;
                    OnPropertyChanged();
                    if (gridRow1 != null) gridRow1.Children.Clear();
                    ShowUC(value);
                }

            }
        }
        private string _UCSelectedCustomer;
        public string UCSelectedCustomer
        {
            get => _UCSelectedCustomer;
            set
            {
                if (value != "" || value != null)
                {
                    _UCSelectedCustomer = value;
                    OnPropertyChanged();
                    if (gridRow1 != null) gridRow1.Children.Clear();
                    ShowUC(value);
                }

            }
        }
        private string _UCSelectedEmployee;
        public string UCSelectedEmployee
        {
            get => _UCSelectedEmployee;
            set
            {
                if (value != "" || value != null)
                {
                    _UCSelectedEmployee = value;
                    OnPropertyChanged();
                    if (gridRow1 != null) gridRow1.Children.Clear();
                    ShowUC(value);
                }

            }
        }
        private string _UCSelectedBill;
        public string UCSelectedBill
        {
            get => _UCSelectedBill;
            set
            {
                if (value != "" || value != null)
                {
                    _UCSelectedBill = value;
                    OnPropertyChanged();
                    if (gridRow1 != null) gridRow1.Children.Clear();
                    ShowUC(value);
                }

            }
        }
        private string _UCSelectedReport;
        public string UCSelectedReport
        {
            get => _UCSelectedReport;
            set
            {
                if (value != "" || value != null)
                {
                    _UCSelectedReport = value;
                    OnPropertyChanged();
                    if (gridRow1 != null) gridRow1.Children.Clear();
                    ShowUC(value);
                }

            }
        }        
        void ShowUC(string name)
        {
            
            switch (name)
            {
                case "Thực đơn":
                    addedUC = new MealTypeUC();
                    break;
                case "Nhóm hàng":
                    addedUC = new ProductTypeUC();
                    break;
                case "Sản phẩm":
                    addedUC = new ProductUC();
                    break;
                case "Chương trình khuyến mãi":
                    addedUC = new PromotionUC();
                    break;
                case "Phòng":
                    addedUC = new RoomUC();
                    break;
                case "Bàn":
                    addedUC = new TableUC();
                    break;
                case "Quản lý đơn vị đo":
                    addedUC = new UnitsUC();
                    break;
                case "Danh sách khách hàng":
                    addedUC = new CustomerUC();
                    break;
                case "Thẻ thành viên":
                    addedUC = new CustomerTypeUC();
                    break;
                case "Quản lý nhân viên":
                    addedUC = new EmployeeUC();
                    break;
                case "Danh sách hóa đơn":
                    addedUC = new BillIUC();
                    break;
                case "Báo cáo kinh doanh":
                    addedUC = new ReportProfitUC();
                    break;
                default:
                    break;
            }
            if (gridRow1 != null && addedUC != null) gridRow1.Children.Add(addedUC); 

        }
        #endregion
        public ICommand LoadedCommand { get; set; }
        public AdminViewModel()
        {
            LoadedCommand = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                gridRow1 = p;
            });
        }

    }
}
