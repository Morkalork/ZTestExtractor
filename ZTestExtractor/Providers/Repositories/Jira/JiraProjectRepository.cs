using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTestExtractor.Core.Interfaces.Data;
using ZTestExtractor.Data.Entities.Jira;

namespace ZTestExtractor.Data.Repositories.Jira
{
    public class JiraProjectRepository : RepositoryBase<JiraProject>
    {
        public JiraProjectRepository(ISession session) : base(session)
        { }
    }
}
