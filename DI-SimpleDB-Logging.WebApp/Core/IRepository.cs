using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DI_SimpleDB_Logging.WebApp.Core
{
    public interface IRepository<T>
    {
        IConfigurationSettings ConfigurationSettings { get; set; }

        IEnumerable<T> Get(string commandText, Func<SqlDataReader, T> mappingFunction);
    }
}