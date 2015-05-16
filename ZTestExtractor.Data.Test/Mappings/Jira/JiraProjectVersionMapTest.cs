using FluentNHibernate.Testing;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTestExtractor.Data.Entities.Jira;

namespace ZTestExtractor.Data.Test.Mappings.Jira
{
    [TestFixture]
    public class JiraProjectVersionMapTest : MapTestBase
    {
        [Test]
        public void JiraProjectVersionMapVerification()
        {
            //TODO: Test issue collection!
            new PersistenceSpecification<JiraProjectVersion>(Session)
                .CheckProperty(p => p.Id, 1)
                .CheckProperty(p => p.Name, "Foo")
                .CheckProperty(p => p.Description, "Bar")
                .CheckReference(p => p.Project, new JiraProject() { Id = 5, Name = "Test Project", Key = "TEST" })
                .VerifyTheMappings();
        }
    }
}
