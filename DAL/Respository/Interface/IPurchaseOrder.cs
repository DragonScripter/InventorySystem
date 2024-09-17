using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Respository.Interface
{
    public interface IPurchaseOrder
    {
        Task<PurchaseOrder?> GetPurchaseOrderById(int id);
        Task <IEnumerable<PurchaseOrder>> GetAllPurchaseOrder();
        int Count(IEnumerable<PurchaseOrder> purchaseOrder);
        Task AddPurchaseOrder(PurchaseOrder purchaseOrder);
        Task UpdatePurchaseOrder(PurchaseOrder purchaseOrder);
        Task DeletePurchaseOrder(int id);
    }
}
