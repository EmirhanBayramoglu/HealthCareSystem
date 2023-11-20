using HealthCareSystem.Repositories;
using HealthCareSystem.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace HealthCareSystem.Extensions
{
    public static class ServiceExtensions
    {

        public static void ConfigureSqlContext(this IServiceCollection services,
            IConfiguration configuration) => services.AddDbContext<RepositoryContext>(options =>
                                                options.UseSqlServer(configuration.GetConnectionString("HealthCareConnetion")));

        public static void ConfigureAppointRepository(this IServiceCollection services) =>
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();

        public static void ConfigureDoctorRepository(this IServiceCollection services) =>
            services.AddScoped<IDoctorRepository, DoctorRepository>();

        public static void ConfigureMedicineRepository(this IServiceCollection services) =>
            services.AddScoped<IMedicineRepository, MedicineRepository>();

        public static void ConfigurePatientRepository(this IServiceCollection services) =>
            services.AddScoped<IPatientRepository, PatientRepository>();

        public static void ConfigurePrescriptRepository(this IServiceCollection services) =>
            services.AddScoped<IPrescriptionRepository, PrescriptionRepository>();


    }
}
