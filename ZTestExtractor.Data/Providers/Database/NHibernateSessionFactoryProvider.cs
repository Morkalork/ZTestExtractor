using NHibernate;
using Ninject.Activation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTestExtractor.Data.Database
{
    public class NHibernateSessionFactoryProvider : Provider<ISessionFactory>
    {
        protected override ISessionFactory CreateInstance(IContext context)
        {
            var factory = new NHibernateSessionFactory();
            return factory.GetSessionFactory();
        }
    }
}
