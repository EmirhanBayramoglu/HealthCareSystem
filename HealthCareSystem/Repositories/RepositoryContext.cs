using HealthCareSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HealthCareSystem.Repositories
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions opt) :
            base(opt)
        {

        }

        public DbSet<Prescription> Prescription { get; set; }
        public DbSet<Patients> Patients { get; set; }
        public DbSet<Medicines> Medicines { get; set; }
        public DbSet<Doctors> Doctors { get; set; }
        public DbSet<Appointments> Appointments { get; set; }
        public DbSet<FamillyDoctorRecord> Records { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Appointments>()
            .HasIndex(e => e.AppointmentId)
            .IsUnique(); // Değeri benzersiz yap

            modelBuilder.Entity<Prescription>()
            .HasIndex(e => e.PrescriptionId)
            .IsUnique(); // Değeri benzersiz yap

            // Örnek ilişkiler

            if (modelBuilder == null)
                throw new ArgumentNullException("modelBuilder");

            // for the other conventions, we do a metadata model loop
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // equivalent of modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
                entityType.SetTableName(entityType.DisplayName());

                // equivalent of modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
                entityType.GetForeignKeys()
                    .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
                    .ToList()
                    .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);
            }

            base.OnModelCreating(modelBuilder);

            
        }
    }
}
