using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTestExtractor.Business.Bootstrapping.Registries;
using Ninject.Extensions.Interception;
using Ninject;

namespace ZTestExtractor.Business.Bootstrapping
{
    public static class Bootstrapper
    {
        public static IKernel Bootstrap()
        {
            var kernel = new StandardKernel();
            kernel.Load<CoreModule>();
            kernel.Load<DataModule>();
            kernel.Load<BusinessModule>();

            return kernel;
        }
    }
}
