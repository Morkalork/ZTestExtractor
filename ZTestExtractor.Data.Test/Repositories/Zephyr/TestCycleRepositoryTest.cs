using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTestExtractor.Entities.Jira;
using ZTestExtractor.Entities.Zephyr;

namespace ZTestExtractor.Data.Test.Repositories.Zephyr
{
    [TestFixture]
    public class TestCycleRepositoryTest : RepositoryTestBase<TestCycleRepository, TestCycle>
    {
        [Test]
        public void GetCyclesByProjectIdGetsCorrectCycles()
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

            IEnumerable<TestCycle> project1Cycles = null;
            IEnumerable<TestCycle> project2Cycles = null;
            using (var transaction = Session.BeginTransaction())
            {
                Session.Save(project1);
                Session.Save(project2);
                Session.Save(cycle1);
                Session.Save(cycle2);
                Session.Save(cycle3);

                project1Cycles = Repository.GetCyclesByProjectId(project1.Id);
                project2Cycles = Repository.GetCyclesByProjectId(project2.Id);
            }

            Assert.That(project1Cycles, Is.Not.Null);
            Assert.That(project1Cycles.Count(), Is.EqualTo(1));

            Assert.That(project2Cycles, Is.Not.Null);
            Assert.That(project2Cycles.Count(), Is.EqualTo(2));
        }

        /// <remark>
        /// I'm doing this test since I found no good way to actually
        /// test inverse collections
        /// </remark>
        [Test]
        public void GetCyclesByProjectIdGetsTheCorrectSchedules()
        {
            var project = new JiraProject { Id = 1, Key = "TEST", Name = "Test project" };

            var cycle = new TestCycle { Id = 1, Name = "A test cycle", Project = project };

            var issue1 = new JiraIssue { Id = 1, Project = project };
            var issue2 = new JiraIssue { Id = 2, Project = project };

            var schedule1 = new TestSchedule { Id = 1, Cycle = cycle, Issue = issue1, Project = project };
            var schedule2 = new TestSchedule { Id = 2, Cycle = cycle, Issue = issue1, Project = project };

            cycle.Schedules.Add(schedule1);
            cycle.Schedules.Add(schedule2);

            IEnumerable<TestCycle> fetchedCycles = null;
            using (var transaction = Session.BeginTransaction())
            {
                Session.Save(project);
                Session.Save(cycle);
                Session.Save(issue1);
                Session.Save(issue2);
                Session.Save(schedule1);
                Session.Save(schedule2);

                fetchedCycles = Repository.GetCyclesByProjectId(project.Id);
            }

            var fetchedCycle = fetchedCycles.Single();

            Assert.That(fetchedCycle.Schedules, Is.Not.Null);
            Assert.That(fetchedCycle.Schedules.Count(), Is.EqualTo(2));

            var schedules = fetchedCycle
                .Schedules
                .ToArray();

            Assert.That(schedules.Contains(schedule1), Is.True);
            Assert.That(schedules.Contains(schedule2), Is.True);
        }
    }
}
