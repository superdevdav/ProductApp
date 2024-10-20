using ProductApp.Core.Models;
using ProductApp.Core.Abstractions;

namespace ProductApp.Application.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productRepository;

        public ProductsService(IProductsRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _productRepository.Get();
        }

        public async Task<int> CreateProduct(Product product)
        {
            return await _productRepository.Create(product);
        }

        public async Task<int> UpdateProduct(int Id, string Name, string Description, decimal Price)
        {
            return await _productRepository.Update(Id, Name, Description, Price);
        }

        public async Task<int> DeleteProduct(int Id)
        {
            return await _productRepository.Delete(Id);
        }
    }
}
