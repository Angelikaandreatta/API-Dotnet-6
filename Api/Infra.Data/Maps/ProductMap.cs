using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Maps
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("product");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("idproduct")
                .UseIdentityColumn();

            builder.Property(x => x.Name)
                .HasColumnName("nameproduct");

            builder.Property(x => x.CodErp)
                .HasColumnName("coderpproduct");

            builder.Property(x => x.Price)
                .HasColumnName("priceproduct");

            builder.HasMany(x => x.Purchase)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductId);
        }
    }
}
