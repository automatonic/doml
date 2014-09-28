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
    }
}
