using CoffeeManagement.Models;
using CoffeeManagement.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CoffeeManagement.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private string _UserName;
        public string UserName {
            get=> _UserName;
            set
            {
                _UserName = value;
                OnPropertyChanged();
            }
        }
        private string _Password;
        public string Password {
            get => _Password;
            set
            {
                _Password = value;
                OnPropertyChanged();
            }
        }
        public ICommand ClosedCommand { get; set; }
        public ICommand AdminCommand { get; set; }
        public ICommand SaleCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }
        public MainViewModel()
        {
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) =>
            {
                Password = p.Password;   
            });
            AdminCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                try
                {
                    Employee employee = CheckCorrectAccount();
                    if (employee != null && employee.AdminPermission == true)
                    {
                        MessageBox.Show("Đăng nhập thành công!");
                        AdminWindow adminWindow = new AdminWindow();
                        p.Hide();
                        adminWindow.ShowDialog();
                        if (adminWindow.IsActive == false)
                        {
                            (p.FindName("FloatingPasswordBox") as PasswordBox).Password = null;
                            UserName = null;
                            p.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }                
            });
            SaleCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                try
                {
                    Employee employee = CheckCorrectAccount();
                    if (employee != null)
                    {
                        MessageBox.Show("Đăng nhập thành công!");
                        LocalDictionary.AddItemToSmallEmployeeMap(ProjectConstants.StaffSale, employee);
                        SaleWindow saleWindow = new SaleWindow();
                        p.Hide();
                        saleWindow.ShowDialog();
                        if (saleWindow.IsActive == false)
                        {
                            (p.FindName("FloatingPasswordBox") as PasswordBox).Password = null;
                            UserName = null;
                            p.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            });
            ClosedCommand = new RelayCommand<Window>((p) => { if (p == null) return false; return true; }, (p) =>
            {
                System.Windows.Application.Current.Shutdown();
            });
        }        
        private Employee CheckCorrectAccount()
        {
            if (Password == null || Password == "") return null;
            string passEncode = LocalDictionary.MD5Hash(LocalDictionary.Base64Encode(Password));
            List<Employee> result = new List<Employee>();
            try
            {
                result = new List<Employee>(DataProvider.Ins.DB.Employees.Where(x => x.UserName == UserName && x.EPassword == passEncode));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }            
            if (result == null || result.Count() == 0) return null;
            else return result.FirstOrDefault();
        }

    }
}
