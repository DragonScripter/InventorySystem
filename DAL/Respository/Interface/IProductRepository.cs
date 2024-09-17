using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Respository.Interface
{
    public interface IProductRepository
    {
        Task<Product?> GetProductById(int id);
        Task<IEnumerable<Product>> GetAllProducts();

        int Count(IEnumerable<Product> product);
        Task AddProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(int id);
    }
}
