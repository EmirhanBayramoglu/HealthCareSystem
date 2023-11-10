using HealthCareSystem.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HealthCareSystem.Extensions
{
    public static class ServiceExtensions
    {

        public static void ConfigureSqlContext(this IServiceCollection services,
            IConfiguration configuration) => services.AddDbContext<RepositoryContext>(options =>
                                                options.UseSqlServer(configuration.GetConnectionString("HealthCareConnetion")));


    }
}
