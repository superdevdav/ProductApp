using ProductApp.Core.Models;

namespace ProductApp.Core.Abstractions
{
    public interface IProductsService
    {
        Task<int> CreateProduct(Product product);
        Task<int> DeleteProduct(int Id);
        Task<List<Product>> GetAllProducts();
        Task<int> UpdateProduct(int Id, string Name, string Description, decimal Price);
    }
}