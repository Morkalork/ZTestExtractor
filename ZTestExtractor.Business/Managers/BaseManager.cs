using NHibernate;
using SimpleInjector;
using SimpleInjector.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTestExtractor.Business.Bootstrapping.Registries;
using ZTestExtractor.Data.Repositories;
using ZTestExtractor.Data.Database;
using ZTestExtractor.Data.Repositories.Jira;

namespace ZTestExtractor.Business.Managers
{
    public abstract class BaseManager
    {

        public BaseManager()
        {
            
        }

        protected TInterface GetRepository<TInterface>()
            where TInterface : class
        {
            var implementation = DataRegistry.Container.GetInstance(typeof(TInterface)) as TInterface;

            return implementation;
        }
    }
}
