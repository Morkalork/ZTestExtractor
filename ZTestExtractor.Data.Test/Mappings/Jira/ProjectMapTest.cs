using FluentNHibernate.Testing;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTestExtractor.Entities.Jira;

namespace ZTestExtractor.Data.Test.Mappings.Jira
{
    [TestFixture]
    public class ProjectMapTest : MapTestBase
    {
        [Test]
        public void ProjectMapVerification()
        {
            //TODO: Test issue collection!
            new PersistenceSpecification<JiraProject>(Session)
                .CheckProperty(p => p.Id, 1)
                .CheckProperty(p => p.Key, "Foo")
                .CheckProperty(p => p.Name, "Bar")
                .VerifyTheMappings();
        }
    }
}
