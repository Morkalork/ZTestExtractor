using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTestExtractor.Core.Entities.Jira;
using ZTestExtractor.Data.Database;
using ZTestExtractor.Data.Repositories.Jira;

namespace ZTestExtractor.Business.Managers.Jira
{
    public class ProjectManager
    {
        public IEnumerable<JiraProject> GetAll()
        {
            using (var session = SessionFactory.OpenSession())
            {
                var projects = new JiraProjectRepository(session)
                    .GetAll();

                return projects;
            }
        }
    }
}
