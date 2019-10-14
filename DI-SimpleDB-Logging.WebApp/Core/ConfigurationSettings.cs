using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DI_SimpleDB_Logging.WebApp.Core
{
    public class ConfigurationSettings : IConfigurationSettings
    {
        public string ConnectionString { get; set; }
    }
}
