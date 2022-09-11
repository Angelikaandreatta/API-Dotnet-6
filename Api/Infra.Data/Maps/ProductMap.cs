using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Maps
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("Id_Product")
                .UseIdentityColumn();

            builder.Property(x => x.Name)
                .HasColumnName("Name_Product");

            builder.Property(x => x.CodErp)
                .HasColumnName("CodErp_Product");

            builder.Property(x => x.Price)
                .HasColumnName("Price_Product");

            builder.HasMany(x => x.Purchase)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductId);
        }
    }
}
