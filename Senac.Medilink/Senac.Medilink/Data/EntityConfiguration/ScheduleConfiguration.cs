using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Senac.Medilink.Data.Entity;

namespace Senac.Medilink.Data.EntityConfiguration
{
    public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.ToTable("schedule");

            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder
                .Property(p => p.Date)
                .HasColumnName("date")
                .HasColumnType("datetime")
                .HasConversion(new ValueConverter<DateTime, DateTime>(
                    v => v.ToUniversalTime(),
                    v => DateTime.SpecifyKind(v, DateTimeKind.Utc))
                )
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
                .HasColumnName("result");

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
        }
    }
}
