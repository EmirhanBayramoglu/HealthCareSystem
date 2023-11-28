using HealthCareSystem.Repositories;
using HealthCareSystem.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Models.Auth;
using Microsoft.AspNetCore.Identity;
using Repository;
using Repository.Contracts;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;

namespace HealthCareSystem.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("HealthConnetion"),
                    b => b.MigrationsAssembly("HealthCareSystem")));
        }


        public static void ConfigureAppointRepository(this IServiceCollection services) =>
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();

        public static void ConfigureDoctorRepository(this IServiceCollection services) =>
            services.AddScoped<IDoctorRepository, DoctorRepository>();

        public static void ConfigureMedicineRepository(this IServiceCollection services) =>
            services.AddScoped<IMedicineRepository, MedicineRepository>();

        public static void ConfigurePatientRepository(this IServiceCollection services) =>
            services.AddScoped<IPatientRepository, PatientRepository>();

        public static void ConfigureAuthenticationSystem(this IServiceCollection services) =>
            services.AddScoped<IAuthenticationService, AuthenticationManager>();

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

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentity<User, IdentityRole>(x =>
            {
                x.Password.RequireDigit = true;
                x.Password.RequireLowercase = false;
                x.Password.RequireUppercase = false;
                x.Password.RequireNonAlphanumeric = false;
                x.Password.RequiredLength = 6;

                x.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<RepositoryContext>()
                .AddDefaultTokenProviders();
        }

        public static void ConfigureJWT(this IServiceCollection services,
            IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings["secretKey"];

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["validIssuer"],
                    ValidAudience = jwtSettings["validAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                }
            );
        }

    }
}
