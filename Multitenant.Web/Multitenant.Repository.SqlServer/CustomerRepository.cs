using Multitenant.Models;
using System.Collections.Generic;
using System.Linq;

namespace Multitenant.Repository.SqlServer
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly SampleContext _context;

        public CustomerRepository(SampleContext context) {
            _context = context;
        }

        public List<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }
    }
}