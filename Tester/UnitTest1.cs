using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Moq;
using DAL.Respository.Implementation;
using DAL.Data;
using DAL;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;

namespace Tester
{
    public class UnitTest1
    {
        private readonly PurchaseOrderRepository _repository;

        public UnitTest1()
        {
            var options = new DbContextOptionsBuilder<InventoryContext>()
                .UseSqlServer("Server=(localdb)\\ProjectModels;Database=Inventory;Trusted_Connection=True;")
                .Options;

            var context = new InventoryContext(options);
            _repository = new PurchaseOrderRepository(context);
        }

        //[Fact]
        //public async Task GetProductbyId()
        //{

        //    var result = await _repository.GetProductById(1);

        //    Assert.NotNull(result);
        //    Assert.Equal("Product1", result.Name);
        //    Assert.Equal("SKU001", result.SKU);
        //}

        //[Fact]
        //public async Task AddPurchaseOrder()
        //{

        //    var result = new PurchaseOrder()
        //    {
        //        SupplierID = 4,
        //        OrderDate = DateTime.Now,
        //        Status = "Completed"
        //    };

        //    var model = await _repository.AddPurchaseOrder(result) as RedirectToActionResult;

        //    Assert.NotNull(result);
        //    Assert.Equal("Product1", result.Name);
        //    Assert.Equal("SKU001", result.SKU);
        //}



        //[Fact]
        //public async Task GetAllSales()
        //{
        //    // Act
        //    var sale = await _repository.GetAllSales();

        //    // Assert
        //    Assert.NotNull(sale);
        //    Assert.Equal(49.95, sale.SaleAmount);
        //}

        //[Fact]
        //public async Task DeleteProduct()
        //{
        //    await _repository.DeleteProduct(1002);

        //    // Assert
        //    var deletedProduct = await _repository.GetProductById(1002);
        //    Assert.Null(deletedProduct); // Ensure the product is deleted
        //}

        //[Fact]
        //public async Task UpdateProduct()
        //{
        //    var product = new Product { ProductID = 5, Name = "Test Product1", SKU = "SKU 005", Price = 30.9m };
        //    await _repository.AddProduct(product);

        //    var updatedProduct = await _repository.GetProductById(5);
        //    updatedProduct.Name = "Machine";
        //    updatedProduct.Price = 50m;

        //    await _repository.UpdateProduct(updatedProduct);

        //    var result = await _repository.GetProductById(5);

        //    Assert.NotNull(result);
        //    Assert.Equal("Machine", result.Name);
        //    Assert.Equal(50m, result.Price);

        //}
    }
}