using Finbuckle.MultiTenant;
using Microsoft.EntityFrameworkCore;
using Multitenant.Models;

namespace Multitenant.Repository.SqlServer
{
    public class SampleContext : MultiTenantDbContext
    { 
        public SampleContext(TenantInfo tenantInfo) : base(tenantInfo) { }
        public SampleContext(TenantInfo tenantInfo, DbContextOptions<SampleContext> options) : base(tenantInfo, options) {  }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasKey(e => e.CustomerId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        //Uncomment to create database
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database={tenant};Trusted_Connection=True;MultipleActiveResultSets=true";
        //        optionsBuilder.UseSqlServer(connectionString.Replace("{tenant}", "Tenant"));
        //    }
        //}
    }
}