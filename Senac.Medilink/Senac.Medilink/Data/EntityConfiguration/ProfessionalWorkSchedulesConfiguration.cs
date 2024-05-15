using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Senac.Medilink.Data.Entity;

namespace Senac.Medilink.Data.EntityConfiguration
{
    public class ProfessionalWorkSchedulesConfiguration : IEntityTypeConfiguration<ProfessionalWorkSchedules>
    {
        public void Configure(EntityTypeBuilder<ProfessionalWorkSchedules> builder)
        {
            builder.ToTable("professionalWorkSchedules");

            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder
                .Property(x => x.DayOfWeek)
                .HasColumnName("dayOfWeek")
                .HasConversion<int>()
                .IsRequired();

            builder
                .Property(x => x.StartTime)
                .HasColumnName("startTime")
                .IsRequired();

            builder
                .Property(x => x.EndTime)
                .HasColumnName("endTime")
                .IsRequired();

            builder
                .HasOne(x => x.Professional)
                .WithMany(x => x.WorkSchedules)
                .HasForeignKey(x => x.ProfessionalId);

            builder
                .HasOne(x => x.Unit)
                .WithMany(x => x.WorkSchedules)
                .HasForeignKey(x => x.UnitId);
        }
    }
}
