using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IntrepiwareUtilities.SearchExpressions.Services;

namespace IntrepiwareUtilities.SearchExpressions
{
    public class LikeExpression : SearchExpression<string>
    {
        public string Value
        {
            get;
            private set;
        }

        public LikeExpression(string value)
        {
            Value = value;
        }

        public override string ToSqlExpression(string fieldName, string parameterName)
        {
            parameterName = ParameterFormattingService.FormatWithAtSign(parameterName);
            return String.Format(" and {0} like {1}", fieldName, parameterName);
        }


        public override Dictionary<string, object> GetDynamicParameters(string parameterName)
        {
            Dictionary<string, object> output = new Dictionary<string, object>();
            parameterName = ParameterFormattingService.FormatWithoutAtSign(parameterName);
            output.Add(parameterName, Value);
            return output;
        }
    }
}
