# SearchExpressions

SearchExpressions is a library that simplifies the construction of a parameterized "WHERE" clause in a SQL query. It is intended to be used in tandem with the [Dapper.NET] library.

## The Problem
Suppose that you have a SQL table "Student" that contains the column "GPA." On some occasions, you query this field for an exact value (GPA = 3.0); other times you query it for a range (GPA between 3.5 and 4.0). Also, because first-semester freshmen haven't taken any classes yet, GPA may be a null value for some records. However, you'd still like to query for these students for QA/verification purposes.

How do you write a function to handle these scenarios? (Suppose that an ORM is not available, or the query is too complex to be modelled in an ORM). Typically, you might write something like this:
```sh
public static List<Student> GetStudents(double? lowGPA, double? highGPA, double? exactGPA, bool gpaHasValue)
{
    ...
}
```

This is problematic for many reasons:

  - You now have four parameters for a single database field, which is hard to read. If this function allows querying on multiple database fields, the number of parameters can quickly get out-of-hand.
  - Sure, you could consider removing the "exactGPA" field, but what would then be your upper and lower bounds? 3.0 and 3.000000001? Is the lower bound inclusive? Will a developer know that without documentation?
  - Logically, gpaHasValue is mutually exclusive with the other parameters. What is the expected result of GetStudents(3.0, 3.1, null, false)?

## Using SearchExpressions

SearchExpressions solves this problem by reducing the number of function parameters required for each database field. In many cases (although not all), you can assign a single parameter per database field.

```sh
public static List<Student> GetStudent(SearchExpression<double> gpa)
{
    DynamicParameters parameters = new DynamicParameters();
    SqlConnection connection = new SqlConnection();
    string query = "select * from Student where 1 = 1";
    
    if(gpa != null)
    {
        query += gpa.ToSqlExpression("[Employee].[GPA]", "@gpa");
        parameters.Add(gpa.GetDynamicParameters("gpa"));
    }
    
    return connection.Query<Student>(query, parameters).ToList();
}

// Query students where GPA = 3.0.
// SQL Statement becomes select * from Student where Student.GPA = @gpa; @gpa = 3.0
GetStudent(Expression.Equals(3.0))

// Query students where GPA between 3.5 and 4.0, inclusive
// SQL statement becomes select * from Student where Student.GPA >= @gpa__LOW and Student.GPA <= @gpa__HIGH; @gpa__Low = 3.5 and @gpa__High = 4.0
GetStudent(Expression.BetweenInclusive(3.5, 4.0))

// Query students where GPA is null
// SQL Statement becomes select * from Student where Student.GPA is null
GetStudent(Expression.DoesNotHaveValue())
```

License
----

MIT


[//]: # (Reference Links)

   [Dapper.NET]: <https://github.com/StackExchange/dapper-dot-net>
