using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeManagement.DTO
{
    public class ReportAllProduct
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public int MinimumQuantity { get; set; }
        public int CurrentQuantity { get; set; }
        public int TotalAmount { get; set; }
        public int Doanhthu { get; set; }
        public ReportAllProduct(DataRow row)
        {
            this.Id = row["Id"].ToString();
            this.DisplayName = row["DisplayName"].ToString();
            this.MinimumQuantity = String.IsNullOrEmpty(row["MinimumQuantity"].ToString()) ? 0 : (int)row["MinimumQuantity"];
            this.CurrentQuantity = String.IsNullOrEmpty(row["CurrentQuantity"].ToString()) ? 0 : (int)row["CurrentQuantity"];
            this.TotalAmount = String.IsNullOrEmpty(row["TotalAmount"].ToString()) ? 0 : (int)row["TotalAmount"];
            this.Doanhthu = String.IsNullOrEmpty(row["Doanhthu"].ToString()) ? 0 : (int)row["Doanhthu"];
        }
    }
}
