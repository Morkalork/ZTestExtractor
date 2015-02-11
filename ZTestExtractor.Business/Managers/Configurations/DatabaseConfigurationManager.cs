using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTestExtractor.Core.Models.Configurations;
using ZTestExtractor.Core.Models.General;
using ZTestExtractor.Repositories.System;

namespace ZTestExtractor.Business.Managers.Configurations
{
    public class DatabaseConfigurationManager
    {
        public static readonly string FileName = "DatabaseConfiguration.json";

        public Result Save(DatabaseConfigurationModel model)
        {
            if(model == null)
            {
                throw new ArgumentNullException("model");
            }

            var result = ValidateDatabaseConfigurationModel(model);

            if(result.Messages.Count() <= 0)
            {
                var fileRepository = new FileRepository();

                //TODO: Perhaps this should be encrypted, could be important information :p
                fileRepository.SaveModelToFile(model, FileName);

                result.Messages.Add("Successfully saved configuration!");
                result.IsSuccess = true;
            }

            return result;
        }

        public DatabaseConfigurationModel Load()
        {
            var model = new FileRepository()
                .LoadModelFromFile<DatabaseConfigurationModel>(FileName);

            if(model == null)
            {
                model = new DatabaseConfigurationModel();
            }

            return model;
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

            if(model.DatabaseSystem == DatabaseSystems.Unknown)
            {
                result.Messages.Add("Invalid database system");
            }

            return result;
        }
    }
}
