using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTestExtractor.Entities.Jira;
using ZTestExtractor.Repositories.Jira;

namespace ZTestExtractor.Data.Test.Repositories.Jira
{
    [TestFixture]
    public class JiraProjectRepositoryTest : RepositoryTestBase<JiraProjectRepository, JiraProject>
    {
    }
}
