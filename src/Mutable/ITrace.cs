using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mutable
{
    public interface ITrace
    {
        void Assign(string property, object value, string valueFormat, string comment);
    }


}
