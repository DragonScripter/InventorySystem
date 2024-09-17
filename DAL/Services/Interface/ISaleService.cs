using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services.Interface
{
    public interface ISaleService
    {
        Task<Sale> GetSaleById(int id);
        Task<IEnumerable<Sale>> GetAllSales();
        Task AddSale(Sale sale);
        Task UpdateSale(Sale sale);
        Task DeleteSale(int id);
    }
}
