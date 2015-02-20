using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTestExtractor.Core.Logging
{
    public class Logger
    {
        private log4net.ILog Log { get; set; }

        public static void Configure()
        {
            log4net.Config.BasicConfigurator.Configure();
        }

        public Logger()
        {
            Log = log4net.LogManager.GetLogger(typeof(Logger));
        }

        public void Error(object msg)
        {
            Log.Error(msg);
        }

        public void Error(object msg, Exception ex)
        {
            Log.Error(msg, ex);
        }

        public void Error(Exception ex)
        {
            Log.Error(ex.Message, ex);
        }

        public void Info(object msg)
        {
            Log.Info(msg);
        }
    }
}
