using NHibernate;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTestExtractor.Core.Logging;

namespace ZTestExtractor.Business.Bootstrapping.Registries
{
    public class CoreModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ISystemLog>().To<Logger>();
        }
    }
}
