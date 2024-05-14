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

        // Users
        public DbSet<User> Users { get; set; }
        public DbSet<Professional> Professionals { get; set; }
        public DbSet<Patient> Patients { get; set; }

        // Appointments
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Unit> Units { get; set; }

        // Professional items
        public DbSet<ProfessionalWorkSchedules> ProfessionalWorkSchedules { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
    }
}
