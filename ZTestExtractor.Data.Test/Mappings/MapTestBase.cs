using NHibernate;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTestExtractor.Data.Database;

namespace ZTestExtractor.Data.Test.Mappings
{
    [TestFixture]
    public abstract class MapTestBase
    {
        public ISession Session { get; private set; }

        [SetUp]
        public void CreateSession()
        {
            Session = TemporaryTestSessionFactory.OpenTemporarySession();
        }

        [TearDown]
        public void DestroySession()
        {
            Session = null;
        }
    }
}
