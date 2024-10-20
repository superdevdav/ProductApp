using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductApp.DataAccess.Entities;
using ProductApp.Core.Models;

namespace ProductApp.DataAccess.Configurations
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategoryEntity>
    {
        public void Configure(EntityTypeBuilder<ProductCategoryEntity> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name)
                .HasMaxLength(ProductCategory.MAX_NAME_LENGTH)
                .IsRequired();

            builder.Property(b => b.Description)
                .HasMaxLength(ProductCategory.MAX_DESCRIPTION_LENGTH)
                .IsRequired();
        }
    }
}
