using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Venezia.Utils
{
    public static class Extensions
    {

        public static string ToJson(this Dictionary<int, int> dic)
        {
            var entries = dic.Select(x => string.Format("{0}:{1}", x.Key, x.Value));
            return "{" + string.Join(",", entries) + "}";
        }
    }
}
