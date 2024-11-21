using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Senac.Medilink.Data.Entity;

namespace Senac.Medilink.Data.EntityConfiguration;

public class UnitConfiguration : IEntityTypeConfiguration<Unit>
{
    public void Configure(EntityTypeBuilder<Unit> builder)
    {
        builder.ToTable("unit");

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
            .Property(x => x.Description)
            .HasColumnName("description");

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
    }
}
