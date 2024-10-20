using ProductApp.Core.Models;

namespace ProductApp.Core.Abstractions
{
    public interface IProductsCategoriesService
    {
        Task<int> CreateProductCategory(ProductCategory productCategory);
        Task<int> DeleteProductCategory(int Id);
        Task<List<ProductCategory>> GetAllProductsCategories();
        Task<int> UpdateProductCategory(int Id, string Name, string Description);
    }
}