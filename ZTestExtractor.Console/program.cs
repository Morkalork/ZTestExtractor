using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTestExtractor.Business.Bootstrapping;
using ZTestExtractor.Business.Managers.Jira;
using ZTestExtractor.Core.Logging;
using output = System.Console;
using Ninject;

namespace ZTestExtractor.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.Configure();

            var kernel = Bootstrapper.Bootstrap();

            var projects = kernel.Get<IJiraProjectManager>()
                .GetAllDisplayModels();

            if (projects != null)
            {
                foreach (var project in projects)
                {
                    output.WriteLine(project.Key);
                }
            }

            output.ReadLine();
        }
    }
}
