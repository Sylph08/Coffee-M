//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CoffeeManagement.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PromotionAndBill
    {
        public int Id { get; set; }
        public string BillId { get; set; }
        public string PromotionId { get; set; }
        public string PromotionName { get; set; }
    
        public virtual Bill Bill { get; set; }
        public virtual Promotion Promotion { get; set; }
    }
}
