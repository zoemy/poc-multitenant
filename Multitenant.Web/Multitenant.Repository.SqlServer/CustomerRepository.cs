using Multitenant.Models;
using System.Collections.Generic;
using System.Linq;

namespace Multitenant.Repository.SqlServer
{
    public class CustomerRepository : ICustomerRepository
    {
        private CRMContext context;

        public CustomerRepository(IDbContextFactory dbContextFactory)
        {
            this.context = dbContextFactory.Create();
        }

        public List<Customer> GetAllCustomers()
        {
            return this.context?.Customers.ToList();
        }
    }
}