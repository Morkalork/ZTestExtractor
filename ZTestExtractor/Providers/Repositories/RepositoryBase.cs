using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTestExtractor.Repositories
{
    public class RepositoryBase
    {
        public ISession Session { get; private set; }

        public RepositoryBase(ISession session)
        {
            Session = session;
        }
    }
}
