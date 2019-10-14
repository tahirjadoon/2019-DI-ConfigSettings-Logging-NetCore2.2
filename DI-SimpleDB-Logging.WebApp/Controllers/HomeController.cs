using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DI_SimpleDB_Logging.WebApp.Models;
using DI_SimpleDB_Logging.WebApp.Core;
using Microsoft.Extensions.Logging;

namespace DI_SimpleDB_Logging.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private ICustomerService CustomerService { get; set; }
        private readonly ILogger _logger;

        public HomeController(ICustomerService customerService, ILogger<HomeController> logger)
        {
            CustomerService = customerService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var customers = CustomerService.GetCustomers();
            _logger.LogWarning($"We only found {customers.Count()} customers");
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
