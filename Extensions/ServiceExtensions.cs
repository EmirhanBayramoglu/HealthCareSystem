using HealthCareSystem.Repositories;
using HealthCareSystem.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

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


        //alttaki 4 işlemi diğer repo dosyaları içerisindeki fonksiyonları diğer repolar içerisinde de kullanmak için yaptım
        public static void ConfigurePatientToDoctorRepository(this IServiceCollection services) =>
            services.AddScoped<DoctorRepository>();

        public static void ConfigurePrescriptionToAppointmentRepository(this IServiceCollection services) =>
            services.AddScoped<PrescriptionRepository>();

        public static void ConfigurePatientToAppointmentRepository(this IServiceCollection services) =>
            services.AddScoped<PatientRepository>();

        public static void ConfigurePatientToRecordRepository(this IServiceCollection services) =>
            services.AddScoped<FamDocRecRepository>();

    }
}
