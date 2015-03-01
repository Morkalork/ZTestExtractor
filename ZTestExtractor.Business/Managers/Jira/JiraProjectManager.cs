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
    public class JiraProjectManager
    {
        public IEnumerable<JiraProjectDisplayModel> GetAllDisplayModels()
        {
            using (var session = SessionFactory.OpenSession())
            {
                return new JiraProjectRepository(session)
                    .GetAllDisplayModels();
            }
        }
    }
}
