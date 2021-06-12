using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeManagement.DTO
{
    public class ProfitPerDay
    {
        public int Nam { get; set; }
        public int Thang { get; set; }
        public int Ngay { get; set; }
        public double Doanhthu { get; set; }
        public ProfitPerDay(DataRow row)
        {
            this.Nam = String.IsNullOrEmpty(row["Nam"].ToString()) ? 0 : (int)row["Nam"];
            this.Thang = String.IsNullOrEmpty(row["Thang"].ToString()) ? 0 : (int)row["Thang"];
            this.Ngay = String.IsNullOrEmpty(row["Ngay"].ToString()) ? 0 : (int)row["Ngay"];
            this.Doanhthu = String.IsNullOrEmpty(row["Doanhthu"].ToString()) ? 0 : (double)row["Doanhthu"];
        }
    }
}
