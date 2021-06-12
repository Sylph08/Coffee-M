using CoffeeManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeManagement.Views
{
    public partial class FrmBillRpt : Form
    {
        List<BillInfoNotNull> _listBI;
        Bill _bill;
        string InputMoney;
        string OutputMoney;
        public FrmBillRpt(Bill bill, List<BillInfoNotNull> listBI, string inputMoney, string outputMoney)
        {
            InitializeComponent();
            _listBI = listBI;
            _bill = bill;
            InputMoney = inputMoney;
            OutputMoney = outputMoney;
        }

        private void FrmBillRpt_Load(object sender, EventArgs e)
        {
            rptBill1.SetDataSource(_listBI);
            rptBill1.SetParameterValue("pEmployee", _bill.Employee.FullName);
            rptBill1.SetParameterValue("pDate", _bill.DateCreated.ToString());
            string table = _bill.TableID == null ? "Khach mang ve" : _bill.TableInfo.DisplayName.ToString();
            rptBill1.SetParameterValue("pTable", table);
            rptBill1.SetParameterValue("pTotalMoney", _bill.TrueBillValue.ToString());
            string phone;
            string custype;
            string cuspoint;
            if (_bill.CustomerPhone != null)
            {
                phone= _bill.CustomerPhone.ToString();
                custype = _bill.Customer.CustomerType.DisplayName;
                cuspoint = _bill.Customer.CurrentPoint.ToString();
            }
            else
            {
                phone = "Khach vang lai";
                custype = "Khong";
                cuspoint = "Khong";
            }
            rptBill1.SetParameterValue("pCusPhone", phone);
            rptBill1.SetParameterValue("pCusType", custype);
            rptBill1.SetParameterValue("pCusPoint", cuspoint);
            rptBill1.SetParameterValue("pCountAmount", _listBI.Count.ToString());
            rptBill1.SetParameterValue("pInputMoney", InputMoney);
            rptBill1.SetParameterValue("pOutputMoney", OutputMoney);
            crystalReportViewer1.ReportSource = rptBill1;
            crystalReportViewer1.Refresh();
        }
    }
}
