using CoffeeManagement.Models;
using CoffeeManagement.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CoffeeManagement.ViewModels
{
    public class EmployeeViewModel : BaseViewModel
    {
        public ICommand ResetPasswordCommand { get; set; }
        #region Property chung
        public ICommand ClearAllFieldCommand { get; set; }
        public ICommand LoadCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand AddCommand { get; set; }
        private string _FullName;
        public string FullName { get => _FullName; set { _FullName = value; OnPropertyChanged(); } }
        private DateTime? _DateOfBirth;
        public DateTime? DateOfBirth
        {
            get => _DateOfBirth;
            set
            {
                _DateOfBirth = value;
            }
        }
        private string _txtDateOfBirth;
        public string txtDateOfBirth
        {
            get => _txtDateOfBirth;
            set
            {
                try
                {
                    _txtDateOfBirth = value;
                    OnPropertyChanged();
                    if (String.IsNullOrEmpty(txtDateOfBirth)) DateOfBirth = null;
                    else DateOfBirth = Convert.ToDateTime(txtDateOfBirth);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        private string _SelectedSex;
        public string SelectedSex { get => _SelectedSex; set { _SelectedSex = value; OnPropertyChanged(); } }
        private string _Phone;
        public string Phone { get => _Phone; set { _Phone = value; OnPropertyChanged(); } }
        private string _Email;
        public string Email { get => _Email; set { _Email = value; OnPropertyChanged(); } }
        private string _EAddress;
        public string EAddress { get => _EAddress; set { _EAddress = value; OnPropertyChanged(); } }
        private string _UserName;
        public string UserName { get => _UserName; set { _UserName = value; OnPropertyChanged(); } }
        private string _EPassword;
        public string EPassword { get => _EPassword; set { _EPassword = value; OnPropertyChanged(); } }
        private State _SelectedAdminPermission;
        public State SelectedAdminPermission { get => _SelectedAdminPermission; set { _SelectedAdminPermission = value; OnPropertyChanged(); } }
        private string _Note;
        public string Note { get => _Note; set { _Note = value; OnPropertyChanged(); } }

        //----------------------------------------------------------

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
        private Employee _SelectedItem;
        public Employee SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    Note = SelectedItem.Note;
                    FullName = SelectedItem.FullName;
                    Phone = SelectedItem.Phone;
                    txtDateOfBirth = SelectedItem.DateOfBirth.ToString();
                    if (SelectedItem.Sex != null) SelectedSex = SelectedItem.Sex;
                    else SelectedSex = null;
                    Phone = SelectedItem.Phone;
                    Email = SelectedItem.Email;
                    EAddress = SelectedItem.EAddress;
                    UserName = SelectedItem.UserName;
                    EPassword = SelectedItem.EPassword;
                    SelectedAdminPermission = SelectedItem.AdminPermission == true ? AdminPermissionList[0] : AdminPermissionList[1];
                    txtUserName.IsEnabled = false;
                }
                else
                {
                    Note = null;
                    FullName = null;
                    Phone = null;
                    txtDateOfBirth = null;
                    SelectedSex = null;
                    Phone = null;
                    Email = null;
                    EAddress = null;
                    UserName = null;
                    EPassword = null;
                    SelectedAdminPermission = null;
                    txtUserName.IsEnabled = true;
                }
            }
        }
        private List<string> _SexList;
        public List<string> SexList { get => _SexList; set { _SexList = value; OnPropertyChanged(); } }
        private List<State> _AdminPermissionList;
        public List<State> AdminPermissionList { get => _AdminPermissionList; set { _AdminPermissionList = value; OnPropertyChanged(); } }

        private ObservableCollection<Employee> _ListGrid;
        public ObservableCollection<Employee> ListGrid { get => _ListGrid; set { _ListGrid = value; OnPropertyChanged(); } }
        private List<string> _SearchList;
        public List<string> SearchList { get => _SearchList; set { _SearchList = value; OnPropertyChanged(); } }
        private void InitSearchList()
        {
            SearchList = new List<string>();
            SearchList.Add("Tên nhân viên");
            SearchList.Add("Ngày sinh");
            SearchList.Add("Giới tính");
            SearchList.Add("Số điện thoại");
            SearchList.Add("Email");
            SearchList.Add("Địa chỉ");
            SearchList.Add("Username");
            SearchList.Add("Quyền Admin");
            SearchList.Add("Ghi chú");
        }
        #endregion
        private TextBox txtUserName = new TextBox();
        public EmployeeViewModel()
        {
            LoadCommand = new RelayCommand<UserControl>((p) =>
            {
                return true;
            }, (p) =>
            {
                try
                {
                    InitData();
                    txtUserName = new TextBox();
                    txtUserName = p.FindName("txtUsername") as TextBox;
                    txtUserName.IsEnabled = true;
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
                 try
                 {
                     SelectedItem = null;
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show(ex.ToString());
                 }
             });

            AddCommand = new RelayCommand<object>((p) =>
            {
                if (String.IsNullOrEmpty(FullName) || String.IsNullOrEmpty(UserName) || String.IsNullOrEmpty(Phone)) return false;
                if (DateOfBirth != null)
                {
                    if (DateTime.Compare(Convert.ToDateTime(DateOfBirth), System.DateTime.Now) >= 0) return false;
                }
                var displayList = DataProvider.Ins.DB.Employees.Where(x => x.UserName == UserName);
                if (displayList.Count() > 0) return false;
                return true;
            }, (p) =>
            {
                
                try
                {
                    Employee employee = new Employee();
                    employee.FullName = FullName;
                    employee.Phone = Phone;
                    employee.DateOfBirth = DateOfBirth;
                    employee.Sex = SelectedSex;
                    employee.EAddress = EAddress;
                    employee.UserName = UserName;
                    if (EPassword != null) employee.EPassword = LocalDictionary.MD5Hash(LocalDictionary.Base64Encode(EPassword));
                    employee.Note = Note;
                    employee.AdminPermission = SelectedAdminPermission == null ? false : SelectedAdminPermission.Id;
                    employee.Email = Email;                    
                    if (Email != null)
                    {
                        if (new EmailAddressAttribute().IsValid(Email) == false)
                        {
                            MessageBox.Show("Lỗi! Địa chỉ Email không hợp lệ!");
                            return;
                        }
                    }
                    DataProvider.Ins.DB.Employees.Add(employee);
                    DataProvider.Ins.DB.SaveChanges();
                    ListGrid = new ObservableCollection<Employee>(DataProvider.Ins.DB.Employees);
                    SelectedItem = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            });

            EditCommand = new RelayCommand<object>((p) =>
            {
                if (String.IsNullOrEmpty(FullName) || String.IsNullOrEmpty(UserName) || String.IsNullOrEmpty(Phone) /*|| String.IsNullOrEmpty(EPassword)*/ || ListGrid.Count() == 0 || SelectedItem == null) return false;
                if (DateOfBirth != null)
                {
                    if (DateTime.Compare(Convert.ToDateTime(DateOfBirth), System.DateTime.Now) >= 0) return false;
                }
                var displayList = DataProvider.Ins.DB.Employees.Where(x => x.FullName == FullName && x.DateOfBirth == DateOfBirth && x.Sex == SelectedSex && x.Phone == Phone && x.Email == Email && x.EAddress == EAddress && x.UserName == UserName && x.EPassword == EPassword && x.AdminPermission == SelectedAdminPermission.Id && x.Note == Note);
                if (displayList.Count() > 0) return false;
                return true;
            }, (p) =>
            {                
                try
                {
                    var employee = DataProvider.Ins.DB.Employees.Where(x => x.UserName == UserName).FirstOrDefault();
                    employee.FullName = FullName;
                    employee.Phone = Phone;
                    employee.DateOfBirth = DateOfBirth;
                    employee.Sex = SelectedSex;
                    employee.EAddress = EAddress;
                    employee.UserName = UserName;
                    employee.Note = Note;
                    employee.AdminPermission = SelectedAdminPermission == null ? false : SelectedAdminPermission.Id;
                    employee.Email = Email;
                    if (Email != null)
                    {
                        if (new EmailAddressAttribute().IsValid(Email) == false)
                        {
                            MessageBox.Show("Lỗi! Địa chỉ Email không hợp lệ!");
                            return;
                        }
                    }
                    if (employee.EPassword == EPassword) employee.EPassword = EPassword;
                    else
                    {
                        if (MessageBox.Show("Bạn muốn thay đổi mật khẩu?", "Cảnh báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
                        {
                            if (!String.IsNullOrEmpty(EPassword))
                            {
                                string temp = LocalDictionary.MD5Hash(LocalDictionary.Base64Encode(EPassword));
                                if (employee.EPassword == temp)
                                {
                                    MessageBox.Show("Mật khẩu mới trùng với mật khẩu cũ!", "Cảnh báo");
                                    EPassword = null;
                                    return;
                                }
                                else employee.EPassword = temp;
                            }
                            else employee.EPassword = null;
                        }
                        else return;
                    }
                    DataProvider.Ins.DB.SaveChanges();
                    ListGrid = new ObservableCollection<Employee>(DataProvider.Ins.DB.Employees);
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
                var tables = DataProvider.Ins.DB.Employees.Where(x => x.UserName == UserName);
                if (tables.Count() == 0) return false;
                return true;
            }, (p) =>
            {
                try
                {
                    if (MessageBox.Show("Bạn chắc chắn muốn xóa chứ", "Cảnh báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    {
                        DataProvider.Ins.DB.Employees.Remove(SelectedItem);
                        DataProvider.Ins.DB.SaveChanges();
                        ListGrid = new ObservableCollection<Employee>(DataProvider.Ins.DB.Employees);
                        SelectedItem = null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            });


        }
        private void InitData()
        {
            InitSearchList();
            SexList = new List<string>();
            SexList.Add("Nam"); SexList.Add("Nữ"); SexList.Add("Khác");
            AdminPermissionList = new List<State>();
            AdminPermissionList.Add(new State(true, "Có", "Không ")); AdminPermissionList.Add(new State(false, "Có", "Không"));
            ListGrid = new ObservableCollection<Employee>(DataProvider.Ins.DB.Employees);
            SelectedItem = null;
        }
        private void Search(string SelectedSearchList, string SearchContent)
        {
            List<Employee> filtered = new List<Employee>();
            List<Employee> source = DataProvider.Ins.DB.Employees.ToList();
            if (SearchContent != null) SearchContent = SearchContent.ToLower();
            if (String.IsNullOrEmpty(SearchContent))
            {
                filtered = source;
            }
            else
            {
                if (SelectedSearchList == SearchList[1])
                {
                    DateTime result = new DateTime();
                    if (DateTime.TryParse(SearchContent, out result))
                        filtered = source.Where(x => x.DateOfBirth == result).ToList();
                }
                else if (SelectedSearchList == SearchList[2])
                {
                    filtered = source.Where(x => x.Sex.ToLower() == SearchContent).ToList();
                }
                else if (SelectedSearchList == SearchList[3])
                {
                    filtered = source.Where(x => x.Phone.ToLower().Contains(SearchContent)).ToList();
                }
                else if (SelectedSearchList == SearchList[4])
                {
                    filtered = DataProvider.Ins.DB.Employees.Where(x => x.Email.ToLower().Contains(SearchContent)).ToList();
                }
                else if (SelectedSearchList == SearchList[5])
                {
                    filtered = DataProvider.Ins.DB.Employees.Where(x => x.EAddress.ToLower().Contains(SearchContent)).ToList();
                }
                else if (SelectedSearchList == SearchList[6])
                {
                    filtered = source.Where(x => x.UserName.ToLower().Contains(SearchContent)).ToList();
                }
                else if (SelectedSearchList == SearchList[7])
                {
                    if (SearchContent.Contains("c") || SearchContent.Contains("t"))
                        filtered = DataProvider.Ins.DB.Employees.Where(x => x.AdminPermission == true).ToList();
                    if (SearchContent.Contains("k") || SearchContent.Contains("f"))
                        filtered = DataProvider.Ins.DB.Employees.Where(x => x.AdminPermission == false).ToList();
                }
                else if (SelectedSearchList == SearchList[6])
                {
                    filtered = DataProvider.Ins.DB.Employees.Where(x => x.Note.Contains(SearchContent)).ToList();
                }
                else
                {
                    filtered = source.Where(x => x.FullName.ToLower().Contains(SearchContent)).ToList();
                }
            }
            ListGrid = new ObservableCollection<Employee>(filtered);
        }
    }
}
