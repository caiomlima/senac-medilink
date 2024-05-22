using Microsoft.EntityFrameworkCore;
using Senac.Medilink.Data.Entity;
using Senac.Medilink.Data.Entity.User;

namespace Senac.Medilink.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Professional> Professionals { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<ProfessionalSpecialty> ProfessionalSpecialties { get; set; }
        public DbSet<ProfessionalWorkSchedules> ProfessionalWorkSchedules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
        }
    }
}
