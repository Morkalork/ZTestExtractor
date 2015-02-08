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
    public static class TestSessionFactory
    {
        private static ISession _session;

        public static ISession OpenSession()
        {
            if (_session == null)
            {
                var sessionFactory = Fluently.Configure()
                    .Database(
                        SQLiteConfiguration.Standard
                        .UsingFile("unitTest.db")
                    )
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<JiraIssue>())
                    .ExposeConfiguration(BuildSchema)
                    .BuildSessionFactory();

                _session = sessionFactory.OpenSession();
            }

            return _session;
        }

        private static void BuildSchema(Configuration config)
        {
            if (File.Exists("unitTest.db"))
                File.Delete("unitTest.db");

            new SchemaExport(config)
              .Create(false, true);
        }
    }
}
