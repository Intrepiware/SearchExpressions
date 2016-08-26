using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IntrepiwareUtilities.SearchExpressions.Services;

namespace IntrepiwareUtilities.SearchExpressions
{
    public class HasValueExpression
    {
        public BlankOrNullStatus BlankOrNullStatus { get; private set; }

        public HasValueExpression(BlankOrNullStatus status)
        {
            BlankOrNullStatus = status;
        }
    }

    public class HasValueExpression<T> : SearchExpression<T>
    {
        public BlankOrNullStatus BlankOrNullStatus { get; private set; }

        public HasValueExpression(BlankOrNullStatus status)
        {
            BlankOrNullStatus = status;
        }

        public override string ToSqlExpression(string fieldName, string parameterName)
        {
            parameterName = ParameterFormattingService.FormatWithAtSign(parameterName);
            switch (BlankOrNullStatus)
            {
                case BlankOrNullStatus.IsNull:
                    return String.Format(" and {0} is null", fieldName);
                case BlankOrNullStatus.IsBlankOrNull:
                    return String.Format(" and nullif({0}, '') is null", fieldName);
                case BlankOrNullStatus.IsNotNull:
                    return String.Format(" and {0} is not null", fieldName);
                case BlankOrNullStatus.IsNotBlankOrNull:
                    return String.Format(" and nullif({0}, '') is not null", fieldName);
                default:
                    throw new ArgumentException("Unrecognized BlankOrNullStatus");
            }

        }

        public override Dictionary<string, object> GetDynamicParameters(string parameterName)
        {
            Dictionary<string, object> output = new Dictionary<string, object>();
            parameterName = ParameterFormattingService.FormatWithoutAtSign(parameterName);
            output.Add(parameterName, null);
            return output;
        }
    }
}
