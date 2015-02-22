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
using ZTestExtractor.Core.Models.Configurations;
using ZTestExtractor.Core.Entities.Jira;
using ZTestExtractor.Data.Repositories.System;
using ZTestExtractor.Core.Entities;

namespace ZTestExtractor.Data.Database
{
    public static class SessionFactory
    {
        private static ISessionFactory _sessionFactory;

        static readonly object factorylock = new object();

        public static bool IsSessionPossible()
        {
            try
            {
                OpenSession();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public static ISession OpenSession()
        {
            lock (factorylock)
            {
                if (_sessionFactory == null)
                {
                    var connectionString = GetConnectionString();

                    var cfg = Fluently.Configure()
                       .Database(MySQLConfiguration
                            .Standard
                            .ConnectionString(connectionString))
                       .Mappings(m => 
                           m.FluentMappings.AddFromAssemblyOf<Entity>()
                       );

                    _sessionFactory = cfg.BuildSessionFactory();
                }
            }

            return _sessionFactory.OpenSession();
        }

        private static string GetConnectionString()
        {
            var repository = new FileRepository();
            var model = repository.LoadModelFromFile<DatabaseConfigurationModel>(DatabaseConfigurationModel.FileName);

            if(model == null || string.IsNullOrEmpty(model.ServerName))
            {
                throw new Exception("Cannot create database!");
            }

            if(model.DatabaseSystem == DatabaseSystems.MySql)
            {
                return string.Format("Server={0};Database={1};Uid={2};Pwd={3};", 
                    model.ServerName, 
                    model.DatabaseName, 
                    model.Username, 
                    model.Password);
            }

            return string.Empty;
        }
    }
}
