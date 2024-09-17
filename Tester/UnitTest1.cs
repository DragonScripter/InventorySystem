using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Moq;
using DAL.Respository.Implementation;
using DAL.Data;
using DAL;
using Microsoft.Extensions.Options;

namespace Tester
{
    public class UnitTest1
    {
        private readonly ProductRepository _repository;

        public UnitTest1()
        {
            var options = new DbContextOptionsBuilder<InventoryContext>()
                .UseSqlServer("Server=(localdb)\\ProjectModels;Database=Inventory;Trusted_Connection=True;")
                .Options;

            var context = new InventoryContext(options);
            _repository = new ProductRepository(context);
        }

        //[Fact]
        //public async Task GetProductbyId()
        //{

        //    var result = await _repository.GetProductById(1);

        //    Assert.NotNull(result);
        //    Assert.Equal("Product1", result.Name);
        //    Assert.Equal("SKU001", result.SKU);
        //}

        [Fact]
        public async Task GetAllProducts()
        {
            // Act
            var products = await _repository.GetAllProducts();

            // Assert
            Assert.NotEmpty(products);
            Assert.Equal(5, products.Count());
        }

        //[Fact]
        //public async Task AddProduct()
        //{
        //    var product = new Product { Name = "Test Product1", SKU = "SKU 109", Price = 30.9m };
        //    await _repository.AddProduct(product);
        //    var result =  await _repository.GetProductById(4);
        //    Assert.Equal("Test Product1", result.Name);
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