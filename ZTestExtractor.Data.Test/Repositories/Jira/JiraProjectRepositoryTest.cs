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
    public class JiraProjectRepositoryTest : RepositoryTestBase<JiraProjectRepository>
    {
        [Test]
        public void GetAllReturnsAllTest()
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

            IEnumerable<JiraProject> foundProjects = null;
            using (var transaction = Session.BeginTransaction())
            {
                Session.Save(project1);
                Session.Save(project2);

                foundProjects = Repository.GetAll();
            }

            Assert.That(foundProjects, Is.Not.Null);
            Assert.That(foundProjects.Count(), Is.EqualTo(2));
        }
    }
}
