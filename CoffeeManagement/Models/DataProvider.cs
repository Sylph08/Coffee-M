using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeManagement.Models
{
    public class DataProvider
    {
        private static DataProvider _ins;

        public static DataProvider Ins
        {
            get
            {
                if (_ins == null) _ins = new DataProvider(); //giúp trong toàn bộ chương trình chỉ có 1 object của class DataProvider
                return _ins;
            }
            set
            {
                _ins = value;
            }
        }
        public TimeCoffeeEntities DB { get; set; }
        private DataProvider()
        {
            DB = new TimeCoffeeEntities();
        }
    }
}
