using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTestExtractor.Core.Models.Configurations;
using ZTestExtractor.Core.Models.General;

namespace ZTestExtractor.Business.Managers.Configurations
{
    public class DatabaseConfigurationManager
    {
        public Result Save(DatabaseConfigurationModel model)
        {
            if(model == null)
            {
                throw new ArgumentNullException("model");
            }

            var result = ValidateDatabaseConfigurationModel(model);

            if(result.Messages.Count() <= 0)
            {

            }

            return result;
        }

        private Result ValidateDatabaseConfigurationModel(DatabaseConfigurationModel model)
        {
            var result = new Result();

            if (string.IsNullOrEmpty(model.ServerName))
            {
                result.Messages.Add("Invalid server name");
            }

            if (string.IsNullOrEmpty(model.DatabaseName))
            {
                result.Messages.Add("Invalid database name");
            }

            if (string.IsNullOrEmpty(model.Username))
            {
                result.Messages.Add("Invalid username");
            }

            if (string.IsNullOrEmpty(model.Password))
            {
                result.Messages.Add("Invalid password");
            }
            return result;
        }
    }
}
