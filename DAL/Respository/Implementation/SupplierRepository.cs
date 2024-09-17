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
    public class SupplierRepository : ISupplierRepository
    {
        private readonly InventoryContext _context;

        public SupplierRepository(InventoryContext context)
        {
            _context = context;
        }

        public async Task<Supplier?> GetSupplierById(int id)
        {
            return await _context.Suppliers.FirstOrDefaultAsync(S => S.SupplierID == id);
        }

        public async Task<IEnumerable<Supplier>> GetAllSuppliers()
        {
            return await _context.Suppliers.ToListAsync();
        }

        public async Task AddSupplier(Supplier supplier)
        {
            ArgumentNullException.ThrowIfNull(supplier);

            await _context.Suppliers.AddAsync(supplier);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSupplier(Supplier supplier)
        {
            _context.Suppliers.Update(supplier);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSupplierById(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier != null) 
            {
                _context.Suppliers.Remove(supplier);
                await _context.SaveChangesAsync();
            }
        }

        public int Count(IEnumerable<Supplier> supplier)
        {
            return _context.Suppliers.Count();
        }
    }
}
