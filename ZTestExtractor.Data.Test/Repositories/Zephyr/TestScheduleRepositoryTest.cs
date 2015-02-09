using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTestExtractor.Entities.Jira;
using ZTestExtractor.Entities.Zephyr;
using ZTestExtractor.Repositories.Zephyr;

namespace ZTestExtractor.Data.Test.Repositories.Zephyr
{
    [TestFixture]
    public class TestScheduleRepositoryTest : RepositoryTestBase<TestScheduleRepository, TestSchedule>
    {
        [Test]
        public void GetSchedulesByCycleIdGetsTheCorrectSchedules()
        {
            var project1 = new JiraProject
            {
                Id = 1,
                Key = "TEST",
                Name = "Test project"
            };

            var project2 = new JiraProject
            {
                Id = 2,
                Key = "FOO",
                Name = "An arbitrary project"
            };

            var cycle1 = new TestCycle
            {
                Id = 1,
                Name = "First test cycle",
                Project = project1
            };

            var cycle2 = new TestCycle
            {
                Id = 2,
                Name = "Second test cycle",
                Project = project2
            };

            var cycle3 = new TestCycle
            {
                Id = 3,
                Name = "Third test cycle",
                Project = project2
            };

            var issue = new JiraIssue
            {
                Id = 1,
                Project = project1,
                Summary = "A test issue"
            };

            var schedule1 = new TestSchedule
            {
                Id = 1,
                Cycle = cycle1,
                Project = project1,
                Issue = issue
            };

            var schedule2 = new TestSchedule
            {
                Id = 1,
                Cycle = cycle2,
                Project = project2,
                Issue = issue
            };

            IEnumerable<TestSchedule> schedules1 = null;
            IEnumerable<TestSchedule> schedules2 = null;
            using (var transaction = Session.BeginTransaction())
            {
                Session.Save(project1);
                Session.Save(project2);
                Session.Save(cycle1);
                Session.Save(cycle2);
                Session.Save(cycle3);
                Session.Save(issue);
                Session.Save(schedule1);
                Session.Save(schedule2);

                schedules1 = Repository.GetSchedulesByCycleId(cycle1.Id);
                schedules2 = Repository.GetSchedulesByCycleId(cycle2.Id);
            }

            Assert.That(schedules1, Is.Not.Null);
            Assert.That(schedules1.Count(), Is.EqualTo(1));
            Assert.That(schedules1.Single(), Is.EqualTo(schedule1));

            Assert.That(schedules2, Is.Not.Null);
            Assert.That(schedules2.Count(), Is.EqualTo(1));
            Assert.That(schedules2.Single(), Is.EqualTo(schedule2));
        }
    }
}
