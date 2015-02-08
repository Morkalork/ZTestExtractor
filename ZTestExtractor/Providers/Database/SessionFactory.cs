using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTestExtractor.Entities.Jira;

namespace ZTestExtractor.Database
{
    public static class SessionFactory
    {
        private static ISessionFactory _sessionFactory;

        static readonly object factorylock = new object();

        public static ISession OpenSession()
        {
            lock (factorylock)
            {
                if (_sessionFactory == null)
                {
                    var connectionString = ConfigurationManager.ConnectionStrings["ZTestExtractorConnectionString"].ConnectionString;

                    var cfg = Fluently.Configure()
                       .Database(MySQLConfiguration
                            .Standard
                            .ConnectionString(connectionString))
                       .Mappings(m => m.AutoMappings.Add(AutoMap.AssemblyOf<JiraIssue>));

                    _sessionFactory = cfg.BuildSessionFactory();
                }
            }

            return _sessionFactory.OpenSession();
        }
    }
}
