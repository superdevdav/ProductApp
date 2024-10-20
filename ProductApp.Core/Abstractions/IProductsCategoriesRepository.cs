using ProductApp.Core.Models;

namespace ProductApp.Core.Abstractions
{
    public interface IProductsCategoriesRepository
    {
        Task<int> Create(ProductCategory productCategory);
        Task<int> Delete(int Id);
        Task<List<ProductCategory>> Get();
        Task<int> Update(int Id, string Name, string Description);
    }
}