using ProductApp.Core.Abstractions;
using ProductApp.Core.Models;

namespace ProductApp.Application.Services
{
    public class ProductsCategoriesService : IProductsCategoriesService
    {
        private readonly IProductsCategoriesRepository _productsCategoriesRepository;

        public ProductsCategoriesService(IProductsCategoriesRepository productsCategoriesRepository)
        {
            _productsCategoriesRepository = productsCategoriesRepository;
        }

        public async Task<List<ProductCategory>> GetAllProductsCategories()
        {
            return await _productsCategoriesRepository.Get();
        }

        public async Task<int> CreateProductCategory(ProductCategory productCategory)
        {
            return await _productsCategoriesRepository.Create(productCategory);
        }

        public async Task<int> UpdateProductCategory(int Id, string Name, string Description)
        {
            return await _productsCategoriesRepository.Update(Id, Name, Description);
        }

        public async Task<int> DeleteProductCategory(int Id)
        {
            return await _productsCategoriesRepository.Delete(Id);
        }
    }
}
