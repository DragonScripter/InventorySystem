using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Respository.Interface
{
    public interface ISaleRepository
    {
        Task<Sale?> GetSaleById(int id);
        Task<IEnumerable<Sale>> GetAllSales();

        int Count(IEnumerable<Sale> sale);
        Task AddSale(Sale sale);
        Task UpdateSale(Sale sale);
        Task DeleteSale(int id);
    }
}
