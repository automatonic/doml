using Mona;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Literal
{
    /// <summary>
    /// Interpretation of the C# grammar listed at
    /// http://msdn.microsoft.com/en-us/library/aa664812(v=vs.71).aspx
    /// </summary>
    public static partial class ExpectCSharp
    {
        /// <summary>
        /// Creates a parser that expects one "newline"
        /// </summary>
        /// <returns>the parser</returns>
        public static IParser<char, IEnumerable<char>> NewLine()
        {
            //new-line:
            //  Carriage return character (U+000D)
            //  Line feed character (U+000A)
            //  Carriage return character (U+000D) followed by line feed character (U+000A)
            //  Line separator character (U+2028)
            //  Paragraph separator character (U+2029)
            return Expect.While<char>((symbol, index) =>
            {
                if (index == 0)
                {
                    switch (symbol)
                    {
                        case '\u000D':
                        case '\u000A':
                        case '\u2028':
                        case '\u2029':
                            return true;
                        default:
                            return false;
                    }
                }
                else if (index == 1)
                {
                    return symbol == '\u000A';
                }
                return false;
            })
            .Select(parse =>
            {
                var node = parse.Node.ToList();
                switch (node.Count)
                {
                    case 1:
                        return parse;
                    case 2:
                        return node[0] == '\u000D' ? parse : parse.WithError(new Exception("Expected Newline"));
                    default:
                        return parse.WithError(new Exception("Expected Newline"));
                }
            });
        }

        public static IParser<char, IEnumerable<char>> Whitespace()
        {
            //whitespace:
            //    Any character with Unicode class Zs
            //    Horizontal tab character (U+0009)
            //    Vertical tab character (U+000B)
            //    Form feed character (U+000C)
            return Expect.While<char>(symbol =>
            {
                switch (symbol)
                {
                    case '\u0009':
                    case '\u000B':
                    case '\u000C':
                        return true;
                    default:
                        return Char.GetUnicodeCategory(symbol) == UnicodeCategory.SpaceSeparator;
                }
            });
        }

        public static IParser<char, string> DelimitedComment()
        {
            // delimited-comment:
            //   /*   delimited-comment-characters^opt   */
            // delimited-comment-characters:
            //   delimited-comment-character
            //   delimited-comment-characters delimited-comment-character
            return Expect.Concatenation(
                Expect.String("/*"),
                DelimitedCommentCharacter()
                    .ZeroOrMore(characters => string.Concat(characters)),
                Expect.String("*/"),
                (prefix, value, suffix) => value
                );
        }

        public static IParser<char, string> DelimitedCommentCharacter()
        {
            // delimited-comment-character:
            //   not-asterisk
            //   * not-slash
            // not-asterisk:
            //   Any Unicode character except *
            // not-slash:
            //   Any Unicode character except /
            return Expect.OneOf(
                    Expect //not-asterisk
                        .Char(input => input != '*')
                        .SelectNode(input => input.ToString()),
                    Expect.Concatenation(
                        Expect.Char('*'),
                        Expect.Char(input => input != '/'),
                        (star, notSlash) => string.Concat(star, notSlash)
                    )
                );
        }

        public static IParser<char, string> SingleLineComment()
        {
            // single-line-comment:
            //   "//"input-characters
            // input-characters:
            //   input-character              
            //   input-characters input-character
            // input-character:
            //   Any Unicode character except a new-line-character
            // new-line-character:
            //   Carriage return character (U+000D)
            //  Line feed character (U+000A)
            //  Line separator character (U+2028)
            //  Paragraph separator character (U+2029)
            return Expect.Concatenation(
                Expect.String("//"),
                Expect.While<char>(input =>
                {
                    switch (input)
                    {
                        case '\u000D':
                        case '\u000A':
                        case '\u2028':
                        case '\u2029':
                            return true;
                        default:
                            return false;
                    }
                }),
                (prefix, value) => new string(value.ToArray())
                );
        }
    }
}
