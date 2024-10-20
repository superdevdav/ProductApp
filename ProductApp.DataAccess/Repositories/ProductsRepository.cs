using Microsoft.EntityFrameworkCore;
using ProductApp.Core.Models;
using ProductApp.DataAccess.Entities;
using ProductApp.Core.Abstractions;

namespace ProductApp.DataAccess.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ProductAppDbContext _context;

        public ProductsRepository(ProductAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> Get()
        {
            var productEntities = await _context.Products
                .AsNoTracking()
                .ToListAsync();

            var products = productEntities
                .Select(p => Product.Create(p.Name, p.Description, p.Price, p.CategoryId, ProductUtils.GetId(p, _context).Result))
                .ToList();

            return products;
        }

        public async Task<int> Create(Product product)
        {
            var productEntity = new ProductEntity
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CategoryId = product.CategoryId
            };

            await _context.Products.AddAsync(productEntity);
            await _context.SaveChangesAsync();

            return productEntity.Id;
        }

        public async Task<int> Update(int Id, string Name, string Description, decimal Price)
        {
            int result = await _context.Products
                .Where(p => p.Id == Id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(p => p.Name, p => Name)
                    .SetProperty(p => p.Description, p => Description)
                    .SetProperty(p => p.Price, p => Price));

            return result;
        }

        public async Task<int> Delete(int Id)
        {
            int result = await _context.Products
                .Where(p => p.Id == Id)
                .ExecuteDeleteAsync();

            return result;
        }
    }
}
