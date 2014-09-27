using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Literal
{
    public class TraceBuilder
    {
        readonly StringBuilder _StringBuilder = new StringBuilder();
        public void AppendAssignmentRaw(string property, string value, string comment)
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

        public void AppendAssignment(string property, string value, string comment)
        {
            AppendAssignmentRaw(property, string.Concat("\"", value.Replace("\"", "\\\"")), comment);
        }

        public void AppendAssignment(string property, int value, string comment)
        {
            AppendAssignmentRaw(property, value.ToString(), comment);
        }

        public void AppendDelimitedComment(string comment)
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


        public void AppendAssignmentVerbatim(string property, string value, string comment)
        {
            AppendAssignmentRaw(property, string.Concat("@\"", value.Replace("\"", "\"\""), "\""), comment);
        }

        public void AppendAssignment(string property, bool value, string comment)
        {
            AppendAssignmentRaw(property, value ? "true" : "false", comment);
        }

        public void AppendAssignment(string property, char value, string comment)
        {
            AppendAssignmentRaw(property, string.Concat("'", value == '\'' ? '\'' : value , "'"), comment);
        }

        public void AppendAssignment(string property, byte value, string comment)
        {
            AppendAssignmentRaw(property, value.ToString(), comment);
        }

        public void AppendAssignment(string property, short value, string comment)
        {
            AppendAssignmentRaw(property, value.ToString(), comment);
        }

        public void AppendAssignment(string property, ushort value, string comment)
        {
            AppendAssignmentRaw(property, value.ToString(), comment);
        }

        public void AppendAssignment(string property, uint value, string comment)
        {
            AppendAssignmentRaw(property, value.ToString(), comment);
        }

        public void AppendAssignment(string property, long value, string comment)
        {
            AppendAssignmentRaw(property, value.ToString(), comment);
        }

        public void AppendAssignment(string property, ulong value, string comment)
        {
            AppendAssignmentRaw(property, value.ToString(), comment);
        }

        public void AppendAssignmentHexadecimal(string property, byte value, string comment)
        {
            AppendAssignmentRaw(property, value.ToString(), comment);
        }

        public void AppendAssignmentHexadecimal(string property, short value, string comment)
        {
            AppendAssignmentRaw(property, value.ToString(), comment);
        }

        public void AppendAssignmentHexadecimal(string property, ushort value, string comment)
        {
            AppendAssignmentRaw(property, value.ToString(), comment);
        }

        public void AppendAssignmentHexadecimal(string property, int value, string comment)
        {
            AppendAssignmentRaw(property, value.ToString(), comment);
        }

        public void AppendAssignmentHexadecimal(string property, uint value, string comment)
        {
            AppendAssignmentRaw(property, value.ToString(), comment);
        }

        public void AppendAssignmentHexadecimal(string property, long value, string comment)
        {
            AppendAssignmentRaw(property, value.ToString(), comment);
        }

        public void AppendAssignmentHexadecimal(string property, ulong value, string comment)
        {
            AppendAssignmentRaw(property, value.ToString(), comment);
        }

        public void AppendAssignment(string property, float value, string comment)
        {
            AppendAssignmentRaw(property, value.ToString(), comment);
        }

        public void AppendAssignment(string property, double value, string comment)
        {
            AppendAssignmentRaw(property, value.ToString(), comment);
        }

        public void AppendAssignment(string property, decimal value, string comment)
        {
            AppendAssignmentRaw(property, value.ToString(), comment);
        }
    }
}
