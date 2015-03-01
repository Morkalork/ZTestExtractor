using FluentNHibernate.Testing;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTestExtractor.Data.Entities.Jira;
using ZTestExtractor.Data.Entities.Zephyr;

namespace ZTestExtractor.Data.Test.Mappings.Zephyr
{
    [TestFixture]
    public class TestStepResultMapTest : MapTestBase
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

                Session.Save(issue);
                Session.Save(cycle);
                Session.Save(schedule);
                Session.Save(step);

                new PersistenceSpecification<TestStepResult>(Session)
                    .CheckProperty(p => p.Id, 1)
                    .CheckProperty(p => p.Comment, "No comment")
                    .CheckProperty(p => p.CreatedBy, "Magnus")
                    .CheckProperty(p => p.ExecutedBy, "Magnus")
                    .CheckProperty(p => p.Status, ZTestExtractor.Data.Entities.Zephyr.TestStatus.Pass.ToString())
                    .CheckReference(p => p.Step, step)
                    .CheckReference(p => p.Project, project)
                    .CheckReference(p => p.Schedule, schedule)
                    .VerifyTheMappings();
            }
        }
    }
}
