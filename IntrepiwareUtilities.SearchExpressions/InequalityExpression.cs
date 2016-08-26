using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IntrepiwareUtilities.SearchExpressions.Services;

namespace IntrepiwareUtilities.SearchExpressions
{
    public class InequalityExpression<T> : SearchExpression<T>
    {
        public T Value { get; private set; }

        public bool GreaterThanValue { get; private set; }

        public bool EqualsValue { get; private set; }

        public InequalityExpression(T value, bool greaterThanValue, bool equalsValue)
        {
            Value = value;
            GreaterThanValue = greaterThanValue;
            EqualsValue = equalsValue;
        }

        public override string ToSqlExpression(string fieldName, string parameterName)
        {
            string operatorString = "";
            parameterName = ParameterFormattingService.FormatWithAtSign(parameterName);
            operatorString = (GreaterThanValue) ? ">" : "<";
            operatorString += (EqualsValue) ? "=" : "";

            return String.Format(" and {0} {1} {2}", fieldName, operatorString, parameterName);
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
