using Microsoft.EntityFrameworkCore;
using Multitenant.Models;

namespace Multitenant.Repository.SqlServer
{
    public class CRMContext : DbContext
    {
        private DbContextOptions contextOptions;

        public CRMContext()
            : base()
        {
        }

        public CRMContext(DbContextOptions options)
            : base(options)
        {
            this.contextOptions = options;
        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasKey(e => e.CustomerId);
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