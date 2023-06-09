//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OrderManagement.Models.Context
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int OrderId { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> CouponId { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public Nullable<int> OrderTotalQty { get; set; }
        public Nullable<decimal> OrderAmount { get; set; }
        public Nullable<decimal> AfterGST { get; set; }
        public Nullable<decimal> TotalPayable { get; set; }
        public Nullable<int> SGST { get; set; }
        public Nullable<int> CGST { get; set; }
        public Nullable<int> ItemId { get; set; }
    
        public virtual CouponCodeMaster CouponCodeMaster { get; set; }
        public virtual User User { get; set; }
        public virtual Item Item { get; set; }
    }
}
