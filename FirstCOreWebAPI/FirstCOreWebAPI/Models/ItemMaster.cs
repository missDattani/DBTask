using System;
using System.Collections.Generic;

namespace FirstCOreWebAPI.Models;

public partial class ItemMaster
{
    public int ItemId { get; set; }

    public string? ItemName { get; set; }

    public int? Qty { get; set; }

    public decimal? Amount { get; set; }

    public decimal? Total { get; set; }

    public int? CouponId { get; set; }

    public DateTime? Dopo { get; set; }

    public virtual CouponCodeMaster? Coupon { get; set; }
}
