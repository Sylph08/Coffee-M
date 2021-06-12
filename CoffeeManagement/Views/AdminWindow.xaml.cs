using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CoffeeManagement.Views
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private string totalContent = "";
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void ProductCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            totalContent = TableCB.Text + CustomerCB.Text + EmployeeCB.Text + BillCB.Text + ReportCB.Text;
            if(totalContent.Length>0)
            {
                //if (ProductCB.Text != "") ProductCB.Text = "";
                if (TableCB.Text != "") TableCB.Text = "";
                if (CustomerCB.Text != "") CustomerCB.Text = "";
                if (EmployeeCB.Text != "") EmployeeCB.Text = "";
                if (BillCB.Text != "") BillCB.Text = "";
                if (ReportCB.Text != "") ReportCB.Text = "";
            }
        }

        private void TableCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            totalContent = CustomerCB.Text + EmployeeCB.Text + BillCB.Text + ReportCB.Text + ProductCB.Text;
            if (totalContent.Length > 0)
            {
                if (ProductCB.Text != "") ProductCB.Text = "";
                //if (TableCB.Text != "") TableCB.Text = "";
                if (CustomerCB.Text != "") CustomerCB.Text = "";
                if (EmployeeCB.Text != "") EmployeeCB.Text = "";
                if (BillCB.Text != "") BillCB.Text = "";
                if (ReportCB.Text != "") ReportCB.Text = "";
            }
                
        }

        private void CustomerCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            totalContent = TableCB.Text + EmployeeCB.Text + BillCB.Text + ReportCB.Text + ProductCB.Text;
            if (totalContent.Length > 0)
            {
                if (ProductCB.Text != "") ProductCB.Text = "";
                if (TableCB.Text != "") TableCB.Text = "";
                //if (CustomerCB.Text != "") CustomerCB.Text = "";
                if (EmployeeCB.Text != "") EmployeeCB.Text = "";
                if (BillCB.Text != "") BillCB.Text = "";
                if (ReportCB.Text != "") ReportCB.Text = "";
            }
                
        }

        private void EmployeeCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            totalContent = TableCB.Text + CustomerCB.Text + BillCB.Text + ReportCB.Text + ProductCB.Text;
            if (totalContent.Length > 0)
            {
                if (ProductCB.Text != "") ProductCB.Text = "";
                if (TableCB.Text != "") TableCB.Text = "";
                if (CustomerCB.Text != "") CustomerCB.Text = "";
                //if (EmployeeCB.Text != "") EmployeeCB.Text = "";
                if (BillCB.Text != "") BillCB.Text = "";
                if (ReportCB.Text != "") ReportCB.Text = "";
            }
                
        }

        private void BillCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            totalContent = TableCB.Text + CustomerCB.Text + EmployeeCB.Text + ReportCB.Text + ProductCB.Text;
            if (totalContent.Length > 0)
            {
                if (ProductCB.Text != "") ProductCB.Text = "";
                if (TableCB.Text != "") TableCB.Text = "";
                if (CustomerCB.Text != "") CustomerCB.Text = "";
                if (EmployeeCB.Text != "") EmployeeCB.Text = "";
                //if (BillCB.Text != "") BillCB.Text = "";
                if (ReportCB.Text != "") ReportCB.Text = "";
            }
                
        }

        private void ReportCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            totalContent = TableCB.Text + CustomerCB.Text + EmployeeCB.Text + BillCB.Text + ProductCB.Text;
            if (totalContent.Length > 0)
            {
                if (ProductCB.Text != "") ProductCB.Text = "";
                if (TableCB.Text != "") TableCB.Text = "";
                if (CustomerCB.Text != "") CustomerCB.Text = "";
                if (EmployeeCB.Text != "") EmployeeCB.Text = "";
                if (BillCB.Text != "") BillCB.Text = "";
                //if (ReportCB.Text != "") ReportCB.Text = "";
            }
                
        }
    }
}
