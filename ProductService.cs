using System.Collections.Generic;
using 

public class ProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product> AddProductAsync(Product product)
    {
        if (string.IsNullOrWhiteSpace(product.Name))
        {
            throw new ArgumentException("Product name cannot be empty.");
        }

        await _productRepository.AddProductAsync(product);
        return product;
    }

   
}

