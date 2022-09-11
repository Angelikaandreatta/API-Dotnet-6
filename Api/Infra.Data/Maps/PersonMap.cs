using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Maps
{
    public class PersonMap : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Person");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("Id_Person")
                .UseIdentityColumn();

            builder.Property(x => x.Name)
                .HasColumnName("Name_Person");

            builder.Property(x => x.Document)
                .HasColumnName("Document_Person");

            builder.Property(x => x.Phone)
                .HasColumnName("Phone_Person");

            builder.HasMany(x => x.Purchase)
                .WithOne(x => x.Person)
                .HasForeignKey(x => x.PersonId);
        }
    }
}
