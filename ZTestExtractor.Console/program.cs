using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTestExtractor.Business.Managers.Jira;
using ZTestExtractor.Core.Logging;
using output = System.Console;

namespace ZTestExtractor.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.Configure();

            var projects = new JiraProjectManager()
                .GetAll();

            if (projects != null)
            {
                foreach (var project in projects)
                {
                    output.WriteLine(project.Key);
                }
            }

            projects = new JiraProjectManager()
                .GetKludd();


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
