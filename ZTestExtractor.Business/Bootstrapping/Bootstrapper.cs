using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTestExtractor.Business.Bootstrapping.Registries;

namespace ZTestExtractor.Business.Bootstrapping
{
    public static class Bootstrapper
    {
        public static void Bootstrap()
        {
            DataRegistry.Register();
            CoreRegistry.Register();
        }
    }
}
