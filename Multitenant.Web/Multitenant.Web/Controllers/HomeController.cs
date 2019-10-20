using Microsoft.AspNetCore.Mvc;
using Multitenant.Models;
using Multitenant.Repository;
using Multitenant.Web.Models;
using System.Collections.Generic;
using System.Diagnostics;

namespace Multitenant.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustomerRepository _repository;

        public HomeController(ICustomerRepository repository)
        {
           _repository = repository;
        }
        public IActionResult Index()
        {
            List<Customer> customers =  _repository.GetAllCustomers();             
            return View(customers);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
