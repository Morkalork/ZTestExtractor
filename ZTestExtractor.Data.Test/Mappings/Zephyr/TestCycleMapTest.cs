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
    public class TestCycleMapTest : MapTestBase
    {
        [Test]
        public void TestCycleMapVerification()
        {
            new PersistenceSpecification<TestCycle>(Session)
                .CheckProperty(p => p.Id, 1)
                .CheckProperty(p => p.CreatedBy, "Magnus")
                .CheckProperty(p => p.Description, "Foo")
                .CheckProperty(p => p.Name, "Test cycle 1")
                .CheckReference(p => p.Project, new JiraProject { Id = 5, Key = "TEST" })
                .VerifyTheMappings();
        }
    }
}
