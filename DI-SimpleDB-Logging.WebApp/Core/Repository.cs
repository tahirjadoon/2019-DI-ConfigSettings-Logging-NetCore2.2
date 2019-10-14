using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DI_SimpleDB_Logging.WebApp.Core
{
    public class Repository<T> : IRepository<T> 
    {
        public IConfigurationSettings ConfigurationSettings { get; set; }
        private readonly ILogger _logger;

        public Repository(IConfigurationSettings configurationSettings, ILogger<Repository<T>> logger)
        {
            ConfigurationSettings = configurationSettings;
            _logger = logger;
        }

        public IEnumerable<T> Get(string commandText, Func<SqlDataReader, T> mappingFunction)
        {
            var list = new List<T>();
            _logger.LogWarning("An inefficient SELECT statement was used");
            using(SqlConnection connection = new SqlConnection(ConfigurationSettings.ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(commandText, connection))
                {
                    cmd.CommandType = CommandType.Text;
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(mappingFunction(reader));
                        }
                    }
                }
            }
            return list;
        }
    }
}
