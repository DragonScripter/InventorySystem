using System;
using System.Collections.Generic;

namespace DAL;

public partial class Sale
{
    public int SaleID { get; set; }

    public int ProductID { get; set; }

    public DateTime SaleDate { get; set; }

    public int QuantitySold { get; set; }

    public decimal SaleAmount { get; set; }

    public virtual Product Product { get; set; } = null!;
}
