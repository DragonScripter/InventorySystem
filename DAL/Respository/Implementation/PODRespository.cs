using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Data;
using DAL.Respository.Interface;
using Microsoft.EntityFrameworkCore;

namespace DAL.Respository.Implementation
{
    public class PODRespository : IPurchaseOrderDetailRepository
    {
        private readonly InventoryContext _context;

        public PODRespository(InventoryContext context) 
        {
            _context = new InventoryContext();
        }
        public async Task<PurchaseOrderDetail?> GetPODbyId(int id)
        {
            return await _context.PurchaseOrderDetails.FirstOrDefaultAsync(P => P.OrderID == id);
        }

        public async Task<IEnumerable<PurchaseOrderDetail>> GetAllPOD()
        {
            return await _context.PurchaseOrderDetails.ToListAsync();
        }
        public async Task AddPOD(PurchaseOrderDetail pod)
        {
            if (pod == null)
            {
                throw new ArgumentNullException(nameof(pod));
            }

            await _context.PurchaseOrderDetails.AddAsync(pod);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePOD(PurchaseOrderDetail pod)
        {
            _context.PurchaseOrderDetails.Update(pod);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePOD(int id)
        {
            var pod = await _context.PurchaseOrderDetails.FindAsync(id);
            if (pod != null)
            {
                _context.PurchaseOrderDetails.Remove(pod);
                await _context.SaveChangesAsync();
            }
        }

        public int Count(IEnumerable<PurchaseOrderDetail> POD)
        {
            return _context.PurchaseOrderDetails.Count();
        }
    }
}
