using Mona;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Literal
{
    /// <summary>
    /// Top level trace parser
    /// </summary>
    public static partial class ExpectTrace
    {
        public static IParser<char, IEnumerable<TraceToken>> Input()
        {
            return Expect
                .OneOf(
                    EmptyLine(),
                    DelimitedComment(),
                    Assignment()
                )
                .ZeroOrMore();
        }

        public static IParser<char, TraceToken> EmptyLine()
        {
            return Expect.Concatenation(
                ExpectCSharp.Whitespace(),
                ExpectCSharp.NewLine(),
                (ws, nl) => new EmptyLine() as TraceToken
                );
        }

        public static IParser<char, TraceToken> DelimitedComment()
        {
            return Expect.Concatenation(
                ExpectCSharp.Whitespace(),
                ExpectCSharp.NewLine(),
                (ws, nl) => new DelimitedComment("") as TraceToken
                );
        }

        public static IParser<char, TraceToken> Assignment()
        {
            return Expect.Concatenation(
                ExpectCSharp.Whitespace(),
                ExpectCSharp.NewLine(),
                (ws, nl) => new LiteralAssignment(new string[] {}, null, "") as TraceToken
                );
        }
    }
}
