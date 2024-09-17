using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Respository.Interface
{
    public interface ISupplierRepository
    {
        Task<Supplier?> GetSupplierById(int id);
        Task<IEnumerable<Supplier>> GetAllSuppliers();
        int Count(IEnumerable<Supplier> supplier);
        Task AddSupplier(Supplier supplier);
        Task UpdateSupplier(Supplier supplier);
        Task DeleteSupplierById(int id);
    }
}
