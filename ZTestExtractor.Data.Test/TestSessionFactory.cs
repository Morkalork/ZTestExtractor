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
using ZTestExtractor.Data.Entities.Jira;
using ZTestExtractor.Data.EntityMappings.Jira;

namespace ZTestExtractor.Data.Test
{
    public static class TestSessionFactory
    {
        public static ISession OpenSession()
        {
            var sessionFactory = Fluently.Configure()
                .Database(
                    SQLiteConfiguration
                    .Standard
                    .ShowSql()
                    .UsingFile("unitTest.db")
                )
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<JiraIssueMap>())
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();

            return sessionFactory.OpenSession();
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
