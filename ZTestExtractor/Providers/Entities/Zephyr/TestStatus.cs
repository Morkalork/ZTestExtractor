using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTestExtractor.Data.Entities.Zephyr
{
    public enum TestStatus
    {
        Unexecuted = -1,
        Unknown = 0, //This one is never mapped by Zephyr
        Pass = 1,
        Fail = 2,
        WIP = 3,
        Blocked = 4
    }
}
