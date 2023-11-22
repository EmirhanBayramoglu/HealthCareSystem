using HealthCareSystem.Repositories;
using HealthCareSystem.Repositories.Contracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace HealthCareSystem.Extensions
{
    public static class ServiceExtensions
    {

        public static void ConfigureSqlContext(this IServiceCollection services,
            IConfiguration configuration) => services.AddDbContext<RepositoryContext>(options =>
                                                options.UseSqlServer(configuration.GetConnectionString("HealthConnetion")));

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

        public static void ConfigureRecordRepository(this IServiceCollection services) =>
            services.AddScoped<IFamDocRecRepository, FamDocRecRepository>();

        public static void ConfigurePrescriptionListRepository(this IServiceCollection services) =>
            services.AddScoped<IPrescriptionListRepository, PrescriptionListRepository>();

        public static void ConfigurePatientToDoctorRepository(this IServiceCollection services) =>
            services.AddScoped<DoctorRepository>();

        public static void ConfigurePatientToRecordRepository(this IServiceCollection services) =>
            services.AddScoped<FamDocRecRepository>();

    }
}
