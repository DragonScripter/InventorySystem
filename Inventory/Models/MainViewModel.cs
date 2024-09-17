using DAL;

namespace Inventory.Models
{
    public class MainViewModel
    {
        public IEnumerable<Product>? Products { get; set; }
        public IEnumerable<PurchaseOrder>? PurchaseOrders { get; set; }

        public IEnumerable<PurchaseOrderDetail>? PurchaseOrderDetails { get; set; }

        public IEnumerable<Sale>? Sales { get; set; }

        public IEnumerable<Supplier>? Suppliers { get; set; } 
    }
}
