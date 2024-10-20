using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductApp.Core.Models;
using ProductApp.DataAccess.Entities;

namespace ProductApp.DataAccess.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                .ValueGeneratedOnAdd();

            builder.Property(b => b.Name)
                .HasMaxLength(Product.MAX_NAME_LENGTH)
                .IsRequired();

            builder.Property(b => b.Description)
                .HasMaxLength(Product.MAX_DESCRIPTION_LENGTH)
                .IsRequired();

            builder.Property(b => b.Price)
                .IsRequired();

            builder.Property(b => b.CategoryId)
                .IsRequired();

            builder.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);
        }
    }
}
