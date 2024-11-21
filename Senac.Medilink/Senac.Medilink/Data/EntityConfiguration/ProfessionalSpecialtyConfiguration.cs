using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Senac.Medilink.Data.Entity;

namespace Senac.Medilink.Data.EntityConfiguration;

public class ProfessionalSpecialtyConfiguration : IEntityTypeConfiguration<ProfessionalSpecialty>
{
    public void Configure(EntityTypeBuilder<ProfessionalSpecialty> builder)
    {
        builder.ToTable("professionalSpecialty");

        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.ProfessionalId);
        builder.HasIndex(x => x.UnitId);
        builder.HasIndex(x => new { x.ProfessionalId, x.UnitId });

        builder
            .Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd()
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
            .HasOne(x => x.Specialty)
            .WithMany(x => x.ProfessionalSpecialties)
            .HasForeignKey(x => x.SpecialtyId);

        builder
            .HasOne(x => x.Professional)
            .WithMany(x => x.ProfessionalSpecialties)
            .HasForeignKey(x => x.ProfessionalId);

        builder
            .HasOne(x => x.Unit)
            .WithMany(x => x.ProfessionalSpecialties)
            .HasForeignKey(x => x.UnitId);
    }
}
