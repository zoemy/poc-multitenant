using Finbuckle.MultiTenant.Stores;
using Microsoft.EntityFrameworkCore;

namespace Multitenant.Repository.SqlServer
{
    public class AppDbContext : EFCoreStoreDbContext<AppTenantInfo>
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("tenant-store");
            base.OnConfiguring(optionsBuilder);
        }
    }
}