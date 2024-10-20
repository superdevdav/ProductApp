using Microsoft.EntityFrameworkCore;
using ProductApp.DataAccess.Entities;

namespace ProductApp.DataAccess
{
    public class ProductCategoryUtils
    {
        public static async Task<int> GetId(ProductCategoryEntity productCategoryEntity, ProductAppDbContext context)
        {
            var id = await context.ProductCategories
                .Where(p => p.Name == productCategoryEntity.Name)
                .Select(p => p.Id)
                .FirstOrDefaultAsync();

            return id;  // Вернем Id или 0, если продукт не найден
        }
    }
}
