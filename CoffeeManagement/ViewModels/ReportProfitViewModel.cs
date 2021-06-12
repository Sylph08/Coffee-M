using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CoffeeManagement.DTO;
using CoffeeManagement.Models;
using Microsoft.Reporting.WinForms;

namespace CoffeeManagement.ViewModels
{
    public class ReportProfitViewModel : BaseViewModel
    {
        public ICommand LoadCommand { get; set; }
        public ICommand ShowCommand { get; set; }

        private bool _DateCheck;
        public bool DateCheck
        {
            get => _DateCheck;
            set
            {
                _DateCheck = value; OnPropertyChanged();
                ListRBT[0] = DateCheck;
                if (DateCheck == false)
                {
                    txtFromDate = null;
                    txtToDate = null;
                }
            }
        }
        private bool _MonthCheck;
        public bool MonthCheck
        {
            get => _MonthCheck;
            set
            {
                _MonthCheck = value;
                OnPropertyChanged();
                ListRBT[1] = MonthCheck;
                if (MonthCheck == false)
                {
                    FromMonth = null;
                    ToMonth = null;
                    FromYear = null;
                    ToYear = null;
                }
            }
        }
        private bool _YearCheck;
        public bool YearCheck
        {
            get => _YearCheck;
            set
            {
                _YearCheck = value;
                OnPropertyChanged();
                ListRBT[2] = YearCheck;
                if (YearCheck == false)
                {
                    StartYear = null;
                    EndYear = null;
                }
            }
        }
        private bool _AllProductCheck;
        public bool AllProductCheck { get => _AllProductCheck; set { _AllProductCheck = value; OnPropertyChanged(); ListRBT[3] = AllProductCheck; } }
        private bool _ProductQuantityCheck;
        public bool ProductQuantityCheck { get => _ProductQuantityCheck; set { _ProductQuantityCheck = value; OnPropertyChanged(); ListRBT[4] = ProductQuantityCheck; } }
        private bool _ProductProfitCheck;
        public bool ProductProfitCheck { get => _ProductProfitCheck; set { _ProductProfitCheck = value; OnPropertyChanged(); ListRBT[5] = ProductProfitCheck; } }
        private bool _EmployeeCheck;
        public bool EmployeeCheck { get => _EmployeeCheck; set { _EmployeeCheck = value; OnPropertyChanged(); ListRBT[6] = EmployeeCheck; } }
        private bool _BestEmployeeCheck;
        public bool BestEmployeeCheck { get => _BestEmployeeCheck; set { _BestEmployeeCheck = value; OnPropertyChanged(); ListRBT[7] = BestEmployeeCheck; } }
        private bool _CustomerCheck;
        public bool CustomerCheck { get => _CustomerCheck; set { _CustomerCheck = value; OnPropertyChanged(); ListRBT[8] = CustomerCheck; } }
        private bool _BestCustomerCheck;
        public bool BestCustomerCheck { get => _BestCustomerCheck; set { _BestCustomerCheck = value; OnPropertyChanged(); ListRBT[9] = BestCustomerCheck; } }
        private DateTime? _FromDate;
        public DateTime? FromDate { get => _FromDate; set { _FromDate = value; } }
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
        public DateTime? ToDate { get => _ToDate; set { _ToDate = value; } }
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
        private string _FromMonth;
        public string FromMonth
        {
            get => _FromMonth;
            set
            {
                _FromMonth = value;
                OnPropertyChanged();
            }
        }
        private string _FromYear;
        public string FromYear { get => _FromYear; set { _FromYear = value; OnPropertyChanged(); } }
        private string _ToMonth;
        public string ToMonth { get => _ToMonth; set { _ToMonth = value; OnPropertyChanged(); } }
        private string _ToYear;
        public string ToYear { get => _ToYear; set { _ToYear = value; OnPropertyChanged(); } }
        private string _StartYear;
        public string StartYear { get => _StartYear; set { _StartYear = value; OnPropertyChanged(); } }
        private string _EndYear;
        public string EndYear { get => _EndYear; set { _EndYear = value; OnPropertyChanged(); } }
        public List<bool> ListRBT;
        public ReportViewer rpv = new ReportViewer();

