using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeManagement.DTO
{
    public class ReportCustomer
    {
        public string DisplayName { get; set; }
        public string Phone { get; set; }
        public string CustomerID { get; set; }
        public int TotalPurchased { get; set; }
        public double CurrentPoint { get; set; }
        public int CustomerTypeID { get; set; }
        public bool IsActive { get; set; }
        public ReportCustomer(DataRow row)
        {
            this.DisplayName = row["DisplayName"].ToString();
            this.Phone = row["Phone"].ToString();
            this.CustomerID = row["CustomerID"].ToString();
            this.TotalPurchased = String.IsNullOrEmpty(row["TotalPurchased"].ToString()) ? 0 : (int)row["TotalPurchased"];
            this.CurrentPoint = String.IsNullOrEmpty(row["CurrentPoint"].ToString()) ? 0 : (double)row["CurrentPoint"];
            this.CustomerTypeID = String.IsNullOrEmpty(row["CustomerTypeID"].ToString()) ? 0 : (int)row["CustomerTypeID"];
            this.IsActive = (bool)row["IsActive"];
        }
    }
}
