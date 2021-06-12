using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeManagement.DTO
{    
    public class ReportStaff
    {
        public string FullName { get; set; }
        public string DateOfBirth { get; set; }
        public string Sex { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string EAddress { get; set; }
        public string UserName { get; set; }
        public bool AdminPermission { get; set; }
        public double TotalSold { get; set; }
        public ReportStaff(DataRow row)
        {
            this.FullName = row["FullName"].ToString();
            this.DateOfBirth = row["DateOfBirth"].ToString();
            this.Sex = row["Sex"].ToString();
            this.Phone = row["Phone"].ToString();
            this.Email = row["Email"].ToString();
            this.EAddress = row["EAddress"].ToString();
            this.UserName = row["UserName"].ToString();
            this.AdminPermission = (bool)row["AdminPermission"];
            this.TotalSold = String.IsNullOrEmpty(row["TotalSold"].ToString()) ? 0 : (double)row["TotalSold"];
        }
    }
}
