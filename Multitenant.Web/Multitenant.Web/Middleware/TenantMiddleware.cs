using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Multitenant.Repository.SqlServer;
using System;
using System.Linq;
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
            //var tenantInfo = httpContext.GetMultiTenantContext()?.TenantInfo;
            //httpContext.RequestServices.GetService<IDbContextFactory>().TenantName = tenantInfo?.ConnectionString;
            string[] urlParts = null;
#if DEBUG
            urlParts = httpContext.Request.Path.Value.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
#else
                        urlParts = httpContext.Request.Host.Host.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
#endif

            if (urlParts != null && urlParts.Any())
            {
                httpContext.RequestServices.GetService<IDbContextFactory>().TenantName = urlParts[0];
            }

            await _next(httpContext);
        }
    }
}
