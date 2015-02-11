using FluentNHibernate.Testing;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTestExtractor.Core.Entities.Jira;
using ZTestExtractor.Core.Entities.Zephyr;

namespace ZTestExtractor.Data.Test.Mappings.Zephyr
{
    [TestFixture]
    public class TestStepMapTest : MapTestBase
    {
        [Test]
        public void TestStepMapVerification()
        {
            var project = new JiraProject { Key = "TEST", Name = "Test project" };
            using (var transaction = Session.BeginTransaction())
            {
                Session.Save(project);

                JiraIssue issue = new JiraIssue
                {
                    Id = 1,
                    Project = project
                };

                Session.Save(issue);

                new PersistenceSpecification<TestStep>(Session)
                    .CheckProperty(p => p.Id, 1)
                    .CheckProperty(p => p.Data, "Data")
                    .CheckProperty(p => p.Order, 1)
                    .CheckProperty(p => p.ExpectedResult, "Result")
                    .CheckProperty(p => p.Step, "Step")
                    .CheckReference(p => p.Issue, issue)
                    .VerifyTheMappings();
            }
        }
    }
}
