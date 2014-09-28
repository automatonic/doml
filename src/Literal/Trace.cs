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
            //Normalize ending with a newline, taking care not to duplicate one
            from =
                string.Concat(
                    from.TrimEnd('\u000D', '\u000A', '\u2028', '\u2029'),
                    '\u000D',
                    '\u000A'
                );
            var parse = parser.Parse(from);
            if (parse.Succeeded())
            {
                return parse.Node;
            }
            return Enumerable.Empty<TraceToken>();
        }
    }
}
