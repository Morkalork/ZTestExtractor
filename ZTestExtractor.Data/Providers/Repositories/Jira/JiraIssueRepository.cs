using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTestExtractor.Data.Entities.Jira;

namespace ZTestExtractor.Data.Repositories.Jira
{
    public class JiraIssueRepository : RepositoryBase<JiraIssue>
    {
        public JiraIssueRepository(ISession session)
            : base(session)
        { }

        public IEnumerable<JiraIssue> GetPlentyOfThem()
        {
            var result = Session
                .QueryOver<JiraIssue>()
                .List<object>();

            return null;
        }
    }
}
