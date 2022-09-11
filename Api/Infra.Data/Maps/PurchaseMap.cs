using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Maps
{
    public class PurchaseMap : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.ToTable("Purchase");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("Id_Purchase")
                .UseIdentityColumn();

            builder.Property(x => x.PersonId)
               .HasColumnName("Id_Person");

            builder.Property(x => x.ProductId)
               .HasColumnName("Id_Product");

            builder.Property(x => x.Date)
               .HasColumnName("Date_Purchase");

            builder.HasOne(x => x.Person)
                .WithMany(x => x.Purchase);

            builder.HasOne(x => x.Product)
            .WithMany(x => x.Purchase);
        }
    }
}
