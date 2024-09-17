using System;
using System.Collections.Generic;

namespace DAL;

public partial class Supplier
{
    public int SupplierID { get; set; }

    public string Name { get; set; } = null!;

    public string? ContactInfo { get; set; }

    public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; } = new List<PurchaseOrder>();
}
