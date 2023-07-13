using System;
using System.Collections.Generic;

namespace FirstCOreWebAPI.Models;

public partial class CouponCodeMaster
{
    public int CouponIcoded { get; set; }

    public string? Code { get; set; }

    public string? Type { get; set; }

    public int? FlatAmount { get; set; }

    public int? Percentage { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public int? UsageLimit { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<ItemMaster> ItemMasters { get; set; } = new List<ItemMaster>();
}
