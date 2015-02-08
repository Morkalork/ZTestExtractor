using FluentNHibernate.Testing;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTestExtractor.Entities.Jira;
using ZTestExtractor.Entities.Zephyr;

namespace ZTestExtractor.Data.Test.Mappings.Zephyr
{
    [TestFixture]
    public class TestStepResultMapTest : MapTestBase
    {
        [Test]
        public void TestStepMapVerification()
        {
            var session = CreateSession();

            var project = new JiraProject { Key = "TEST", Name = "Test project" };
            using (var transaction = session.BeginTransaction())
            {
                session.Save(project);

                JiraIssue issue = new JiraIssue
                {
                    Id = 1,
                    Project = project
                };

                TestCycle cycle = new TestCycle
                {
                    Id = 1,
                    Project = project
                };

                TestSchedule schedule = new TestSchedule
                {
                    Id = 1,
                    Cycle = cycle,
                    Issue = issue,
                    Project = project
                };

                TestStep step = new TestStep
                {
                    Id = 1,
                    Issue = issue,
                    Schedule = schedule
                };

                session.Save(issue);
                session.Save(cycle);
                session.Save(schedule);
                session.Save(step);

                new PersistenceSpecification<TestStepResult>(session)
                    .CheckProperty(p => p.Id, 1)
                    .CheckProperty(p => p.Comment, "No comment")
                    .CheckProperty(p => p.CreatedBy, "Magnus")
                    .CheckProperty(p => p.ExecutedBy, "Magnus")
                    .CheckProperty(p => p.Status, ZTestExtractor.Entities.Zephyr.TestStatus.Pass.ToString())
                    .CheckReference(p => p.Step, step)
                    .CheckReference(p => p.Project, project)
                    .CheckReference(p => p.Schedule, schedule)
                    .VerifyTheMappings();
            }
        }
    }
}
