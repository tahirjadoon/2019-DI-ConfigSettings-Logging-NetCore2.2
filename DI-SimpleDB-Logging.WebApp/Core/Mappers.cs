using DI_SimpleDB_Logging.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DI_SimpleDB_Logging.WebApp.Core
{
    public static class Mappers
    {
        public static CustomerViewModel GetCustomer(SqlDataReader reader)
        {
            var customer = new CustomerViewModel()
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Address = reader.GetString(2)
            };
            return customer;
        }
    }
}
