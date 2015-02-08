using FluentNHibernate;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTestExtractor.Entities.Jira;

namespace ZTestExtractor.Data.Test
{
    /// <summary>
    /// A factory for building a temporary in memory database
    /// </summary>
    /// <remarks>
    /// More on SessionSource: http://marekblotny.blogspot.se/2008/12/fluent-nhibernate-integration-tests.html
    /// </remarks>
    public class TemporaryTestSessionFactory
    {
        private static SessionSource _sessionSource;

        static readonly object factorylock = new object();

        public static ISession OpenTemporarySession()
        {
            lock (factorylock)
            {
                if (_sessionSource == null)
                {
                    var persistenceModel = new PersistenceModel();
                    persistenceModel.AddMappingsFromAssembly(typeof(JiraIssue).Assembly);

                    var sqLiteConfiguration = new SQLiteConfiguration()
                            .InMemory()
                            .ShowSql();

                    var sessionSource = new SessionSource(sqLiteConfiguration.ToProperties(), persistenceModel);

                    _sessionSource = sessionSource;
                }
            }

            var session = _sessionSource.CreateSession();
            _sessionSource.BuildSchema(session);

            return session;
        }
    }
}
