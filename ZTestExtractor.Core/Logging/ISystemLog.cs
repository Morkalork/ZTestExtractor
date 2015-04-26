using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTestExtractor.Core.Logging
{
    public interface ISystemLog
    {
        void Error(object msg);

        void Error(object msg, Exception ex);

        void Error(Exception ex);

        void Info(object msg);

        void Warn(object msg);
    }
}
