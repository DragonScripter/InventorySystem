using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Data;
using DAL.Respository.Interface;
using Microsoft.EntityFrameworkCore;

namespace DAL.Respository.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly InventoryContext _context;

        public ProductRepository(InventoryContext context) 
        {
            _context = context;
        }

        public async Task<Product?> GetProductById(int id) 
        {
            return await _context.Products.FirstOrDefaultAsync(P => P.ProductID == id);
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public int Count(IEnumerable<Product> products)
        {
            return _context.Products.Count();
        }

        public async Task AddProduct(Product product) 
        {
            ArgumentNullException.ThrowIfNull(product);
            if (string.IsNullOrEmpty(product.SKU)) 
            {
                throw new ArgumentException("Sku is required.", nameof(product.SKU));
            }
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProduct(Product product) 
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(int id) 
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null) 
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}
