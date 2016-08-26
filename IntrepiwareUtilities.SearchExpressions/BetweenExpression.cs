using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IntrepiwareUtilities.SearchExpressions.Services;

namespace IntrepiwareUtilities.SearchExpressions
{
    public class BetweenExpression<T> : SearchExpression<T>
    {
        public IEnumerable<T> Value { get; private set; }

        public bool LowInclusive { get; private set; }

        public bool HighInclusive { get; private set; }

        public BetweenExpression(T lowValue, T highValue, bool highInclusive, bool lowInclusive)
        {
            Value = new T[] { lowValue, highValue };
            HighInclusive = highInclusive;
            LowInclusive = lowInclusive;

        }

        public override string ToSqlExpression(string fieldName, string parameterName)
        {
            string lowOperator, highOperator;
            string lowParameterName, highParameterName;

            lowOperator = (LowInclusive) ? ">=" : ">";
            highOperator = (HighInclusive) ? "<=" : "<";
            lowParameterName = ParameterFormattingService.FormatWithAtSign(parameterName + "___LOW");
            highParameterName = ParameterFormattingService.FormatWithAtSign(parameterName + "___HIGH");
            return String.Format(" and {0} {1} {2} and {3} {4} {5}",
                fieldName, lowOperator, lowParameterName, fieldName, highOperator, highParameterName);
        }

        public override Dictionary<string, object> GetDynamicParameters(string parameterName)
        {
            string lowParameterName, highParameterName;
            Dictionary<string, object> output;
            IEnumerable<T> values;

            lowParameterName = ParameterFormattingService.FormatWithoutAtSign(parameterName + "___LOW");
            highParameterName = ParameterFormattingService.FormatWithoutAtSign(parameterName + "___HIGH");
            values = (IEnumerable<T>)Value;

            output = new Dictionary<string, object>();
            output.Add(lowParameterName, values.ElementAt(0));
            output.Add(highParameterName, values.ElementAt(1));
            return output;
        }
    }

}
