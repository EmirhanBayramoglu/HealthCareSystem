using HealthCareSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthCareSystem.Repositories
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions opt) :
            base(opt)
        {

        }

        public DbSet<Prescription> Prescription { get; set; }
        public DbSet<Patients> Patient { get; set; }
        public DbSet<Medicines> Medicine { get; set; }
        public DbSet<Doctors> Doctor { get; set; }
        public DbSet<Appointments> Appointment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Örnek ilişkiler
            modelBuilder.Entity<Prescription>()
                .HasOne(p => p.Medicine)
                .WithMany(pa => pa.Prescription)
                .HasForeignKey(p => p.MedicineId);

            modelBuilder.Entity<Patients>()
                .HasOne(p => p.Doctor)
                .WithMany(d => d.Patient)
                .HasForeignKey(p => p.DoctorId);

            modelBuilder.Entity<Appointments>()
                .HasOne(a => a.Patient)
                .WithMany(pa => pa.Appointment)
                .HasForeignKey(a => a.PatientId);

            modelBuilder.Entity<Appointments>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Appointment)
                .HasForeignKey(a => a.DoctorId);

            modelBuilder.Entity<Appointments>()
                .HasOne(a => a.prescription)
                .WithMany(d => d.Appointment)
                .HasForeignKey(a => a.prescriptionId);

            // Diğer ilişkileri de buraya ekleyebilirsiniz.

            base.OnModelCreating(modelBuilder);
        }
    }
}
