using Finbuckle.MultiTenant;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Multitenant.Repository.SqlServer;
using Multitenant.Web.Middleware;
using System;

namespace Multitenant.Web.Extensions
{
    public static class ConfigureTenant
    {
        public static void ConfigureMultitenant(this IServiceCollection services)
        {
            services.AddMultiTenant()
                    .WithEFCoreStore<AppDbContext, AppTenantInfo>()
                    .WithStaticStrategy("ddmo");
        }
        public static void UseMultitenantTenant(this IApplicationBuilder app)
        {
            app.UseMultiTenant();
            app.UseMiddleware<TenantMiddleware>();
            SetupStore(app.ApplicationServices);
        }
         
        private static void SetupStore(IServiceProvider serviceProvider)
        {
            var scopeServices = serviceProvider.CreateScope().ServiceProvider;
            var store = scopeServices.GetRequiredService<IMultiTenantStore>();

            store.TryAddAsync(new TenantInfo("tenant-finbuckle-d043favoiaw", "ddmo", "DDMO LLC", "Server=(localdb)\\mssqllocaldb;Database=TenantA;Trusted_Connection=True;MultipleActiveResultSets=true", null)).Wait();
            store.TryAddAsync(new TenantInfo("tenant-initech-341ojadsfa", "skygen", "Skygen LLC", "Server=(localdb)\\mssqllocaldb;Database=TenantB;Trusted_Connection=True;MultipleActiveResultSets=true", null)).Wait();
        }
    }
}
