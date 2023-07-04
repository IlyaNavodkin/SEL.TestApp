using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SEL.DAL.Repositories;
using SEL.DAL.Repositories.Interfaces;

namespace SEL.DAL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDal(this IServiceCollection services,
            IConfiguration configuration)
        {
            var identityConnectionString = configuration["DbConnection"];

            services.AddScoped<IWorkerRepository>(opt => new WorkerRepository(identityConnectionString));
            services.AddScoped<IDepartmentRepository>(opt => new DepartmentRepository(identityConnectionString));

            return services;
        }
    }
}