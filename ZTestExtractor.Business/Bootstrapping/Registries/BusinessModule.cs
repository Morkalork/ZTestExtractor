using Ninject.Modules;
using Ninject.Extensions.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTestExtractor.Business.Managers;

namespace ZTestExtractor.Business.Bootstrapping.Registries
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Kernel
                .Bind(scanner =>
                    scanner.FromAssemblyContaining<IManager>()
                        .SelectAllTypes()
                        .BindAllInterfaces()
                );
        }
    }
}
