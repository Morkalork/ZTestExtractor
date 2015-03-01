using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTestExtractor.Data.Entities.Jira;
using ZTestExtractor.Data.Repositories.Jira;

namespace ZTestExtractor.Data.Test.Repositories
{
    /// <summary>
    /// To test the base functionality of the RepositoryBase class I will be using
    /// the 'JiraProject' entity as a token entity
    /// </summary>
    [TestFixture]
    public class RepositoryBaseTest : RepositoryTestBase<JiraProjectRepository, JiraProject>
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

        [Test]
        public void GetByIdReturnsTheCorrectProject()
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

            JiraProject foundProject = null;
            using (var transaction = Session.BeginTransaction())
            {
                Session.Save(project1);
                Session.Save(project2);

                foundProject = Repository.GetById(1);
            }

            Assert.That(foundProject, Is.Not.Null);
            Assert.That(foundProject.Id, Is.EqualTo(1));
            Assert.That(foundProject, Is.EqualTo(project1));
        }
    }
}
