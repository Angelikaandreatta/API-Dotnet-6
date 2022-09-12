using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Maps
{
    public class PersonMap : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("person");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("idperson")
                .UseIdentityColumn();

            builder.Property(x => x.Name)
                .HasColumnName("nameperson");

            builder.Property(x => x.Document)
                .HasColumnName("documentperson");

            builder.Property(x => x.Phone)
                .HasColumnName("phoneperson");

            builder.HasMany(x => x.Purchase)
                .WithOne(x => x.Person)
                .HasForeignKey(x => x.PersonId);
        }
    }
}
