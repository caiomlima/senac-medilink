using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Senac.Medilink.Data.Entity;

namespace Senac.Medilink.Data.EntityConfiguration;

public class ExamSpecialtyConfiguration : IEntityTypeConfiguration<ExamSpecialty>
{
    public void Configure(EntityTypeBuilder<ExamSpecialty> builder)
    {
        builder.ToTable("examSpecialty");

        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.UnitId);
        builder.HasIndex(x => new { x.SpecialtyId, x.UnitId });

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
            .WithMany(x => x.ExamSpecialties)
            .HasForeignKey(x => x.SpecialtyId);

        builder
            .HasOne(x => x.Unit)
            .WithMany(x => x.ExamSpecialties)
            .HasForeignKey(x => x.UnitId);
    }
}
