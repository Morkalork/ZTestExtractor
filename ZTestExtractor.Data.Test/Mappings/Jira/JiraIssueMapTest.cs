using FluentNHibernate.Testing;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTestExtractor.Entities.Jira;

namespace ZTestExtractor.Data.Test.Mappings.Jira
{
    [TestFixture]
    public class JiraIssueMapTest : MapTestBase
    {
        [Test]
        public void JiraIssueMapVerification()
        {
            new PersistenceSpecification<JiraIssue>(Session)
                .CheckProperty(p => p.Id, 1)
                .CheckProperty(p => p.CreatedBy, "Magnus")
                .CheckProperty(p => p.Description, "An issue!")
                .CheckProperty(p => p.Summary, "A summary")
                .CheckReference(p => p.Project, new JiraProject() { Id = 5, Name = "Test Project", Key = "TEST" })
                .VerifyTheMappings();
        }
    }
}
