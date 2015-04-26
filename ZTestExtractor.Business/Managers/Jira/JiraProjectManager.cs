using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTestExtractor.Data.Entities.Jira;
using ZTestExtractor.Data.Database;
using ZTestExtractor.Data.Repositories.Jira;
using ZTestExtractor.Models.Jira;

namespace ZTestExtractor.Business.Managers.Jira
{
    public class JiraProjectManager : BaseManager
    {
        public IEnumerable<JiraProjectDisplayModel> GetAllDisplayModels()
        {
            var repository = GetRepository<JiraProjectRepository>();
            return repository
                .GetAllDisplayModels();
        }
    }
}
