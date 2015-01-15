using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntrepiwareUtilities.Modules
{

    public class Expression
    {

        public static BetweenExpression<T> Between<T>(T lowValue, T highValue)
        {
            return new BetweenExpression<T>() { Value = new[] { lowValue, highValue }, HighInclusive = false, LowInclusive = false };
        }

        public static BetweenExpression<T> BetweenInclusive<T>(T lowValue, T highValue)
        {
            return new BetweenExpression<T>() { Value = new[] { lowValue, highValue }, HighInclusive = true, LowInclusive = true };
        }

        public static BetweenExpression<T> BetweenInclusiveHigher<T>(T lowValue, T highValue)
        {
            return new BetweenExpression<T>() { Value = new[] { lowValue, highValue }, HighInclusive = true, LowInclusive = false };
        }

        public static BetweenExpression<T> BetweenInclusiveLower<T>(T lowValue, T highValue)
        {
            return new BetweenExpression<T>() { Value = new[] { lowValue, highValue }, HighInclusive = false, LowInclusive = true };
        }

        public static EqualityExpression DoesNotEqual(object value)
        {
            return new EqualityExpression() { EqualsValue = false, Value = value };
        }

        public static HasValueExpression DoesNotHaveValue()
        {
            return new HasValueExpression() { BlankOrNullStatus = HasValueExpression.STATUS_IS_NOT_NULL };
        }

        public static EqualityExpression Equals(object value)
        {
            return new EqualityExpression() { EqualsValue = true, Value = value };
        }

        public static InequalityExpression GreaterThan(object value)
        {
            return new InequalityExpression() { EqualsValue = false, GreaterThanValue = true, Value = value };
        }

        public static InequalityExpression GreaterThanOrEqualTo(object value)
        {
            return new InequalityExpression() { EqualsValue = true, GreaterThanValue = true, Value = value };
        }

        public static HasValueExpression HasValue()
        {
            return new HasValueExpression() { BlankOrNullStatus = HasValueExpression.STATUS_IS_NOT_NULL };
        }

        public static SetExpression<T> InSet<T>(IEnumerable<T> value)
        {
            return new SetExpression<T>() { InSet = true, Value = value };
        }

        public static HasValueExpression IsBlankOrNull()
        {
            return new HasValueExpression() { BlankOrNullStatus = HasValueExpression.STATUS_IS_BLANK_OR_NULL };
        }

        public static HasValueExpression IsNotBlankOrNull()
        {
            return new HasValueExpression() { BlankOrNullStatus = HasValueExpression.STATUS_IS_NOT_BLANK_OR_NULL };
        }

        public static InequalityExpression LessThan(object value)
        {
            return new InequalityExpression() { GreaterThanValue = false, EqualsValue = false, Value = value };
        }

        public static InequalityExpression LessThanOrEqualTo(object value)
        {
            return new InequalityExpression() { GreaterThanValue = false, EqualsValue = true, Value = value };
        }

        public static SetExpression<T> NotInSet<T>(IEnumerable<T> value)
        {
            return new SetExpression<T>() { InSet = false, Value = value };
        }
    }

    public interface ISearchExpression
    {
        string ToSqlExpression(string fieldName, string parameterName);

        object Value { get; set; }

        Dictionary<string, object> GetDynamicParameters(string parameterName);
    }

    public class BetweenExpression<T> : ISearchExpression
    {
        public object Value { get; set; }

        public bool LowInclusive { get; set; }

        public bool HighInclusive { get; set; }

        public string ToSqlExpression(string fieldName, string parameterName)
        {
            string lowOperator, highOperator;
            string lowParameterName, highParameterName;

            lowOperator = (LowInclusive) ? ">=" : ">";
            highOperator = (HighInclusive) ? "<=" : "<";
            lowParameterName = parameterName + "___LOW";
            highParameterName = parameterName + "___HIGH";
            return String.Format(" and {0} {1} {2} and {3} {4} {5}",
                fieldName, lowOperator, lowParameterName, fieldName, highOperator, highParameterName);
        }

        public Dictionary<string, object> GetDynamicParameters(string parameterName)
        {
            string lowParameterName, highParameterName;
            Dictionary<string, object> output;
            IEnumerable<T> values;

            lowParameterName = parameterName + "___LOW";
            highParameterName = parameterName + "___HIGH";
            values = (IEnumerable<T>)Value;

            output = new Dictionary<string, object>();
            output.Add(lowParameterName, values.ElementAt(0));
            output.Add(highParameterName, values.ElementAt(1));
            return output;
        }
    }

    public class EqualityExpression : ISearchExpression
    {
        public object Value { get; set; }

        public bool EqualsValue { get; set; }

        public string ToSqlExpression(string fieldName, string parameterName)
        {
            string operatorString = (EqualsValue) ? "=" : "<>";
            parameterName = ParameterFormattingService.FormatWithAtSign(parameterName);
            return String.Format(" and {0}{1}{2}", fieldName, operatorString, parameterName);
        }

        public Dictionary<string, object> GetDynamicParameters(string parameterName)
        {
            Dictionary<string, object> output = new Dictionary<string, object>();
            parameterName = ParameterFormattingService.FormatWithoutAtSign(parameterName);
            output.Add(parameterName, Value);
            return output;
        }

    }

    public class HasValueExpression : ISearchExpression
    {

        public int BlankOrNullStatus { get; set; }

        public const int STATUS_IS_NULL = 0;
        public const int STATUS_IS_BLANK_OR_NULL = 1;
        public const int STATUS_IS_NOT_NULL = 2;
        public const int STATUS_IS_NOT_BLANK_OR_NULL = 3;


        public string ToSqlExpression(string fieldName, string parameterName)
        {
            parameterName = ParameterFormattingService.FormatWithAtSign(parameterName);
            switch(BlankOrNullStatus)
            {
                case STATUS_IS_NULL:
                    return String.Format(" and {0} is null", fieldName);
                case STATUS_IS_BLANK_OR_NULL:
                    return String.Format(" and nullif({0}, '') is null", fieldName);
                case STATUS_IS_NOT_NULL:
                    return String.Format(" and {0} is not null", fieldName);
                case STATUS_IS_NOT_BLANK_OR_NULL:
                    return String.Format(" and nullif({0}, '') is not null", fieldName);
                default:
                    throw new ArgumentException("Unrecognized BlankOrNullStatus");
            }

        }

        public object Value
        {
            get
            {
                return null;
            }
            set
            {
                throw new ArgumentException();
            }
        }

        public Dictionary<string, object> GetDynamicParameters(string parameterName)
        {
            Dictionary<string, object> output = new Dictionary<string, object>();
            parameterName = ParameterFormattingService.FormatWithoutAtSign(parameterName);
            output.Add(parameterName, Value);
            return output;
        }
    }

    public class InequalityExpression : ISearchExpression
    {
        public object Value { get; set; }

        public bool GreaterThanValue { get; set; }

        public bool EqualsValue { get; set; }

        public string ToSqlExpression(string fieldName, string parameterName)
        {
            string operatorString = "";
            parameterName = ParameterFormattingService.FormatWithAtSign(parameterName);
            operatorString = (GreaterThanValue) ? ">" : "<";
            operatorString += (EqualsValue) ? "=" : "";

            return String.Format(" and {0}{1}{2}", fieldName, operatorString, parameterName);
        }

        public Dictionary<string, object> GetDynamicParameters(string parameterName)
        {
            Dictionary<string, object> output = new Dictionary<string, object>();
            parameterName = ParameterFormattingService.FormatWithoutAtSign(parameterName);
            output.Add(parameterName, Value);
            return output;
        }

    }

    public class SetExpression<T> : ISearchExpression
    {
        public object Value { get; set; }

        public bool InSet { get; set; }

        public string ToSqlExpression(string fieldName, string parameterName)
        {
            string operatorString = (InSet) ? "in" : "not in";
            parameterName = ParameterFormattingService.FormatWithAtSign(parameterName);
            return String.Format(" and {0} {1} {2}", fieldName, operatorString, parameterName);
        }

        public Dictionary<string, object> GetDynamicParameters(string parameterName)
        {
            Dictionary<string, object> output = new Dictionary<string, object>();
            parameterName = ParameterFormattingService.FormatWithoutAtSign(parameterName);
            output.Add(parameterName, ((IEnumerable<T>)Value).ToArray());
            return output;
        }
    }


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
