﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Data;
using DAL.Respository.Interface;
using Microsoft.EntityFrameworkCore;

namespace DAL.Respository.Implementation
{
    public class PurchaseOrderDetailRepository : IPurchaseOrderDetailRepository
    {
        private readonly InventoryContext _context;

        public PurchaseOrderDetailRepository(InventoryContext context) 
        {
            _context = context;
        }
        public async Task<PurchaseOrderDetail?> GetPODbyId(int id)
        {
            return await _context.PurchaseOrderDetails.FirstOrDefaultAsync(P => P.OrderID == id);
        }

        public async Task<IEnumerable<PurchaseOrderDetail>> GetAllPOD()
        {
            return await _context.PurchaseOrderDetails.ToListAsync();
        }

        public int Count(IEnumerable<PurchaseOrderDetail> POD)
        {
            return _context.PurchaseOrderDetails.Count();
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
    }
}
