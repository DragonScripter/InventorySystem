using System;
using System.Collections.Generic;

namespace DAL;

public partial class Product
{
    public int ProductID { get; set; }

    public string Name { get; set; } = null!;

    public string SKU { get; set; } = null!;

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public int? SupplierID { get; set; }

    public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; } = new List<PurchaseOrderDetail>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

  
}
