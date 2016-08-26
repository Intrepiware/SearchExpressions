using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntrepiwareUtilities.SearchExpressions
{

    public abstract class SearchExpression<T>
    {
        public abstract string ToSqlExpression(string fieldName, string parameterName);

        public abstract Dictionary<string, object> GetDynamicParameters(string parameterName);

        public static implicit operator SearchExpression<T>(HasValueExpression valueExpression)
        {
            return new HasValueExpression<T>(valueExpression.BlankOrNullStatus);
        }
    }
}
