using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZTestExtractor.Core.Models.Configurations;

namespace ZTestExtractor.MVC.Models.Configurations
{
    public class ConfigurationsViewModel
    {
        public IEnumerable<DatabaseSystems> DatabaseSystems { get; set; }

        public DatabaseConfigurationModel DatabaseConfigurationModel { get; set; }
    }
}