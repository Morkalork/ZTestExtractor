using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTestExtractor.Data.Entities.Jira;
using ZTestExtractor.Data.Repositories.Jira;

namespace ZTestExtractor.Data.Test.Repositories.Jira
{
    [TestFixture]
    public class JiraProjectRepositoryTest : RepositoryTestBase<JiraProjectRepository, JiraProject>
    {
        [Test]
        public void GetAllFetchesProperProjectsWithIssues()
        {
            var project = new JiraProject
            {
                Id = 1,
                Key = "TEST",
                Name = "The test project"
            };

            var issue1 = new JiraIssue { Id = 1, Project = project };
            var issue2 = new JiraIssue { Id = 2, Project = project };
            var issue3 = new JiraIssue { Id = 3, Project = project };
            var issue4 = new JiraIssue { Id = 4, Project = project };

            project.Issues.Add(issue1);
            project.Issues.Add(issue2);
            project.Issues.Add(issue3);
            project.Issues.Add(issue4);

            IEnumerable<JiraProject> projects = null;
            using (var transaction = Session.BeginTransaction())
            {
                Session.Save(project);
                Session.Save(issue1);
                Session.Save(issue2);
                Session.Save(issue3);
                Session.Save(issue4);

                projects = Repository.GetAll();
            }

            Assert.That(project.Issues.Count(), Is.EqualTo(4));
        }
    }
}
