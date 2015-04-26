using NHibernate;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTestExtractor.Core.Logging;

namespace ZTestExtractor.Business.Bootstrapping.Registries
{
    public static class CoreRegistry
    {
        public static Container Container { get; set; }

        public static void Register()
        {
            if (Container == null)
            {
                Container = new Container();

                Container.Register<ISystemLog, Logger>();
            }
        }
    }
}
