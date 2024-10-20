﻿namespace ProductApp.DataAccess.Entities
{
    public class ProductEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public ProductCategoryEntity Category { get; set; } = null!;
    }
}
