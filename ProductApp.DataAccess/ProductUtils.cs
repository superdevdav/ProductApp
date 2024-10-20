using Microsoft.EntityFrameworkCore;
using ProductApp.DataAccess.Entities;

namespace ProductApp.DataAccess
{
    public class ProductUtils
    {
        public static async Task<int> GetId(ProductEntity productEntity, ProductAppDbContext context)
        {
            var id = await context.Products
                .Where(p => p.Name == productEntity.Name)
                .Select(p => p.Id)
                .FirstOrDefaultAsync();

            return id;  // Вернем Id или 0, если продукт не найден
        }
    }
}
