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

        public override bool Equals(object obj)
        {
            DatabaseConfigurationModel model = obj as DatabaseConfigurationModel;
            if (model == null)
            {
                return false;
            }

            return this.ServerName.Equals(model.ServerName) 
                && this.DatabaseName.Equals(model.DatabaseName)
                && this.DatabaseSystem.Equals(model.DatabaseSystem);
        }

        public override int GetHashCode()
        {
            return (this.ServerName + this.DatabaseName + DatabaseSystem.ToString()).GetHashCode();
        }
    }
}
