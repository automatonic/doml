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
        //public static IParser<char, IEnumerable<char>> Whitespace()
        //{
        //    //whitespace:
        //    //    Any character with Unicode class Zs
        //    //    Horizontal tab character (U+0009)
        //    //    Vertical tab character (U+000B)
        //    //    Form feed character (U+000C)
        //    return Expect.While<char>(symbol =>
        //    {
        //        switch (symbol)
        //        {
        //            case '\u0009':
        //            case '\u000B':
        //            case '\u000C':
        //                return true;
        //            default:
        //                return Char.GetUnicodeCategory(symbol) == UnicodeCategory.SpaceSeparator;
        //        }
        //    });
        //}      
    }
}
