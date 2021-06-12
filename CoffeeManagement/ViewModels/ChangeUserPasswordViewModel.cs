using CoffeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CoffeeManagement.ViewModels
{
    public class ChangeUserPasswordViewModel : BaseViewModel
    {
        // chi duoc goi tai thay doi mat khau cua SaleWindow        
        private Employee localEmployee = new Employee();
        private string _UserName;
        public string UserName
        {
            get => _UserName;
            set
            {
                _UserName = value;
                OnPropertyChanged();
            }
        }
        private string _Password1;
        public string Password1
        {
            get => _Password1;
            set
            {
                _Password1 = value;
                OnPropertyChanged();
            }
        }
        private string _Password2;
        public string Password2
        {
            get => _Password2;
            set
            {
                _Password2 = value;
                OnPropertyChanged();
            }
        }
        private string _Password3;
        public string Password3
        {
            get => _Password3;
            set
            {
                _Password3 = value;
                OnPropertyChanged();
            }
        }
        public ICommand SaveCommand { get; set; }
        public ICommand LoadCommand { get; set; }
        public ICommand PasswordChangedCommand1 { get; set; }
        public ICommand PasswordChangedCommand2 { get; set; }
        public ICommand PasswordChangedCommand3 { get; set; }
        public ChangeUserPasswordViewModel()
        {
            LoadCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (LocalDictionary.SmallEmployeeMap.ContainsKey(ProjectConstants.EmployeeChangePassword))
                {
                    localEmployee = LocalDictionary.SmallEmployeeMap[ProjectConstants.EmployeeChangePassword];
                    UserName = localEmployee.UserName;
                }
            });
            PasswordChangedCommand1 = new RelayCommand<PasswordBox>((p) => { return true; }, (p) =>
            {
                Password1 = p.Password;
            });
            PasswordChangedCommand2 = new RelayCommand<PasswordBox>((p) => { return true; }, (p) =>
            {
                Password2 = p.Password;
            });
            PasswordChangedCommand3 = new RelayCommand<PasswordBox>((p) => { return true; }, (p) =>
            {
                Password3 = p.Password;
            });

            SaveCommand = new RelayCommand<Window>((p) =>
            {
                if (String.IsNullOrEmpty(UserName) || String.IsNullOrEmpty(Password1) || String.IsNullOrEmpty(Password2) || String.IsNullOrEmpty(Password3)) return false;
                return true;
            }, (p) =>
            {
                try
                {
                    string pass1encode = LocalDictionary.MD5Hash(LocalDictionary.Base64Encode(Password1));
                    if (pass1encode != localEmployee.EPassword) MessageBox.Show("Mật khẩu cũ không hợp lệ!");
                    else
                    {
                        if (Password1 == Password2) MessageBox.Show("Lỗi! Mật khẩu mới giống mật khẩu cũ.");
                        if (Password2 != Password3) MessageBox.Show("Mật khẩu mới không khớp nhau!");
                        else
                        {
                            var employee = DataProvider.Ins.DB.Employees.Where(x => x.UserName == localEmployee.UserName).FirstOrDefault();
                            employee.EPassword = LocalDictionary.MD5Hash(LocalDictionary.Base64Encode(Password2));
                            DataProvider.Ins.DB.SaveChanges();
                            localEmployee = employee;
                            MessageBox.Show("Thay đổi mật khẩu thành công!");
                            //gui lai employee moi len map
                            LocalDictionary.AddItemToSmallEmployeeMap(ProjectConstants.EmployeeChangePassword, employee);
                            //
                            (p.FindName("FloatingPasswordBox1") as PasswordBox).Password = null;
                            (p.FindName("FloatingPasswordBox2") as PasswordBox).Password = null;
                            (p.FindName("FloatingPasswordBox3") as PasswordBox).Password = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }                
            });
        }
    }
}
