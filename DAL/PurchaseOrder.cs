using System;
using System.Collections.Generic;

namespace DAL;

public partial class PurchaseOrder
{
    public int OrderID { get; set; }

    public int SupplierID { get; set; }

    public DateTime OrderDate { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; } = new List<PurchaseOrderDetail>();

    public virtual Supplier Supplier { get; set; } = null!;
}
