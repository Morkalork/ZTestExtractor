using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTestExtractor.Core.Interfaces.Data;
using ZTestExtractor.Entities.Jira;

namespace ZTestExtractor.Repositories.Jira
{
    public class JiraProjectRepository : RepositoryBase
    {
        public JiraProjectRepository(ISession session) : base(session)
        { }

        public IEnumerable<JiraProject> GetAll()
        {
            return Session
                .CreateCriteria<JiraProject>()
                .List<JiraProject>();
        }
    }
}
