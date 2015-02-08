using NHibernate;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTestExtractor.Core.Interfaces.Data;
using ZTestExtractor.Repositories;

namespace ZTestExtractor.Data.Test.Repositories
{
    [TestFixture]
    public abstract class RepositoryTestBase<TRepository, TEntity>
        where TEntity : class, IEntity
        where TRepository : RepositoryBase<TEntity>
    {
        public ISession Session { get; set; }
        public TRepository Repository { get; set; }

        [SetUp]
        public void CreateSessionAndRepository()
        {
            Session = TestSessionFactory.OpenSession();
            Repository = (TRepository)Activator.CreateInstance(typeof(TRepository), Session);
        }

        [TearDown]
        public void DestroySession()
        {
            Session = null;
        }
    }
}
