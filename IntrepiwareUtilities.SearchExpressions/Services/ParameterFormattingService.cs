using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntrepiwareUtilities.SearchExpressions.Services
{
    public class ParameterFormattingService
    {
        public static string FormatWithAtSign(string parameterName)
        {
            return parameterName[0] == '@' ? parameterName : "@" + parameterName;
        }

        public static string FormatWithoutAtSign(string parameterName)
        {
            return parameterName[0] == '@' ? parameterName.Substring(1) : parameterName;
        }
    }
}
