using Microsoft.EntityFrameworkCore;

namespace Multitenant.Repository.SqlServer
{
    public class DbContextFactory : IDbContextFactory
    {
        public string TenantConnection { get; set; }

        public DbContextFactory() { }

        public CRMContext Create()
        {
            CRMContext context = null;

            if (!string.IsNullOrWhiteSpace(TenantConnection))
            {
                var dbContextOptionsBuilder = new DbContextOptionsBuilder();
                dbContextOptionsBuilder.UseSqlServer(TenantConnection);
                context = new CRMContext(dbContextOptionsBuilder.Options);
            }

            return context;
        }
    }
}