using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Literal
{
    public sealed class DelimitedComment : TraceToken
    {
        readonly string _Value;
        public DelimitedComment(string value)
        {
            _Value = value;
        }

        public string Value
        {
            get
            {
                return _Value;
            }
        }
    }
}
