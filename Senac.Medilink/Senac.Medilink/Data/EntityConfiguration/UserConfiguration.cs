using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Senac.Medilink.Data.Entity.User;
using System.ComponentModel;

namespace Senac.Medilink.Data.EntityConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");

            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Email);

            builder
                .Property(x => x.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder
                .Property(x => x.Email)
                .HasColumnName("email")
                .IsRequired();

            builder
                .Property(x => x.Password)
                .HasColumnName("password")
                .IsRequired();

            builder
                .Property(x => x.UserType)
                .HasColumnName("userType")
                .IsRequired();

            builder
                .Property(p => p.CreatedAt)
                .HasColumnName("createdAt")
                .HasColumnType("datetime")
                .HasConversion(new ValueConverter<DateTime, DateTime>(
                    v => v.ToUniversalTime(),
                    v => DateTime.SpecifyKind(v, DateTimeKind.Utc))
                )
                .IsRequired();

            builder
                .Property(p => p.UpdatedAt)
                .HasColumnName("updatedAt")
                .HasColumnType("datetime")
                .HasConversion(new ValueConverter<DateTime, DateTime>(
                    v => v.ToUniversalTime(),
                    v => DateTime.SpecifyKind(v, DateTimeKind.Utc))
                )
                .IsRequired();

            builder
                .Property(x => x.Active)
                .HasColumnName("active")
                .HasDefaultValue(true)
                .IsRequired();
        }
    }
}
