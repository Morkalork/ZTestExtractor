using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTestExtractor.Core.Interfaces;
using NHibernate.FlowQuery;
using NHibernate.FlowQuery.Core;

namespace ZTestExtractor.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        public ISession Session { get; private set; }

        public IImmediateFlowQuery<TEntity> Query
        {
            get
            {
                return Session.FlowQuery<TEntity>();
            }
        }

        public RepositoryBase(ISession session)
        {
            Session = session;
        }

        public virtual TEntity GetById(int id)
        {
            using(var transaction = Session.BeginTransaction())
            {
                return Session.CreateCriteria<TEntity>()
                    .Add(Restrictions.Eq("Id", id))
                    .List<TEntity>()
                    .SingleOrDefault();
            }
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return Session
                .QueryOver<TEntity>()
                .List();
        }
    }
}
