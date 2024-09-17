using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Respository.Interface
{
    public interface IPurchaseOrderDetailRepository
    {
        Task<PurchaseOrderDetail?> GetPODbyId(int id);
        Task<IEnumerable<PurchaseOrderDetail>> GetAllPOD();
        int Count(IEnumerable<PurchaseOrderDetail> POD);
        Task AddPOD(PurchaseOrderDetail POD);
        Task UpdatePOD(PurchaseOrderDetail POD);
        Task DeletePOD(int id);
    }
}
