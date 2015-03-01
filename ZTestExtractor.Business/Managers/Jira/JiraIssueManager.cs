using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTestExtractor.Data.Entities.Jira;
using ZTestExtractor.Data.Database;
using ZTestExtractor.Data.Repositories.Jira;

namespace ZTestExtractor.Business.Managers.Jira
{
    public class JiraIssueManager
    {
        public IEnumerable<JiraIssue> GetAll()
        {
            using (var session = SessionFactory.OpenSession())
            {
                var issues = new JiraIssueRepository(session)
                    .GetAll();

                var issues2 = new JiraIssueRepository(session)
                    .GetPlentyOfThem();

                return issues;
            }
        }
    }
}
