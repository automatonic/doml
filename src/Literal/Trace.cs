using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mona;

namespace Literal
{
    public static class Trace
    {
        public static IEnumerable<TraceToken> Tokenize(string from)
        {
            var parser = ExpectTrace.Input();
            var parse = parser.Parse(from);
            if (parse.Succeeded())
            {
                return parse.Node;
            }
            return Enumerable.Empty<TraceToken>();
        }
    }
}
