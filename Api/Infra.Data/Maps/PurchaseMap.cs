using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Maps
{
    public class PurchaseMap : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.ToTable("purchase");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("idpurchase")
                .UseIdentityColumn();

            builder.Property(x => x.PersonId)
               .HasColumnName("idperson");

            builder.Property(x => x.ProductId)
               .HasColumnName("idproduct");

            builder.Property(x => x.Date)
               .HasColumnName("datepurchase");

            builder.HasOne(x => x.Person)
                .WithMany(x => x.Purchase);

            builder.HasOne(x => x.Product)
            .WithMany(x => x.Purchase);
        }
    }
}
