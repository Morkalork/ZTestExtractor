using NHibernate;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTestExtractor.Data.Database;

namespace ZTestExtractor.Business.Bootstrapping.Registries
{
    public static class DataRegistry
    {
        public static ISession CurrentSession { get; set; }

        public static Container Container { get; set; }

        public static void Register()
        {
            if (Container == null)
            {
                Container = new Container();

                Container.Register<ISession>(() => SessionFactory.OpenSession());
            }
        }
    }
}
