using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace Literal
{

    public class TraceShould
    {
        [Fact]
        public void TokenizeAnEmptyString()
        {
            Trace
                .Tokenize(string.Empty)
                .Should()
                .BeEmpty();
        }

        [Theory]
        [InlineData(" ")]
        [InlineData("/t")]
        public void TokenizeStandaloneWhitespace(string input)
        {
            var tokens = Trace
                .Tokenize(input)
                .ToList();
            tokens.Should().HaveCount(1, because: "the whitespace will be interpreted as a single, empty line");
            tokens.Should().OnlyContain(token => token is EmptyLine, because: "all tokens are empty lines");
        }

        [Theory]
        [InlineData("/*a*/")]
        public void TokenizeDelimitedComment(string input)
        {
            var tokens = Trace
                .Tokenize(input)
                .ToList();

            tokens.Should().NotBeEmpty(because: "a delimited comment is a valid token");
            tokens.All(token => token is DelimitedComment).Should().BeTrue(because: "all tokens are delimited comments");
        }
    }
}
