using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using FluentAssertions;
using Mona;

namespace Literal
{
    public class ExpectCSharpShould
    {
        [Theory]
        [InlineData("a")]
        [InlineData("_")]
        [InlineData("_97")]
        [InlineData("MonaLisa")]
        [InlineData("@class")]
        public void MatchIdentifier(string input)
        {
            var parse = ExpectCSharp.Identifier().Parse(input);
            parse.Succeeded().Should().BeTrue();
            parse.Node.Should().Be(input);
        }

        [Theory]
        [InlineData("9")]
        [InlineData("^")]
        [InlineData("class")]
        public void RejectIdentifier(string input)
        {
            var parse = ExpectCSharp.Identifier().Parse(input);
            parse.Succeeded().Should().BeFalse();
        }


        [Theory]
        [InlineData("/*a*/")]
        [InlineData("/**/")]
        [InlineData("/*a\r\nb*/")]
        public void MatchDelimitedComment(string input)
        {
            var parse = ExpectCSharp.DelimitedComment().Parse(input);
            parse.Succeeded().Should().BeTrue();
            parse.Node.Should().Be(input.Substring(2,input.Length -4), because: "we ignore the comment prefix/suffix");
        }
    }
}
