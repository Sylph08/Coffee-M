namespace CoffeeManagement.Models
{
    using System;
    using System.Collections.Generic;

    public partial class BillInfoNotNull
    {
        public int Id { get; set; }
        public string BillID { get; set; }
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int IntoMoney { get; set; }
        public string Note { get; set; }
        public bool IsGift { get; set; }

        public virtual Bill Bill { get; set; }
        public virtual Product Product { get; set; }

    }
}
