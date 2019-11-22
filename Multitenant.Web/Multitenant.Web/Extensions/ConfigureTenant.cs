using Finbuckle.MultiTenant;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Multitenant.Repository.SqlServer;
using System;

namespace Multitenant.Web.Extensions
{
    public static class ConfigureTenant
    {
        public static void ConfigureMultitenant(this IServiceCollection services)
        {
            services.AddMultiTenant()
                    .WithEFCoreStore<AppDbContext, AppTenantInfo>()
                    .WithStaticStrategy("tenant-a");
            services.AddDbContext<SampleContext>();
        }
        public static void UseMultitenantTenant(this IApplicationBuilder app)
        {
            app.UseMultiTenant();
            SetupStore(app.ApplicationServices);
        }
         
        private static void SetupStore(IServiceProvider serviceProvider)
        {
            var scopeServices = serviceProvider.CreateScope().ServiceProvider;
            var store = scopeServices.GetRequiredService<IMultiTenantStore>();

            store.TryAddAsync(new TenantInfo("tenant-a-d043favoiaw", "tenant-a", "Tenant LLC", "Server=(localdb)\\mssqllocaldb;Database=TenantA;Trusted_Connection=True;MultipleActiveResultSets=true", null)).Wait();
            store.TryAddAsync(new TenantInfo("tenant-b-341ojadsfa", "tenant-b", "Tenant LLC", "Server=(localdb)\\mssqllocaldb;Database=TenantB;Trusted_Connection=True;MultipleActiveResultSets=true", null)).Wait();
        }
    }
}
