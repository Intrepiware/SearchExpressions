using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace IntrepiwareUtilities.SearchExpressions.Tester.Tests
{
    [TestFixture]
    public class StringTest
    {
        [Test()]
        public void Between()
        {
            BetweenExpression<string> expression = null;
            Dictionary<string, object> parameters = null;
            string whereParam = null;

            expression = Expression.Between("a", "b");
            parameters = expression.GetDynamicParameters("@p1");
            whereParam = expression.ToSqlExpression("[Table].[Field]", "@p1");
            Console.WriteLine(String.Join(",", parameters.Keys));

            Assert.AreEqual(parameters["p1___LOW"], "a");
            Assert.AreEqual(parameters["p1___HIGH"], "b");
            Assert.AreEqual(whereParam, " and [Table].[Field] > @p1___LOW and [Table].[Field] < @p1___HIGH");
        }

        [Test()]
        public void Between_MissingAtSymb()
        {
            BetweenExpression<string> expression = null;
            Dictionary<string, object> parameters = null;
            string whereParam = null;

            expression = Expression.Between("a", "b");
            parameters = expression.GetDynamicParameters("p1");
            whereParam = expression.ToSqlExpression("[Table].[Field]", "p1");
            Console.WriteLine(String.Join(",", parameters.Keys));

            Assert.AreEqual(parameters["p1___LOW"], "a");
            Assert.AreEqual(parameters["p1___HIGH"], "b");
            Assert.AreEqual(whereParam, " and [Table].[Field] > @p1___LOW and [Table].[Field] < @p1___HIGH");
        }

        [Test()]
        public void BetweenInclusive()
        {
            BetweenExpression<string> expression = null;
            Dictionary<string, object> parameters = null;
            string whereParam = null;

            expression = Expression.BetweenInclusive("a", "b");
            parameters = expression.GetDynamicParameters("@p1");
            whereParam = expression.ToSqlExpression("[Table].[Field]", "@p1");
            Console.WriteLine(String.Join(",", parameters.Keys));

            Assert.AreEqual(parameters["p1___LOW"], "a");
            Assert.AreEqual(parameters["p1___HIGH"], "b");
            Assert.AreEqual(whereParam, " and [Table].[Field] >= @p1___LOW and [Table].[Field] <= @p1___HIGH");
        }

        [Test()]
        public void BetweenInclusive_MissingAtSymb()
        {
            BetweenExpression<string> expression = null;
            Dictionary<string, object> parameters = null;
            string whereParam = null;

            expression = Expression.BetweenInclusive("a", "b");
            parameters = expression.GetDynamicParameters("p1");
            whereParam = expression.ToSqlExpression("[Table].[Field]", "p1");
            Console.WriteLine(String.Join(",", parameters.Keys));

            Assert.AreEqual(parameters["p1___LOW"], "a");
            Assert.AreEqual(parameters["p1___HIGH"], "b");
            Assert.AreEqual(whereParam, " and [Table].[Field] >= @p1___LOW and [Table].[Field] <= @p1___HIGH");
        }

        [Test()]
        public void BetweenInclusiveHigher()
        {
            BetweenExpression<string> expression = null;
            Dictionary<string, object> parameters = null;
            string whereParam = null;

            expression = Expression.BetweenInclusiveHigher("a", "b");
            parameters = expression.GetDynamicParameters("@p1");
            whereParam = expression.ToSqlExpression("[Table].[Field]", "@p1");
            Console.WriteLine(String.Join(",", parameters.Keys));

            Assert.AreEqual(parameters["p1___LOW"], "a");
            Assert.AreEqual(parameters["p1___HIGH"], "b");
            Assert.AreEqual(whereParam, " and [Table].[Field] > @p1___LOW and [Table].[Field] <= @p1___HIGH");
        }

        [Test()]
        public void BetweenInclusiveHigher_MissingAtSymb()
        {
            BetweenExpression<string> expression = null;
            Dictionary<string, object> parameters = null;
            string whereParam = null;

            expression = Expression.BetweenInclusiveHigher("a", "b");
            parameters = expression.GetDynamicParameters("p1");
            whereParam = expression.ToSqlExpression("[Table].[Field]", "p1");
            Console.WriteLine(String.Join(",", parameters.Keys));

            Assert.AreEqual(parameters["p1___LOW"], "a");
            Assert.AreEqual(parameters["p1___HIGH"], "b");
            Assert.AreEqual(whereParam, " and [Table].[Field] > @p1___LOW and [Table].[Field] <= @p1___HIGH");
        }
        [Test()]
        public void BetweenInclusiveLower()
        {
            BetweenExpression<string> expression = null;
            Dictionary<string, object> parameters = null;
            string whereParam = null;

            expression = Expression.BetweenInclusiveLower("a", "b");
            parameters = expression.GetDynamicParameters("@p1");
            whereParam = expression.ToSqlExpression("[Table].[Field]", "@p1");
            Console.WriteLine(String.Join(",", parameters.Keys));

            Assert.AreEqual(parameters["p1___LOW"], "a");
            Assert.AreEqual(parameters["p1___HIGH"], "b");
            Assert.AreEqual(whereParam, " and [Table].[Field] >= @p1___LOW and [Table].[Field] < @p1___HIGH");
        }

        [Test()]
        public void BetweenInclusiveLower_MissingAtSymb()
        {
            BetweenExpression<string> expression = null;
            Dictionary<string, object> parameters = null;
            string whereParam = null;

            expression = Expression.BetweenInclusiveLower("a", "b");
            parameters = expression.GetDynamicParameters("p1");
            whereParam = expression.ToSqlExpression("[Table].[Field]", "p1");
            Console.WriteLine(String.Join(",", parameters.Keys));

            Assert.AreEqual(parameters["p1___LOW"], "a");
            Assert.AreEqual(parameters["p1___HIGH"], "b");
            Assert.AreEqual(whereParam, " and [Table].[Field] >= @p1___LOW and [Table].[Field] < @p1___HIGH");
        }


        [Test()]
        public void DoesNotEqual()
        {
            EqualityExpression<string> expression = null;
            Dictionary<string, object> parameters = null;
            string whereParam = null;

            expression = Expression.DoesNotEqual("a");
            parameters = expression.GetDynamicParameters("@p1");
            whereParam = expression.ToSqlExpression("[Table].[Field]", "@p1");
            Console.WriteLine(String.Join(",", parameters.Keys));

            Assert.AreEqual(parameters["p1"], "a");
            Assert.AreEqual(whereParam, " and [Table].[Field] <> @p1");
        }

        [Test()]
        public void DoesNotEqual_MissingAtSymb()
        {
            EqualityExpression<string> expression = null;
            Dictionary<string, object> parameters = null;
            string whereParam = null;

            expression = Expression.DoesNotEqual("a");
            parameters = expression.GetDynamicParameters("p1");
            whereParam = expression.ToSqlExpression("[Table].[Field]", "p1");
            Console.WriteLine(String.Join(",", parameters.Keys));

            Assert.AreEqual(parameters["p1"], "a");
            Assert.AreEqual(whereParam, " and [Table].[Field] <> @p1");
        }

        [Test()]
        public void Equals()
        {
            EqualityExpression<string> expression = null;
            Dictionary<string, object> parameters = null;
            string whereParam = null;

            expression = Expression.Equals("a");
            parameters = expression.GetDynamicParameters("@p1");
            whereParam = expression.ToSqlExpression("[Table].[Field]", "@p1");
            Console.WriteLine(String.Join(",", parameters.Keys));

            Assert.AreEqual(parameters["p1"], "a");
            Assert.AreEqual(whereParam, " and [Table].[Field] = @p1");
        }

        [Test()]
        public void Equals_MissingAtSymb()
        {
            EqualityExpression<string> expression = null;
            Dictionary<string, object> parameters = null;
            string whereParam = null;

            expression = Expression.Equals("a");
            parameters = expression.GetDynamicParameters("p1");
            whereParam = expression.ToSqlExpression("[Table].[Field]", "p1");
            Console.WriteLine(String.Join(",", parameters.Keys));

            Assert.AreEqual(parameters["p1"], "a");
            Assert.AreEqual(whereParam, " and [Table].[Field] = @p1");
        }

        [Test()]
        public void GreaterThan()
        {
            InequalityExpression<string> expression = null;
            Dictionary<string, object> parameters = null;
            string whereParam = null;

            expression = Expression.GreaterThan("a");
            parameters = expression.GetDynamicParameters("@p1");
            whereParam = expression.ToSqlExpression("[Table].[Field]", "@p1");
            Console.WriteLine(String.Join(",", parameters.Keys));

            Assert.AreEqual(parameters["p1"], "a");
            Assert.AreEqual(whereParam, " and [Table].[Field] > @p1");
        }

        [Test()]
        public void GreaterThan_MissingAtSymb()
        {
            InequalityExpression<string> expression = null;
            Dictionary<string, object> parameters = null;
            string whereParam = null;

            expression = Expression.GreaterThan("a");
            parameters = expression.GetDynamicParameters("p1");
            whereParam = expression.ToSqlExpression("[Table].[Field]", "p1");
            Console.WriteLine(String.Join(",", parameters.Keys));

            Assert.AreEqual(parameters["p1"], "a");
            Assert.AreEqual(whereParam, " and [Table].[Field] > @p1");
        }
        
        [Test()]
        public void GreaterThanOrEqualTo()
        {
            InequalityExpression<string> expression = null;
            Dictionary<string, object> parameters = null;
            string whereParam = null;

            expression = Expression.GreaterThanOrEqualTo("a");
            parameters = expression.GetDynamicParameters("@p1");
            whereParam = expression.ToSqlExpression("[Table].[Field]", "@p1");
            Console.WriteLine(String.Join(",", parameters.Keys));

            Assert.AreEqual(parameters["p1"], "a");
            Assert.AreEqual(whereParam, " and [Table].[Field] >= @p1");
        }

        [Test()]
        public void GreaterThanOrEqualTo_MissingAtSymb()
        {
            InequalityExpression<string> expression = null;
            Dictionary<string, object> parameters = null;
            string whereParam = null;

            expression = Expression.GreaterThanOrEqualTo("a");
            parameters = expression.GetDynamicParameters("p1");
            whereParam = expression.ToSqlExpression("[Table].[Field]", "p1");
            Console.WriteLine(String.Join(",", parameters.Keys));

            Assert.AreEqual(parameters["p1"], "a");
            Assert.AreEqual(whereParam, " and [Table].[Field] >= @p1");
        }

        [Test()]
        public void HasValue()
        {
            SearchExpression<string> expression = null;
            Dictionary<string, object> parameters = null;
            string whereParam = null;

            expression = Expression.HasValue();
            parameters = expression.GetDynamicParameters("@p1");
            whereParam = expression.ToSqlExpression("[Table].[Field]", "@p1");

            Assert.IsNull(parameters["p1"]);
            Assert.AreEqual(whereParam, " and [Table].[Field] is not null");
        }

        [Test()]
        public void HasValue_MissingAtSymb()
        {
            SearchExpression<string> expression = null;
            Dictionary<string, object> parameters = null;
            string whereParam = null;

            expression = Expression.HasValue();
            parameters = expression.GetDynamicParameters("p1");
            whereParam = expression.ToSqlExpression("[Table].[Field]", "p1");

            Assert.IsNull(parameters["p1"]);
            Assert.AreEqual(whereParam, " and [Table].[Field] is not null");
        }

        [Test()]
        public void InSet()
        {
            SearchExpression<string> expression = null;
            Dictionary<string, object> parameters = null;
            string whereParam = null;

            expression = Expression.InSet(new[] { "a", "b" });
            parameters = expression.GetDynamicParameters("@p1");
            whereParam = expression.ToSqlExpression("[Table].[Field]", "@p1");

            Assert.IsTrue(((IEnumerable<string>)parameters["p1"]).Contains("a"));
            Assert.IsTrue(((IEnumerable<string>)parameters["p1"]).Contains("b"));
            Assert.AreEqual(whereParam, " and [Table].[Field] in @p1");
        }

        [Test()]
        public void InSet_MissingAtSymb()
        {
            SearchExpression<string> expression = null;
            Dictionary<string, object> parameters = null;
            string whereParam = null;

            expression = Expression.InSet(new[] { "a", "b" });
            parameters = expression.GetDynamicParameters("p1");
            whereParam = expression.ToSqlExpression("[Table].[Field]", "p1");

            Assert.IsTrue(((IEnumerable<string>)parameters["p1"]).Contains("a"));
            Assert.IsTrue(((IEnumerable<string>)parameters["p1"]).Contains("b"));
            Assert.AreEqual(whereParam, " and [Table].[Field] in @p1");
        }

        [Test()]
        public void IsBlankOrNull()
        {
            SearchExpression<string> expression = null;
            Dictionary<string, object> parameters = null;
            string whereParam = null;

            expression = Expression.IsBlankOrNull();
            parameters = expression.GetDynamicParameters("@p1");
            whereParam = expression.ToSqlExpression("[Table].[Field]", "@p1");

            Assert.IsNull(parameters["p1"]);
            Assert.AreEqual(whereParam, " and nullif([Table].[Field], '') is null");
        }

        [Test()]
        public void IsBlankOrNull_MissingAtSymb()
        {
            SearchExpression<string> expression = null;
            Dictionary<string, object> parameters = null;
            string whereParam = null;

            expression = Expression.IsBlankOrNull();
            parameters = expression.GetDynamicParameters("p1");
            whereParam = expression.ToSqlExpression("[Table].[Field]", "p1");

            Assert.IsNull(parameters["p1"]);
            Assert.AreEqual(whereParam, " and nullif([Table].[Field], '') is null");
        }

        [Test()]
        public void IsNotBlankOrNull()
        {
            SearchExpression<string> expression = null;
            Dictionary<string, object> parameters = null;
            string whereParam = null;

            expression = Expression.IsNotBlankOrNull();
            parameters = expression.GetDynamicParameters("@p1");
            whereParam = expression.ToSqlExpression("[Table].[Field]", "@p1");

            Assert.IsNull(parameters["p1"]);
            Assert.AreEqual(whereParam, " and nullif([Table].[Field], '') is not null");
        }

        [Test()]
        public void IsNotBlankOrNull_MissingAtSymb()
        {
            SearchExpression<string> expression = null;
            Dictionary<string, object> parameters = null;
            string whereParam = null;

            expression = Expression.IsNotBlankOrNull();
            parameters = expression.GetDynamicParameters("p1");
            whereParam = expression.ToSqlExpression("[Table].[Field]", "p1");

            Assert.IsNull(parameters["p1"]);
            Assert.AreEqual(whereParam, " and nullif([Table].[Field], '') is not null");
        }


        [Test()]
        public void LessThan()
        {
            InequalityExpression<string> expression = null;
            Dictionary<string, object> parameters = null;
            string whereParam = null;

            expression = Expression.LessThan("a");
            parameters = expression.GetDynamicParameters("@p1");
            whereParam = expression.ToSqlExpression("[Table].[Field]", "@p1");
            Console.WriteLine(String.Join(",", parameters.Keys));

            Assert.AreEqual(parameters["p1"], "a");
            Assert.AreEqual(whereParam, " and [Table].[Field] < @p1");
        }

        [Test()]
        public void LessThan_MissingAtSymb()
        {
            InequalityExpression<string> expression = null;
            Dictionary<string, object> parameters = null;
            string whereParam = null;

            expression = Expression.LessThan("a");
            parameters = expression.GetDynamicParameters("p1");
            whereParam = expression.ToSqlExpression("[Table].[Field]", "p1");
            Console.WriteLine(String.Join(",", parameters.Keys));

            Assert.AreEqual(parameters["p1"], "a");
            Assert.AreEqual(whereParam, " and [Table].[Field] < @p1");
        }

        [Test()]
        public void LessThanOrEqualTo()
        {
            InequalityExpression<string> expression = null;
            Dictionary<string, object> parameters = null;
            string whereParam = null;

            expression = Expression.LessThanOrEqualTo("a");
            parameters = expression.GetDynamicParameters("@p1");
            whereParam = expression.ToSqlExpression("[Table].[Field]", "@p1");
            Console.WriteLine(String.Join(",", parameters.Keys));

            Assert.AreEqual(parameters["p1"], "a");
            Assert.AreEqual(whereParam, " and [Table].[Field] <= @p1");
        }

        [Test()]
        public void LessThanOrEqualTo_MissingAtSymb()
        {
            InequalityExpression<string> expression = null;
            Dictionary<string, object> parameters = null;
            string whereParam = null;

            expression = Expression.LessThanOrEqualTo("a");
            parameters = expression.GetDynamicParameters("p1");
            whereParam = expression.ToSqlExpression("[Table].[Field]", "p1");
            Console.WriteLine(String.Join(",", parameters.Keys));

            Assert.AreEqual(parameters["p1"], "a");
            Assert.AreEqual(whereParam, " and [Table].[Field] <= @p1");
        }

        [Test()]
        public void Like()
        {
            LikeExpression expression = null;
            Dictionary<string, object> parameters = null;
            string whereParam = null;

            expression = Expression.LikeValue("testtest");
            parameters = expression.GetDynamicParameters("@p1");
            whereParam = expression.ToSqlExpression("[Table].[Field]", "@p1");

            Assert.AreEqual(parameters["p1"], "testtest");
            Assert.AreEqual(whereParam, " and [Table].[Field] like @p1");
        }

        [Test]

        public void LikeMissingAtSymb()
        {
            LikeExpression expression = null;
            Dictionary<string, object> parameters = null;
            string whereParam = null;

            expression = Expression.LikeValue("testtest");
            parameters = expression.GetDynamicParameters("p1");
            whereParam = expression.ToSqlExpression("[Table].[Field]", "p1");

            Assert.AreEqual(parameters["p1"], "testtest");
            Assert.AreEqual(whereParam, " and [Table].[Field] like @p1");
        }
        
        [Test()]
        public void NotInSet()
        {
            SearchExpression<string> expression = null;
            Dictionary<string, object> parameters = null;
            string whereParam = null;

            expression = Expression.NotInSet(new[] { "a", "b" });
            parameters = expression.GetDynamicParameters("@p1");
            whereParam = expression.ToSqlExpression("[Table].[Field]", "@p1");

            Assert.IsTrue(((IEnumerable<string>)parameters["p1"]).Contains("a"));
            Assert.IsTrue(((IEnumerable<string>)parameters["p1"]).Contains("b"));
            Assert.AreEqual(whereParam, " and [Table].[Field] not in @p1");
        }

        [Test()]
        public void NotInSet_MissingAtSymb()
        {
            SearchExpression<string> expression = null;
            Dictionary<string, object> parameters = null;
            string whereParam = null;

            expression = Expression.NotInSet(new[] { "a", "b" });
            parameters = expression.GetDynamicParameters("p1");
            whereParam = expression.ToSqlExpression("[Table].[Field]", "p1");

            Assert.IsTrue(((IEnumerable<string>)parameters["p1"]).Contains("a"));
            Assert.IsTrue(((IEnumerable<string>)parameters["p1"]).Contains("b"));
            Assert.AreEqual(whereParam, " and [Table].[Field] not in @p1");
        }

    }
}
