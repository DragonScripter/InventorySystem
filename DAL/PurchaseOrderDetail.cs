using System;
using System.Collections.Generic;

namespace DAL;

public partial class PurchaseOrderDetail
{
    public int OrderDetailID { get; set; }

    public int OrderID { get; set; }

    public int ProductID { get; set; }

    public int QuantityOrdered { get; set; }

    public virtual PurchaseOrder Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
