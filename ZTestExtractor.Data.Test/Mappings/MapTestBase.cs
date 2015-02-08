using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTestExtractor.Database;

namespace ZTestExtractor.Data.Test.Mappings
{
    public abstract class MapTestBase
    {
        public ISession CreateSession()
        {
            return TestSessionFactory.OpenSession();
        }
    }
}
