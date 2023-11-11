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
        public DbSet<Patients> Patients { get; set; }
        public DbSet<Medicines> Medicines { get; set; }
        public DbSet<Doctors> Doctors { get; set; }
        public DbSet<Appointments> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

            /* modelBuilder.Entity<Patients>()
                 .HasOne(p => p.Doctors)
                 .WithMany(d => d.Patients)
                 .HasForeignKey(p => p.DoctorId);

             modelBuilder.Entity<Appointments>()
                 .HasOne(a => a.Patients)
                 .WithMany(pa => pa.Appointments)
                 .HasForeignKey(a => a.TcNumber);

             modelBuilder.Entity<Appointments>()
                 .HasOne(a => a.Doctors)
                 .WithMany(d => d.Appointments)
                 .HasForeignKey(a => a.DoctorId);

             modelBuilder.Entity<Appointments>()
                 .HasOne(a => a.Prescription)
                 .WithMany(p => p.Appointments)
                 .HasForeignKey(a => a.PrescriptionId);

             // Diğer ilişkileri de buraya ekleyebilirsiniz.

             base.OnModelCreating(modelBuilder);*/
        }
    }
}
