using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mutable
{
    internal class Traceable : ITraceable
    {
        StringBuilder _StringBuilder = new StringBuilder();
        public void RecordAssignmentRaw(string property, string value, string comment)
        {
            _StringBuilder.AppendFormat(CultureInfo.InvariantCulture, "{0} = {1}", property ?? "_", value ?? "null");
            if (string.IsNullOrWhiteSpace(comment))
            {
                _StringBuilder.AppendLine(";");
            }
            else
            {
                var firstCommentLine = comment.Split('\n','\r')[0];
                _StringBuilder.AppendFormat(CultureInfo.InvariantCulture, "; //{0}", firstCommentLine);
            }
        }

        public void RecordAssignment(string property, string value, string comment)
        {
            RecordAssignmentRaw(property, string.Concat("\"", value.Replace("\"", "\\\"")), comment);
        }

        public void RecordAssignment(string property, int value, string comment)
        {
            RecordAssignmentRaw(property, value.ToString(), comment);
        }

        public void RecordDelimitedComment(string comment)
        {
            if (string.IsNullOrWhiteSpace(comment))
            {
                return;
            }
            _StringBuilder.AppendFormat(
                CultureInfo.InvariantCulture, 
                "/*{0}*/", 
                comment.Replace("*/",string.Empty));
        }

        public override string ToString()
        {
            return _StringBuilder.ToString();
        }


        public void RecordAssignmentVerbatim(string property, string value, string comment)
        {
            RecordAssignmentRaw(property, string.Concat("@\"", value.Replace("\"", "\"\""), "\""), comment);
        }

        public void RecordAssignment(string property, bool value, string comment)
        {
            RecordAssignmentRaw(property, value ? "true" : "false", comment);
        }

        public void RecordAssignment(string property, char value, string comment)
        {
            RecordAssignmentRaw(property, string.Concat("'", value == '\'' ? '\'' : value , "'"), comment);
        }

        public void RecordAssignment(string property, byte value, string comment)
        {
            RecordAssignmentRaw(property, value.ToString(), comment);
        }

        public void RecordAssignment(string property, short value, string comment)
        {
            RecordAssignmentRaw(property, value.ToString(), comment);
        }

        public void RecordAssignment(string property, ushort value, string comment)
        {
            RecordAssignmentRaw(property, value.ToString(), comment);
        }

        public void RecordAssignment(string property, uint value, string comment)
        {
            RecordAssignmentRaw(property, value.ToString(), comment);
        }

        public void RecordAssignment(string property, long value, string comment)
        {
            RecordAssignmentRaw(property, value.ToString(), comment);
        }

        public void RecordAssignment(string property, ulong value, string comment)
        {
            RecordAssignmentRaw(property, value.ToString(), comment);
        }

        public void RecordAssignmentHexadecimal(string property, byte value, string comment)
        {
            RecordAssignmentRaw(property, value.ToString(), comment);
        }

        public void RecordAssignmentHexadecimal(string property, short value, string comment)
        {
            RecordAssignmentRaw(property, value.ToString(), comment);
        }

        public void RecordAssignmentHexadecimal(string property, ushort value, string comment)
        {
            RecordAssignmentRaw(property, value.ToString(), comment);
        }

        public void RecordAssignmentHexadecimal(string property, int value, string comment)
        {
            RecordAssignmentRaw(property, value.ToString(), comment);
        }

        public void RecordAssignmentHexadecimal(string property, uint value, string comment)
        {
            RecordAssignmentRaw(property, value.ToString(), comment);
        }

        public void RecordAssignmentHexadecimal(string property, long value, string comment)
        {
            RecordAssignmentRaw(property, value.ToString(), comment);
        }

        public void RecordAssignmentHexadecimal(string property, ulong value, string comment)
        {
            RecordAssignmentRaw(property, value.ToString(), comment);
        }

        public void RecordAssignment(string property, float value, string comment)
        {
            RecordAssignmentRaw(property, value.ToString(), comment);
        }

        public void RecordAssignment(string property, double value, string comment)
        {
            RecordAssignmentRaw(property, value.ToString(), comment);
        }

        public void RecordAssignment(string property, decimal value, string comment)
        {
            RecordAssignmentRaw(property, value.ToString(), comment);
        }
    }
}
