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
    public class SaleRepository : ISaleRepository
    {
        private readonly InventoryContext _context;

        public SaleRepository(InventoryContext context) 
        {
            _context = context;
        }

        public async Task<Sale?> GetSaleById(int id)
        {
            return await _context.Sales.FirstOrDefaultAsync(S => S.SaleID == id);
        }

        public async Task<IEnumerable<Sale>> GetAllSales()
        {
            return await _context.Sales.ToListAsync();
        }

        public async Task AddSale(Sale sale)
        {
            ArgumentNullException.ThrowIfNull(sale);

            await _context.Sales.AddAsync(sale);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSale(Sale sale)
        {
            _context.Sales.Update(sale);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSale(int id)
        {
            var sale = await _context.Sales.FindAsync(id);
            if (sale != null) 
            {
                _context.Sales.Remove(sale);
                await _context.SaveChangesAsync();
            }

        }

        public int Count(IEnumerable<Sale> sale)
        {
            return _context.Sales.Count();
        }
    }
}
