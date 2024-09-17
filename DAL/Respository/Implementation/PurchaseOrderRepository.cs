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
    public class PurchaseOrderRepository : IPurchaseOrder
    {

        private readonly InventoryContext _context;

        public PurchaseOrderRepository(InventoryContext context)
        {
            _context = context;
        }

        public async Task<PurchaseOrder?> GetPurchaseOrderById(int id)
        {
            return await _context.PurchaseOrders.FirstOrDefaultAsync(P => P.OrderID == id);
        }
        public async Task<IEnumerable<PurchaseOrder>> GetAllPurchaseOrder()
        {
            return await _context.PurchaseOrders.ToListAsync();
        }
        public async Task AddPurchaseOrder(PurchaseOrder purchaseOrder)
        {
            if (purchaseOrder == null)
            {
                throw new ArgumentNullException(nameof(purchaseOrder));
            }

            await _context.PurchaseOrders.AddAsync(purchaseOrder);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePurchaseOrder(PurchaseOrder purchaseOrder)
        {
            _context.PurchaseOrders.Update(purchaseOrder);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePurchaseOrder(int id)
        {
            var purchaseOrder = await _context.PurchaseOrders.FindAsync(id);
            if (purchaseOrder != null) 
            {
                _context.PurchaseOrders.Remove(purchaseOrder);
                await _context.SaveChangesAsync();
            }
        }

        public int Count(IEnumerable<PurchaseOrder> purchaseOrder)
        {
            return _context.PurchaseOrders.Count();
        }
    }


}