        public ReportProfitViewModel()
        {
            LoadCommand = new RelayCommand<UserControl>((p) =>
            {
                return true;
            }
            , (p) =>
            {
                ListRBT = new List<bool>(); ;
                ListRBT.Add(DateCheck);
                ListRBT.Add(MonthCheck);
                ListRBT.Add(YearCheck);
                ListRBT.Add(AllProductCheck);
                ListRBT.Add(ProductQuantityCheck);
                ListRBT.Add(ProductProfitCheck);
                ListRBT.Add(EmployeeCheck);
                ListRBT.Add(BestEmployeeCheck);
                ListRBT.Add(CustomerCheck);
                ListRBT.Add(BestCustomerCheck);
                rpv = p.FindName("MainRV") as ReportViewer;
                txtFromDate = null;
                txtToDate = null;
            }
            );
            ShowCommand = new RelayCommand<UserControl>((p) =>
            {
                if (ListRBT.Where(x => x == true).Count() < 1) return false;
                if (DateCheck) if (String.IsNullOrEmpty(txtFromDate) || String.IsNullOrEmpty(txtToDate)) return false;
                if (MonthCheck) if (String.IsNullOrEmpty(FromMonth) || String.IsNullOrEmpty(FromYear) || String.IsNullOrEmpty(ToMonth) || String.IsNullOrEmpty(ToYear)) return false;
                if (YearCheck) if (String.IsNullOrEmpty(StartYear) || String.IsNullOrEmpty(EndYear)) return false;
                return true;
            }
            , (p) =>
            {
                try
                {
                    if (DateCheck)
                    {
                        if (DateTime.Compare(Convert.ToDateTime(FromDate), Convert.ToDateTime(ToDate)) <= 0)
                        {
                            int fy = Convert.ToDateTime(FromDate).Year;
                            int fm = Convert.ToDateTime(FromDate).Month;
                            int fd = Convert.ToDateTime(FromDate).Day;
                            int ty = Convert.ToDateTime(ToDate).Year;
                            int tm = Convert.ToDateTime(ToDate).Month;
                            int td = Convert.ToDateTime(ToDate).Day;
                            DateTime? fDate = null;
                            if (TestMonthAndYear(fm, fy)) fDate = new DateTime(fy, fm, fd);
                            DateTime? tDate = null;
                            if (TestMonthAndYear(tm, ty)) tDate = new DateTime(ty, tm, td);
                            if (fDate != null && tDate != null && DateTime.Compare(Convert.ToDateTime(fDate), Convert.ToDateTime(tDate)) <= 0)
                            {
                                DataTable dtb = new DataTable();
                                List<ProfitPerDay> li = new List<ProfitPerDay>();
                                dtb = GetData("select * from ProfitPerDay");
                                foreach (DataRow item in dtb.Rows)
                                {
                                    ProfitPerDay i = new ProfitPerDay(item);
                                    li.Add(i);
                                }

                                List<ProfitPerDay> re = new List<ProfitPerDay>();
                                foreach (var item in li)
                                {
                                    DateTime dati = new DateTime(item.Nam, item.Thang, item.Ngay);
                                    if (DateTime.Compare(Convert.ToDateTime(fDate), dati) <= 0 && DateTime.Compare(dati, Convert.ToDateTime(tDate)) <= 0) re.Add(item);
                                }
                                rpv.Reset();
                                ReportDataSource ds = new ReportDataSource("DayRpt", re);
                                rpv.LocalReport.DataSources.Add(ds);
                                rpv.LocalReport.ReportEmbeddedResource = "CoffeeManagement.Report.DayRpt.rdlc";
                                rpv.RefreshReport();
                            }
                        }
                    }
                    if (MonthCheck)
                    {
                        int fd = 1; int td = 1;
                        int fm = Convert.ToInt32(FromMonth);
                        int tm = Convert.ToInt32(ToMonth);
                        int fy = Convert.ToInt32(FromYear);
                        int ty = Convert.ToInt32(ToYear);
                        DateTime? fDate = null;
                        DateTime? tDate = null;
                        if (TestMonthAndYear(fm, fy)) fDate = new DateTime(fy, fm, fd);
                        if (TestMonthAndYear(tm, ty)) tDate = new DateTime(ty, tm, td);
                        if (fDate != null && tDate != null && ty >= fy)
                        {
                            DataTable dtb = new DataTable();
                            List<ProfitPerMonth> li = new List<ProfitPerMonth>();
                            dtb = GetData("select * from ProfitPerMonth");
                            foreach (DataRow item in dtb.Rows)
                            {
                                ProfitPerMonth i = new ProfitPerMonth(item);
                                li.Add(i);
                            }
                            List<ProfitPerMonth> re = new List<ProfitPerMonth>();
                            foreach (var item in li)
                            {
                                DateTime dati = new DateTime(item.Nam, item.Thang, 1);
                                if (DateTime.Compare(Convert.ToDateTime(fDate), dati) <= 0 && DateTime.Compare(dati, Convert.ToDateTime(tDate)) <= 0) re.Add(item);
                            }
                            rpv.Reset();
                            ReportDataSource ds = new ReportDataSource("MonthRpt", re);
                            rpv.LocalReport.DataSources.Add(ds);
                            rpv.LocalReport.ReportEmbeddedResource = "CoffeeManagement.Report.MonthRpt.rdlc";
                            rpv.RefreshReport();
                        }
                    }
                    if (YearCheck)
                    {
                        int fy = Convert.ToInt32(StartYear);
                        int ty = Convert.ToInt32(EndYear);

                        if (fy <= ty && TestMonthAndYear(1, fy) && TestMonthAndYear(1, ty))
                        {
                            DataTable dtb = new DataTable();
                            List<ProfitPerYear> li = new List<ProfitPerYear>();
                            dtb = GetData("select * from ProfitPerYear");
                            foreach (DataRow item in dtb.Rows)
                            {
                                ProfitPerYear i = new ProfitPerYear(item);
                                li.Add(i);
                            }
                            List<ProfitPerYear> re = new List<ProfitPerYear>();
                            if (fy < ty)
                            {
                                foreach (var item in li)
                                {
                                    if (item.Nam >= fy && item.Nam <= ty) re.Add(item);
                                }
                            }
                            if (fy == ty)
                            {
                                re = li.Where(x => x.Nam == fy).ToList();
                            }
                            rpv.Reset();
                            ReportDataSource ds = new ReportDataSource("YearRpt", re);
                            rpv.LocalReport.DataSources.Add(ds);
                            rpv.LocalReport.ReportEmbeddedResource = "CoffeeManagement.Report.YearRpt.rdlc";
                            rpv.RefreshReport();
                        }
                    }
                    if (AllProductCheck)
                    {
                        DataTable dtb = new DataTable();
                        dtb = GetData("select * from ReportAllProduct");
                        rpv.Reset();
                        ReportDataSource ds = new ReportDataSource("ProductRpt", dtb);
                        rpv.LocalReport.DataSources.Add(ds);
                        rpv.LocalReport.ReportEmbeddedResource = "CoffeeManagement.Report.ProductRpt.rdlc";
                        rpv.RefreshReport();
                    }
                    if (ProductQuantityCheck)
                    {
                        DataTable dtb = new DataTable();
                        dtb = GetData("select * from ReportAllProduct");
                        List<ReportAllProduct> li = new List<ReportAllProduct>();
                        foreach (DataRow item in dtb.Rows)
                        {
                            ReportAllProduct i = new ReportAllProduct(item);
                            li.Add(i);
                        }
                        List<ReportAllProduct> re = li.OrderByDescending(x => x.TotalAmount).Take(10).ToList();
                        rpv.Clear();
                        rpv.Reset();
                        ReportDataSource ds = new ReportDataSource("ProductRpt", re);
                        rpv.LocalReport.DataSources.Add(ds);
                        rpv.LocalReport.ReportEmbeddedResource = "CoffeeManagement.Report.ProductRpt.rdlc";
                        rpv.RefreshReport();
                    }
                    if (ProductProfitCheck)
                    {
                        DataTable dtb = new DataTable();
                        dtb = GetData("select * from ReportAllProduct");
                        List<ReportAllProduct> li = new List<ReportAllProduct>();
                        foreach (DataRow item in dtb.Rows)
                        {
                            ReportAllProduct i = new ReportAllProduct(item);
                            li.Add(i);
                        }
                        List<ReportAllProduct> re = li.OrderByDescending(x => x.Doanhthu).Take(10).ToList();
                        rpv.Reset();
                        ReportDataSource ds = new ReportDataSource("ProductRpt", re);
                        rpv.LocalReport.DataSources.Add(ds);
                        rpv.LocalReport.ReportEmbeddedResource = "CoffeeManagement.Report.ProductRpt.rdlc";
                        rpv.RefreshReport();
                    }
                    if (EmployeeCheck)
                    {
                        DataTable dtb = new DataTable();
                        dtb = GetData("select * from ReportStaff");
                        rpv.Reset();
                        ReportDataSource ds = new ReportDataSource("StaffRpt", dtb);
                        rpv.LocalReport.DataSources.Add(ds);
                        rpv.LocalReport.ReportEmbeddedResource = "CoffeeManagement.Report.StaffRpt.rdlc";
                        rpv.RefreshReport();
                    }
                    if (BestEmployeeCheck)
                    {
                        DataTable dtb = new DataTable();
                        dtb = GetData("select * from ReportStaff");
                        List<ReportStaff> li = new List<ReportStaff>();
                        foreach (DataRow item in dtb.Rows)
                        {
                            ReportStaff i = new ReportStaff(item);
                            li.Add(i);
                        }
                        List<ReportStaff> re = li.OrderByDescending(x => x.TotalSold).Take(7).ToList();
                        rpv.Reset();
                        ReportDataSource ds = new ReportDataSource("StaffRpt", re);
                        rpv.LocalReport.DataSources.Add(ds);
                        rpv.LocalReport.ReportEmbeddedResource = "CoffeeManagement.Report.StaffRpt.rdlc";
                        rpv.RefreshReport();
                    }
                    if (CustomerCheck)
                    {
                        DataTable dtb = new DataTable();
                        dtb = GetData("select * from Customer");
                        rpv.Reset();
                        ReportDataSource ds = new ReportDataSource("CustomerRpt", dtb);
                        rpv.LocalReport.DataSources.Add(ds);
                        rpv.LocalReport.ReportEmbeddedResource = "CoffeeManagement.Report.CustomerRpt.rdlc";
                        rpv.RefreshReport();
                    }
                    if (BestCustomerCheck)
                    {
                        DataTable dtb = new DataTable();
                        dtb = GetData("select * from Customer");
                        List<ReportCustomer> li = new List<ReportCustomer>();
                        foreach (DataRow item in dtb.Rows)
                        {
                            ReportCustomer i = new ReportCustomer(item);
                            li.Add(i);
                        }
                        List<ReportCustomer> re = li.OrderByDescending(x => x.TotalPurchased).Take(10).ToList();
                        rpv.Reset();
                        ReportDataSource ds = new ReportDataSource("CustomerRpt", re);
                        rpv.LocalReport.DataSources.Add(ds);
                        rpv.LocalReport.ReportEmbeddedResource = "CoffeeManagement.Report.CustomerRpt.rdlc";
                        rpv.RefreshReport();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            );
        }
        private DataTable GetData(string sql)
        {
            DataTable dt = new DataTable();
            string cnt = System.Configuration.ConfigurationManager.ConnectionStrings["oldCNN"].ConnectionString.ToString();
            using (SqlConnection cn = new SqlConnection(cnt))
            {
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        private bool TestMonthAndYear(int m, int y)
        {
            if (m > 12 || m < 1)
            {
                MessageBox.Show("Tháng không hợp lệ!");
                return false;
            }
            if (y < 2020)
            {
                MessageBox.Show("Năm không hợp lệ!");
                return false;
            }
            return true;
        }
    }
}
