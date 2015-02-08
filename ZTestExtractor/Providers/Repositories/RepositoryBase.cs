using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTestExtractor.Core.Interfaces.Data;

namespace ZTestExtractor.Repositories
{
    public class RepositoryBase : IRepository
    {
        public ISession Session { get; private set; }

        public RepositoryBase(ISession session)
        {
            Session = session;
        }
    }
}
