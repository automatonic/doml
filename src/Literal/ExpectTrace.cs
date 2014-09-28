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
                    LiteralAssignment()
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
            return ExpectCSharp
                .DelimitedComment()
                .SelectNode(comment => new DelimitedComment(comment) as TraceToken);
        }

        public static IParser<char, TraceToken> LiteralAssignment()
        {
            return Expect.Concatenation(
                PropertyChain(),
                ExpectCSharp.Whitespace(),
                Expect.Char('='),
                ExpectCSharp.Whitespace(),
                ExpectCSharp.Literal(),
                ExpectCSharp.Whitespace(),
                ExpectCSharp.SingleLineComment(),
                (property, ws1, eq, ws2, value, ws3, comment) => new LiteralAssignment(property, value, comment) as TraceToken
                );
        }

        public static IParser<char, IEnumerable<string>> PropertyChain()
        {
            return Expect.Concatenation(
                ExpectCSharp.Identifier(),
                Expect
                    .Concatenation(
                        Expect.Char('.'),
                        ExpectCSharp.Identifier(),
                        (dot, identifier) => identifier)
                    .ZeroOrMore(),
                (property, chain) => 
                    new string[] { property }
                        .Concat(chain)
                );
        }
    }
}
