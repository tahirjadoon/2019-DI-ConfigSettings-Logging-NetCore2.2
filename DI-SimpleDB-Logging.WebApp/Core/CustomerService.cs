using DI_SimpleDB_Logging.WebApp.Models;
using System.Collections.Generic;

namespace DI_SimpleDB_Logging.WebApp.Core
{
    public class CustomerService : ICustomerService
    {
        private IRepository<CustomerViewModel> CustomerRepository { get; set; }

        public CustomerService(IRepository<CustomerViewModel> customerRepository)
        {
            CustomerRepository = customerRepository;
        }

        public IEnumerable<CustomerViewModel> GetCustomers()
        {
            var commandText = "SELECT Id, Name, Address FROM Customer";
            var customers = CustomerRepository.Get(commandText, Mappers.GetCustomer);
            return customers;
        }
    }
}
