using Microsoft.Extensions.DependencyInjection;
using Multitenant.Repository;
using Multitenant.Repository.SqlServer;

namespace Multitenant.Web.Extensions
{
    public static class ConfigureDependencyinjection
    {
        public static void ConfigureServices(this IServiceCollection services, string connectionTemplate) {           
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IDbContextFactory, DbContextFactory>();
        }
    }
}
