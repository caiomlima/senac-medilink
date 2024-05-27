using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Senac.Medilink.Data.Entity;
using Senac.Medilink.Data.Entity.User;

namespace Senac.Medilink.Data.EntityConfiguration
{
    public class ProfessionalConfiguration : IEntityTypeConfiguration<Professional>
    {
        public void Configure(EntityTypeBuilder<Professional> builder)
        {
            builder.ToTable("professional");

            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder
                .Property(x => x.Name)
                .HasColumnName("name")
                .IsRequired();

            builder
                .Property(x => x.Document)
                .HasColumnName("document")
                .IsRequired();

            builder
                .Property(p => p.CreatedAt)
                .HasColumnName("createdAt")
                .HasColumnType("datetime")
                .IsRequired();

            builder
                .Property(p => p.UpdatedAt)
                .HasColumnName("updatedAt")
                .HasColumnType("datetime")
                .IsRequired();

            builder
                .Property(x => x.Active)
                .HasColumnName("active")
                .HasDefaultValue(true)
                .IsRequired();

            builder
                .HasOne<User>(x => x.User)
                .WithOne(x => x.Professional)
                .HasForeignKey<Professional>(x => x.Id)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasMany(x => x.Schedules)
                .WithOne(x => x.Professional)
                .HasForeignKey(x => x.ProfessionalId);

            builder
                .HasMany(x => x.ProfessionalSpecialties)
                .WithOne(x => x.Professional)
                .HasForeignKey(x => x.ProfessionalId);
        }
    }
}
