using Microsoft.EntityFrameworkCore;
using ProductApp.Core.Models;
using ProductApp.DataAccess.Entities;
using ProductApp.Core.Abstractions;

namespace ProductApp.DataAccess.Repositories
{
    public class ProductsCategoriesRepository : IProductsCategoriesRepository
    {
        private readonly ProductAppDbContext _context;

        public ProductsCategoriesRepository(ProductAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductCategory>> Get()
        {
            var productCategoriesEntities = await _context.ProductCategories
                .AsNoTracking()
                .ToListAsync();

            var productCategories = productCategoriesEntities
                .Select(pc => ProductCategory.Create(pc.Name, pc.Description, ProductCategoryUtils.GetId(pc, _context).Result))
                .ToList();

            return productCategories;
        }

        public async Task<int> Create(ProductCategory productCategory)
        {
            var productCategorEntity = new ProductCategoryEntity
            {
                Id = productCategory.Id,
                Name = productCategory.Name,
                Description = productCategory.Description,
            };

            await _context.AddAsync(productCategorEntity);
            await _context.SaveChangesAsync();

            return productCategorEntity.Id;
        }

        public async Task<int> Update(int Id, string Name, string Description)
        {
            int result = await _context.ProductCategories
                .Where(pc => pc.Id == Id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(pc => pc.Name, Name)
                    .SetProperty(pc => pc.Description, Description));

            return result;
        }

        public async Task<int> Delete(int Id)
        {
            int result = await _context.ProductCategories
                .Where(pc => pc.Id == Id)
                .ExecuteDeleteAsync();

            return result;
        }
    }
}
