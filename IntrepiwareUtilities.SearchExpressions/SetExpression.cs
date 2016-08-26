using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IntrepiwareUtilities.SearchExpressions.Services;

namespace IntrepiwareUtilities.SearchExpressions
{
    public class SetExpression<T> : SearchExpression<T>
    {
        public IEnumerable<T> Value { get; private set; }

        public bool InSet { get; private set; }

        public SetExpression(IEnumerable<T> value, bool inSet)
        {
            Value = value;
            InSet = inSet;
        }

        public override string ToSqlExpression(string fieldName, string parameterName)
        {
            string operatorString = (InSet) ? "in" : "not in";
            parameterName = ParameterFormattingService.FormatWithAtSign(parameterName);
            return String.Format(" and {0} {1} {2}", fieldName, operatorString, parameterName);
        }

        public override Dictionary<string, object> GetDynamicParameters(string parameterName)
        {
            Dictionary<string, object> output = new Dictionary<string, object>();
            parameterName = ParameterFormattingService.FormatWithoutAtSign(parameterName);
            output.Add(parameterName, ((IEnumerable<T>)Value).ToArray());
            return output;
        }
    }
}
