using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mutable
{
    public interface ITraceable
    {
        void RecordDelimitedComment(string comment);
        void RecordAssignmentRaw(string property, string rawValue, string comment);        
        void RecordAssignment(string property, string value, string comment);
        void RecordAssignmentVerbatim(string property, string value, string comment);
        void RecordAssignment(string property, bool value, string comment);
        void RecordAssignment(string property, char value, string comment);
        void RecordAssignment(string property, byte value, string comment);
        void RecordAssignment(string property, short value, string comment);
        void RecordAssignment(string property, ushort value, string comment);
        void RecordAssignment(string property, int value, string comment);
        void RecordAssignment(string property, uint value, string comment);
        void RecordAssignment(string property, long value, string comment);
        void RecordAssignment(string property, ulong value, string comment);

        void RecordAssignmentHexadecimal(string property, byte value, string comment);
        void RecordAssignmentHexadecimal(string property, short value, string comment);
        void RecordAssignmentHexadecimal(string property, ushort value, string comment);
        void RecordAssignmentHexadecimal(string property, int value, string comment);
        void RecordAssignmentHexadecimal(string property, uint value, string comment);
        void RecordAssignmentHexadecimal(string property, long value, string comment);
        void RecordAssignmentHexadecimal(string property, ulong value, string comment);

        void RecordAssignment(string property, float value, string comment);
        void RecordAssignment(string property, double value, string comment);
        void RecordAssignment(string property, decimal value, string comment);

        string ToString();
    }
    
    public static class ITraceableExtensions
    {
        public static void RecordAssignment(this ITraceable traceable, string property, string value)
        {
            traceable.RecordAssignment(property, value, null);
        }
    }
}
