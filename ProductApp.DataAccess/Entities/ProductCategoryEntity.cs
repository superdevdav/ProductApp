namespace ProductApp.DataAccess.Entities
{
    public class ProductCategoryEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public ICollection<ProductEntity> Products { get; set; } = new List<ProductEntity>();
    }
}
