using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Literal
{
    public sealed class LiteralAssignment : TraceToken
    {
        readonly string _Property;
        readonly object _Value;
        readonly string _Comment;
        public LiteralAssignment(IEnumerable<string> propertyChain, object value, string comment)
        {
            _Property = string.Join(".", propertyChain.ToArray());
            _Value = value;
            _Comment = comment;
        }

        public string Property
        {
            get
            {
                return _Property;
            }
        }
        public object Value
        {
            get
            {
                return _Value;
            }
        }
        public string Comment
        {
            get
            {
                return _Comment;
            }
        }

    }
}
