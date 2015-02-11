using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTestExtractor.Core.Models.Configurations
{
    public class DatabaseConfigurationModel
    {
        public string ServerName { get; set; }

        public string DatabaseName { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public DatabaseSystems DatabaseSystem { get; set; }
    }
}
