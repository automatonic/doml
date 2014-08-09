using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mutable
{
    public static class Trace
    {
        public static ITraceable Begin()
        {
            return new Traceable();
        }
    }
}
