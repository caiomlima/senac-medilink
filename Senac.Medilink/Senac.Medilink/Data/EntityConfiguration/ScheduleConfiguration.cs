using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Senac.Medilink.Data.Entity;

namespace Senac.Medilink.Data.EntityConfiguration;

public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
{
    public void Configure(EntityTypeBuilder<Schedule> builder)
    {
        builder.ToTable("schedule");

        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.ProfessionalId);
        builder.HasIndex(x => x.PatientId);
        builder.HasIndex(x => x.UnitId);
        builder.HasIndex(x => new { x.StartDate, x.EndDate });
        builder.HasIndex(x => x.Type);
        builder.HasIndex(x => new { x.ProfessionalId, x.Status });
        builder.HasIndex(x => x.Active);

        builder
            .Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder
            .Property(p => p.StartDate)
            .HasColumnName("startDate")
            .HasColumnType("datetime")
            .IsRequired();

        builder
            .Property(p => p.EndDate)
            .HasColumnName("endDate")
            .HasColumnType("datetime")
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
            .Property(x => x.Type)
            .HasColumnName("type")
            .HasConversion<int>()
            .IsRequired();

        builder
            .Property(x => x.Status)
            .HasColumnName("status")
            .HasConversion<int>()
            .IsRequired();

        builder
            .Property(x => x.Form)
            .HasColumnName("form")
            .HasConversion<int>()
            .IsRequired();

        builder
            .Property(x => x.Result)
            .HasColumnName("result")
            .HasDefaultValue(null);

        builder
            .Property(x => x.Active)
            .HasColumnName("active")
            .HasDefaultValue(true)
            .IsRequired();

        builder
            .HasOne(x => x.Patient)
            .WithMany(x => x.Schedules)
            .HasForeignKey(x => x.PatientId);

        builder
            .HasOne(x => x.Professional)
            .WithMany(x => x.Schedules)
            .HasForeignKey(x => x.ProfessionalId);

        builder
            .HasOne(x => x.Unit)
            .WithMany(x => x.Schedules)
            .HasForeignKey(x => x.UnitId);

        builder
            .HasOne(x => x.Specialty)
            .WithMany(x => x.Schedules)
            .HasForeignKey(x => x.SpecialtyId);
    }
}
