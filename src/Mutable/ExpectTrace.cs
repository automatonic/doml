using Mona;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Mutable
{
    /// <summary>
    /// Top level trace parser
    /// </summary>
    public static partial class ExpectTrace
    {
        public static IParser<char, IEnumerable<Tuple<string, object, string>>> Input()
        {
            return Expect
                .OneOf(
                    EmptyLine(),
                    DelimitedComment(),
                    Assignment()
                )
                .ZeroOrMore();
        }
      
        public static IParser<char, Tuple<string, object, string>> EmptyLine()
        {
            return Expect.Concatenation(
                ExpectCSharp.Whitespace(),
                ExpectCSharp.NewLine(),
                (ws, nl) => Tuple.Create((string)null, (object)null, (string)null)
                );
        }

        public static IParser<char, Tuple<string, object, string>> DelimitedComment()
        {
            return Expect.Concatenation(
                ExpectCSharp.Whitespace(),
                ExpectCSharp.NewLine(),
                (ws, nl) => Tuple.Create((string)null, (object)null, (string)null)
                );
        }

        public static IParser<char, Tuple<string, object, string>> Assignment()
        {
            return Expect.Concatenation(
                ExpectCSharp.Whitespace(),
                ExpectCSharp.NewLine(),
                (ws, nl) => Tuple.Create((string)null, (object)null, (string)null)
                );
        }
    }
}
