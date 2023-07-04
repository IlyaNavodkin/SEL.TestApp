using Microsoft.Extensions.DependencyInjection;
using SEL.BLL.Services;
using SEL.BLL.Services.Interfaces;
using SEL.DAL.Repositories;
using SEL.DAL.Repositories.Interfaces;

namespace SEL.BLL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBll(this IServiceCollection services)
        {
            services.AddTransient<IWorkerService, WorkerService>();
            services.AddTransient<IDepartmentService, DepartmentService>();
            services.AddTransient<IDepartmentHierarchyService, DepartmentHierarchyServiceService>();

            return services;
        }
    }
}