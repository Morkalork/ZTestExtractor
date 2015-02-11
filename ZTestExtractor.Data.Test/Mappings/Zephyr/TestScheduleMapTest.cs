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
    public class TestScheduleMapTest : MapTestBase
    {
        [Test]
        public void TestScheduleMapVerification()
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

                TestCycle cycle = new TestCycle
                {
                    Id = 1,
                    Name = "Test Cycle",
                    Project = project,
                    Description = "A test cycle"
                };

                Session.Save(issue);
                Session.Save(cycle);

                new PersistenceSpecification<TestSchedule>(Session)
                    .CheckProperty(p => p.Id, 1)
                    .CheckProperty(p => p.CreatedBy, "Magnus")
                    .CheckProperty(p => p.CreatedDate, DateTime.Today)
                    .CheckProperty(p => p.Assignee, "Magnus")
                    .CheckProperty(p => p.Comment, "Hello World!")
                    .CheckProperty(p => p.ExecutedBy, "Jim")
                    .CheckProperty(p => p.Order, 1)
                    .CheckProperty(p => p.Status, ZTestExtractor.Core.Entities.Zephyr.TestStatus.Pass)
                    .CheckReference(p => p.Project, project)
                    .CheckReference(p => p.Issue, issue)
                    .CheckReference(p => p.Cycle, cycle)
                    .VerifyTheMappings();
            }
        }
    }
}
