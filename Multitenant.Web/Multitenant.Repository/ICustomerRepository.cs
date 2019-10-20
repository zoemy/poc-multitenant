using Multitenant.Models;
using System.Collections.Generic;

namespace Multitenant.Repository
{
    public interface ICustomerRepository
    {
        List<Customer> GetAllCustomers();
    }
}