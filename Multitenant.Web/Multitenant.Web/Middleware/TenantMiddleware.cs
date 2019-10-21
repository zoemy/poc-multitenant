using Finbuckle.MultiTenant;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Multitenant.Repository.SqlServer;
using System.Threading.Tasks;

namespace Multitenant.Web.Middleware
{
    public class TenantMiddleware
    {
        private readonly RequestDelegate _next;

        public TenantMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var tenantInfo = httpContext.GetMultiTenantContext()?.TenantInfo;
            httpContext.RequestServices.GetService<IDbContextFactory>().TenantConnection = tenantInfo?.ConnectionString;           
            await _next(httpContext);
        }
    }
}
