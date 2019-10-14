using System.Collections.Generic;
using DI_SimpleDB_Logging.WebApp.Models;

namespace DI_SimpleDB_Logging.WebApp.Core
{
    public interface ICustomerService
    {
        IEnumerable<CustomerViewModel> GetCustomers();
    }
}