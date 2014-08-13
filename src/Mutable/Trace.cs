using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mona;

namespace Mutable
{
    public static class Trace
    {
        public static ITraceable Begin()
        {
            return new Traceable();
        }

        public static void Retrace(string from, Action<string, object, string> into)
        {
            var parser = ExpectTrace.Input();
            var parse = parser.Parse(from);
            if (parse.Succeeded() && into != null)
            {
                foreach (var line in parse.Node)
                {
                    into(line.Item1, line.Item2, line.Item3);
                }
            }
        }
    }
}
