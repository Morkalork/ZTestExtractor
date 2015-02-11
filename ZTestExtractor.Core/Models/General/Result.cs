using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTestExtractor.Core.Models.General
{
    public class Result
    {
        public IList<string> Messages { get; set; }

        public bool IsSuccess { get; set; }

        public Result() : this(false)
        { }

        public Result( bool isSuccess)
        {
            Messages = new List<string>();
        }
    }
}
