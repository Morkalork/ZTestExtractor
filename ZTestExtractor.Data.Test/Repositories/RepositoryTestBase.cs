using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTestExtractor.Data.Test.Repositories
{
    public abstract class RepositoryTestBase
    {
        public ISession CreateSession()
        {
            return TestSessionFactory.OpenSession();
        }
    }
}
