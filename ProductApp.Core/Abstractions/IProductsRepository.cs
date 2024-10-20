using ProductApp.Core.Models;

namespace ProductApp.Core.Abstractions
{
    public interface IProductsRepository
    {
        Task<int> Create(Product product);
        Task<int> Delete(int Id);
        Task<List<Product>> Get();
        Task<int> Update(int Id, string Name, string Description, decimal Price);
    }
}