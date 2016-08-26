using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntrepiwareUtilities.SearchExpressions
{
    public static class Expression
    {
        public static BetweenExpression<T> Between<T>(T lowValue, T highValue)
        {
            return new BetweenExpression<T>(lowValue, highValue, false, false);
        }

        public static BetweenExpression<T> BetweenInclusive<T>(T lowValue, T highValue)
        {
            return new BetweenExpression<T>(lowValue, highValue, true, true);
        }

        public static BetweenExpression<T> BetweenInclusiveHigher<T>(T lowValue, T highValue)
        {
            return new BetweenExpression<T>(lowValue, highValue, true, false);
        }

        public static BetweenExpression<T> BetweenInclusiveLower<T>(T lowValue, T highValue)
        {
            return new BetweenExpression<T>(lowValue, highValue, false, true);
        }

        public static EqualityExpression<T> DoesNotEqual<T>(T value)
        {
            return new EqualityExpression<T>(value, false);
        }

        public static HasValueExpression DoesNotHaveValue()
        {
            return new HasValueExpression(BlankOrNullStatus.IsNull);
        }

        public static EqualityExpression<T> Equals<T>(T value)
        {
            return new EqualityExpression<T>(value, true);
        }

        public static InequalityExpression<T> GreaterThan<T>(T value)
        {
            return new InequalityExpression<T>(value, true, false);
        }

        public static InequalityExpression<T> GreaterThanOrEqualTo<T>(T value)
        {
            return new InequalityExpression<T>(value, true, true);
        }

        public static HasValueExpression HasValue()
        {
            return new HasValueExpression(BlankOrNullStatus.IsNotNull);
        }

        public static SetExpression<T> InSet<T>(IEnumerable<T> value)
        {
            return new SetExpression<T>(value, true);
        }

        public static HasValueExpression IsBlankOrNull()
        {
            return new HasValueExpression(BlankOrNullStatus.IsBlankOrNull);
        }

        public static HasValueExpression IsNotBlankOrNull()
        {
            return new HasValueExpression(BlankOrNullStatus.IsNotBlankOrNull);
        }

        public static InequalityExpression<T> LessThan<T>(T value)
        {
            return new InequalityExpression<T>(value, false, false);
        }

        public static InequalityExpression<T> LessThanOrEqualTo<T>(T value)
        {
            return new InequalityExpression<T>(value, false, true);
        }

        public static LikeExpression LikeValue(string value)
        {
            return new LikeExpression(value);
        }

        public static SetExpression<T> NotInSet<T>(IEnumerable<T> value)
        {
            return new SetExpression<T>(value, false);
        }
    }
}
