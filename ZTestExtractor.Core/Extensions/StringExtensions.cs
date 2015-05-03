using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTestExtractor.Core.Extensions
{
    public static class StringExtensions
    {
        public static string F(this string str, params object[] args)
        {
            return string.Format(str, args);
        }
    }
}
