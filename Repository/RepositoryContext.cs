using HealthCareSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models.Auth;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace HealthCareSystem.Repositories
{
    public class RepositoryContext : IdentityDbContext<User>
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
        public DbSet<PrescriptionLists> PrescriptionList { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //unique değer için ayarlama
            modelBuilder.Entity<Prescription>()
            .Property(p => p.PrescriptionId)
            .HasDefaultValueSql("NEWID()"); 

            modelBuilder.Entity<Appointments>()
            .Property(e => e.AppointmentType)
            .IsRequired()
            .HasMaxLength(10);

            //AppointmentType özelliğinin sadece "General" ve "Family" değerlerini alabilmesini sağlar
            modelBuilder.Entity<Appointments>()
            .HasCheckConstraint("CK_AppointmentType", "[AppointmentType] IN ('General', 'Family')");

            modelBuilder.Entity<Appointments>()
            .Property(e => e.AppoStatus)
            .IsRequired()
            .HasMaxLength(10);

            //AppoStatus özelliğinin sadece 'Waiting', 'Active', 'Ended', 'Canceled' değerlerini alabilmesini sağlar
            modelBuilder.Entity<Appointments>()
            .HasCheckConstraint("CK_AppoStatus", "[AppoStatus] IN ('Waiting', 'Active', 'Ended', 'Canceled')");

            modelBuilder.Entity<Doctors>()
            .Property(e => e.DoctorType)
            .IsRequired()
            .HasMaxLength(10);
            //CK_DoctorType özelliğinin sadece "General" ve "Family" değerlerini alabilmesini sağlar
            modelBuilder.Entity<Doctors>()
            .HasCheckConstraint("CK_DoctorType", "[DoctorType] IN ('General', 'Family')");

            // Örnek ilişkiler

            if (modelBuilder == null)
                throw new ArgumentNullException("modelBuilder");

            // for the other conventions, we do a metadata model loop
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // equivalent of modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
                entityType.SetTableName(entityType.DisplayName());

                // equivalent of modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
                //Fk bağlantılarında bir verinin silinmesi durumunda sorun çıkmaması için eklenen özellik
                entityType.GetForeignKeys()
                    .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
                    .ToList()
                    .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);
            }

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
