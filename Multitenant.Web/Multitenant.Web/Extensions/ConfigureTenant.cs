using Microsoft.AspNetCore.Builder;
using Multitenant.Web.Middleware;

namespace Multitenant.Web.Extensions
{
    public static class ConfigureTenant
    {
        public static IApplicationBuilder UseTenant(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<TenantMiddleware>();
        }
    }
}
