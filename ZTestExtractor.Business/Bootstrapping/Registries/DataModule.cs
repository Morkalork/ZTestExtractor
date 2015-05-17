using NHibernate;
using Ninject;
using Ninject.Web.Common;
using Ninject.Modules;
using Ninject.Extensions.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTestExtractor.Data.Database;
using ZTestExtractor.Data.Repositories;

namespace ZTestExtractor.Business.Bootstrapping.Registries
{
    public class DataModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ISessionFactory>()
                .ToProvider<NHibernateSessionFactoryProvider>()
                .InSingletonScope();

            Bind<ISession>()
                .ToMethod(context => context.Kernel.Get<ISessionFactory>().OpenSession()).InRequestScope();

            Kernel
                .Bind(scanner =>
                    scanner.FromAssemblyContaining<IRepository>()
                        .SelectAllTypes()
                        .BindAllInterfaces()
                );
        }
    }
}
